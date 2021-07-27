using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Faq
    {
        public int Id { set; get; }
        public string Question { set; get; }
        public string Answer { set; get; }
        public int System { set; get; }
    }
}
