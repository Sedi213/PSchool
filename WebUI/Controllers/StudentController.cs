using Domain.InterfaceServices;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.ResourceModels;

namespace WebUI.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICommandStudentService _cmdservice;
        public StudentController(ICommandStudentService service)
        {
            _cmdservice = service;
        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var list = await _cmdservice.GetAllStudent();

            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> NewStudent()
        {
            return View(await _cmdservice.GetAllStudent());
        }
        [HttpPost]

        public async Task<RedirectResult> NewStudent( RequestAddStudent req)
        {
            Console.WriteLine(Request);
            var note = await _cmdservice.AddStudent(new Student
            {
                ParentId = req.ParentId,
                FirstName = req.FirstName,
                LastName= req.LastName
            });

            return Redirect("~/Student/GetAll");
        }
        [HttpPost]

        public async Task<RedirectResult> DeleteStudent(Guid guid)
        {
            await _cmdservice.DeleteStudent(new Student
            {
                StudentId = guid
            });

            return Redirect("~/Student/GetAll");
        }
    }
}
