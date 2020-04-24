using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Social.BLL;
using Social.Model;
namespace Social_Sercuitys.API.Controllers
{
    public class SocialController : ApiController
    {
        socialBll bll = new socialBll();
        [HttpGet]
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(string name, string pwd)
        {
            return bll.Login(name, pwd);
        }
    
        /// <summary>
        /// 显示公司注册信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Company> Companies()
        {
            return bll.Companies();
        }

        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Employees> GetEmployees()
        {
            return bll.GetEmployees();
        }

        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddCompany(Company company)
        {

            return bll.AddCompany(company);
        }

        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelCompany(int id)
        {
            return bll.DelCompany(id);
        }

        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut]
        public int UptCompany(int id, Company company)
        {
            return bll.UptCompany(id, company);
        }

        /// <summary>
        /// 查询公司信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Company> GetCompany(string name)
        {
            return bll.GetCompany(name);
        }

        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Employees> GetEmployees(string name, string address)
        {
            return bll.GetEmployees(name,address);
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int AddEmployees(Employees employee)
        {
            return bll.AddEmployees(employee);
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public int DelEmployees(int id)
        {
            return bll.DelEmployees(id);
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public int UptEmployees(int id,Employees employees)
        {
            return bll.UptEmployees(id,employees);
        }
        /// <summary>
        /// 注册信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
       [HttpPost]
        public int Adduser(UserLogin user)
        {
            return bll.Adduser(user);
        }

        /// <summary>
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PayInfo> GetPayinfos()
        {
            return bll.GetPayinfos();
        }
        /// <summary>
        /// 添加缴费明细
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddPayInto(PayInfo payinfo)
        {
            return bll.AddPayInto(payinfo);
        }
        /// <summary>
        /// 查询缴费明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PayInfo> GetPayinfos(int cid, string name, string idCard, int lid)
        {
            return bll.GetPayinfos(cid, name, idCard, lid);
        }
        /// <summary>
        /// 查询权限信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Power> GetPowers()
        {
            return bll.GetPowers();
        }
        /// <summary>
        /// 查询险种信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Insurancetype> GetInsurancetypes()
        {
            return bll.GetInsurancetypes();
        }
    }
}
