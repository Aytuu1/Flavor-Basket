using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.Abstract
{
  public interface IOrderDal : IGenericDal<Order>
  {
    public int TotalOrderCount();
    public int ActiveOrderCount();
    public decimal LastOrderPrice();
    public decimal TodayTotalPrice();





  }
}
