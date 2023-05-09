using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelthFundData.Models
{
    public class Recovery
    {
        [Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [DisplayName("Positive test date")]
        public DateTime PositiveDate { get; set; }
        [DisplayName("recovery date")]
        public DateTime RecoveryDate { get; set; }
    }
}
