using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Social.Model;
using Social.BLL;
namespace Social_Sercuitys.API.Controllers
{
    public class CompanyController : ApiController
    {
        CompanyBll companyBll = new CompanyBll();

        /// <summary>
        /// 显示公司注册信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Company> GetCompanyList()
        {
            return companyBll.GetCompanyList();
        }

        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddCompany(Company company)
        {
            return companyBll.AddCompany(company);
        }

        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public int DelCompany(int id)
        {
            return companyBll.DelCompany(id);
        }

        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPost]
        public int UptCompany(int id, Company company)
        {
            return companyBll.UptCompany(id, company);
        }

        /// <summary>
        /// 查询公司信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Company> GetCompany(string name)
        {
            return companyBll.GetCompany(name);
        }
    }
}
