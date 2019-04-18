using Microsoft.AspNetCore.Mvc;
using WebPagesPack.Controllers.ControllersLogic;

namespace WebPagesPack.Controllers
{
    public class HomeController:Controller
    {
        public int FirstPageNumber { get; set; }
        private IHomeLogic homeLogic;
        
        public HomeController(IHomeLogic homeLogic)
        {
            this.homeLogic = homeLogic;
            FirstPageNumber = homeLogic.GetFirstPageNumber();
        }

        public ViewResult Index(int id)
        {
            var model = homeLogic.GetKwejkViewModel();
            model.FirstPageNumber = FirstPageNumber;

            return View(model);
        }
    }
}
