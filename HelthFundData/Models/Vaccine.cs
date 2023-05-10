using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelthFundData.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        [DisplayName("Member id")]
        public int MemberId { get; set; }
        [DisplayName("Vaccine manufacturer")]
        public string VaccineManufacturer { get; set; }
        [DisplayName("Vaccine date")]
        public DateTime VaccineDate { get; set; }
    }
}
