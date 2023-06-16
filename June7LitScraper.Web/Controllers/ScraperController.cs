using June7LitScraper.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace June7LitScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<LitSection> Scrape()
        {
            return June7LitScraper.Data.Scraper.Scrape();
        }
    }
}
