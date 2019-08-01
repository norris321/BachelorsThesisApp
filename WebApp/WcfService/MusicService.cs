using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DataContracts;
using WcfService.Logic;
using WcfService.Utilities;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MusicService : IMusicService
    {
        public string AddAlbum(AlbumContract album)
        {

            MusicProcessor process = new MusicProcessor(new DataAccess());
            return process.AddAlbum(album.ToAlbum());
        }


        public string AddRating(int idUser, int idAlbum,int rating )
        { 

            MusicProcessor process = new MusicProcessor(new DataAccess());
            Rating newRating = new Rating { IdAlbum = idAlbum, IdUser = idUser, Rating1 = rating };
            return process.AddRating(newRating);

        }

        public string AddUser(string username, string password, string rank)
        {
            MusicProcessor process = new MusicProcessor(new DataAccess());
            User user = new User { Username = username, Password = password, Rank = rank };
            return process.AddUser(user);

        }

        public AlbumContract GetAlbum(int id)
        {
            //ReadData readData = new ReadData(new MusicDBEntities());
            var query = new MusicProcessor(new DataAccess());

            return new AlbumContract(query.GetAlbum(id));
        }

        public UserContract GetUserByName(string username)
        {
            var query = new MusicProcessor(new DataAccess());

            return new UserContract(query.GetUserInfoByName(username));
        }

        public AlbumContract[] GetAlbums()
        {
            var query = new MusicProcessor(new DataAccess());

            var albums = query.GetAlbums();
            AlbumContract[] output = new AlbumContract[albums.Length];
            for(int i = 0; i < albums.Length;i++)
            {
                output[i] = new AlbumContract(albums[i]);
            }

            return output;
        }

        public RatingContract GetRating(int id)
        {
            var query = new MusicProcessor(new DataAccess());

            return new RatingContract(query.GetRating(id));
        }

        public RatingContract[] GetRatings()
        {
            var query = new MusicProcessor(new DataAccess());

            var ratings = query.GetRatings();
            RatingContract[] output = new RatingContract[ratings.Length];
            for (int i = 0; i < ratings.Length; i++)
            {
                output[i] = new RatingContract(ratings[i]);
            }

            return output;
        }

        public UserContract GetUser(int id)
        {
            var query = new MusicProcessor(new DataAccess());

            return new UserContract(query.GetUser(id));
        }

        public UserContract[] GetUsers()
        {
            var query = new MusicProcessor(new DataAccess());

            var users = query.GetUsers();
            UserContract[] output = new UserContract[users.Length];
            for (int i = 0; i < users.Length; i++)
            {
                output[i] = new UserContract(users[i]);
            }

            return output;
        }

        public string ModifyUser(int id, string newUsername, string newPassword, string newRank)
        {
            var query = new MusicProcessor(new DataAccess());

            return query.OverrideUser(new User { IdUser = id, Password = newPassword, Username = newUsername, Rank = newRank});

        }

        public string ModyifyAlbum(int id, string newArtistname, string newAlbumname)
        {
            var query = new MusicProcessor(new DataAccess());

            return query.OverrideAlbum(new Album { IdAlbum = id, ArtistName = newArtistname, AlbumName = newAlbumname});
        }

        public string ModifyRating(int id, int idUser, int idAlbum, int rating)
        {
            using (MusicDBEntities entities = new MusicDBEntities())
            {
                var album = (from a in entities.Albums where a.IdAlbum == idAlbum select a).SingleOrDefault();
                var user = (from u in entities.Users where u.IdUser == idUser select u).SingleOrDefault();

                Rating modifiedRating = new Rating { Album = album, IdAlbum = idAlbum, IdRating = id, IdUser = idUser, User = user, Rating1 = rating };

                var query = new MusicProcessor(new DataAccess());
                return query.OverrideRating(modifiedRating);
            }
        }


        public UserContract Login(string username, string password)
        {
            var query = new MusicProcessor(new DataAccess());
            return query.Login(username, password);           

        }
    }
}
