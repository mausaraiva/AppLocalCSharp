-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema db_empregado
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema db_empregado
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `db_empregado` DEFAULT CHARACTER SET utf8 ;
USE `db_empregado` ;

-- -----------------------------------------------------
-- Table `db_empregado`.`empregado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `db_empregado`.`empregado` (
  `matricula` INT NOT NULL AUTO_INCREMENT,
  `cpf` VARCHAR(11) NOT NULL,
  `nome` VARCHAR(80) NOT NULL,
  `endereco` VARCHAR(200) NOT NULL,
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC),
  PRIMARY KEY (`matricula`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
