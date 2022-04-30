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

-- -----------------------------------------------------
-- Schema BDSistemaEyS
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `BDSistemaEyS` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `BDSistemaEyS` ;

-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Administraciones`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Administraciones` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Administraciones` (
  `idAdministrador` INT NOT NULL AUTO_INCREMENT,
  `primerNombre` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `segundoNombre` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `primerApellido` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `segundoApellido` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `rolAdministrador` VARCHAR(50) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`idAdministrador`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Cargo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Cargo` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Cargo` (
  `idCargo` INT NOT NULL AUTO_INCREMENT,
  `nombreCargo` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `descripcionCargo` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`idCargo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Departamento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Departamento` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Departamento` (
  `idDepartamento` INT NOT NULL AUTO_INCREMENT,
  `nombreDepartamento` VARCHAR(25) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `descripcionDepartamento` VARCHAR(100) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `extensionDepartamento` VARCHAR(50) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`idDepartamento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Grupos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Grupos` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Grupos` (
  `idGrupo` INT NOT NULL AUTO_INCREMENT,
  `nombreGrupo` VARCHAR(25) CHARACTER SET 'utf8' NOT NULL,
  `descripcionGrupo` VARCHAR(100) CHARACTER SET 'utf8' NOT NULL,
  PRIMARY KEY (`idGrupo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `BDSistemaEyS`.`Horario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `BDSistemaEyS`.`Horario` ;

CREATE TABLE IF NOT EXISTS `BDSistemaEyS`.`Horario` (
  `idHorario` INT NOT NULL AUTO_INCREMENT,
  `lunesInicio` DATETIME NULL DEFAULT NULL,
  `lunesSalida` DATETIME NULL DEFAULT NULL,
  `martesInicio` DATETIME NULL DEFAULT NULL,
  `MartesSalida` DATETIME NULL DEFAULT NULL,
  `miercolesInicio` DATETIME NULL DEFAULT NULL,
  `miercolesSalida` DATETIME NULL DEFAULT NULL,
  `juevesInicio` DATETIME NULL DEFAULT NULL,
  `juevesSalida` DATETIME NULL DEFAULT NULL,
  `viernesInicio` DATETIME NULL DEFAULT NULL,
  `viernesSalida` DATETIME NULL DEFAULT NULL,
  `sabadoInicio` DATETIME NULL DEFAULT NULL,
  `sabadoFin` DATETIME NULL DEFAULT NULL,
  `domingoFin` DATETIME NULL DEFAULT NULL,
  `domingoInicio` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`idHorario`))
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
  `fechaIngreso` DATETIME NULL DEFAULT NULL,
  `cedulaEmpleado` VARCHAR(14) NULL,
  `idCargo` INT NULL,
  `idDepartamento` INT NULL,
  `idHorario` INT NULL,
  `idGrupo` INT NULL,
  PRIMARY KEY (`idEmpleado`),
  INDEX `RefCargo3` (`idCargo` ASC) VISIBLE,
  INDEX `RefDepartamento4` (`idDepartamento` ASC) VISIBLE,
  INDEX `RefHorario6` (`idHorario` ASC) VISIBLE,
  INDEX `RefGrupos7` (`idGrupo` ASC) VISIBLE,
  CONSTRAINT `RefCargo3`
    FOREIGN KEY (`idCargo`)
    REFERENCES `BDSistemaEyS`.`Cargo` (`idCargo`),
  CONSTRAINT `RefDepartamento4`
    FOREIGN KEY (`idDepartamento`)
    REFERENCES `BDSistemaEyS`.`Departamento` (`idDepartamento`),
  CONSTRAINT `RefGrupos7`
    FOREIGN KEY (`idGrupo`)
    REFERENCES `BDSistemaEyS`.`Grupos` (`idGrupo`),
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
  `fechaHoraSalida` DATETIME NULL,
  `fechaHoraEntrada` DATETIME NULL,
  `idEmpleado` INT NOT NULL,
  PRIMARY KEY (`idAsistencia`),
  INDEX `RefEmpleado5` (`idEmpleado` ASC) VISIBLE,
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
  `idEmpleado` INT NOT NULL,
  `FechaHoraInicio` DATETIME NOT NULL,
  `FechaHoraFin` DATETIME NOT NULL,
  PRIMARY KEY (`idSolVacaciones`),
  INDEX `RefEmpleado8` (`idEmpleado` ASC) VISIBLE,
  CONSTRAINT `RefEmpleado8`
    FOREIGN KEY (`idEmpleado`)
    REFERENCES `BDSistemaEyS`.`Empleado` (`idEmpleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
