using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LkwdScoopScraping.Scraping;

namespace LkwdScoopScraping.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [Route("scrape")]
        public List<ScoopResult> Scrape()
        {
            return Scraper.ScrapeScoop();
        }
    }
}
