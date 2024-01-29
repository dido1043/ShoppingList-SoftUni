using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Contarcts;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
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
        public async Task AddProductAsync(ProductViewModel model)
        { 
            if (model == null)
            {
                throw new ArgumentException("Invalid product");
            }
            var entity = new Product()
            {
                Name = model.Name
            };
            await _context.Products.AddAsync(entity);
            _context.SaveChangesAsync();
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

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid product");
            }
            return new ProductViewModel() { Id = entity.Id, Name = entity.Name };
        }

        public Task UpdateProductAsync(ProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
