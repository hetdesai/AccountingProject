Imports CrystalDecisions.Shared
Public Class frmprintzoom
    Private Sub frmprintzoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If zoomprint = 4 Then
                Dim rpt As New zoom4
                rpt.SetDataSource(frmnewzoom4.ds1)
                Dim p1 As New ParameterFields
                Dim field1 As New ParameterField ' ParameterField for 1st param
                Dim value1 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field2 As New ParameterField ' ParameterField for 1st param
                Dim value2 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field3 As New ParameterField ' ParameterField for 1st param
                Dim value3 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field4 As New ParameterField
                Dim value4 As New ParameterDiscreteValue
                'Now set first param
                field1.ParameterFieldName = "Companyname"
                value1.Value = frmcomdis.CompanyName
                field1.CurrentValues.Add(value1)
                p1.Add(field1)
                field2.ParameterFieldName = "Acname"
                value2.Value = frmnewzoom4.Label5.Text
                field2.CurrentValues.Add(value2)
                p1.Add(field2)
                field3.ParameterFieldName = "Opening balance"
                value3.Value = frmnewzoom4.Label7.Text
                field3.CurrentValues.Add(value3)
                p1.Add(field3)
                field4.ParameterFieldName = "Month"
                value4.Value = frmnewzoom4.Label10.Text
                field4.CurrentValues.Add(value4)
                p1.Add(field4)
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.ParameterFieldInfo = p1
            ElseIf zoomprint = 3 Then
                Dim rpt As New zoom3
                rpt.SetDataSource(frmnewZoom3.ds)
                Dim p1 As New ParameterFields
                Dim field1 As New ParameterField ' ParameterField for 1st param
                Dim value1 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field2 As New ParameterField ' ParameterField for 1st param
                Dim value2 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field3 As New ParameterField ' ParameterField for 1st param
                Dim value3 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field4 As New ParameterField
                Dim value4 As New ParameterDiscreteValue
                'Now set first param
                field1.ParameterFieldName = "Companyname"
                value1.Value = frmcomdis.CompanyName
                field1.CurrentValues.Add(value1)
                p1.Add(field1)
                field2.ParameterFieldName = "Acname"
                value2.Value = frmnewZoom3.Label5.Text
                field2.CurrentValues.Add(value2)
                p1.Add(field2)
                field3.ParameterFieldName = "Opening balance"
                value3.Value = frmnewZoom3.Label7.Text
                field3.CurrentValues.Add(value3)
                p1.Add(field3)
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.ParameterFieldInfo = p1
            ElseIf zoomprint = 2 Then
                Dim rpt As New zoom2t2
                rpt.SetDataSource(frmnewzoom2.zoomdata)
                Dim p1 As New ParameterFields
                Dim field1 As New ParameterField ' ParameterField for 1st param
                Dim value1 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field2 As New ParameterField ' ParameterField for 1st param
                Dim value2 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field3 As New ParameterField ' ParameterField for 1st param
                Dim value3 As New ParameterDiscreteValue  ' ParameterField for 2nd param
                Dim field4 As New ParameterField
                Dim value4 As New ParameterDiscreteValue
                'Now set first param
                field1.ParameterFieldName = "Companyname"
                value1.Value = frmcomdis.CompanyName
                field1.CurrentValues.Add(value1)
                p1.Add(field1)
                field2.ParameterFieldName = "Acname"
                value2.Value = frmnewzoom2.Label4.Text
                field2.CurrentValues.Add(value2)
                p1.Add(field2)
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.ParameterFieldInfo = p1
            ElseIf zoomprint = 1 Then

            End If
           
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class