using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rema1000.Models;

namespace Rema1000.Services
{
    public interface IProductCategoryRead<T>
    {
        List<T> ReadByCategory(Guid categoryID);
    }
}
