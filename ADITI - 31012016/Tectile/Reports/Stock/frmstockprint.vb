Imports System.Data.SqlClient
Public Class frmstockprint
    Dim ds As New DataSet2

    Private Sub frmstockprint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmstockprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = frmStocksum.MaskedTextBox1.Text
            dat2 = frmStocksum.MaskedTextBox2.Text
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim opqty As New ListBox
            Dim itli As New ListBox
            Dim ittype As New ListBox
            Dim it As String = "and ("
            If frmStocksum.CheckedListBox1.CheckedItems.Count = 0 Then
                For i = 0 To frmStocksum.CheckedListBox1.Items.Count - 1
                    connect()
                    cmd = New SqlCommand("Select ITName,SUm(RQty)-Sum(DQty) as bal,ITtype from tblStock where (billdt<='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "')" & " and ITName='" & frmStocksum.CheckedListBox1.Items(i).ToString & "' Group By ITName,ITType", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows Then
                        While dr.Read
                            opqty.Items.Add(dr.Item(1))
                            itli.Items.Add(dr.Item(0))
                            ittype.Items.Add(dr.Item("ITType"))
                        End While
                        dr.Close()
                    Else
                        dr.Close()
                        Dim cmd2 As New SqlCommand
                        cmd2 = New SqlCommand("Select ITType from tblItem Where ITName='" & frmStocksum.CheckedListBox1.Items(i).ToString & "'", cn)
                        Dim dr1 As SqlDataReader
                        dr1 = cmd2.ExecuteReader
                        While dr1.Read
                            ittype.Items.Add(dr1.Item(0))
                        End While
                        dr1.Close()
                        opqty.Items.Add(0)
                        itli.Items.Add(frmStocksum.CheckedListBox1.Items(i).ToString)
                    End If
                    it = it & "ITName='" & frmStocksum.CheckedListBox1.Items(i).ToString & "' Or "
                    close1()
                Next
            Else
                For i = 0 To frmStocksum.CheckedListBox1.CheckedItems.Count - 1
                    connect()
                    cmd = New SqlCommand("Select ITName,SUm(RQty)-Sum(DQty) as bal,ITtype from tblStock where (billdt<='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "')" & " and ITName='" & frmStocksum.CheckedListBox1.CheckedItems(i).ToString & "' Group By ITName,ITType", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows Then
                        While dr.Read
                            opqty.Items.Add(dr.Item(1))
                            itli.Items.Add(dr.Item(0))
                            ittype.Items.Add(dr.Item("ITType"))
                        End While
                        dr.Close()
                    Else
                        dr.Close()
                        Dim cmd2 As New SqlCommand
                        cmd2 = New SqlCommand("Select ITType from tblItem Where ITName='" & frmStocksum.CheckedListBox1.CheckedItems(i).ToString & "'", cn)
                        Dim dr1 As SqlDataReader
                        dr1 = cmd2.ExecuteReader
                        While dr1.Read
                            ittype.Items.Add(dr1.Item(0))
                        End While
                        dr1.Close()
                        opqty.Items.Add(0)
                        itli.Items.Add(frmStocksum.CheckedListBox1.CheckedItems(i).ToString)
                    End If
                    close1()
                    it = it & "ITName='" & frmStocksum.CheckedListBox1.CheckedItems(i).ToString & "' Or "
                Next
            End If
            it = it.Substring(0, it.Length - 4).ToString & ")"
            connect()
            Dim rate As New ListBox
            Dim count As Integer
            For i = 0 To itli.Items.Count - 1
                cmd = New SqlCommand("Select Rate from tblItem where ItName='" & itli.Items(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    rate.Items.Add(dr.Item(0))
                End While
                dr.Close()
            Next
            If frmStocksum.CheckedListBox1.CheckedItems.Count = 0 Then
                Dim k As Integer
                k = 0
                For i = 0 To frmStocksum.CheckedListBox1.Items.Count - 1
                    connect()
                    cmd = New SqlCommand("Select ITName,Sum(RQty) as RQty,Sum(DQty) as DQty,ITType from tblStock where (billdt >'" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "')" & " and ITName='" & frmStocksum.CheckedListBox1.Items(i) & "' Group By ITName,ITType", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        Dim dt As DataRow = ds.Tables("tblStockSum").NewRow
                        Dim cmd2 As New SqlCommand
                        dt.Item("ITType") = ittype.Items(k)
                        dt.Item("ITName") = itli.Items(k).ToString
                        dt.Item("Openingqty") = opqty.Items(k).ToString
                        dt.Item("RQty") = 0
                        dt.Item("DQty") = 0
                        dt.Item("Balance") = Val(opqty.Items(k).ToString)
                        dt.Item("Rate") = rate.Items(k)
                        dt.Item("Value") = rate.Items(k) * (Val(opqty.Items(k).ToString))
                        ds.Tables("tblStockSum").Rows.Add(dt)
                        k = k + 1
                    Else
                        While dr.Read
                            Dim dt As DataRow = ds.Tables("tblStockSum").NewRow
                            dt.Item("ITType") = dr.Item("ITType")
                            dt.Item("ITName") = itli.Items(k).ToString
                            dt.Item("Openingqty") = opqty.Items(k).ToString
                            dt.Item("RQty") = dr.Item("RQty")
                            dt.Item("DQty") = dr.Item("DQty")
                            dt.Item("Balance") = Val(opqty.Items(k).ToString) + dr.Item("RQty") - dr.Item("DQty")
                            dt.Item("Rate") = rate.Items(k)
                            dt.Item("Value") = rate.Items(k) * (Val(opqty.Items(k).ToString) + dr.Item("RQty") - dr.Item("DQty"))
                            ds.Tables("tblStockSum").Rows.Add(dt)
                            k = k + 1
                        End While
                        dr.Close()
                    End If
                    close1()

                Next
            Else
                Dim k As Integer
                k = 0
                For i = 0 To frmStocksum.CheckedListBox1.CheckedItems.Count - 1
                    connect()
                    cmd = New SqlCommand("Select ITName,Sum(RQty) as RQty,Sum(DQty) as DQty,ITType from tblStock where (billdt >'" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "')" & " and ITName='" & frmStocksum.CheckedListBox1.CheckedItems(i) & "' Group By ITName,ITType", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = 0 Then
                        Dim dt As DataRow = ds.Tables("tblStockSum").NewRow
                        Dim cmd2 As New SqlCommand
                        dt.Item("ITType") = ittype.Items(k)
                        dt.Item("ITName") = itli.Items(k).ToString
                        dt.Item("Openingqty") = opqty.Items(k).ToString
                        dt.Item("RQty") = 0
                        dt.Item("DQty") = 0
                        dt.Item("Balance") = Val(opqty.Items(k).ToString)
                        dt.Item("Rate") = rate.Items(k)
                        dt.Item("Value") = rate.Items(k) * (Val(opqty.Items(k).ToString))
                        ds.Tables("tblStockSum").Rows.Add(dt)
                        k = k + 1
                    Else
                        While dr.Read
                            Dim dt As DataRow = ds.Tables("tblStockSum").NewRow
                            dt.Item("ITType") = dr.Item("ITType")
                            dt.Item("ITName") = itli.Items(k).ToString
                            dt.Item("Openingqty") = opqty.Items(k).ToString
                            dt.Item("RQty") = dr.Item("RQty")
                            dt.Item("DQty") = dr.Item("DQty")
                            dt.Item("Balance") = Val(opqty.Items(k).ToString) + dr.Item("RQty") - dr.Item("DQty")
                            dt.Item("Rate") = rate.Items(k)
                            dt.Item("Value") = rate.Items(k) * (Val(opqty.Items(k).ToString) + dr.Item("RQty") - dr.Item("DQty"))
                            ds.Tables("tblStockSum").Rows.Add(dt)
                            k = k + 1
                        End While
                        dr.Close()
                    End If
                    close1()
                Next
            End If
            close1()

            Dim rpt As New rptstksum
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ParameterFieldInfo = passparam(frmStocksum.MaskedTextBox1.Text, frmStocksum.MaskedTextBox2.Text, "STOCK STATEMENT")
            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class