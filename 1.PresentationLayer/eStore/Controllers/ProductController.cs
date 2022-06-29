using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessObject;
using DataAccess.Repository;

namespace eStore.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepository = null;
        public ProductController() => productRepository = new ProductRepository();

        //GET: Index
        public IActionResult Index() {
            var productList = productRepository.GetProducts();
            return View(productList);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            var product = productRepository.GetProductByID(id.Value);
            if (product == null) {
                return NotFound();
            }
            return View(product);
        }
        
    }
}