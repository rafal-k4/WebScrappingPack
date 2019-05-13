using Models;
using System.Collections.Generic;

namespace HtmlParser.Interfaces
{
    public interface IRepository
    {
        int GetFirstPageNumber();
        IEnumerable<IModel> GetObjects();
        IEnumerable<IModel> GetObjects(int id);
    }
}
