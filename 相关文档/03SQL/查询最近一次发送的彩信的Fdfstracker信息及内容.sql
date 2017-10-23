select * from dbo.FdfsContent as fdc 
select sc.ID from dbo.S_SMSContent as sc order by id desc 

select * from dbo.FdfsContent as fdc where fdc.ID=(
(select r.FCID from dbo.R_SMSContent_FdfsContent as r where r.CID=(select top 1 sc.ID from dbo.S_SMSContent as sc order by id desc )))

select top 1 * from dbo.FdfsContent as fdc
 left join R_SMSContent_FdfsContent as r on r.FCID=fdc.ID
 left join S_SMSContent as sc on sc.ID=r.CID
 order by sc.ID desc