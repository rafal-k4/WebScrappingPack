using System.Collections.Generic;
using System.Linq;
using HtmlParser.Interfaces;

namespace JbzdzParser.Infrastructure
{
    public class HtmlJbzdyRepository: IRepository
    {
        private const string url = "https://jbzdy.pl/";


        public IEnumerable<HtmlNode> GetPageNodes()
        {

            var doc = PrepareHtmlDocument(url);

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
