-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema BDSistemaEyS
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `BDSistemaEyS` ;

-- -----------------------------------------------------
-- Schema BDSistemaEyS
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `BDSistemaEyS` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `BDSistemaEyS` ;

-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Cargo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Cargo` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Cargo` (
  `idCargo` INT NOT NULL AUTO_INCREMENT,
  `nombreCargo` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `descripcionCargo` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  `estado` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`idCargo`),
  UNIQUE INDEX `idCargo_UNIQUE` (`idCargo` ASC) VISIBLE,
  UNIQUE INDEX `nombreCargo_UNIQUE` (`nombreCargo` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Departamento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Departamento` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Departamento` (
  `idDepartamento` INT NOT NULL AUTO_INCREMENT,
  `nombreDepartamento` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `descripcionDepartamento` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `extensionDepartamento` VARCHAR(5) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `estado` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`idDepartamento`),
  UNIQUE INDEX `idDepartamento_UNIQUE` (`idDepartamento` ASC) VISIBLE,
  UNIQUE INDEX `nombreDepartamento_UNIQUE` (`nombreDepartamento` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Horario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Horario` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Horario` (
  `idHorario` INT NOT NULL AUTO_INCREMENT,
  `nombreHorario` VARCHAR(50) NOT NULL,
  `lunesInicio` TIME NULL DEFAULT NULL,
  `lunesSalida` TIME NULL DEFAULT NULL,
  `martesInicio` TIME NULL DEFAULT NULL,
  `martesSalida` TIME NULL DEFAULT NULL,
  `miercolesInicio` TIME NULL DEFAULT NULL,
  `miercolesSalida` TIME NULL DEFAULT NULL,
  `juevesInicio` TIME NULL DEFAULT NULL,
  `juevesSalida` TIME NULL DEFAULT NULL,
  `viernesInicio` TIME NULL DEFAULT NULL,
  `viernesSalida` TIME NULL DEFAULT NULL,
  `sabadoInicio` TIME NULL DEFAULT NULL,
  `sabadoSalida` TIME NULL DEFAULT NULL,
  `domingoInicio` TIME NULL DEFAULT NULL,
  `domingoSalida` TIME NULL DEFAULT NULL,
  `estado` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`idHorario`),
  UNIQUE INDEX `idHorario_UNIQUE` (`idHorario` ASC) VISIBLE,
  UNIQUE INDEX `nombreHorario_UNIQUE` (`nombreHorario` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Empleado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Empleado` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Empleado` (
  `idEmpleado` INT NOT NULL AUTO_INCREMENT,
  `primerNombre` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `segundoNombre` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `primerApellido` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `segundoApellido` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `fechaIngreso` DATE NULL DEFAULT NULL,
  `fechaNacimiento` DATE NULL,
  `cedulaEmpleado` VARCHAR(14) CHARACTER SET 'utf8' NULL,
  `pinEmpleado` VARCHAR(30) CHARACTER SET 'utf8' NOT NULL,
  `telefonoEmpleado` VARCHAR(15) NULL,
  `emailPersonal` VARCHAR(50) NULL,
  `emailEmpresarial` VARCHAR(50) NULL,
  `idCargo` INT NULL,
  `idDepartamento` INT NULL,
  `idHorario` INT NULL,
  `estado` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`idEmpleado`),
  INDEX `RefCargo3` (`idCargo` ASC) VISIBLE,
  INDEX `RefDepartamento4` (`idDepartamento` ASC) VISIBLE,
  INDEX `RefHorario6` (`idHorario` ASC) VISIBLE,
  UNIQUE INDEX `idEmpleado_UNIQUE` (`idEmpleado` ASC) VISIBLE,
  UNIQUE INDEX `telefonoEmpleado_UNIQUE` (`telefonoEmpleado` ASC) VISIBLE,
  UNIQUE INDEX `emailPersonal_UNIQUE` (`emailPersonal` ASC) VISIBLE,
  UNIQUE INDEX `emailEmpresarial_UNIQUE` (`emailEmpresarial` ASC) VISIBLE,
  UNIQUE INDEX `cedulaEmpleado_UNIQUE` (`cedulaEmpleado` ASC) VISIBLE,
  CONSTRAINT `RefCargo3`
    FOREIGN KEY (`idCargo`)
    REFERENCES `BDSistemaEyS`.`Cargo` (`idCargo`),
  CONSTRAINT `RefDepartamento4`
    FOREIGN KEY (`idDepartamento`)
    REFERENCES `BDSistemaEyS`.`Departamento` (`idDepartamento`),
  CONSTRAINT `RefHorario6`
    FOREIGN KEY (`idHorario`)
    REFERENCES `BDSistemaEyS`.`Horario` (`idHorario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Asistencia`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Asistencia` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Asistencia` (
  `idAsistencia` INT NOT NULL AUTO_INCREMENT,
  `fechaAsistencia` DATE NOT NULL,
  `horaEntrada` TIME NULL,
  `horaSalida` TIME NULL,
  `idEmpleado` INT NOT NULL,
  PRIMARY KEY (`idAsistencia`),
  INDEX `RefEmpleado5` (`idEmpleado` ASC) VISIBLE,
  UNIQUE INDEX `idAsistencia_UNIQUE` (`idAsistencia` ASC) VISIBLE,
  UNIQUE INDEX `fechaAsistencia_idEmpleado_UNIQUE` (`fechaAsistencia` ASC, `idEmpleado` ASC) VISIBLE,
  CONSTRAINT `RefEmpleado5`
    FOREIGN KEY (`idEmpleado`)
    REFERENCES `BDSistemaEyS`.`Empleado` (`idEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`SolVacaciones`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`SolVacaciones` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`SolVacaciones` (
  `idSolVacaciones` INT NOT NULL AUTO_INCREMENT,
  `fechaSol` DATETIME NOT NULL,
  `descripcionSol` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  `fechaHoraInicio` DATETIME NOT NULL,
  `fechaHoraFin` DATETIME NOT NULL,
  `idEmpleado` INT NOT NULL,
  `estado` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`idSolVacaciones`),
  INDEX `RefEmpleado8` (`idEmpleado` ASC) VISIBLE,
  UNIQUE INDEX `idSolVacaciones_UNIQUE` (`idSolVacaciones` ASC) VISIBLE,
  CONSTRAINT `RefEmpleado8`
    FOREIGN KEY (`idEmpleado`)
    REFERENCES `BDSistemaEyS`.`Empleado` (`idEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`tbl_user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`tbl_user` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`tbl_user` (
  `id_user` INT(11) NOT NULL AUTO_INCREMENT,
  `user` VARCHAR(50) NOT NULL,
  `pwd` VARCHAR(50) NOT NULL,
  `nombres` VARCHAR(50) NOT NULL,
  `apellidos` VARCHAR(50) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `pwd_temp` VARCHAR(50) NULL DEFAULT NULL,
  `estado` INT(11) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE INDEX `id_user_UNIQUE` (`id_user` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `user_UNIQUE` (`user` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`tbl_rol`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`tbl_rol` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`tbl_rol` (
  `id_rol` INT NOT NULL AUTO_INCREMENT,
  `rol` VARCHAR(50) NOT NULL,
  `descripcion` VARCHAR(100) NULL DEFAULT NULL,
  `estado` INT(11) NOT NULL,
  PRIMARY KEY (`id_rol`),
  UNIQUE INDEX `rol_UNIQUE` (`rol` ASC) VISIBLE,
  UNIQUE INDEX `id_rol_UNIQUE` (`id_rol` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`tbl_UserRol`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`tbl_UserRol` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`tbl_UserRol` (
  `id_UserRol` INT(11) NOT NULL AUTO_INCREMENT,
  `id_user` INT(11) NOT NULL,
  `id_rol` INT(11) NOT NULL,
  PRIMARY KEY (`id_UserRol`),
  UNIQUE INDEX `id_UserRol_UNIQUE` (`id_UserRol` ASC) VISIBLE,
  INDEX `id_user_idx` (`id_user` ASC) VISIBLE,
  INDEX `id_rol_idx` (`id_rol` ASC) VISIBLE,
  CONSTRAINT `fk_ur_id_user`
    FOREIGN KEY (`id_user`)
    REFERENCES `BDSistemaEyS`.`tbl_user` (`id_user`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ur_id_rol`
    FOREIGN KEY (`id_rol`)
    REFERENCES `BDSistemaEyS`.`tbl_rol` (`id_rol`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`tbl_opcion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`tbl_opcion` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`tbl_opcion` (
  `id_opcion` INT(11) NOT NULL AUTO_INCREMENT,
  `opcion` VARCHAR(50) NOT NULL,
  `descripcion` VARCHAR(100) NULL DEFAULT NULL,
  `estado` INT(11) NOT NULL,
  PRIMARY KEY (`id_opcion`),
  UNIQUE INDEX `id_opcion_UNIQUE` (`id_opcion` ASC) VISIBLE,
  UNIQUE INDEX `opcion_UNIQUE` (`opcion` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`tbl_rolOpcion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`tbl_rolOpcion` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`tbl_rolOpcion` (
  `id_rolOpcion` INT(11) NOT NULL AUTO_INCREMENT,
  `id_rol` INT(11) NOT NULL,
  `id_opcion` INT(11) NOT NULL,
  PRIMARY KEY (`id_rolOpcion`),
  UNIQUE INDEX `id_rolOpcion_UNIQUE` (`id_rolOpcion` ASC) VISIBLE,
  INDEX `id_rol_idx` (`id_rol` ASC) VISIBLE,
  INDEX `id_opcion_idx` (`id_opcion` ASC) VISIBLE,
  CONSTRAINT `fk_ro_id_rol`
    FOREIGN KEY (`id_rol`)
    REFERENCES `BDSistemaEyS`.`tbl_rol` (`id_rol`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ro_id_opcion`
    FOREIGN KEY (`id_opcion`)
    REFERENCES `BDSistemaEyS`.`tbl_opcion` (`id_opcion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `BDSistemaEyS` ;

-- -----------------------------------------------------
-- Placeholder table for view `BDSistemaEyS`.`vwEmpleado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`vwEmpleado` (`ID` INT, `Nombre` INT, `Apellido` INT, `PIN` INT, `Ingreso` INT, `"Fecha de Nacimiento"` INT, `"C??dula"` INT, `"Tel??fono"` INT, `"Email Personal"` INT, `"Email Empresarial"` INT, `Cargo` INT, `Departamento` INT, `"Horario"` INT);

-- -----------------------------------------------------
-- Placeholder table for view `BDSistemaEyS`.`vwRolOpcion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`vwRolOpcion` (`ID Rol` INT, `Rol` INT, `Opci??n` INT);

-- -----------------------------------------------------
-- Placeholder table for view `BDSistemaEyS`.`vwUserRol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`vwUserRol` (`ID UserRol` INT, `Usuario` INT, `Rol` INT);

-- -----------------------------------------------------
-- Placeholder table for view `BDSistemaEyS`.`vwAsistencia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`vwAsistencia` (`"ID"` INT, `"ID Empleado"` INT, `"Empleado"` INT, `"Fecha"` INT, `"Hora de Entrada"` INT, `"Hora de Salida"` INT);

-- -----------------------------------------------------
-- Placeholder table for view `BDSistemaEyS`.`vwSolVacaciones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`vwSolVacaciones` (`"ID"` INT, `"Fecha de Solicitud"` INT, `"Descripci??n"` INT, `"Fecha de Inicio"` INT, `"Fecha de Fin"` INT, `"ID Empleado"` INT, `"Empleado"` INT);

-- -----------------------------------------------------
-- View `BDSistemaEyS`.`vwEmpleado`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`vwEmpleado`;
DROP VIEW IF EXISTS `BDSistemaEyS`.`vwEmpleado` ;
USE `BDSistemaEyS`;
CREATE  OR REPLACE VIEW `vwEmpleado` AS
SELECT
Empleado.idEmpleado as ID,
CONCAT(Empleado.primernombre, " ", Empleado.segundoNombre) as Nombre,
CONCAT(Empleado.primerApellido, " ", Empleado.segundoApellido) as Apellido,
Empleado.pinEmpleado as PIN,
Empleado.fechaIngreso as Ingreso,
Empleado.fechaNacimiento as "Fecha de Nacimiento",
Empleado.cedulaEmpleado as "C??dula",
Empleado.telefonoEmpleado as "Tel??fono",
Empleado.emailPersonal as "Email Personal",
Empleado.emailEmpresarial as "Email Empresarial",
Cargo.nombreCargo as Cargo,
Departamento.nombreDepartamento as Departamento,
Horario.nombreHorario as "Horario"
FROM
BDSistemaEyS.Empleado as Empleado
LEFT JOIN
BDSistemaEyS.Departamento as Departamento ON Empleado.idDepartamento = Departamento.idDepartamento
LEFT JOIN
BDSistemaEyS.Cargo as Cargo ON Empleado.idCargo = Cargo.idCargo
LEFT JOIN
BDSistemaEyS.Horario as Horario ON Empleado.idHorario = Horario.idHorario
WHERE
Empleado.estado <> 3
;

-- -----------------------------------------------------
-- View `BDSistemaEyS`.`vwRolOpcion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`vwRolOpcion`;
DROP VIEW IF EXISTS `BDSistemaEyS`.`vwRolOpcion` ;
USE `BDSistemaEyS`;
CREATE  OR REPLACE VIEW `vwRolOpcion` AS
SELECT
`tbrop`.`id_rolOpcion` AS `ID Rol`,
`tbr`.`rol` AS `Rol`,
`tbopc`.`opcion` AS `Opci??n`
FROM
`tbl_rolOpcion` AS `tbrop`
LEFT JOIN
`tbl_rol` AS `tbr` ON `tbrop`.`id_rol` = `tbr`.`id_rol`
LEFT JOIN
`tbl_opcion` AS `tbopc` ON `tbrop`.`id_opcion` = `tbopc`.`id_opcion`
;

-- -----------------------------------------------------
-- View `BDSistemaEyS`.`vwUserRol`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`vwUserRol`;
DROP VIEW IF EXISTS `BDSistemaEyS`.`vwUserRol` ;
USE `BDSistemaEyS`;
CREATE  OR REPLACE VIEW `vwUserRol` AS
SELECT
`tbur`.`id_UserRol` AS `ID UserRol`,
`tbus`.`user` AS `Usuario`,
`tbr`.`rol` AS `Rol`
FROM
`tbl_UserRol` AS `tbur`
LEFT JOIN
`tbl_user` AS `tbus` ON `tbur`.`id_user` = `tbus`.`id_user`
LEFT JOIN
`tbl_rol` AS `tbr` ON `tbur`.`id_rol` = `tbr`.`id_rol`
;

-- -----------------------------------------------------
-- View `BDSistemaEyS`.`vwAsistencia`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`vwAsistencia`;
DROP VIEW IF EXISTS `BDSistemaEyS`.`vwAsistencia` ;
USE `BDSistemaEyS`;
CREATE  OR REPLACE VIEW `vwAsistencia` AS
SELECT
Asistencia.idAsistencia AS "ID",
Asistencia.idEmpleado AS "ID Empleado",
CONCAT(Empleado.Nombre, " ", Empleado.Apellido) As "Empleado",
Asistencia.fechaAsistencia AS "Fecha",
Asistencia.horaEntrada AS "Hora de Entrada",
Asistencia.horaSalida AS "Hora de Salida"
FROM
BDSistemaEyS.Asistencia AS Asistencia
LEFT JOIN
BDSistemaEyS.vwEmpleado AS Empleado ON Asistencia.idEmpleado = Empleado.ID;

-- -----------------------------------------------------
-- View `BDSistemaEyS`.`vwSolVacaciones`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`vwSolVacaciones`;
DROP VIEW IF EXISTS `BDSistemaEyS`.`vwSolVacaciones` ;
USE `BDSistemaEyS`;
CREATE  OR REPLACE VIEW `vwSolVacaciones` AS
SELECT
Sol.idSolVacaciones AS "ID",
Sol.fechaSol AS "Fecha de Solicitud",
Sol.descripcionSol AS "Descripci??n",
Sol.fechaHoraInicio AS "Fecha de Inicio",
Sol.fechaHoraFin AS "Fecha de Fin",
Sol.idEmpleado AS "ID Empleado",
CONCAT(Empleado.Nombre, " ", Empleado.Apellido) AS "Empleado"
FROM
BDSistemaEyS.SolVacaciones AS Sol
LEFT JOIN
BDSistemaEyS.vwEmpleado AS Empleado ON Sol.idEmpleado = Empleado.ID
WHERE
Sol.estado <> 3;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
-- begin attached script 'DefaultValues'
-- -----------------------------------------------------
-- DefaultValues SistemaEyS
-- -----------------------------------------------------

USE BDSistemaEyS;

INSERT INTO Cargo (
idCargo, nombreCargo, descripcionCargo, estado
)
VALUES
(
1, "Dise??ador Web", "Dise??a webs incre??bles", 1
),
(
2, "Programador", "Programa", 1
);

INSERT INTO Departamento (
idDepartamento, nombreDepartamento, descripcionDepartamento,
extensionDepartamento, estado
)
VALUES (
1, "Dise??o", "Departamento enfocado en el dise??o.",
"336", 1
);

INSERT INTO Horario (
idHorario, nombreHorario,
lunesInicio, lunesSalida,
martesInicio, martesSalida,
miercolesInicio, miercolesSalida,
juevesInicio, juevesSalida,
viernesInicio, viernesSalida,
sabadoInicio, sabadoSalida,
domingoInicio, domingoSalida,
estado
)
VALUES (
1, "Horario com??n (8AM - 5PM)",
"8:00", "17:00",
"8:00", "17:00",
"8:00", "17:00",
"8:00", "17:00",
"8:00", "17:00",
NULL, NULL,
NULL, NULL,
1
);

INSERT INTO Empleado (
idEmpleado, primerNombre, segundoNombre,
primerApellido, segundoApellido, fechaIngreso,
fechaNacimiento, telefonoEmpleado,
emailPersonal, emailEmpresarial,
pinEmpleado, cedulaEmpleado,
idCargo, idDepartamento, idHorario, estado
)
VALUES
(
29812, "Juan", "Ezequiel",
"P??rez", "Jim??nez", "2022-04-29",
"2002-09-06", "76129076",
"juan@gmail.com", NULL,
"1212", "0010405021900A",
1, 1, 1, 1
),
(
31725, "Jezer", "Josu??",
"Mej??a", "Otero", "2022-04-29",
"2003-11-05", "81211855",
"jezer@gmail.com", NULL,
"9898", "2010511031000Y",
2, 1, 1, 1
),
(
32229, "Leo", "Neftal??s",
"Corea", "Navarrete", "2022-04-29",
"2003-01-01", "00005454",
"leo@gmail.com", NULL,
"5454", "00000000000001",
2, 1, 1, 1
),
(
31642, "Roire", "Mart??n",
"Villavicencio", "Obreg??n", "2022-04-29",
"2003-01-01", "00007272",
"roire@gmail.com", NULL,
"7272", "00000000000002",
1, 1, 1, 1
);

INSERT INTO Asistencia (
fechaAsistencia, HoraEntrada, horaSalida, idEmpleado
)
VALUES (
"2022-04-30", "8:10", "13:45",
29812
);

-- -----------------------------------------------------
-- DefaultValues Seguridad
-- -----------------------------------------------------

USE BDSistemaEyS;

INSERT INTO tbl_user (
id_user, user, pwd, nombres, apellidos,
email, pwd_temp, estado
)
VALUES
(
1, "albertoj", "uwu", "Alberto", "Jim??nez",
"alberto.jimenez@google.com", "uwu_temp", 1
),
(
2, "jezerm", "uwu", "Jezer", "Mej??a",
"jezer.mejia@gmail.com", "", 1
),
(
3, "roirev", "uwu", "Roire", "Villavicencio",
"roire.villavicencio@gmail.com", "", 1
),
(
4, "leoc", "uwu", "Leo", "Corea",
"leo.corea@gmail.com", "", 1
)
;

INSERT INTO tbl_rol (id_rol, rol, descripcion, estado)
VALUES
(1, "RRHH", "Recursos Humanos", 1),
(2, "Gerencia General", "Gerencia General", 1),
(3, "TI", "Inform??tica", 1);

INSERT INTO tbl_opcion (id_opcion, opcion, descripcion, estado)
VALUES
(1, "Tabla Empleados", "", 1),
(2, "Tabla Solicitudes", "", 1),
(3, "Tabla Asistencias", "", 1),
(4, "Reportes", "Ver reportes :D", 1),
(5, "Seguridad User", "", 1),
(6, "Seguridad Rol", "", 1),
(7, "Seguridad Opcion", "", 1),
(8, "Seguridad UserRol", "", 1),
(9, "Seguridad RolOpcion", "", 1)
;

INSERT INTO tbl_UserRol (id_UserRol, id_user, id_rol)
VALUES (1, 1, 2);

INSERT INTO tbl_rolOpcion (id_rolOpcion, id_rol, id_opcion)
VALUES
(1, 2, 1), -- GG - Tabla Empleados
(2, 2, 2), -- GG -- Tabla Solicitudes
(3, 2, 3), -- GG -- Tabla Asistencias
(4, 2, 4) -- GG -- Reportes
;
-- end attached script 'DefaultValues'
