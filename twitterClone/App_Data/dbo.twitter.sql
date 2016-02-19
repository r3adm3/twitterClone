CREATE TABLE [dbo].[tweets] (
    [Id]                  INT            NOT NULL IDENTITY,
    [status]              NVARCHAR (255) NOT NULL,
    [detailedDescription] NVARCHAR (MAX) NOT NULL,
    [userPosted]          NVARCHAR (50)  NOT NULL,
    [postedDateTime]      DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

