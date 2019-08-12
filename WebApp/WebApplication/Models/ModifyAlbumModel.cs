using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ServiceReference;

namespace WebApplication.Models
{
    public class ModifyAlbumModel
    {
        public int Id { set; get; }
        public string NewAlbumName { set; get; }
        public string NewArtistName { set; get; }

        public string Modify()
        {
            using (MusicServiceClient client = new MusicServiceClient())
            {
                return client.ModyifyAlbum(Id,NewArtistName,NewAlbumName);
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
                    foreach (AlbumContract a in albums)
                    {
                        yield return new SelectListItem
                        { Text = a.ArtistName + " " + a.AlbumName, Value = a.IdAlbum.ToString() };
                    }
                }
            }
        }
    }
}
   