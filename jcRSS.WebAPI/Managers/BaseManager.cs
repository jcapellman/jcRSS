using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using jcRSS.PCL.Transports.Internal;

namespace jcRSS.WebAPI.Managers {
    public class BaseManager {
        internal RequestItem _requestItem;

        public BaseManager(RequestItem requestItem) {
            _requestItem = requestItem;
        }

        public static DateTime ConvertDateTimeOffset(DateTimeOffset? dateTimeOffset) {
            if (!dateTimeOffset.HasValue) {
                return DateTime.MinValue;
            }

            return new DateTime(dateTimeOffset.Value.Ticks, DateTimeKind.Utc);
        }
    }
}