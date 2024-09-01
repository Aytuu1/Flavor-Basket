using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Abstract;
using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.BusinessLayer.Concrete
{
  public class BookingManager : IBookingService
  {
    private readonly IBookingDal _bookingDal;
    public BookingManager(IBookingDal bookingDal)
    {
      _bookingDal = bookingDal;
    }

    public void TAdd(Booking entity)
    {
      _bookingDal.Add(entity);
    }

    public void TBookoingStatusApproved(int id)
    {
       _bookingDal.BookoingStatusApproved(id);
    }

    public void TBookoingStatusCancelled(int id)
    {
       _bookingDal.BookoingStatusCancelled(id);
    }

    public void TDelete(Booking entity)
    {
      _bookingDal.Delete(entity);
    }

    public List<Booking> TGetAll()
    {
      return _bookingDal.GetAll();
    }

    public Booking TGetByID(int id)
    {
      return _bookingDal.GetByID(id);
    }

    public void TUpdate(Booking entity)
    {
      _bookingDal.Update(entity);
    }
  }
}
