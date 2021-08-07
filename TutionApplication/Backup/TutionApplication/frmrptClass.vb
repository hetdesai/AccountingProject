Imports System.Data.OleDb
Public Class frmrptClass

    Private Sub frmrptClass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Class wise Report"
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader
        Connect()
        cmd = New OleDbCommand("Select * from tblSchool", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            TextBox3.AutoCompleteCustomSource.Add(dr.Item(1))
        End While
        dr.Close()
        Close1()
        TextBox1.Text = Today.Year
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim formula As String = " and "
        If TextBox1.Text.Trim.Length <> 0 Then
            formula = "{tblStudentInfo.Year1} = " & TextBox1.Text & " and "
        End If
        If TextBox2.Text.Trim.Length <> 0 Then
            formula = formula & "{tblStudentInfo.Sem} = " & TextBox2.Text & " and "
        End If
        If TextBox3.Text.Trim.Length <> 0 Then
            formula = formula & "{tblStudentInfo.SchoolName} = '" & TextBox3.Text & "' and "
        End If
        formula = formula.Substring(0, formula.Length - 5)
        CrystalReportViewer1.SelectionFormula = formula
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class