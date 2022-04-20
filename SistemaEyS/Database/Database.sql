-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema Seguridad
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Seguridad
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Seguridad` DEFAULT CHARACTER SET utf8 ;
USE `Seguridad` ;

-- -----------------------------------------------------
-- Table `Seguridad`.`tbl_rol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Seguridad`.`tbl_rol` (
  `id_rol` INT(11) NOT NULL AUTO_INCREMENT,
  `rol` VARCHAR(50) NOT NULL,
  `estado` INT(11) NOT NULL,
  PRIMARY KEY (`id_rol`),
  UNIQUE INDEX `id_rol_UNIQUE` (`id_rol` ASC) VISIBLE,
  UNIQUE INDEX `rol_UNIQUE` (`rol` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `Seguridad`.`tbl_user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Seguridad`.`tbl_user` (
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
  UNIQUE INDEX `user_UNIQUE` (`user` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  INDEX `fk_tbl_user_tbl_rol1_idx` (`apellidos` ASC) VISIBLE,
  CONSTRAINT `fk_tbl_user_tbl_rol1`
    FOREIGN KEY (`apellidos`)
    REFERENCES `Seguridad`.`tbl_rol` (`id_rol`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 16
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `Seguridad`.`tbl_UserRol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Seguridad`.`tbl_UserRol` (
  `id_UserRol` INT(11) NOT NULL AUTO_INCREMENT,
  `id_user` INT(11) NOT NULL,
  `id_rol` INT(11) NOT NULL,
  PRIMARY KEY (`id_UserRol`),
  UNIQUE INDEX `id_UserRol_UNIQUE` (`id_UserRol` ASC) VISIBLE,
  INDEX `fk_tbl_UserRol_1_idx` (`id_user` ASC) VISIBLE,
  INDEX `fk_tbl_UserRol_2_idx` (`id_rol` ASC) VISIBLE,
  CONSTRAINT `fk_tbl_UserRol_1`
    FOREIGN KEY (`id_user`)
    REFERENCES `Seguridad`.`tbl_user` (`id_user`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbl_UserRol_2`
    FOREIGN KEY (`id_rol`)
    REFERENCES `Seguridad`.`tbl_rol` (`id_rol`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `Seguridad`.`tbl_opcion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Seguridad`.`tbl_opcion` (
  `id_opcion` INT(11) NOT NULL AUTO_INCREMENT,
  `opcion` VARCHAR(50) NOT NULL,
  `estado` INT(11) NOT NULL,
  PRIMARY KEY (`id_opcion`),
  UNIQUE INDEX `id_opcion_UNIQUE` (`id_opcion` ASC) VISIBLE,
  UNIQUE INDEX `opcion_UNIQUE` (`opcion` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `Seguridad`.`tbl_rolOpcion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Seguridad`.`tbl_rolOpcion` (
  `id_rolOpcion` INT(11) NOT NULL AUTO_INCREMENT,
  `id_rol` INT(11) NOT NULL,
  `id_opcion` INT(11) NOT NULL,
  PRIMARY KEY (`id_rolOpcion`),
  UNIQUE INDEX `id_rolOpcion_UNIQUE` (`id_rolOpcion` ASC) VISIBLE,
  INDEX `fk_tbl_rolOpcion_1_idx` (`id_rol` ASC) VISIBLE,
  INDEX `fk_tbl_rolOpcion_2_idx` (`id_opcion` ASC) VISIBLE,
  CONSTRAINT `fk_tbl_rolOpcion_1`
    FOREIGN KEY (`id_rol`)
    REFERENCES `Seguridad`.`tbl_rol` (`id_rol`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tbl_rolOpcion_2`
    FOREIGN KEY (`id_opcion`)
    REFERENCES `Seguridad`.`tbl_opcion` (`id_opcion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;

USE `Seguridad` ;

-- -----------------------------------------------------
-- Placeholder table for view `Seguridad`.`VwRolOpcion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Seguridad`.`VwRolOpcion` (`id_rol` INT, `rol` INT, `id_opcion` INT, `opcion` INT);

-- -----------------------------------------------------
-- Placeholder table for view `Seguridad`.`VwUserRol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Seguridad`.`VwUserRol` (`id_user` INT, `user` INT, `pwd` INT, `nombres` INT, `apellidos` INT, `email` INT, `pwd_temp` INT, `estado` INT, `id_rol` INT, `rol` INT);

-- -----------------------------------------------------
-- View `Seguridad`.`VwRolOpcion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Seguridad`.`VwRolOpcion`;
USE `Seguridad`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `Seguridad`.`VwRolOpcion` AS select `trop`.`id_rol` AS `id_rol`,`tr`.`rol` AS `rol`,`trop`.`id_opcion` AS `id_opcion`,`topc`.`opcion` AS `opcion` from ((`Seguridad`.`tbl_rolOpcion` `trop` join `Seguridad`.`tbl_rol` `tr` on((`trop`.`id_rol` = `tr`.`id_rol`))) join `Seguridad`.`tbl_opcion` `topc` on((`trop`.`id_opcion` = `topc`.`id_opcion`)));

-- -----------------------------------------------------
-- View `Seguridad`.`VwUserRol`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Seguridad`.`VwUserRol`;
USE `Seguridad`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `Seguridad`.`VwUserRol` AS select `tur`.`id_user` AS `id_user`,`tus`.`user` AS `user`,`tus`.`pwd` AS `pwd`,`tus`.`nombres` AS `nombres`,`tus`.`apellidos` AS `apellidos`,`tus`.`email` AS `email`,`tus`.`pwd_temp` AS `pwd_temp`,`tus`.`estado` AS `estado`,`tur`.`id_rol` AS `id_rol`,`tr`.`rol` AS `rol` from ((`Seguridad`.`tbl_UserRol` `tur` join `Seguridad`.`tbl_user` `tus` on((`tur`.`id_user` = `tus`.`id_user`))) join `Seguridad`.`tbl_rol` `tr` on((`tur`.`id_rol` = `tr`.`id_rol`)));

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
