Imports ApiProductosLinq.DTOs

Namespace Repositories

    Public Interface IProductoRepository

        Function GetByCategoriaIdAsync(categoriaId As Integer) As Task(Of IEnumerable(Of ProductoResponseDTO))

    End Interface

End Namespace
