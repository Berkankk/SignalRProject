using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.MessageDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MessageController : Controller
    {
    

        public IActionResult Index()
        {
     
            return View();
        }
        public IActionResult ClientUserCount()
        {
            return View();
        }
      
        

    }
}
