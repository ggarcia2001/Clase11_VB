Imports Microsoft.EntityFrameworkCore
Imports ApiProductosLinq.Data

Namespace Repositories

    Public Class CategoriaRepository
        Implements ICategoriaRepository

        Private ReadOnly _context As AppDbContext

        Public Sub New(context As AppDbContext)
            _context = context
        End Sub

        Public Async Function ExisteAsync(id As Integer) As Task(Of Boolean) Implements ICategoriaRepository.ExisteAsync
            Return Await _context.Categorias.AnyAsync(Function(c) c.Id = id)
        End Function

    End Class

End Namespace
