using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.DAL;
using Social.Model;
namespace Social.BLL
{
    public class socialBll
    {
        socialDal dal = new socialDal();
        public int Login(string name, string pwd)
        {
            return dal.Login(name, pwd);
        }
    }
}
