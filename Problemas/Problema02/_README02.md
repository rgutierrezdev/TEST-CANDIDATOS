Enunciado para el Problema 02
-----------------------------

Se tienen 2 tablas en la BD, "Siniestro" y "DatoSiniestro" con una relación one-to-many

- Hacer los cambios que sean necesarios en la BD para que en el método BorrarSiniestro se pueda eliminar todo menos la linea 16 y se produzca el mismo resultado.


/******************************RODRIGO GUTIERREZ*******************************/

En este caso como la tabla está vacía no es necesario hacer una migración previa de datos.

Se borra la tabla DatoSiniestro y se crea nuevamente con la siguiente FOREIGN KEY

CREATE TABLE "DatoSiniestro" 
( "Id" INTEGER NOT NULL, 
"IdSiniestro" INTEGER NOT NULL, 
"Dato" TEXT, 
PRIMARY KEY("Id"),
FOREIGN KEY (IdSiniestro) REFERENCES Siniestro(Id) ON DELETE CASCADE
)