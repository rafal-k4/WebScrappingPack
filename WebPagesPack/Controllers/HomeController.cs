using Microsoft.AspNetCore.Mvc;
using WebPagesPack.Controllers.ControllersLogic;

namespace WebPagesPack.Controllers
{
    public class HomeController:Controller
    {

        public ViewResult Index(int? id)
        {
            return View();
        }
    }
}
