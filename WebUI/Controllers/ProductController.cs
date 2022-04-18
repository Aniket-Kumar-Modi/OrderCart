using Application.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _procutServices;

        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productServices, ILogger<ProductController> logger)
        {
            _procutServices = productServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _procutServices.GetProducts();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Something Went Wrong");
            }
        }


    }
}
