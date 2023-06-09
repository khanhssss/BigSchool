﻿using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbConText;

        public HomeController()
        {
            _dbConText = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingCourses = _dbConText.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);

            return View(upcomingCourses);
        }

    
    }
}