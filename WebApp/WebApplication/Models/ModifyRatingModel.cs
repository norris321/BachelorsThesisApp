using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServicesConnections;
using WebApplication.WcfServiceReference;

namespace WebApplication.Models
{
    public class ModifyRatingModel
    {
        public string ID_rating { set; get; }
        public string NewRating { set; get; }
        public int CurrentUserId{ get;}

        public ModifyRatingModel()
        {

        }

        public ModifyRatingModel(string user)
        {
            AccessWcfService service = new AccessWcfService("GetUserByName", "GET", user);
            string returnJson = service.GetJsonFromService();
            UserContract userInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<UserContract>(returnJson);

            if(userInfo == null || userInfo.IdUser == 0)
            {
                throw new CustomExceptions.NoUserFoundException("No user with that username exist in database");
            }

            CurrentUserId = userInfo.IdUser;
            
        }

        public static IEnumerable<SelectListItem> SelectRatedAlbum(int currentUserId)
        {
            AccessWcfService service = new AccessWcfService("GetRatingsForUser", "GET", currentUserId.ToString());
            string returnJson = service.GetJsonFromService();
            RatingContract[] ratings = Newtonsoft.Json.JsonConvert.DeserializeObject<RatingContract[]>(returnJson);

            if (ratings == null)
            {
                yield return new SelectListItem { Text = "null", Value = "null" };
            }
            else
            {
                foreach (RatingContract r in ratings)
                {
                    yield return new SelectListItem
                    { Text = r.ArtistName + " " + r.AlbumName + " " + r.Rating.ToString(), Value = r.IdRating.ToString() };
                }
            }
        }

        public static IEnumerable<SelectListItem> RateAlbum()
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return new SelectListItem { Text = i.ToString(), Value = i.ToString() };
            }
        }

        public string ModifyRating()
        {
            if (ID_rating == "null")
                return "";

            AccessWcfService service = new AccessWcfService("ModifyRating", "PUT");
            RatingContract rating = new RatingContract { IdRating = Int32.Parse(ID_rating), Rating = Int32.Parse(NewRating) };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(rating);

            return service.SendJsonToService(json);

        }

        public string DeleteRating()
        {
            if (ID_rating == "null")
                return "";

            AccessWcfService service = new AccessWcfService("DeleteRating", "DELETE");
            int id = Int32.Parse(ID_rating);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(id);

            return service.SendJsonToService(json);
        }
    }
}