create database wenja;
use wenja;
create table cadastro (id int auto_increment primary key, login varchar (25) not null, senha varchar(25) not null, telefone varchar(15) not null, email varchar(100) not null unique, endereco varchar(100) not null, cpf varchar(14)not null);
insert into cadastro (id, login, senha, telefone, email, endereco, cpf) values (null,'admin','admin','12345','admin@gmail.com','rua coroados - 75, 103', '100.100.100-00');
insert into cadastro (id, login, senha, telefone, email, endereco, cpf) values (null,'a','b','c','d','e', 'f');
insert into cadastro (id, login, senha, telefone, email, endereco, cpf) values (null,'q','w','e','r','t', 'y');

create table produtos (id int auto_increment primary key, nomeproduto varchar(50)not null unique, preco float(10.2),infproduto varchar(255));
insert into produtos (id, nomeproduto, preco, infproduto) values (null, 'aa', 9.99, 'bb');
insert into produtos (id, nomeproduto, preco, infproduto) values (null, 'b', 10.20, 'cc');

use wenja;
create table compras (id_compra int auto_increment primary key,
id_produto int,
id_client int,
foreign key (id_produto) references produtos(id),
foreign key (id_client) references cadastro(id)
);
create table funcionarios (id_funcionario int auto_increment primary key,
nome varchar(255)not null unique,
cargo varchar(255) not null,
salario float(10.2) not null,
infs varchar (255) not null
);

create table estoque (id int auto_increment primary key,
id_produto int,
foreign key (id_produto) references produtos(id)
);

create table inf_cartao (id int auto_increment primary key,
numero int(16),
titular varchar(255),
id_client int,
foreign key (id_client) references cadastro(id)
);