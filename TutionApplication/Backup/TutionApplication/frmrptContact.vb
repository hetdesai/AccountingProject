Public Class frmrptContact

    Private Sub frmrptContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Contact Report"
        TextBox1.Text = Today.Year
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
            formula = formula & "{tblStudentInfo.Batch} = '" & TextBox3.Text & "' and "
        End If
        formula = formula.Substring(0, formula.Length - 5)
        CrystalReportViewer1.SelectionFormula = formula
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class