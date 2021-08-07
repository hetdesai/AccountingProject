Imports System.Data.SqlClient
Public Class frmbldis
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim ds As New DataSet2
    Private Sub frmbldis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dat1 As New Date
            Dim dat2 As New Date
            Dim dat As String
            dat1 = frmBSdis.MaskedTextBox1.Text
            dat2 = frmBSdis.MaskedTextBox2.Text
            dat = "tblLedg.date >='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and tblLedg.date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
        connect()
            Dim sql As String
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
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
                ds.Tables("p&l1").Rows.Add(dt)
            End While
            dr.Close()
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='Fals' and tblMH.ASD='" & "Liabilities" & "' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("p&l3").NewRow
                dt.Item("ASD") = "Liabilities"
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = dr.Item(3)
                '      If dr.Item("bal") < 0 Then
                '  dt.Item("dr") = (dr.Item("bal").ToString * -1)
                ' dt.Item("cr") = 0
                '   Else
                dt.Item("cr") = (dr.Item("bal").ToString)
                dt.Item("dr") = 0
                '    End If
                ds.Tables("p&l3").Rows.Add(dt)
            End While
            dr.Close()
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.Treading='Fals' and tblMH.ASD='" & "Assets" & "' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("p&l2").NewRow
                dt.Item("ASD") = "Assets"
                dt.Item("Shead") = dr.Item(2)
                dt.Item("ACname") = dr.Item(1)
                dt.Item("Mhead") = dr.Item(3)
                '   If dr.Item("bal") < 0 Then
                dt.Item("dr") = (dr.Item("bal").ToString * -1)
                dt.Item("cr") = 0
                '  Else
                'dt.Item("cr") = (dr.Item("bal").ToString)
                'dt.Item("dr") = 0
                ' End If
                ds.Tables("p&l2").Rows.Add(dt)
            End While
            dr.Close()
            Dim expenditure As Decimal
            Dim income As Decimal
            sql = "Select ASD, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.ASD='" & "Expenditure" & "' and " & dat & " group by tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read
                expenditure = ((dr.Item("Balance")) * -1)
            End While
            dr.Close()
            sql = "Select ASD, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMH.ASD='" & "Income" & "' and " & dat & " group by tblMh.ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader()
            While dr.Read
                income = (dr.Item("Balance"))
            End While
            dr.Close()
            '   If income - expenditure < 0 Then
            Dim dt1 As DataRow = ds.Tables("p&l3").NewRow
            dt1.Item("ASD") = "Liabilities"
            dt1.Item("Shead") = "Reserve & Surplus"
            dt1.Item("ACname") = "Reserve & Surplus"
            dt1.Item("Mhead") = "asd"
            dt1.Item("Cr") = (income - expenditure)
            ds.Tables("p&l3").Rows.Add(dt1)
            If frmBSdis.rpttype = "Account" Then
                Dim rpt3 As New rptpl1
                rpt3.SetDataSource(ds.Tables("p&l3"))
                Dim rpt2 As New rptpl2
                rpt2.SetDataSource(ds.Tables("p&l2"))
                Dim rpt1 As New rptblmain
                rpt1.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt1

            Else
                Dim rpt3 As New rptpl1
                rpt3.SetDataSource(ds.Tables("p&l3"))
                Dim rpt2 As New rptpl2
                rpt2.SetDataSource(ds.Tables("p&l2"))
                Dim rpt1 As New rptblmain2
                rpt1.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt1
            End If
            CrystalReportViewer1.ParameterFieldInfo = passparam(Format(dateyf, "dd-MM-yyyy"), Format(dateyl, "dd-MM-yyyy"), "Balance Sheet")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class