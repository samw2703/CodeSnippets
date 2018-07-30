CREATE DATABASE [SnippetsTest]
GO

USE [SnippetsTest]
GO


CREATE TABLE [Languages] (
	[Id] int IDENTITY(1, 1) NOT NULL,
	[Value] varchar(max) NOT NULL
)

ALTER TABLE [Languages]
ADD CONSTRAINT PK_Languages PRIMARY KEY (Id);

CREATE TABLE [Snippets] (
	[Id] int IDENTITY(1, 1) NOT NULL,
	[Key] varchar(max) NOT NULL,
	[Value] varchar(max) NOT NULL,
	[UsedCount] int NOT NULL,
	[LanguageId] int NOT NULL
)

ALTER TABLE [Snippets]
ADD CONSTRAINT PK_Snippet PRIMARY KEY (Id);

ALTER TABLE [Snippets]
ADD CONSTRAINT FK_SnippetLanguageId
FOREIGN KEY (LanguageId) REFERENCES Languages(Id);