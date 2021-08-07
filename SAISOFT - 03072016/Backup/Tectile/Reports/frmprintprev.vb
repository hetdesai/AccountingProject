Imports System.Data.SqlClient
Public Class frmprintprev

    Private Sub frmprintprev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim rpt As New rptprev
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet2
            da = New SqlDataAdapter("Select * from tblOub", cn)
            da.Fill(ds, "tblOub")
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ParameterFieldInfo = passparam("", "", "PREVIOUS BILLS")
            CrystalReportViewer1.ReportSource = rpt
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class