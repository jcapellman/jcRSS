using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using jcRSS.PCL.Transports.Feeds;

namespace jcRSS.WebAPI.Controllers {
    public class FeedController : BaseAPIController {
        public List<FeedListingResponseItem> GET() {
            return new Managers.Feeds(REQUEST_ITEM).GetListing();
        }
    }
}