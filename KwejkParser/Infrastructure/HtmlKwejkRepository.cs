using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using KwejkParser.Interfaces;

namespace KwejkParser.Infrastructure
{
    public class HtmlKwejkRepository: IHtmlKwejkRepository
    {
        private const string url = "https://kwejk.pl/";
        public IEnumerable<HtmlNode> GetNodeWithFirstPageNumber()
        {
            var doc = PrepareHtmlDocument(url);
            return doc.DocumentNode.SelectNodes("//li");
        }

        public IEnumerable<HtmlNode> GetPageNodes()
        {

            var doc = PrepareHtmlDocument(url);

            var nodes = doc.DocumentNode.SelectNodes("//div").Where(x => x.Attributes["class"]?.Value.Contains("box fav") ?? false );

            return nodes;
        }

        public IEnumerable<HtmlNode> GetPageNodes(int id)
        {
            var doc = PrepareHtmlDocument(string.Concat(url,"/strona/", id));

            var nodes = doc.DocumentNode.SelectNodes("//div").Where(x => x.Attributes["class"]?.Value.Contains("box fav") ?? false);

            return nodes;
        }

        private HtmlDocument PrepareHtmlDocument(string url)
        {
            var web = new HtmlWeb();
            return web.Load(url);
        }


    }
}
