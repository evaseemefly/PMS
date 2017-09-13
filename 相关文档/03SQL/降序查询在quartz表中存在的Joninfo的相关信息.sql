Select * from dbo.QRTZ_JOB_DETAILS as q
left join dbo.J_JobInfo as j 
on q.JOB_NAME=j.JID
order by q.JOB_NAME desc

select * from dbo.J_JobInfo as j
order by j.JID desc