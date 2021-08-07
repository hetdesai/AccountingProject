Imports System.Data.SqlClient
Public Class frmp1
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim ds As New DataSet2

    Private Sub frmp1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmp1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dat1 As New Date
            Dim dat2 As New Date
            Dim dat As String
            dat1 = frmP2.MaskedTextBox1.Text
            dat2 = frmP2.MaskedTextBox2.Text
            dat = "tblLedg.date >='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and tblLedg.date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
            connect()
            Dim sql As String
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='Fals' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("p&l1").NewRow
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
                ds.Tables("P&l1").Rows.Add(dt)
            End While
            dr.Close()
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='Fals' and tblMH.ASD='" & "Expenditure" & "' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("P&l2").NewRow
                dt.Item("ASD") = "Expenditure"
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = dr.Item(3)
                '      If dr.Item("bal") < 0 Then
                dt.Item("dr") = (dr.Item("bal").ToString * -1)
                dt.Item("cr") = 0
                '   Else
                '  dt.Item("cr") = (dr.Item("bal").ToString)
                '  dt.Item("dr") = 0
                '    End If
                ds.Tables("P&l2").Rows.Add(dt)
            End While
            dr.Close()
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='Fals' and tblMH.ASD='" & "Income" & "' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("P&l3").NewRow
                dt.Item("ASD") = "Income"
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = dr.Item(3)
                '   If dr.Item("bal") < 0 Then
                'dt.Item("dr") = (dr.Item("bal").ToString * -1)
                '   dt.Item("cr") = 0
                '  Else
                dt.Item("cr") = (dr.Item("bal").ToString)
                dt.Item("dr") = 0
                ' End If
                ds.Tables("P&l3").Rows.Add(dt)
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
                Dim dt As DataRow = ds.Tables("P&l2").NewRow
                dt.Item("ASD") = "Expenditure"
                dt.Item("Shead") = "Treading"
                dt.Item("ACname") = "Gross Profit/Loss Transfer from Trading"
                dt.Item("Mhead") = "asd"
                dt.Item("Dr") = (income - expenditure) * -1
                ds.Tables("P&l2").Rows.Add(dt)
            ElseIf income - expenditure > 0 Then
                'MsgBox("het")
                Dim dt As DataRow = ds.Tables("P&l3").NewRow
                dt.Item("ASD") = "Income"
                dt.Item("Shead") = "Treading"
                dt.Item("ACname") = "Gross Profit/Loss Transfer from Trading"
                dt.Item("Mhead") = "asd"
                dt.Item("Cr") = income - expenditure

                ds.Tables("P&l3").Rows.Add(dt)
            End If
            Dim i As Integer
            Dim ex1 As Decimal
            Dim in1 As Decimal

            For i = 0 To ds.Tables("P&l2").Rows.Count - 1
                ex1 = ex1 + ds.Tables("P&l2").Rows(i).Item("Dr")
            Next
            For i = 0 To ds.Tables("P&l3").Rows.Count - 1
                in1 = in1 + ds.Tables("P&l3").Rows(i).Item("Cr")
            Next
            If in1 - ex1 > 0 Then
                Dim dt As DataRow = ds.Tables("P&l2").NewRow
                dt.Item("ASD") = "Expenditure"
                dt.Item("Shead") = "P&l1"
                dt.Item("ACname") = "Net Profit/Loss Transfer to BS"
                dt.Item("Mhead") = "zzzz"
                dt.Item("Dr") = (in1 - ex1)
                ds.Tables("P&l2").Rows.Add(dt)
            Else
                Dim dt As DataRow = ds.Tables("P&l3").NewRow
                dt.Item("ASD") = "Income"
                dt.Item("Shead") = "P&l1"
                dt.Item("ACname") = "Net Profit/Loss Transfer to BS"
                dt.Item("Mhead") = "zzzz"
                dt.Item("Cr") = (in1 - ex1) * -1
                ds.Tables("P&l3").Rows.Add(dt)
            End If

            Dim rpt3 As New rptpl1
            rpt3.SetDataSource(ds.Tables("P&l2"))
            Dim rpt2 As New rptpl2
            rpt2.SetDataSource(ds.Tables("P&l3"))
            If frmP2.rpttype = "Account" Then
                Dim rpt1 As New rptplmain
                rpt1.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt1
                CrystalReportViewer1.ParameterFieldInfo = passparam(Format(dateyf, "dd-MM-yyyy"), Format(dateyl, "dd-MM-yyyy"), "Profit & Loss")
            Else
                Dim rpt1 As New rptplmain2
                rpt1.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt1
                CrystalReportViewer1.ParameterFieldInfo = passparam(Format(dateyf, "dd-MM-yyyy"), Format(dateyl, "dd-MM-yyyy"), "Profit & Loss")
            End If

            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class