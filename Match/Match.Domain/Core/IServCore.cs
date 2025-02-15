﻿namespace Match.Domain.Core
{
    public interface IServCore<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
