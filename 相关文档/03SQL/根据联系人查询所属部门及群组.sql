select PID from dbo.P_PersonInfo as p
where p.PName='李强'

select * from dbo.P_Group as g
where g.GID=(select GID from dbo.R_Person_Group as r
where r.PID=(select PID from dbo.P_PersonInfo as p
where p.PName='李强'))

select * from dbo.P_DepartmentInfo as dd
where dd.DID=(
select r.DerpartmentID from dbo.R_Person_Department as r
where r.PersonID=(
select PID from dbo.P_PersonInfo as p
where p.PhoneNum='15210161270'))

select * from dbo.P_PersonInfo as p
where p.PhoneNum='15210161270'

