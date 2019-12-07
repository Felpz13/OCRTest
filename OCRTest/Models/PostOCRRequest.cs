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
