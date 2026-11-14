Imports ApiProductosLinq.DTOs
Imports ApiProductosLinq.Repositories

Namespace Services

    Public Class ProductoService
        Implements IProductoService

        Private ReadOnly _productoRepository As IProductoRepository
        Private ReadOnly _categoriaRepository As ICategoriaRepository

        Public Sub New(productoRepository As IProductoRepository, categoriaRepository As ICategoriaRepository)
            _productoRepository = productoRepository
            _categoriaRepository = categoriaRepository
        End Sub

        Public Async Function GetByCategoriaIdAsync(categoriaId As Integer) As Task(Of IEnumerable(Of ProductoResponseDTO)) Implements IProductoService.GetByCategoriaIdAsync
            Dim existe As Boolean = Await _categoriaRepository.ExisteAsync(categoriaId)
            If Not existe Then
                Return Nothing
            End If

            Return Await _productoRepository.GetByCategoriaIdAsync(categoriaId)
        End Function

    End Class

End Namespace
