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
        /// 显示注册公司信息
        /// </summary>
        /// <returns></returns>
        public List<Company> companies()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = "select * from company ";
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
                string sql = $"insert into company values('{company.Name}','{company.Salesman}','{company.CreateTime}')";
                var query = connection.Query(sql);
                return Convert.ToInt32(query);
            }
         }
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DelCompany(int Id)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"delete from Company where ID='{Id}'";
                var query = connection.Query(sql);
                return Convert.ToInt32(query);
            }
         }
        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public int UptCompany(int Id,Company company)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"Update Company set Name='{company.Name}',Salesman='{company.Salesman}',CreateTime='{company.CreateTime}' where ID='{Id}'";
                var query = connection.Query(sql);
                return Convert.ToInt32(query);
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
                string sql=($"select * from company where Name like '%'+{name}+'%' ");
                var query = connection.Query<Company>(sql);
                return query.ToList();
            }
         }

        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployees()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = "select * from employee join company on employee.Cid=company.ID; ";
                var query = connection.Query<Employees>(sql);
                return query.ToList();
            }
        }
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <returns></returns>
        public int AddEmployees(Employees employee)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"insert into employee values ('{employee.Name}','{employee.IDCard}','{employee.IDCard}','{employee.Sex}','{employee.Cid}','{employee.Tel}','{employee.Address}') ";
                var query = connection.Query(sql);
                return Convert.ToInt32(query);
            }
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <returns></returns>
        public int DelEmployees(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"delete from employee where Id  ='{id}'";
                var query = connection.Query(sql);
                return Convert.ToInt32(query);
            }
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        public int UptEmployees(int Id,Employees employee)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"Update employee set Name='{employee.Name}',IDCard='{employee.IDCard}',Sex='{employee.Sex}',Cid='{employee.Cid}', Tel='{employee.Tel}', Address='{employee.Address}' where ID='{Id}'";
                var query = connection.Execute(sql);
                return Convert.ToInt32(query);
            }
        }
        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployees(string name, string address)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select * from employee where Name like '%'+{name}+'%' and  Address like '%'+{address}+'%'";
                var query = connection.Query<Employees>(sql);
                return query.ToList();
            }
        }

    }
}
