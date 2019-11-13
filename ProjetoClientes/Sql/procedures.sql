CREATE Procedure Sp_Consulta_Cliente (@CPF varchar(15)) as

select	c.Nome,
		c.CPF,
		Tipo = tc.Descricao,
		c.Id_Tipo_Cliente,
		c.Sexo,
		Situacao = sc.Descricao,
		c.Id_Situacao_Cliente
from	Tb_Cliente c
join	Tb_Tipo_Cliente tc on (tc.Id_Tipo_Cliente = c.Id_Tipo_Cliente)
join	Tb_Situacao_Cliente sc on (sc.Id_Situacao_Cliente = c.Id_Situacao_Cliente)
where	(c.CPF = @CPF or isnull(@CPF, '') = '')

return

GO

create Procedure Sp_Insere_Cliente (
	@Nome varchar(30),
	@CPF varchar(15),
	@Id_Tipo_Cliente int,
	@Sexo char(1),
	@Id_Situacao_Cliente int
) as

insert into Tb_Cliente (CPF,Nome,Id_Tipo_Cliente,Sexo,Id_Situacao_Cliente)
select @Nome, @CPF,	@Id_Tipo_Cliente, @Sexo, @Id_Situacao_Cliente

return

GO

CREATE Procedure Sp_Atualiza_Cliente (
	@Nome varchar(30),
	@CPF varchar(15),
	@Sexo char(1),
	@Id_Tipo_Cliente int,
	@Id_Situacao_Cliente int
) as

update Tb_Cliente set
Nome = @Nome,
Id_Tipo_Cliente = @Id_Tipo_Cliente,
Sexo = @Sexo,
Id_Situacao_Cliente = @Id_Situacao_Cliente
where  CPF = @CPF

return

GO

create procedure Sp_Exclui_Cliente (@CPF varchar(15)) as

delete from Tb_Cliente where CPF = @CPF

return

GO

CREATE Procedure Sp_Consulta_Situacao_Cliente as

select	Id_Situacao_Cliente,
		Descricao
from	Tb_Situacao_Cliente

return

GO

CREATE Procedure Sp_Consulta_Tipo_Cliente as

select	Id_Tipo_Cliente,
		Descricao
from	Tb_Tipo_Cliente

return

GO