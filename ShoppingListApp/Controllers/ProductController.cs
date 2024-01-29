using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Contarcts;

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
        [HttpGet]
        public async Task<IActionResult> Add()
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
