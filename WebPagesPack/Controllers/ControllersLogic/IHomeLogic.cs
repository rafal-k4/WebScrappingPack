using WebPagesPack.Models;

namespace WebPagesPack.Controllers.ControllersLogic
{
    public interface IHomeLogic
    {
        IndexViewModel GetKwejkViewModel();
        IndexViewModel GetKwejkViewModel(int id);
        int GetFirstPageNumber();
    }
}
