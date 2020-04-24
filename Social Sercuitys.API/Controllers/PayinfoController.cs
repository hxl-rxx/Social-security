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
    public class PayinfoController : ApiController
    {
        PayinfoBll payinfoBll = new PayinfoBll();

        /// <summary>
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PayInfo> GetPayinfos()
        {
            return payinfoBll.GetPayinfos();
        }

        /// <summary>
        /// 添加缴费明细
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddPayInto(PayInfo payinfo)
        {
            return payinfoBll.AddPayInto(payinfo);
        }

        /// <summary>
        /// 查询缴费明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PayInfo> GetPayinfos(int cid, string Name, string IDcard, int lid)
        {
            return payinfoBll.GetPayinfos(cid, Name, IDcard, lid);
        }
    }
}
