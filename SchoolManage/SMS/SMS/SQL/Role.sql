/*
   20 January 202100:55:50
   User: 
   Server: LAPTOP-RO63EGQ0
   Database: SMS
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Role
	(
	RoleId int NOT NULL,
	Descr varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Role ADD CONSTRAINT
	PK_Table_1 PRIMARY KEY CLUSTERED 
	(
	RoleId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Role SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
