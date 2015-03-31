using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using jcRSS.PCL.Transports.Internal;
using jcRSS.PCL.Transports.Feeds;

namespace jcRSS.PCL.Handlers {
    public class FeedHandler : BaseHandler {
        public FeedHandler(RequestItem requestItem) : base(requestItem) { }

        public async Task<List<FeedListingResponseItem>> GetFeed() {
            return await Get<List<FeedListingResponseItem>>("Feed");
        }
    }
}