Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmprinttb
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet2
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Private Sub frmprinttb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmprinttb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ac As String = "and ("
            If frmtb.CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To frmtb.CheckedListBox2.Items.Count - 1
                    ac = ac & "tblAccount.ACName='" & frmtb.CheckedListBox2.Items(i).ToString & "' Or "
                Next
            End If
            For i = 0 To frmtb.CheckedListBox2.CheckedItems.Count - 1
                ac = ac & "tblAccount.ACName='" & frmtb.CheckedListBox2.CheckedItems(i).ToString & "' Or "
            Next
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = frmtb.MaskedTextBox1.Text.ToString
            dat2 = frmtb.MaskedTextBox2.Text.ToString
            Dim date1 As String
            date1 = "tblLedg.Date >='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and tblLedg.Date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
            ac = ac.Substring(0, ac.Length - 4).ToString & ")"
            Dim sql As String
            If frmtbdis.rpttype = "Zero" Then
                sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode " & ac & " and (" & date1 & ") group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD having sum(bal) <> 0"
            Else
                sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode " & ac & " and (" & date1 & ") group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            End If
            DataGridView1.Visible = False
            connect()
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("trialbal").NewRow
                dt.Item("ASD") = dr.Item(0)
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = dr.Item(3)
                If dr.Item("bal") < 0 Then
                    dt.Item("dr") = (dr.Item("bal").ToString * -1)
                    dt.Item("cr") = 0
                Else
                    dt.Item("cr") = (dr.Item("bal").ToString)
                    dt.Item("dr") = 0
                End If
                ds.Tables("trialbal").Rows.Add(dt)
            End While
            dr.Close()
            close1()
            ' DataGridView1.DataSource = ds.Tables("trialbal")
            If frmtbdis.rpttype = "Account" Or frmtbdis.rpttype = "Zero" Then
                Dim rpt As New trialbal
                rpt.SetDataSource(ds.Tables("trialbal"))
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmtb.MaskedTextBox1.Text, frmtb.MaskedTextBox2.Text, "Trial Balance")
                CrystalReportViewer1.ReportSource = rpt
            Else
                Dim rpt As New trialbal2
                rpt.SetDataSource(ds.Tables("trialbal"))
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmtb.MaskedTextBox1.Text, frmtb.MaskedTextBox2.Text, "Trial Balance")
                CrystalReportViewer1.ReportSource = rpt
            End If
            
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Function passparam(ByVal fromdat As String, ByVal todate As String, ByVal Title As String) As ParameterFields
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
            'Now set first param
            field1.ParameterFieldName = "fromdate"
            value1.Value = fromdat
            field1.CurrentValues.Add(value1)
            p1.Add(field1)
            field2.ParameterFieldName = "Todate"
            value2.Value = todate
            field2.CurrentValues.Add(value2)
            p1.Add(field2)
            field3.ParameterFieldName = "title"
            value3.Value = Title
            field3.CurrentValues.Add(value3)
            p1.Add(field3)
            field4.ParameterFieldName = "Companyname"
            value4.Value = comname
            field4.CurrentValues.Add(value4)
            p1.Add(field4)
            field5.ParameterFieldName = "Address"
            value5.Value = ""
            field5.CurrentValues.Add(value5)
            p1.Add(field5)
            Return p1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class