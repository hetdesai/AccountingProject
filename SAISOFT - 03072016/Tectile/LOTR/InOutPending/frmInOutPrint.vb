Imports System.Data.SqlClient
Public Class frmInOutPrint
    Dim ds As New LotDataset
    Private Sub frmInOutPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmInOutPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("SELECT tblLotr.Date, tblLotr.LotNo, tblLotr.IchNo, tblLotr.ACName, tblLotr.Gpcs, tblLotr.Gmtr, sale1.BillDt, sale1.BillNo, sale1.ITName, sale1.process, sale1.shade, sale1.Style, sale1.Grpcs, sale1.GrMtr FROM tblLotr INNER JOIN sale1 ON tblLotr.LotNo = sale1.lotno", cn)
            da.Fill(ds, "INOUT")
            Dim rpt As New rptInOutLot
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class