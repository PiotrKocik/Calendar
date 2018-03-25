using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Core.Models
{
    public class Token
    {
        public string TokenKey { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
    }
}
