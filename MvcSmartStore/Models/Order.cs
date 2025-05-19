namespace MvcSmartStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId{get; set; }

        public int SmartphoneId {get; set; }
        public DateTime OrderDate { get; set; }


        public User User { get; set; }
        public Smartphone Smartphone { get; set; }

    }
}
