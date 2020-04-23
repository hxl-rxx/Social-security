using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        /// 注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Adduser(userLogin user)
        {
            return dal.Adduser(user);
        }

       
        /// <summary>
        /// 查询权限信息
        /// </summary>
        /// <returns></returns>
        public List<Power> GetPowers(string name)
        {
            return dal.GetPowers(name);
        }
        /// <summary>
        /// 查询险种信息
        /// </summary>
        /// <returns></returns>
        public List<Insurancetype> GetInsurancetypes(string name)
        {
            return dal.GetInsurancetypes(name);
        }
    }
}
