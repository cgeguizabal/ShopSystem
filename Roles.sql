-- Insertar roles
INSERT INTO rol (nombre) values('Administrador');
INSERT INTO rol (nombre) values('Vendedor');
INSERT INTO rol (nombre) values('Almacenero');
go

--Procedimiento listar rol
CREATE PROC rol_listar
as
SELECT idrol,nombre FROM rol
WHERE estado=1
go
