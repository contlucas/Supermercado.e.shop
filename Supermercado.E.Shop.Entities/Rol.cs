using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.E.Shop.Entities
{
    public class Rol
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
