using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication.ServicesConnections;
using WebApplication.WcfServiceReference;

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
                AccessWcfService service = new AccessWcfService("AddAlbum", "POST");
                var album = new AlbumContract { ArtistName = NewArtistName, AlbumName = NewAlbumName };
                string returnMessage = service.SendJsonToService(album);
                return returnMessage;
            }
            catch(Exception e)
            {
                return "Error: No database connection";
            }
        }
    }
}