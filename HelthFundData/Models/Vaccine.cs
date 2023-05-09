using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelthFundData.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string VaccineManufacturer { get; set; }
        public DateTime VaccineDate { get; set; }
    }
}
