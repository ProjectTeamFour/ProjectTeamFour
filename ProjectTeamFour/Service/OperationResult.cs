using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Models;
using ProjectTeamFour.Service;
using System.IO;
using System.Web.Mvc;
using ProjectTeamFour.ViewModels;

namespace ProjectTeamFour.Service
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public DateTime DateTime { get; set; }
        public Exception Exception { get; set; }
        public string MessageInfo { get; set; }
        public int Status { get; set; }
        public ProjectTotalViewModel VMobj { get; set; }

    }

    public static class OperationHelper
    {
        //public static string WriteLog(this OperationResult result, string serverPath)
        //{
        //    if (result.Exception != null)
        //    {
        //        string filename = $"{result.DateTime.ToString("yyyy-MM-dd_HH_mm_ss")}.txt";
        //        string path = Path.Combine(serverPath, filename);
        //        File.WriteAllText(path, result.Exception.ToString());
        //        return path;
        //    }
        //    else
        //    {
        //        return "沒有存檔";
        //    }
        //}
    }
}