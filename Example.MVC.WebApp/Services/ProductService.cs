using Example.EF.DbContexts;
using Example.EF.Entities;

namespace Example.MVC.WebApp.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(ExampleDbContext context) : base(context)
        {
         
        }

        public override Product? GetById(string id)
        {
            var product = _context.Products.ToList();
            return product.SingleOrDefault(x => x.ProductId.ToString() == id);
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _context.Products.Where(x => x.ProductName.Contains(name) || x.QuantityPerUnit!.Contains(name)).ToList();
        }
    }
}
