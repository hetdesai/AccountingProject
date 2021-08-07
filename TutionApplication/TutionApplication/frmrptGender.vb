Public Class frmrptGender

    Private Sub frmrptGender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Gender Report"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = Today.Year
        Dim formula As String = " and "
        If TextBox1.Text.Trim.Length <> 0 Then
            formula = "{tblStudentInfo.Year1} = " & TextBox1.Text & " and "
        End If
        If TextBox2.Text.Trim.Length <> 0 Then
            formula = "{tblStudentInfo.Sem} = " & TextBox2.Text & " and "
        End If
        If ComboBox1.Text = "" Then

        ElseIf ComboBox1.Text = "Male" Then

            formula = formula & "{tblStudentInfo.Gender} ='Male' and "
        ElseIf ComboBox1.Text = "All" Then

        Else
            formula = formula & "{tblStudentInfo.Gender} ='Female' and '"
        End If
        formula = formula.Substring(0, formula.Length - 5)
        CrystalReportViewer1.SelectionFormula = formula
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class