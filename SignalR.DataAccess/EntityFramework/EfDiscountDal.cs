﻿using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
{
    public EfDiscountDal(SignalRContext context) : base(context)
    {
    }
}