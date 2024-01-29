using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Contarcts;
using ShoppingListApp.Data;
using ShoppingListApp.Models;

namespace ShoppingListApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ShoppingListDbContext _context;
        public ProductService(ShoppingListDbContext context)
        {
            _context = context;
        }
        public Task AddProductAsync(ProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProductAsync(int id)
        {
            var productForDelete = await _context.Products.FindAsync(id);
            if (productForDelete == null)
            {
                throw new ArgumentException("Invalid product");
            }
            _context.Products.Remove(productForDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                .ToListAsync();    
        }

        public Task<ProductViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
