using FlavorB.DataAccessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using FlavorB.DataAccessLayer.Repostories;
using FlavorB.DtoLayer.ProductDto;
using FlavorBasketAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FlavorB.DataAccessLayer.EntityFrameWork
{
  public class EfProductDal : GenericRepository<Product>, IProductDal
  {
    public EfProductDal(FlavorBContext context) : base(context)
    {
    }
    public List<Product> GetProductsWithCategories()
    {
      var context = new FlavorBContext();
      var values = context.Products.Include(x => x.Category).ToList();
      return values;
    }
    public int ProductCount()
    {
      using var context = new FlavorBContext();
      return context.Products.Count();
    }
    public int ProductCountByCategoryNameDrink()
    {
      using var context = new FlavorBContext();
      return context.Products
        .Where(x => x
        .CategoryID ==
        (context.Categories
        .Where(y => y.CategoryName == "İçecek")
        .Select(z => z.CategoryID).FirstOrDefault())).Count();
    }
    public int ProductCountByCategoryNameHamburger()
    {
      using var context = new FlavorBContext();
      return context.Products.Where(x => x
      .CategoryID == (context.Categories
      .Where(y => y.CategoryName == "Hamburger")
      .Select(z => z.CategoryID).FirstOrDefault())).Count();
    }
    public string ProductNameByMaxPrice()
    {
      using var context = new FlavorBContext();
      return context.Products
        .Where(x => x.Price == (context.Products.Max(y => y.Price)))
        .Select(z => z.ProductName).FirstOrDefault();
    }
    public string ProductNameByMinPrice()
    {
      using var context = new FlavorBContext();
      return context.Products
        .Where(x => x.Price == (context.Products.Min(y => y.Price)))
        .Select(z => z.ProductName).FirstOrDefault();
    }
    public decimal ProductPriceAvg()
    {
      using var context = new FlavorBContext();
      return context.Products.Average(x => x.Price);
    }
    public decimal ProductPriceByHamburger()
    {
      using var context = new FlavorBContext();
      return context.Products
        .Where(x => x
        .CategoryID == (context.Categories
        .Where(x => x.CategoryName == "Hamburger")
        .Select(z => z.CategoryID).FirstOrDefault()))
        .Average(w => w.Price);
    }
  }
}
