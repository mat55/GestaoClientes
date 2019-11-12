create database ProjetoClientes

use ProjetoClientes

create table Tb_Tipo_Cliente(
Id_Tipo_Cliente int primary key not null,
Descricao varchar(50))

create table Tb_Situacao_Cliente(
Id_Situacao_Cliente int primary key not null,
Descricao varchar(50))

create table Tb_Cliente(
CPF varchar(15) primary key not null,
Nome varchar(30),
Id_Tipo_Cliente int not null,
Constraint FK_Tb_Cliente_Tb_Tipo_Cliente Foreign Key (Id_Tipo_Cliente) References Tb_Tipo_Cliente (Id_Tipo_Cliente),
Sexo char(1),
Id_Situacao_Cliente int not null
Constraint FK_Tb_Cliente_Tb_Situacao_Cliente Foreign Key (Id_Situacao_Cliente) References Tb_Situacao_Cliente (Id_Situacao_Cliente)
)