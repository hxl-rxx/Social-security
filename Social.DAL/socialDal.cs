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
    public class socialDal
    {
        static readonly string Coon = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string name,string pwd)
        {
            using(MySqlConnection connection=new MySqlConnection(Coon))
            {
                string sql = $"select * from userLogin where Name={name} && passWord={pwd}";
                var query = connection.Query(sql);
                return Convert.ToInt32(query);
            }
        }
        /// <summary>
        /// 显示注册公司信息
        /// </summary>
        /// <returns></returns>
        public List<Company> companies()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = "select * from company; ";
                var query = connection.Query<Company>(sql);
                return query.ToList();
            }
        }
    }
}
