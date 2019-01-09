using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class ContactMessageModel
    {
        public DateTime date { get; set; }
        public int id { get; set; }
        public string message { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
