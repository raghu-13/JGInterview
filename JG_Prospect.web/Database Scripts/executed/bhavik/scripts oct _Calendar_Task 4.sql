USE [JGBS]
GO
/****** Object:  StoredProcedure [dbo].[GetHRCalendar]    Script Date: 10/29/2016 12:14:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[GetHRCalendar]
	-- Add the parameters for the stored procedure here
	@Year varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT 
	--	a.ID,( a.EventName + '  '+u.Username + ' '+i.FristName+  '  ' + i.Phone +'   '+i.Designation) as EventName,
	--	EventDate = CONVERT(Varchar(50),EventDate)+' '+ CONVERT(varchar(50),InterviewTime),a.EventAddedBy,a.ApplicantId,u.Username,i.FristName,i.LastName,i.Phone
	--FROM 
	--	dbo.tbl_AnnualEvents a 
	--		INNER JOIN  dbo.tblUsers u ON u.Id = a.EventAddedBy LEFT JOIN dbo.tblInstallUsers i ON i.Id = a.ApplicantId
	--WHERE 
	--	a.EventName='InterViewDetails' AND 
	--	DATEPART(yyyy,EventDate)=@Year

	SELECT 
		a.ID,( a.EventName + '  '+u.Username + ' '+i.Designation+  '  ' + i.Phone +'   '+i.FristName) as EventName,
		EventDate = CONVERT(datetime,EventDate) + CONVERT(datetime,InterviewTime),a.EventAddedBy,a.ApplicantId,u.Username,i.FristName,i.LastName,i.Phone,i.Id,
		i.Status, i.Designation, i.Email, TaskAss.TaskId , ISNULL(tTask.InstallId,'') AS InstallId,
		STUFF
		(
			(SELECT  CAST(', ' + u.FristName as VARCHAR) AS Name
			FROM tbl_AnnualEventAssignedUsers tu
				INNER JOIN tblInstallUsers u ON tu.UserId = u.Id
			WHERE tu.EventId = a.Id
			FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)')
			,1
			,2
			,' '
		) AS AssignedUserFristNames
	FROM 
		tbl_AnnualEvents a 
		OUTER APPLY 
		(
			SELECT TOP 1 Id, Username, FirstName AS FristName
			FROM tblUsers
			WHERE tblUsers.id = a.EventAddedBy AND ISNULL(a.IsInstallUser,0) = 0

			UNION

			SELECT TOP 1  Id, Email AS Username, FristName
			FROM tblInstallUsers
			WHERE tblInstallUsers.id = a.EventAddedBy AND ISNULL(a.IsInstallUser,1) = 1
		) u --INNER JOIN  tblUsers u ON u.Id = a.EventAddedBy 
		LEFT JOIN tblInstallUsers i ON i.Id = a.ApplicantId
		LEFT JOIN tblTaskAssignedUsers TaskAss ON TaskAss.UserId = i.Id
		LEFT JOIN tblTask tTask ON tTask.TaskId = TaskAss.TaskId
	WHERE 
		a.EventName='InterViewDetails' AND 
		DATEPART(yyyy,EventDate)=@Year

END




/****** Object:  StoredProcedure [dbo].[GetAllAnnualEvent]    Script Date: 10/29/2016 12:13:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetAllAnnualEvent] 
	-- Add the parameters for the stored procedure here
	@Year varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--select a.ID,a.EventName,a.EventDate,a.EventAddedBy,a.ApplicantId,u.Username,i.FristName,i.LastName,i.Phone
	--from tbl_AnnualEvents a INNER JOIN  tblUsers u ON u.Id = a.EventAddedBy LEFT JOIN tblInstallUsers i ON i.Id = a.ApplicantId
	--where DATEPART(yyyy,EventDate)=@Year

	SELECT 
		a.ID,a.EventName,a.EventDate,a.EventAddedBy,a.ApplicantId,u.Username,i.FristName,i.LastName,i.Phone,i.Id,
		i.Status, i.Designation, i.Email, TaskAss.TaskId , ISNULL(tTask.InstallId,'') AS InstallId ,
		STUFF
		(
			(SELECT  CAST(', ' + u.FristName as VARCHAR) AS Name
			FROM tbl_AnnualEventAssignedUsers tu
				INNER JOIN tblInstallUsers u ON tu.UserId = u.Id
			WHERE tu.EventId = a.Id
			FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)')
			,1
			,2
			,' '
		) AS AssignedUserFristNames
	FROM 
		tbl_AnnualEvents a 
		OUTER APPLY 
		(
			SELECT TOP 1 Id, Username, FirstName AS FristName
			FROM tblUsers
			WHERE tblUsers.id = a.EventAddedBy AND ISNULL(a.IsInstallUser,0) = 0

			UNION

			SELECT TOP 1  Id, Email AS Username, FristName
			FROM tblInstallUsers
			WHERE tblInstallUsers.id = a.EventAddedBy AND ISNULL(a.IsInstallUser,1) = 1
		) u --INNER JOIN  tblUsers u ON u.Id = a.EventAddedBy 
		LEFT JOIN tblInstallUsers i ON i.Id = a.ApplicantId 
		LEFT JOIN tblTaskAssignedUsers TaskAss ON TaskAss.UserId = i.Id
		LEFT JOIN tblTask tTask ON tTask.TaskId = TaskAss.TaskId
	WHERE 
		a.EventName IS NOT NULL AND 
		a.EventName !='InterViewDetails' AND 
		DATEPART(yyyy,EventDate)=@Year
	
	UNION 

	SELECT 
		a.ID,( a.EventName + '  '+u.Username + ' '+i.Designation+  '  ' + i.Phone +'   '+i.FristName) as EventName,
		EventDate = CONVERT(datetime,EventDate) + CONVERT(datetime,InterviewTime),a.EventAddedBy,a.ApplicantId,u.Username,i.FristName,i.LastName,i.Phone,i.Id,
		i.Status, i.Designation, i.Email, TaskAss.TaskId , ISNULL(tTask.InstallId,'') AS InstallId,
		STUFF
		(
			(SELECT  CAST(', ' + u.FristName as VARCHAR) AS Name
			FROM tbl_AnnualEventAssignedUsers tu
				INNER JOIN tblInstallUsers u ON tu.UserId = u.Id
			WHERE tu.EventId = a.Id
			FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)')
			,1
			,2
			,' '
		) AS AssignedUserFristNames
	FROM 
		tbl_AnnualEvents a 
		OUTER APPLY 
		(
			SELECT TOP 1 Id, Username, FirstName AS FristName
			FROM tblUsers
			WHERE tblUsers.id = a.EventAddedBy AND ISNULL(a.IsInstallUser,0) = 0

			UNION

			SELECT TOP 1  Id, Email AS Username, FristName
			FROM tblInstallUsers
			WHERE tblInstallUsers.id = a.EventAddedBy AND ISNULL(a.IsInstallUser,1) = 1
		) u --INNER JOIN  tblUsers u ON u.Id = a.EventAddedBy 
		LEFT JOIN tblInstallUsers i ON i.Id = a.ApplicantId
		LEFT JOIN tblTaskAssignedUsers TaskAss ON TaskAss.UserId = i.Id
		LEFT JOIN tblTask tTask ON tTask.TaskId = TaskAss.TaskId
	WHERE 
		a.EventName='InterViewDetails' AND 
		DATEPART(yyyy,EventDate)=@Year

END

