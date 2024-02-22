using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NET.Models
{
    public class ResponseModel
    {

        public HttpStatusCode httpStatusCode { get; set; }
        public string? httpStatusMessage { get; set; }


        public ResponseModel(HttpStatusCode httpStatusCode, string httpStatusMessage)
        {
            this.httpStatusCode = httpStatusCode;
            this.httpStatusMessage = httpStatusMessage;



        }

    }
}