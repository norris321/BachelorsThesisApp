using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.ServiceReference;

namespace WebApplication.Models
{
    public class ShowAlbumsModel
    {
        public AlbumContract[] albums { set; get; }

        public ShowAlbumsModel()
        {
            try
            {
                using (ServiceReference.MusicServiceClient client = new MusicServiceClient())
                {
                    albums = client.GetAlbums();
                }
            }
            catch(Exception e)
            {
                albums = null;
            }
                
        }
    }
}