using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelthFundData.Models
{
    public class Member
    {

        [Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Required field")]
        [MinLength(2, ErrorMessage = "First name cannot be shorter than 2 characters.")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Required field")]
        [MinLength(2, ErrorMessage = "Last name cannot be shorter than 2 characters.")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [DisplayName("Phone number")]
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [DisplayName("Mobile number")]
        public string? MobileNumber { get; set; }
        [DisplayName("Birth date")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Image url")]
        [MaxLength(200)]
        [DataType(DataType.ImageUrl)]
        public string? ImageUrl { get; set; }


    }
}
