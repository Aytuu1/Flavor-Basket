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
	public class SocialMedyaManager : ISocialMedyaService
	{
		private readonly ISocialMedyaDal _socialMedyaDal;

		public SocialMedyaManager(ISocialMedyaDal socialMedyaDal)
		{
			_socialMedyaDal = socialMedyaDal;
		}

		public void TAdd(SocialMedya entity)
		{
			_socialMedyaDal.Add(entity);
		}

		public void TDelete(SocialMedya entity)
		{
			_socialMedyaDal.Delete(entity);
		}

		public List<SocialMedya> TGetAll()
		{
			return _socialMedyaDal.GetAll();
		}

		public SocialMedya TGetByID(int id)
		{
			return _socialMedyaDal.GetByID(id);
		}

		public void TUpdate(SocialMedya entity)
		{
			_socialMedyaDal.Update(entity);
		}
	}
}
