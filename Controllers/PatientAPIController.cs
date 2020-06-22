using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.Dal;
using WebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        string constr = "";
        public PatientAPIController (IConfiguration configuration)
        {
            constr = configuration["ConnStr"];
        }
        // GET: api/<PatientAPIController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
          //  return new string[] { "value1", "value2" };
        //}

        // GET api/<PatientAPIController>/5
        [HttpGet]
        public IActionResult Get(string patientName)
        {
            PatientDal dal = new PatientDal(constr);
            List<PatientModel> search = (from temp in dal.PatientModels
                                         where temp.name == patientName
                                         select temp)
                                        .ToList<PatientModel>();
            return Ok(search);
        }

        // POST api/<PatientAPIController
        [HttpPost]
        public IActionResult Post(PatientModel obj)
        {
            var context = new ValidationContext(obj, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, context, result, true);

            if (result.Count == 0)
            {
                PatientDal dal = new PatientDal(constr);
                dal.Database.EnsureCreated();
                dal.Add(obj);// Save in Memory
                dal.SaveChanges();//physical commit
                List<PatientModel> recs = dal.PatientModels.ToList<PatientModel>();

                return Ok(recs);
            }
            else
            {
                return StatusCode(500, result);
            }
        }

        // PUT api/<PatientAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
