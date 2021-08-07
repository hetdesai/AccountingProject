Imports System.Data.SqlClient
Public Class frmVatReport
    Dim ds As New DataSet3
    Private Sub frmVatReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dt As New DataTable
            dt = ds.Tables("Datatable1")
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            For i = 0 To 1000
                cmd = New SqlCommand("select a.name,a.gramt,a.netamt,s.bkname,s.billno,s.amt vat,s1.amt advat from saltax s,saltax s1,salesc a where s1.taxnara like '%C%' and s.taxnara like '%C%' and s1.billno=s.billno and a.oubno=s.billno", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim datarow As DataRow = dt.NewRow
                    datarow("SrNo") = i
                    datarow("BillNo") = "15/1"
                    datarow("AccountName") = dr.Item("BKNAME")
                    datarow("VAT") = dr.Item("vat")
                    datarow("ADDITIONAL VAT") = dr.Item("advat")
                    datarow("Gross Amt") = dr.Item("gramt")
                    datarow("Net Amt") = dr.Item("netamt")
                    datarow("date") = DateTime.Now.Date
                    dt.Rows.Add(datarow)
                End While
                dr.Close()

            Next
            close1()
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class