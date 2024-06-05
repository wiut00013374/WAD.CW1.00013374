using System.ComponentModel.DataAnnotations;

namespace Rent_a_car.Models
{
    public class Users
    {

        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public string CustomerPhone { get; set; }

    }
}
