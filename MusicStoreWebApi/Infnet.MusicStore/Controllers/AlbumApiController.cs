using Infnet.MusicStore.Context;
using Infnet.MusicStore.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Infnet.MusicStore.Controllers
{
    [RoutePrefix("api/musicstore/album")]
    public class AlbumApiController : ApiController
    {
        private readonly MusicStoreContext db = new MusicStoreContext();

        // GET: api/AlbumApi
        [HttpGet, ResponseType(typeof(Album)), Route("all")]
        public IHttpActionResult GetAlbum()
        {
            return Ok(db.Album);
        }

        // GET: api/AlbumApi/5
        [ResponseType(typeof(Album)), HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> GetAlbumAsync(int id)
        {
            var album = await db.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/AlbumApi/5
        [ResponseType(typeof(void)), Route("{id}"), HttpPut]
        public async Task<IHttpActionResult> PutAlbumAsync(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.AlbumId)
            {
                return BadRequest();
            }

            db.Entry(album).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/AlbumApi
        [ResponseType(typeof(Album)), HttpPost, Route("album")]
        public async Task<IHttpActionResult> PostAlbumAsync(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Album.Add(album);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = album.AlbumId }, album);
        }

        // DELETE: api/AlbumApi/5
        [ResponseType(typeof(Album)), HttpDelete, Route("album")]
        public async Task<IHttpActionResult> DeleteAlbum(int id)
        {
            Album album = await db.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            db.Album.Remove(album);
            await db.SaveChangesAsync();

            return Ok(album);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
            db.Dispose();
        }

        private bool AlbumExists(int id)
        {
            return db.Album.Count(e => e.AlbumId == id) > 0;
        }
    }
}