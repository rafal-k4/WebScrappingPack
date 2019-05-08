

using HtmlParser.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebPagesPack.Models;

namespace WebPagesPack.Controllers
{
    public class JbzdyController: Controller
    {
        public int FirstPageNumber { get; set; }
        private IRepository jzbdyRepo;

        public JbzdyController(IRepository repo)
        {
            jzbdyRepo = repo;
        }

        public ViewResult Index(int? id)
        {

            var model = id == null ? jzbdyRepo.GetObjects().ToList() : jzbdyRepo.GetObjects((int)id).ToList();
            var viewModel = new IndexViewModel { KwejkViewModel = model, CurrentPageNumber = FirstPageNumber };
            //model.CurrentPageNumber = id == null ? FirstPageNumber : (int)id;

            return View(viewModel);
        }

        public ActionResult GetPage(int id)
        {
            var model = jzbdyRepo.GetObjects(id);
            var viewModel = new IndexViewModel { KwejkViewModel = model, CurrentPageNumber = id };

            return PartialView("Index", viewModel);
        }
    }
}
