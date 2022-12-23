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

        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var list = await _cmdservice.GetAllStudent();

            return View(list);
        }
        [HttpPost]

        public async Task<ActionResult<Student>> NewNote([FromBody] RequestAddStudent req)
        {
            var note = await _cmdservice.AddStudent(new Student
            {
                ParentId = req.ParentId,
                FirstName = req.FirstName,
                LastName= req.LastName
            });

            return Ok();
        }
        [HttpPost]

        public async Task<ActionResult> DeleteNote(Guid guid)
        {
            await _cmdservice.DeleteStudent(new Student
            {
                StudentId = guid
            });

            return Ok();
        }
    }
}
