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

    public void ChangeStatusToTrue(int id)
    {
        using var context = new SignalRContext();
        var value = context.Discounts.Find(id);
        value.Status = true;
        context.SaveChanges();
    }

    public void ChangeStatusToFalse(int id)
    {
        using var context = new SignalRContext();
        var value = context.Discounts.Find(id);
        value.Status = false;
        context.SaveChanges();
    }
}