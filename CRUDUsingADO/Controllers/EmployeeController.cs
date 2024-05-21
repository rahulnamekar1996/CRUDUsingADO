﻿using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingADO.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL employeedal;
        private readonly IConfiguration configuration;
        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            employeedal = new EmployeeDAL(configuration);
            
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var model = employeedal.GetEmployees();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var emp = employeedal.GetEmployeeById(id);
            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = employeedal.AddEmployee(emp);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = employeedal.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = employeedal.EditEmployee(emp);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int id) // delete confirmation page
        {
            var emp = employeedal.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")] // if httpget method & httppost method has diff action name
        // to indentify method for post req we will apply [ActionName]
        public ActionResult DeleteConfirm(int id)// post confirmation to del emp
        {
            try
            {
                int result = employeedal.DeleteEmployee(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

    }
}
