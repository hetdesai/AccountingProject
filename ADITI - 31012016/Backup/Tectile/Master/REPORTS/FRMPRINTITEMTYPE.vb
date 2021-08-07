Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class FRMPRINTITEMTYPE
    Dim DS As New DataSet2
    Dim DA As New SqlDataAdapter

    Private Sub FRMPRINTITEMTYPE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            connect()

            DA = New SqlDataAdapter("SELECT * FROM TBLITTYPE", cn)
            DA.Fill(DS, "TBLITTYPE")
            Dim RPT As New RPTITTYPE
            RPT.SetDataSource(DS)
            CrystalReportViewer1.ParameterFieldInfo = passparam()
            CrystalReportViewer1.ReportSource = RPT
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function passparam() As ParameterFields
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
            field3.ParameterFieldName = "title"
            value3.Value = "Item Type"
            field3.CurrentValues.Add(value3)
            p1.Add(field3)
            field4.ParameterFieldName = "companyname"
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
End Class