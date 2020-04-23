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
                string sql = $"select count(1) from userLogin where Name='{name}' and passWord='{pwd}' " ;
                var query = connection.ExecuteScalar(sql);
                return Convert.ToInt32(query);
            }
        }
      

     

        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Adduser(userLogin user)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"insert into userLogin values(null,'{user.Name}','{user.PassWord}','{user.Userlevel}')";
                var query = connection.Execute(sql);
                return query;
            }
        }

        

        /// <summary>
        /// 查询权限信息
        /// </summary>
        /// <returns></returns>
        public List<Power> GetPowers(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select *from power where Name like '%'+{name}+'%'";
                var query = connection.Query<Power>(sql);
                return query.ToList();

            }
        }
        /// <summary>
        /// 查询险种信息
        /// </summary>
        /// <returns></returns>
        public List<Insurancetype> GetInsurancetypes(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select *from insurancetype where Name like '%'+{name}+'%'";
                var query = connection.Query<Insurancetype>(sql);
                return query.ToList();

            }
        }

    }
}
