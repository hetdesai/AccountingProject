Imports System.Data.OleDb
Public Class frmorderedreports
    Dim da As New OleDbDataAdapter
    Dim sql As String

    Private Sub frmorderedreports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Connect()
        Dim ds As New DataSet1
        Dim str As String
        str = "ID"
        If ComboBox1.Text = "First Name" Then
            str = "St_FName"
        ElseIf ComboBox1.Text = "Last Name" Then
            str = "St_SName"
        ElseIf ComboBox1.Text = "IT ID" Then
            str = "ID"
        ElseIf ComboBox1.Text = "School" Then
            str = "SchoolName"
        End If
        da = New OleDbDataAdapter("Select * from tblStudentInfo order by " & str, cn)
        da.Fill(ds, "tblStudentInfo")
        Dim rpt As New rptordered
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
        Close1()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged
        Connect()
        Dim ds As New DataSet1
        Dim str As String
        str = "ID"
        If ComboBox1.Text = "First Name" Then
            str = "St_FName"
        ElseIf ComboBox1.Text = "Last Name" Then
            str = "St_SName"
        ElseIf ComboBox1.Text = "IT ID" Then
            str = "ID"
        ElseIf ComboBox1.Text = "School" Then
            str = "SchoolName"
        End If
        da = New OleDbDataAdapter("Select * from tblStudentInfo order by " & str & " " & ComboBox2.Text, cn)
        da.Fill(ds, "tblStudentInfo")
        Dim rpt As New rptordered
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
        Close1()
    End Sub
End Class