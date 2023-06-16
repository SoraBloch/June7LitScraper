using AngleSharp.Html.Parser;
namespace June7LitScraper.Data
{
    public static class Scraper
    {
        public static List<LitSection> Scrape()
        {
            var html = GetHtml();
            return ParseHtml(html);
        }
        private static string GetHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            using var client = new HttpClient(handler);

            var url = "https://lakewoodprogramming.com/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }

        private static List<LitSection> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var sections = new List<LitSection>();

            var divs = document.QuerySelectorAll(".section.appear.clearfix");
            foreach (var div in divs)
            {
                LitSection section = new();
                sections.Add(section);
                var titleElement = div.QuerySelector("h2");
                if (titleElement != null)
                {
                    section.Title = titleElement.TextContent;
                }
                var textElement = div.QuerySelector("p");
                if (textElement != null)
                {
                    section.Text = textElement.TextContent;
                }
                var tableElement = div.QuerySelector("table");
                if (tableElement != null)
                {
                    section.Text = tableElement.TextContent;
                }
            }
            return sections;
        }
    }
}