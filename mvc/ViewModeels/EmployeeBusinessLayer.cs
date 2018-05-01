﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc.DataAccessLayer;

namespace mvc.Models
{
    public class EmployeeBusinessLayer
    {

        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        public bool IsValidUser(UserDetails u)
        {
            if(u.UserName=="Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserStatus GetUserValidity(UserDetails u)
        {
            if(u.UserName=="admin" && u.Password == "admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }else if(u.UserName=="Sukesh" && u.Password == "Sukesh")
            {
                return UserStatus.AuthenticatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        #region 代码已更新
        //public List<Employee> GetEmployees()
        //{
        //    List<Employee> employees = new List<Employee>();
        //    Employee emp = new Employee();
        //    emp.FirstName = "johnson";
        //    emp.LastName = "fernandes";
        //    emp.Salary = 14000;
        //    employees.Add(emp);

        //    emp = new Employee();
        //    emp.FirstName = "michael";
        //    emp.LastName = "jackson";
        //    emp.Salary = 16000;
        //    employees.Add(emp);

        //    emp = new Employee();
        //    emp.FirstName = "rebert";
        //    emp.LastName = "pattinson";
        //    emp.Salary = 20000;
        //    employees.Add(emp);

        //    return employees;
        //}
        #endregion
    }
}