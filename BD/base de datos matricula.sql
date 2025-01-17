/****** Object:  Database [matricula-universidad-db]    Script Date: 27/4/2024 22:33:23 ******/
CREATE DATABASE [matricula-universidad-db]  (EDITION = 'GeneralPurpose', SERVICE_OBJECTIVE = 'GP_S_Gen5_1', MAXSIZE = 32 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [matricula-universidad-db] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [matricula-universidad-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [matricula-universidad-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [matricula-universidad-db] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [matricula-universidad-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [matricula-universidad-db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [matricula-universidad-db] SET  MULTI_USER 
GO
ALTER DATABASE [matricula-universidad-db] SET ENCRYPTION ON
GO
ALTER DATABASE [matricula-universidad-db] SET QUERY_STORE = ON
GO
ALTER DATABASE [matricula-universidad-db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[IdCarrera] [int] IDENTITY(1,1) NOT NULL,
	[Carrera] [varchar](150) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[IdCarrera] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[IdEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[Identificacion] [varchar](20) NOT NULL,
	[TipoIdentificacion] [varchar](20) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[IdCarrera] [int] NOT NULL,
	[EstadoEstudiante] [varchar](20) NOT NULL,
	[IdUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[IdGrupo] [int] IDENTITY(1,1) NOT NULL,
	[IdMateria] [int] NOT NULL,
	[NumeroGrupo] [int] NOT NULL,
	[Horario] [varchar](100) NOT NULL,
	[Capacidad] [int] NOT NULL,
	[Estado] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[IdMateria] [int] IDENTITY(1,1) NOT NULL,
	[IdCarrera] [int] NOT NULL,
	[Materia] [varchar](150) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CantidadCreditos] [int] NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[IdMateria] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[IdMatricula] [int] IDENTITY(1,1) NOT NULL,
	[IdGrupo] [int] NOT NULL,
	[IdEstudiante] [int] NOT NULL,
	[FechaMatricula] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMatricula] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Estudiante] ADD  DEFAULT ('Activo') FOR [EstadoEstudiante]
GO
ALTER TABLE [dbo].[Matricula] ADD  DEFAULT (getdate()) FOR [FechaMatricula]
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carrera] ([IdCarrera])
GO
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Estudiante] CHECK CONSTRAINT [FK_Estudiante_Usuario]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([IdMateria])
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD  CONSTRAINT [FK_Materia_Carrera] FOREIGN KEY([IdCarrera])
REFERENCES [dbo].[Carrera] ([IdCarrera])
GO
ALTER TABLE [dbo].[Materia] CHECK CONSTRAINT [FK_Materia_Carrera]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([IdGrupo])
GO
/****** Object:  StoredProcedure [dbo].[spActualizarCarrera]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spActualizarCarrera]
    @IdCarrera INT,
    @NuevoNombre VARCHAR(150),
    @NuevoEstado INT
AS
BEGIN
    UPDATE Carrera
    SET Carrera = @NuevoNombre,
        Estado = @NuevoEstado
    WHERE IdCarrera = @IdCarrera;
END;
GO
/****** Object:  StoredProcedure [dbo].[spActualizarMateria]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spActualizarMateria]
    @IdMateria INT,
    @NuevoNombre VARCHAR(150)
AS
BEGIN
    UPDATE Materia
    SET Materia = @NuevoNombre
    WHERE IdMateria = @IdMateria;
END;
GO
/****** Object:  StoredProcedure [dbo].[spAgregarGrupo]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAgregarGrupo]
@IdMateria INT,
@NumeroGrupo INT,
@Horario VARCHAR(100),
@Capacidad INT,
@Estado VARCHAR(20)
AS
BEGIN
    INSERT INTO Grupo (IdMateria, NumeroGrupo, Horario, Capacidad, Estado)
    VALUES (@IdMateria, @NumeroGrupo, @Horario, @Capacidad, @Estado);
END
GO
/****** Object:  StoredProcedure [dbo].[spAutenticaUsuario]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAutenticaUsuario]
    @Usuario VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar las credenciales del usuario
    SELECT IdUsuario, Usuario, IdRol
    FROM Usuarios
    WHERE Usuario = @Usuario AND Password = @Password;
END
GO
/****** Object:  StoredProcedure [dbo].[spBuscarEstudiantePorIdentificacion]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spBuscarEstudiantePorIdentificacion]
@Identificacion VARCHAR(20)
AS
BEGIN
    SELECT * FROM Estudiante
    WHERE Identificacion = @Identificacion;
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearCarrera]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCrearCarrera]
    @Carrera VARCHAR(150),
	@Estado INT
AS
BEGIN
    INSERT INTO Carrera (Carrera, Estado)
    VALUES (@Carrera, @Estado);
END;
GO
/****** Object:  StoredProcedure [dbo].[spCrearEstudiante]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCrearEstudiante]
@Nombre VARCHAR(100),
@Apellidos VARCHAR(100),
@Identificacion VARCHAR(20),
@TipoIdentificacion VARCHAR(20),
@FechaNacimiento DATE,
@IdCarrera INT,
@EstadoEstudiante VARCHAR(20)
AS
BEGIN
    INSERT INTO Estudiante (Nombre, Apellidos, Identificacion, TipoIdentificacion, FechaNacimiento, IdCarrera, EstadoEstudiante)
    VALUES (@Nombre, @Apellidos, @Identificacion, @TipoIdentificacion, @FechaNacimiento, @IdCarrera, @EstadoEstudiante);
END
GO
/****** Object:  StoredProcedure [dbo].[spCrearMateria]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spCrearMateria]
    @IdCarrera INT,
    @Materia VARCHAR(150)
AS
BEGIN
    INSERT INTO Materia (IdCarrera, Materia, Estado)
    VALUES (@IdCarrera, @Materia, 1);
END;
GO
/****** Object:  StoredProcedure [dbo].[SpGruposConMateria]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpGruposConMateria]
AS
BEGIN
    -- Realiza un join entre la tabla 'Grupo' y la tabla de materias
    SELECT 
        g.IdGrupo,
        g.IdMateria,
        m.Materia AS NombreMateria,  -- Aquí suponemos que la tabla de materias tiene un campo 'Nombre'
        g.NumeroGrupo,
        g.Horario,
        g.Capacidad,
        g.Estado
    FROM 
        dbo.Grupo g  -- Alias para la tabla 'Grupo'
    INNER JOIN 
        dbo.Materia m  -- Alias para la tabla 'Materia'
    ON 
        g.IdMateria = m.IdMateria  -- Relación entre 'Grupo' e 'IdMateria'
END
GO
/****** Object:  StoredProcedure [dbo].[spListarCarreras]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarCarreras]
AS
BEGIN
    SELECT
        c.IdCarrera,
        c.Carrera,
		c.Estado,
        COUNT(DISTINCT e.IdEstudiante) AS CantidadEstudiantes,
        COUNT(DISTINCT m.IdMateria) AS CantidadMaterias
    FROM 
        Carrera c
    LEFT JOIN 
        Estudiante e ON c.IdCarrera = e.IdCarrera
    LEFT JOIN 
        Materia m ON c.IdCarrera = m.IdCarrera
    GROUP BY 
        c.IdCarrera, c.Carrera, c.Estado;
END;
GO
/****** Object:  StoredProcedure [dbo].[spListarEstudiantes]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Crear el procedimiento almacenado para obtener todos los estudiantes
CREATE PROCEDURE [dbo].[spListarEstudiantes]
AS
BEGIN
    -- Seleccionar todos los registros de la tabla Estudiante
    -- Unión entre Estudiante y Carrera para obtener el nombre de la carrera
       SELECT 
        est.[IdEstudiante], 
        est.[Nombre], 
        est.[Apellidos], 
        est.[Identificacion], 
        est.[TipoIdentificacion], 
        est.[FechaNacimiento], 
        est.[IdCarrera], 
        est.[EstadoEstudiante], 
        mat.[IdMatricula], 
        mat.[IdGrupo], 
        mat.[FechaMatricula]
    FROM 
        [dbo].[Estudiante] AS est
    LEFT JOIN 
        [dbo].[Matricula] AS mat
    ON 
        est.[IdEstudiante] = mat.[IdEstudiante];
END
GO
/****** Object:  StoredProcedure [dbo].[spListarGruposDisponiblesPorEstudianteYMateria]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarGruposDisponiblesPorEstudianteYMateria]
@IdEstudiante INT,
@IdMateria INT
AS
BEGIN
    SELECT G.IdGrupo, G.NumeroGrupo, G.Horario, G.Capacidad
    FROM Grupo G
    INNER JOIN Materia M ON G.IdMateria = M.IdMateria
    WHERE M.IdMateria = @IdMateria
    AND (SELECT COUNT(*) FROM Matricula WHERE IdGrupo = G.IdGrupo) < G.Capacidad
    AND NOT EXISTS (SELECT 1 FROM Matricula WHERE IdEstudiante = @IdEstudiante AND IdGrupo = G.IdGrupo);
END
GO
/****** Object:  StoredProcedure [dbo].[spListarMaterias]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarMaterias]
AS
BEGIN
    SELECT 
        M.IdMateria,
        M.Materia,
        C.Carrera,
        M.CantidadCreditos,
        M.IdCarrera,  -- Agregando el IdCarrera
        M.Estado  -- Agregando el estado
    FROM 
        Materia M
    INNER JOIN 
        Carrera C 
    ON 
        M.IdCarrera = C.IdCarrera;
END
GO
/****** Object:  StoredProcedure [dbo].[spListarMateriasParaMatricularPorEstudiante]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[spListarMateriasParaMatricularPorEstudiante]
(
    -- Add the parameters for the stored procedure here
    @IdEstudiante INT
)
AS
BEGIN
  select e.IdEstudiante, m.Materia, m.CantidadCreditos, g.IdGrupo, G.NumeroGrupo, g.Horario from Estudiante e 
  inner join Carrera c on c.IdCarrera = e.IdCarrera
  inner join Materia m on m.IdCarrera = c.IdCarrera
  inner join Grupo g on g.IdMateria = m.IdMateria
  where e.IdEstudiante = @IdEstudiante
END
GO
/****** Object:  StoredProcedure [dbo].[spListarMateriasPorCarrera]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spListarMateriasPorCarrera]
    @IdCarrera INT
AS
BEGIN
    SELECT IdMateria, Materia
    FROM Materia
    WHERE IdCarrera = @IdCarrera;
END;
GO
/****** Object:  StoredProcedure [dbo].[spMatricularEstudianteEnGrupo]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMatricularEstudianteEnGrupo]
@IdEstudiante INT,
@IdGrupo INT
AS
BEGIN
    INSERT INTO Matricula (IdGrupo, IdEstudiante, FechaMatricula)
    VALUES (@IdGrupo, @IdEstudiante, GETDATE());
END
GO
/****** Object:  StoredProcedure [dbo].[spObtenerCarreraPorId]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spObtenerCarreraPorId]
	@IdCarrera INT
AS
BEGIN
    SELECT IdCarrera, Carrera, Estado
    FROM Carrera
    WHERE IdCarrera = @IdCarrera;
END;
GO
/****** Object:  StoredProcedure [dbo].[spObtenerEstudiantePorIdUsuario]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spObtenerEstudiantePorIdUsuario]
    @IdUsuario INT
AS
BEGIN
    SELECT *
    FROM Estudiante
    WHERE IdUsuario = @IdUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[spObtenerMatriculaPorIdEstudiante]    Script Date: 27/4/2024 22:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[spObtenerMatriculaPorIdEstudiante]
(
    -- Add the parameters for the stored procedure here
    @IdEstudiante INT
)
AS
BEGIN
  select g.NumeroGrupo, m.FechaMatricula, mt.Materia, g.Horario, mt.CantidadCreditos, g.IdGrupo
  from Matricula m
  inner join Grupo g on g.IdGrupo = m.IdGrupo
  inner join Materia mt on mt.IdMateria = g.IdMateria
  where m.IdEstudiante = @IdEstudiante;
END
GO
ALTER DATABASE [matricula-universidad-db] SET  READ_WRITE 
GO
