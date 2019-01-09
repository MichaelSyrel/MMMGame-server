using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class ResultModel
    {
        public int id { get; set; }
        public int userID { get; set; }
        public DateTime  date { get; set; }
        public int duration { get; set; }
        public int moveCount { get; set; }
        public int score { get; set; }
        public int difficulty { get; set; }
        public string username { get; set; }
        public string fullName { get; set; }

    }
}
