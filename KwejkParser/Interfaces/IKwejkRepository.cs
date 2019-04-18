using HtmlAgilityPack;
using System.Collections.Generic;


namespace KwejkParser.Interfaces
{
    public interface IKwejkRepository
    {
        IEnumerable<HtmlNode> GetPageNodes();
    }
}
