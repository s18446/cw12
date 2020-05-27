using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw12.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw12.Controllers
{
    public class PatientsController : Controller
    {
        public IActionResult Index()
        {
            var db = new s18446Context();
            var patients = db.Patiens.ToList();
            return View(patients);
        }

        public string GetDetails()
        {
            return "Jan Kowalski";
        }
    }
}