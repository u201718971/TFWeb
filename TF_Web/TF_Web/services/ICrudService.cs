using System;
using System.Collections.Generic;
using System.Text;

namespace service
{
    public interface ICrudService<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        bool Add(T t);

        
    }
}
