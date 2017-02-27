using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Day1API.Models;
using System.Data.Entity;

namespace Day1API.Controllers
{
    public class DogController : ApiController
    {
        DogContext db = new DogContext();

        [ResponseType(typeof(Dog))]
        public IHttpActionResult Get()
        {
            DbSet<Dog> results = db.Dogs;
            return Ok(results);
        }

        public IHttpActionResult Get(int id)
        {
            Dog result = db.Dogs.Find(id);
            return Ok(result);
        }

        public IHttpActionResult Post(Dog dog)
        {
            db.Dogs.Add(dog);
            db.SaveChanges();
            return Created("Get", dog);
        }

        public IHttpActionResult Put(int id, Dog dog)
        {
            dog.Id = id;
            db.Entry(dog).State = EntityState.Modified;

            // Step 3
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            Dog dog = db.Dogs.Find(id);
            db.Dogs.Remove(dog);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
