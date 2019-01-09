using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class FeedbackModel
    {
        public int id  { get; set; }
        public string username { get; set; }
        public DateTime date { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
    }
}
