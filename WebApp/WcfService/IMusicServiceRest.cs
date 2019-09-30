using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.DataContracts;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMusicServiceRest" in both code and config file together.
    [ServiceContract]
    public interface IMusicServiceRest
    {

        //Albums
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAlbums/",
            BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AlbumContract[] GetAlbums();


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetAlbum/{id}",
            BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AlbumContract GetAlbum(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddAlbum",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddAlbum(AlbumContract album);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteAlbum",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string DeleteAlbum(int  idAlbum);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ModifyAlbum",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ModifyAlbum(AlbumContract modifiedAlbumData);


        //Users
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetUsers/",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserContract[] GetUsers();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetUser/{id}",
            BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserContract GetUser(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetUserByName/{userName}",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserContract GetUserByName(string userName);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddUser",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddUser(UserLoginContract user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteUser",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string DeleteUser(int idUser);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ModifyUser",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ModifyUser(UserLoginContract modifiedUserData);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Login",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserContract Login(UserLoginContract loginCredentials);


        //RatingContract
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetRatings/",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        RatingContract[] GetRatings();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetRatingsForUser/{id}",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        RatingContract[] GetRatingsForUser(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/GetRating/{id}",
            BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        RatingContract GetRating(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddRating",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string AddRating(RatingContract rating);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/DeleteRating",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string DeleteRating(int idUser);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ModifyRating",
        BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ModifyRating(RatingContract modifiedRatingData);

    }
}
