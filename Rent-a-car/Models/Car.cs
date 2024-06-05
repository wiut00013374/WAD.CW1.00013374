using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent_a_car.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public string VehicleBrand { get; set; }

        // 14055
        [Required(ErrorMessage = "This field is mandatory.")]
        public string VehicleModel { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public int ManufactureYear { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public string VehicleColor { get; set; }

        [Required(ErrorMessage = "This field is mandatory.")]
        public int? ClientId { get; set; }

        [ForeignKey("UserId")]
        public Users? user { get; set; }
    }
}
