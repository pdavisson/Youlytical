﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name="Company")]
        public string Company {get; set; }

        [DataType(DataType.Text)]
        [Display(Name="FranchiseID")]
        public string FranchiseID {get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name="FirstName")]
        public string FirstName {get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name="LastName")]
        public string LastName {get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}