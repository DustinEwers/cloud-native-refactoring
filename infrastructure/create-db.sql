IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191112024831_InitialCreate')
BEGIN
    CREATE TABLE [Phrase] (
        [Id] int NOT NULL IDENTITY,
        [Text] nvarchar(max) NULL,
        CONSTRAINT [PK_Phrase] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191112024831_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191112024831_InitialCreate', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191112024917_AddData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Text') AND [object_id] = OBJECT_ID(N'[Phrase]'))
        SET IDENTITY_INSERT [Phrase] ON;
    INSERT INTO [Phrase] ([Id], [Text])
    VALUES (1, N'Ope'),
    (2, N'Where-Abouts'),
    (3, N'Spotted Cow'),
    (4, N'Brandy Old Fashioned'),
    (5, N'Stop-and-go-lights'),
    (6, N'Fleet Farm'),
    (7, N'Cheesehead'),
    (8, N'Fish Fry'),
    (9, N'Bubbler'),
    (10, N'Aw Geez'),
    (11, N'For Cripes Sakes'),
    (12, N'Up Nort'),
    (13, N'Uff-Da'),
    (14, N'Ya Know?'),
    (15, N'Believe You Me'),
    (16, N'You betcha');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Text') AND [object_id] = OBJECT_ID(N'[Phrase]'))
        SET IDENTITY_INSERT [Phrase] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191112024917_AddData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191112024917_AddData', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191112045226_AddCacheSchema')
BEGIN
    CREATE TABLE [DataCache] (
        [Id] nvarchar(449) NOT NULL,
        [Value] varbinary(max) NOT NULL,
        [ExpiresAtTime] datetimeoffset(7) NOT NULL,
        [SlidingExpirationInSeconds] bigint NULL,
        [AbsoluteExpiration] datetimeoffset(7) NULL,
        CONSTRAINT [PK_DataCache] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191112045226_AddCacheSchema')
BEGIN
    CREATE INDEX [Index_ExpiresAtTime] ON [DataCache] ([ExpiresAtTime]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191112045226_AddCacheSchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191112045226_AddCacheSchema', N'3.0.0');
END;

GO

