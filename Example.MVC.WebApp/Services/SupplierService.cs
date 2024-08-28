using Example.EF.DbContexts;
using Example.EF.Entities;

namespace Example.MVC.WebApp.Services
{
    public class SupplierService : BaseService<Supplier>
    {
        public SupplierService(ExampleDbContext context) : base(context)
        {
        }

        public override Supplier? GetById(string id)
        {
            var supplier = _context.Suppliers.ToList();

            return supplier.FirstOrDefault(x => x.SupplierId.ToString() == id);

        }
        public IEnumerable<Supplier> GetByName(string name)
        {
            return _context.Suppliers.Where(x => x.ContactName!.ToString().Contains(name) || x.CompanyName.Contains(name)).ToList();
        }

    }
}
