using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServiceReference;

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
            using (MusicServiceClient client = new MusicServiceClient())
            {
                var userInfo = client.GetUserByName(user);
                if (userInfo == null)
                {
                    throw new CustomExceptions.NoUserFoundException("No user with that username exist in database");
                }

                if (userInfo.IdUser == 0)
                {
                    throw new CustomExceptions.NoUserFoundException("No user with that username exist in database");
                }

                CurrentUserId = userInfo.IdUser;
            }
        }

        public static IEnumerable<SelectListItem> SelectRatedAlbum(int currentUserId)
        {
            using (MusicServiceClient client = new MusicServiceClient())
            {
                var ratings = client.GetRatingsForUser(currentUserId);
                if (ratings == null)
                {
                    yield return new SelectListItem { Text = "null", Value = "null" };
                }
                else
                {
                    foreach (RatingContract r in ratings)
                    {
                        yield return new SelectListItem
                        { Text = r.ArtistName + " " + r.AlbumName + " "+ r.Rating.ToString(), Value = r.IdRating.ToString() };
                    }
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
            if (string.IsNullOrEmpty(ID_rating))
                return "";

                using (MusicServiceClient client = new MusicServiceClient())
                {
                    return client.ModifyRating(Int32.Parse(ID_rating), Int32.Parse(NewRating));
                }
        }

        public string DeleteRating()
        {
            if (string.IsNullOrEmpty(ID_rating))
                return "";

            using (MusicServiceClient client = new MusicServiceClient())
            {
                return client.DeleteRating(Int32.Parse(ID_rating));
            }
        }
    }
}