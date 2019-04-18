using KwejkParser.Infrastructure;
using System.Linq;
using WebPagesPack.Models;

namespace WebPagesPack.Controllers.ControllersLogic
{
    public class HomeLogic : IHomeLogic
    {
        public IndexViewModel GetKwejkViewModel() => new IndexViewModel() { KwejkViewModel = new HtmlKwejkParser().GetKwejkObjects().ToList() };
    }
}
