using Infraestructure.Provider;
using Infraestructure.Provider.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiColmado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderAppService _providerService;
        public ProviderController(IProviderAppService providerService)
        {
            _providerService = providerService;
        }
        [Route("api/[controller]/CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct(ProviderDto dto)
        {
            var NewProvider = _providerService.addProvider(dto);
            return Ok(NewProvider);
        }
        [Route("api/[controller]/GetAllProvider")]
        [HttpGet]
        public IActionResult GetAllProvider()
        {
            var providers = _providerService.GetAllProviders();
            return Ok(providers);
        }
        [Route("api/[controller]/GetProviderById/{id}")]
        [HttpGet]
        public IActionResult GetProviderById(int id)
        {
            var provider= _providerService.GetById(id);
            return Ok(provider);
        }
        [Route("api/[controller]/GetProviderWithCondition")]
        [HttpGet]
        public IActionResult GetProviderWithCondition()
        {
            var provider = _providerService.GetAllProviderWihtCondition();
            return Ok(provider);
        }
        [Route("api/[controller]/softDelete")]
        [HttpDelete]
        public IActionResult softDelete(int id)
        {
            var provider = _providerService.SoftDelete(id);
            if (provider == null)
            {
                return NotFound($"El id {id} no existe en la base de datos");
            }
            _providerService.SoftDelete(id);
            return Ok(provider);
        }
        [Route("api/[controller]/DeleteProvider")]
        [HttpDelete]
        public IActionResult DeleteProvider(int id)
        {
            var provider = _providerService.GetById(id);
            if (provider == null)
            {
                return NotFound($"El id {id} no existe en la base de datos");
            }
            _providerService.DeleteProvider(id);
            return Ok("EL proveedor fue borrado definitivamente");
        }
        [Route("api/[controller]/UpdateProvider")]
        [HttpPut]
        public IActionResult UpdateProvider(int id, ProviderDto dto)
        {
            var provider = _providerService.GetById(id);
            if (provider == null)
            {
                return NotFound($"El id {id} no exite en el base de datos");
            }
                _providerService.UpdatePrvider(id, dto);
            return Ok(provider);
        }
    }
}
