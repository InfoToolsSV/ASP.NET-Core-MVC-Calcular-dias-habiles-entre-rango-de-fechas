using System.ComponentModel.DataAnnotations;

namespace BusinessDays.Models
{
    public class DateRangeViewModel
    {
        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int BusinessDays { get; set; }
    }
}