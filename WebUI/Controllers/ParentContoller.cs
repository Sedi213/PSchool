using Domain.InterfaceServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebUI.ResourceModels;

namespace WebUI.Controllers
{
    [Route("Parent/[action]")]
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
        public async Task<RedirectResult> NewParent(RequestAddParent req)
        {
            Console.WriteLine(Request);
            var note = await _cmdservice.AddParent(new Parent
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email,
                Phone = req.Phone,
                WorkPhone = req.WorkPhone,
                HomeAddress = req.HomeAddress,
                NickName = req.NickName,
                Sibilings = req.Sibilings,
            });


            return Redirect("~/Parent/GetAll");
        }
        [HttpPost]
        public async Task<RedirectResult> DeleteParent(Guid guid)
        {
            await _cmdservice.DeleteParent(new Parent
            {
                ParentId = guid
            });

            return Redirect("~/Parent/GetAll");
        }
    }
}
