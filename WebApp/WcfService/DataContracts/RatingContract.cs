using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DataContracts
{
    [DataContract]
    public class RatingContract : IRatingContract
    {
        [DataMember]
        public int IdRating { set; get; }

        [DataMember]
        public int IdUser { set; get; }

        [DataMember]
        public int IdAlbum { set; get; }

        [DataMember]
        public string ArtistName { set; get; }

        [DataMember]
        public string AlbumName { set; get; }

        [DataMember]
        public int? Rating { set; get; }

        public RatingContract(Rating rating)
        {

            IdAlbum = rating.IdAlbum;
            IdRating = rating.IdRating;
            IdUser = rating.IdUser;
            ArtistName = rating.Album.ArtistName;
            AlbumName = rating.Album.AlbumName;
            Rating = rating.Rating1;

        }

        public RatingContract()
        {
        }

        public Rating ToRating()
        {
            using (var context = new MusicDatabaseEntities())
            {
                var album = (from a in context.Albums where a.IdAlbum == IdAlbum select a).SingleOrDefault();
                var user = (from u in context.Users where u.IdUser == IdUser select u).SingleOrDefault();

                Rating output = new Rating { IdAlbum = album.IdAlbum, IdRating = this.IdRating, IdUser = user.IdUser, Rating1 = Rating };
                return output;
            }

        }
    }
}
