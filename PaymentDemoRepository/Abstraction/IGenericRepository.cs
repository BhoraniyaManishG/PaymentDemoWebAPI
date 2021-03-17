using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentDemoRepository.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(object id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
