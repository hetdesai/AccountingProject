Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmprocessshow
    Dim ds As New DataSet2
    Private Sub frmprocessshow_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmprocessshow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("select * from sale1", cn)
            da.Fill(ds, "sale1")
            da = New SqlDataAdapter("select * from tblAccount", cn)
            da.Fill(ds, "tblAccount")
            da = New SqlDataAdapter("Select * from sale", cn)
            da.Fill(ds, "sale")
            If frmMainScreen.process = "Month Process" Then
                ' Dim rpt As New rptoutmonthlyprocess
                Dim rpt As New rptmonthprocesscross2
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam("12-12-2011", "12-12-2011", "Month Process")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.process = "Process Month" Then
                Dim rpt As New rptprocessmonthcross2
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam("12-12-2011", "12-12-2011", "Process Month")
                CrystalReportViewer1.ReportSource = rpt
            End If
            close1()

        Catch ex As Exception

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