alter procedure USP_Listado_ca
@cTexto varchar(100)=''
as
	 SELECT cod_categ, descripcion_ca 
	 FROM Categorias
	 WHERE estado=1 and 
	 --upper(trim(cast(cod_categ as char))+trim(descripcion_ca)) like '%'+upper(trim(@cTexto))+'%';
	 upper(trim(descripcion_ca)) like '%'+upper(trim(@cTexto))+'%';

	 --trim limpia espacios a la derecha
	 --cast convierte a otro tipo de dato
	 --upper pasa a mayuscula
go

