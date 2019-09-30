namespace WcfService.DataContracts
{
    public interface IRatingContract
    {
        string AlbumName { get; set; }
        string ArtistName { get; set; }
        int IdAlbum { get; set; }
        int IdRating { get; set; }
        int IdUser { get; set; }
        int? Rating { get; set; }

        Rating ToRating();
    }
}