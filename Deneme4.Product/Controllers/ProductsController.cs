using Deneme4.Product.Models;
using Deneme4.Product.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Deneme4.Product.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Variables

        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        #endregion

        #region Constructor

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [Route("GetProducts")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                _logger.LogError($"Product with id : {id},hasn't been found in databasei");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> CreateProduct([FromBody] Products product)
        {
            await _productRepository.Create(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Products product)
        {
            return Ok(await _productRepository.Update(product));
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Products), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            return Ok(await _productRepository.Delete(id));
        }

        #endregion
    }
}