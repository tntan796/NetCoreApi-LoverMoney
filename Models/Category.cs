using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Category
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Metadata { set; get; }
        public string Icon { set; get; }
        public string ParentId { set; get; }
    }
}
