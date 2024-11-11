using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DAL.Entities
{
    public class DiscountCode
    {
        public int Id { get; set; }
        public string code { get; set; }
        public decimal codePercentage { get; set; }
        public List<UsedCodes> UsedCodes { get; set; }

    }
}
