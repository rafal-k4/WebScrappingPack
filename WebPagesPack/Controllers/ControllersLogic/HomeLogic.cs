using System.Linq;
using WebPagesPack.Models;
using KwejkParser.Interfaces;

namespace WebPagesPack.Controllers.ControllersLogic
{
    public class HomeLogic : IHomeLogic
    {
        private IHtmlKwejkParser KwejkParser { get; set; }
        public HomeLogic(IHtmlKwejkParser kwejkParser)
        {
            KwejkParser = kwejkParser;
        }
        public IndexViewModel GetKwejkViewModel() => new IndexViewModel() { KwejkViewModel = KwejkParser.GetKwejkObjects().ToList() };

        public int GetFirstPageNumber()
        {
            return KwejkParser.GetFirstPageNumber();
        }

        public IndexViewModel GetKwejkViewModel(int id) => new IndexViewModel() { KwejkViewModel = KwejkParser.GetKwejkObjects(id).ToList() };
        
    }
}
