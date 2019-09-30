using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebApplication.ServiceReference;
using WebApplication.WcfServiceReference;
using WebApplication.ServicesConnections;

namespace WebApplication.Models
{
    public class ModifyAlbumModel
    {
        public int Id { set; get; }
        public string NewAlbumName { set; get; }
        public string NewArtistName { set; get; }

        public string Modify()
        {
            AccessWcfService service = new AccessWcfService("ModifyAlbum", "PUT");
            AlbumContract album = new AlbumContract { IdAlbum = Id, AlbumName = NewAlbumName, ArtistName = NewArtistName };
            string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(album);

            string returnJson = service.SendJsonToService(inputJson);
            return returnJson;
        }

        public string Delete()
        {
            AccessWcfService service = new AccessWcfService("DeleteAlbum", "DELETE");
            string inputJson = Newtonsoft.Json.JsonConvert.SerializeObject(Id);
            string returnJson = service.SendJsonToService(inputJson);
            return returnJson;
        }

        public static IEnumerable<SelectListItem> ChooseAlbum()
        {
            AccessWcfService service = new AccessWcfService("GetAlbums", "GET");
            string json = service.GetJsonFromService();
            AlbumContract[] albums = Newtonsoft.Json.JsonConvert.DeserializeObject<AlbumContract[]>(json);

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
   