using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PomodoroEnterprise.API.EF;
using PomodoroEnterprise.API.EF.Tables;

namespace PomodoroEnterprise.API.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/pomodoroes")]
    public class PomodoroesController : ApiController
    {
        private DataContext db = new DataContext();

        [Route("getbytask/{TaskId}")]
        // GET: api/Pomodoroes
        public IQueryable<Pomodoro> GetPomodoroes(int TaskId)
        {
            return db.Pomodoroes.Where(p => p.TaskId == TaskId);
        }

        // GET: api/Pomodoroes/5
        [ResponseType(typeof(Pomodoro))]
        public async Task<IHttpActionResult> GetPomodoro(int id)
        {
            Pomodoro pomodoro = await db.Pomodoroes.FindAsync(id);
            if (pomodoro == null)
            {
                return NotFound();
            }

            return Ok(pomodoro);
        }

        // PUT: api/Pomodoroes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPomodoro(int id, Pomodoro pomodoro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pomodoro.Id)
            {
                return BadRequest();
            }

            db.Entry(pomodoro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PomodoroExists(id))
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

        // POST: api/Pomodoroes
        [ResponseType(typeof(Pomodoro))]
        public async Task<IHttpActionResult> PostPomodoro(Pomodoro pomodoro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pomodoroes.Add(pomodoro);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pomodoro.Id }, pomodoro);
        }

        // DELETE: api/Pomodoroes/5
        [ResponseType(typeof(Pomodoro))]
        public async Task<IHttpActionResult> DeletePomodoro(int id)
        {
            Pomodoro pomodoro = await db.Pomodoroes.FindAsync(id);
            if (pomodoro == null)
            {
                return NotFound();
            }

            db.Pomodoroes.Remove(pomodoro);
            await db.SaveChangesAsync();

            return Ok(pomodoro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PomodoroExists(int id)
        {
            return db.Pomodoroes.Count(e => e.Id == id) > 0;
        }
    }
}