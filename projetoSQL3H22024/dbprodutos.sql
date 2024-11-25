drop database dbprodutos;

create database dbprodutos;

use dbprodutos;


CREATE TABLE PRODUTOS 
( 
CODIGO INT, 
NOME VARCHAR(50), 
TIPO VARCHAR(25), 
QUANTIDADE INT, 
VALOR DECIMAL(10,2) 
);
 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 1,'IMPRESSORA', 'INFORMATICA', 200, 600.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 2,'CAMERA DIGITAL', 'DIGITAIS', 300, 400.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 3,'DVD PLAYER', 'ELETRONICOS', 250, 500.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 4,'MONITOR', 'INFORMATICA', 400, 900.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 5,'TELEVISOR', 'ELETRONICOS', 350, 650.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 6,'FILMADORA DIGITAL', 'DIGITAIS', 500, 700.00 );
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 7,'CELULAR', 'TELEFONE', 450, 850.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 8,'TECLADO', 'INFORMATICA', 300, 450.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 9,'VIDEOCASSETE', 'ELETRONICOS', 200, 300.00 ); 
INSERT INTO PRODUTOS ( CODIGO, NOME, TIPO, QUANTIDADE, VALOR ) VALUES ( 10,'MOUSE', 'INFORMATICA', 400, 60.00 );

show tables;

desc PRODUTOS;

-- Comandos select

select * from produtos; 

select nome,valor from produtos;

select codigo as 'Código', nome as 'Nome do produto' from produtos;

select distinct tipo from produtos;

select * from produtos where quantidade > 250;

select nome, tipo from produtos where valor <= 150;

select * from produtos where quantidade >= 300 and valor <= 50;

select * from produtos where quantidade >= 300 or valor <= 50;

select * from produtos where nome = 'Monitor' and tipo = 'Informatica';

select * from produtos where nome = 'Monitor' or tipo = 'Informatica';

select * from produtos where tipo not in('Informatica','Telefone');

select * from produtos where valor not between 250 and 600;

-- pesquisa por código

select * from produtos where codigo = 5;

-- pesquisa por nome

-- %nome

-- nome%

-- %nome%


select * from produtos where nome like '%o';

select * from produtos where nome like 'i%';

select * from produtos where nome like '%a%';

select * from produtos where nome like '%a%' and tipo = 'Informatica';

select * from produtos where nome like '%a%' or tipo = 'Informatica';

select * from produtos where nome not like '%a%' or tipo = 'Informatica';

select valor = valor * 1.20 as 'Valor' from produtos where nome like 'F%';

select valor from produtos where nome like 'f%';

update produtos set valor = valor * 1.12 
	where nome like 'f%';

select nome, valor from produtos 
	where nome like 'f%';

update produtos set quantidade = quantidade + 50 
	where valor > 400 and valor < 600;

select * from produtos 
	where valor > 400 and valor < 600;

-- clausula order by

select * from produtos order by valor desc;

select * from produtos order by valor asc;

-- clausula limit

select * from produtos limit 5;

select * from produtos order by valor limit 5;


