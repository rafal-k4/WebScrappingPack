using HtmlAgilityPack;
using System.Collections.Generic;


namespace KwejkParser.Interfaces
{
    public interface IHtmlKwejkRepository
    {
        IEnumerable<HtmlNode> GetPageNodes();
    }
}
