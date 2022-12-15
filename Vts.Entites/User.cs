using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vts.Entites
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        public int Mobile { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

        public string Photograph { get; set; }
    }
}
