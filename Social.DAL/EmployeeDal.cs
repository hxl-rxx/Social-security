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
    public class EmployeeDal
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
                string sql = $"select * from employee join company on employee.Cid=company.CompanyId join address on employee.Aid=address.Aid join Regist on employee.Rid=Regist.Rid";

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
                    Aid=Convert.ToInt32(e["Aid"]),
                    Fixphone=Convert.ToString(e["Fixphone"]),
                    Rid=Convert.ToInt32(e["Rid"]),
                    OpenBank=Convert.ToString(e["OpenBank"]),
                    OpenName=Convert.ToString(e["OpenName"]),
                    subBank=Convert.ToString(e["subBank"]),
                    BankNumber=Convert.ToString(e["BankNumber"]),
                    Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) },
                    address=new Address { Aname=Convert.ToString(e["Aname"])},
                    regist=new Regist { Rname=Convert.ToString(e["Rname"])}
                }).ToList();

                return query;
            }
        }
        public List<Employees> GetEmployeesd()
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select * from employee join company on employee.Cid=company.CompanyId join address on employee.Aid=address.Aid join Regist on employee.Rid=Regist.Rid limit 5,4";

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
                    Aid = Convert.ToInt32(e["Aid"]),
                    Fixphone = Convert.ToString(e["Fixphone"]),
                    Rid = Convert.ToInt32(e["Rid"]),
                    OpenBank = Convert.ToString(e["OpenBank"]),
                    OpenName = Convert.ToString(e["OpenName"]),
                    subBank = Convert.ToString(e["subBank"]),
                    BankNumber = Convert.ToString(e["BankNumber"]),
                    Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) },
                    address = new Address { Aname = Convert.ToString(e["Aname"]) },
                    regist = new Regist { Rname = Convert.ToString(e["Rname"]) }
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
                string sql = $"INSERT into employee VALUES(NULL,'{employee.Name}','{employee.IDCard}',{employee.Sex},{employee.Cid},'{employee.Tel}','{employee.Address}','{employee.Aid}','{employee.Fixphone}','{employee.Rid}','{employee.OpenBank}','{employee.OpenName}','{employee.subBank}','{employee.BankNumber}')";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <returns></returns>
        public int DelEmployees(string id)
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
                string sql = $"select * from employee join company on employee.Cid=company.CompanyId join address on employee.Aid=address.Aid join Regist on employee.Rid=Regist.Rid where ID={id}; ";
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
                    Aid = Convert.ToInt32(e["Aid"]),
                    Fixphone = Convert.ToString(e["Fixphone"]),
                    Rid = Convert.ToInt32(e["Rid"]),
                    OpenBank = Convert.ToString(e["OpenBank"]),
                    OpenName = Convert.ToString(e["OpenName"]),
                    subBank = Convert.ToString(e["subBank"]),
                    BankNumber = Convert.ToString(e["BankNumber"]),
                    Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) },
                    address = new Address { Aname = Convert.ToString(e["Aname"]) },
                    regist = new Regist { Rname = Convert.ToString(e["Rname"]) }
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
                string sql = $"Update employee set Name='{employees.Name}',IDCard='{employees.IDCard}',Sex={employees.Sex},Cid={employees.Cid}, Tel='{employees.Tel}', Address='{employees.Address}',Aid='{employees.Aid}',Fixphone='{employees.Fixphone}',Rid='{employees.Rid}',OpenBank='{employees.OpenBank}',OpenName='{employees.OpenName}',SubBank='{employees.subBank}',BankNumber='{employees.BankNumber}' where ID={employees.ID}";
                var query = connection.Execute(sql);
                return query;
            }
        }
        /// <summary>
        /// 根据姓名查询员工信息
        ///</summary>
        /// <returns></returns>
        public List<Employees> GetEmployees(int cid,string name)
        {
           
                using (MySqlConnection connection = new MySqlConnection(Coon))
                {

                    connection.Open();
                    string sql = $"select * from employee join company on employee.Cid=company.CompanyId join address on employee.Aid=address.Aid join Regist on employee.Rid=Regist.Rid";
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
                        Aid = Convert.ToInt32(e["Aid"]),
                        Fixphone = Convert.ToString(e["Fixphone"]),
                        Rid = Convert.ToInt32(e["Rid"]),
                        OpenBank = Convert.ToString(e["OpenBank"]),
                        OpenName = Convert.ToString(e["OpenName"]),
                        subBank = Convert.ToString(e["subBank"]),
                        BankNumber = Convert.ToString(e["BankNumber"]),
                        Companys = new Company { Cname = Convert.ToString(e["Cname"]), CreateTime = Convert.ToDateTime(e["CreateTime"]), Salesman = Convert.ToString(e["Salesman"]) },
                        address = new Address { Aname = Convert.ToString(e["Aname"]) },
                        regist = new Regist { Rname = Convert.ToString(e["Rname"]) }
                    }).ToList()/*.Where(e => e.Name.Contains(name) || e.Cid == cid).ToList()*/;
                if(!string.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(e => e.Name.Contains(name)).ToList();
                }
                if(cid!=0)
                {
                    query = query.Where(e => e.Cid == cid).ToList();
                }
                
                return query;
            }
        }
       
    }
        
}

