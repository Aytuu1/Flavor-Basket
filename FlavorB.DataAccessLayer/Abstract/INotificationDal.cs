﻿using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.Abstract
{
  public interface INotificationDal : IGenericDal<Notification>
  {
    int NotificationCountByStatusFalse();
    List<Notification> GetAllNotificationByFalse();
    void NotificationChangeToTrue(int id);
    void NotificationChangeToFalse(int id);






  }
}