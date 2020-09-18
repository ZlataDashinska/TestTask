using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TestTask1.Models;

namespace TestTask1.Controllers
{
    public class FilesController : Controller
    {
        [HttpPost("/getFiles")]
        public IActionResult getFilesByEmail(string email)
        {
            using (DataBaseContext db = new DataBaseContext()) {
                List<User> users=db.user.ToList();
                var selectedUsers = from user in users
                                    where user.email == email
                                    select user;
                User person = null;

                foreach (User x in selectedUsers)
                {
                    person = x;
                }

                if (person != null)
                {
                    List<File> files = db.files.ToList();
                    var selectedFiles = from file in files
                                        where file.user_id == person.id
                                        select file;
                    List<string> res = new List<string>();
                    foreach (File x in selectedFiles)
                    {
                        res.Add(x.path);
                    }
                    return Json(res);
                }
                }
            return null;
        }

        [HttpPost("/addFiles")]
        public IActionResult addFile(string email, string path)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                List<User> users = db.user.ToList();
                var selectedUsers = from user in users
                                    where user.email == email
                                    select user;
                User person = null;

                foreach (User x in selectedUsers)
                {
                    person = x;
                }

                if (person != null)
                {
                    File newFile = new File { id = Guid.NewGuid(), path = path, user_id = person.id };
                    IActionResult response;
                    db.files.Add(newFile);
                    try
                    {
                        db.SaveChanges();
                        response = Ok("File " + path + " added!");

                    }
                    catch (Exception e)
                    {
                        response = BadRequest(e.Message);
                    }
                    return response;
                }
            }
            return null;
        }
    }
}
