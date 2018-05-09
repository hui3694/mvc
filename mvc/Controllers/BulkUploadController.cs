using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Filters;
using mvc.ViewModels;
using BusinessEntities;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BusinessLayer;

namespace mvc.Controllers
{
    public class BulkUploadController : AsyncController
    {
        [HeaderFooterFilter]
        [AdminFilter]
        // GET: BulkUpload
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            //List<Employee> employees = GetEmployee(model);
            //EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            //bal.UploadEmployees(employees);
            //return RedirectToAction("index", "employee");

            int t1 = Thread.CurrentThread.ManagedThreadId;
            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>
                (() => GetEmployee(model));
            int t2 = Thread.CurrentThread.ManagedThreadId;
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("index", "employee");
        }

        private List<Employee> GetEmployee(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine();
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var value = line.Split(',');
                Employee e = new Employee();
                e.FirstName = value[0];
                e.LastName = value[1];
                e.Salary = int.Parse(value[2]);
                employees.Add(e);
            }
            return employees;
        }
    }
}