using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Droplist.api.data;

namespace Droplist.api.Controllers
{
	public class DroplistsController : ApiController
    {
        private DroplistDataContext db = new DroplistDataContext();

		// GET: api/Droplists
		public IHttpActionResult GetDroplists()
		{
			var resultSet = db.Droplists.Select(droplist => new
			{
				droplist.DroplistId,
				droplist.BuildingId,
				droplist.DroplistName,
				droplist.CreatedOnDate,
				droplist.EmployeeId,
				droplist.SectionId,
				droplist.Description
			});

			return Ok(resultSet);
		}

        // GET: api/Droplists/5
        [ResponseType(typeof(Models.Droplist))]
        public IHttpActionResult GetDroplist(int id)
        {
            Models.Droplist droplist = db.Droplists.Find(id);
            if (droplist == null)
            {
                return NotFound();
            }
			var resultSet = new
			{
				droplist.DroplistId,
				droplist.BuildingId,
				droplist.DroplistName,
				droplist.CreatedOnDate,
				droplist.EmployeeId,
				droplist.SectionId,
				droplist.Description

			};
			return Ok(resultSet);

		}

        // PUT: api/Droplists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDroplist(int id, Models.Droplist droplist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != droplist.DroplistId)
            {
                return BadRequest();
            }
			var dbDroplist = db.Droplists.Find(id);
			dbDroplist.DroplistId = droplist.DroplistId;
			dbDroplist.BuildingId = droplist.BuildingId;
			dbDroplist.EmployeeId = droplist.EmployeeId;
			dbDroplist.DroplistName = droplist.DroplistName;
			dbDroplist.SectionId = droplist.SectionId;
			dbDroplist.CreatedOnDate = droplist.CreatedOnDate;
			dbDroplist.Description = droplist.Description;

			db.Entry(dbDroplist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DroplistExists(id))
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

        // POST: api/Droplists
        [ResponseType(typeof(Models.Droplist))]
        public IHttpActionResult PostDroplist(Models.Droplist droplist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Droplists.Add(droplist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = droplist.DroplistId }, new
			{
				droplist.DroplistId,
				droplist.BuildingId,
				droplist.DroplistName,
				droplist.CreatedOnDate,
				droplist.EmployeeId,
				droplist.SectionId,
				droplist.Description
			});
        }

        // DELETE: api/Droplists/5
        [ResponseType(typeof(Models.Droplist))]
        public IHttpActionResult DeleteDroplist(int id)
        {
			Models.Droplist droplist = db.Droplists.Find(id);
            if (droplist == null)
            {
                return NotFound();
            }

            db.Droplists.Remove(droplist);
            db.SaveChanges();

            return Ok(droplist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DroplistExists(int id)
        {
            return db.Droplists.Count(e => e.DroplistId == id) > 0;
        }
    }
}