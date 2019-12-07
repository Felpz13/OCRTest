using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCRTest.ViewModel
{
    public class GetOCRResponse
    {
        public int code { get; set; }
        public string status { get; set; }
        public ResponseGetDataViewModel data { get; set; }
    }

    public class ResponseGetDataViewModel
    {
        public string id { get; set; }
        public string encode { get; set; }
        public string content { get; set; }
    }
}
