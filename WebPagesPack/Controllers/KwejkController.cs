using Microsoft.AspNetCore.Mvc;
using WebPagesPack.Controllers.ControllersLogic;
using HtmlParser.Interfaces;
using System.Linq;
using WebPagesPack.Models;

namespace WebPagesPack.Controllers
{
    public class KwejkController: Controller
    {

        public int FirstPageNumber { get; set; }
        private IRepository kwejkRepo;

        public KwejkController(IRepository kwejkRepo)
        {
            this.kwejkRepo = kwejkRepo;
            FirstPageNumber = kwejkRepo.GetFirstPageNumber();
        }

        public ViewResult Index(int? id)
        {

            var model = id == null ? kwejkRepo.GetObjects().ToList() : kwejkRepo.GetObjects((int)id).ToList();
            var viewModel = new IndexViewModel { KwejkViewModel = model, CurrentPageNumber = FirstPageNumber }
            //model.CurrentPageNumber = id == null ? FirstPageNumber : (int)id;

            return View(model);
        }

        public ActionResult GetPage(int id)
        {
            var model = kwejkRepo.GetObjects(id);

            return PartialView("Index", model);
        }
    }
}
