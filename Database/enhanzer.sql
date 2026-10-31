-- Enhanzer assignment database (SQL Server)
-- Creates the Enhanzer database and the Location_Details, Purchase_Bill and Purchase_Bill_Item tables.
-- Generated from the EF Core migrations; run in SSMS or with:
--   sqlcmd -S "(localdb)\MSSQLLocalDB" -i Database/enhanzer.sql

IF DB_ID(N'Enhanzer') IS NULL
    CREATE DATABASE [Enhanzer];
GO

USE [Enhanzer];
GO

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
CREATE TABLE [Location_Details] (
    [Location_Code] varchar(20) NOT NULL,
    [Location_Name] nvarchar(100) NULL,
    [Stock_Handle] int NULL,
    [Address] nvarchar(max) NULL,
    [Phone] varchar(15) NULL,
    [Status] bit NULL,
    CONSTRAINT [PK_Location_Details] PRIMARY KEY ([Location_Code])
);

CREATE TABLE [Purchase_Bill] (
    [Id] int NOT NULL IDENTITY,
    [Created_At] datetime2 NOT NULL,
    [Created_By] varchar(100) NOT NULL,
    [Total_Items] int NOT NULL,
    [Total_Qty] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Purchase_Bill] PRIMARY KEY ([Id])
);

CREATE TABLE [Purchase_Bill_Item] (
    [Id] int NOT NULL IDENTITY,
    [Purchase_Bill_Id] int NOT NULL,
    [Item_Name] varchar(50) NOT NULL,
    [Batch_Code] varchar(20) NOT NULL,
    [Standard_Cost] decimal(18,2) NOT NULL,
    [Standard_Price] decimal(18,2) NOT NULL,
    [Margin] decimal(18,2) NOT NULL,
    [Qty] decimal(18,2) NOT NULL,
    [Free_Qty] decimal(18,2) NOT NULL,
    [Discount] decimal(5,2) NOT NULL,
    [Total_Cost] decimal(18,2) NOT NULL,
    [Total_Selling] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Purchase_Bill_Item] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Purchase_Bill_Item_Location_Details_Batch_Code] FOREIGN KEY ([Batch_Code]) REFERENCES [Location_Details] ([Location_Code]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Purchase_Bill_Item_Purchase_Bill_Purchase_Bill_Id] FOREIGN KEY ([Purchase_Bill_Id]) REFERENCES [Purchase_Bill] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Purchase_Bill_Item_Batch_Code] ON [Purchase_Bill_Item] ([Batch_Code]);

CREATE INDEX [IX_Purchase_Bill_Item_Purchase_Bill_Id] ON [Purchase_Bill_Item] ([Purchase_Bill_Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261031045613_InitialCreate', N'10.0.14');

COMMIT;
GO

