using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD_by_Store_Procedure_Employee_Management.Controllers
{
    public class EmployeeController : Controller
    {
        DAL.Employee objdal = new DAL.Employee();
        public ActionResult Index()
        {
            TempData["ie"] = objdal.GetEmployee();
            TempData.Keep();
            return View();

        }        
        
        [HttpPost]
        public ActionResult Index(Models.Employee e1,string b1)
        {
            if (b1 == "Save")
            {
                int i = objdal.AddEmployee(e1);
                if (i == 1)
                {
                    ViewBag.Message = "Employee Added";
                }
                else
                {
                    ViewBag.Message = "Failed";
                }
                return View();
            }
            else if (b1 == "Update") 
            {
                int i = objdal.UpdateEmployee(e1);
                if (i == 1)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id) 
        {
            Models.Employee e1 = new Models.Employee();
            e1.Eno = id;
            int i = objdal.DeleteEmployee(e1);
            if (i==1) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        {
            TempData.Keep();
            Models.Employee e1 = new Models.Employee();
            e1.Eno = id;
            e1 = objdal.SearchEmp(e1);
            return View("Index",e1);
        }
    }
}