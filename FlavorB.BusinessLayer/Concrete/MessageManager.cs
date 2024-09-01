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
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void TAdd(Message entity)
		{
			_messageDal.Add(entity);
		}

		public void TDelete(Message entity)
		{
			_messageDal.Delete(entity);
		}

		public List<Message> TGetAll()
		{
			return _messageDal.GetAll();
		}

		public Message TGetByID(int id)
		{
			return _messageDal.GetByID(id);
		}

		public void TUpdate(Message entity)
		{
			_messageDal.Update(entity);
		}
	}
}
