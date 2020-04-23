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
        static readonly string Coon = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
        /// <summary>
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        public List<payinfo> GetPayinfos()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = "select * from payinfo p join company c on p.Cid=c.ID join employee on p.Eid=e.ID join insuranceType t on p.lid=t.ID ";
                var query = connection.Query<payinfo>(sql);
                return query.ToList();
            }
        }
        /// <summary>
        /// 添加缴费明细
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        public int AddPayInto(payinfo payinfo)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"insert into payinfo values(null,'{payinfo.Cid}','{payinfo.Eid}','{payinfo.ExpenType}','{payinfo.lid}','{payinfo.Ccost}','{payinfo.Ecost}','{payinfo.Month}','{payinfo.BeginMonth}','{payinfo.EndMonth}')";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 查询缴费明细
        /// </summary>
        /// <returns></returns>
        public List<payinfo> GetPayinfos(int cid, string Name, string IDcard, int lid)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select * from payinfo p join company c on p.Cid=c.ID join employee on p.Eid=e.ID join insuranceType t on p.lid=t.ID where Cid='{cid}' || e.Name like '%'+{Name}+'%'|| e.IDcard='{IDcard}' || t.ID='{lid}' ";
                var query = connection.Query<payinfo>(sql);
                return query.ToList();
            }
        }
    }
}
