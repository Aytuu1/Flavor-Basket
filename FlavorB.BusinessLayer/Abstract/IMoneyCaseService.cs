using FlavorB.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.BusinessLayer.Abstract
{
  public interface IMoneyCaseService:IGenericService<MoneyCase>
  {
    public decimal TTotalMoneyCaseAmount();
  }
}
