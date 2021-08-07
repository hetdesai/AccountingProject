Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmprintpending
    Dim ds As New DataSet
    Private Sub frmPrintinward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmPrintinward_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With frmpenlotsele
                Dim group As String = ""
                Dim Name As String = ""
                Dim lotno As String = ""
                Dim item As String = ""
                Dim mst As String = ""
                Dim type As String = ""
                Dim i As Integer
                If .CustomeChecklistbox1.CheckedItemsCount = 0 Then
                    For i = 0 To .CustomeChecklistbox1.ItemsCount - 1
                        group = group & "pgroup='" & .CustomeChecklistbox1.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To .CustomeChecklistbox1.CheckedItemsCount - 1
                        group = group & "pgroup='" & .CustomeChecklistbox1.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                group = group.Substring(0, group.Length - 4)
                If .CustomeChecklistbox2.CheckedItemsCount = 0 Then
                    For i = 0 To .CustomeChecklistbox2.ItemsCount - 1
                        Name = Name & "acname='" & .CustomeChecklistbox2.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To .CustomeChecklistbox2.CheckedItemsCount - 1
                        Name = Name & "acname='" & .CustomeChecklistbox2.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                Name = Name.Substring(0, Name.Length - 4)
                If .CustomeChecklistbox4.CheckedItemsCount = 0 Then
                    For i = 0 To .CustomeChecklistbox4.ItemsCount - 1
                        lotno = lotno & "lotno='" & .CustomeChecklistbox4.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To .CustomeChecklistbox4.CheckedItemsCount - 1
                        lotno = lotno & "lotno='" & .CustomeChecklistbox4.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                Try
                    lotno = lotno.Substring(0, lotno.Length - 4)
                Catch ex As Exception

                End Try
                If .ComboBox3.Text = "A" Then
                    type = "and check1='A'"
                ElseIf .ComboBox3.Text = "B" Then
                    type = "and check1='B'"
                Else
                    type = ""
                End If
                If .CustomeChecklistbox3.CheckedItemsCount = 0 Then
                    For i = 0 To .CustomeChecklistbox3.ItemsCount - 1
                        item = item & "item='" & .CustomeChecklistbox3.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To .CustomeChecklistbox3.CheckedItemsCount - 1
                        item = item & "item='" & .CustomeChecklistbox3.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                item = item.Substring(0, item.Length - 4)
                If .CustomeChecklistbox5.CheckedItemsCount = 0 Then
                    For i = 0 To .CustomeChecklistbox5.ItemsCount - 1
                        mst = mst & "mst='" & .CustomeChecklistbox5.getItems(i).ToString & "' or "
                    Next
                Else
                    For i = 0 To .CustomeChecklistbox5.CheckedItemsCount - 1
                        mst = mst & "mst='" & .CustomeChecklistbox5.getCheckedItems(i).ToString & "' or "
                    Next
                End If
                mst = mst.Substring(0, mst.Length - 4)
                Dim da As New SqlDataAdapter
                '   da = New SqlDataAdapter("select * from tblAccount where (" & group & ") and (" & Name & ")", cn)
                '  da.Fill(ds, "tblAccount")
                ' da = New SqlDataAdapter("select * from tblLotr where (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ") and (" & dat & ")", cn)
                '  da.Fill(ds, "tblLotr")
                ' da = New SqlDataAdapter("Select * from tblLotrt", cn)
                'da.Fill(ds, "tblLotrt")
                Dim dat1 As New Date
                Dim dat2 As New Date
                Dim dat3 As New Date
                Dim dat4 As New Date
                dat1 = .MaskedTextBox1.Text
                dat2 = .MaskedTextBox2.Text
                dat3 = .MaskedTextBox3.Text
                dat4 = .MaskedTextBox4.Text
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                da = New SqlDataAdapter("select * from tblLotr where (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ") and date>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and date<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and isdesp='f' " & type, cn)
                da.Fill(ds, "tblLotr")
                Dim combo As New ComboBox
                For i = 0 To ds.Tables("tblLotr").Rows.Count - 1
                    cmd = New SqlCommand("select sum(grpcs),sum(grmtr) from sale1 where lotno='" & ds.Tables("tbllotr").Rows(i).Item("lotno").ToString & "' and billdt>='" & dat3.Month & "-" & dat3.Day & "-" & dat3.Year & "' and billdt<='" & dat4.Month & "-" & dat4.Day & "-" & dat4.Year & "' group by lotno", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        dr.Close()
                    Else
                        While dr.Read
                            ds.Tables("tbllotr").Rows(i).Item("gpcs") = ds.Tables("tbllotr").Rows(i).Item("gpcs") - Val(dr.Item(0))
                            ds.Tables("tbllotr").Rows(i).Item("gmtr") = ds.Tables("tbllotr").Rows(i).Item("gmtr") - Val(dr.Item(1))
                            If ds.Tables("tblLotr").Rows(i).Item("gpcs") = 0 And ds.Tables("tblLotr").Rows(i).Item("gmtr") = 0 Then
                                combo.Items.Add(i)
                            End If
                        End While
                        dr.Close()
                    End If
                Next
                For i = 0 To combo.Items.Count - 1
                    ds.Tables("tblLotr").Rows.RemoveAt((Val(combo.Items(i).ToString) - i))
                Next
                '   ds.Tables("tblLotr").Columns(0)
                '    DataGridView1.DataSource = ds.Tables("tblLotr")
                da = New SqlDataAdapter("Select * from tblLotrt", cn)
                da.Fill(ds, "tblLotrt")
                da = New SqlDataAdapter("select * from tblAccount where (" & group & ") and (" & Name & ")", cn)
                da.Fill(ds, "tblAccount")
                If frmMainScreen.pending = "Lot" And frmpenlotsele.ComboBox1.Text = "Lot Wise" Then
                    Dim rpt As New rptinwardlotwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Lot" And frmpenlotsele.ComboBox1.Text = "Detail" Then
                    Dim rpt As New rptinwardlotdetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Lot Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Lot" And frmpenlotsele.ComboBox1.Text = "Daily" Then
                    Dim rpt As New rptinwardlotdaily
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Lot Daily")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwardgroupdetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwardgroupbillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwardgroupmonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwardgroupsummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwardgrouppartydetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Party Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwardgrouppartybillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Party Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwardgrouppartymonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Party Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwardgrouppartysummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Party Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Item" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwardgroupitemdetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Item Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Item" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwardgroupitembillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Item Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Item" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwardgroupitemmonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Item Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Item" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwardgroupitemsummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Group Item Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwardpartydetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwardpartybillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwardpartymonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwardpartysummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party + Item" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwardpartyitemdetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Item Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party + Item" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwardpartyitembillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Item Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party + Item" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwardPartyitemmonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Item Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Party + Item" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwardPartyitemsummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Party Item Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwarditemdetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwarditembillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwarditemmonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwarditemsummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Group" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwarditemgroupdetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Group Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Group" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwarditemgroupbillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Group Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Group" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwarditemgroupmonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Group Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Group" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwarditemgroupsummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Group Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Party" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwarditempartydetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Party" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwarditempartybillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Party" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwarditemPartymonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Item + Party" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwarditemPartysummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Summary")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party + Item" And frmpenlotsele.ComboBox2.Text = "Detail" Then
                    Dim rpt As New rptinwardgrouppartyitemdetail
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Item Detail")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party + Item" And frmpenlotsele.ComboBox2.Text = "Lot Wise" Then
                    Dim rpt As New rptinwardgrouppartyitembillwise
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Item Lot Wise")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party + Item" And frmpenlotsele.ComboBox2.Text = "Monthly" Then
                    Dim rpt As New rptinwardgrouppartyitemmonthly
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Item Monthly")
                    CrystalReportViewer1.ReportSource = rpt
                ElseIf frmMainScreen.pending = "Group + Party + Item" And frmpenlotsele.ComboBox2.Text = "Summary" Then
                    Dim rpt As New rptinwardgrouppartyitemsummary
                    rpt.SetDataSource(ds)
                    CrystalReportViewer1.ParameterFieldInfo = passparam(frmpenlotsele.MaskedTextBox1.Text, frmpenlotsele.MaskedTextBox2.Text, "Item Party Item Summary")
                    CrystalReportViewer1.ReportSource = rpt
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function passparam(ByVal fromdat As String, ByVal todate As String, ByVal Title As String) As ParameterFields
        Try

            Dim p1 As New ParameterFields
            Dim field1 As New ParameterField ' ParameterField for 1st param
            Dim value1 As New ParameterDiscreteValue  ' ParameterField for 2nd param
            Dim field2 As New ParameterField  'ParameterDiscreteValue for 1st param
            Dim value2 As New ParameterDiscreteValue 'ParameterDiscreteValue for 2nd param
            Dim field3 As New ParameterField
            Dim value3 As New ParameterDiscreteValue
            Dim field4 As New ParameterField
            Dim value4 As New ParameterDiscreteValue
            Dim field5 As New ParameterField
            Dim value5 As New ParameterDiscreteValue
            Dim field6 As New ParameterField
            Dim value6 As New ParameterDiscreteValue
            'Now set first param
            field1.ParameterFieldName = "fromdate"
            value1.Value = fromdat
            field1.CurrentValues.Add(value1)
            p1.Add(field1)
            field2.ParameterFieldName = "Todate"
            value2.Value = todate
            field2.CurrentValues.Add(value2)
            p1.Add(field2)
            field3.ParameterFieldName = "Reporttitle"
            value3.Value = Title
            field3.CurrentValues.Add(value3)
            p1.Add(field3)
            field4.ParameterFieldName = "Companyname"
            value4.Value = comname
            field4.CurrentValues.Add(value4)
            p1.Add(field4)
            field5.ParameterFieldName = "Address"
            value5.Value = frmcomdis.add1 & "," & frmcomdis.add2 & "," & frmcomdis.add3
            field5.CurrentValues.Add(value5)
            p1.Add(field5)
            field6.ParameterFieldName = "Balance"
            value6.Value = "No"
            field6.CurrentValues.Add(value6)
            p1.Add(field6)
            Return p1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class