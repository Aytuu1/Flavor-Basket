using FlavorB.DataAccessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using FlavorB.DataAccessLayer.Repostories;
using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.EntityFrameWork
{
  public class EfOrderDal : GenericRepository<Order>, IOrderDal
  {
    public EfOrderDal(FlavorBContext context) : base(context)
    {
    }

    public int ActiveOrderCount()
    {
     using var context = new FlavorBContext();
      return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
    }

    public decimal LastOrderPrice()
    {
      using var context = new FlavorBContext();
      return context.Orders
        .OrderByDescending(x => x.OrderID)
        .Take(1).Select(y => y.TotalPrice).FirstOrDefault();
    }

    public decimal TodayTotalPrice()
    {
      using var context = new FlavorBContext();
      return 0;
    }
    public int TotalOrderCount()
    {
     using var context = new FlavorBContext();
      return context.Orders.Count();
    }












  }
}
