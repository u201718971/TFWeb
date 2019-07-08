using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Service
{
    public interface ICrudService<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        bool Add(T t);

        bool Update(T entity);

    }
}
