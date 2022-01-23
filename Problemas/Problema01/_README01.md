Enunciado del Problema 01
--------------------------

La tabla Cliente de la base de datos contiene 500000 registros.
Si ejecutamos la consulta "SELECT * FROM Cliente", la misma sólo demora milisegundos en ejecutarse.
Si a la consulta le agregamos un ORDER BY y ejecutamos "SELECT * FROM Cliente ORDER BY Nombre", la consluta puede demorar más de 1 minuto.

- Hacé en la BD lo que creas necesario para que la consulta no demore más al incluir el ORDER BY.


/******************************RODRIGO GUTIERREZ*******************************/

ANTES:

Ejecución terminada sin errores.
Resultado: 500000 filas devueltas en 1410ms
En la línea 2:
SELECT * FROM Cliente ORDER BY Nombre

	--QUERY PLAN
		--SCAN TABLE Cliente
		--USE TEMP B-TREE FOR ORDER BY

DESPUES:

CREATE INDEX "Cliente_Nombre_INDEX" ON "Cliente" (
	"Nombre"	ASC
);

Ejecución terminada sin errores.
Resultado: 500000 filas devueltas en 110ms
En la línea 2:
SELECT * FROM Cliente ORDER BY Nombre

	--QUERY PLAN
		--SCAN TABLE Cliente USING COVERING INDEX Cliente_Nombre_INDEX

