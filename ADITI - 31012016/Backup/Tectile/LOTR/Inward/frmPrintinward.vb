Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmPrintinward
    Dim ds As New DataSet

    Private Sub frmPrintinward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmPrintinward_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim group As String = ""
            Dim Name As String = ""
            Dim lotno As String = ""
            Dim item As String = ""
            Dim mst As String = ""
            Dim dat1 As New Date
            Dim dat2 As New Date
            Dim dat As String = ""
            dat1 = frmInwardsele.MaskedTextBox1.Text
            dat2 = frmInwardsele.MaskedTextBox2.Text
            dat = "date>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and date<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
            Dim i As Integer
            If frmInwardsele.CheckedListBox1.CheckedItems.Count = 0 Then
                For i = 0 To frmInwardsele.CheckedListBox1.Items.Count - 1
                    group = group & "pgroup='" & frmInwardsele.CheckedListBox1.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmInwardsele.CheckedListBox1.CheckedItems.Count - 1
                    group = group & "pgroup='" & frmInwardsele.CheckedListBox1.CheckedItems(i).ToString & "' or "
                Next
            End If
            group = group.Substring(0, group.Length - 4)
            If frmInwardsele.CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To frmInwardsele.CheckedListBox2.Items.Count - 1
                    Name = Name & "acname='" & frmInwardsele.CheckedListBox2.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmInwardsele.CheckedListBox2.CheckedItems.Count - 1
                    Name = Name & "acname='" & frmInwardsele.CheckedListBox2.CheckedItems(i).ToString & "' or "
                Next
            End If
            Name = Name.Substring(0, Name.Length - 4)
            If frmInwardsele.CheckedListBox3.CheckedItems.Count = 0 Then
                For i = 0 To frmInwardsele.CheckedListBox3.Items.Count - 1
                    lotno = lotno & "lotno='" & frmInwardsele.CheckedListBox3.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmInwardsele.CheckedListBox3.CheckedItems.Count - 1
                    lotno = lotno & "lotno='" & frmInwardsele.CheckedListBox3.CheckedItems(i).ToString & "' or "
                Next
            End If
            Try
                lotno = lotno.Substring(0, lotno.Length - 4)
            Catch ex As Exception

            End Try
            If frmInwardsele.CheckedListBox5.CheckedItems.Count = 0 Then
                For i = 0 To frmInwardsele.CheckedListBox5.Items.Count - 1
                    item = item & "item='" & frmInwardsele.CheckedListBox5.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmInwardsele.CheckedListBox5.CheckedItems.Count - 1
                    item = item & "item='" & frmInwardsele.CheckedListBox5.CheckedItems(i).ToString & "' or "
                Next
            End If
            item = item.Substring(0, item.Length - 4)
            If frmInwardsele.CheckedListBox4.CheckedItems.Count = 0 Then
                For i = 0 To frmInwardsele.CheckedListBox4.Items.Count - 1
                    mst = mst & "mst='" & frmInwardsele.CheckedListBox4.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmInwardsele.CheckedListBox4.CheckedItems.Count - 1
                    mst = mst & "mst='" & frmInwardsele.CheckedListBox4.CheckedItems(i).ToString & "' or "
                Next
            End If
            mst = mst.Substring(0, mst.Length - 4)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("select * from tblAccount where (" & group & ") and (" & Name & ")", cn)
            da.Fill(ds, "tblAccount")
            '  MsgBox("select * from tblLotr where (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ")")
            '    MsgBox("select * from tblLotr where (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ") and (" & dat & ")")
            da = New SqlDataAdapter("select * from tblLotr where (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ") and (" & dat & ")", cn)
            da.Fill(ds, "tblLotr")
            da = New SqlDataAdapter("Select * from tblLotrt", cn)
            da.Fill(ds, "tblLotrt")
             If frmMainScreen.inwardrpt = "Lot" And frmInwardsele.ComboBox1.Text = "Lot Wise" Then
                Dim rpt As New rptinwardlotwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Lot" And frmInwardsele.ComboBox1.Text = "Detail" Then
                Dim rpt As New rptinwardlotdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Lot Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Lot" And frmInwardsele.ComboBox1.Text = "Daily" Then
                Dim rpt As New rptinwardlotdaily
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Lot Daily")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwardgroupdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwardgroupbillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwardgroupmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwardgroupsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwardgrouppartydetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwardgrouppartybillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Party Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwardgrouppartymonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwardgrouppartysummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Item" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwardgroupitemdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Item" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwardgroupitembillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Item Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Item" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwardgroupitemmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Item" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwardgroupitemsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Group Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwardpartydetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwardpartybillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwardpartymonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwardpartysummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party + Item" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwardpartyitemdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party + Item" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwardpartyitembillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Item Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party + Item" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwardPartyitemmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Party + Item" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwardPartyitemsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Party Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwarditemdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwarditembillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwarditemmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwarditemsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Group" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwarditemgroupdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Group Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Group" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwarditemgroupbillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Group Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Group" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwarditemgroupmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Group Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Group" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwarditemgroupsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Group Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Party" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwarditempartydetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Party" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwarditempartybillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Party" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwarditemPartymonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Item + Party" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwarditemPartysummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party + Item" And frmInwardsele.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptinwardgrouppartyitemdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party + Item" And frmInwardsele.ComboBox2.Text = "Lot Wise" Then
                Dim rpt As New rptinwardgrouppartyitembillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Item Lot Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party + Item" And frmInwardsele.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptinwardgrouppartyitemmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.inwardrpt = "Group + Party + Item" And frmInwardsele.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptinwardgrouppartyitemsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmInwardsele.MaskedTextBox1.Text, frmInwardsele.MaskedTextBox2.Text, "Item Party Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            End If
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
End Class