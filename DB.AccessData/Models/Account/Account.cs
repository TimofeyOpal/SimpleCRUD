using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.AccessData.Models.Account
{
   public class Account
   {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Role[] Roles { get; set; }

   }
   public enum Role
   {
        User,
        Employee, 
        Admin
   }
}
