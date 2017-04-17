select * from dbo.R_Department_Mission as r 
join dbo.S_SMSMission as m on r.MissionID=m.SMID
join dbo.P_DepartmentInfo as d on r.DepartmentID=d.DID
where m.SMSMissionName='аидЧ╡Бйт'

DELETE from dbo.R_Department_Mission as r 
join dbo.S_SMSMission as m on r.MissionID=m.SMID
join dbo.P_DepartmentInfo as d on r.DepartmentID=d.DID
where m.SMSMissionName='аидЧ╡Бйт'
SELECT * FROM DBO.R_Department_Mission WHERE MissionID='27'

DELETE FROM DBO.R_Department_Mission WHERE MissionID='27'
