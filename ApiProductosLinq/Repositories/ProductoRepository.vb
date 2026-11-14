Imports Microsoft.EntityFrameworkCore
Imports ApiProductosLinq.Data
Imports ApiProductosLinq.DTOs

Namespace Repositories

    Public Class ProductoRepository
        Implements IProductoRepository

        Private ReadOnly _context As AppDbContext

        Public Sub New(context As AppDbContext)
            _context = context
        End Sub

        Public Async Function GetByCategoriaIdAsync(categoriaId As Integer) As Task(Of IEnumerable(Of ProductoResponseDTO)) Implements IProductoRepository.GetByCategoriaIdAsync
            Dim productos As List(Of ProductoResponseDTO) = Await _context.Productos _
                .AsNoTracking() _
                .Where(Function(p) p.CategoriaId = categoriaId) _
                .OrderBy(Function(p) p.Id) _
                .Select(Function(p) New ProductoResponseDTO With {
                    .Id = p.Id,
                    .Nombre = p.Nombre,
                    .Precio = p.Precio,
                    .CategoriaId = p.CategoriaId,
                    .CategoriaNombre = p.Categoria.Nombre
                }) _
                .ToListAsync()
            Return productos
        End Function

    End Class

End Namespace
