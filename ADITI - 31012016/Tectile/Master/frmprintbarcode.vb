Imports System.Data.SqlClient
Public Class frmprintbarcode
    Dim ds As New DataSet2
    Dim da As New SqlDataAdapter
    Dim rpt As New rptbarcode
    Private Sub frmprintbarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim i As Integer
            Dim j As Integer
            ds.Tables("datatable6").Rows.Clear()
            For i = 0 To frmselectitem.DG1.RowCount - 1
                For j = 0 To frmselectitem.DG1.Item(7, i).Value - 1
                    Dim dt As DataRow = ds.Tables("datatable6").NewRow
                    dt.Item(0) = frmselectitem.DG1.Item(0, i).Value.ToString
                    dt.Item(1) = 1
                    ds.Tables("datatable6").Rows.Add(dt)
                Next
            Next
            '  MsgBox(ds.Tables("datatable6").Rows.Count)
            DataGridView1.DataSource = ds.Tables("datatable6")
            da = New SqlDataAdapter("Select * from tblIt2", cn)
            da.Fill(ds, "tblIt2")
            da = New SqlDataAdapter("select * from tblBarcode", cn)
            da.Fill(ds, "tblBarcode")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            close1()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class