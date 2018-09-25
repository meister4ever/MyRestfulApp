# MyRestfulApp
Test Genérico de .NET

Pasos para el uso de la aplicación:

A) Para configurar la conexión a la base de datos y popularla con datos de prueba:
1. Modificar el connectionstring en el archivo Web.config (en Data Source) 
   de DESKTOP-JPGUFQL\SQLEXPRESS al connection string del servidor SQL que usted disponga.
2. Para los datos de prueba, Acceder al Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)  
   y ejecutar el comando: Update-Database (si se quieren ver las queries que ejecuta usar el flag -Verbose)

B) Para probar el ABM y los servicios de Usuarios
   Ejecutar los test unitarios del proyecto MyRestfulApp.Tests

C) Para probar los Servicios de cotización
Para consultar los servicios de cotización, correr la aplicación e ingresar los siguientes:
http://localhost:8080/MyRestfulApp/Quotation/Dolar
Despliega en el navegador un resultado del estilo: ["36.900","38.400","Actualizada al 25/9/2018 15:00"]
http://localhost:8080/MyRestfulApp/Quotation/Pesos
Devuelve HTTP ERROR 401
http://localhost:8080/MyRestfulApp/Quotation/Real
Devuelve HTTP ERROR 401
