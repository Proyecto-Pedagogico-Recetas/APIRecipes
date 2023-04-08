insert into RolType
([Name], [Description],IsActive)
values
('Profesor','Sube y lista recetas', 1) 

select * from RolType

insert into Authotizations
([ControllerName], [ActionName], [HTTPMethodType], InsertDate, [Name])

values
('User', 'insertuser', 'POST', GETDATE(), 'InsertUser')

select * from Authotizations

insert into Rol_Authorization
(IdRol, IdAuthorization, IsActive)

values
(1,1,1)
select * from Rol_Authorization

insert into Users
(IdRol, [UserName], InsertDate, IsActive, EncryptedPassword, EncryptedToken, TokenExpireDate)

values
(1, 'Celia', GETDATE(), 1, '$2a$11$V6c1zrNzHljeiIQ81bLaoeogagZWvr2JUkUs8CHmWzHYJ6T2l0S5q', '', GETDATE())

select * from Users
