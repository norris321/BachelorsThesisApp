using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService.DataContracts
{
    [DataContract]
    public class AlbumContract
    {
        [DataMember]
        public int IdAlbum { set; get; }

        [DataMember]
        public string ArtistName { set; get; }

        [DataMember]
        public string AlbumName { set; get; }

        public AlbumContract(Album album)
        {
            IdAlbum = album.IdAlbum;
            ArtistName = album.ArtistName;
            AlbumName = album.AlbumName;
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
