using HtmlAgilityPack;

namespace opsec_task
{
    public interface IFetcher
    {
        HtmlDocument FetchHtml ();
    }
}