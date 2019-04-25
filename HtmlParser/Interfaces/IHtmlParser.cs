using HtmlAgilityPack;
using System.Collections.Generic;

namespace HtmlParser.Interfaces
{
    public interface IHtmlParser
    {
        IEnumerable<HtmlNode> GetNodeWithFirstPageNumber();
        IEnumerable<HtmlNode> GetPageNodes();
        IEnumerable<HtmlNode> GetPageNodes(int id);
    }
}
