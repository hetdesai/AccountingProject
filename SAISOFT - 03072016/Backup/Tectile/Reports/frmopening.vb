Imports System.Data.SqlClient
Public Class frmopening
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private Sub frmopening_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim sql As String
            Dim i As Integer
            If frmopeningfilter.CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To frmopeningfilter.CheckedListBox2.Items.Count - 1
                    sql = sql & "acname='" & frmopeningfilter.CheckedListBox2.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmopeningfilter.CheckedListBox2.CheckedItems.Count - 1
                    sql = sql & "acname='" & frmopeningfilter.CheckedListBox2.CheckedItems(i).ToString & "' or "
                Next
            End If
            sql = sql.Substring(0, sql.Length - 4)
            da = New SqlDataAdapter("select * from tblopen where " & sql, cn)
            da.Fill(ds, "tblopen")
            da = New SqlDataAdapter("sELECT * FROM TBLACCOUNT", cn)
            da.Fill(ds, "TBLaCCOUNT")
            Dim rpt As New rptopening
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.ParameterFieldInfo = passparam(dateyf, dateyl, "OPENING BALANCE")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class