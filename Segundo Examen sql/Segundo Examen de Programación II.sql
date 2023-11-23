/*
     //Segundo Examen de Programación II: Mantenimiento de tres tablas:  Equipos, Usuarios y tecnicos 
     //Estudiante: José Pablo Muñoz Zúñiga
     //Carrera: Ingeniería Informática
     //Materia: Programación II 
*/

/*En esta parte se crea la base de datos*/

CREATE DATABASE SEGUNDOEXAMENDEPROGRAMACIONII
GO

/*En esta parte tiene la funcion para denominar una base externa como base de datos actual*/

USE SEGUNDOEXAMENDEPROGRAMACIONII
GO

/*En esta parte se crea la tabla de equipos*/

CREATE TABLE Equipos
(
    EquipoID int identity(1,1), 
	TipoEquipo varchar(50) NOT NULL,
	CONSTRAINT pk_idequipos PRIMARY KEY(EquipoID)
)
GO

/*En esta parte se crea la tabla de usuarios*/

CREATE TABLE Usuarios
(
    UsuarioID int identity(1000,5),
	Nombre int,
	CorreoElectronico varchar(100) NOT NULL,
	CONSTRAINT pk_idusuarios PRIMARY KEY (UsuarioID),
	CONSTRAINT fk_idequipos FOREIGN KEY (Nombre) REFERENCES equipos (EquipoID)
)
GO

/*En esta parte se crea la tabla de tecnicos*/

CREATE TABLE Tecnicos
(
    TecnicoID int identity(10,15),
	Nombre int,
	Especialidad varchar(105) NOT NULL,
	CONSTRAINT pk_idtecnicos PRIMARY KEY (TecnicoID),
	CONSTRAINT fk_idequipos1 FOREIGN KEY (Nombre) REFERENCES equipos (EquipoID)
)
GO

/*En esta parte se crea la tabla de reparaciones*/

CREATE TABLE Reparaciones
(
    ReparacionID int identity(1001,35),
	EquipoID int,
	FechaSolicitud datetime constraint df_fecha2 DEFAULT GETDATE(),
	Estado varchar(200) NOT NULL,
	CONSTRAINT pk_idrepaciones PRIMARY KEY (ReparacionID),
	CONSTRAINT fk_idequipos2 FOREIGN KEY (EquipoID) REFERENCES equipos (EquipoID)
)
GO

/*En esta parte se crea la tabla de detalles reparacion*/

CREATE TABLE DetallesReparacion
(
    DetalleID int identity(1002,143),
	ReparacionID int,
	Descripcion varchar(103) NOT NULL,
	FechaInicio datetime constraint df_fecha3 DEFAULT GETDATE(),
	FechaFin datetime constraint df_fecha5 DEFAULT GETDATE(),
	CONSTRAINT pk_iddetallesreparacion PRIMARY KEY (DetalleID),
	CONSTRAINT fk_idequipos3 FOREIGN KEY (ReparacionID) REFERENCES equipos (EquipoID)
)
GO

/*En esta parte se crea la tabla de asignaciones*/

CREATE TABLE Asignaciones
(
    AsignacionID int identity(120,35),
	ReparacionID int,
	TecnicosID int,
	FechaAsignacion datetime constraint df_fecha4 DEFAULT GETDATE(),
	CONSTRAINT pk_idasignaciones PRIMARY KEY (AsignacionID),
	CONSTRAINT fk_idequipos4 FOREIGN KEY (TecnicosID) REFERENCES equipos (EquipoID)
)
GO

-- PROCEDIMIENTOS ALMACENADOS, STORE PROCEDURE, SP, PA

/*En esta parte sirve para agregar equipos*/

CREATE PROCEDURE AGREGAREquipos
@TIPOEQUIPO VARCHAR(100)
  AS
    BEGIN
	    INSERT INTO Equipos (TipoEquipo) VALUES (@TIPOEQUIPO)
	END
GO

/*En esta parte sirve para borrar equipos*/

CREATE PROCEDURE BORRARequipos
@CODIGO INT
   AS    
     BEGIN
	     DELETE Equipos WHERE EquipoID =@CODIGO
	 END
GO

/*En esta parte sirve consultar equipos*/

