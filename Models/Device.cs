using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Device
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public DateTime CreateDate { set; get; }
        public string UserId { set; get; }
    }
}
