CREATE PROCEDURE NETDESLIB.usp_ActualizarCliente
(
	IN @IdCliente VARCHAR(36),
	IN @Nombres VARCHAR(250),
	IN @Apellidos VARCHAR(250),
	IN @Correo VARCHAR(500),
	IN @Edad INTEGER
)
LANGUAGE SQL


UPDATE NETDESLIB.Clientes
	SET Nombres = @Nombres
		,Apellidos = @Apellidos
		,Correo = @Correo
		,Edad = @Edad
	WHERE IdCliente = @IdCliente
