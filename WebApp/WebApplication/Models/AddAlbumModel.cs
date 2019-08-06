using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AddAlbumModel
    {
        [Required]
        [MaxLength(30)]
        public string NewArtistName { set; get; }

        [Required]
        [MaxLength(30)]
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