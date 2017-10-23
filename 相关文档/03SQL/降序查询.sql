select * from SMS_NMEFC.dbo.S_SMSRecord_Current as sn
order by sn.SRID desc
select * from S_SMSContent as sc
order by sc.ID desc

select * from S_SMSContent as sc
where sc.ID='7274'