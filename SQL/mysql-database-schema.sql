-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema supermarketsmysql
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema supermarketsmysql
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `supermarketsmysql` DEFAULT CHARACTER SET utf8 ;
USE `supermarketsmysql` ;

-- -----------------------------------------------------
-- Table `supermarketsmysql`.`vendors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketsmysql`.`vendors` (
  `id` INT(11) NOT NULL,
  `vendor_name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketsmysql`.`expenses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketsmysql`.`expenses` (
  `id` INT(11) NOT NULL,
  `vendor_id` INT(11) NOT NULL,
  `expense` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `expenses_vendors_fk_idx` (`vendor_id` ASC),
  CONSTRAINT `expenses_vendors_fk`
    FOREIGN KEY (`vendor_id`)
    REFERENCES `supermarketsmysql`.`vendors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketsmysql`.`incomes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketsmysql`.`incomes` (
  `id` INT(11) NOT NULL,
  `vendor_id` INT(11) NOT NULL,
  `product_id` INT(11) NOT NULL,
  `income` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `incomes_vendors_fk_idx` (`product_id` ASC),
  CONSTRAINT `incomes_vendors_fk`
    FOREIGN KEY (`product_id`)
    REFERENCES `supermarketsmysql`.`vendors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketsmysql`.`products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketsmysql`.`products` (
  `id` INT(11) NOT NULL,
  `product_name` VARCHAR(100) NOT NULL,
  `vendor_id` INT(11) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `products_vendors_fk_idx` (`vendor_id` ASC),
  CONSTRAINT `products_vendors_fk`
    FOREIGN KEY (`vendor_id`)
    REFERENCES `supermarketsmysql`.`vendors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
