Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models

    <Table("Categorias")>
    Public Class Categoria

        <Key>
        <Column("Id")>
        Public Property Id As Integer

        <Required>
        <StringLength(100)>
        <Column("Nombre")>
        Public Property Nombre As String

        Public Property Productos As ICollection(Of Producto) = New List(Of Producto)()

    End Class

End Namespace
