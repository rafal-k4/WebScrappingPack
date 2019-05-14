using Microsoft.AspNetCore.Mvc;
using HtmlParser.Interfaces;
using System.Linq;
using WebPagesPack.Models;

namespace WebPagesPack.Controllers
{
    public class KwejkController: Controller
    {

        public int FirstPageNumber { get; set; }
        private IKwejkRepository kwejkRepo;

        public KwejkController(IKwejkRepository kwejkRepo)
        {
            this.kwejkRepo = kwejkRepo;
            FirstPageNumber = kwejkRepo.GetFirstPageNumber();
        }

        public ViewResult Index(int? id)
        {

            var model = id == null ? kwejkRepo.GetObjects().ToList() : kwejkRepo.GetObjects((int)id).ToList();
            var viewModel = new KwejkViewModel { KwejkList = model, CurrentPageNumber = FirstPageNumber };
            //model.CurrentPageNumber = id == null ? FirstPageNumber : (int)id;

            return View(viewModel);
        }

        public ActionResult GetPage(int id)
        {
            var model = kwejkRepo.GetObjects(id);
            var viewModel = new KwejkViewModel { KwejkList = model, CurrentPageNumber = id };

            return PartialView("Index", viewModel);
        }
    }
}
