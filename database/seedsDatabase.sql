CREATE SCHEMA addresses;
    
create table addresses.address(
    id serial not null primary key,
    postalCode int,
    number varchar(100),
    complement varchar(300),
    referencePlace varchar(300),
    addressLine varchar(300),
    neighborhood varchar(300),
    city varchar(300),
    state varchar(80),
    country varchar(80),
    lat double precision,
    long double precision,
    point geography,
    shape geography
);

insert into addresses.address(postalCode, number, complement, referencePlace, addressLine, neighborhood, city, state, country, lat, long)
  values (71735720, '09/10', 'Lote', null, 'ADE Conjunto 2', 'SMPW', 'Nucleo Bandeirante', 'Distrito Federal', 'Brasil', -15.8674807,-48.0310518);
