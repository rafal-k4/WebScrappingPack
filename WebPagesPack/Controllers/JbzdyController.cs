

using HtmlParser.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebPagesPack.Models;

namespace WebPagesPack.Controllers
{
    public class JbzdyController: Controller
    {
        public int FirstPageNumber { get; set; }
        private IJbzdyRepository jzbdyRepo;

        public JbzdyController(IJbzdyRepository repo)
        {
            jzbdyRepo = repo;
        }

        public ViewResult Index(int? id)
        {

            var model = id == null ? jzbdyRepo.GetObjects().ToList() : jzbdyRepo.GetObjects((int)id).ToList();
            var viewModel = new JbzdyViewModel { JbzdyList = model, CurrentPageNumber = FirstPageNumber };
            //model.CurrentPageNumber = id == null ? FirstPageNumber : (int)id;

            return View(viewModel);
        }

        public ActionResult GetPage(int id)
        {
            var model = jzbdyRepo.GetObjects(id);
            var viewModel = new JbzdyViewModel { JbzdyList = model, CurrentPageNumber = id };

            return PartialView("Index", viewModel);
        }
    }
}
