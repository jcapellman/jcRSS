using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using jcRSS.PCL.Transports.Internal;

namespace jcRSS.WebAPI.Controllers {
    public class BaseAPIController : ApiController {
        public RequestItem REQUEST_ITEM {
            get {
                return new RequestItem { WebAPIAddress = jcRSS.PCL.Common.Constants.CONST_WEBAPI_ADDRESS };
            }
        }
    }
}