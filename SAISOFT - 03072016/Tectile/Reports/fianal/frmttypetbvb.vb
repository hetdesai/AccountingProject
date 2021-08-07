Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmttypetbvb
    Dim ds As New DataSet2
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Private Function param1() As ParameterFields
        Dim p1 As New ParameterFields
        Dim field4 As New ParameterField
        Dim value4 As New ParameterDiscreteValue
        Dim field5 As New ParameterField
        Dim value5 As New ParameterDiscreteValue
        field4.ParameterFieldName = "COMPANYNAME2"
        value4.Value = frmcomdis.CompanyName
        field4.CurrentValues.Add(value4)
        p1.Add(field4)
        ' field5.ParameterFieldName = "Address"
        'value5.Value = frmcomdis.add1 & vbNewLine & frmcomdis.add2 & vbNewLine & frmcomdis.add3
        'field5.CurrentValues.Add(value5)
        'p1.Add(field5)
        Return p1

    End Function

    Private Sub frmttypetbvb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmttypetbvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim sql As String
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            '    DataGridView1.Visible = False
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
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            '    DataGridView1.Visible = False
            connect()
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("trialbal1").NewRow
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
                If dr.Item("bal") < 0 Then
                    ds.Tables("trialbal1").Rows.Add(dt)
                End If
            End While
            dr.Close()
            Dim rpt1 As New rptttypedr
            rpt1.SetDataSource(ds.Tables("trialbal1"))
            sql = "Select ASD,tblledg.ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD"
            '    DataGridView1.Visible = False
            connect()
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim dt As DataRow = ds.Tables("trialbal2").NewRow
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
                If dr.Item("bal") > 0 Then
                    ds.Tables("trialbal2").Rows.Add(dt)
                End If
            End While
            dr.Close()
            Dim rpt2 As New rptttype2
            rpt2.SetDataSource(ds.Tables("trialbal2"))
            close1()
            ' DataGridView1.DataSource = ds.Tables("trialbal")
            Dim rpt As New rptttypemain
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ParameterFieldInfo = param1()
            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class