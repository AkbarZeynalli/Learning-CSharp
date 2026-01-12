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

CREATE TABLE [Restaurants] (
    [ID] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [Latitude] float NOT NULL,
    [Longitude] float NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [OpeningTime] time NOT NULL,
    [ClosingTime] time NOT NULL,
    [LogoUrl] nvarchar(max) NULL,
    [IsActive] bit NOT NULL,
    [AverageRating] decimal(18,2) NOT NULL,
    [TotalReviews] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Restaurants] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [Users] (
    [ID] int NOT NULL IDENTITY,
    [FullName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NOT NULL,
    [PhoneNumber] nvarchar(max) NOT NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [Address] nvarchar(max) NULL,
    [RegisteredAt] datetime2 NOT NULL,
    [LastLoginAt] datetime2 NULL,
    [IsActive] bit NOT NULL,
    [EmailConfirmed] bit NOT NULL,
    [TotalReservations] int NOT NULL,
    [CompletedReservations] int NOT NULL,
    [CancelledReservations] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [FoodItems] (
    [ID] int NOT NULL IDENTITY,
    [RestaurantId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [OriginalPrice] decimal(18,2) NOT NULL,
    [DiscountedPrice] decimal(18,2) NOT NULL,
    [DiscountPercentage] int NOT NULL,
    [AvailableQuantity] int NOT NULL,
    [ExpiryDate] datetime2 NOT NULL,
    [Category] int NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [IsAvailable] bit NOT NULL,
    [AllergenInfo] nvarchar(max) NULL,
    [ViewCount] int NOT NULL,
    [ReservationCount] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_FoodItems] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_FoodItems_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reviews] (
    [ID] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [RestaurantId] int NOT NULL,
    [Rating] int NOT NULL,
    [Comment] nvarchar(max) NULL,
    [IsVerified] bit NOT NULL,
    [HelpfulCount] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Reviews_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reservations] (
    [ID] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [FoodItemId] int NOT NULL,
    [Quantity] int NOT NULL,
    [TotalPrice] decimal(18,2) NOT NULL,
    [ReservationTime] datetime2 NOT NULL,
    [PickupTime] datetime2 NOT NULL,
    [ActualPickupTime] datetime2 NULL,
    [Status] int NOT NULL,
    [CancellationReason] nvarchar(max) NULL,
    [Notes] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Reservations_FoodItems_FoodItemId] FOREIGN KEY ([FoodItemId]) REFERENCES [FoodItems] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reservations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_FoodItems_RestaurantId] ON [FoodItems] ([RestaurantId]);
GO

CREATE INDEX [IX_Reservations_FoodItemId] ON [Reservations] ([FoodItemId]);
GO

CREATE INDEX [IX_Reservations_UserId] ON [Reservations] ([UserId]);
GO

CREATE INDEX [IX_Reviews_RestaurantId] ON [Reviews] ([RestaurantId]);
GO

CREATE INDEX [IX_Reviews_UserId] ON [Reviews] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260112131127_InitialCreate', N'8.0.22');
GO

COMMIT;
GO

