using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Social.BLL;
using Social.Model;
namespace Social_Sercuitys.API.Controllers
{
    public class SocialController : ApiController
    {
        socialBll bll = new socialBll();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string name, string pwd)
        {
            return bll.Login(name, pwd);
        }
    
        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
       [HttpPost]
        public int Adduser(userLogin user)
        {
            return bll.Adduser(user);
        }

 
        /// <summary>
        /// 查询权限信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Power> GetPowers(string name)
        {
            return bll.GetPowers(name);
        }
        /// <summary>
        /// 查询险种信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Insurancetype> GetInsurancetypes(string name)
        {
            return bll.GetInsurancetypes(name);
        }
    }
}
