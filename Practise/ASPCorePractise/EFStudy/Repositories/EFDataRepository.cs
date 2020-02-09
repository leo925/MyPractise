using EFStudy.DataBaseContext;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFStudy.Repositories
{
    public class EFDataRepository : IDataRepository
    {
        EFDatabaseContext context;

        public EFDataRepository(EFDatabaseContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;

        public IEnumerable<Product> GetProductsByPrice(decimal minPrice)
        {
            return context.Products.Where(p => p.Price >= minPrice);
        }
    }
}
