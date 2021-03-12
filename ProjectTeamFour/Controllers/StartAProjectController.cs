using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using ProjectTeamFour.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectTeamFour.Controllers
{
    public class StartAProjectController : Controller
    {


        private MemberService _MemberService;

        public StartAProjectController()
        {
            _MemberService = new MemberService();
        }
        // GET: StartAProject
        public ActionResult Index()
        {
            int result = _MemberService.ReturnLoginnerId();

            if (result == 0)
            {
                return RedirectToAction("Login", "Member");
            }

            return View();
        }

        public ActionResult SubmissionProcess()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<string> UpLoadImg(HttpPostedFile file)
        //{
        //    //HttpFileCollection files = HttpContext.Current.Request.Files;
        //    //HttpPostedFile file = files[0];
        //    if (file == null || file.ContentLength == 0)
        //    {
        //        return null;
        //    }

        //    try
        //    {
        //        BinaryReader binaryReader = new BinaryReader(file.InputStream);
        //        byte[] byteArray = binaryReader.ReadBytes(file.ContentLength);
        //        var apiClient = new ApiClient("7cc84057ff7498d");
        //        var httpClient = new HttpClient();
        //        var imageEndpoint = new ImageEndpoint(apiClient, httpClient);
        //        var imageUpload = await imageEndpoint.UploadImageAsync(new MemoryStream(byteArray));

        //        return "成功" + imageUpload.Link;

        //    }
        //    catch (Exception ex)
        //    {
        //        return "失敗" + ex.ToString();
        //    }

        //}
    }
}