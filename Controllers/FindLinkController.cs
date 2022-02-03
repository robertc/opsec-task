using Microsoft.AspNetCore.Mvc;

namespace opsec_task.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FindLinkController : ControllerBase
    {
        private readonly ILogger<FindLinkController> _logger;
        private readonly IFetcher _fetcher;
        private readonly IParser _parser;

        public FindLinkController(ILogger<FindLinkController> logger)
        {
            _logger = logger;
            _fetcher = new WatchSeriesFetcher();
            _parser = new WatchSeriesParser();
        }

        [HttpGet]
        public string Get(string term)
        {
            _logger.LogInformation($"Received request {term} at {DateTimeOffset.UtcNow}");
            try
            {
                var fetchResult = _fetcher.FetchHtml();
                var foundLinks = _parser.ParseHtml(fetchResult);

                if (foundLinks.ContainsKey(term))
                    return foundLinks[term];
                else
                    _logger.LogInformation($"No link found for {term}");//TODO(RC) Return a 404 here
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, $"Unexpected error processing {term}");
            }

            return string.Empty;
        }
    }
}