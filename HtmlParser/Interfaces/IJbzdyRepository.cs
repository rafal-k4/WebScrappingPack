using Models;
using System.Collections.Generic;

namespace HtmlParser.Interfaces
{
    public interface IJbzdyRepository
    {
        int GetFirstPageNumber();
        IEnumerable<JbzdyModel> GetObjects();
        IEnumerable<JbzdyModel> GetObjects(int id);
    }
}
