﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.DAL;
using Social.Model;
namespace Social.BLL
{
   public class CompanyBll
    {
        CompanyDal companyDal = new CompanyDal();

        /// <summary>
        /// 显示注册公司信息
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompanyList()
        {
            return companyDal.GetCompanyList();
        }
        /// <summary>
        /// 根据Id查询单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company GetCompanyById(int id)
        {
            return companyDal.GetCompanyById(id);
        }
        /// <summary>
        /// 添加公司信息
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public int AddCompany(Company company)
        {

            return companyDal.AddCompany(company);
        }
        /// <summary>
        /// 删除公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelCompany(int id)
        {
            return companyDal.DelCompany(id);
        }
        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public int UptCompany(int id, Company company)
        {
            return companyDal.UptCompany(id, company);
        }
        /// <summary>
        /// 查询公司信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Company> GetCompany(string name)
        {
            return companyDal.GetCompany(name);
        }
    }
}
