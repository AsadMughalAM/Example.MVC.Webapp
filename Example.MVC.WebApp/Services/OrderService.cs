using Example.EF.DbContexts;
using Example.EF.Entities;

namespace Example.MVC.WebApp.Services
{
    public class OrderService : BaseService<Order>
    {
        public OrderService(ExampleDbContext context) : base(context)
        {
        }

        public override Order? GetById(string id)
        {
            var Order = _context.Orders.ToList();
            return Order.SingleOrDefault(x => x.OrderId.ToString() == id);
        }

        public IEnumerable <Order> GetByName(string name)
        {
            return _context.Orders.Where(x => x.ShipName!.Contains(name) || x.ShipCountry!.Contains(name)).ToList();
        }
    }
}
