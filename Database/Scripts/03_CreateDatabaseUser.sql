USE OPSAVER;
GO

CREATE USER [opsaver_app]
FOR LOGIN [opsaver_app];
GO

ALTER ROLE [db_datareader]
ADD MEMBER [opsaver_app];
GO

ALTER ROLE [db_datawriter]
ADD MEMBER [opsaver_app];
GO