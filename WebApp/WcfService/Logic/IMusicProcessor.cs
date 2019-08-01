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
        Album GetAlbum(int id);
        Album[] GetAlbums();
        string AddAlbum(Album album);

        User GetUserInfoByName(string username);
        User GetUser(int id);
        User[] GetUsers();
        UserContract Login(string username, string password); 
        string AddUser(User user);

        Rating GetRating(int id);
        Rating[] GetRatings();
        string AddRating(Rating rating);

        string OverrideUser(User user);
        string OverrideRating(Rating rating);
        string OverrideAlbum(Album album);
    }
}
