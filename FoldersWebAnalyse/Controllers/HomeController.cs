using FoldersWebAnalyse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;




namespace FoldersWebAnalyse.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            return View(allDrives);
        }
        public IActionResult GetResultAnalyse(string dirName)
        {
            //var drive = new FolderClass("D:\\");
            var drive = new FolderClass(dirName);
            var folderClass = Models.Folder.GeterDirs.SetDirs(drive);
            return View(folderClass);
        }
    }
}
