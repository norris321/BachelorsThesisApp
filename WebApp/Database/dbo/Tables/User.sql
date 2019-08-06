CREATE TABLE [dbo].[User] (
    [IdUser]   INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (30) NULL,
    [Password] VARCHAR (16)  NULL,
    [Rank]     VARCHAR (16)  NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([IdUser] ASC)
);

