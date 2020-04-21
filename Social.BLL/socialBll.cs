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
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string name, string pwd)
        {
            return dal.Login(name, pwd);
        }
        /// <summary>
        /// 显示注册公司信息
        /// </summary>
        /// <returns></returns>
        public List<Company> companies()
        {
            return dal.companies();
        }
    }
}
