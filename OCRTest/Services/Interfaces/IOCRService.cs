using OCRTest.Models;
using OCRTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCRTest.Services.Interfaces
{
    public interface IOCRService
    {
        Task<PostOCRResponse> UploadFile(string fileName, string b64String);
        Task<OCRResultViewModel> GetB64Text(string fileId, string fileName);

        Task<FileStatus> GetConversionStatus(string fileId);
    }
}
