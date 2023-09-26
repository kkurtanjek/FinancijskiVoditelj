using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancijskiVoditelj.Models
{
    /// <summary>
    /// User of this software.
    /// </summary>
   public class User
    {
        public string Name { get; set; }
        public string LastNname  { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
