using Infnet.MusicStore.Context;
using Infnet.MusicStore.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Infnet.MusicStore.Controllers
{
    [RoutePrefix("api/musicstore/artist")]
    public class ArtistApiController : ApiController
    {
        private readonly MusicStoreContext db = new MusicStoreContext();

        [HttpGet, Route("all")]
        // GET: api/ArtistApi
        public IHttpActionResult GetArtist()
        {
            return Ok(db.Artist);
        }

        // GET: api/ArtistApi/5
        [ResponseType(typeof(Artist)), Route("{id}")]
        public async Task<IHttpActionResult> GetArtistAsync(int id)
        {
            var artist = await db.Artist.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/ArtistApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArtistAsync(int id, Artist artist)
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

            return Ok();
        }

        // POST: api/ArtistApi
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> PostArtistAsync(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artist.Add(artist);
            await db.SaveChangesAsync();

            return CreatedAtRoute("PostArtist", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/ArtistApi/5
        [ResponseType(typeof(Artist))]
        public async Task<IHttpActionResult> DeleteArtistAsync(int id)
        {
            var artist = await db.Artist.FindAsync(id);

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
            db.Dispose();
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return db.Artist.Count(e => e.ArtistId == id) > default(int);
        }
    }
}