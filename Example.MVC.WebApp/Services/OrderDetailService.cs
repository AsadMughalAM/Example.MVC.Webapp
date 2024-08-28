using Example.EF.DbContexts;
using Example.EF.Entities;

namespace Example.MVC.WebApp.Services
{
    public class OrderDetailService:BaseService<OrderDetail>
    {
        public OrderDetailService(ExampleDbContext context) : base(context) { }

        public override OrderDetail? GetById(string id)
        {
            var OrderDetail = _context.OrderDetails.ToList();
            return OrderDetail.FirstOrDefault(x => x.OrderId.ToString() == id);
        }

        public IEnumerable<OrderDetail> GetByName(string name) {
            return _context.OrderDetails.Where(x => x.Quantity.ToString().Contains(name) || x.ProductId.ToString().Contains(name)).ToList();
        }

    }
}
