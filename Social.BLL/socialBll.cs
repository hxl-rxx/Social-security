using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Social.DAL;
using Social.Model;
namespace Social.BLL
{
    public class socialBll
    {
        socialDal dal = new socialDal();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string name, string pwd)
        {
            return dal.Login(name, pwd);
        }
        /// <summary>
        /// 显示注册公司信息
        /// </summary>
        /// <returns></returns>
        public List<Company> Companies()
        {
            return dal.Companies();
        }
        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployees()
        {
            return dal.GetEmployees();
        }
        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int AddCompany(Company company)
        {

            return dal.AddCompany(company);
        }
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelCompany(int id)
        {
            return dal.DelCompany(id);
        }
        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public int UptCompany(int id, Company company)
        {
            return dal.UptCompany(id, company);
        }
        /// <summary>
        /// 查询公司信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Company> GetCompany(string name)
        {
            return dal.GetCompany(name);
        }

        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployees(string name, string address)
        {
            return dal.GetEmployees(name, address);
        }
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <returns></returns>
        public int AddEmployees(Employees employee)
        {
            return dal.AddEmployees(employee);
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <returns></returns>
        public int DelEmployees(int id)
        {
            return dal.DelEmployees(id);
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        public int UptEmployees(int id,Employees employees)
        {
            return dal.UptEmployees(id,employees);
        }

        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Adduser(UserLogin user)
        {
            return dal.Adduser(user);
        }

        /// <summary>
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        public List<PayInfo> GetPayinfos()
        {
            return dal.GetPayinfos();
        }
        /// <summary>
        /// 添加缴费明细
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        public int AddPayInto(PayInfo payinfo)
        {
            return dal.AddPayInto(payinfo);
        }
        /// <summary>
        /// 查询缴费明细
        /// </summary>
        /// <returns></returns>
        public List<PayInfo> GetPayinfos(int cid, string name, string idCard, int lid)
        {
            return dal.GetPayinfos(cid, name, idCard, lid);
        }
        /// <summary>
        /// 查询权限信息
        /// </summary>
        /// <returns></returns>
        public List<Power> GetPowers()
        {
            return dal.GetPowers();
        }
        /// <summary>
        /// 查询险种信息
        /// </summary>
        /// <returns></returns>
        public List<Insurancetype> GetInsurancetypes()
        {
            return dal.GetInsurancetypes();
        }
    }
}
