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
  public class EfMoneyCaseDal : GenericRepository<MoneyCase>,IMoneyCaseDal
  {
    public EfMoneyCaseDal(FlavorBContext context) : base(context)
    {
    }

    public decimal TotalMoneyCaseAmount()
    {
      using var context = new FlavorBContext();
      return context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
    }
  }
}
