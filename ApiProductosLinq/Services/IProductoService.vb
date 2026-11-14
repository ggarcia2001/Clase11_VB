Imports ApiProductosLinq.DTOs

Namespace Services

    Public Interface IProductoService

        Function GetByCategoriaIdAsync(categoriaId As Integer) As Task(Of IEnumerable(Of ProductoResponseDTO))

    End Interface

End Namespace
