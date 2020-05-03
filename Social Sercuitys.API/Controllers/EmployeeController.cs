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
    public class EmployeeController : ApiController
    {
        EmployeeBll employeeBll = new EmployeeBll();


        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Employees> GetEmployees()
        {
            return employeeBll.GetEmployees();
        }

        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Employees> GetEmployees(string name)
        {
            return employeeBll.GetEmployees(name);
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int AddEmployees(Employees employee)
        {
            return employeeBll.AddEmployees(employee);
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <returns></returns>
       [HttpPost]
        public int DelEmployees(int id)
        {
            return employeeBll.DelEmployees(id);
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Employees PutEmployees(int id)
        {
            return employeeBll.PutEmployees(id);
        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
       [HttpPost]
        public int UptEmployees(Employees employees)
        {
            return employeeBll.UptEmployees(employees);
        }
    }
}
