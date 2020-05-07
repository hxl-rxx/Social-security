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
   public class CompanyDal
    {
        static readonly string Coon = ConfigurationManager.ConnectionStrings["SqlData"].ConnectionString;
        /// <summary>
        /// 显示注册公司信息
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompanyList()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = "select * from company";
                var query = connection.Query<Company>(sql);
                return query.ToList();
            }
        }
        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int AddCompany(Company company)
        {

            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                connection.Open();
                string sql = $"insert into company values(null,'{company.Cname}','{company.Salesman}','{company.CreateTime}')";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DelCompany(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"delete from company where CompanyId='{id}'";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public int UptCompany(int id, Company company)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"Update Company set Cname='{company.Cname}',Salesman='{company.Salesman}',CreateTime='{company.CreateTime}' where CompanyId='{id}'";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 查询公司信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Company> GetCompany(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                connection.Open();
                string sql = "select * from company";
                var query = connection.Query<Company>(sql);
                return query.ToList().Where(s => s.Cname.Contains(name)).ToList();
            }
        }
    }
}
