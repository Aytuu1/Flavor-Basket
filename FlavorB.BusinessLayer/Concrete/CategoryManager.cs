using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Abstract;
using FlavorBasketAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.BusinessLayer.Concrete
{
  public class CategoryManager : ICategoryService
  {
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
      _categoryDal = categoryDal;
    }

    public int TActiveCategoryCount()
    {
     return _categoryDal.ActiveCategoryCount();
    }

    public int TPassiveCategoryCount()
    {
      return _categoryDal.PassiveCategoryCount();
    }

    public void TAdd(Category entity)
    {
      _categoryDal.Add(entity);
    }

    public int TCategoryCount()
    {
      return _categoryDal.CategoryCount();
    }

    public void TDelete(Category entity)
    {
      _categoryDal.Delete(entity);
    }

    public List<Category> TGetAll()
    {
      return _categoryDal.GetAll();
    }

    public Category TGetByID(int id)
    {
      return _categoryDal.GetByID(id);
    }

    public void TUpdate(Category entity)
    {
      _categoryDal.Update(entity);
    }
  }
}
