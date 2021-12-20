using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL
{
    public class ObjPresentation : BaseEntity
    {
        public string Title { get; set; }
        public string VideoPath { get; set; }
        public bool Status { get; set; }
    }
}
