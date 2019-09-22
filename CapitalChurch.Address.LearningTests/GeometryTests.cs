using System.Linq;
using CapitalChurch.Address.Data;
using CapitalChurch.Address.Shared;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NUnit.Framework;
using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using Shouldly;

namespace CapitalChurch.Address.LearningTests
{
    public class GeometryTests
    {        
        private readonly AddressContext _target;
        
        public GeometryTests()
        {
            var builder = new DbContextOptionsBuilder<AddressContext>();

            builder.UseNpgsql(DatabaseConstants.ConnectionString, o => o.UseNetTopologySuite(geographyAsDefault: true));
            
            this._target = new AddressContext(builder.Options);
        }


        [Test]
        public void CreatePointTest()
        {
            var allAddresses = _target.Addresses
                .Where(x => x.Point == null)
                .ToList();

            void UpdateAddressWithPoint(Domain.Model.Address obj)
            {
                if(!obj.Latitude.HasValue || !obj.Longitude.HasValue)
                    return;

                obj.Point = new Point(obj.Latitude.Value, obj.Longitude.Value);
                _target.Attach(obj);
                _target.Entry(obj).State = EntityState.Modified;
            }
            
            allAddresses.ForEach(UpdateAddressWithPoint);
            _target.SaveChanges();
        }

        [Test]
        public void DistanceVerificationOnDbTest()
        {
            var taguatingaCentro = new Point(-15.8326894,-48.0547287);
            var taguaCenter = new Point(-15.8026851,-48.0685222);
            
            var distanceFromCatolica = _target.Addresses
                .Where(x => x.Point != null)
                .Select(x => new
                {
                    DistanceTaguatingaCentro = x.Point.Distance(taguatingaCentro),
                    DistanceTaguaCenter = x.Point.Distance(taguaCenter)
                })
                .FirstOrDefault();
            
            distanceFromCatolica.ShouldNotBeNull();
            distanceFromCatolica.DistanceTaguaCenter.ShouldBeGreaterThan(distanceFromCatolica.DistanceTaguatingaCentro);
        }

        [Test]
        public void CartesianDistanceTest()
        {
            var southCampus = new Point(-15.8136081, -47.8442208);
            var northCampus = new Point(-15.7632746, -47.8779637);
            var epnbCampus = new Point(-15.8756763, -47.992994);

            var cartesianDistanceCampusNorth = epnbCampus.Distance(northCampus);
            var cartesianDistanceCampusSouth = epnbCampus.Distance(southCampus);
            
            cartesianDistanceCampusNorth.ShouldBeGreaterThan(cartesianDistanceCampusSouth);
            
            //result makes no sense, because is cartesian and not geographic(lat, lng)
        }

        [Test]
        public void MetersDistanceTest()
        {
            var brasiliaUtmZone = 23;
            var originCoordinateSystem = GeographicCoordinateSystem.WGS84;
            var targetCoordinateSystem = ProjectedCoordinateSystem.WGS84_UTM(brasiliaUtmZone, false);

            var transform = new CoordinateTransformationFactory().CreateFromCoordinateSystems(
                originCoordinateSystem, targetCoordinateSystem);
            
            var southCampus = new GeoAPI.Geometries.Coordinate(-15.8136081, -47.8442208);
            var northCampus = new GeoAPI.Geometries.Coordinate(-15.7632746, -47.8779637);
            var epnbCampus = new GeoAPI.Geometries.Coordinate(-15.87567632, -47.9929947);
            
            var southCoordinate = new GeoAPI.Geometries.Coordinate(southCampus.X, southCampus.Y);
            var northCoordinate = new GeoAPI.Geometries.Coordinate(northCampus.X, northCampus.Y);
            var epnbCoordinate = new GeoAPI.Geometries.Coordinate(epnbCampus.X, epnbCampus.Y);

            var newSouthCampusPoint = transform.MathTransform.Transform(southCoordinate);
            var newNorthCampusPoint = transform.MathTransform.Transform(northCoordinate);
            var newEnpbCampusPoint = transform.MathTransform.Transform(epnbCoordinate);

            var distanceSouthCampus = newEnpbCampusPoint.Distance(newSouthCampusPoint);
            var distanceNorthCampus = newEnpbCampusPoint.Distance(newNorthCampusPoint);
            
            distanceSouthCampus.ShouldBeGreaterThan(distanceNorthCampus);
            
            //result makes no sense for me, on google says other way
        }

        [Test]
        public void MetersDistanceTaguaTest()
        {
            var brasiliaUtmZone = 23;
            var originCoordinateSystem = GeographicCoordinateSystem.WGS84;
            var targetCoordinateSystem = ProjectedCoordinateSystem.WGS84_UTM(brasiliaUtmZone, false);

            var transform = new CoordinateTransformationFactory().CreateFromCoordinateSystems(
                originCoordinateSystem, targetCoordinateSystem);
            
            var catolica = new GeoAPI.Geometries.Coordinate(-15.8674807,-48.0310518);
            var taguatingaCentro = new GeoAPI.Geometries.Coordinate(-15.8326894,-48.0547287);
            var taguaCenter = new GeoAPI.Geometries.Coordinate(-15.8026851,-48.0685222);
            
            var catolicaCoordinate = new GeoAPI.Geometries.Coordinate(catolica.X, catolica.Y);
            var taguatingaCentroCoordinate = new GeoAPI.Geometries.Coordinate(taguatingaCentro.X, taguatingaCentro.Y);
            var taguaCenterCoordinate = new GeoAPI.Geometries.Coordinate(taguaCenter.X, taguaCenter.Y);

            var newcatolicaPoint = transform.MathTransform.Transform(catolicaCoordinate);
            var newTaguatingaCentroPoint = transform.MathTransform.Transform(taguatingaCentroCoordinate);
            var newTaguaCenterPoint = transform.MathTransform.Transform(taguaCenterCoordinate);

            var distanceTaguatingaCentro = newcatolicaPoint.Distance(newTaguatingaCentroPoint);
            var distanceTaguaCenter = newcatolicaPoint.Distance(newTaguaCenterPoint);
            
            distanceTaguaCenter.ShouldBeGreaterThan(distanceTaguatingaCentro);
            
            //try in strait line, at least this works
        }
    }
}