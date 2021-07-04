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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507190812_DhomeMigration')
BEGIN
    CREATE TABLE [appointment] (
        [AppointmentId] int NOT NULL IDENTITY,
        [idCustomer] int NOT NULL,
        [idEmployee] int NOT NULL,
        [description] varchar(200) NOT NULL,
        [appointmentDate] varchar(max) NOT NULL,
        [address] varchar(200) NOT NULL,
        [valorization] int NOT NULL,
        [status] varchar(max) NOT NULL,
        [idPaymentMethod] int NOT NULL,
        CONSTRAINT [PK_appointment] PRIMARY KEY ([AppointmentId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507190812_DhomeMigration')
BEGIN
    CREATE TABLE [Customer] (
        [CustomerId] int NOT NULL IDENTITY,
        [Firstname] varchar(50) NOT NULL,
        [Lastname] varchar(50) NOT NULL,
        [Dni] varchar(8) NOT NULL,
        [Email] varchar(max) NOT NULL,
        [idCity] int NOT NULL,
        [idAccount] int NOT NULL,
        [Cellphone] int NOT NULL,
        [idDistrict] int NOT NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([CustomerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507190812_DhomeMigration')
BEGIN
    CREATE TABLE [Employee] (
        [EmployeeId] int NOT NULL IDENTITY,
        [Firstname] varchar(max) NOT NULL,
        [Lastname] varchar(max) NOT NULL,
        [Dni] varchar(8) NOT NULL,
        [Email] varchar(max) NOT NULL,
        [idCity] int NOT NULL,
        [Description] varchar(max) NOT NULL,
        [Cellphone] int NOT NULL,
        [idSpecialty] int NOT NULL,
        [idDistrict] int NOT NULL,
        [idAccount] int NOT NULL,
        CONSTRAINT [PK_Employee] PRIMARY KEY ([EmployeeId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210507190812_DhomeMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210507190812_DhomeMigration', N'5.0.4');
END;
GO

COMMIT;
GO

