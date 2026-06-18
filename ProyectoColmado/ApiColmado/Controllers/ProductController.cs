using Infraestructure.Product;
using Infraestructure.Product.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiColmado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _services;
        public ProductController(IProductAppService services)
        {
            _services = services;
        }
        [Route("api/[controller]/CreateProduct")]
        [HttpPost]
        public IActionResult CreateProduct(ProducDto dto)
        {
            var NewProduct = _services.AddProduct(dto);
            return Ok(NewProduct);
        }

        [Route("api/[controller]/getProductById/{id}")]
        [HttpGet]
        public IActionResult getProductById(int id) 
        {
            var ListProduct= _services.GetById(id);
            if (ListProduct == null)
            {
                return NotFound($"el id {id} no existe en la base de datos");
            }
            return Ok(ListProduct);
        }
        [Route("api/[controller]/GetAllProducts")]
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var listProducts= _services.GetAllProducts();
            return Ok(listProducts);
        }
        [Route("api/[controller]/ProductNoDelete")]
        [HttpGet]
        public IActionResult ProductNoDelete()
        {
            var listProduct = _services.GetAllProductWihtCondition();
            return Ok(listProduct);
        }
        [Route("api/[controller]/SoftDeleteProduct")]
        [HttpDelete]
        public IActionResult SoftDeleteProduct(int id)
        {
            var product = _services.GetById(id);
            if (product == null)
            {
                return NotFound($"El id {id} no existe en base de datos");
            }
            _services.SoftDelete(id);
            return Ok("El producto fue borrado logicamente");
        }
        [Route("api/[controller]/UpdateProduct")]
        [HttpPut]
        public IActionResult UpdateProduct(int id, ProducDto dto)
        {
            var product = _services.GetById(id);
            if (product == null)
            {
                return NotFound($"El id {id} no existe en la base de datos");
            }
            _services.UpdateProduct(id, dto);
            return Ok(product);
        }
        [Route("api/[controller]/DeleteProduct")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _services.GetById(id);
            if (product == null)
            {
                return NotFound($"El id {id} no existe en la base de datos");
            }
            _services.DeleteProduct(id);
            return Ok("El producto fue borrado definitivamente");
        }
        [Route("api/[controller]/getProductWithCategory")]
        [HttpGet]
        public IActionResult getProductWithCategory()
        {
            var listproducts = _services.GetAllProductWihtCategory();
            return Ok(listproducts);
        }
    }
}
