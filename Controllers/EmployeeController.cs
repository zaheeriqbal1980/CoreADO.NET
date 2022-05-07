using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreADO.NET.Models;

namespace CoreADO.NET.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext emp_obj = new EmployeeContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEmployees()
        {
            return View(emp_obj.GetAllEmployees());
        }


        public IActionResult AddEmployee()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel emp)
        {
            int Result = emp_obj.SaveEmployee(emp);
            if (Result > 0)
            {
                return RedirectToAction("GetEmployees");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditEmployee(int? id)
        {
            EmployeeModel emp = emp_obj.GetAllEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult EditEmployee(EmployeeModel emp)
        {
            int Result = emp_obj.UpdateEmployee(emp);
            if (Result > 0)
            {
                return RedirectToAction("GetEmployees");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeleteEmployee(int? id)
        {
            EmployeeModel emp = emp_obj.GetAllEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        [ActionName("DeleteEmployee")]
        public ActionResult DeleteConfirmed(int? id)
        {
            int Result = emp_obj.DeleteEmployee(id);
            if (Result > 0)
            {
                return RedirectToAction("GetEmployees");
            }
            else
            {
                return View();

            }
        }
    }
}
