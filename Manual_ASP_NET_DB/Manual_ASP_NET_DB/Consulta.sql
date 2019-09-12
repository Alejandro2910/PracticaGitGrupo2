CREATE TABLE [dbo].[Consulta] (     
	[IdPaciente] INT NOT NULL,     
	[IdMedico] INT NOT NULL,     
	[Fecha] DATETIME NOT NULL,     
	[Sintomas] VARCHAR(MAX) NOT NULL,     
	[Diagnostico] VARCHAR(MAX) NOT NULL, 
 
    CONSTRAINT PK_Consulta PRIMARY KEY ([IdPaciente], [IdMedico], [Fecha]),     
	CONSTRAINT FK_Consulta_Paciente FOREIGN KEY ([IdPaciente])      
	REFERENCES dbo.[Paciente]([Id]) ON DELETE CASCADE,     
	CONSTRAINT FK_Consulta_Medico FOREIGN KEY ([IdMedico])      
	REFERENCES dbo.[Medico]([Id]) ON DELETE CASCADE, 

)