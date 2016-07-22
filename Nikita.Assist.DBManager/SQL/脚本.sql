CREATE TABLE [Bse_DataDictionary]
(
  [id] INT IDENTITY(1,1)  NOT NULL,
  [ServerName] VARCHAR (100),
  [DatabaseName] VARCHAR (50),
  [TableName] VARCHAR (50),
  [TableHistoryName] VARCHAR (50),
  [TableRemark] VARCHAR (50),
  [ColumnName] VARCHAR (50),
  [ColumnIdentity] VARCHAR (50),
  [ColumnPK] VARCHAR (50),
  [ColumnType] VARCHAR (50),
  [ColumnSpace] VARCHAR (50),
  [ColumnLength] VARCHAR (50),
  [ColumnScale] VARCHAR (50),
  [ColumnAllowNull] VARCHAR (50),
  [ColumnDefaultValue] VARCHAR (50),
  [ColumnRemark] VARCHAR (150),
  [ColumnHistory] VARCHAR (50),
  [DbType] VARCHAR (50),
  [OperationType] VARCHAR (50),
  [CreateUser] VARCHAR (50),
  [CreateTime] DATETIME  DEFAULT (current_timestamp),
  [LastEditUser] VARCHAR (50),
  [LastEditTime] DATETIME,
  [Status] TINYINT  DEFAULT 1
);


CREATE UNIQUE INDEX [PK_test2] ON [Bse_DataDictionary]([id]);



CREATE TABLE [Bse_ExcuteAnalyze]
(
  [id] INT IDENTITY(1,1)  NOT NULL,
  [ExcuteName] VARCHAR (50),
  [ExcuteSql] VARCHAR (8000),
  [ExcuteType] VARCHAR (50),
  [DbType] VARCHAR (50),
  [Remark] VARCHAR (500)  NOT NULL DEFAULT (''),
  [CreateDate] DATETIME  NOT NULL DEFAULT (current_timestamp)
);


CREATE UNIQUE INDEX [PK_Bse_ExcuteAnalyze] ON [Bse_ExcuteAnalyze]([id]);


SET IDENTITY_INSERT [Bse_ExcuteAnalyze] ON
GO
INSERT INTO [Bse_ExcuteAnalyze] (
  [id],  [ExcuteName],  [ExcuteSql],  [ExcuteType],  [DbType],  [Remark],  [CreateDate]) VALUES (
5 ,N'²éÑ¯SQL×èÈû' ,N'SELECT SPID=p.spid,
       DBName = convert(CHAR(20),d.name),
       ProgramName = program_name,
       LoginName = convert(CHAR(20),l.name),
       HostName = convert(CHAR(20),hostname),
       Status = p.status,
       BlockedBy = p.blocked,
       LoginTime = login_time,
       QUERY = CAST(TEXT AS VARCHAR(MAX))
FROM   MASTER.dbo.sysprocesses p
       INNER JOIN MASTER.dbo.sysdatabases d
         ON p.dbid = d.dbid
       INNER JOIN MASTER.dbo.syslogins l
         ON p.sid = l.sid
       CROSS APPLY sys.dm_exec_sql_text(sql_handle)
WHERE  p.blocked = 0
       AND EXISTS (SELECT 1
                   FROM   MASTER..sysprocesses p1
                   WHERE  p1.blocked = p.spid)' ,N'SQLÓï¾ä' ,N'SqlServer' ,N'' ,'2015-12-12T15:24:41.523'
);

SET IDENTITY_INSERT [Bse_ExcuteAnalyze] OFF
GO
DBCC CHECKIDENT ([Bse_ExcuteAnalyze])
GO
