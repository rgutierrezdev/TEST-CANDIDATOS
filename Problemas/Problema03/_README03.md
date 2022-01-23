Enunciado del Problema 03
-------------------------

Evidentemente, el método CrearUsuario crea un objeto Usuario y lo persiste.

1. Que modificaría? Por qué?
	
	Modificar el metodo para recibir el Modelo y no lo parámetros, esto para poder aplicar MVC y patrones de diseño sobre EF. Ejemplo Repository Pattern

	--> public void CrearUsuario(Usuario usuario, DAOFactory daof)

2. Que agregaría? Por qué?

	Control de existencia sobre el usuario antes de crearlo, para esto es necesario un indice único o utilizar la PK.

	Ejemplo de la tabla

		CREATE TABLE "Usuario" 
		( "Id" INTEGER NOT NULL, 
		  "login" TEXT, 
		  "password" TEXT, 
		  PRIMARY KEY("Id")
		)

		CREATE UNIQUE INDEX UIndex_Login ON Usuario(login DESC) 