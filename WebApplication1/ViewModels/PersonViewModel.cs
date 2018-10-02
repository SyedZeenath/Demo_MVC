using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class PersonViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Person Name cannot be empty")]
        [MinLength(3, ErrorMessage = "length of Name should be greater than  characters")]
        [MaxLength(50, ErrorMessage ="Name cannot be more than 50 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Date of Birth")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public GenderTypes Gender { get; set; }

        [DisplayFormat(NullDisplayText ="Not available")]
        [EmailAddress(ErrorMessage ="Please provide an email address here")]
        public string Email { get; set; }
    }
}