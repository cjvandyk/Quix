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
using Quix.REST.Data;
using Quix.REST.Models;

namespace Quix.REST.Controllers
{
    public class SubscribersController : ApiController
    {
        private Context db = new Context();

        // GET: api/Subscribers
        //public IQueryable<Subscriber> GetSubscribers()
        public IQueryable<SubscriberDto> GetSubscribers()
        {
            //return db.Subscribers;
            var subscribers = from s in db.Subscribers
                              select new SubscriberDto()
                              {
                                  Id = s.Id,
                                  Name = s.Name
                              };
            return subscribers;
        }

        // GET: api/Subscribers/5
        //[ResponseType(typeof(Subscriber))]
        [ResponseType(typeof(SubscriberDto))]
        public async Task<IHttpActionResult> GetSubscriber(Guid id)
        {
            //Subscriber subscriber = await db.Subscribers.FindAsync(id);
            var subscriber = await db.Subscribers.Select(
                s => new SubscriberDetailDto()
                {
                    Id = s.Id,
                    Name = s.Name
                }).SingleOrDefaultAsync(s => s.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

        // PUT: api/Subscribers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubscriber(Guid id, Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriber.Id)
            {
                return BadRequest();
            }

            db.Entry(subscriber).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(id))
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

        // POST: api/Subscribers
        //[ResponseType(typeof(Subscriber))]
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> PostSubscriber(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subscribers.Add(subscriber);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubscriberExists(subscriber.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtRoute("DefaultApi", new { id = subscriber.Id }, subscriber);
            var dto = new SubscriberDto()
            {
                Id = subscriber.Id,
                Name = subscriber.Name
            };
            return CreatedAtRoute("DefaultApi", new { id = subscriber.Id }, dto);
        }

        // DELETE: api/Subscribers/5
        [ResponseType(typeof(Subscriber))]
        public async Task<IHttpActionResult> DeleteSubscriber(Guid id)
        {
            Subscriber subscriber = await db.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            db.Subscribers.Remove(subscriber);
            await db.SaveChangesAsync();

            return Ok(subscriber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubscriberExists(Guid id)
        {
            return db.Subscribers.Count(e => e.Id == id) > 0;
        }
    }
}