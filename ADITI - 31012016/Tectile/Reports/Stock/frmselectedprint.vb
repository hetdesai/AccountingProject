Public Class frmselectedprint

    Private Sub frmselectedprint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmselectedprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rpt As New rptStockLedg
        rpt.SetDataSource(frmSelecteditemLedg.ds)
        CrystalReportViewer1.ParameterFieldInfo = passparam(frmSelecteditemLedg.MaskedTextBox1.Text, frmSelecteditemLedg.MaskedTextBox2.Text, "STOCK LEDGER")
        CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class