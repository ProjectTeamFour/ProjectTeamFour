using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTeamFour.Models;
using ProjectTeamFour.Service;
using System.IO;

namespace ProjectTeamFour.Service
{
    public class OperationResult
    {
        public bool IsSuccessful { get; set; }
        public DateTime DateTime { get; set; }
        public Exception Exception { get; set; }
        public Member Member { get; set; }
    }

    public static class OperationHelper
    {
        public static string  WriteLog(this OperationResult result)
        {
            if (result.Exception != null)
            {
                string path = $"~/Assets/Log/{result.DateTime.ToString("yyyy-MM-dd_HH_mm_ss")}.txt";
                File.WriteAllText(path, result.Exception.ToString());
                return path;
            }
            else
            {
                return "沒有存檔";
            }
        }
    }
}