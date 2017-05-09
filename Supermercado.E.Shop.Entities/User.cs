using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado.E.Shop.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public int AttemptsQuantity { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<System.DateTime> LastLoginDateTime { get; set; }
        public int IDRol { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
