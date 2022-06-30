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

        //GET 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductObject product)
        {
            try {
                if (ModelState.IsValid) {
                    productRepository.InsertProduct(product);    
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception) {

            }
            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            ProductObject product = productRepository.GetProductByID(Convert.ToInt32(id));
            if (product == null) return NotFound();
            return View(product);
            //
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductObject product)
        {
            try {
                var _product = productRepository.GetProductByID(product.ProductId);
                if (_product == null) return NotFound();
                if (ModelState.IsValid) {
                    productRepository.UpdateProduct(product);    
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception) {

            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            ProductObject product = productRepository.GetProductByID(Convert.ToInt32(id));
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductObject product)
        {
            try {
                var _product = productRepository.GetProductByID(product.ProductId);
                if (_product == null) return NotFound();
                if (ModelState.IsValid) {
                    productRepository.RemoveProduct(product.ProductId);    
                    return RedirectToAction(nameof(Index));
                }
            } catch (Exception) {

            }
            return View(product);
        }
        
    }
}