﻿using FlavorB.DataAccessLayer.Abstract;
using FlavorB.DataAccessLayer.Concrete;
using FlavorB.DataAccessLayer.Repostories;
using FlavorBasketAPI.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlavorB.DataAccessLayer.EntityFrameWork
{
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public EfFeatureDal(FlavorBContext context) : base(context)
        {
        }
    }
}