using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ADO.net_Example.Models;

namespace ADO.net_Example.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            Student student = new Student();
            DataTable dt = student.GetAllStudents();
            return View(dt);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult Add(FormCollection frm)
        {
            Student student = new Student();
            string name = frm["S_Name"];
            int age = Convert.ToInt32(frm["S_Age"]);
            string gender = frm["S_Gender"];
            int status = student.InsertStudent(name, gender, age);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int StudentID)
        {
            Student student = new Student();
            student.DeleteStudent(StudentID);
            return RedirectToAction("Index");
        }        

        public ActionResult Edit(int StudentID)
        {
            Student student = new Student();
            DataTable dt = student.GetStudentByID(StudentID);
            return View("Edit", dt);
        }

        public ActionResult UpdateRecord(FormCollection frm)
        {
            Student student = new Student();
            string name = frm["S_Name"];
            int age = Convert.ToInt32(frm["S_Age"]);
            string gender = frm["S_Gender"];
            int id = Convert.ToInt32(frm["S_ID"]);
            int status = student.UpdateStudent(id, name, gender, age);
            return RedirectToAction("Index");
        }
    }
}