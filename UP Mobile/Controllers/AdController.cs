﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UP_Mobile.Controllers
{
    public class AdController : Controller
    {
        public IActionResult AddRole()
        {
            return View();
        }
    }
}
