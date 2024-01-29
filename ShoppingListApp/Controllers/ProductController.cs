using Microsoft.AspNetCore.Mvc;
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
            await productService.AddProductAsync(model);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Change product name
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
        
    }
}
