using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using Social.Model;
namespace Social.DAL
{
   public class PayInfoDal
    {
        static readonly string Coon = ConfigurationManager.ConnectionStrings["SqlData"].ConnectionString;
        /// <summary>
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        public List<PayInfo> GetPayinfos()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = "select * from payinfo p join company c on p.Cid=c.CompanyId join employee e on p.Eid=e.ID join insuranceType t on p.Iid=t.ID";
                var query = connection.Query<PayInfo>(sql);
                return query.ToList();
            }
        }
        /// <summary>
        /// 添加缴费明细
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        public int AddPayInto(PayInfo payinfo)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"insert into payinfo values(null,'{payinfo.Cid}','{payinfo.Eid}','{payinfo.ExpenType}','{payinfo.Iid}','{payinfo.Ccost}','{payinfo.Ecost}','{payinfo.Month}','{payinfo.BeginMonth}','{payinfo.EndMonth}')";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 查询缴费明细
        /// </summary>
        /// <returns></returns>
        public List<PayInfo> GetPayinfos(int cid = -1, string name = "", int iid = -1)
        {
            List<PayInfo> payInfoList = GetPayinfos();
            if (!string.IsNullOrEmpty(name))
            {
                payInfoList = payInfoList.Where(p => p.Name.Contains(name)).ToList();
            }
            if (cid != -1)
            {
                payInfoList = payInfoList.Where(p => p.Cid == cid).ToList();
            }
            if (iid != -1)
            {
                payInfoList = payInfoList.Where(p => p.Iid == iid).ToList();
            }
            return payInfoList;
        }
        /// <summary>
        /// 删除缴费信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPayInfo(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = "delete from payinfo where ID =" + id;
                return connection.Execute(sql);
            }
        }
    }
}
