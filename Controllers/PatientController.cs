using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Dal;

namespace WebApplication.Controllers
{
    [EnableCors("AllowOriginRule")]
    public class PatientController : Controller
    {

        public IActionResult Submit([FromBody]PatientModel obj)
        {
            PatientDal dal = new PatientDal();
            dal.Database.EnsureCreated();
            dal.Add(obj);// Save in Memory
            dal.SaveChanges();//physical commit
            

            List<PatientModel> recs = dal.PatientModels.ToList<PatientModel>();

            return Json(recs);
           
        }
        
    }
}
