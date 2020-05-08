using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.DAL;
using Social.Model;
namespace Social.BLL
{
   public class EmployeeBll
    {
        EmployeeDal employeeDal = new EmployeeDal();
        /// <summary>
        /// 显示员工信息
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployees()
        {
            return employeeDal.GetEmployees();
        }
        public List<Employees> GetEmployeesd()
        {
            return employeeDal.GetEmployeesd();
        }

        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployees(string name)
        {
            return employeeDal.GetEmployees(name);
        }
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <returns></returns>
        public int AddEmployees(Employees employee)
        {
            return employeeDal.AddEmployees(employee);
        }
        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <returns></returns>
        public int DelEmployees(int id)
        {
            return employeeDal.DelEmployees(id);
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employees PutEmployees(int id)
        {
            return employeeDal.PutEmployees(id);
         }
    
 
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <returns></returns>
        public int UptEmployees(Employees employees)
        {
            return employeeDal.UptEmployees(employees);
        }
    }
}
