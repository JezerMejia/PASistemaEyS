/*
 * ER/Studio Data Architect SQL Code Generation
 * Project :      Modelo Control de Asistencia de Empleados.DM1
 *
 * Date Created : viernes, 22 de abril de 2022 11:03:10 p.m.
 * Target DBMS : Microsoft SQL Server 2017
 */

USE master;
CREATE DATABASE BDSistemaEyS;
USE BDSistemaEyS;
/* 
 * TABLE: Administraciones 
 */

CREATE TABLE Administraciones(
    idAdministrador     int             AUTO_INCREMENT,
    primerNombre        nvarchar(25)    NOT NULL,
    segundoNombre       nvarchar(25)    NOT NULL,
    primerApellido      nvarchar(25)    NOT NULL,
    segundoApellido     nvarchar(25)    NOT NULL,
    rolAdministrador    nvarchar(50)    NOT NULL,
    CONSTRAINT PK8 PRIMARY KEY NONCLUSTERED (idAdministrador)
);

/* 
 * TABLE: Asistencia 
 */

CREATE TABLE Asistencia(
    idAsistencia        int         AUTO_INCREMENT,
    fechaHoraSalida     datetime    NOT NULL,
    fechaHoraEntrada    datetime    NOT NULL,
    idEmpleado          int         NOT NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (idAsistencia)
);

/* 
 * TABLE: Cargo 
 */

CREATE TABLE Cargo(
    idCargo             int              AUTO_INCREMENT,
    nombreCargo         nvarchar(25)     NOT NULL,
    descripcionCargo    nvarchar(100)    NOT NULL,
    CONSTRAINT PK2 PRIMARY KEY NONCLUSTERED (idCargo)
);

/* 
 * TABLE: Departamento 
 */

CREATE TABLE Departamento(
    idDepartamento             int              AUTO_INCREMENT,
    nombreDepartamento         nvarchar(25)     NULL,
    descripcionDepartamento    nvarchar(100)    NULL,
    extensionDepartamento      nvarchar(50)     NULL,
    CONSTRAINT PK3 PRIMARY KEY NONCLUSTERED (idDepartamento)
);

/* 
 * TABLE: Empleado 
 */

CREATE TABLE Empleado(
    idEmpleado         int             AUTO_INCREMENT,
    primerNombre       nvarchar(25)    NOT NULL,
    segundoNombre      nvarchar(25)    NOT NULL,
    primerApellido     nvarchar(25)    NOT NULL,
    segundoApellido    nvarchar(25)    NOT NULL,
    fechaIngreso       datetime        NULL,
    cedulaEmpleado     float           NULL,
    idCargo            int             NOT NULL,
    idDepartamento     int             NOT NULL,
    idHorario          int             NOT NULL,
    idGrupo            int             NOT NULL,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (idEmpleado)
);

/* 
 * TABLE: Grupos 
 */

CREATE TABLE Grupos(
    idGrupo             int              AUTO_INCREMENT,
    nombreGrupo         nvarchar(25)     NOT NULL,
    descripcionGrupo    nvarchar(100)    NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (idGrupo)
);

/* 
 * TABLE: Horario 
 */

CREATE TABLE Horario(
    idHorario          int         AUTO_INCREMENT,
    lunesInicio        datetime    NOT NULL,
    lunesSalida        datetime    NULL,
    martesInicio       datetime    NULL,
    MartesSalida       datetime    NULL,
    miercolesInicio    datetime    NULL,
    miercolesSalida    datetime    NULL,
    juevesInicio       datetime    NULL,
    juevesSalida       datetime    NULL,
    viernesInicio      datetime    NULL,
    viernesSalida      datetime    NULL,
    sabadoInicio       datetime    NULL,
    sabadoFin          datetime    NULL,
    domingoFin         datetime    NULL,
    domingoInicio      datetime    NULL,
    CONSTRAINT PK5 PRIMARY KEY NONCLUSTERED (idHorario)
);

/* 
 * TABLE: SolVacaciones 
 */

CREATE TABLE SolVacaciones(
    idSolVacaciones    int              AUTO_INCREMENT,
    fechaSol           datetime         NULL,
    descripcionSol     nvarchar(100)    NOT NULL,
    idEmpleado         int              NOT NULL,
    CONSTRAINT PK7 PRIMARY KEY NONCLUSTERED (idSolVacaciones)
);

/* 
 * TABLE: Asistencia 
 */

ALTER TABLE Asistencia ADD CONSTRAINT RefEmpleado5 
    FOREIGN KEY (idEmpleado)
    REFERENCES Empleado(idEmpleado);


/* 
 * TABLE: Empleado 
 */

ALTER TABLE Empleado ADD CONSTRAINT RefCargo3 
    FOREIGN KEY (idCargo)
    REFERENCES Cargo(idCargo);

ALTER TABLE Empleado ADD CONSTRAINT RefDepartamento4 
    FOREIGN KEY (idDepartamento)
    REFERENCES Departamento(idDepartamento);

ALTER TABLE Empleado ADD CONSTRAINT RefHorario6 
    FOREIGN KEY (idHorario)
    REFERENCES Horario(idHorario);

ALTER TABLE Empleado ADD CONSTRAINT RefGrupos7 
    FOREIGN KEY (idGrupo)
    REFERENCES Grupos(idGrupo);


/* 
 * TABLE: SolVacaciones 
 */

ALTER TABLE SolVacaciones ADD CONSTRAINT RefEmpleado8 
    FOREIGN KEY (idEmpleado)
    REFERENCES Empleado(idEmpleado);


