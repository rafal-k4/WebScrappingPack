using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPagesPack.Controllers.ControllersLogic;
using WebPagesPack.Models;

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
            

            return View();
        }
    }
}
