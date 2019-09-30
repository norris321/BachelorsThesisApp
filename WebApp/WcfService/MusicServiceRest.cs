using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DataContracts;
using WcfService.Logic;
using Newtonsoft.Json.Serialization;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MusicServiceRest" in both code and config file together.
    public class MusicServiceRest : IMusicServiceRest
    {
        public AlbumContract[] GetAlbums()
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            var albums = processor.GetAlbums();

            return albums;
        }

        public AlbumContract GetAlbum(string id)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            int _id;
            try
            {
                Int32.TryParse(id, out _id);
            }
            catch (Exception e)
            {
                return null;
            }

            return processor.GetAlbum(_id);
            
        }

        public string AddAlbum(AlbumContract album)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.AddAlbum(album.ArtistName, album.AlbumName);

            return message;
        }

        public string DeleteAlbum(int idAlbum)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.DeleteData_Album(idAlbum);

            return message;
        }

        public string ModifyAlbum(AlbumContract modifiedAlbumData)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.OverrideAlbum(modifiedAlbumData.ToAlbum());

            return message;
        }


        public UserContract[] GetUsers()
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            var users = processor.GetUsers();
 
            return users;
        }

        public UserContract GetUser(string id)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            int _id;

            try
            {
                Int32.TryParse(id, out _id);
            }
            catch(Exception)
            {
                return null;
            }

            return processor.GetUser(_id);

        }

        public UserContract GetUserByName(string userName)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            var user = processor.GetUserInfoByName(userName);

            return user;
        }

        public string AddUser(UserLoginContract user)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.AddUser(user.ToUser());

            return message;
        }

        public string DeleteUser(int idUser)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.DeleteData_User(idUser);

            return message;
        }

        public string ModifyUser(UserLoginContract modifiedUserData)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.OverrideUser(modifiedUserData.ToUser());

            return message;
        }

        public UserContract Login(UserLoginContract loginCredentials)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();

            var user = processor.Login(loginCredentials.Username, loginCredentials.Password);

            return user;
        }

        public RatingContract[] GetRatings()
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            var ratings = processor.GetRatings();
            RatingContract[] output = new RatingContract[ratings.Length];

            for(int i = 0; i < ratings.Length;i++)
            {
                output[i] = new RatingContract(ratings[i]);
            }

            return output;
        }

        public RatingContract[] GetRatingsForUser(string id)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            var ratings = processor.GetRatings(Int32.Parse(id));

            if (ratings == null)
                return null;

            RatingContract[] output = new RatingContract[ratings.Length];

            for (int i = 0; i < ratings.Length; i++)
            {
                output[i] = new RatingContract(ratings[i]);
            }

            return output;
        }

        public RatingContract GetRating(string id)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            int _id;

            try
            {
                Int32.TryParse(id, out _id);
            }
            catch (Exception)
            {
                return null;
            }

            return new RatingContract(processor.GetRating(_id));
        }

        public string AddRating(RatingContract rating)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.AddRating(rating.ToRating());

            return message;
        }

        public string DeleteRating(int idUser)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.DeleteData_Rating(idUser);

            return message;
        }

        public string ModifyRating(RatingContract modifiedRatingData)
        {
            IMusicProcessor processor = Factory.GetIMusicProcessorInstance();
            string message = processor.OverrideRating(modifiedRatingData.IdRating, modifiedRatingData.Rating);

            return message;
        }
    }
}
