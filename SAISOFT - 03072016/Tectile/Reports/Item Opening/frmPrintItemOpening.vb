Imports System.Data.SqlClient
Public Class frmPrintItemOpening

    Private Sub frmPrintItemOpening_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            Dim rpt As New itemopening
            connect()
            da = New SqlDataAdapter("Select * from tblItOpen", cn)
            da.Fill(ds, "tblItOpen")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ParameterFieldInfo = passparam("", "", "ITEM OPENING")
            CrystalReportViewer1.ReportSource = rpt
            close1()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class