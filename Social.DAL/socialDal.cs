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
        //连接字符串
        static readonly string Coon = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
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
                string sql = $"insert into company values(null,'{company.Name}','{company.Salesman}','{company.CreateTime}')";
                var query = connection.Execute(sql);
                return query;
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
                string sql = $"delete from company where ID='{Id}'";
                var query = connection.Execute(sql);
                return query;
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
        public int UptEmployees(int Id,Employees employee)
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
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        public List<payinfo> GetPayinfos()
        {
            using(MySqlConnection connection=new MySqlConnection(Coon))
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
            using(MySqlConnection connection=new MySqlConnection(Coon))
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
        public List<payinfo> GetPayinfos(int cid,string Name,string IDcard,int lid)
        {
            using (MySqlConnection connection = new MySqlConnection(Coon))
            {
                string sql = $"select * from payinfo p join company c on p.Cid=c.ID join employee on p.Eid=e.ID join insuranceType t on p.lid=t.ID where Cid='{cid}' || e.Name like '%'+{Name}+'%'|| e.IDcard='{IDcard}' || t.ID='{lid}' ";
                var query = connection.Query<payinfo>(sql);
                return query.ToList();
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
