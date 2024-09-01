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
  public class EfBookingDal : GenericRepository<Booking>, IBookingDal
  {
    public EfBookingDal(FlavorBContext context) : base(context)
    {
    }

    public void BookoingStatusApproved(int id)
    {
      using var context = new FlavorBContext();
      var values = context.Bookings.Find(id);
      values.Description = "Rezervasyon Onaylandı";
      context.SaveChanges();
    }

    public void BookoingStatusCancelled(int id)
    {
      using var context = new FlavorBContext();
      var values = context.Bookings.Find(id);
      values.Description = "Rezervasyon İptal Edildi";
      context.SaveChanges();
    }
  }
}
