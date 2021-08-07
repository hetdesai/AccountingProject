Imports System.Data.SqlClient
Public Class frmStkledgdis
    Public ds As New DataSet2
    Private Sub frmStkledgdis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmStkledgdis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            connect()
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = frmStockledg.MaskedTextBox1.Text
            dat2 = frmStockledg.MaskedTextBox2.Text
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select ITName,ITType,SUm(RQty)-SUm(DQty) as bal from tblStock where BillDt<='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and ITName='" & frmStockledg.CheckedListBox1.CheckedItems(0).ToString & "' group By ITName,ITType", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("tblStock").NewRow
                dt.Item("BillDt") = dat1
                dt.Item("Book") = "Opening"
                dt.Item("VrNo") = " "
                dt.Item("ITName") = dr.Item("ITName")
                dt.Item("ITType") = dr.Item("ITType")
                If dr.Item("bal") > 0 Then
                    dt.Item("RQty") = dr.Item("Bal")
                    dt.Item("DAmt") = 0.0
                ElseIf dr.Item("Bal") < 0 Then
                    dt.Item("DQty") = dr.Item("Bal")
                    dt.Item("RQty") = 0.0
                End If
                dt.Item("Rate") = 0.0
                dt.Item("RAmt") = 0.0
                dt.Item("DAmt") = 0.0
                dt.Item("DRate") = 0.0
                ds.Tables("tblStock").Rows.Add(dt)
            End While
            dr.Close()
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from tblStock where BillDt>'" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "'and BillDt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ITName='" & frmStockledg.CheckedListBox1.CheckedItems(0).ToString & "'", cn)
            da.Fill(ds, "tblStock")
            DataGridView1.DataSource = ds.Tables("tblStock")
            ' DataGridView1.AutoResizeColumns()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmstockledgprint.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class