Imports System.Data.OleDb

Module Module1
    Public koneksi As OleDbConnection
    Public cmd As OleDbCommand
    Public adaptor As OleDbDataAdapter
    Public baca As OleDbDataReader
    Public data As DataSet
    Public str As String

    Sub buka()
        koneksi = New OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=Database_internal.accdb")
        koneksi.Open()
    End Sub
End Module

