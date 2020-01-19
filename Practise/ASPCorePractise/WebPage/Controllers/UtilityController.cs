using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebPage.Controllers
{
    public class UtilityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult RemoveChinese()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveChinese([FromForm]string InputStr)
        {
            System.Text.StringBuilder strB = new System.Text.StringBuilder();
            var lines = InputStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var lineTrim = line.Trim();
                if (!string.IsNullOrWhiteSpace(lineTrim))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(lineTrim, @"[\u4e00-\u9fa5]"))
                    {
                        continue;
                    }
                    if (lineTrim.Contains(""))
                    {
                        lineTrim = lineTrim.Replace("", string.Empty);
                    }
                    strB.Append(lineTrim+Environment.NewLine);
                }
            }
            ViewBag.Lines = strB.ToString();
            return View();
        }
         
    }
}