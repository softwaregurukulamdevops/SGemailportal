using EmailPortel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public EmailController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetEmailDetails")]
        public List<Email> GetEmailDetails()
        {
            List<Email> lstEmail = new List<Email>();
            try
            {
                lstEmail = trainingDBContext.Email.ToList();
                return lstEmail;
            }
            catch (Exception ex)
            {
                lstEmail = new List<Email>();
                return lstEmail;
            }
        }
        [HttpPost("AddEmail")]
        public string AddEmail(Email email)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(email.Email1))
                {
                    trainingDBContext.Add(email);
                    trainingDBContext.SaveChanges();
                    message = "Email added successfully";
                }
                else
                    message = "Email required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
