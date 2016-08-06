select 
u.Id
,u.UserName
, ISNULL(u.FirstName,'')+ isnull( u.LastName,'') as Name
,r.Id RoleId
,r.Name RoleName
 from users u
left join UserRole ur on u.Id= ur.UserId
left join Role r on ur.RoleId = r.Id

select * from Role
select * from UserRole
select * from UserType