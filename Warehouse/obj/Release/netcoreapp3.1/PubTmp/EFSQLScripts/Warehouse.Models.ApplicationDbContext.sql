IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE TABLE [Positions] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Salary] int NOT NULL,
        [Responsibility] nvarchar(max) NULL,
        [Requirements] nvarchar(max) NULL,
        CONSTRAINT [PK_Positions] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE TABLE [Suppliers] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        CONSTRAINT [PK_Suppliers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE TABLE [TypeOfProducts] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_TypeOfProducts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE TABLE [Employees] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Age] int NOT NULL,
        [Gender] nvarchar(max) NULL,
        [Address] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [PassportData] nvarchar(max) NULL,
        [PositionId] int NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Employees_Positions_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [Positions] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Manufacturer] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [StorageConditions] nvarchar(max) NULL,
        [Pack] nvarchar(max) NULL,
        [ExpirationDate] datetime2 NOT NULL,
        [TypeOfProductId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_TypeOfProducts_TypeOfProductId] FOREIGN KEY ([TypeOfProductId]) REFERENCES [TypeOfProducts] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE TABLE [Storages] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [ReceiptDate] datetime2 NOT NULL,
        [SupplierId] int NOT NULL,
        [OrderDate] datetime2 NOT NULL,
        [CustomerId] int NOT NULL,
        [DepartureDate] datetime2 NOT NULL,
        [DeliveryMethod] nvarchar(max) NULL,
        [Volume] nvarchar(max) NULL,
        [Price] int NOT NULL,
        CONSTRAINT [PK_Storages] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Storages_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Storages_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Storages_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Suppliers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE INDEX [IX_Employees_PositionId] ON [Employees] ([PositionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE INDEX [IX_Products_TypeOfProductId] ON [Products] ([TypeOfProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE INDEX [IX_Storages_CustomerId] ON [Storages] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE INDEX [IX_Storages_ProductId] ON [Storages] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    CREATE INDEX [IX_Storages_SupplierId] ON [Storages] ([SupplierId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200306165942_initial migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200306165942_initial migration', N'3.1.2');
END;

GO

