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
    public class SocialDal
    {
        //连接字符串
        static readonly string coon = ConfigurationManager.ConnectionStrings["SqlData"].ConnectionString;

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public int Login(string name,string pwd)
        {
            using(MySqlConnection connection=new MySqlConnection(coon))
            {
                string sql = $"select count(1) from userLogin where Uname='{name}' and passWord='{pwd}' " ;
                var query = connection.ExecuteScalar(sql);
                return Convert.ToInt32(query);
            }
        }
        
        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Adduser(UserLogin user)
        {
            using (MySqlConnection connection = new MySqlConnection(coon))
            {
                string sql = $"insert into userLogin values(null,'{user.Uname}','{user.PassWord}','{user.Userlevel}')";
                var query = connection.Execute(sql);
                return query;
            }
        }

       

        /// <summary>
        /// 查看权限信息
        /// </summary>
        /// <returns></returns>
        public List<Power> GetPowers()
        {
            using (MySqlConnection connection = new MySqlConnection(coon))
            {
                string sql = $"select *from power";
                var query = connection.Query<Power>(sql);
                return query.ToList();

            }
        }
        /// <summary>
        /// 查询险种信息
        /// </summary>
        /// <returns></returns>
        public List<Insurancetype> GetInsurancetypes()
        {
            using (MySqlConnection connection = new MySqlConnection(coon))
            {
                string sql = $"select * from insurancetype";
                var query = connection.Query<Insurancetype>(sql);
                return query.ToList();

            }
        }

    }
}
