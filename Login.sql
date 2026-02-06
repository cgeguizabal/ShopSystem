CREATE PROC usuario_login
@email varchar(50),
@clave varchar(50)
AS
SELECT u.idusuario,u.idrol,r.nombre as rol,u.nombre,u.estado
FROM usuario u inner join rol r on u.idrol=r.idrol
WHERE u.email=@email and u.clave=HASHBYTES('SHA2_256', @clave)
go