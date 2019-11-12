create Procedure Sp_Consulta_Cliente as

select	c.Nome,
		c.CPF,
		tc.Descricao,
		c.Sexo,
		sc.Descricao
from	Tb_Cliente c
join	Tb_Tipo_Cliente tc on (tc.Id_Tipo_Cliente = c.Id_Tipo_Cliente)
join	Tb_Situacao_Cliente sc on (sc.Id_Situacao_Cliente = c.Id_Situacao_Cliente)

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

create Procedure Sp_Atualiza_Cliente (
	@Nome varchar(30),
	@CPF varchar(15),
	@Id_Tipo_Cliente int,
	@Sexo char(1),
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

create Procedure Sp_Exclui_Cliente (@CPF varchar(15)) as

delete from Tb_Cliente where  CPF = @CPF

return
