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
        public int Sex { get; set; }
        public int Cid { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public int Aid { get; set; }
        public string Fixphone { get; set; }
        public int Rid { get; set; }
        public string OpenBank { get; set; }
        public string OpenName { get; set; }
        public string subBank { get; set; }
        public string BankNumber { get; set; }
        [ForeignKey("")]
        public Company Companys { get; set; }
        [ForeignKey("")]
        public Address address { get; set; }
        [ForeignKey("")]
        public Regist regist { get; set; }
    }
}
