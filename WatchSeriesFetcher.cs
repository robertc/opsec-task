using HtmlAgilityPack;

namespace opsec_task
{
    public class WatchSeriesFetcher : IFetcher 
    {

        private const string REQUEST_URL = "https://www.watchseries1.video/all-series/";//TODO(RC) Move to config

        public WatchSeriesFetcher() {}

        public HtmlDocument FetchHtml()
        {
            var webRequester = new HtmlWeb();
            var returnDocument = webRequester.Load(REQUEST_URL);
            return returnDocument;
        }
    }
}