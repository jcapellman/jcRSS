using System.Collections.Generic;

using jcRSS.PCL.Transports.Feeds;

namespace jcRSS.WebAPI.Controllers {
    public class FeedController : BaseAPIController {
        public List<FeedListingResponseItem> GET() {
            return new Managers.Feeds(REQUEST_ITEM).GetListing();
        }
    }
}