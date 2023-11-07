﻿namespace SignalR.Business.Abstract;

public interface IGenericService<T> where T : class
{
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
    T? GetById(int id);
    List<T> GetAll();
}