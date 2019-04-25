using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using HtmlParser.Interfaces;
using Models;

namespace JbzdzParser.Infrastructure
{
    public class HtmlJbzdyRepository: IRepository
    {
        public IHtmlParser JbzdyParser { get; set; }

        public HtmlJbzdyRepository(IHtmlParser jbzdyRepo)
        {
            JbzdyParser = jbzdyRepo;
        }
        public IEnumerable<KwejkModel> GetObjects()
        {
            IEnumerable<HtmlNode> nodes = JbzdyParser.GetPageNodes();

            return GetJbzdyObject(nodes);
        }

        public IEnumerable<KwejkModel> GetObjects(int id)
        {
            var nodes = JbzdyParser.GetPageNodes(id);

            return GetJbzdyObject(nodes);
        }

        private IEnumerable<KwejkModel> GetJbzdyObject(IEnumerable<HtmlNode> nodes)
        {
            foreach (var node in nodes)
            {

                var title = node.Descendants("h2").
                        Select(x => x.Descendants("a").Where(y => y.Attributes["dusk"]?.Value == "media-title-selector").
                        FirstOrDefault()?.InnerText).FirstOrDefault();

                var imageUrl = node.Descendants("img").Where(x => x.Attributes["class"]?.Value == "full-image").Select(y => y.Attributes["src"]?.Value).FirstOrDefault();
                var videoUrl = node.Descendants("player").Where(x => x.Attributes["class"]?.Value.Contains("player") == true).Select(y => y.Attributes["source"]?.Value).FirstOrDefault();

                yield return new KwejkModel() { ImageUrl = imageUrl?.Trim(), VideoUrl = videoUrl, Title = title?.Trim().Replace("\t", "").Replace("\n", " ") };
            }
        }

        public int GetFirstPageNumber()
        {
            var nodes = JbzdyParser.GetNodeWithFirstPageNumber();
            var resultNumberAsText = nodes.Where(x => x.Attributes["class"]?.Value == "current").FirstOrDefault()?.InnerText.Trim();

            int resultNumber;
            int.TryParse(resultNumberAsText, out resultNumber);
            return resultNumber;
        }
    }
}
