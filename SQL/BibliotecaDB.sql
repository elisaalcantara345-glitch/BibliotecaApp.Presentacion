/* ============================================================
   PROYECTO: SISTEMA DE GESTIÓN DE BIBLIOTECA
   Base de datos: BibliotecaDB
   Motor: Microsoft SQL Server 2025
   Script limpio para instalación en Windows
   ============================================================ */

/* 1. CREAR BASE DE DATOS */
IF DB_ID(N'BibliotecaDB') IS NULL
BEGIN
    CREATE DATABASE BibliotecaDB;
END
GO

USE BibliotecaDB;
GO

/* 2. TABLA AUTORES */
CREATE TABLE dbo.Autores (
    IdAutor INT IDENTITY(1,1) NOT NULL,
    Codigo VARCHAR(20) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Nacionalidad VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    CONSTRAINT PK_Autores PRIMARY KEY (IdAutor),
    CONSTRAINT UQ_Autores_Codigo UNIQUE (Codigo)
);
GO

/* 3. TABLA CATEGORIAS */
CREATE TABLE dbo.Categorias (
    IdCategoria INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(150) NULL,
    CONSTRAINT PK_Categorias PRIMARY KEY (IdCategoria),
    CONSTRAINT UQ_Categorias_Nombre UNIQUE (Nombre)
);
GO

/* 4. TABLA USUARIOS */
CREATE TABLE dbo.Usuarios (
    IdUsuario INT IDENTITY(1,1) NOT NULL,
    Documento VARCHAR(20) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Correo VARCHAR(100) NOT NULL,
    ProgramaAcademico VARCHAR(100) NOT NULL,
    CONSTRAINT PK_Usuarios PRIMARY KEY (IdUsuario),
    CONSTRAINT UQ_Usuarios_Documento UNIQUE (Documento)
);
GO

/* 5. TABLA LIBROS */
CREATE TABLE dbo.Libros (
    IdLibro INT IDENTITY(1,1) NOT NULL,
    Codigo VARCHAR(20) NOT NULL,
    ISBN VARCHAR(20) NOT NULL,
    Titulo VARCHAR(150) NOT NULL,
    AnioPublicacion INT NOT NULL,
    Cantidad INT NOT NULL,
    CantidadDisponible INT NOT NULL,
    IdAutor INT NOT NULL,
    IdCategoria INT NOT NULL,
    CONSTRAINT PK_Libros PRIMARY KEY (IdLibro),
    CONSTRAINT UQ_Libros_Codigo UNIQUE (Codigo),
    CONSTRAINT UQ_Libros_ISBN UNIQUE (ISBN),
    CONSTRAINT CK_Libros_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT CK_Libros_Disponible CHECK (
        CantidadDisponible >= 0 AND CantidadDisponible <= Cantidad
    ),
    CONSTRAINT FK_Libros_Autores FOREIGN KEY (IdAutor)
        REFERENCES dbo.Autores(IdAutor),
    CONSTRAINT FK_Libros_Categorias FOREIGN KEY (IdCategoria)
        REFERENCES dbo.Categorias(IdCategoria)
);
GO

/* 6. TABLA PRESTAMOS */
CREATE TABLE dbo.Prestamos (
    IdPrestamo INT IDENTITY(1,1) NOT NULL,
    IdUsuario INT NOT NULL,
    FechaPrestamo DATE NOT NULL,
    FechaDevolucionEsperada DATE NOT NULL,
    FechaDevolucionReal DATE NULL,
    Estado VARCHAR(20) NOT NULL,
    CONSTRAINT PK_Prestamos PRIMARY KEY (IdPrestamo),
    CONSTRAINT CK_Prestamos_Estado CHECK (
        Estado IN ('Prestado', 'Devuelto', 'Atrasado')
    ),
    CONSTRAINT FK_Prestamos_Usuarios FOREIGN KEY (IdUsuario)
        REFERENCES dbo.Usuarios(IdUsuario)
);
GO

