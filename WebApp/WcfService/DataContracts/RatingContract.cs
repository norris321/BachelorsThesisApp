using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DataContracts
{
    [DataContract]
    public class RatingContract
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
            //Album album = new Album { ArtistName = ArtistName, AlbumName = AlbumName };
            using (var context = new MusicDBEntities())
            {
                var album = (from a in context.Albums where a.ArtistName == ArtistName && a.AlbumName == AlbumName select a).SingleOrDefault();
                var user = (from u in context.Users where u.IdUser == IdUser select u).SingleOrDefault();

                Rating output = new Rating { Album = album, IdAlbum = album.IdAlbum, IdRating = IdRating, User = user, IdUser = IdUser, Rating1 = Rating };
                return output;
            }

                //Rating rating = new Rating { Album = album, }
        }
    }
}
