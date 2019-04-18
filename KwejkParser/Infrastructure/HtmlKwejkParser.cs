using System.Collections.Generic;
using System.Linq;
using Models;
using HtmlAgilityPack;
using KwejkParser.Interfaces;


namespace KwejkParser.Infrastructure
{
    public class HtmlKwejkParser: IHtmlKwejkParser
    {
        public IHtmlKwejkRepository KwejkRepository { get; set; }

        public HtmlKwejkParser(IHtmlKwejkRepository kwejkRepo)
        {
            KwejkRepository = kwejkRepo;
        }
        public IEnumerable<KwejkModel> GetKwejkObjects()
        {
            IEnumerable<HtmlNode> nodes = KwejkRepository.GetPageNodes();

            foreach(var node in nodes)
            {

                var title = node.Descendants("h2").
                        Select(x => x.Descendants("a").Where(y => y.Attributes["dusk"]?.Value == "media-title-selector").
                        FirstOrDefault()?.InnerText).FirstOrDefault();
     
                var url = node.Descendants("img").Where(x => x.Attributes["class"]?.Value == "full-image").Select(y => y.Attributes["src"]?.Value).FirstOrDefault();


                yield return new KwejkModel() { ImageUrl = url?.Trim(), Title = title?.Trim().Replace("\t","").Replace("\n"," ") };
            }

        }
    }
}
