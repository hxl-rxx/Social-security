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
        public List<Employees> GetEmployees(string name, string address)
        {
            return employeeBll.GetEmployees(name, address);
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
       [HttpDelete]
        public int DelEmployees(int id)
        {
            return employeeBll.DelEmployees(id);
        }

        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public int UptEmployees(int id, Employees employees)
        {
            return employeeBll.UptEmployees(id, employees);
        }
    }
}
