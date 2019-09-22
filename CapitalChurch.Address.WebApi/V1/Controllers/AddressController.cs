using CapitalChurch.Address.Shared.Contracts.Business;
using CapitalChurch.Address.WebApi.V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapitalChurch.Address.WebApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAppAddress _app;

        public AddressController(IAppAddress app)
        {
            _app = app;
        }

        [HttpPost]
        public AddressViewModel Insert([FromBody] AddressViewModel obj) =>
            _app.Create(obj);
    }
}