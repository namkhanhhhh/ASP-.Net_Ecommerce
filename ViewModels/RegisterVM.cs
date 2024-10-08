﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop_ASP_MVC.ViewModels
{
    public class RegisterVM
    {
        [Key]
        [Display(Name="User Name")]
        [Required(ErrorMessage ="Must not blank")]
        [MaxLength(20,ErrorMessage ="Max length = 20 characters")]
        public string MaKh { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage ="Min length at least 5 characters")]
        [MaxLength(20, ErrorMessage = "Max length = 20 characters")]
        [Required(ErrorMessage = "Must not blank")]
        public string MatKhau { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Must not blank")]
        [MaxLength(30, ErrorMessage = "Max length = 30 characters")]
        public string HoTen { get; set; }

        [Display(Name = "Gender")]
        public bool GioiTinh { get; set; } = true;


        
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        [Display(Name="Address")]
        [Required(ErrorMessage = "Must not blank")]
        [MinLength(5, ErrorMessage = "Min length at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Max length = 50 characters")]
        public string DiaChi { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Must not blank")]
        [MinLength(8, ErrorMessage = "Min length at least 8 characters")]
        [MaxLength(20, ErrorMessage = "Max length = 12 characters")]
        [RegularExpression(@"0[98]\d{8}", ErrorMessage ="Not valid phone number")]
        public string DienThoai { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Must not blank")]
        [MinLength(11, ErrorMessage = "Min length at least 11 characters")]
        [MaxLength(50, ErrorMessage = "Max length = 50 characters")]
        [EmailAddress(ErrorMessage = "Not valid")]
        public string Email { get; set; }

        [Display(Name = "Image")]
        public string? Hinh { get; set; }
    }
}
