using System.ComponentModel.DataAnnotations;

namespace MvcSmartStore.Models
{
    public class Smartphone
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public float Price  { get; set; }
        public string Selling_platform { get; set; }
        public float Rating { get; set; }
        public int Refresh_rate { get; set; }
        public float Screen_size { get; set; }
        public int Ram {  get; set; }
        public int Storage {  get; set; }
        public string Processor { get; set; }
        public string Camera_setup { get; set; }
        public string imgURL { get; set; }

    }
}
