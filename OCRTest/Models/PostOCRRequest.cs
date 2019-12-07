using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCRTest.ViewModel
{
    public class PostOCRRequest
    {
        public string apikey { get; set; }
        public string input { get; set; }
        public string file { get; set; }
        public string filename { get; set; }
        public string outputformat { get; set; }
        public OCROption options { get; set; }
        public PostOCRRequest()
        {
            //apikey = "f6f17474ddf658654083ba033b803672"; //Felipe
            apikey = "81eabfdaa24866b0fdbe3860ede79f35"; //Pedro
        }


    }

    public class OCROption
    {
        public bool ocr_enabled { get; set; }
        public OCRSettings ocr_settings { get; set; }
        public OCROption()
        {
            ocr_enabled = true;
            ocr_settings = new OCRSettings();
        }
    }

    public class OCRSettings
    {
        public string[] langs { get; set; }

        public OCRSettings()
        {
            langs = new string[]{ "bra" };
        }
    }
}
