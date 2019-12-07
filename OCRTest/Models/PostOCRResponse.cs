using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCRTest.ViewModel
{
    public class PostOCRResponse
    {
        public int code { get; set; }
        public string status { get; set; }
        public ResponseDataViewModel data { get; set; }
    }

    public class ResponseDataViewModel
    {
        public string id { get; set; }
        public int minutes { get; set; }
    }
}
