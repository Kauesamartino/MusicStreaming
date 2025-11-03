using Microsoft.AspNetCore.Mvc;

namespace MusicStreaming.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
