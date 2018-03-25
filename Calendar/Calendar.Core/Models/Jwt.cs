using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Core.Models
{
    public class Jwt
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
