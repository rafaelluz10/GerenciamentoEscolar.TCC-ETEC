-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 19/10/2024 às 03:11
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbcantina`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbclientes`
--

CREATE TABLE `tbclientes` (
  `codCli` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telCelular` char(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbfornecedores`
--

CREATE TABLE `tbfornecedores` (
  `codForn` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `cnpj` char(18) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbfuncionarios`
--

CREATE TABLE `tbfuncionarios` (
  `codFunc` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `cpf` char(14) NOT NULL,
  `telCelular` char(10) DEFAULT NULL,
  `cep` char(9) DEFAULT NULL,
  `endereco` varchar(100) DEFAULT NULL,
  `numero` char(10) DEFAULT NULL,
  `bairro` varchar(100) DEFAULT NULL,
  `cidade` varchar(100) DEFAULT NULL,
  `estado` char(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbfuncionarios`
--

INSERT INTO `tbfuncionarios` (`codFunc`, `nome`, `email`, `cpf`, `telCelular`, `cep`, `endereco`, `numero`, `bairro`, `cidade`, `estado`) VALUES
(1, 'Etecia', 'etecia@etecia.com.br', '645.646.464-65', '65465-4654', '04750-000', 'Rua Doutor Antônio Bento', '355', 'Santo Amaro', 'São Paulo', 'SP'),
(2, 'Amarildo Vasconcelos', 'amarildo.vasconcelos@gmail.com', '654.654.646-46', '65465-4654', '04752-000', 'Rua Jurci Soares Sebastião', '355', 'Santo Amaro', 'São Paulo', 'SP'),
(3, 'Benedita da Silva', 'benedita.silva@hotmail.com', '313.465.474-13', '65464-6546', '04753-000', 'Rua Barão do Rio Branco', '325', 'Santo Amaro', 'São Paulo', 'SP');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbprodutos`
--

CREATE TABLE `tbprodutos` (
  `codProd` int(11) NOT NULL,
  `descricao` varchar(100) DEFAULT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `valor` decimal(9,2) DEFAULT NULL,
  `validade` date DEFAULT NULL,
  `dataEntrada` date DEFAULT NULL,
  `horaEntrada` time DEFAULT NULL,
  `codForn` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbusuarios`
--

CREATE TABLE `tbusuarios` (
  `codUsu` int(11) NOT NULL,
  `nome` varchar(25) NOT NULL,
  `senha` varchar(10) NOT NULL,
  `codFunc` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tbusuarios`
--

INSERT INTO `tbusuarios` (`codUsu`, `nome`, `senha`, `codFunc`) VALUES
(1, 'etecia', '123456', 1),
(2, 'benedita.silva', '123456', 3);

-- --------------------------------------------------------

--
-- Estrutura para tabela `tbvendas`
--

CREATE TABLE `tbvendas` (
  `codVenda` int(11) NOT NULL,
  `dataVenda` date DEFAULT NULL,
  `horaVenda` time DEFAULT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `codUsu` int(11) NOT NULL,
  `codCli` int(11) NOT NULL,
  `codProd` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `tbclientes`
--
ALTER TABLE `tbclientes`
  ADD PRIMARY KEY (`codCli`);

--
-- Índices de tabela `tbfornecedores`
--
ALTER TABLE `tbfornecedores`
  ADD PRIMARY KEY (`codForn`),
  ADD UNIQUE KEY `cnpj` (`cnpj`);

--
-- Índices de tabela `tbfuncionarios`
--
ALTER TABLE `tbfuncionarios`
  ADD PRIMARY KEY (`codFunc`),
  ADD UNIQUE KEY `cpf` (`cpf`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Índices de tabela `tbprodutos`
--
ALTER TABLE `tbprodutos`
  ADD PRIMARY KEY (`codProd`),
  ADD KEY `codForn` (`codForn`);

--
-- Índices de tabela `tbusuarios`
--
ALTER TABLE `tbusuarios`
  ADD PRIMARY KEY (`codUsu`),
  ADD UNIQUE KEY `nome` (`nome`),
  ADD KEY `codFunc` (`codFunc`);

--
-- Índices de tabela `tbvendas`
--
ALTER TABLE `tbvendas`
  ADD PRIMARY KEY (`codVenda`),
  ADD KEY `codUsu` (`codUsu`),
  ADD KEY `codCli` (`codCli`),
  ADD KEY `codProd` (`codProd`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tbclientes`
--
ALTER TABLE `tbclientes`
  MODIFY `codCli` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbfornecedores`
--
ALTER TABLE `tbfornecedores`
  MODIFY `codForn` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbfuncionarios`
--
ALTER TABLE `tbfuncionarios`
  MODIFY `codFunc` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `tbprodutos`
--
ALTER TABLE `tbprodutos`
  MODIFY `codProd` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tbusuarios`
--
ALTER TABLE `tbusuarios`
  MODIFY `codUsu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `tbvendas`
--
ALTER TABLE `tbvendas`
  MODIFY `codVenda` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `tbprodutos`
--
ALTER TABLE `tbprodutos`
  ADD CONSTRAINT `tbprodutos_ibfk_1` FOREIGN KEY (`codForn`) REFERENCES `tbfornecedores` (`codForn`);

--
-- Restrições para tabelas `tbusuarios`
--
ALTER TABLE `tbusuarios`
  ADD CONSTRAINT `tbusuarios_ibfk_1` FOREIGN KEY (`codFunc`) REFERENCES `tbfuncionarios` (`codFunc`);

--
-- Restrições para tabelas `tbvendas`
--
ALTER TABLE `tbvendas`
  ADD CONSTRAINT `tbvendas_ibfk_1` FOREIGN KEY (`codUsu`) REFERENCES `tbusuarios` (`codUsu`),
  ADD CONSTRAINT `tbvendas_ibfk_2` FOREIGN KEY (`codCli`) REFERENCES `tbclientes` (`codCli`),
  ADD CONSTRAINT `tbvendas_ibfk_3` FOREIGN KEY (`codProd`) REFERENCES `tbprodutos` (`codProd`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
