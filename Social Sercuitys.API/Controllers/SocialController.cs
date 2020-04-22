﻿using System;
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
        public List<Company> companies()
        {
            return bll.companies();
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
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int DelCompany(int Id)
        {
            return bll.DelCompany(Id);
        }

        /// <summary>
        /// 修改公司信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        [HttpPut]
        public int UptCompany(int Id, Company company)
        {
            return bll.UptCompany(Id, company);
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
        public int Adduser(userLogin user)
        {
            return bll.Adduser(user);
        }

        /// <summary>
        /// 显示缴费明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<payinfo> GetPayinfos()
        {
            return bll.GetPayinfos();
        }
        /// <summary>
        /// 添加缴费明细
        /// </summary>
        /// <param name="payinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddPayInto(payinfo payinfo)
        {
            return bll.AddPayInto(payinfo);
        }
        /// <summary>
        /// 查询缴费明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<payinfo> GetPayinfos(int cid, string Name, string IDcard, int lid)
        {
            return bll.GetPayinfos(cid, Name, IDcard, lid);
        }
        /// <summary>
        /// 查询权限信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Power> GetPowers(string name)
        {
            return bll.GetPowers(name);
        }
        /// <summary>
        /// 查询险种信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Insurancetype> GetInsurancetypes(string name)
        {
            return bll.GetInsurancetypes(name);
        }
    }
}