/* 7. TABLA DETALLE DE PRESTAMOS */
CREATE TABLE dbo.DetallePrestamos (
    IdDetalle INT IDENTITY(1,1) NOT NULL,
    IdPrestamo INT NOT NULL,
    IdLibro INT NOT NULL,
    Cantidad INT NOT NULL,
    CONSTRAINT PK_DetallePrestamos PRIMARY KEY (IdDetalle),
    CONSTRAINT CK_DetallePrestamos_Cantidad CHECK (Cantidad > 0),
    CONSTRAINT FK_DetallePrestamos_Prestamos FOREIGN KEY (IdPrestamo)
        REFERENCES dbo.Prestamos(IdPrestamo),
    CONSTRAINT FK_DetallePrestamos_Libros FOREIGN KEY (IdLibro)
        REFERENCES dbo.Libros(IdLibro)
);
GO

/* ============================================================
   8. DATOS DE PRUEBA
   ============================================================ */

INSERT INTO dbo.Categorias (Nombre, Descripcion)
VALUES
('Programación', 'Libros sobre programación y desarrollo de software'),
('Bases de Datos', 'Libros sobre bases de datos y SQL'),
('Redes', 'Libros sobre redes y comunicaciones'),
('Matemáticas', 'Libros de matemáticas'),
('Electrónica', 'Libros sobre electrónica'),
('Inteligencia Artificial', 'Libros sobre inteligencia artificial'),
('Otros', 'Otros temas académicos');
GO

INSERT INTO dbo.Autores
    (Codigo, Nombre, Apellidos, Nacionalidad, FechaNacimiento)
VALUES
('AUT001', 'Robert', 'Martin', 'Estadounidense', '1952-12-05'),
('AUT002', 'Abraham', 'Silberschatz', 'Estadounidense', '1952-07-01'),
('AUT003', 'Andrew', 'Tanenbaum', 'Estadounidense', '1944-03-16'),
('AUT004', 'Stuart', 'Russell', 'Británico', '1962-03-01');
GO

INSERT INTO dbo.Usuarios
    (Documento, Nombre, Apellidos, Telefono, Correo, ProgramaAcademico)
VALUES
('1001001001', 'Laura', 'Gomez', '3001112233', 'laura.gomez@correo.com', 'Ingeniería de Sistemas'),
('1001001002', 'Carlos', 'Rodriguez', '3012223344', 'carlos.rodriguez@correo.com', 'Ingeniería de Software'),
('1001001003', 'Sofia', 'Martinez', '3023334455', 'sofia.martinez@correo.com', 'Matemáticas'),
('1001001004', 'Daniel', 'Torres', '3034445566', 'daniel.torres@correo.com', 'Ingeniería Electrónica'),
('1001001005', 'Valentina', 'Perez', '3045556677', 'valentina.perez@correo.com', 'Inteligencia Artificial');
GO

INSERT INTO dbo.Libros
    (Codigo, ISBN, Titulo, AnioPublicacion, Cantidad, CantidadDisponible, IdAutor, IdCategoria)
VALUES
('LIB001', '9780132350884', 'Clean Code', 2008, 5, 5, 1, 1),
('LIB002', '9780073523323', 'Fundamentos de Bases de Datos', 2019, 4, 4, 2, 2),
('LIB003', '9780132126953', 'Computer Networks', 2010, 3, 3, 3, 3),
('LIB004', '9780132098545', 'Artificial Intelligence', 2015, 4, 4, 4, 6),
('LIB005', '9780262033848', 'Introduction to Algorithms', 2009, 3, 3, 1, 1),
('LIB006', '9780131103627', 'The Art of Electronics', 2015, 2, 2, 3, 5),
('LIB007', '9780201616224', 'Matemáticas para Ingeniería', 2018, 5, 5, 2, 4),
('LIB008', '9780134685991', 'Effective Java', 2018, 4, 4, 1, 1);
GO

/*
   Registro de un préstamo de prueba ya DEVUELTO.
   Se conserva para demostrar el historial de préstamos.
   La disponibilidad de LIB001 queda nuevamente en 5.
*/
DECLARE @IdPrestamo INT;

INSERT INTO dbo.Prestamos
    (IdUsuario, FechaPrestamo, FechaDevolucionEsperada,
     FechaDevolucionReal, Estado)
