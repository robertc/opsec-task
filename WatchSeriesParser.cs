using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System.Linq;

namespace opsec_task
{
    public class WatchSeriesParser : IParser 
    {
        public WatchSeriesParser() {}

        public Dictionary<string,string> ParseHtml (HtmlDocument htmlDocument)
        {
            var ret = new Dictionary<string,string>();
            var nodes = htmlDocument.DocumentNode.QuerySelectorAll("li.list-group-item>a");

            foreach (var node in nodes)
            {
                var link = node.Attributes["href"]?.Value;

                var title = node.QuerySelectorAll("div>b").FirstOrDefault()?.InnerText;

                if (!string.IsNullOrWhiteSpace(link) && !string.IsNullOrWhiteSpace(title))
                {
                    ret.Add(title!, link!);
                }
            }

            return ret;
        }
    }
}