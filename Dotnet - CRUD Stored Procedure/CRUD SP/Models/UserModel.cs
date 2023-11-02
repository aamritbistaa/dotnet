using System.ComponentModel.DataAnnotations;

namespace CRUD_SP.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="Username")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "Age of person")]
        [Range(18,50,ErrorMessage ="age must be in the range of 18 and 60")]
        public int Age { get; set; }

    }
}
