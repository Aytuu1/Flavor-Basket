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
  public class EfNotificationDal : GenericRepository<Notification>,INotificationDal
  {
    public EfNotificationDal(FlavorBContext context) : base(context)
    {
    }

    public List<Notification> GetAllNotificationByFalse()
    {
      using var context = new FlavorBContext();
      return context.Notifications.Where(x=>x.Status==false).ToList();
    }

    public void NotificationChangeToFalse(int id)
    {
      using var context = new FlavorBContext();
      var value = context.Notifications.Find(id);
      value.Status = false;
      context.SaveChanges();
    }

    public void NotificationChangeToTrue(int id)
    {
      using var context= new FlavorBContext();
      var value = context.Notifications.Find(id);
      value.Status = true;
      context.SaveChanges();
    }

    public int NotificationCountByStatusFalse()
    {
      using var context = new FlavorBContext();
      return context.Notifications.Where(x=>x.Status==false).Count();
    }





  }
}
