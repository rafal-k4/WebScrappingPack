using Models;
using System.Collections.Generic;


namespace KwejkParser.Interfaces
{
    public interface IHtmlKwejkParser
    {
        IEnumerable<KwejkModel> GetKwejkObjects();
        int GetFirstPageNumber();
    }
}
