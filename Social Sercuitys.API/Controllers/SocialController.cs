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
        [HttpPost]
        public int Login(string name, string pwd)
        {
            return bll.Login(name, pwd);
        }
        /// <summary>
        /// 显示公司注册信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Company> companies()
        {
            return bll.companies();
        }
    }
}
