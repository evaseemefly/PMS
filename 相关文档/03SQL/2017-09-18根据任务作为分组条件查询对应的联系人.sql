select u.*,s.* from dbo.S_SMSMission as s
left join dbo.R_UserInfo_SMSMission as r
 on s.SMID=r.SMID
left join dbo.UserInfo as u
 on r.UID=u.ID
where s.SMSMissionName='≤‚ ‘»ŒŒÒ' 

select * from  dbo.S_SMSMission as m
inner join dbo.P_DepartmentInfo as d
inner join R_Department_Mission as dm
on dm.DepartmentID=d.DID
on dm.MissionID=m.SMID
inner join dbo.R_Person_Department as pd
on pd.DerpartmentID=d.DID
inner join dbo.P_PersonInfo as p
on pd.PersonID=p.PID
group by m.SMID

select *,SUM(P.PID) from dbo.P_PersonInfo AS P
INNER JOIN DBO.R_Person_Department AS PD 
ON P.PID=PD.PersonID
INNER JOIN DBO.P_DepartmentInfo AS D
ON PD.DerpartmentID=D.DID
INNER JOIN DBO.R_Department_Mission AS DM
ON DM.DepartmentID=D.DID
INNER JOIN DBO.S_SMSMission AS M
ON DM.MissionID=M.SMID
GROUP BY M.SMID

select P.PID,P.PName,P.PhoneNum,M.SMID,M.SMSMissionName from dbo.P_PersonInfo AS P
INNER JOIN DBO.R_Person_Department AS PD 
ON P.PID=PD.PersonID
INNER JOIN DBO.P_DepartmentInfo AS D
ON PD.DerpartmentID=D.DID
INNER JOIN DBO.R_Department_Mission AS DM
ON DM.DepartmentID=D.DID
INNER JOIN DBO.S_SMSMission AS M
ON DM.MissionID=M.SMID
GROUP BY M.SMID

SELECT U.SMSMissionName,COUNT(U.PID)
FROM(select P.PID,P.PName,P.PhoneNum,M.SMID,M.SMSMissionName from dbo.P_PersonInfo AS P
INNER JOIN DBO.R_Person_Department AS PD 
ON P.PID=PD.PersonID
INNER JOIN DBO.P_DepartmentInfo AS D
ON PD.DerpartmentID=D.DID
INNER JOIN DBO.R_Department_Mission AS DM
ON DM.DepartmentID=D.DID
INNER JOIN DBO.S_SMSMission AS M
ON DM.MissionID=M.SMID) AS U
GROUP BY U.SMID,U.SMSMissionName

select COUNT(P.PID)
 from dbo.P_PersonInfo AS P
INNER JOIN DBO.R_Person_Department AS PD 
ON P.PID=PD.PersonID
INNER JOIN DBO.P_DepartmentInfo AS D
ON PD.DerpartmentID=D.DID
INNER JOIN DBO.R_Department_Mission AS DM
ON DM.DepartmentID=D.DID
INNER JOIN DBO.S_SMSMission AS M
ON DM.MissionID=M.SMID
GROUP BY M.SMID

WHERE SMID=2

on p.PID=pd.PersonID


join dbo.P_Group as g
join R_Group_Mission as gm
join dbo.R_Person_Group as pg

dbo.P_PersonInfo as p
