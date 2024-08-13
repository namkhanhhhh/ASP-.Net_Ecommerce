using System.ComponentModel.DataAnnotations;

namespace OnlineShop_ASP_MVC.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Not valid")]
        [MaxLength(20, ErrorMessage = "Max length = 20 characters")]
        public string UserName {  get; set; }

        [Required(ErrorMessage = "Not valid")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
