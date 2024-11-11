using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DAL.Entities
{
    public class order
    {
        public int Id { get; set; }
        public int QTY { get; set; }
        public int TotalPrice { get; set; }
        public User User { get; set; }
       
        [ForeignKey("UserId")]
        public int uID { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }

    }
}
