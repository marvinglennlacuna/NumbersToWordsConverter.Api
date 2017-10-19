using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersToWordsConverter.Api.Models
{
    public class ResponseMessageModel
    {
        public string Message { private get; set; }
        public int StatusCode { private get; set; }
    }
}