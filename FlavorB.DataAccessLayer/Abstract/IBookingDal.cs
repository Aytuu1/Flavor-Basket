using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.Abstract
{
  public interface IBookingDal : IGenericDal<Booking>
  {
    void BookoingStatusApproved(int id);
    void BookoingStatusCancelled(int id);
  }
}
