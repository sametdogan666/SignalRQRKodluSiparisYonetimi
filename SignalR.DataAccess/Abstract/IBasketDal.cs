﻿using SignalR.Entities.Entities;

namespace SignalR.DataAccess.Abstract;

public interface IBasketDal : IGenericDal<Basket>
{
    List<Basket> GetBasketByMenuTableNumber(int id);
}