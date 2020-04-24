using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.DAL;
using Social.Model;
namespace Social.BLL
{
   public class PayinfoBll
    {
        PayInfoDal infoDal = new PayInfoDal();
        /// <summary>
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        public List<PayInfo> GetPayinfos()
        {
            return infoDal.GetPayinfos();
        }
        /// <summary>
        /// 添加缴费明细
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        public int AddPayInto(PayInfo payinfo)
        {
            return infoDal.AddPayInto(payinfo);
        }
        /// <summary>
        /// 查询缴费明细
        /// </summary>
        /// <returns></returns>
        public List<PayInfo> GetPayinfos(int cid, string Name, string IDcard, int lid)
        {
            return infoDal.GetPayinfos(cid, Name, IDcard, lid);
        }
    }
}
