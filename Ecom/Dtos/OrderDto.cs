using Ecom.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Dtos
{
    public class OrderDto
    {
       
        public int QTY { get; set; }
        public int TotalPrice { get; set; }

        public List<int>  productIds { get; set; }

        
        public int uID { get; set; }

    }
}
