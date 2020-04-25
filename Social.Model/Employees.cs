using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Model
{
   public class Employees
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IDCard { get; set; }
        public bool Sex { get; set; }
        public int Cid { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        [ForeignKey("")]
        public Company Companys { get; set; }
    }
}
