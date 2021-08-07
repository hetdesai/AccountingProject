Imports System.Data.SqlClient
Public Class frmchlnprint
    Dim ds As New DataSet2

    Private Sub frmchlnprint_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmchlnprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With frmlotselection
                Dim group As String = ""
                Dim Name As String = ""
                Dim lotno As String = ""
                Dim item As String = ""
                Dim mst As String = ""
                Dim dat1 As New Date
                Dim dat2 As New Date
                Dim type As String = ""
                Dim dat As String = ""
                dat1 = frmlotselection.MaskedTextBox1.Text
                dat2 = frmlotselection.MaskedTextBox2.Text
                dat = "date>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and date<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
                Dim i As Integer
                '   MessageBox.Show(frmlotselection.CustomeChecklistbox1.CheckedItemsCount)
                If frmlotselection.CustomeChecklistbox1.CheckedItemsCount = 0 Then
                    For i = 0 To frmlotselection.CustomeChecklistbox1.ItemsCount - 1
                        group = group & "pgroup='" & frmlotselection.CustomeChecklistbox1.getItems(i).ToString & "' or "

                    Next
                Else
                    For i = 0 To frmlotselection.CustomeChecklistbox1.CheckedItemsCount - 1
                        group = group & "pgroup='" & frmlotselection.CustomeChecklistbox1.getCheckedItems(i).ToString & "' or "
                    Next

                End If
                ' MessageBox.Show(group)
                group = group.Substring(0, group.Length - 4)
                '  MessageBox.Show(group)
                If frmlotselection.CustomeChecklistbox2.CheckedItemsCount = 0 Then
                    For i = 0 To frmlotselection.CustomeChecklistbox2.ItemsCount - 1
                        Name = Name & "name='" & frmlotselection.CustomeChecklistbox2.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To frmlotselection.CustomeChecklistbox2.CheckedItemsCount - 1
                        Name = Name & "name='" & frmlotselection.CustomeChecklistbox2.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                Name = Name.Substring(0, Name.Length - 4)
                If frmlotselection.CustomeChecklistbox4.CheckedItemsCount = 0 Then
                    For i = 0 To frmlotselection.CustomeChecklistbox4.ItemsCount - 1
                        lotno = lotno & "lotno='" & frmlotselection.CustomeChecklistbox4.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To frmlotselection.CustomeChecklistbox4.CheckedItemsCount - 1
                        lotno = lotno & "lotno='" & frmlotselection.CustomeChecklistbox4.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                Try
                    lotno = lotno.Substring(0, lotno.Length - 4)
                Catch ex As Exception

                End Try
                If frmlotselection.CustomeChecklistbox3.CheckedItemsCount = 0 Then
                    For i = 0 To frmlotselection.CustomeChecklistbox3.ItemsCount - 1
                        item = item & "itname='" & frmlotselection.CustomeChecklistbox3.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To frmlotselection.CustomeChecklistbox3.CheckedItemsCount - 1
                        item = item & "itname='" & frmlotselection.CustomeChecklistbox3.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                item = item.Substring(0, item.Length - 4)
                If frmlotselection.CustomeChecklistbox5.CheckedItemsCount = 0 Then
                    For i = 0 To frmlotselection.CustomeChecklistbox5.ItemsCount - 1
                        mst = mst & "mst='" & frmlotselection.CustomeChecklistbox5.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To frmlotselection.CustomeChecklistbox5.CheckedItemsCount - 1
                        mst = mst & "mst='" & frmlotselection.CustomeChecklistbox5.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                  mst = mst.Substring(0, mst.Length - 4)



                connect()
                Dim da As New SqlDataAdapter
                da = New SqlDataAdapter("select * from sale1 where (" & Name & ") and (" & item & ") and (" & mst & ") order  by convert(INT,billno)", cn)
                da.Fill(ds, "sale1")
                da = New SqlDataAdapter("Select * from tblLotr", cn)
                da.Fill(ds, "tblLotr")
                da = New SqlDataAdapter("select * from salet order by Srno", cn)
                da.Fill(ds, "salet")

                Dim j As Integer
                Dim count As Integer
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim srlistbox As New ListBox
                'field(declaration)
                Dim vrno As String
                Dim bkname As String
                Dim bkcode As Integer
                Dim chno As String
                Dim chdt As New Date
                Dim billno As String
                Dim oubno As String
                Dim billdt As New Date

                Dim namecr As String
                Dim accode As Integer
                Dim accodecr As Integer
                Dim maxch As Integer
                Dim k As Integer
                cmd = New SqlCommand("select * from tblSetup where Book='LOTR' and operation='MAXCH'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    maxch = dr.Item(2)
                End While
                dr.Close()
                For i = 0 To .CheckedListBox1.Items.Count - 1
                    srlistbox.Items.Clear()
                    cmd = New SqlCommand("select * from sale1 where billno='" & .CheckedListBox1.Items(i).ToString & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        vrno = dr.Item("vrno")
                        bkname = dr.Item("bkname")
                        bkcode = dr.Item("bkcode")
                        chno = dr.Item("chno")
                        chdt = Format(dr.Item("chdt"), "dd-MM-yyyy")
                        billno = dr.Item("billno")
                        oubno = dr.Item("oubno")
                        billdt = Format(dr.Item("billdt"), "dd-MM-yyyy")
                        name = dr.Item("name")
                        namecr = dr.Item("namecr")
                        accode = dr.Item("accode")
                        accodecr = dr.Item("accodecr")
                        srlistbox.Items.Add(dr.Item("srno"))
                    End While
                    dr.Close()
                    For j = 0 To srlistbox.Items.Count - 1

                        cmd = New SqlCommand("select * from sale1 where billNo='" & .CheckedListBox1.Items(i).ToString & "' and bkname='" & bkname & "'", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            lotno = dr.Item("lotno")
                        End While
                        dr.Close()
                        cmd = New SqlCommand("select count(serilano) from salet where billNo='" & .CheckedListBox1.Items(i).ToString & "' and bkname='" & bkname & "' and sr=" & srlistbox.Items(j).ToString, cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            count = dr.Item(0)
                        End While
                        dr.Close()
                        If count Mod maxch > 0 Then
                            For k = 0 To maxch - (count Mod maxch) - 1
                                Dim dt As DataRow = ds.Tables("salet").NewRow
                                dt.Item(0) = vrno
                                dt.Item(1) = bkname
                                dt.Item(2) = bkcode
                                dt.Item(3) = chno
                                dt.Item(4) = chdt.Day & "-" & chdt.Month & "-" & chdt.Year
                                dt.Item(5) = billno
                                dt.Item(6) = oubno
                                dt.Item(7) = billdt.Day & "-" & billdt.Month & "-" & billdt.Year
                                dt.Item(8) = name
                                dt.Item(9) = namecr
                                dt.Item(10) = accode
                                dt.Item(11) = accodecr
                                dt.Item(12) = 999
                                dt.Item(13) = 0
                                dt.Item(14) = 0
                                dt.Item(15) = lotno
                                dt.Item(16) = srlistbox.Items(j).ToString
                                dt.Item(17) = " "
                                '  ds.Tables("salet").Rows.Add(dt)
                            Next
                        End If
                    Next
                Next
                Dim rpt3 As New rptch3
                rpt3.SetDataSource(ds)
                Dim rpt As New copyrpt
                rpt.SetDataSource(ds)
                Dim rpt2 As New rptch2
                rpt2.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt
                close1()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.ExportReport()
        CrystalReportViewer1.PrintReport()

    End Sub
End Class