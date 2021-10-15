CREATE TABLE [dbo].[cidade] (
    [Id]     INT           NOT NULL IDENTITY,
    [Nome]   VARCHAR (100) NOT NULL,
    [Estado] VARCHAR (60)  NOT NULL,
    CONSTRAINT [PK_CIDADE] PRIMARY KEY CLUSTERED ([Id] ASC)
);

