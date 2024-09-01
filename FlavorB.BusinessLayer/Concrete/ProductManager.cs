﻿using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Abstract;
using FlavorBasketAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.BusinessLayer.Concrete
{
  public class ProductManager : IProductService
  {
    private readonly IProductDal _productDal;
		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}
    public int TProductCountByCategoryNameDrink()
    {
      return _productDal.ProductCountByCategoryNameDrink();
    }
    public int TProductCountByCategoryNameHamburger()
    {
     return _productDal.ProductCountByCategoryNameHamburger();
    }
    public void TAdd(Product entity)
    {
      _productDal.Add(entity);
    }
    public void TDelete(Product entity)
    {
      _productDal.Delete(entity);
    }
    public List<Product> TGetAll()
    {
      return _productDal.GetAll();
    }
    public Product TGetByID(int id)
    {
      return _productDal.GetByID(id);
    }
    public List<Product> TGetProductsWithCategories()
    {
      return _productDal.GetProductsWithCategories();
    }
    public int TProductCount()
    {
      return _productDal.ProductCount();
    }
    public void TUpdate(Product entity)
    {
      _productDal.Update(entity);
    }
    public decimal TProductPriceAvg()
    {
      return _productDal.ProductPriceAvg();
    }
    public string TProductNameByMaxPrice()
    {
      return _productDal.ProductNameByMaxPrice();
    }
    public string TProductNameByMinPrice()
    {
      return _productDal.ProductNameByMinPrice();
    }

    public decimal TProductPriceByHamburger()
    {
      return _productDal.ProductPriceByHamburger();
    }
  }
}