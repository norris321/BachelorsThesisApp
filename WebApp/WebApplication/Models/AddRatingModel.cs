using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.WcfServiceReference;
using WebApplication.ServicesConnections;

namespace WebApplication.Models
{
    public class AddRatingModel
    {
        public string Rating { set; get; }
        public string Album { set; get; }

        public static IEnumerable<SelectListItem> RateAlbum()
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return new SelectListItem { Text = i.ToString(), Value = i.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> ChooseAlbum()
        {
            AccessWcfService service = new AccessWcfService("GetAlbums", "GET");
            string userJsonData = service.GetJsonFromService();
            AlbumContract[] albums = Newtonsoft.Json.JsonConvert.DeserializeObject<AlbumContract[]>(userJsonData);

            if (albums == null)
            {
                yield return new SelectListItem { Text = "null", Value = "null" };
            }
            else
            {
                foreach (AlbumContract a in albums)
                {
                    yield return new SelectListItem
                    { Text = a.ArtistName + " " + a.AlbumName, Value = a.IdAlbum.ToString() };
                }
            }


        }

        public string Rate(string user)
        {

            AccessWcfService getUserId = new AccessWcfService("GetUserByName", "GET", user);
            string userJsonData = getUserId.GetJsonFromService();
            int idUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserContract>(userJsonData).IdUser;

            AccessWcfService getAlbumId = new AccessWcfService("GetAlbum", "GET", Album);
            string albumJsonData = getAlbumId.GetJsonFromService();
            int idAlbum = Newtonsoft.Json.JsonConvert.DeserializeObject<AlbumContract>(albumJsonData).IdAlbum;

            AccessWcfService serviceAddUser = new AccessWcfService("AddRating", "POST");
            RatingContract rating = new RatingContract { IdUser = idUser, IdAlbum = idAlbum, Rating = Int32.Parse(Rating) };
            string returnMessage = serviceAddUser.SendJsonToService(rating);

            return returnMessage;
        }

    }
}