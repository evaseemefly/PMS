select * from SMS_NMEFC.dbo.S_SMSMission as sm 
where R_Group_Mission as r

select sm.SMID,sm.SMSMissionName,g.GID,g.GroupName from S_SMSMission as sm ,P_Group as g,R_Group_Mission as r
where sm.SMID=r.MissionID and g.GID=r.GroupID