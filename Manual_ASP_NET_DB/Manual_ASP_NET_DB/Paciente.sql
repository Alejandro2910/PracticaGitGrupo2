CREATE TABLE [dbo].[Paciente]
(
	[Id]				int				identity (1,1) not null,
	[Nombre]			varchar(50)		not null,
	[Apellidos]			varchar(50)		null,
	[FechaNacimiento]	datetime		not null,
	[Residencia]		varchar(max)	null,
	[Peso]				decimal(5, 2)	null,
	[Altura]			decimal(3, 2)	null,
	[PresionArterial]	int				null,
	primary key clustered ([Id] ASC)
)
