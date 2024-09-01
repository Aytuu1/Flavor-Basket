using FlavorB.DataAccessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using FlavorB.DataAccessLayer.Repostories;
using FlavorB.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.EntityFrameWork
{
  public class EfBasketDal : GenericRepository<Basket>, IBasketDal
  {
    public EfBasketDal(FlavorBContext context) : base(context)
    {
    }

    public List<Basket> GetBasketByMenuTableNumber(int id)
    {
      using var context = new FlavorBContext();
      var value = context.Baskets.Where(x=>x.MenuTableID == id).Include(y=>y.Product).ToList();
      return value;
    }
  }
}
