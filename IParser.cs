using HtmlAgilityPack;

namespace opsec_task
{
    public interface IParser
    {
        Dictionary<string,string> ParseHtml (HtmlDocument htmlDocument);
    }
}