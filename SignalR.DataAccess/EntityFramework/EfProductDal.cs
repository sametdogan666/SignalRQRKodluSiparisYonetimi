﻿using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    public EfProductDal(SignalRContext context) : base(context)
    {
    }
}