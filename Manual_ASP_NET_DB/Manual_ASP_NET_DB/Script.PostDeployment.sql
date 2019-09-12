/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM dbo.[Consulta]; 
DELETE FROM dbo.[Paciente]; 
DELETE FROM dbo.[Medico]; 
 
SET IDENTITY_INSERT dbo.[Paciente] ON
INSERT INTO dbo.[Paciente]([Id], [Nombre], [Apellidos], [FechaNacimiento], [Residencia], [Altura], [Peso],
[PresionArterial]) VALUES    (1, 'Popstar', 'Potata', '1990-10-10', 'San Pedro', 1.5, 50.1, NULL),
(2, 'Arven', 'Arijas', '1980-10-11', 'Heredia', 1.7, 70, 80),
(3, 'Andrea', 'Ledezma', '1997-09-19', 'Santa Ana', 1.7, 80, NULL); 
SET IDENTITY_INSERT dbo.[Paciente] OFF 
 
SET IDENTITY_INSERT dbo.[Medico] ON INSERT INTO dbo.[Medico]([Id], [Nombre], [Apellidos], [Especialidad],
[Oficina]) VALUES    (1, 'Andrea', 'Salas', 'Otorino', 111), 
 (2, 'Steriel', 'Guzman', 'General', 101),      (3, 'Adrían', 'Ramires', 'General', 100); 
SET IDENTITY_INSERT dbo.[Medico] OFF 
 
INSERT INTO dbo.[Consulta]([IdPaciente], [IdMedico], [Fecha], [Sintomas], [Diagnostico]) VALUES    (1, 1,
'2019-10-10', 'Dolor de cabeza', 'Migraña'),      (2, 3, '2019-04-11', 'Vómito y diarrea', 'Indigestión'),
(3, 2, '2019-03-09', 'Desmayos', 'Sin diagnostico');