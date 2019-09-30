
namespace WcfService.DataContracts
{

    public interface IAlbumContract
    {
        string AlbumName { get; set; }
        string ArtistName { get; set; }
        int IdAlbum { get; set; }

        Album ToAlbum();
    }
}