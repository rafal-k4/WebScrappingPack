using HtmlAgilityPack;
using HtmlParser.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace JbzdzParser.Infrastructure
{
    public class HtmlJbzdyParser: IHtmlParser
    {
        private const string url = "https://jbzdy.pl/";
        public IEnumerable<HtmlNode> GetNodeWithFirstPageNumber()
        {
            var doc = PrepareHtmlDocument(url);
            return doc.DocumentNode.SelectNodes("//li");
        }

        public IEnumerable<HtmlNode> GetPageNodes()
        {

            var doc = PrepareHtmlDocument(url);

            var nodes = doc.DocumentNode.SelectNodes("//div").Where(x => x.Attributes["class"]?.Value.Contains("box fav") ?? false);

            return nodes;
        }

        public IEnumerable<HtmlNode> GetPageNodes(int id)
        {
            var doc = PrepareHtmlDocument(string.Concat(url, "/strona/", id));

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
