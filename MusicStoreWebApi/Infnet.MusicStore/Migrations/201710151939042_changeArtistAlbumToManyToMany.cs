namespace Infnet.MusicStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeArtistAlbumToManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropIndex("dbo.Album", new[] { "ArtistId" });
            CreateTable(
                "dbo.ArtistAlbum",
                c => new
                    {
                        Artist_ArtistId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ArtistId, t.Album_AlbumId })
                .ForeignKey("dbo.Artist", t => t.Artist_ArtistId)
                .ForeignKey("dbo.Album", t => t.Album_AlbumId)
                .Index(t => t.Artist_ArtistId)
                .Index(t => t.Album_AlbumId);
            
            DropColumn("dbo.Album", "ArtistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Album", "ArtistId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ArtistAlbum", "Album_AlbumId", "dbo.Album");
            DropForeignKey("dbo.ArtistAlbum", "Artist_ArtistId", "dbo.Artist");
            DropIndex("dbo.ArtistAlbum", new[] { "Album_AlbumId" });
            DropIndex("dbo.ArtistAlbum", new[] { "Artist_ArtistId" });
            DropTable("dbo.ArtistAlbum");
            CreateIndex("dbo.Album", "ArtistId");
            AddForeignKey("dbo.Album", "ArtistId", "dbo.Artist", "ArtistId");
        }
    }
}
