using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using jcRSS.PCL.Transports.Content;
using jcRSS.PCL.Transports.Internal;

namespace jcRSS.PCL.Handlers {
    public class ContentHandler : BaseHandler {
        public ContentHandler(RequestItem requestItem) : base(requestItem) { }

        public async Task<List<ContentListingResponseItem>>GetContent(int? feedID = null) {
            return await Get<List<ContentListingResponseItem>>(String.Format("Content?feedID={0}", feedID));
        }
    }
}