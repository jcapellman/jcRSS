using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using jcRSS.PCL.Transports.Content;

namespace jcRSS.WebAPI.Controllers {
    public class ContentController : BaseAPIController {
        public List<ContentListingResponseItem> GET(int? feedID = null) {
            return new Managers.Content(REQUEST_ITEM).GetContentListing(feedID);
        }
    }
}