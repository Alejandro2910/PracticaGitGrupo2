CREATE TABLE [dbo].[Medico]
(
	 [Id]           INT			IDENTITY (1, 1) NOT NULL,
	 [Nombre]       VARCHAR(50) NOT NULL,
	 [Apellidos]    VARCHAR(50) NOT NULL,
	 [Especialidad] VARCHAR(50) NOT NULL,
	 [Oficina]      INT         NOT NULL,
	 PRIMARY KEY CLUSTERED ([Id] ASC)
)
