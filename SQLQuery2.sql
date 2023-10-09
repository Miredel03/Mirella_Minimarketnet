-- PROCEDIMIENTOS ALMACENADOS DE LA TABLA CATEGORIA
/* 
CREADO POR MIRELLA GONZALES
07-10-2023
Boton guardar de tabla dbo.categorias
*/
CREATE PROCEDURE USP_Guardar_ca
@nOpcion INT=0,
@nCodigo_Ca INT=0,
@Descripcion_Ca VARCHAR(40)=''
AS
IF @nOpcion=1--Nuevo registro
BEGIN
	INSERT INTO Categorias(descripcion_ca, estado)
	VALUES (@Descripcion_Ca,1);
END;
ELSE--actualiza
BEGIN
	UPDATE Categorias 
	SET descripcion_ca=@Descripcion_Ca 
	WHERE cod_categ=@nCodigo_Ca;
END;
GO

/* 
CREADO POR MIRELLA GONZALES
07-10-2023
Boton eliminar de tabla dbo.categorias
*/
CREATE PROCEDURE USP_Eliminar_ca
@codigo_Ca INT=0
AS
BEGIN
	DELETE FROM  Categorias 
	WHERE cod_categ=@codigo_Ca;
END;
GO


-- PROCEDIMIENTOS ALMACENADOS DE LA TABLA MARCAS

/* 
CREADO POR MIRELLA GONZALES
07-10-2023
Boton guardar de tabla dbo.marcas
*/ 

ALTER PROCEDURE USP_Guardar_ma
@nOpcion INT=0,
@nCodigo_Ma INT=0,
@Descripcion_Ma VARCHAR(40)=''
AS
IF @nOpcion=1--Nuevo registro
BEGIN
	INSERT INTO marcas(descripcion_ma, estado) 
	VALUES (@Descripcion_Ma,1);
END;
ELSE--actualiza
BEGIN
	update marcas 
	SET descripcion_ma=@Descripcion_Ma 
	WHERE cod_marcas=@nCodigo_Ma;
END;
GO

/* 
CREADO POR MIRELLA GONZALES
07-10-2023
Lista de datos de tabla dbo.marcas
*/ 

CREATE PROCEDURE USP_Listado_ma
@cTexto VARCHAR(100)=''
AS
	 SELECT cod_marcas, descripcion_ma 
	 FROM marcas
	 WHERE estado=1 and 
	 --upper(trim(cast(cod_categ as char))+trim(descripcion_ca)) like '%'+upper(trim(@cTexto))+'%';
	 upper(trim(descripcion_ma)) like '%'+upper(trim(@cTexto))+'%';
	 --trim limpia espacios a la derecha
	 --cast convierte a otro tipo de dato
	 --upper pasa a mayuscula
GO



--CODIGO SQL

 -- CONSULTAR DATOS DE TABLAS

	SELECT
		campo1,
		campo2
	FROM nombre_tabla
	WHERE campo1='sasas' and campo2='dsadadadsa'


 --- INSERTAR DATOS EN UNA TABLA
  INSERT INTO
	nombre_tabla(campo1, campo2)
  VALUES('valor 1', 'valor 2')

 -- ACTUALIZAR DATOS DE UNA TABLA

 UPDATE
	nombre_tabla
 SET
	campo1='dasdada',
	campo2='dsadadadsa'
 WHERE 
	campo1='dsadada'

	-- ELIMINAR DATOS DE UNA TABLA

DELETE FROM
	nombre_tabla
WHERE 
	campo1='dadasdsad'

