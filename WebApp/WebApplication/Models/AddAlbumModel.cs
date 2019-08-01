using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AddAlbumModel
    {
        public string NewArtistName { set; get; }
        public string NewAlbumName { set; get; }

        public string AddAlbum()
        {
            try
            {
                using(WebApplication.ServiceReference.MusicServiceClient client = new ServiceReference.MusicServiceClient())
                {
                    if (NewAlbumName != null && NewArtistName != null)
                        return client.AddAlbum(new ServiceReference.AlbumContract { ArtistName = NewArtistName, AlbumName = NewAlbumName });
                    else
                        return "Exception";
                }
            }
            catch(Exception e)
            {
                return "Exception";
            }
        }
    }
}