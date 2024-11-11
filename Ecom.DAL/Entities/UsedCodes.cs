using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DAL.Entities
{
    public class UsedCodes
    {
        public int userId { get; set; }
        public User User { get; set; }
        public int discountId { get; set; }
        public DiscountCode Discountcode { get; set; }

        public int Id { get; set; }
    }
}
