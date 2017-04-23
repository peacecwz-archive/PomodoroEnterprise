using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PomodoroEnterprise.API.EF;
using PomodoroEnterprise.API.EF.Tables;
using AutoMapper;

namespace PomodoroEnterprise.API.Controllers.API
{
    [RoutePrefix("api/tasks")]
    [Authorize]
    public class TasksController : ApiController
    {
        private DataContext db = new DataContext();

        [Route("getbyproject/{ProjectId}")]
        // GET: api/Tasks
        public IQueryable<Task> GetTasks(int ProjectId)
        {
            Guid UserId = UserHelper.GetUserId();
            var project = db.Projects.SingleOrDefault(p => p.Id == ProjectId & p.UserId == UserId);
            if (project == null)
                return null;
            return db.Tasks.Where(p => p.ProjectId == project.Id);

        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetTask(int id)
        {
            Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public async System.Threading.Tasks.Task<IHttpActionResult> PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public async System.Threading.Tasks.Task<IHttpActionResult> PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(task);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public async System.Threading.Tasks.Task<IHttpActionResult> DeleteTask(int id)
        {
            Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            await db.SaveChangesAsync();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.Id == id) > 0;
        }
    }
}