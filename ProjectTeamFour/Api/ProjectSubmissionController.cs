using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectTeamFour.Models;
using ProjectTeamFour.ViewModels;
using ProjectTeamFour.Service;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.IO;
using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ProjectTeamFour.Api
{
    public class ProjectSubmissionController : ApiController
    {
        private SubmissionProcessService _submissionservice;
        private LogService _logservice;
        private ProjectDetailEntityService _projectdetailentityservice;

        public ProjectSubmissionController()
        {
            _submissionservice = new SubmissionProcessService();
            _logservice = new LogService();
            _projectdetailentityservice = new ProjectDetailEntityService();
        }

        public OperationResult ReceiveData([FromBody] SubmissionProcessViewModel input)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            OperationResult result = new OperationResult();
            result.Status = _submissionservice.ReturnLoginnerId();

            sw.Stop();
            //Console.WriteLine($"{sw.ElapsedMilliseconds}ms");

            var first = sw.ElapsedMilliseconds;



            sw.Restart();

            result = _submissionservice.ReceiveSubmissionData(input, result.Status);

            sw.Stop();
            //Console.WriteLine($"{sw.ElapsedMilliseconds}ms");

            var second = sw.ElapsedMilliseconds;


            // if(ModelState.IsValid) 前端做
            if (result.IsSuccessful)
            {
                return result;
            }
            else
            {
                Log entity = new Log()
                {
                    //Path = result.WriteLog(HostingEnvironment.MapPath("~/Assets/Log/")),
                    DateTime = result.DateTime
                };
                _logservice.Create(entity);
                return result;
            }
        }


        public OperationResult ReceiveDraftData([FromBody] SubmissionProcessViewModel input)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            OperationResult result = new OperationResult();
            result.Status = _submissionservice.ReturnLoginnerId();

            sw.Stop();
            //Console.WriteLine($"{sw.ElapsedMilliseconds}ms");

            var first = sw.ElapsedMilliseconds;



            sw.Restart();

            result = _submissionservice.ReceiveDraftData(input, result.Status);

            sw.Stop();
            //Console.WriteLine($"{sw.ElapsedMilliseconds}ms");

            var second = sw.ElapsedMilliseconds;


            // if(ModelState.IsValid) 前端做
            if (result.IsSuccessful)
            {
                return result;
            }
            else
            {
                Log entity = new Log()
                {
                    //Path = result.WriteLog(HostingEnvironment.MapPath("~/Assets/Log/")),
                    DateTime = result.DateTime
                };
                _logservice.Create(entity);
                return result;
            }
        }


        [System.Web.Mvc.HttpPost]
        public async Task<string> UpLoadImg(HttpPostedFile file)
        {
            //HttpFileCollection files = HttpContext.Current.Request.Files;
            //HttpPostedFile file = files[0];
            if (file == null || file.ContentLength == 0)
            {
                return null;
            }

            try
            {
                BinaryReader binaryReader = new BinaryReader(file.InputStream);
                byte[] byteArray = binaryReader.ReadBytes(file.ContentLength);
                var apiClient = new ApiClient("7cc84057ff7498d");
                var httpClient = new HttpClient();
                var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
                var imageUpload = await imageEndpoint.UploadImageAsync(new MemoryStream(byteArray));

                return "成功" + imageUpload.Link;

            }
            catch (Exception ex)
            {
                return "失敗" + ex.ToString();
            }

        }

        //[System.Web.Http.HttpPost]
        //public ActionResult UploadImage(HttpPostedFile uploadFile)
        //{
        //    if (uploadFile.ContentLength > 0)
        //    {
        //        var imgService = new ImgUrImageService();
        //        byte[] fileBytes = new byte[uploadFile.ContentLength];
        //        uploadFile.InputStream.Read(fileBytes, 0, fileBytes.Length);
        //        uploadFile.InputStream.Close();
        //        string fileContent = Convert.ToBase64String(fileBytes);
        //        var response = imgService.Upload(fileContent);
        //    }
        //    return View();
        //}


        public string UploadFiles()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            HttpPostedFile file = files[0];
            var stream = file.InputStream;
            var myAccount = new Account { ApiKey = "846843815975652", ApiSecret = "qMRPPwm3IgED3Uzefx5CRhz_W7g", Cloud = "dymc0bi31" };
            Cloudinary _cloudinary = new Cloudinary(myAccount);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream)
            };
            ImageUploadResult uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.SecureUri.AbsoluteUri;
        }
       
    }
}
