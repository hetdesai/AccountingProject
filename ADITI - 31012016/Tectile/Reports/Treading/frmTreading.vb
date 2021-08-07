Imports System.Data.SqlClient
Public Class frmTreading
    Dim cmd As New SqlCommand
    Dim ds As New DataSet2
    Dim dr As SqlDataReader

    Private Sub frmTreading_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmTreading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dat1 As New Date
            Dim dat2 As New Date
            Dim dat As String
            dat1 = frmtradingdis.MaskedTextBox1.Text
            dat2 = frmtradingdis.MaskedTextBox2.Text
            dat = "tblLedg.date >='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and tblLedg.date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
            connect()
            Dim sql As String
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='True' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("Treading1").NewRow
                dt.Item("ASD") = dr.Item(0)
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = "A" & dr.Item(3)
                If dr.Item("bal") < 0 Then
                    dt.Item("dr") = (dr.Item("bal").ToString * -1)
                    dt.Item("cr") = 0
                Else
                    dt.Item("cr") = (dr.Item("bal").ToString)
                    dt.Item("dr") = 0
                End If
                ds.Tables("Treading1").Rows.Add(dt)
            End While
            dr.Close()
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='True' and tblMH.ASD='" & "Expenditure" & "' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("Treading2").NewRow
                dt.Item("ASD") = "Expenditure"
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = dr.Item(3)
                'If dr.Item("bal") < 0 Then
                dt.Item("dr") = (dr.Item("bal").ToString * -1)
                dt.Item("cr") = 0
                'Else
                'dt.Item("cr") = (dr.Item("bal").ToString)
                'dt.Item("dr") = 0
                ' End If
                ds.Tables("Treading2").Rows.Add(dt)
            End While
            dr.Close()
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='True' and tblMH.ASD='" & "Income" & "' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("Treading3").NewRow
                dt.Item("ASD") = "Income"
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = dr.Item(3)
                '  If dr.Item("bal") < 0 Then
                '  dt.Item("dr") = (dr.Item("bal").ToString * -1)
                ' dt.Item("cr") = 0
                'Else
                dt.Item("cr") = (dr.Item("bal").ToString)
                dt.Item("dr") = 0
                ' End If
                ds.Tables("Treading3").Rows.Add(dt)
            End While
            dr.Close()
            Dim expenditure As Decimal
            Dim income As Decimal
            sql = "Select ASD, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='True' and tblMH.ASD='" & "Expenditure" & "' and " & dat & " group by tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read
                expenditure = ((dr.Item("Balance")) * -1)
            End While
            dr.Close()
            sql = "Select ASD, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='True' and tblMH.ASD='" & "Income" & "' and " & dat & " group by tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read
                income = (dr.Item("Balance"))
            End While
            dr.Close()
            If income - expenditure < 0 Then
                Dim dt As DataRow = ds.Tables("Treading3").NewRow
                dt.Item("ASD") = "Income"
                dt.Item("Shead") = "Treading"
                dt.Item("ACname") = "Gross Profit/Loss Transfer to Profit & Loss"
                dt.Item("Mhead") = "Z" & "Profit / Loss"
                dt.Item("Cr") = (income - expenditure) * -1
                ds.Tables("Treading3").Rows.Add(dt)
            Else
                Dim dt As DataRow = ds.Tables("Treading2").NewRow
                dt.Item("ASD") = "Expenditure"
                dt.Item("Shead") = "Treading"
                dt.Item("ACname") = "Gross Profit/Loss Transfer to Profit & Loss"
                dt.Item("Mhead") = "Z" & "Profit / Loss"
                dt.Item("dr") = income - expenditure
                ds.Tables("Treading2").Rows.Add(dt)
            End If
            Dim rpt3 As New rptTreadingIn
            rpt3.SetDataSource(ds.Tables("Treading2"))
            Dim rpt2 As New rptTreadingIn
            rpt2.SetDataSource(ds.Tables("Treading3"))
            If frmtradingdis.rpttype = "Account" Then
                Dim rpt1 As New rptTreadingMain
                rpt1.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(Format(dateyf, "dd-MM-yyyy"), Format(dateyl, "dd-MM-yyyy"), "TRADING")
                CrystalReportViewer1.ReportSource = rpt1
            Else
                Dim rpt1 As New rptTreadingMain2
                rpt1.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(Format(dateyf, "dd-MM-yyyy"), Format(dateyl, "dd-MM-yyyy"), "TRADING")
                CrystalReportViewer1.ReportSource = rpt1
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class