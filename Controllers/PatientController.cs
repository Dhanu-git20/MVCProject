using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PatientController : Controller
    {
        static List<PatientModel> patients = new List<PatientModel>();
        public IActionResult Add()
        {
            return View("PatientAdd", patients);
        }

        public IActionResult Submit(PatientModel obj)
        {
            patients.Add(obj);
            return View("PatientAdd", patients);
           
        }
        
    }
}
