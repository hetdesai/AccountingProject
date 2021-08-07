Public Class frmrptNormalReport

    Private Sub frmrptNormalReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Normal Report"
        TextBox1.Text = Today.Year
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim formula As String
        If TextBox1.Text.Trim.Length <> 0 Then
            formula = "{tblStudentInfo.Year1} =" & TextBox1.Text & " and "
        End If
        If TextBox2.Text.Trim.Length <> 0 Then
            formula = formula & "{tblStudentInfo.Sem} =" & TextBox2.Text & " and "
        End If
        If TextBox1.Text.Length = 0 And TextBox2.Text.Length = 0 Then
            formula = " and "
            CrystalReportViewer1.SelectionFormula = ""
            CrystalReportViewer1.RefreshReport()
            GoTo en
        End If

        formula = formula.Substring(0, formula.Length - 4)
        CrystalReportViewer1.SelectionFormula = formula
        CrystalReportViewer1.RefreshReport()
en:

    End Sub
End Class