
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/23/2015 15:21:28
-- Generated from EDMX file: C:\Users\jorge\Source\Workspaces\ITPE3200\Nettbutikk\Nettbutikk\DAL\Nettbutikk.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Nettbutikk];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PasswordHash] nvarchar(max)  NOT NULL,
    [PasswordSalt] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [CategoryId] bigint  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [ParentCategory_Id] bigint  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [PlacementDateTime] datetime  NOT NULL,
    [CustomerId] bigint  NOT NULL
);
GO

-- Creating table 'OrderLines'
CREATE TABLE [dbo].[OrderLines] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [OrderId] bigint  NOT NULL,
    [Product_Id] bigint  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CustomerPrimaryShippingAddress_Address_Id] bigint  NOT NULL,
    [CustomerPrimaryBillingAddress_Address_Id] bigint  NOT NULL,
    [CustomerAddresses_Address_Id] bigint  NOT NULL
);
GO

-- Creating table 'Users_Customer'
CREATE TABLE [dbo].[Users_Customer] (
    [Phone] nvarchar(max)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Users_Administrator'
CREATE TABLE [dbo].[Users_Administrator] (
    [Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [PK_OrderLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Customer'
ALTER TABLE [dbo].[Users_Customer]
ADD CONSTRAINT [PK_Users_Customer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users_Administrator'
ALTER TABLE [dbo].[Users_Administrator]
ADD CONSTRAINT [PK_Users_Administrator]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ParentCategory_Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [FK_CategoryCategory]
    FOREIGN KEY ([ParentCategory_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryCategory'
CREATE INDEX [IX_FK_CategoryCategory]
ON [dbo].[Categories]
    ([ParentCategory_Id]);
GO

-- Creating foreign key on [CustomerPrimaryShippingAddress_Address_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_CustomerPrimaryShippingAddress]
    FOREIGN KEY ([CustomerPrimaryShippingAddress_Address_Id])
    REFERENCES [dbo].[Users_Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerPrimaryShippingAddress'
CREATE INDEX [IX_FK_CustomerPrimaryShippingAddress]
ON [dbo].[Addresses]
    ([CustomerPrimaryShippingAddress_Address_Id]);
GO

-- Creating foreign key on [CustomerPrimaryBillingAddress_Address_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_CustomerPrimaryBillingAddress]
    FOREIGN KEY ([CustomerPrimaryBillingAddress_Address_Id])
    REFERENCES [dbo].[Users_Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerPrimaryBillingAddress'
CREATE INDEX [IX_FK_CustomerPrimaryBillingAddress]
ON [dbo].[Addresses]
    ([CustomerPrimaryBillingAddress_Address_Id]);
GO

-- Creating foreign key on [CustomerAddresses_Address_Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_CustomerAddresses]
    FOREIGN KEY ([CustomerAddresses_Address_Id])
    REFERENCES [dbo].[Users_Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAddresses'
CREATE INDEX [IX_FK_CustomerAddresses]
ON [dbo].[Addresses]
    ([CustomerAddresses_Address_Id]);
GO

-- Creating foreign key on [OrderId] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [FK_OrderOrderLine]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderLine'
CREATE INDEX [IX_FK_OrderOrderLine]
ON [dbo].[OrderLines]
    ([OrderId]);
GO

-- Creating foreign key on [Product_Id] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [FK_OrderLineProduct]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderLineProduct'
CREATE INDEX [IX_FK_OrderLineProduct]
ON [dbo].[OrderLines]
    ([Product_Id]);
GO

-- Creating foreign key on [CategoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCategory'
CREATE INDEX [IX_FK_ProductCategory]
ON [dbo].[Products]
    ([CategoryId]);
GO

-- Creating foreign key on [CustomerId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Users_Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Orders]
    ([CustomerId]);
GO

-- Creating foreign key on [Id] in table 'Users_Customer'
ALTER TABLE [dbo].[Users_Customer]
ADD CONSTRAINT [FK_Customer_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Users_Administrator'
ALTER TABLE [dbo].[Users_Administrator]
ADD CONSTRAINT [FK_Administrator_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------