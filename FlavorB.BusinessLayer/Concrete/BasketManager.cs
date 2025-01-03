﻿using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Abstract;
using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.BusinessLayer.Concrete
{
  public class BasketManager : IBasketService
  {
    private readonly IBasketDal _basketDal;

    public BasketManager(IBasketDal basketDal)
    {
      _basketDal = basketDal;
    }

    public void TAdd(Basket entity)
    {
      _basketDal.Add(entity);
    }

    public void TDelete(Basket entity)
    {
      _basketDal.Delete(entity);
    }

    public List<Basket> TGetAll()
    {
      throw new NotImplementedException();
    }

    public List<Basket> TGetBasketByMenuTableNumber(int id)
    {
      return _basketDal.GetBasketByMenuTableNumber(id);
    }

    public Basket TGetByID(int id)
    {
      return _basketDal.GetByID(id);
    }

    public void TUpdate(Basket entity)
    {
      throw new NotImplementedException();
    }
  }
}
