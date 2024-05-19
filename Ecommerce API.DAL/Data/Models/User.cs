using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.DAL.Data.Models
{
    public class User : IdentityUser
    {
        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
