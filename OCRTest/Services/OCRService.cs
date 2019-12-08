using Newtonsoft.Json;
using OCRTest.Models;
using OCRTest.Services.Interfaces;
using OCRTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OCRTest.Services
{
    public class OCRService : IOCRService
    {
        private readonly IHttpClientFactory _clientFactory;
        public OCRService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }             

        public async Task<PostOCRResponse> UploadFile(string fileName, string b64String, string apiKey)
        {
            var requestBody = new PostOCRRequest()
            {
                input = "base64",
                file = b64String,
                filename = fileName,
                outputformat = "txt",
                apikey = apiKey,
                options = new OCROption()

            };

            var requestBodyJSON = JsonConvert.SerializeObject(requestBody);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://api.convertio.co/convert");
            request.Content = new StringContent(requestBodyJSON);
           
            using(var client = _clientFactory.CreateClient())
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<PostOCRResponse>(responseString);

                    return result;
                }
                else
                {
                    return null;
                }
            }          
        }

        public async Task<OCRResultViewModel> GetB64Text(string fileId, string fileName)
        {            
            var ocrResult = new OCRResultViewModel();

            var newRequest = new HttpRequestMessage(HttpMethod.Get, "http://api.convertio.co/convert/" + fileId + "/dl");

            using (var client = _clientFactory.CreateClient())
            {
                var response = await client.SendAsync(newRequest);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetOCRResponse>(responseString);

                if (result.code == 200)
                {                  
                    ocrResult.Name = "Sucesso!";
                    ocrResult.Data = fileName;
                    ocrResult.Token = result.data.content;
                }
                else
                {
                    ocrResult.Name = "Falha";
                    ocrResult.Data = "";
                    ocrResult.Token = "Arquivo corrompido ou excedido o limite de uso da key!";
                }
                return ocrResult;
            }                
        }

        public async Task<FileStatus> GetConversionStatus(string fileId)
        {
            var newRequest = new HttpRequestMessage(HttpMethod.Get, "http://api.convertio.co/convert/" + fileId + "/status");
            

            using (var client = _clientFactory.CreateClient())
            {
                var response = await client.SendAsync(newRequest);

                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<FileStatus>(responseString);

                return result;
            }
        }
    }
}
