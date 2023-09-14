using mypro.Conrext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mypro.Controllers
{
     
    public class StudentController : Controller
    {
        // GET: Student
        db_testEntities dbObj = new db_testEntities();
        public ActionResult Student(Student obj)
        {
            return View(obj);
           
        }
        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            if (ModelState.IsValid ) {
                Student obj = new Student();
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;
                
                if (model.ID == 0)
                {
                    dbObj.Students.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }
                ModelState.Clear();
            }
           
            return View("Student");
        }
        public ActionResult StudentList()
        {
            var res = dbObj.Students.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbObj.Students.Where(x => x.ID == id).First();
            dbObj.Students.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.Students.ToList();
            return View("StudentList",list);
        }
        public ActionResult Details(int? id)
        {
            //var res2 = dbObj.Students.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student obj = dbObj.Students.Find(id);
            if (obj==null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }
    }
}