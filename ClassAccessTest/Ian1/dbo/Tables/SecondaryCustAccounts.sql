CREATE TABLE [dbo].[SecondaryCustAccounts] (
    [Id] NCHAR(10) NOT NULL, 
    [CustomerNo] NVARCHAR(12) NOT NULL, 
    [AccountType1] NVARCHAR (2)   CONSTRAINT [DF_SecondaryCustAccounts_AccountType1] DEFAULT ((1)) NOT NULL,
    [AccountNum1]  NVARCHAR (12)  NOT NULL,
    [AccountType2] NCHAR(10) NULL, 
    [AccountNum2] NCHAR(10) NULL, 
    [AccountType3] NCHAR(10) NULL, 
    [AccountNum3] NCHAR(10) NULL, 
    [AccountType4] NCHAR(10) NULL, 
    [AccountNum4] NCHAR(10) NULL, 
    CONSTRAINT [PK_SecondaryCustAccounts] PRIMARY KEY ([CustomerNo]) 
);

