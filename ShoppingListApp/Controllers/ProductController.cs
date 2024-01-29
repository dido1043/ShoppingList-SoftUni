﻿using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contarcts;
using ShoppingListApp.Models;

namespace ShoppingListApp.Controllers
{
    public class ProductController : Controller
    {   
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
                productService = _productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllAsync();   
            return View(model);
        }
        /// <summary>
        /// Adding products
        /// </summary>
        /// <returns>redirect to action</returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(Add));
            }
            await productService.AddProductAsync(model);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Change product name
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await productService.GetByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model, int id)
        {
            if (ModelState.IsValid == false || model.Id != id)
            {
                return View(model);
            }
            await productService.UpdateProductAsync(model);

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
        
    }
}
