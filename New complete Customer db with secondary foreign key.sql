CREATE TABLE [dbo].[Customer] (
    [Id]           INT            NOT NULL,
    [CustomerNo]   NUMERIC (12)   NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [Address1]     NVARCHAR (100) NOT NULL,
    [Address2]     NVARCHAR (100) NULL,
    [Town]         NVARCHAR (100) NOT NULL,
    [County]       NVARCHAR (100) NOT NULL,
    [Postcode]     NVARCHAR (20)  NOT NULL,
    [FileName]     NVARCHAR (50)  NOT NULL,
    [FullFileName] NVARCHAR (300) NOT NULL,
    [SecAccounts]  NUMERIC (12)   IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY (CUSTOMERNO),
    CONSTRAINT  PK_SecondaryCustAccounts FOREIGN KEY (SecAccounts)  REFERENCES AccountNum
);
