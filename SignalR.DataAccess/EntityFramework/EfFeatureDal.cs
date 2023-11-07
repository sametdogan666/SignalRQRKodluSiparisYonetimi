﻿using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
{
    public EfFeatureDal(SignalRContext context) : base(context)
    {
    }
}