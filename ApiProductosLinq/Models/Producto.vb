Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models

    <Table("Productos")>
    Public Class Producto

        <Key>
        <Column("Id")>
        Public Property Id As Integer

        <Required>
        <StringLength(100)>
        <Column("Nombre")>
        Public Property Nombre As String

        <Column("Precio", TypeName:="decimal(18,2)")>
        Public Property Precio As Decimal

        <Column("CategoriaId")>
        Public Property CategoriaId As Integer

        <ForeignKey("CategoriaId")>
        Public Property Categoria As Categoria

    End Class

End Namespace
