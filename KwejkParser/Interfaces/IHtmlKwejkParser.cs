using Models;
using System.Collections.Generic;


namespace KwejkParser.Interfaces
{
    public interface IHtmlKwejkParser
    {
        IEnumerable<KwejkModel> GetKwejkObjects();
        IEnumerable<KwejkModel> GetKwejkObjects(int id);
        int GetFirstPageNumber();
    }
}
