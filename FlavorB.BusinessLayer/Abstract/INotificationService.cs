using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.BusinessLayer.Abstract
{
  public interface INotificationService:IGenericService<Notification>
  {
    public int TNotificationCountByStatusFalse();
    List<Notification> TGetAllNotificationByFalse();
    void TNotificationChangeToTrue(int id);
    void TNotificationChangeToFalse(int id);
  }
}