CREATE PROCEDURE CONSULTAEquipos
  AS
    BEGIN
	  SELECT * FROM Equipos
	END
GO

/*En esta parte es la segunda programacion de consultar equipos para que el programa funcione correctamente*/

CREATE PROCEDURE CONSULTAEquipos_FILTRO
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Equipos WHERE EquipoID = @CODIGO
	END
GO

/*En esta parte sirve para actualizar los equipos*/

CREATE PROCEDURE MODIFICARequipos
@CODIGO INT,
@TIPOEQUIPO VARCHAR (107)
    AS    
      BEGIN
	    UPDATE Equipos SET TipoEquipo=@TIPOEQUIPO WHERE EquipoID  =@CODIGO
	  END
GO

/*En esta parte sirve para agregar usuarios*/

CREATE PROCEDURE AGREGARUsuarios
@CORREOELECTRONICO VARCHAR(100)
  AS
    BEGIN
	    INSERT INTO Usuarios (CorreoElectronico) VALUES (@CORREOELECTRONICO)
	END
GO

/*En esta parte sirve para borrar equipos*/

CREATE PROCEDURE BORRARusuarios
@CODIGO INT
  AS    
    BEGIN
	   DELETE Usuarios WHERE UsuarioID =@CODIGO
	END
GO

/*En esta parte sirve para actualizar los equipos*/

CREATE PROCEDURE MODIFICARusuarios
@CODIGO INT,
@CORREOELECTRONICO VARCHAR (107)
    AS    
      BEGIN
	    UPDATE Usuarios SET CorreoElectronico=@CORREOELECTRONICO WHERE UsuarioID  =@CODIGO
	  END
GO

/*En esta parte sirve consultar equipos*/

CREATE PROCEDURE CONSULTAUsuarios
  AS
    BEGIN
	  SELECT * FROM Usuarios
	END
GO

/*En esta parte es la segunda programacion de consultar usuarios para que el programa funcione correctamente*/

CREATE PROCEDURE CONSULTAUsuarios_FILTRO
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Usuarios WHERE UsuarioID = @CODIGO
	END
GO

/*En esta parte sirve para agregar tecnicos*/

CREATE PROCEDURE AGREGARTecnicos
@ESPECIALIDAD VARCHAR(150)
  AS
    BEGIN
	    INSERT INTO Tecnicos (Especialidad) VALUES (@ESPECIALIDAD)
	END
GO

/*En esta parte sirve para borrar equipos*/

CREATE PROCEDURE BORRARtecnicos
@CODIGO INT
   AS    
     BEGIN
	     DELETE Tecnicos WHERE TecnicoID =@CODIGO
	 END
GO

/*En esta parte sirve para actualizar los equipos*/

CREATE PROCEDURE MODIFICARtecnicos
@CODIGO INT,
@ESPECIALIDAD VARCHAR (107)
    AS    
      BEGIN
	    UPDATE Tecnicos SET Especialidad=@ESPECIALIDAD WHERE TecnicoID  = @CODIGO
	  END
GO

/*En esta parte sirve consultar equipos*/

CREATE PROCEDURE CONSULTATecnicos
  AS
    BEGIN
	  SELECT * FROM Tecnicos
	END
GO

/*En esta parte es la segunda programacion de consultar tecnicos para que el programa funcione correctamente*/

CREATE PROCEDURE CONSULTATecnicos_FILTRO
@CODIGO INT
  AS
    BEGIN
	  SELECT * FROM Tecnicos WHERE TecnicoID = @CODIGO
	END
GO

/*En esta parte se agregan dos equipos nuevos*/

INSERT INTO Equipos VALUES ('EQUIPO SE SOFTWARE'),('EQUIPO DE HARDWARE')
GO

/*En esta parte se agregan un primer usuario nuevo*/

EXEC AGREGARUsuarios 'Mario@gmail.com'

/*En esta parte se agregan un segundo usuario nuevo*/

EXEC AGREGARUsuarios 'Alexis@gmail.com'

/*En esta parte se agregan un primer usuario nuevo*/

EXEC AGREGARTecnicos 'TECNICO DE SISTEMAS'

/*En esta parte se agregan un segundo usuario nuevo*/

EXEC AGREGARTecnicos 'TECNICO DE SOFTWARE'




