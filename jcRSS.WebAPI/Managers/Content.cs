using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using jcRSS.DataLayer;
using jcRSS.PCL.Transports.Internal;
using jcRSS.PCL.Transports.Content;

namespace jcRSS.WebAPI.Managers {
    public class Content : BaseManager {
        public Content(RequestItem requestItem) : base(requestItem) { }

        public List<ContentListingResponseItem> GetContentListing(int? feedID = null) {
            using (var eFactory = new jcEntityFactory()) {
                //     var result = eFactory.WEBAPI_getContentListSP(_requestItem.UserID, feedID).ToList();

                //   return result.Select(a => new ContentListingResponseItem { Body = a.ContentBody, ContentFeedID = a.ID, Title = a.ContentTitle, PostDate = ConvertDateTimeOffset(a.ContentPostDate) }).ToList();
                return new List<ContentListingResponseItem>();
            }
        }
    }
}