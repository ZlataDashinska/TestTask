using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask1.Models;

namespace TestTask1.Controllers
{
    public class RegController : Controller
    {

        [HttpPost("/registration")]
        public IActionResult Registration(string email, string password, string name)
        {

            User newUser = new User { id = Guid.NewGuid(), name = name, email = email, password_hash = Help.GetHashString(password) };
            using (DataBaseContext db = new DataBaseContext())
            {
                IActionResult response;
                db.user.Add(newUser);
                try {
                    db.SaveChanges();
                    response = Ok("User " + name + " created!");

                }
                catch(Exception e)
                {
                    response = BadRequest(e.Message);
                }
                return response;
            }
        }
    }
}
