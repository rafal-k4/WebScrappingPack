using Microsoft.AspNetCore.Mvc;
using WebPagesPack.Controllers.ControllersLogic;

namespace WebPagesPack.Controllers
{
    public class HomeController:Controller
    {
        private IHomeLogic homeLogic;
        public HomeController(IHomeLogic homeLogic)
        {
            this.homeLogic = homeLogic;
        }

        public ViewResult Index()
        {
            var model = homeLogic.GetKwejkViewModel();
            

            return View(model);
        }
    }
}
