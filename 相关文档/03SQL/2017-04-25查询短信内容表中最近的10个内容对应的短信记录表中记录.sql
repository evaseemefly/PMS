SELECT * FROM DBO.S_SMSContent ORDER BY ID DESC
--查询短信内容表中最近的10个短信对应的相关记录
SELECT * FROM DBO.S_SMSRecord_Current AS SC WHERE SC.SCID in (SELECT TOP 10 S.ID FROM DBO.S_SMSContent AS S ORDER BY S.ID DESC )

--查询短信内容表中最近的10个短信对应的相关记录
SELECT * FROM DBO.S_SMSRecord_Current AS SC WHERE SC.SCID in (SELECT TOP 1 S.ID FROM DBO.S_SMSContent AS S ORDER BY S.ID DESC )

SELECT * FROM DBO.S_SMSRecord_Current AS SC 
LEFT JOIN DBO.S_SMSContent AS S
ON S.ID=SC.SCID
ORDER BY SC.SRID DESC

--查询指定msgid的记录
select * from dbo.S_SMSContent as c
left join dbo.S_SMSRecord_Current as sc
on c.ID=sc.SCID
 where c.msgId='3393c563e4634cca90beb64122efb8cf'

 --查询最后一个发送的短彩信内容
 SELECT TOP 1 * FROM DBO.S_SMSContent AS S WHERE S.isMMS='1' ORDER BY S.ID DESC

 --查询最近发的四个短信记录
 SELECT TOP 4 * FROM DBO.S_SMSRecord_Current AS SC 
 LEFT JOIN DBO.S_SMSContent AS S
 ON SC.SCID=S.ID
ORDER BY SC.SCID DESC 
 
  (SELECT TOP 4 S.ID FROM DBO.S_SMSContent AS S WHERE S.isMMS='1' ORDER BY S.ID DESC) ORDER BY SC.SCID DESC 

  SELECT * FROM DBO.S_SMSRecord_Current AS SC WHERE SC.SCID='15343'
