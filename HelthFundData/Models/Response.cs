using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelthFundData.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Single { get; set; }
        public List<T> SingleList { get; set; }
    }
}
