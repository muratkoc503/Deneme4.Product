using System;
using Deneme4.Product.Controllers;
using Deneme4.Product.Models;
using Deneme4.Product.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Deneme4.ProductTest
{
    [TestFixture]
    public class Tests
    {
        private Mock<IProductRepository> _productRepositoryMock;
        private Mock<ILogger<ProductController>> _loggerMock;
        private ProductController _productController;

        [SetUp]
        public void Setup()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _loggerMock = new Mock<ILogger<ProductController>>();
            _productController = new ProductController(_productRepositoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetProducts_ReturnsOkResult()
        {
            _productRepositoryMock.Setup(repo => repo.GetProducts())
                .ReturnsAsync(new List<Products>());

            var result = await _productController.GetProducts();

            Assert.IsInstanceOf<IEnumerable<Products>>(okResult.Value);
            var okResult = (OkObjectResult)result.Result;
            Assert.IsInstanceOf<IEnumerable<Products>>(okResult.Value);
        }

        [Test]
        public async Task GetProduct_ReturnsNotFoundResult_WhenProductNotFound()
        {
            var productId = Guid.NewGuid();
            _productRepositoryMock.Setup(repo => repo.GetProduct(productId))
                .ReturnsAsync((Products)null);

            var result = await _productController.GetProduct(productId);

            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task CreateProduct_ReturnsCreatedAtRouteResult()
        {
            var newProduct = new Products { Id = Guid.NewGuid(), Name = "Test Product" };

            _productRepositoryMock.Setup(repo => repo.Create(It.IsAny<Products>()))
                .ReturnsAsync(newProduct);

            var result = await _productController.CreateProduct(newProduct);

            Assert.IsInstanceOf<CreatedAtRouteResult>(result.Result);
            var createdAtRouteResult = (CreatedAtRouteResult)result.Result;
            Assert.AreEqual("GetProduct", createdAtRouteResult.RouteName);
            Assert.AreEqual(newProduct.Id, createdAtRouteResult.RouteValues["id"]);
            Assert.AreEqual(newProduct, createdAtRouteResult.Value);
        }

        [Test]
        public async Task UpdateProduct_ReturnsOkResult()
        {
            var existingProduct = new Products { Id = Guid.NewGuid(), Name = "Existing Product" };

            _productRepositoryMock.Setup(repo => repo.Update(It.IsAny<Products>()))
                .ReturnsAsync(existingProduct);

            var result = await _productController.UpdateProduct(existingProduct);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.IsInstanceOf<Products>(okResult.Value);
            Assert.AreEqual(existingProduct, okResult.Value);
        }

        [Test]
        public async Task DeleteProductById_ReturnsOkResult()
        {
            var productId = Guid.NewGuid();
            _productRepositoryMock.Setup(repo => repo.Delete(productId))
                .ReturnsAsync(true);

            var result = await _productController.DeleteProductById(productId);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
