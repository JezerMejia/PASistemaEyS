# Sistema de Entrada y Salida

Este es el proyecto de Programación de Aplicaciones en el que se crea un sistema de control de asistencias para una empresa "X".

## Requerimientos

- mono
- monodevelop (IDE opcional)
- gtk-sharp
- MySQL

## Instalación de Base de Datos

Luego de instalar y configurar MySQL, se requiere de instalar las 2 bases de datos incluídas en este proyecto:

- `SistemaEyS/Database/BDSistemaEyS.sql`, para lo relacionado con el sistema de control de asistencias.
- `SistemaEyS/Database/BD.sql`, para lo relacionado con la seguridad.

Además, se recomienda usar el script `SistemaEyS/Database/DefaultValuesEyS.sql` para instalar algunos valores por defecto.

### Terminal

Por medio de la terminal, se ejecuta:

```
mysql -u root -p < ./SistemaEyS/Database/BDSistemaEyS.sql
mysql -u root -p < ./SistemaEyS/Database/BD.sql
mysql -u root -p < ./SistemaEyS/Database/DefaultValuesEyS.sql
```

### MySQL Workbench

Se abren los archivos anteriormente señalados, y se ejecutan.

## Compilación y Ejecución

### Terminal

Por medio de la línea de comandos, se compila:

```sh
msbuild SistemaEyS.sln
```

Para ejecutar:

```sh
mono SistemaEyS/bin/Debug/SistemaEyS.exe
```

### MonoDevelop

Se importa el archivo de la solución, `SistemaEyS.sln`, desde **Archivo->Abrir** ó `Ctrl+O`.

Posteriormente, se compila (con `F8`) y se ejecuta (`CTRL+F5`).
