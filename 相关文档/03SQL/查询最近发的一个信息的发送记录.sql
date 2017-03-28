select * from dbo.S_SMSRecord_Current as src
where src.SCID=(select top 1 sc.id from dbo.S_SMSContent as sc where sc.isMMS='false' order by ID desc)

select top 1 * from dbo.S_SMSContent as sc where sc.isMMS='false' order by ID desc