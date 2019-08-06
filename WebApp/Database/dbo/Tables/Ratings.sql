CREATE TABLE [dbo].[Ratings] (
    [IdRating] INT IDENTITY (1, 1) NOT NULL,
    [IdUser]   INT NOT NULL,
    [IdAlbum]  INT NOT NULL,
    [Rating]   INT NULL,
    CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED ([IdRating] ASC),
    CONSTRAINT [FK_Ratings_Album] FOREIGN KEY ([IdAlbum]) REFERENCES [dbo].[Album] ([IdAlbum]),
    CONSTRAINT [FK_Ratings_User] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([IdUser])
);

