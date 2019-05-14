using Microsoft.AspNetCore.Mvc;

namespace WebPagesPack.Controllers
{
    public class HomeController:Controller
    {

        public ViewResult Index()
        {
            return View();
        }
    }
}
