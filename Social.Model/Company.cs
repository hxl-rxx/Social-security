using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Model
{
    [Table("company")]
   public class Company
  {
        public int CompanyId { get; set; }
        public string Cname { get; set; }
        public string Salesman { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
