IF DB_ID(N'ProductosLinqDB') IS NULL
BEGIN
    CREATE DATABASE ProductosLinqDB;
END
GO

USE ProductosLinqDB;
GO

IF OBJECT_ID(N'dbo.Categorias', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categorias (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL
    );
END
GO

IF OBJECT_ID(N'dbo.Productos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Nombre VARCHAR(100) NOT NULL,
        Precio DECIMAL(18,2) NOT NULL,
        CategoriaId INT NOT NULL,
        CONSTRAINT FK_Productos_Categorias FOREIGN KEY (CategoriaId) REFERENCES dbo.Categorias(Id)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Categorias)
BEGIN
    INSERT INTO dbo.Categorias (Nombre) VALUES ('Electronica'), ('Hogar'), ('Juguetes'), ('Libros');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Productos)
BEGIN
    INSERT INTO dbo.Productos (Nombre, Precio, CategoriaId) VALUES
        ('Auriculares Bluetooth', 15999.90, 1),
        ('Teclado Mecanico', 28500.00, 1),
        ('Licuadora', 32000.50, 2),
        ('Juego de Sabanas', 18750.00, 2),
        ('Lampara de Mesa', 9990.00, 2);
END
GO
