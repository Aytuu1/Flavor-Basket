using FlavorB.BusinessLayer.Abstract;
using FlavorB.DataAccessLayer.Abstract;
using FlavorBasketAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.BusinessLayer.Concrete
{
	public class FeatureManager : IFeatureService
	{
		private readonly IFeatureDal _featureDal;

		public FeatureManager(IFeatureDal featureDal)
		{
			_featureDal = featureDal;
		}

		public void TAdd(Feature entity)
		{
			_featureDal.Add(entity);
		}

		public void TDelete(Feature entity)
		{
			_featureDal.Delete(entity);
		}

		public List<Feature> TGetAll()
		{
			return _featureDal.GetAll();
		}

		public Feature TGetByID(int id)
		{
			return _featureDal.GetByID(id);
		}

		public void TUpdate(Feature entity)
		{
			_featureDal.Update(entity);
		}
	}
}
