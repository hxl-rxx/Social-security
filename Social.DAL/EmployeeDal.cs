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
  public  class EmployeeDal
    {
        static readonly string Coon = ConfigurationManager.ConnectionStrings["SqlData"].ConnectionString;
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
                string sql = $"insert into employee values (null,'{employee.Name}','{employee.IDCard}','{employee.IDCard}','{employee.Sex}','{employee.Cid}','{employee.Tel}','{employee.Address}') ";
                var query = connection.Execute(sql);
                return query;
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
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        public int UptEmployees(int Id, Employees employee)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"Update employee set Name='{employee.Name}',IDCard='{employee.IDCard}',Sex='{employee.Sex}',Cid='{employee.Cid}', Tel='{employee.Tel}', Address='{employee.Address}' where ID='{Id}'";
                var query = connection.Execute(sql);
                return query;
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
