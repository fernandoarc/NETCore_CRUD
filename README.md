# NET CORE 3.1 - CRUD

El motivo del presente proyecto de estudio es implementar y desarrollar un CRUD basado en .Net Core, versión 3.1

## Requisitos
---
Para iniciar el desarrollo, el desarrollador debe tener en cuenta las siguientes consideraciones:

- Instalar IDE Visual Studio Code.
- Instalar extensión **C#** desde el IDE previamente indicado (v1.24.4 para el presente proyecto).
- Instalar extensión **C# extensions** desde el IDE previamente indicado (v1.3.1).
- Instalar extensión **Nuget package Management** desde el IDE previamente indicado (v1.1.6).
- Contar con SQL Server Manager (v18.1 usada en el presente proyecto).
- Instalar framework **.NET Core, version 3.1.1** desde la página oficial de Microsoft [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download).

## Creación e inicio del proyecto
---
Para crear el proyecto debemos crear una carpeta en donde alojaremos el código fuente del proyecto, posteriormente abrimos dicha carpeta desde Visual Studio Code y ejecutamos el comando desde la terminal del IDE para generar la plantilla del proyecto.

```cmd
dotnet new mvc
```

Para iniciar el proyecto se debe ejecutar el siguiente comando desde la terminal de Visual Studio Code.

```cmd
dotnet run
---
dotnet watch run
```
NOTA: el comando anterior deja a la terminal en espera, es importante cancelar la ejecución de la linea anterior una vez que ya no se requiera (para cancelar **ctrl+c**)

## Estrategia de desarrollo
---
El proyecto será desarrollado bajo el esquema de *Code First*, el cual consiste en desarrollar los modelos y relaciones desde el código fuente y migrarlos posteriormente a la base de datos a través de *Entity Framework*

## Configuracion inicial enrutado http - https
---
La plantilla por defecto esta configurado para correr con el protocolo HTTPS, para evitar inconvenientes y mensajes de warning se recomienda en ambiente local modificar el protocolo de comunicación, eliminando la ruta https y comentando la redirección forzada a https

Eliminar ruta https
![Modificar enrutado https](/Documentacion/ConfiguracionInicio.png)

Comentar redirección forzada
![Modificar enrutado https](/Documentacion/redireccionHttps.png)

## Implementación Entity Framework
--------
A continuación se explica los pasos a seguir para la implementación de EF para trabajar con .Net Core.


IMPORTANTE: las versiones de Entity Framework deben ser iguales a la versión de .NetCore con la que se está trabajando, en este caso la versión 3.1.1.


### Agregar entity Framework

Para implementar Entity Framework desde el código, se deben tener en cuenta las siguientes consideraciones:

- Agregar dependencia de *EntityFrameworkCore, v3.1.1* a través de Nugget Package Manager.
- Restaurar  dependencias.

### Habilitar automáticamente cadena conexion
El objetivo de este paso consiste en habilitar la conexión a la base de datos apenas inicie la ejecución del proyecto, para ello debemos configurar y habilitar la cadena de conexión, tomando en cuenta las siguientes consideraciones:

- Agregar la cadena de conexión en el archivo *appsettings.json*.
- Agregar dependencia *EntityFrameworkCore.SqlServer, versión 3.1.1*  a través de Nugget Package Manager.
- Restaurar nuevamente las dependencias

### Habilitar Migrations
Este punto consiste en habilitar el proceso de modelado y migración de las clases desarrolladas en c# y migrarlas al Sql Server. 

Para lograr dicho objetivo se deben tener en cuenta:
- Ejecutar el siguiente comando desde la terminal:
```cmd
dotnet tool install --global dotnet-ef --version 3.1.1
```
- Agregar dependencia *EntityFrameworkCore.Desing, versión 3.1.0*  a través de Nugget Package Manager.
- Restaurar nuevamente las dependencias
- Ejecutar el siguiente comando desde la terminal:
```cmd
dotnet ef migrations add Migracion
dotnet ef database update
```
- En el caso de querer actualizar version de EF ejecutar los siguientes comandos:
```cmd
dotnet tool update --global dotnet-ef --version 3.1.1
//importante, se debe actualizar la version en el csproj, según la version a actualizar
```
