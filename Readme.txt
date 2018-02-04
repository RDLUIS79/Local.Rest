Arquitectura de la aplicacion:

	Lenguage: c#
		Local.Rest.ApiRest: Proyecto WebApi para creacion de servicio Rest
		Local.Rest.ApiSoap: Proyecto WCF para creacion de sercio Soap
		Local.Rest.ModelDTO: Proyecto de biblioteca de clases para el modelo y el mapeo de la bbdd
		Local.Rest.ServiceRest: Proyecto de biblioteca de clases para el mapeo y creacion de servicios de negocio y lógico que consumen los ws.
		Local.Rest.Shared: Proyecto de clases, contiene funciones para generar log y realizar trazas, por ejemplo para implementar un lo g de modificaciones en los platos/ingredientes.
	BBDD: 
		Mapeo de la entidad de modelo de datos con EF6
		modelEntities: localDB
		TeastRestEntities: Microsoft SQL Server Enterprise: Core-based Licensing (64-bit)
			Incluye (.bak)
	Documentacion:
		Swagger: Para mapeo, testeo y documentacion de servicios api rest
		Clientes de pruebas WCF: mapeo, testeo y documentacion de los servicios soap
		
