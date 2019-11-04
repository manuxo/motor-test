using System;
using System.Collections.Generic;
using System.Text;

namespace motor.infrastructure.Repositories
{
    public interface IRepository<T,ID>
    {
        void Add(T entity);

        T Find(ID id);

        List<T> List();

        void Update(ID id, T entity);

        void Delete(ID id);
    }
}
