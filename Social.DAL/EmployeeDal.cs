using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
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
                string sql = $"select * from employee join company on employee.Cid=company.CompanyId limit 3";
                
                MySqlDataAdapter dr = new MySqlDataAdapter(new MySqlCommand(sql, connection));
                DataTable dt = new DataTable();
                dr.Fill(dt);
                List<Employees> query = dt.AsEnumerable().Select(e => new Employees
                {
                    ID = Convert.ToInt32(e["ID"]),
                    Name = Convert.ToString(e["Name"]),
                    Address = Convert.ToString(e["Address"]),
                    Sex = Convert.ToInt32(e["Sex"]),
                    IDCard = Convert.ToString(e["IDCard"]),
                    Tel = Convert.ToString(e["Tel"]),
                    Cid = Convert.ToInt32(e["Cid"]),
                    Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) }
                }).ToList();
               
                return query;
            }
        }
        public List<Employees> GetEmployeesd()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select * from employee join company on employee.Cid=company.CompanyId limit 5,4";

                MySqlDataAdapter dr = new MySqlDataAdapter(new MySqlCommand(sql, connection));
                DataTable dt = new DataTable();
                dr.Fill(dt);
                List<Employees> query = dt.AsEnumerable().Select(e => new Employees
                {
                    ID = Convert.ToInt32(e["ID"]),
                    Name = Convert.ToString(e["Name"]),
                    Address = Convert.ToString(e["Address"]),
                    Sex = Convert.ToInt32(e["Sex"]),
                    IDCard = Convert.ToString(e["IDCard"]),
                    Tel = Convert.ToString(e["Tel"]),
                    Cid = Convert.ToInt32(e["Cid"]),
                    Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) }
                }).ToList();

                return query;
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
                string sql = $"insert into employee values (null,'{employee.Name}','{employee.IDCard}',{employee.Sex},{employee.Cid},'{employee.Tel}','{employee.Address}') ";
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
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employees PutEmployees(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select * from employee join company on employee.Cid=company.CompanyId where ID={id}; ";
                MySqlDataAdapter dr = new MySqlDataAdapter(new MySqlCommand(sql, connection));
                DataTable dt = new DataTable();
                dr.Fill(dt);
                List<Employees> query = dt.AsEnumerable().Select(e => new Employees
                {
                    ID = Convert.ToInt32(e["ID"]),
                    Name = Convert.ToString(e["Name"]),
                    Address = Convert.ToString(e["Address"]),
                    Sex = Convert.ToInt32(e["Sex"]),
                    IDCard = Convert.ToString(e["IDCard"]),
                    Tel = Convert.ToString(e["Tel"]),
                    Cid = Convert.ToInt32(e["Cid"]),
                    Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) }
                }).ToList();
                return query.FirstOrDefault();
            }
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        public int UptEmployees(Employees employees)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            { 
                string sql = $"Update employee set Name='{employees.Name}',IDCard='{employees.IDCard}',Sex={employees.Sex},Cid={employees.Cid}, Tel='{employees.Tel}', Address='{employees.Address}' where ID={employees.ID}";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 查询员工信息
        ///</summary>
        /// <returns></returns>
        public List<Employees> GetEmployees(string name = "", int cid = -1)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                if (name != null)
                {
                    connection.Open();
                    string sql = $"select * from employee join company on employee.Cid=company.CompanyId";
                    MySqlDataAdapter dr = new MySqlDataAdapter(new MySqlCommand(sql, connection));
                    DataTable dt = new DataTable();
                    dr.Fill(dt);
                    List<Employees> query = dt.AsEnumerable().Select(e => new Employees
                    {
                        ID = Convert.ToInt32(e["ID"]),
                        Name = Convert.ToString(e["Name"]),
                        Address = Convert.ToString(e["Address"]),
                        Sex = Convert.ToInt32(e["Sex"]),
                        IDCard = Convert.ToString(e["IDCard"]),
                        Tel = Convert.ToString(e["Tel"]),
                        Cid = Convert.ToInt32(e["Cid"]),
                        Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) }
                    }).ToList().Where(e => e.Name.Contains(name)).ToList();
                    return query;
                }
                else
                {
                    connection.Open();
                    string sql = $"select * from employee join company on employee.Cid=company.CompanyId";
                    MySqlDataAdapter dr = new MySqlDataAdapter(new MySqlCommand(sql, connection));
                    DataTable dt = new DataTable();
                    dr.Fill(dt);
                    List<Employees> query = dt.AsEnumerable().Select(e => new Employees
                    {
                        ID = Convert.ToInt32(e["ID"]),
                        Name = Convert.ToString(e["Name"]),
                        Address = Convert.ToString(e["Address"]),
                        Sex = Convert.ToInt32(e["Sex"]),
                        IDCard = Convert.ToString(e["IDCard"]),
                        Tel = Convert.ToString(e["Tel"]),
                        Cid = Convert.ToInt32(e["Cid"]),
                        Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) }
                    }).ToList();
                    return query;
                }

            }
        }
    }
    
}
