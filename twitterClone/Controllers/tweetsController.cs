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
using twitterClone.Models;

namespace twitterClone.Controllers
{
    public class tweetsController : ApiController
    {
        private twitterDBEntities1 db = new twitterDBEntities1();

        // GET: api/tweets
        public IQueryable<tweet> Gettweets()
        {
            return db.tweets;
        }

        // GET: api/tweets/5
        [ResponseType(typeof(tweet))]
        public IHttpActionResult Gettweet(int id)
        {
            tweet tweet = db.tweets.Find(id);
            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        // PUT: api/tweets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttweet(int id, tweet tweet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tweet.Id)
            {
                return BadRequest();
            }

            db.Entry(tweet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tweetExists(id))
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

        // POST: api/tweets
        [ResponseType(typeof(tweet))]
        public IHttpActionResult Posttweet(tweet tweet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tweets.Add(tweet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tweet.Id }, tweet);
        }

        // DELETE: api/tweets/5
        [ResponseType(typeof(tweet))]
        public IHttpActionResult Deletetweet(int id)
        {
            tweet tweet = db.tweets.Find(id);
            if (tweet == null)
            {
                return NotFound();
            }

            db.tweets.Remove(tweet);
            db.SaveChanges();

            return Ok(tweet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tweetExists(int id)
        {
            return db.tweets.Count(e => e.Id == id) > 0;
        }
    }
}