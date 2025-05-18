namespace MvcSmartStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId{get; set; }
        public DateTime OrderDate { get; set; }


        public User User { get; set; }

        public List<OrderData> OrderDatas { get; set; } = new List<OrderData>();//so its never null cause its required
    }
}
