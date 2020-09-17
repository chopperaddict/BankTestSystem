CREATE TABLE [dbo].[Customer] (
    [Id] INT NOT NULL IDENTITY, 
    [CustomerNo]   NCHAR(20) NOT NULL,
    [FirstName]    NVARCHAR(200) NOT NULL,
    [LastName]     NVARCHAR(200) NOT NULL,
    [Address1]     NVARCHAR(200) NOT NULL,
    [Address2]     NVARCHAR(200) NULL,
    [Town]         NVARCHAR(200) NOT NULL,
    [County]       NVARCHAR(200) NOT NULL,
    [Postcode]     NVARCHAR(50) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    [MobileNumber] NVARCHAR(20) NOT NULL, 
    [DOB] DATE NOT NULL DEFAULT getdate(), 
    [FileName]     NVARCHAR(200) NOT NULL,
    [FullFileName] NVARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerNo] ASC), 
);

