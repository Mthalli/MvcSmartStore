using System.ComponentModel.DataAnnotations;

namespace MvcSmartStore.Models
{
    public class OrderData
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public Smartphone Smartphone { get; set; }

    }
}
