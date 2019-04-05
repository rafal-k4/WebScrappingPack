using KwejkParser.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPagesPack.Models;

namespace WebPagesPack.Controllers.ControllersLogic
{
    public class HomeLogic : IHomeLogic
    {
        public IndexViewModel GetKwejkViewModel() => new IndexViewModel() { KwejkViewModel = new HtmlKwejkParser().GetKwejkObjects().ToList() };
    }
}
