using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceMAnagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        AttendanceManagementSystemEntities db = new AttendanceManagementSystemEntities();
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            ViewBag.students = students;
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(int[] StudentId, DateTime attendanceDate)
        {

            int[] markstudent = StudentId;
            var checkdate = db.Attendances.FirstOrDefault(c => c.Date == attendanceDate);
            
                foreach (var id in markstudent)
                {
                    Attendance attendance = new Attendance();
                    attendance.StudentId = id;
                    attendance.Date = attendanceDate;
                    db.Attendances.Add(attendance);
                    db.SaveChanges();
                    TempData["message"] = "Attendance Marked " + attendanceDate.ToString("d");
                }
            var students = db.Students.ToList();
            ViewBag.students = students;

            return View();
        }

    }
}
