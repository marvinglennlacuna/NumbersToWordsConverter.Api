using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumbersToWordsConverter.Api.Models
{
    public class DataModel
    {
        public string Name { get; set; }
        public decimal Numbers { get; set; }
        public string Words{ get; set;  }
    }
}