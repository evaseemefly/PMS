SELECT * FROM DBO.S_SMSContent ORDER BY ID DESC
--��ѯ�������ݱ��������10�����Ŷ�Ӧ����ؼ�¼
SELECT * FROM DBO.S_SMSRecord_Current AS SC WHERE SC.SCID in (SELECT TOP 10 S.ID FROM DBO.S_SMSContent AS S ORDER BY S.ID DESC )

--��ѯ�������ݱ��������10�����Ŷ�Ӧ����ؼ�¼
SELECT * FROM DBO.S_SMSRecord_Current AS SC WHERE SC.SCID in (SELECT TOP 1 S.ID FROM DBO.S_SMSContent AS S ORDER BY S.ID DESC )

SELECT * FROM DBO.S_SMSRecord_Current AS SC 
LEFT JOIN DBO.S_SMSContent AS S
ON S.ID=SC.SCID
ORDER BY SC.SRID DESC

--��ѯָ��msgid�ļ�¼
select * from dbo.S_SMSContent as c
left join dbo.S_SMSRecord_Current as sc
on c.ID=sc.SCID
 where c.msgId='3393c563e4634cca90beb64122efb8cf'

 --��ѯ���һ�����͵Ķ̲�������
 SELECT TOP 1 * FROM DBO.S_SMSContent AS S WHERE S.isMMS='1' ORDER BY S.ID DESC

 --��ѯ��������ĸ����ż�¼
 SELECT TOP 4 * FROM DBO.S_SMSRecord_Current AS SC 
 LEFT JOIN DBO.S_SMSContent AS S
 ON SC.SCID=S.ID
ORDER BY SC.SCID DESC 
 
  (SELECT TOP 4 S.ID FROM DBO.S_SMSContent AS S WHERE S.isMMS='1' ORDER BY S.ID DESC) ORDER BY SC.SCID DESC 

  SELECT * FROM DBO.S_SMSRecord_Current AS SC WHERE SC.SCID='15343'
