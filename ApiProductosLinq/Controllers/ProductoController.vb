Imports Microsoft.AspNetCore.Mvc
Imports ApiProductosLinq.DTOs
Imports ApiProductosLinq.Services

Namespace Controllers

    <ApiController>
    <Route("api/producto")>
    Public Class ProductoController
        Inherits ControllerBase

        Private ReadOnly _service As IProductoService

        Public Sub New(service As IProductoService)
            _service = service
        End Sub

        <HttpGet("categoria/{categoriaId:int}")>
        Public Async Function GetByCategoria(categoriaId As Integer) As Task(Of IActionResult)
            Dim productos As IEnumerable(Of ProductoResponseDTO) = Await _service.GetByCategoriaIdAsync(categoriaId)
            If productos Is Nothing Then
                Return NotFound($"La categoria con id {categoriaId} no existe.")
            End If
            Return Ok(productos)
        End Function

    End Class

End Namespace
