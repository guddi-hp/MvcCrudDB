using MvcCrudDB.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudDB.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        MvcDBEntities dbobj = new MvcDBEntities();
        public ActionResult Student(tbl_Student obj)
        {
            //if(obj !=null)
            //return View(obj );
            //else
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            if(ModelState.IsValid)
            {
                tbl_Student obj = new tbl_Student();
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Description = model.Description;

                if (model.ID == 0)
                {
                    dbobj.tbl_Student.Add(obj);
                    dbobj.SaveChanges();
                }
                else
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                }

                //dbobj.tbl_Student.Add(obj);
                //dbobj.SaveChanges();
            }
            ModelState.Clear();
            
            return View("Student");
        }

        public ActionResult StudentList()
        {
            var res = dbobj.tbl_Student.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbobj.tbl_Student.Where(x=>x.ID==id).First();
            dbobj.tbl_Student.Remove(res);
            dbobj.SaveChanges();

            var List = dbobj.tbl_Student.ToList();
            return View("StudentList",List);
        }

    }
}
