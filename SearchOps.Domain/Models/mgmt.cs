using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchOps.Domain.Models
{
    public class Mgmt
    {
        public int mgmtID { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public bool CreatedOn { get; set; }
        public Property Property { get; set; }
        public int PropertyID { get; set; }
    }
}
