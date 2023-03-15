using System.ComponentModel.DataAnnotations;
namespace PayRoll.Models
{
    public class Employee
    {

        public Guid Id { get; set; }



        [StringLength(50)]
        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^[A-Z a-z0-9ÑñáéíóúÁÉÍÓÚ\\-\\_]+$",
            ErrorMessage = "Name must be alphanumeric.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Incorrect Email Address.")]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

      
    }
}
