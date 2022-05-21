# NET CORE 3.1 - CRUD

El motivo del presente proyecto de estudio es implementar y desarrollar un CRUD basado en .Net Core, versión 3.1

## Requisitos
Para iniciar el desarrollo, el desarrollador debe tener en cuenta las siguientes consideraciones:

- Instalar IDE Visual Studio Code.
- Instalar extensión **C#** desde el IDE previamente indicado (v1.24.4 para el presente proyecto).
- Instalar extensión **C# extensions** desde el IDE previamente indicado (v1.3.1).
- Instalar extensión **Nuget package Management** desde el IDE previamente indicado (v1.1.6).
- Instalar framework **.NET Core, version 3.1.1** desde la página oficial de Microsoft [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download).

## Creación proyecto e inicio del proyecto
Para crear el proyecto debemos crear una carpeta en donde alojaremos el código fuente del proyecto, posteriormente abrimos dicha carpeta desde Visual Studio Code y ejecutamos el comando desde la terminal del IDE para generar la plantilla del proyecto.

```cmd
dotnet new mvc
```

Para iniciar el proyecto se debe ejecutar el siguiente comando desde la terminal de Visual Studio Code.

```cmd
dotnet run
```
NOTA: el comando anterior deja a la terminal en espera, es importante cancelar la ejecución de la linea anterior una vez que ya no se requiera (para cancelar **ctrl+c**)

## Estrategia de desarrollo
El proyecto será desarrollado bajo el esquema de *Coder First*, el cual consiste en desarrollar los modelos y relaciones desde el código fuente y migrarlos posteriormente a la base de datos a través de *Entity Framework*

