using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DataContracts
{
    [DataContract]
    public class AlbumContract : IAlbumContract
    {
        [DataMember]
        public int IdAlbum { set; get; }

        [DataMember]
        public string ArtistName { set; get; }

        [DataMember]
        public string AlbumName { set; get; }

        public AlbumContract(Album album)
        {
            if (album != null)
            {
                IdAlbum = album.IdAlbum;
                AlbumName = album.AlbumName;
                ArtistName = album.ArtistName;
            }
 
        }

        public AlbumContract()
        {
        }

        public Album ToAlbum()
        {
            Album album = new Album { AlbumName = AlbumName, ArtistName = ArtistName, IdAlbum = IdAlbum };

            return album;
        }
    }
}
