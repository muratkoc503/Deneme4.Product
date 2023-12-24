using Deneme4.UI.Client;
using Deneme4.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Deneme4.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductClient _productClient;

        public ProductsController(ProductClient productClient)
        {
            _productClient = productClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            var createAuction = await _productClient.CreateProduct(model);
            //if (createAuction.IsSuccess)
                //return RedirectToAction("Products/Create");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var product = await _productClient.GetProducts();
            if (product.IsSuccess)
                return View(product.Data);
            return View();   
        }



    }
}

