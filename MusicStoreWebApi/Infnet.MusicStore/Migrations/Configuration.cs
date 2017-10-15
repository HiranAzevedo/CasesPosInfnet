using Infnet.MusicStore.Context;
using Infnet.MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Infnet.MusicStore.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MusicStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MusicStoreContext context)
        {
            context.Artist.AddOrUpdate(x => x.Name, new Artist
            {
                Name = "Kurt",
                ArtistId = 1,

            });

            context.Genre.AddOrUpdate(x => x.Name, new Genre
            {
                Description = "Rock and Roll",
                Name = "Rock",
                GenreId = 1,
            });

            context.Album.AddOrUpdate(x => x.Title, new Album
            {
                AlbumId = 1,
                AlbumArtUrl = "http://default.com",
                Artist = new List<Artist> { context.Artist.Find(1) },
                Price = 99,
                Title = "Kurtando a vida",
                GenreId = 1,
            });

            context.Order.AddOrUpdate(x => x.Email, new Order
            {
                Address = "Rua 123",
                Email = "hiran@email.com",
                City = "Rj",
                Country = "BRA",
                FirstName = "hiran",
                LastName = "azevedo",
                OrderDate = DateTime.Now,
                Phone = "1232",
                PostalCode = "3456546",
                State = "RJ",
                Total = 199.99m,
                UserName = "hiran.azevedo",
                OrderId = 1
            });

            context.OrderDetail.AddOrUpdate(x => x.OrderDetailId, new OrderDetail
            {
                AlbumId = 1,
                OrderDetailId = 1,
                Quantity = 12,
                OrderId = 1,
                UnitPrice = 199.99m,
            });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
