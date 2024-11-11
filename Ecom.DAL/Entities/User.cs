using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Password { get; set; }
        public int Age { get; set; }
        public List<order> Orders { get; set; }
        public List<UsedCodes> UsedCodes { get; set; }
    }
}
