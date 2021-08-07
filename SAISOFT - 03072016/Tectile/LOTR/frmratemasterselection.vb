Imports System.Data.SqlClient
Public Class frmratemasterselection

    Private Sub frmratemasterselection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select distinct pgroup from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox1.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct acname from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox2.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select mst from mst", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox5.AddItem(dr.Item(0))
            End While
            dr.Close()
            close1()
             Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmRateMaserEdit.Show()
    End Sub

    Private Sub Button1_KeyDown(sender As Object, e As KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class