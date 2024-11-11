using Ecom.DAL.Entities;

namespace Ecom.Dtos
{
    public class OrderedProductsDto
    {
       
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int? OrderId { get; set; }

        public order Order { get; set; }
        public int Id { get; set; }
    }
}
