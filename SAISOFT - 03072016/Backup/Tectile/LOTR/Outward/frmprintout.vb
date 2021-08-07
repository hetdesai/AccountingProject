Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmprintout
    Dim ds As New DataSet2
    Private Sub frmprintout_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmprintout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Dim group As String = ""
            Dim Name As String = ""
            Dim lotno As String = ""
            Dim item As String = ""
            Dim mst As String = ""
            Dim process As String = ""
            Dim dat1 As New Date
            Dim dat2 As New Date
            Dim dat As String = ""
            dat1 = frmoutward.MaskedTextBox1.Text
            dat2 = frmoutward.MaskedTextBox2.Text
            dat = "date>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and date<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
            Dim i As Integer
            If frmoutward.CheckedListBox1.CheckedItems.Count = 0 Then
                For i = 0 To frmoutward.CheckedListBox1.Items.Count - 1
                    group = group & "pgroup='" & frmoutward.CheckedListBox1.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmoutward.CheckedListBox1.CheckedItems.Count - 1
                    group = group & "pgroup='" & frmoutward.CheckedListBox1.CheckedItems(i).ToString & "' or "
                Next
            End If
            group = group.Substring(0, group.Length - 4)
            If frmoutward.CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To frmoutward.CheckedListBox2.Items.Count - 1
                    Name = Name & "name='" & frmoutward.CheckedListBox2.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmoutward.CheckedListBox2.CheckedItems.Count - 1
                    Name = Name & "name='" & frmoutward.CheckedListBox2.CheckedItems(i).ToString & "' or "
                Next
            End If
            Name = Name.Substring(0, Name.Length - 4)
            If frmoutward.CheckedListBox3.CheckedItems.Count = 0 Then
                For i = 0 To frmoutward.CheckedListBox3.Items.Count - 1
                    lotno = lotno & "lotno='" & frmoutward.CheckedListBox3.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmoutward.CheckedListBox3.CheckedItems.Count - 1
                    lotno = lotno & "lotno='" & frmoutward.CheckedListBox3.CheckedItems(i).ToString & "' or "
                Next
            End If
            Try
                lotno = lotno.Substring(0, lotno.Length - 4)
            Catch ex As Exception

            End Try
            If frmoutward.CheckedListBox5.CheckedItems.Count = 0 Then
                For i = 0 To frmoutward.CheckedListBox5.Items.Count - 1
                    item = item & "itname='" & frmoutward.CheckedListBox5.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmoutward.CheckedListBox5.CheckedItems.Count - 1
                    item = item & "itname='" & frmoutward.CheckedListBox5.CheckedItems(i).ToString & "' or "
                Next
            End If
            item = item.Substring(0, item.Length - 4)
            If frmoutward.CheckedListBox4.CheckedItems.Count = 0 Then
                For i = 0 To frmoutward.CheckedListBox4.Items.Count - 1
                    mst = mst & "mst='" & frmoutward.CheckedListBox4.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmoutward.CheckedListBox4.CheckedItems.Count - 1
                    mst = mst & "mst='" & frmoutward.CheckedListBox4.CheckedItems(i).ToString & "' or "
                Next
            End If
            mst = mst.Substring(0, mst.Length - 4)
            If frmoutward.CheckedListBox6.CheckedItems.Count = 0 Then
                For i = 0 To frmoutward.CheckedListBox6.Items.Count - 1
                    process = process & "process='" & frmoutward.CheckedListBox6.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To frmoutward.CheckedListBox6.CheckedItems.Count - 1
                    process = process & "process='" & frmoutward.CheckedListBox6.CheckedItems(i).ToString & "' or "
                Next
            End If
            process = process.Substring(0, process.Length - 4)
            Dim da As New SqlDataAdapter
            '    da = New SqlDataAdapter("select * from tblAccount where (" & group & ")", cn)
            '   da.Fill(ds, "tblAccount")
            '  da = New SqlDataAdapter("select * from sale where (" & mst & ") and (" & Name & ")", cn)
            '  da.Fill(ds, "sale")
            ' da = New SqlDataAdapter("Select * from sale1 where (" & process & ")" & " and (" & mst & ") and (" & Name & ") and (" & item & ") and (" & lotno & ")", cn)
            '   da.Fill(ds, "sale1")
            da = New SqlDataAdapter("select * from tblAccount where (" & group & ")", cn)
            da.Fill(ds, "tblAccount")
            da = New SqlDataAdapter("select * from sale where (" & mst & ") and (" & Name & ")", cn)
            da.Fill(ds, "sale")
            da = New SqlDataAdapter("Select * from sale1 where (" & process & ")", cn)
            da.Fill(ds, "sale1")

            MsgBox(frmoutward.ComboBox2.Text)
            If frmMainScreen.outward = "Lot" And frmoutward.ComboBox1.Text = "Bill Wise" Then
                Dim rpt As New rptoutbilldetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Lot" And frmoutward.ComboBox1.Text = "Daily" Then
                Dim rpt As New rptoutbilldaily
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Daily")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Lot" And frmoutward.ComboBox1.Text = "Monthly" Then
                Dim rpt As New rptoutbillmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Lot" And frmoutward.ComboBox1.Text = "Summary" Then
                Dim rpt As New rptoutbillsum
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutgroupdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group" And frmoutward.ComboBox2.Text = "Bill Wise" Then
                MsgBox("het")
                Dim rpt As New rptoutgroupbillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutgroupmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutgroupSummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group + Party" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutgrouppartydetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group + Party" And frmoutward.ComboBox2.Text = "Bill Wise" Then
                Dim rpt As New rptoutgrouppartybillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Party Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group + Party" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutgrouppartymonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group + Party" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutgrouppartysummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Party" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutpartydetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Party" And frmoutward.ComboBox2.Text = "Bill Wise" Then
                Dim rpt As New rptoutpartybillwise
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Party" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutpartymonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Party" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutpartysummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group + Item" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutgroupitemdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group + Item" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutgroupitemmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Group + Item" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutgroupitemsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Group Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item + Group" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutitemgroupdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Group Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item + Group" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutitemgroupmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Group Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item + Group" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutitemgroupsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Group Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutitemdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutitemmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutitemsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Party + Item" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutpartyitemdetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Party Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Party + Item" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutpartyitemmonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Party Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Party + Item" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutpartyitemsummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Party Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item + Party" And frmoutward.ComboBox2.Text = "Detail" Then
                Dim rpt As New rptoutitempartydetail
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item + Party" And frmoutward.ComboBox2.Text = "Monthly" Then
                Dim rpt As New rptoutitempartymonthly
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.outward = "Item + Party" And frmoutward.ComboBox2.Text = "Summary" Then
                Dim rpt As New rptoutitempartysummary
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmoutward.MaskedTextBox1.Text, frmoutward.MaskedTextBox2.Text, "Item Party Summary")
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

            Return p1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class