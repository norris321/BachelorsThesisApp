using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfService.DataContracts;

namespace WcfService.Logic
{
    public interface IMusicProcessor
    {
        AlbumContract GetAlbum(int id);
        AlbumContract[] GetAlbums();
        string AddAlbum(string artistName, string albumName);
        string OverrideAlbum(Album album);
        string DeleteData_Album(int id);

        UserContract GetUserInfoByName(string username);
        UserContract GetUser(int id);
        UserContract[] GetUsers();
        UserContract Login(string username, string password); 
        string AddUser(User user);
        string OverrideUser(User user);
        string DeleteData_User(int id);

        Rating GetRating(int id);
        Rating[] GetRatings();
        Rating[] GetRatings(int id);
        string AddRating(Rating rating);
        string OverrideRating(int ratingID, int? rating);
        string DeleteData_Rating(int id);
    }
}
