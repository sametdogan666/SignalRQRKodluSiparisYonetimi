﻿using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfAboutDal : GenericRepository<About>, IAboutDal
{
    public EfAboutDal(SignalRContext context) : base(context)
    {
    }
}