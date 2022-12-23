using Domain.InterfaceServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebUI.ResourceModels;
using Application.Services;

namespace WebUI.Controllers
{
    public class ParentContoller : Controller
    {
        private readonly ICommandParentService _cmdservice;
        public ParentContoller(ICommandParentService service)
        {
            _cmdservice = service;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var list = await _cmdservice.GetAllParent();

            return View(list);
        }

        [HttpGet]
        public IActionResult NewParent()
        {
            return View();
        }
        [HttpPost]

        public async Task<ActionResult<Parent>> NewParent([FromBody] RequestAddStudent req)
        {
            var note = await _cmdservice.AddParent(new Parent());
           

            return Redirect("~/Parent/GetAll");
        }
        [HttpPost]

        public async Task<ActionResult> DeleteNote(Guid guid)
        {
            await _cmdservice.DeleteParent(new Parent
            {
                ParentId = guid
            });

            return Ok();
        }
    }
}
