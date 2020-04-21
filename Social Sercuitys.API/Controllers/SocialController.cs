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
        [HttpPost]
        public int Login(string name, string pwd)
        {
            return bll.Login(name, pwd);
        }
    }
}
