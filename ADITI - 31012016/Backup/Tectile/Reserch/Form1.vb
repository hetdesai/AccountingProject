Imports System.Data.SqlClient
Public Class Form1
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        connect()
            da = New SqlDataAdapter("Select * from tblPurchase,tblAccount where tblAccount.ACName=tblPurchase.NameCr", cn)
            da.Fill(ds, "tblPurchase_tb")

            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class