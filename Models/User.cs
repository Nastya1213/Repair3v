using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair3v.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateOnly DateS { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
