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
  public class EfSliderDal : GenericRepository<Slider>, ISliderDal
  {
    public EfSliderDal(FlavorBContext context) : base(context)
    {
    }
  }
}
