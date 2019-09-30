using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService.DataContracts;
using WcfService.Utilities;

namespace WcfService.Logic
{
    public class MusicProcessor : IMusicProcessor
    {
        IDataAccess dataAccess;

        public MusicProcessor(IDataAccess context)
        {
            dataAccess = context;
        }

        public UserContract GetUserInfoByName(string username)
        {
            var user = dataAccess.ReadData_User(username);
            return new UserContract(user);
        }


        public UserContract Login(string username, string password)
        {
            User user = dataAccess.ReadData_User(username, password);
            return new UserContract(user);
        }

        public string AddAlbum(string artistName, string albumName)
        {
            if (String.IsNullOrEmpty(artistName)  || String.IsNullOrEmpty(albumName))
            {
                return "Input forms cannont be empty";
            }
            else if (artistName.Length > 30 || artistName.Length < 3 || albumName.Length > 30 || albumName.Length < 3)
            {
                return "Artist and album name need to have between 3 and 30 characters.";
            }
            else if (dataAccess.ReadData_Album(artistName, albumName) != null)
            {
                return "Album is added already.";
            }
            else if (dataAccess.SaveData_Album(artistName, albumName))
            {
                return "Album added.";
            }
            else
            {
                return "Error";
            }
        }

        public string AddRating(Rating rating)
        {
            if (rating.Rating1 < 1 || rating.Rating1 > 10)
            {
                return "Rating needs to be between 1 - 10 range.";
            }

            var user = dataAccess.ReadData_User(rating.IdUser);
            var album = dataAccess.ReadData_Album(rating.IdAlbum);

            if (user == null || album == null)
                return "Error: album or user record not found.";

            if(dataAccess.SaveData_Rating(rating))
                return "Rating added.";
            else
                return "Error.";
        }

        public string AddUser(User user)
        {
            if ( string.IsNullOrEmpty(user.Username) || String.IsNullOrEmpty(user.Password))
            {
                return "Input forms cannont be empty.";
            }
            else if (user.Username.Length < 3 || user.Username.Length > 30)
            {
                return "User name needs to have between 3 and 30 characters.";
            }
            else if (user.Password.Length > 30 || user.Password.Length < 3)
            {
                return "Password needs to have between 3 and 30 characters.";
            }
            else if (dataAccess.SaveData_User(user))
            {
                return "User added.";
            }
            else
            {
                return "Error.";
            }
        }

        public AlbumContract GetAlbum(int id)
        {
            Album album = dataAccess.ReadData_Album(id);
            AlbumContract output = new AlbumContract(album);
            return output;
        }

        public AlbumContract[] GetAlbums()
        {
            Album[] albums = dataAccess.ReadData_Albums();
            AlbumContract[] output = new AlbumContract[albums.Length];
            for(int i = 0; i < albums.Length;i++)
            {
                output[i] = new AlbumContract(albums[i]);
            }

            return output;
        }

        public Rating GetRating(int id)
        {
            return dataAccess.ReadData_Rating(id);
        }

        public Rating[] GetRatings()
        {
            return dataAccess.ReadData_Ratings();
        }

        public Rating[] GetRatings(int id)
        {
            return dataAccess.ReadData_Ratings(id);
        }

        public UserContract GetUser(int id)
        {
            var user = dataAccess.ReadData_User(id);
            return new UserContract(user);
        }

        public UserContract[] GetUsers()
        {
            var users = dataAccess.ReadData_Users();
            UserContract[] output = new UserContract[users.Length];
            for(int i = 0; i < output.Length; i++)
            {
                output[i] = new UserContract(users[i]);
            }

            return output;
        }

        public string OverrideAlbum(Album album)
        {
            if (dataAccess.UpdateData_Album(album))
                return "Album record was updated.";
            else return "Record was not updated.";
        }

        public string OverrideRating(int ratingId, int? rating)
        {
            if (dataAccess.UpdateData_Rating(ratingId, rating))
                return "Rating record was updated.";
            else
                return "Record was not updated.";
        }

        public string OverrideUser(User user)
        {
            if (dataAccess.UpdateData_User(user))
                return "User record was updated.";
            else
                return "Record was not updated.";
        }


        public string DeleteData_Album(int id)
        {
            if(dataAccess.DeleteData_Album(id))
            {
                return "Album was deleted";
            }
            else
            {
                return "Error: album was not deleted";
            }
        }

        public string DeleteData_User(int id)
        {
            if (dataAccess.DeleteData_User(id))
            {
                return "User was deleted";
            }
            else
            {
                return "Error: user was not deleted";
            }
        }
        public string DeleteData_Rating(int id)
        {
            if (dataAccess.DeleteData_Rating(id))
            {
                return "Rating was deleted";
            }
            else
            {
                return "Error: rating was not deleted";
            }
        }

    }
}
