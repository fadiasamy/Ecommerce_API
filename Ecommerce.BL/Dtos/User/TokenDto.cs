using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_API.BL.Dtos.User
{
    
  public record TokenDto(string Token, DateTime ExpirDates);
    
}
