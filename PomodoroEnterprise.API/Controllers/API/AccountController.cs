using PomodoroEnterprise.API.EF;
using PomodoroEnterprise.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PomodoroEnterprise.API.Controllers.API
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private DataContext db = new DataContext();

        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterModel model)
        {
            string errorMessage = "";
            if (!ModelState.IsValid)
            {
                errorMessage = "Your infos are not valid";
            }
            var user = db.Users.SingleOrDefault(u => u.Username == model.Username | u.Email == model.Email);
            if (user == null)
            {
                db.Users.Add(new EF.Tables.User()
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password.Hash()
                });
                try
                {
                    await db.SaveChangesAsync();
                    return Ok("Create Successfuly");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            else
            {
                if (user.Username == model.Username)
                    errorMessage = "Username is already taken by another user";
                else if (user.Email == model.Email)
                    errorMessage = "Email is already registered";
                return BadRequest(errorMessage);
            }
        }
    }
}
