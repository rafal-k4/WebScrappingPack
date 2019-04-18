using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using KwejkParser.Interfaces;

namespace KwejkParser.Infrastructure
{
    public class HtmlKwejkRepository: IHtmlKwejkRepository
    {
        public IEnumerable<HtmlNode> GetPageNodes()
        {
            var url = "https://kwejk.pl/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var nodes = doc.DocumentNode.SelectNodes("//div").Where(x => x.Attributes["class"]?.Value.Contains("box fav") ?? false );

            return nodes;
        }
    }
}
