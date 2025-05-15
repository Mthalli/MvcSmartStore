using System.ComponentModel.DataAnnotations;

namespace MvcSmartStore.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
		[Required]
		public string Sex { get; set; }
        [Range (0, 150)]
        public int Age { get; set; }
        [Range(0,1000000)]
        public int Salary {  get; set; }

    }
}
