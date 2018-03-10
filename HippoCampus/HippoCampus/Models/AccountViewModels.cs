using HippoCampus.Enum;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HippoCampus.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    

    public class RegisterStudentWorkerViewModel
    {
        public RegisterStudentWorkerViewModel(string email, string phoneNumber, string wrkr_stdnt_first_name, string wrkr_stdnt_last_name, string wrkr_stdnt_transport, string wrkr_stdnt_availability)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            this.wrkr_stdnt_first_name = wrkr_stdnt_first_name;
            this.wrkr_stdnt_last_name = wrkr_stdnt_last_name;
            this.wrkr_stdnt_transport = wrkr_stdnt_transport;
            this.wrkr_stdnt_availability = wrkr_stdnt_availability;
        }
        public RegisterStudentWorkerViewModel()
        { }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int wrkr_stdnt_id { get; set; }
        [DisplayName("First Name")]
        public string wrkr_stdnt_first_name { get; set; }
        [DisplayName("Last Name")]
        public string wrkr_stdnt_last_name { get; set; }
        [DisplayName("Drive")]
        public string wrkr_stdnt_transport { get; set; }
        [DisplayName("Availability")]
        public string wrkr_stdnt_availability { get; set; }

    }

    public class RegisterStudentWorkerCreateViewModel
    {
        public RegisterStudentWorkerCreateViewModel(string email, string phoneNumber, string wrkr_stdnt_first_name, string wrkr_stdnt_last_name, YesOrNo wrkr_stdnt_transport, YesOrNo wrkr_stdnt_availability)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            this.wrkr_stdnt_first_name = wrkr_stdnt_first_name;
            this.wrkr_stdnt_last_name = wrkr_stdnt_last_name;
            this.wrkr_stdnt_transport = wrkr_stdnt_transport;
            this.wrkr_stdnt_availability = wrkr_stdnt_availability;
        }
        public RegisterStudentWorkerCreateViewModel()
        { }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int wrkr_stdnt_id { get; set; }
        [DisplayName("First Name")]
        public string wrkr_stdnt_first_name { get; set; }
        [DisplayName("Last Name")]
        public string wrkr_stdnt_last_name { get; set; }
        [DisplayName("Drive")]
        public YesOrNo wrkr_stdnt_transport { get; set; }
        [DisplayName("Availability")]
        public YesOrNo wrkr_stdnt_availability { get; set; }

    }
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
