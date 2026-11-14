Imports Microsoft.EntityFrameworkCore
Imports ApiProductosLinq.Models

Namespace Data

    Public Class AppDbContext
        Inherits DbContext

        Public Sub New(options As DbContextOptions(Of AppDbContext))
            MyBase.New(options)
        End Sub

        Public Property Categorias As DbSet(Of Categoria)
        Public Property Productos As DbSet(Of Producto)

        Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

            modelBuilder.Entity(Of Categoria)().ToTable("Categorias")
            modelBuilder.Entity(Of Producto)().ToTable("Productos")

            modelBuilder.Entity(Of Producto)() _
                .HasOne(Function(p) p.Categoria) _
                .WithMany(Function(c) c.Productos) _
                .HasForeignKey(Function(p) p.CategoriaId)
        End Sub

    End Class

End Namespace
