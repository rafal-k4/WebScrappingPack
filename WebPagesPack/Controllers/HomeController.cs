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

        public ViewResult Index(int? id)
        {

            var model = id == null ? homeLogic.GetKwejkViewModel() : homeLogic.GetKwejkViewModel((int)id);
            model.CurrentPageNumber = id == null ? FirstPageNumber : (int)id;

            return View(model);
        }

        public ActionResult GetPage(int id)
        {
            var model = homeLogic.GetKwejkViewModel(id);

            return PartialView("Index", model);
        }
    }
}
