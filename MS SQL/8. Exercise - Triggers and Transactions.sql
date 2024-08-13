USE [Bank]
GO

 --01.
CREATE TABLE [Logs] (
	[LogId] INT IDENTITY PRIMARY KEY, 
	[AccountId] INT, 
	[OldSum] MONEY, 
	[NewSum] MONEY
)

CREATE TRIGGER tr_NewEntryIntoLogs
ON [Accounts] 
FOR UPDATE
AS
 INSERT INTO [Logs]([AccountId], [OldSum], [NewSum])
 SELECT i.[Id], d.[Balance], i.[Balance]
 FROM inserted AS i
 JOIN deleted AS d ON i.Id = d.Id
 WHERE i.[Balance] <> d.[Balance] --02.CREATE TABLE [NotificationEmails] (
	[Id] INT IDENTITY PRIMARY KEY, 
	[Recipient] INT NOT NULL, 
	[Subject] NVARCHAR(200) NOT NULL, 
	[Body] NVARCHAR(1000) NOT NULL
)CREATE TRIGGER tr_EmailNotification
ON [Logs] 
FOR Insert
AS
 INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
 SELECT i.[AccountId]
	   ,CONCAT_WS(' ', 'Balance change for account:', i.[AccountId])
	   ,CONCAT_WS(' ', 'On', GETDATE(), 'your balance was changed for', i.OldSum, 'to', i.NewSum)
 FROM inserted AS iGO --03.CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(10, 4))ASBEGIN	IF @MoneyAmount > 0	BEGIN		UPDATE [Accounts]		SET [Balance] = [Balance] + @MoneyAmount		WHERE [Id] = @AccountId	ENDEND --04.CREATE OR ALTER PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(10, 4))ASBEGIN	IF @MoneyAmount > 0	BEGIN		UPDATE [Accounts]		SET [Balance] = [Balance] - @MoneyAmount		WHERE [Id] = @AccountId	ENDEND --05.CREATE OR ALTER PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(10, 4))ASBEGIN	IF @Amount > 0	BEGIN		EXEC usp_WithdrawMoney @SenderId, @Amount		EXEC usp_DepositMoneY @ReceiverId, @Amount	ENDEND