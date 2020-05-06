using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Model
{
   public class PayInfo
  {
        public int ID { get; set; }
        public int Cid { get; set; }
        public int Eid { get; set; }
        public int ExpenType { get; set; }
        public int Iid { get; set; }
        public decimal Ccost { get; set; }
        public decimal Ecost { get; set; }
        public int Month { get; set; }
        public string BeginMonth { get; set; }
        public string EndMonth { get; set; }

        public string Cname { get; set; }
        public string Name { get; set; }
        public string Iname { get; set; }
    }
}
