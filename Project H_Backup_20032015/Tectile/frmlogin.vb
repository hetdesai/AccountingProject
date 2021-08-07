Imports System.Data.SqlClient
Public Class frmlogin

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '   connect()
        ' Dim cmd As New SqlCommand
        ' Dim dr As SqlDataReader
        'cmd = New SqlCommand("select * from tblUserpass where Username='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "' and TYPE='" & TextBox3.Text & "'", cn)
        '  dr = cmd.ExecuteReader
        '  If dr.HasRows Then
        frmMainScreen.Show()
        ' dr.Close()
        ' Else
        ' dr.Close()
        ' End If
        ' close1()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class