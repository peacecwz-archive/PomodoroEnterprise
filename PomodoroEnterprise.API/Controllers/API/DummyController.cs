using PomodoroEnterprise.API.EF;
using PomodoroEnterprise.API.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PomodoroEnterprise.API.Controllers.API
{
    [RoutePrefix("api/dummy")]
    public class DummyController : ApiController
    {
        private DataContext db = new DataContext();

        [Route("insert")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var scode = new EF.Tables.Project()
            {
                Name = "Scode",
                UserId = Guid.Parse(""),
                Description = "Scode Code World"
            };
            var tcm = new EF.Tables.Project()
            {
                Name = "TCM.DOFI",
                UserId = Guid.Parse(""),
                Description = ""
            };
            var tcmYemekSepeti = new EF.Tables.Project()
            {
                Name = "TCM.YemekSepeti",
                UserId = Guid.Parse(""),
                Description = ""
            };
            db.Projects.Add(scode);
            db.Projects.Add(tcm);
            db.Projects.Add(tcmYemekSepeti);
            List<Task> tasks = new List<Task>()
            {
                new Task()
                {
                    Name = "Scode Golang Backend Geliştirme",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                },
                new Task()
                {
                    Name = "Scode React Native Mobile App Geliştirme",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                },
                new Task()
                {
                    Name = "Scode Tasarımların Tamamlanması",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                },
                new Task()
                {
                    Name = "Scode PR Yapılması",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                },
                new Task()
                {
                    Name = "Scode FATİH Projesi Entegrasyonları",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                },
                new Task()
                {
                    Name = "Scode Unit Testlerin yapılması",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                },
                new Task()
                {
                    Name = "Scode Azure Deploy",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                },
                new Task()
                {
                    Name = "Scode A/B Testleri",
                    Deadline = DateTime.Now.AddDays(7),
                    ProjectId = scode.Id
                }
            };
            db.Tasks.AddRange(tasks);
            db.SaveChanges();
            return Ok();
        }
    }
}
