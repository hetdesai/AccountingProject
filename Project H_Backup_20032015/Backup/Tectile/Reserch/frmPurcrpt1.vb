Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPurcrpt1
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet2
    '  Dim rpt As New rptpurc1

    Private Sub frmPurcrpt1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            da = New SqlDataAdapter("Select * from tblPurchase", cn)
            da.Fill(ds, "tblPurchase")
            '   Dim rpt As New rptpurc1
            '      rpt.SetDataSource(ds)
            Dim p1 As New ParameterFields ' tHis requires only one object
            Dim p2 As New ParameterField ' ParameterField for 1st param
            Dim p22 As New ParameterField ' ParameterField for 2nd param
            Dim p3 As New ParameterDiscreteValue 'ParameterDiscreteValue for 1st param
            Dim p4 As New ParameterDiscreteValue 'ParameterDiscreteValue for 2nd param

            'Now set first param

            p2.ParameterFieldName = "One"
            p3.Value = "BillNo"
            p2.CurrentValues.Add(p3)
            p1.Add(p2)

            p22.ParameterFieldName = "Two"
            p4.Value = "NameCr"
            p22.CurrentValues.Add(p4)
            p1.Add(p22)

            CrystalReportViewer1.ParameterFieldInfo = p1 'crv1 is crystal report viewer
            'Now set second param

            '        p22.ParameterFieldName = "P2"
            '       p4.Value = "Second Value"
            '      p22.CurrentValues.Add(p4)
            '     p1.Add(p22)
            '    CrystalReportViewer1.ParameterFieldInfo = p1
            '   CrystalReportViewer1.ReportSource = rpt
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
End Class