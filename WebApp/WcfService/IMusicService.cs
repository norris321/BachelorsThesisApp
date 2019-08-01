using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DataContracts;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMusicService
    {
        [OperationContract]
        AlbumContract[] GetAlbums();

        [OperationContract]
        UserContract Login(string username, string password);

        [OperationContract]
        AlbumContract GetAlbum(int id);

        [OperationContract]
        string AddAlbum(AlbumContract album);

        [OperationContract]
        UserContract[] GetUsers();

        [OperationContract]
        UserContract GetUser(int id);

        [OperationContract]
        UserContract GetUserByName(string username);

        [OperationContract]
        string AddUser(string username, string password, string rank);

        [OperationContract]
        RatingContract[] GetRatings();

        [OperationContract]
        RatingContract GetRating(int id);

        [OperationContract]
        string AddRating(int idUser, int idAlbum, int rating);

        [OperationContract]
        string ModifyUser(int id, string newUsername, string newPassword, string newRank);

        [OperationContract]
        string ModyifyAlbum(int id, string newArtistname, string newAlbumname);

        [OperationContract]
        string ModifyRating(int id, int idUser,int idAlbum, int rating);

        //[OperationContract]
        //void Test();

    }

}
