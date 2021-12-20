using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjVideo : BaseEntity
    {
        public string Name { get; set; }
        public string VideoPath { get; set; }
        public bool Status { get; set; }
    }
}
