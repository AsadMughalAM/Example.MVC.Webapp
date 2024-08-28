using Example.EF.DbContexts;
using Example.EF.Entities;

namespace Example.MVC.WebApp.Services
{
    public class ShipperService : BaseService<Shipper>
    {
        public ShipperService(ExampleDbContext context) : base(context)
        {
           
        }

        public override Shipper? GetById(string id)
        {
            var shipper = _context.Shippers.ToList();

            return shipper.FirstOrDefault(x => x.ShipperId.ToString() == id);

        }

        public IEnumerable<Shipper> GetByName(string name)
        {
            return _context.Shippers.Where(x => x.ShipperId.
            ToString().Contains(name) || x.ShipperId.ToString().Contains(name)).ToList();
        }
    }
}
