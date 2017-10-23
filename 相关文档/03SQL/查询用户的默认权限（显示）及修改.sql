--查找admin账户对应的权限
select * from dbo.R_UserInfo_ActionInfo as r
left join dbo.UserInfo as u on r.UserInfoID=u.ID
left join dbo.ActionInfo as a on r.ActionInfoID=a.ID
where u.UName='admin' and a.ID=5

--修改isDefault
update R_UserInfo_ActionInfo
set isDefault=1
where id=24

--查询指定用户所拥有的全部权限
select r.* from dbo.R_UserInfo_ActionInfo as r
left join dbo.UserInfo as u on r.UserInfoID=u.ID
left join dbo.ActionInfo as a on r.ActionInfoID=a.ID
where u.UName='admin'and a.ID=43
