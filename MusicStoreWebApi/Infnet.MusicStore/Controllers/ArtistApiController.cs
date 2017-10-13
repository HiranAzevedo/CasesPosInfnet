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
using Infnet.MusicStore.Context;
using Infnet.MusicStore.Models;

namespace Infnet.MusicStore.Controllers
{
    [RoutePrefix("api/musicstore/artist")]
    public class ArtistApiController : ApiController
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET: api/ArtistApi
        public IQueryable<Artist> GetArtist()
        {
            return db.Artist;
        }

        // GET: api/ArtistApi/5
        [ResponseType(typeof(Artist)), Route("{id}")]
        public async Task<IHttpActionResult> GetArtist(int id)
        {
            Artist artist = await db.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/ArtistApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            db.Entry(artist).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/ArtistApi
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> PostArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artist.Add(artist);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> DeleteArtist(int id)
        {
            Artist artist = await db.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            db.Artist.Remove(artist);
            await db.SaveChangesAsync();

            return Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return db.Artist.Count(e => e.ArtistId == id) > 0;
        }
    }
}