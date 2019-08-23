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

        public User GetUserInfoByName(string username)
        {
            var user = dataAccess.ReadData_User(username);
            return user;
        }


        public UserContract Login(string username, string password)
        {
            User user = dataAccess.ReadData_User(username, password);
            return new UserContract(user);
        }

        public string AddAlbum(Album album)
        {
            string output = null;
            if (album.ArtistName.Length > 30 || album.ArtistName.Length < 3 || album.ArtistName == null)
            {
                output = "Artist name needs to have between 3 and 30 characters.";
            }

            if (album.AlbumName.Length > 30 || album.AlbumName.Length < 3 || album.AlbumName == null)
            {
                if (string.IsNullOrEmpty(output))
                    output = "Album name needs to have between 3 and 30 characters.";
                else
                    output = "Artist name and Album name need to have between 3 and 30 characters.";
            }

            if (!string.IsNullOrEmpty(output))
            {
                return output;
            }


            if (dataAccess.SaveData_Album(album))
                return "Album added.";
            else
                return "Error";
        }

        public string AddRating(Rating rating)
        {
            if (rating.Rating1 < 1 || rating.Rating1 > 10)
            {
                return "Rating needs to be between 1 - 10 range.";
            }

            var user = GetUser(rating.IdUser);
            var album = GetAlbum(rating.IdAlbum);
            if (user == null || album == null)
                return "False.";

            if(dataAccess.SaveData_Rating(rating))
                return "Rating added.";
            else
                return "Error.";
        }

        public string AddUser(User user)
        {
            string output = null;
            if (user.Username.Length > 30 || user.Username.Length < 3 || user.Username == null)
            {
                output = "User name needs to have between 3 and 30 characters.";
            }

            if (user.Password.Length > 30 || user.Password.Length < 3 || user.Password == null)
            {
                if (string.IsNullOrEmpty(output))
                    output = "Password needs to have between 3 and 30 characters.";
                else
                    output = "User name and password need to have between 3 and 30 characters.";
            }

            if (!string.IsNullOrEmpty(output))
            {
                return output;
            }

            if (dataAccess.SaveData_User(user))
                return "User added.";
            else
                return "Error.";
        }

        public Album GetAlbum(int id)
        {
           return dataAccess.ReadData_Album(id);
        }

        public Album[] GetAlbums()
        {
            return dataAccess.ReadData_Albums();
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

        public User GetUser(int id)
        {
            return dataAccess.ReadData_User(id);
        }

        public User[] GetUsers()
        {
            return dataAccess.ReadData_Users();
        }

        public string OverrideAlbum(Album album)
        {
            if (dataAccess.UpdateData_Album(album))
                return "Album record was updated.";
            else return "Record was not updated.";
        }

        public string OverrideRating(Rating rating)
        {
            if (dataAccess.UpdateData_Rating(rating))
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
