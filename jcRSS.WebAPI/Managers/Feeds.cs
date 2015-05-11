using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using jcRSS.PCL.Transports.Internal;
using jcRSS.PCL.Transports.Feeds;

namespace jcRSS.WebAPI.Managers {
    public class Feeds : BaseManager {
        public Feeds(RequestItem requestItem) : base(requestItem) { }


        public List<FeedListingResponseItem> GetListing() {
            using (var eFactory = new jcRSS.DataLayer.jcEntityFactory()) {
               /* var result = eFactory.WEBAPI_getFeedListingSP(_requestItem.UserID).ToList();

                return result.Select(a => new FeedListingResponseItem { 
                    Title = a.Title, 
                    FeedID = a.ID, 
                    NumUnread = a.NumUnread ?? 0}).ToList();*/

            return new List<FeedListingResponseItem>();
            }
        }
    }
}