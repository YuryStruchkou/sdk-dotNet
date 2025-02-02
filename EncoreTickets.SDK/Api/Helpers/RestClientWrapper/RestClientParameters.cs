﻿using System.Collections.Generic;

namespace EncoreTickets.SDK.Api.Helpers.RestClientWrapper
{
    /// <summary>
    /// Parameters for requests of <see cref="RestClientWrapper"/>
    /// </summary>
    internal class RestClientParameters
    {
        /// <summary>
        /// Gets or sets site URL.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the relative path of a site resource.
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// Gets or sets the format for dates.
        /// </summary>
        public string RequestDateFormat { get; set; }

        /// <summary>
        /// Gets or sets request headers: key - header name; value - header value.
        /// </summary>
        public Dictionary<string, string> RequestHeaders { get; set; }

        /// <summary>
        /// Gets or sets request URL segments: key - template name in URL; value - target value.
        /// </summary>
        public Dictionary<string, string> RequestUrlSegments { get; set; }

        /// <summary>
        /// Gets or sets request query parameters: key - parameter name; value - parameter value.
        /// </summary>
        public Dictionary<string, string> RequestQueryParameters { get; set; }

        /// <summary>
        /// Gets or sets an object for a request body.
        /// </summary>
        public object RequestBody { get; set; }

        /// <summary>
        /// Gets or sets request method.
        /// </summary>
        public RequestMethod RequestMethod { get; set; }

        /// <summary>
        /// Gets or sets request format.
        /// </summary>
        public RequestFormat RequestFormat { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="RestClientParameters"/>
        /// </summary>
        public RestClientParameters()
        {
            RequestFormat = RequestFormat.Xml;
        }
    }
}