VALUES
(
    (SELECT IdUsuario FROM dbo.Usuarios WHERE Documento = '1001001001'),
    '2026-09-11',
    '2026-09-18',
    '2026-09-11',
    'Devuelto'
);

SET @IdPrestamo = SCOPE_IDENTITY();

INSERT INTO dbo.DetallePrestamos
    (IdPrestamo, IdLibro, Cantidad)
VALUES
(
    @IdPrestamo,
    (SELECT IdLibro FROM dbo.Libros WHERE Codigo = 'LIB001'),
    1
);
GO

/* ============================================================
   9. CONSULTAS DE VERIFICACION
   ============================================================ */

-- Ver tablas creadas
SELECT TABLE_NAME AS Tabla
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO

-- Ver claves foraneas
SELECT
    fk.name AS Relacion,
    OBJECT_NAME(fk.parent_object_id) AS TablaOrigen,
    OBJECT_NAME(fk.referenced_object_id) AS TablaDestino
FROM sys.foreign_keys fk
ORDER BY TablaOrigen, TablaDestino;
GO

-- Ver restricciones CHECK
SELECT
    name AS Restriccion,
    OBJECT_NAME(parent_object_id) AS Tabla
FROM sys.check_constraints
ORDER BY Tabla, Restriccion;
GO

-- Libros disponibles
SELECT
    Codigo,
    Titulo,
    Cantidad,
    CantidadDisponible
FROM dbo.Libros
WHERE CantidadDisponible > 0
ORDER BY Titulo;
GO

-- Libros con autor y categoria
SELECT
    L.Codigo,
    L.Titulo,
    A.Nombre + ' ' + A.Apellidos AS Autor,
    C.Nombre AS Categoria,
    L.Cantidad,
    L.CantidadDisponible
FROM dbo.Libros L
INNER JOIN dbo.Autores A ON L.IdAutor = A.IdAutor
INNER JOIN dbo.Categorias C ON L.IdCategoria = C.IdCategoria
ORDER BY L.Codigo;
GO

-- Historial de prestamos
SELECT
    P.IdPrestamo,
    U.Documento,
    U.Nombre + ' ' + U.Apellidos AS Usuario,
    L.Codigo AS CodigoLibro,
    L.Titulo,
    DP.Cantidad,
    P.FechaPrestamo,
    P.FechaDevolucionEsperada,
    P.FechaDevolucionReal,
    P.Estado
FROM dbo.Prestamos P
INNER JOIN dbo.Usuarios U ON P.IdUsuario = U.IdUsuario
INNER JOIN dbo.DetallePrestamos DP ON P.IdPrestamo = DP.IdPrestamo
INNER JOIN dbo.Libros L ON DP.IdLibro = L.IdLibro
ORDER BY P.FechaPrestamo DESC;
GO

-- Usuarios con prestamos activos
SELECT
    U.Documento,
    U.Nombre + ' ' + U.Apellidos AS Usuario,
    COUNT(P.IdPrestamo) AS PrestamosActivos
FROM dbo.Usuarios U
INNER JOIN dbo.Prestamos P ON U.IdUsuario = P.IdUsuario
WHERE P.Estado = 'Prestado'
GROUP BY U.Documento, U.Nombre, U.Apellidos
ORDER BY PrestamosActivos DESC;
GO

-- Cantidad de libros por categoria
SELECT
    C.Nombre AS Categoria,
    COUNT(L.IdLibro) AS CantidadLibros
FROM dbo.Categorias C
LEFT JOIN dbo.Libros L ON C.IdCategoria = L.IdCategoria
GROUP BY C.IdCategoria, C.Nombre
ORDER BY C.Nombre;
GO

-- Cantidad de ejemplares actualmente prestados
SELECT
    COALESCE(SUM(DP.Cantidad), 0) AS CantidadLibrosPrestados
FROM dbo.Prestamos P
INNER JOIN dbo.DetallePrestamos DP ON P.IdPrestamo = DP.IdPrestamo
WHERE P.Estado = 'Prestado';
GO

/* ============================================================
   FIN DEL SCRIPT
   ============================================================ */
