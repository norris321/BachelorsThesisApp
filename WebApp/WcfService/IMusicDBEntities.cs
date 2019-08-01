using System.Data.Entity;

namespace WcfService
{
    public interface IMusicDBEntities
    {
        DbSet<Album> Albums { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<User> Users { get; set; }
        bool SaveAlbum(Album album);
        bool SaveRating(Rating rating);
        bool SaveUser(User user);
    }
}