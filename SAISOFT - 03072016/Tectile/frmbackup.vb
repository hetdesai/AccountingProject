Imports System.Data
Imports System.IO
Public Class frmbackup
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Try
                cn.Open()
                cn.Close()
                '     System .IO .File. (Application.StartupPath & "\" & frmcomdis.companycode & "NewDb.mdf")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            System.IO.File.Copy(Application.StartupPath & "\" & frmcomdis.companycode & "NewDb.mdf", Application.StartupPath & "\backup\" & TextBox1.Text & ".mdf")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmbackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Date.Today & "BackUp"
    End Sub
End Class