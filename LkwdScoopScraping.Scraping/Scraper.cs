using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace LkwdScoopScraping.Scraping
{
    public static class Scraper
    {
        public static List<ScoopResult> ScrapeScoop()
        {
            var results = new List<ScoopResult>();
            var html = GetScoopHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            IHtmlCollection<IElement> searchResultElements = document.QuerySelectorAll("#content");
            foreach (IElement result in searchResultElements)
            {
                var ScoopResult = new ScoopResult();

                ScoopResult.Title = result.QuerySelector("h2").TextContent;
                ScoopResult.LinkUrl = result.QuerySelector("a.more-link").Attributes["href"].Value;

                var imageElement = result.QuerySelector("img");
                if (imageElement != null)
                {
                    var imageSrcValue = imageElement.Attributes["src"].Value;
                    ScoopResult.ImageUrl = imageSrcValue;
                }

                ScoopResult.Blurb = result.QuerySelector("a.fancybox").TextContent;

                string commentCountString = result.QuerySelector("div.backtotop").TextContent;
                string commentCountDigits = String.Join("", commentCountString.Where(char.IsDigit));
                ScoopResult.CommentCount = (commentCountDigits != "")
                    ? int.Parse(commentCountDigits)
                    : 0;

                results.Add(ScoopResult);


            }

            return results;
        }

        private static string GetScoopHtml()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            string url = $"https://www.lakewoodscoop.com";
            var client = new HttpClient(handler);
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
    }
