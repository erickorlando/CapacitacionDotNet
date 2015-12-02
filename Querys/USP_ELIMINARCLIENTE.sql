CREATE PROCEDURE NETDESLIB.usp_EliminarCliente
(
	@IdCliente VARCHAR(36)
)
LANGUAGE SQL


DELETE FROM NETDESLIB.Clientes
		WHERE IdCliente = @IdCliente