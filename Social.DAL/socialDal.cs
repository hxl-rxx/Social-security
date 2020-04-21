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

        public int Login(string name,string pwd)
        {
            using(MySqlConnection connection=new MySqlConnection(Coon))
            {
                string sql = $"select * from userLogin where Name={name} && passWord={pwd}";
                var query = connection.Query(sql);
                return Convert.ToInt32(query);
            }
        }
    }
}
