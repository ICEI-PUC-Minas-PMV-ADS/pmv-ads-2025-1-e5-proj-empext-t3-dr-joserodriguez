IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Patients] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Address] nvarchar(200) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Complaint] nvarchar(500) NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250316135159_InitialCreate', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Patients] ADD [AppointmentDate] datetime2 NULL;
GO

ALTER TABLE [Patients] ADD [AppointmentTime] time NULL;
GO

ALTER TABLE [Patients] ADD [SpecialtiesString] nvarchar(max) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250322164455_AddAppointmentAndSpecialties', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patients]') AND [c].[name] = N'Complaint');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Patients] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Patients] ALTER COLUMN [Complaint] nvarchar(500) NULL;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250408225150_CreateUserTable', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Email], [Password])
VALUES (1, N'Consultoriodontovip@gmail.com', N'odontovipJR294');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250430014026_AddUserSeedData', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [NameUser] nvarchar(max) NULL;
GO

UPDATE [Users] SET [NameUser] = N'Dr.José Rodriguez'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250430035955_AddNameToUser', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250430234920_AddDentistaTable', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Dentistas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NOT NULL,
    [Cedula] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Dentistas] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cedula', N'Email', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Dentistas]'))
    SET IDENTITY_INSERT [Dentistas] ON;
INSERT INTO [Dentistas] ([Id], [Cedula], [Email], [Nome], [Telefone])
VALUES (1, N'123456', N'maria.silva@odontovip.com', N'Dr. Maria Silva', N'(11) 98765-4321');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cedula', N'Email', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[Dentistas]'))
    SET IDENTITY_INSERT [Dentistas] OFF;
GO

UPDATE [Users] SET [NameUser] = N'Dr. José Rodriguez'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250501000419_AddEnderecoToDentista', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250501071812_CriarTabelaAgendamentos', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250501093345_AdicionarEmailAoAgendamento', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Agendamentos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Especialidade] nvarchar(max) NOT NULL,
    [Data] datetime2 NOT NULL,
    [Hora] nvarchar(max) NOT NULL,
    [Mensagem] nvarchar(max) NOT NULL,
    [Confirmado] bit NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Agendamentos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250520082517_InitialCreate2', N'6.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250520083044_CorrigirMudancas', N'6.0.0');
GO

COMMIT;
GO

