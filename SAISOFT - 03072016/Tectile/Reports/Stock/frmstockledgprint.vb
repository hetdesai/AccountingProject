Imports System.Data.SqlClient
Public Class frmstockledgprint

    Private Sub frmstockledgprint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstockledgprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rpt As New rptStockLedg
        rpt.SetDataSource(frmStkledgdis.ds)
        CrystalReportViewer1.ParameterFieldInfo = passparam(frmStockledg.MaskedTextBox1.Text, frmStockledg.MaskedTextBox2.Text, "STOCK LEDGER")
        CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class