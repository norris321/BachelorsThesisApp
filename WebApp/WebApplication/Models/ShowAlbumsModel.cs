using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.ServicesConnections;
using WebApplication.WcfServiceReference;

namespace WebApplication.Models
{
    public class ShowAlbumsModel
    {
        public AlbumContract[] albums { set; get; }

        public ShowAlbumsModel()
        {
            try
            {
                AccessWcfService service = new AccessWcfService("GetAlbums", "GET");
                string json = service.GetJsonFromService();
                albums = Newtonsoft.Json.JsonConvert.DeserializeObject<AlbumContract[]>(json); 
            }
            catch(Exception e)
            {
                albums = null;
            }
                
        }
    }
}