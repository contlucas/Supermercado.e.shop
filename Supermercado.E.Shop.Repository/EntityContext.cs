using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermercado.E.Shop.Context;

namespace Supermercado.E.Shop.Repository
{
    public class EntityContext<T> : Repository<T>, IDisposable where T : class
    {
        public EntityContext() : base(new SupermercadoEShopDB())
        {

        }

        public void Dispose()
        {
            this.dataTable = null;
            this.dbContext = null;
        }

        ~EntityContext()
        {

        }

        public void ConfirmChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
