-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema comercialtdsdb01
-- -----------------------------------------------------
-- drop Schema `comercialtdsdb01`;
-- -----------------------------------------------------
-- Schema comercialtdsdb01
-- -----------------------------------------------------
drop database if exists comercialtdsdb01;
CREATE SCHEMA IF NOT EXISTS `comercialtdsdb01` DEFAULT CHARACTER SET utf8 ;
USE `comercialtdsdb01` ;

-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`niveis`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`niveis` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `sigla` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`usuarios` (
  `id` INT(4) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(60) NOT NULL,
  `email` VARCHAR(60) NOT NULL,
  `senha` VARCHAR(32) NOT NULL,
  `nivel_id` INT NOT NULL,
  `ativo` BIT(1) NOT NULL DEFAULT b'1',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) ,
  INDEX `fk_usuarios_niveis1_idx` (`nivel_id` ASC) ,
  CONSTRAINT `fk_usuarios_niveis1`
    FOREIGN KEY (`nivel_id`)
    REFERENCES `comercialtdsdb01`.`niveis` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1001
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`caixas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`caixas` (
  `id` INT(4) NOT NULL AUTO_INCREMENT,
  `usuario_id` INT(4) NOT NULL,
  `data_abertura` DATETIME NOT NULL,
  `saldo_inicial` DECIMAL(10,2) NOT NULL,
  `status` CHAR(1) NOT NULL DEFAULT 'A',
  PRIMARY KEY (`id`),
  INDEX `fk_Caixa_Usuarios1_idx` (`usuario_id` ASC) ,
  CONSTRAINT `fk_Caixa_Usuarios1`
    FOREIGN KEY (`usuario_id`)
    REFERENCES `comercialtdsdb01`.`usuarios` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`categorias`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`categorias` (
  `id` INT(4) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(255) NOT NULL,
  `sigla` CHAR(3) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`clientes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`clientes` (
  `id` INT(4) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `cpf` CHAR(11) NOT NULL,
  `telefone` CHAR(14) NULL DEFAULT NULL,
  `email` VARCHAR(60) NOT NULL,
  `data_nasc` DATE NULL DEFAULT NULL,
  `data_cad` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `ativo` BIT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC) ,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 10001
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`enderecos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`enderecos` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `cliente_id` INT(4) NOT NULL,
  `cep` CHAR(8) NOT NULL,
  `logradouro` VARCHAR(100) NULL DEFAULT NULL,
  `numero` VARCHAR(40) NOT NULL,
  `complemento` VARCHAR(60) NULL DEFAULT NULL,
  `bairro` VARCHAR(60) NOT NULL,
  `cidade` VARCHAR(60) NOT NULL,
  `uf` CHAR(2) NOT NULL,
  `tipo_endereco` CHAR(3) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_table1_clientes_idx` (`cliente_id` ASC) ,
  CONSTRAINT `fk_table1_clientes`
    FOREIGN KEY (`cliente_id`)
    REFERENCES `comercialtdsdb01`.`clientes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`produtos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`produtos` (
  `id` INT(4) NOT NULL AUTO_INCREMENT,
  `cod_barras` VARCHAR(60) NOT NULL,
  `descricao` VARCHAR(60) NOT NULL,
  `valor_unit` DECIMAL(10,2) NOT NULL,
  `unidade_venda` VARCHAR(12) NOT NULL,
  `categoria_id` INT(4) NOT NULL,
  `estoque_minimo` DECIMAL(10,2) NOT NULL,
  `classe_desconto` DECIMAL(10,2) NULL DEFAULT NULL,
  `imagem` BLOB NULL DEFAULT NULL,
  `data_cad` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
   `descontinuado` BIT(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `idProduto_UNIQUE` (`id` ASC) ,
  UNIQUE INDEX `Produtocol_UNIQUE` (`cod_barras` ASC) ,
  INDEX `fk_Produto_Categorias1_idx` (`categoria_id` ASC) ,
  CONSTRAINT `fk_Produto_Categorias1`
    FOREIGN KEY (`categoria_id`)
    REFERENCES `comercialtdsdb01`.`categorias` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
-- hashcode
AUTO_INCREMENT = 7400001
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`estoques`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`estoques` (
  `produto_id` INT(4) NOT NULL,
  `quantidade` DECIMAL(10,2) NOT NULL,
  `data_ultimo_movimento` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP() ON UPDATE CURRENT_TIMESTAMP(),
  INDEX `fk_Estoque_Produto1_idx` (`produto_id` ASC) ,
  CONSTRAINT `fk_Estoque_Produto1`
    FOREIGN KEY (`produto_id`)
    REFERENCES `comercialtdsdb01`.`produtos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`fornecedores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`fornecedores` (
  `id` INT(4) NOT NULL,
  `razao_social` VARCHAR(100) NOT NULL,
  `fantasia` VARCHAR(40) NOT NULL,
  `cnpj` CHAR(14) NOT NULL,
  `contato` VARCHAR(60) NULL DEFAULT NULL,
  `telefone` VARCHAR(45) NULL DEFAULT NULL,
  `email` VARCHAR(60) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `cnpj_UNIQUE` (`cnpj` ASC) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`pedidos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`pedidos` (
  `id` INT(4) NOT NULL AUTO_INCREMENT,
  `usuario_id` INT(4) NOT NULL,
  `cliente_id` INT(4) NOT NULL,
  `data` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP(),
  `status` CHAR(1) NOT NULL DEFAULT 'A',
  `desconto` DECIMAL(10,2) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Pedido_Usuarios1_idx` (`usuario_id` ASC) ,
  INDEX `fk_Pedido_Clientes1_idx` (`cliente_id` ASC) ,
  CONSTRAINT `fk_Pedido_Clientes1`
    FOREIGN KEY (`cliente_id`)
    REFERENCES `comercialtdsdb01`.`clientes` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pedido_Usuarios1`
    FOREIGN KEY (`usuario_id`)
    REFERENCES `comercialtdsdb01`.`usuarios` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 100001
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`itempedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`itempedido` (
  `id` INT(4) NOT NULL AUTO_INCREMENT,
  `pedido_id` INT(11) NOT NULL,
  `produto_id` INT(11) NOT NULL,
  `valor_unit` DECIMAL(10,2) NOT NULL,
  `quantidade` DECIMAL(10,3) NOT NULL,
  `desconto` DECIMAL(10,2) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_ItemPedido_Pedido1_idx` (`pedido_id` ASC) ,
  INDEX `fk_ItemPedido_Produto1_idx` (`produto_id` ASC) ,
  CONSTRAINT `fk_ItemPedido_Pedido1`
    FOREIGN KEY (`pedido_id`)
    REFERENCES `comercialtdsdb01`.`pedidos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ItemPedido_Produto1`
    FOREIGN KEY (`produto_id`)
    REFERENCES `comercialtdsdb01`.`produtos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `comercialtdsdb01`.`produtofornecedor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`produtofornecedor` (
  `produto_id` INT(4) NOT NULL,
  `fornecedores_id` INT(4) NOT NULL,
  PRIMARY KEY (`produto_id`, `fornecedores_id`),
  INDEX `fk_Produto_has_Fornecedores_Fornecedores1_idx` (`fornecedores_id` ASC) ,
  INDEX `fk_Produto_has_Fornecedores_Produto1_idx` (`produto_id` ASC) ,
  CONSTRAINT `fk_Produto_has_Fornecedores_Fornecedores1`
    FOREIGN KEY (`fornecedores_id`)
    REFERENCES `comercialtdsdb01`.`fornecedores` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Produto_has_Fornecedores_Produto1`
    FOREIGN KEY (`produto_id`)
    REFERENCES `comercialtdsdb01`.`produtos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

USE `comercialtdsdb01` ;

-- -----------------------------------------------------
-- Placeholder table for view `comercialtdsdb01`.`vw_pedido`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `comercialtdsdb01`.`vw_pedido` (`pedido` INT, `cliente` INT, `produto` INT, `quantidade` INT, `valor_item` INT, `desc_item` INT, `desc_pedido` INT, `cod_barras` INT, `descricao` INT);

-- -----------------------------------------------------
-- procedure sp_categoria_delete
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_categoria_delete`(spid int)
begin
	delete from categorias
    where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_categoria_insert
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_categoria_insert`(spnome varchar(40), spsigla char(3))
begin
	insert into categorias
    values(0,spnome,spsigla);
    select last_insert_id();
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_categoria_update
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_categoria_update`(spid int, spnome varchar(40), spsigla char(3))
begin
	update categorias set nome = spnome, sigla = spsigla
    where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_delete
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_endereco_delete`(spid int)
begin
delete from enderecos
where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_insert
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_endereco_insert`(
    spcliente_id int, 
    spcep char(8), 
    splogradouro varchar(100),
    spnumero varchar(40),
    spcomplemento varchar(60),
    spbairro varchar(60),
    spcidade varchar(60),
    spuf char(2),
    sptipo_endereco char(3)
    )
begin
		insert into enderecos 
        values (0,spcliente_id, spcep, splogradouro, spnumero, spcomplemento, spbairro, spcidade, spuf, sptipo_endereco);
        select @@identity as id;
    end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_endereco_update
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_endereco_update`(
spid int,
spcep char(8), 
splogradouro varchar(100),
spnumero varchar(40),
spcomplemento varchar(60),
spbairro varchar(60),
spcidade varchar(60),
spuf char(2),
sptipo_endereco char(3))
begin
	 update enderecos set cep = spcep, 
     logradouro = splogradouro, 
     numero = spnumero, 
	 complemento = spcomplemento, 
	 bairro = spbairro, 
	 cidade = spcidade, 
	 uf = spuf,
	 tipo_endereco = sptipo_endereco 
	 where id = spid;
 end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_insere_cliente
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_cliente_insert`(
spnome varchar(100), 
spcpf char(11), 
sptelefone char(14), 
spemail varchar(60), 
spdatanasc date
)
begin 
	insert into clientes 
    values (0,spnome, spcpf, sptelefone, spemail, spdatanasc,default,1);
    select  last_insert_id();
end$$

DELIMITER ;


USE `comercialtdsdb01`;
DROP procedure IF EXISTS `sp_cliente_update`;

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE PROCEDURE `sp_cliente_update` (spid int, spnome varchar(100), sptelefone char(14), spdatanasc date)
BEGIN
 update clientes set nome= spnome, telefone  = sptelefone, data_nasc = spdatanasc where id = spid; 
END$$

DELIMITER ;



-- -----------------------------------------------------
-- procedure sp_itempedido_delete
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_itempedido_delete`(spid int)
begin
	delete from itempedido
    where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_itempedido_insert
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_itempedido_insert`(sppedido_id int, spproduto_id int, spquantidade decimal (10,3), spdesconto decimal(10,2))
begin
	insert into itempedido
    values (0, sppedido_id, spproduto_id, (select valor_unit from produtos where id = spproduto_id), spquantidade, spdesconto);
    select last_insert_id();
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_itempedido_update
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_itempedido_update`(spid int,spquantidade decimal(10,3), spdesconto decimal(10,2))
begin
	update itempedido set quantidade = spquantidade, desconto = spdesconto
    where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pedido_insert
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pedido_insert`(spusuario_id int, spcliente_id int)
begin
	insert into pedidos
    values(0, spusuario_id, spcliente_id,default , 'A', 0);
    select last_insert_id();
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_pedido_update
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_pedido_update`(spid int, spstatus char(1), spdesconto decimal(10,2))
begin
	update pedidos set status = spstatus, desconto = spdesconto
    where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_produto_insert
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_produto_insert`(
spcod_barras varchar(60), 
spdescricao varchar(60),
spvalor_unit decimal(10,2),
spunidade_venda varchar(12),
spcategoria_id int,
spestoque_minimo decimal(10,2),
spclasse_desconto decimal(10,2))
begin
	insert into produtos
    values(
    0,
    spcod_barras, 
    spdescricao, 
    spvalor_unit, 
    spunidade_venda,
    spcategoria_id, 
    spestoque_minimo,
    spclasse_desconto,
    null,
    default, 
    default);
    select last_insert_id();
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_produto_update
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_produto_update`(
spid int,
spcod_barras varchar(60), 
spdescricao varchar(60),
spvalor_unit decimal(10,2),
spunidade_venda varchar(12),
spcategoria_id int,
spestoque_minimo decimal(10,2),
spclasse_desconto decimal(10,2),
spdescontinuado bit(1)
)
begin
	update produtos set cod_barras = spcod_barras, descricao = spdescricao,
    valor_unit = spvalor_unit, unidade_venda = spunidade_venda, categoria_id = spcategoria_id,
    estoque_minimo = spestoque_minimo, classe_desconto = spclasse_desconto, descontinuado = spdescontinuado 
    where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_usuario_altera
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
-- drop procedure `sp_usuario_altera`
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_altera`(
-- parâmetros da procedure
spid int, spnome varchar(60), spsenha varchar(32), spnivel int)
begin
	update usuarios 
	set nome = spnome, senha = md5(spsenha), nivel_id = spnivel where id = spid;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_usuario_insert
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_usuario_insert`(
-- parâmetros da procedure
spnome varchar(60), spemail varchar(60), spsenha varchar(32), spnivel int)
begin
	insert into usuarios 
	values (0,spnome, spemail, md5(spsenha), spnivel, default);
    select * from usuarios where id = last_insert_id();
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure sp_venda_terminal
-- -----------------------------------------------------

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_venda_terminal`(spusuario_id int,spcpf char(11), spcodbar varchar(60))
begin
	insert pedidos values(0,spusuario_id,(select id from clientes where cpf = spcpf), default, 'A', 0);
		insert itempedido values (
			0,
			last_insert_id(),
			(select id from produtos where cod_barras = spcodbar),
            (select valor_unit from produtos where cod_barras = spcodbar),
            1,
            0);
	select * from itempedido where id = last_insert_id();
end$$

DELIMITER ;

-- -----------------------------------------------------
-- View `comercialtdsdb01`.`vw_pedido`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `comercialtdsdb01`.`vw_pedido`;
USE `comercialtdsdb01`;
CREATE  OR REPLACE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `comercialtdsdb01`.`vw_pedido` AS select `p`.`id` AS `pedido`,`p`.`cliente_id` AS `cliente`,`ip`.`produto_id` AS `produto`,`ip`.`quantidade` AS `quantidade`,`ip`.`valor_unit` AS `valor_item`,`ip`.`desconto` AS `desc_item`,`p`.`desconto` AS `desc_pedido`,`pr`.`cod_barras` AS `cod_barras`,`pr`.`descricao` AS `descricao` from ((`comercialtdsdb01`.`pedidos` `p` join `comercialtdsdb01`.`itempedido` `ip` on(`p`.`id` = `ip`.`pedido_id`)) join `comercialtdsdb01`.`produtos` `pr` on(`ip`.`produto_id` = `pr`.`id`));
USE `comercialtdsdb01`;

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `comercialtdsdb01`.`trigger_gera_estoque`
AFTER INSERT ON `comercialtdsdb01`.`produtos`
FOR EACH ROW
BEGIN
INSERT INTO estoques values(new.id, 0, current_date());
END$$

USE `comercialtdsdb01`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `comercialtdsdb01`.`trigger_baixa_estoque`
AFTER INSERT ON `comercialtdsdb01`.`itempedido`
FOR EACH ROW
BEGIN
update estoques SET quantidade = quantidade - NEW.quantidade, data_ultimo_movimento = current_date()
where produto_id = new.produto_id
;
END$$
-- SP_NIVEL_INSERT --
delimiter $$
          create procedure comercialtdsdb01.sp_nivel_insert(
		   spnome varchar(45),
           spsigla varchar(45)
)
begin
		   insert into niveis(nome, sigla) values (spnome, spsigla);
           select * from niveis where id = last_insert_id();
end $$

-- SP_NIVEL_UPDATE --
delimiter $$
		    create procedure comercialtdsdb01.sp_nivel_update(
		    spid int,
            spnome varchar(45),
            spsigla varchar(45)
)
begin
   update niveis set nome = spnome, sigla = spsigla 
   where id = spid;
end $$
DELIMITER ;

-- *********************************************************************
-- Alteração da procedure de insert de produtos, para incluir a imagem
USE `comercialtdsdb01`;
DROP procedure IF EXISTS `comercialtdsdb01`.`sp_produto_insert`;
;

DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_produto_insert`(
spcod_barras varchar(60), 
spdescricao varchar(60),
spvalor_unit decimal(10,2),
spunidade_venda varchar(12),
spcategoria_id int,
spestoque_minimo decimal(10,3),
spclasse_desconto decimal(10,4),
spimagem blob -- adicionando a imagem
)
begin
	insert into produtos
    values(
    0,
    spcod_barras, 
    spdescricao, 
    spvalor_unit, 
    spunidade_venda,
    spcategoria_id, 
    spestoque_minimo,
    (spclasse_desconto / 100),
    spimagem,
    default, 
    default);
    select last_insert_id();
end$$
DELIMITER ;

USE `comercialtdsdb01`;
DROP procedure IF EXISTS `comercialtdsdb01`.`sp_produto_update`;
;
DELIMITER $$
USE `comercialtdsdb01`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_produto_update`(
spid int,
spcod_barras varchar(60), 
spdescricao varchar(60),
spvalor_unit decimal(10,2),
spunidade_venda varchar(12),
spcategoria_id int,
spestoque_minimo decimal(10,3),
spclasse_desconto decimal(10,4),
spimagem blob,
spdescontinuado bit(1)
)
begin
	update produtos set cod_barras = spcod_barras, descricao = spdescricao,
    valor_unit = spvalor_unit, unidade_venda = spunidade_venda, categoria_id = spcategoria_id,
    estoque_minimo = spestoque_minimo, classe_desconto = (spclasse_desconto / 100), descontinuado = spdescontinuado, 
    imagem = spimagem
    where id = spid;
end$$

DELIMITER ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;




----------------------------------
-- teste de usuario
----------------------------------
-- Adicionando usuario para fazer teste de login no C#
--------------------
USE `comercialtdsdb01`;
call sp_nivel_insert('Master','MT');
call sp_usuario_insert('Marcell', 'marcell@tdsq.com','1234',1);

-- UPDATE usuarios SET senha md5('123') WHERE email = 'marcell@tdsq.com');

select * from usuarios;
select * from niveis;
-- UPDATE estoques SET quantidade = quantidade + (SELECT quantidade FROM itempedido WHERE id = 1) WHERE produto_id = 740001;
-- DELETE FROM itempedido WHERE id = 1;