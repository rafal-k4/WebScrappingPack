using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KwejkParser.Infrastructure
{
    public class HtmlKwejkRepository
    {
        internal IEnumerable<HtmlNode> GetPageNodes()
        {
            var url = "https://kwejk.pl/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var nodes = doc.DocumentNode.SelectNodes("//div").Where(x => x.Attributes["class"]?.Value.Contains("box fav") ?? false );

            return nodes;
        }
    }
}
