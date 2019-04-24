using Microsoft.AspNetCore.Mvc;
using WebPagesPack.Controllers.ControllersLogic;

namespace WebPagesPack.Controllers
{
    public class HomeController:Controller
    {

        public string Index(int? id)
        {
            return "coś tam";
        }
    }
}
