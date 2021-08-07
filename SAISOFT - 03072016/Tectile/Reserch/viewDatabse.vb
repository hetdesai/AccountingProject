Imports System.Data.SqlClient
Public Class viewDatabse

    Private Sub viewDatabse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        connect()
        myfilldatagrid(DataGridView1, TextBox1.Text)
        close1()

    End Sub
End Class