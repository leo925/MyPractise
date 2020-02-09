using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFStudy.Repositories
{
    public interface IDataRepository
    {
        IQueryable<Product> Products { get; }
        IEnumerable<Product> GetProductsByPrice(decimal minPrice);
    }
}
