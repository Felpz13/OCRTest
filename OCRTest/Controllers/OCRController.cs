﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OCRTest.Services.Interfaces;
using OCRTest.ViewModel;

namespace OCRTest.Controllers
{
    public class OCRController : Controller
    {
        private readonly IOCRService _iocrService;

        public OCRController(IOCRService iocrService)
        {
            _iocrService = iocrService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult OCRResult(string fileName, string b64String)
        {     
            var uploadSuccess = _iocrService.UploadFile(fileName, b64String).Result;

            if (uploadSuccess != null)
            {                
                var model = _iocrService.GetB64Text(uploadSuccess.data.id, fileName).Result;

                return PartialView(model);
            }
            else
            {
                return PartialView(new OCRResultViewModel());
            }           
        }
    }
}