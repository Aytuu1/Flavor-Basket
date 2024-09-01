using FlavorB.DataAccessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using FlavorB.DataAccessLayer.Repostories;
using FlavorBasketAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.EntityFrameWork
{
	public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
	{
		public EfCategoryDal(FlavorBContext context) : base(context)
		{
		}

    public int ActiveCategoryCount()
    {
      using var context = new FlavorBContext();
      return context.Categories.Where(x=>x.CategoryStatus==true).Count();
    }

    public int CategoryCount()
    {
      using var context = new FlavorBContext();
      return context.Categories.Count();
    }

    public int PassiveCategoryCount()
    {
      using var context= new FlavorBContext();
      return context.Categories.Where(x=>x.CategoryStatus==false).Count();
    }
  }
}
