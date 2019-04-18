using HtmlAgilityPack;
using System.Collections.Generic;


namespace KwejkParser.Interfaces
{
    public interface IHtmlKwejkRepository
    {
        IEnumerable<HtmlNode> GetPageNodes();
        IEnumerable<HtmlNode> GetPageNodes(int id);
        IEnumerable<HtmlNode> GetNodeWithFirstPageNumber();
    }
}
