using System.Linq;
using WebPagesPack.Models;
using HtmlParser.Interfaces;

namespace WebPagesPack.Controllers.ControllersLogic
{
    public class HomeLogic : IHomeLogic
    {
        private IRepository KwejkRepo { get; set; }
        public HomeLogic(IRepository kwejkRepo)
        {
            KwejkRepo = kwejkRepo;
        }
        public IndexViewModel GetKwejkViewModel() => new IndexViewModel() { KwejkViewModel = KwejkRepo.GetObjects().ToList() };

        public int GetFirstPageNumber()
        {
            return KwejkRepo.GetFirstPageNumber();
        }

        public IndexViewModel GetKwejkViewModel(int id) => new IndexViewModel() { KwejkViewModel = KwejkRepo.GetObjects(id).ToList() };
        
    }
}
