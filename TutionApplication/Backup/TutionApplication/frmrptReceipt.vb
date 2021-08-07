Public Class frmrptReceipt

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmALLreceipt.Show()
        Me.Close()
    End Sub

    Private Sub frmrptReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Receipt Form"
        CrystalReportViewer1.SelectionFormula = "{tblFee.Rasid_No} = " & TextBox1.Text
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class