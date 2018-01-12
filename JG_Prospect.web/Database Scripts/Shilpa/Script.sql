USE [JGBS_Interview]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserAssignedDesigSequencnce]    Script Date: 12-Jan-18 9:18:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetUserAssignedDesigSequencnce]       
( -- Add the parameters for the stored procedure here      
 @DesignationId INT ,      
 @IsTechTask BIT,    
 @UserID  INT      
)      
AS      
BEGIN      
    
-- Check if already assigned sequence available to given user.    
    
--IF NOT EXISTS ( SELECT [Id] FROM tblAssignedSequencing WHERE UserId = @UserID)    
--BEGIN    
    
 
  IF(@DesignationId = 5 OR @DesignationId = 23)
  BEGIN

   INSERT INTO tblAssignedSequencing      
     (AssignedDesigSeq, UserId, IsTechTask, TaskId, CreatedDateTime, DesignationId,IsTemp)      
   SELECT  TOP 1 ISNULL([Sequence],1), @UserID, @IsTechTask , TaskId, GETDATE() , @DesignationId, 1 FROM tblTask       
   WHERE (AdminUserId IS NOT NULL AND TechLeadUserId IS NOT NULL ) AND [SequenceDesignationId] = @DesignationID 
   AND IsTechTask = @IsTechTask AND [Sequence] IS NOT NULL    
   and TaskId not in -- Added by Jitendra
	(Select Distinct S.TaskId From tbl_AnnualEvents E With(NoLock) -- Added by Jitendra
	Join tblAssignedSequencing S on E.ApplicantId = S.UserId -- Added by Jitendra
	Where E.EventDate >= CAST(GetDate() as date) -- Added by Jitendra
			And E.EventName = 'InterViewDetails' And E.IsInstallUser = 1)  -- Added by Jitendra    
   ORDER BY [Sequence] ASC       

  END
  ELSE
   BEGIN

    INSERT INTO tblAssignedSequencing      
           (AssignedDesigSeq, UserId, IsTechTask, TaskId, CreatedDateTime, DesignationId,IsTemp)      
    SELECT  TOP 1 ISNULL([Sequence],1), @UserID, @IsTechTask , TaskId, GETDATE() , @DesignationId, 1 FROM tblTask       
    WHERE (AdminUserId IS NOT NULL AND TechLeadUserId IS NOT NULL ) AND [SequenceDesignationId] = @DesignationID 
    AND IsTechTask = @IsTechTask AND [Sequence] IS NOT NULL AND [Sequence] > (         
      
      SELECT       ISNULL(MAX(AssignedDesigSeq),0) AS LastAssignedSequence      
       FROM            tblAssignedSequencing      
      WHERE        (DesignationId = @DesignationId) AND (IsTechTask = @IsTechTask)      
    And IsTemp = 1 -- Added by Jitendra
    )  and TaskId not in -- Added by Jitendra
	(Select Distinct S.TaskId From tbl_AnnualEvents E With(NoLock) -- Added by Jitendra
	Join tblAssignedSequencing S on E.ApplicantId = S.UserId -- Added by Jitendra
	Where E.EventDate >= CAST(GetDate() as date) -- Added by Jitendra
			And E.EventName = 'InterViewDetails' And E.IsInstallUser = 1)  -- Added by Jitendra    
    ORDER BY [Sequence] ASC       

   END
--END   

-- Get newly assigned sequence from inserted sequence / Already assigned sequence      
SELECT  Id,[AssignedDesigSeq] AS [AvailableSequence],TBA.TaskId, dbo.udf_GetParentTaskId(TBA.TaskId) AS ParentTaskId,       
(SELECT Title FROM tblTask WHERE TaskId =  dbo.udf_GetParentTaskId(TBA.TaskId)) AS ParentTitle , dbo.udf_GetCombineInstallId(TBA.TaskId) AS InstallId , T.Title       
      
FROM tblTask AS T       
      
INNER JOIN tblAssignedSequencing AS TBA ON TBA.TaskId = T.TaskId      
       
WHERE TBA.UserId = @UserId AND TBA.IsTemp = 1        

End