using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServiceReference;

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
            using (MusicServiceClient client = new MusicServiceClient())
            {
               var albums = client.GetAlbums();
                if (albums == null)
                {
                    yield return new SelectListItem { Text = "null", Value = "null" };
                }
                else
                {
                    foreach(AlbumContract a in albums)
                    {
                        yield return new SelectListItem
                        { Text = a.ArtistName + " " + a.AlbumName, Value = a.IdAlbum.ToString() };
                    }
                }
            }
        }

        public string Rate(string user)
        {
            using (MusicServiceClient client = new MusicServiceClient())
            {
                int id = client.GetUserByName(user).IdUser;
                return client.AddRating(id, Int32.Parse(Album), Int32.Parse(Rating));
            }
        }

    }
}