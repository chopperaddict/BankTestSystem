CREATE TABLE [dbo].[BankAccount] (
    [Id] INT NOT NULL IDENTITY, 
    [BankACNo] NCHAR(20) NOT NULL,
    [CustACNo] NCHAR (20) NOT NULL,
    [AcType]  INT            NOT NULL,
    [Balance]      MONEY          NOT NULL,
    [OpenDate]     DATE           NOT NULL,
    [CloseDate]    DATE           NOT NULL,
    [Interest] NUMERIC (8, 4) NOT NULL,
    [Status]       INT            NOT NULL,
    CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED ([Id]), 
    CONSTRAINT [FK_CustACNumber] FOREIGN KEY ( [CustACNo] ) REFERENCES [dbo].[Customer] ([CustomerNo]) 
);

GO


CREATE UNIQUE INDEX [IX_BankACNo_Column] ON [dbo].[BankAccount] ([BankACNo])

GO
