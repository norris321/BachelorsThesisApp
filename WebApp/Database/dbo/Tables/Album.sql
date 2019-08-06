CREATE TABLE [dbo].[Album] (
    [IdAlbum]    INT           IDENTITY (1, 1) NOT NULL,
    [ArtistName] NVARCHAR (30) NULL,
    [AlbumName]  NVARCHAR (30) NULL,
    CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED ([IdAlbum] ASC)
);

