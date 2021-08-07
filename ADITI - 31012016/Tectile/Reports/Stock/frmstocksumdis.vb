Imports System.Data.SqlClient
Public Class frmstocksumdis
    Public ds As New DataSet2
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmstocksumdis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmstockdis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = frmStocksum.MaskedTextBox1.Text
            dat2 = frmStocksum.MaskedTextBox2.Text
            Dim it As String = "and ("
            If frmStocksum.CheckedListBox1.CheckedItems.Count = 0 Then
                For i = 0 To frmStocksum.CheckedListBox1.Items.Count - 1
                    it = it & "ITName='" & frmStocksum.CheckedListBox1.Items(i).ToString & "' Or "
                Next
            End If
            For i = 0 To frmStocksum.CheckedListBox1.CheckedItems.Count - 1
                it = it & "ITName='" & frmStocksum.CheckedListBox1.CheckedItems(i).ToString & "' Or "
            Next
            it = it.Substring(0, it.Length - 4).ToString & ")"
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select ITName,SUm(cr)-Sum(dr) as bal,ITtype from tblStock where (billdt<'" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "')" & it & " Group By ITName,ITType", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("tblStock").NewRow
                dt.Item(0) = "Opening"
                dt.Item(1) = " "
                dt.Item(2) = dr.Item("ITName")
                dt.Item(3) = dr.Item("ITtype")
                If dr.Item("bal") < 0 Then
                    dt.Item(4) = dr.Item("bal") * -1
                    dt.Item(5) = 0
                ElseIf dr.Item("bal") > 0 Then
                    dt.Item(5) = dr.Item("bal")
                    dt.Item(4) = 0
                Else
                    dt.Item(4) = 0
                    dt.Item(5) = 0
                End If
                ds.Tables("tblStock").Rows.Add(dt)
            End While
            dr.Close()
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from tblStock where (billdt >='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "')" & it, cn)
            da.Fill(ds, "tblStock")
            DataGridView1.DataSource = ds.Tables("tblStock")
            DataGridView1.Columns(DataGridView1.ColumnCount - 2).Visible = False
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmstockprint.Show()
    End Sub
End Class