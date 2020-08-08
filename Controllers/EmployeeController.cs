using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Models;
using System.Data.Entity;
namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IList<EmployeeDetailsViewModel> emp = null;
            using (var ctx = new hrmsEntities1())
            {
                emp = ctx.EmployeeDetails.Select(s => new EmployeeDetailsViewModel()
                {
                    EmployeeID = s.EmployeeID,
                    EmployeeName = s.EmployeeName,
                    DOB = s.DOB,
                    DOJ = s.DOJ,
                    DepartmentID = s.Department.DepartmentID,
                    DepartmentName = s.Department.DepartmentName,
                    DesignationID=s.Designation.DesignationID,
                    DesignationName=s.Designation.DesignationName
                }).ToList<EmployeeDetailsViewModel>();
                return View(emp);
            }
        }
        public ActionResult Create()
        {
            var ctx = new hrmsEntities1();
            ViewBag.desig = new SelectList(ctx.Designations, "DesignationID", "DesignationName");
            ViewBag.departmnt = new SelectList(ctx.Departments, "DepartmentID", "DepartmentName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeDetailsViewModel emp)
        {
            using (var ctx=new hrmsEntities1())
            {
                ctx.EmployeeDetails.Add(new EmployeeDetail()
                {
                    EmployeeID = emp.EmployeeID,
                    EmployeeName = emp.EmployeeName,
                    DOB = emp.DOB,
                    DOJ = emp.DOJ,
                    DesignationID = emp.DesignationID,
                    DepartmentID = emp.DepartmentID
                });
                ctx.SaveChanges();
                TempData["Success"] = "Saved Successfully";
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int id)
        {
            var ctx = new hrmsEntities1();
            ViewBag.desig = new SelectList(ctx.Designations, "DesignationID", "DesignationName");
            ViewBag.departmnt = new SelectList(ctx.Departments, "DepartmentID", "DepartmentName");
            var emp = ctx.EmployeeDetails
                         .Where(s=>s.EmployeeID==id)
                         .Select(s => new EmployeeDetailsViewModel()
                         {
                            EmployeeID=s.EmployeeID,
                            EmployeeName=s.EmployeeName,
                            DOB=s.DOB,
                            DOJ=s.DOJ,
                            DepartmentID=s.DepartmentID,
                            DepartmentName=s.Department.DepartmentName,
                            DesignationID=s.DesignationID,
                            DesignationName=s.Designation.DesignationName
                         }).FirstOrDefault<EmployeeDetailsViewModel>();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeDetailsViewModel emp)
        {
            using (var ctx = new hrmsEntities1())
            {
                var existingEmployee = ctx.EmployeeDetails
                                           .Where(s => s.EmployeeID == emp.EmployeeID)
                                           .FirstOrDefault<EmployeeDetail>();
                if(existingEmployee!=null)
                {
                    existingEmployee.EmployeeID = emp.EmployeeID;
                    existingEmployee.EmployeeName = emp.EmployeeName;
                    existingEmployee.DOB = emp.DOB;
                    existingEmployee.DOJ = emp.DOJ;
                    existingEmployee.DesignationID = emp.DesignationID;
                    existingEmployee.DepartmentID = emp.DepartmentID;
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }
        public ActionResult Details(int id)
        {
            var ctx = new hrmsEntities1();
            ViewBag.desig = new SelectList(ctx.Designations, "DesignationID", "DesignationName");
            ViewBag.departmnt = new SelectList(ctx.Departments, "DepartmentID", "DepartmentName");
            var emp = ctx.EmployeeDetails
                         .Where(s => s.EmployeeID == id)
                         .Select(s => new EmployeeDetailsViewModel()
                         {
                             EmployeeID = s.EmployeeID,
                             EmployeeName = s.EmployeeName,
                             DOB = s.DOB,
                             DOJ = s.DOJ,
                             DepartmentID = s.DepartmentID,
                             DepartmentName = s.Department.DepartmentName,
                             DesignationID = s.DesignationID,
                             DesignationName = s.Designation.DesignationName
                         }).FirstOrDefault<EmployeeDetailsViewModel>();
            return View(emp);
        }
        public ActionResult Delete(int id)
        {
            using(var ctx=new hrmsEntities1())
            {
                var empid = ctx.EmployeeDetails
                            .Where(s => s.EmployeeID == id)
                            .FirstOrDefault();
                ctx.Entry(empid).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}