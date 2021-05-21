using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Models;

namespace Rema1000.Services
{
    public interface IService<T>
    {
        bool SaveChanges();
        T Create(T product);
        T Read(Guid id);
        List<T> Read();
        bool Update(Guid id, T product);
        bool Delete(Guid id);
    }
}
