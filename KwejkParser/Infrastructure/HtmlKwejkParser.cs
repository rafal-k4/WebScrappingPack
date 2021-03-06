﻿using System.Collections.Generic;
using System.Linq;
using Models;
using HtmlAgilityPack;
using KwejkParser.Interfaces;
using System;

namespace KwejkParser.Infrastructure
{
    public class HtmlKwejkParser : IHtmlKwejkParser
    {
        public IHtmlKwejkRepository KwejkRepository { get; set; }

        public HtmlKwejkParser(IHtmlKwejkRepository kwejkRepo)
        {
            KwejkRepository = kwejkRepo;
        }
        public IEnumerable<KwejkModel> GetKwejkObjects()
        {
            IEnumerable<HtmlNode> nodes = KwejkRepository.GetPageNodes();

            return GetParsedKwejkObjects(nodes);
        }

        public IEnumerable<KwejkModel> GetKwejkObjects(int id)
        {
            var nodes = KwejkRepository.GetPageNodes(id);

            return GetParsedKwejkObjects(nodes);
        }

        private IEnumerable<KwejkModel> GetParsedKwejkObjects(IEnumerable<HtmlNode> nodes)
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
            var nodes = KwejkRepository.GetNodeWithFirstPageNumber();
            var resultNumberAsText = nodes.Where(x => x.Attributes["class"]?.Value == "current").FirstOrDefault()?.InnerText.Trim();

            int resultNumber;
            int.TryParse(resultNumberAsText, out resultNumber);
            return resultNumber;
        }

    }
}
