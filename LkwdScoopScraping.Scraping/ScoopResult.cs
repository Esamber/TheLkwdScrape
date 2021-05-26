using System;
using System.Collections.Generic;
using System.Text;

namespace LkwdScoopScraping.Scraping
{
    public class ScoopResult
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Blurb { get; set; }
        public int CommentCount { get; set; }
        public string LinkUrl { get; set; }
    }
}
