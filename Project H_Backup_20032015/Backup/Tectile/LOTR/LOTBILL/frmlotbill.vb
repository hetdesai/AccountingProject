Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmlotbill

    Private Sub frmlotbill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim ds As New DataSet2
            Dim da As New SqlDataAdapter
            Dim rpt1 As New rptlotbill
            Dim rpt2 As New rptlotbill2
            Dim rpt3 As New rptlotbill3
            da = New SqlDataAdapter("Select * from sale1", cn)
            da.Fill(ds, "sale1")
            Dim billno As String
            Dim i As Integer
            billno = "where "
            For i = 0 To frmlotbillselection.CheckedListBox1.CheckedItems.Count - 1
                billno = billno & "billno='" & frmlotbillselection.CheckedListBox1.CheckedItems(i).ToString & "' OR "
            Next
            billno = billno.Substring(0, billno.Length - 4)
            da = New SqlDataAdapter("select * from sale " & billno, cn)
            da.Fill(ds, "sale")
            da = New SqlDataAdapter("select * from tblaccount", cn)
            da.Fill(ds, "tblaccount")
            da = New SqlDataAdapter("select * from tblLotr", cn)
            da.Fill(ds, "tblLotr")
            rpt1.SetDataSource(ds)
            rpt2.SetDataSource(ds)
            rpt3.SetDataSource(ds)
            CrystalReportViewer1.ParameterFieldInfo = param1()
            CrystalReportViewer1.ReportSource = rpt1
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function param1() As ParameterFields
        Dim p1 As New ParameterFields
        Dim field3 As New ParameterField
        Dim value3 As New ParameterDiscreteValue
        Dim field4 As New ParameterField
        Dim value4 As New ParameterDiscreteValue
        Dim field5 As New ParameterField
        Dim value5 As New ParameterDiscreteValue
        Dim field6 As New ParameterField
        Dim value6 As New ParameterDiscreteValue
        Dim field7 As New ParameterField
        Dim value7 As New ParameterDiscreteValue
        Dim field8 As New ParameterField
        Dim value8 As New ParameterDiscreteValue
        Dim field9 As New ParameterField
        Dim value9 As New ParameterDiscreteValue
        Dim field10 As New ParameterField
        Dim value10 As New ParameterDiscreteValue
        Dim field11 As New ParameterField
        Dim value11 As New ParameterDiscreteValue
        Dim field12 As New ParameterField
        Dim value12 As New ParameterDiscreteValue
        Dim field13 As New ParameterField
        Dim value13 As New ParameterDiscreteValue
        Dim field14 As New ParameterField
        Dim value14 As New ParameterDiscreteValue
        Dim field15 As New ParameterField
        Dim value15 As New ParameterDiscreteValue
        Dim field16 As New ParameterField
        Dim value16 As New ParameterDiscreteValue
        Dim field17 As New ParameterField
        Dim value17 As New ParameterDiscreteValue
        Dim field18 As New ParameterField
        Dim value18 As New ParameterDiscreteValue
        'Now set first param
        field3.ParameterFieldName = "termcon"
        value3.Value = frmcomdis.termscondition
        field3.CurrentValues.Add(value3)
        p1.Add(field3)
        field4.ParameterFieldName = "Comapnyname"
        value4.Value = frmcomdis.CompanyName
        field4.CurrentValues.Add(value4)
        p1.Add(field4)
        field5.ParameterFieldName = "Address"
        value5.Value = frmcomdis.add1 & vbNewLine & frmcomdis.add2 & vbNewLine & frmcomdis.add3 & vbNewLine & frmcomdis.City & "," & frmcomdis.state & "-" & frmcomdis.pincode
        field5.CurrentValues.Add(value5)
        p1.Add(field5)
        field6.ParameterFieldName = "tin"
        value6.Value = frmcomdis.tin
        field6.CurrentValues.Add(value6)
        p1.Add(field6)
        field7.ParameterFieldName = "cst"
        value7.Value = frmcomdis.cst
        field7.CurrentValues.Add(value7)
        p1.Add(field7)
        field8.ParameterFieldName = "pan"
        value8.Value = frmcomdis.pan
        field8.CurrentValues.Add(value8)
        p1.Add(field8)
        field9.ParameterFieldName = "tan"
        value9.Value = frmcomdis.tan
        field9.CurrentValues.Add(value9)
        p1.Add(field9)
        field10.ParameterFieldName = "ecc"
        value10.Value = frmcomdis.ecc
        field10.CurrentValues.Add(value10)
        p1.Add(field10)
        field11.ParameterFieldName = "juriductioncity"
        value11.Value = frmcomdis.juricity
        field11.CurrentValues.Add(value11)
        p1.Add(field11)
        field12.ParameterFieldName = "phone1"
        value12.Value = frmcomdis.phone1
        field12.CurrentValues.Add(value12)
        p1.Add(field12)
        field13.ParameterFieldName = "phone2"
        value13.Value = frmcomdis.phone2
        field13.CurrentValues.Add(value13)
        p1.Add(field13)
        field14.ParameterFieldName = "phone3"
        value14.Value = frmcomdis.phone3
        field14.CurrentValues.Add(value14)
        p1.Add(field14)
        field15.ParameterFieldName = "city"
        value15.Value = frmcomdis.phone1
        field15.CurrentValues.Add(value15)
        p1.Add(field15)
        field16.ParameterFieldName = "website"
        value16.Value = frmcomdis.website
        field16.CurrentValues.Add(value16)
        p1.Add(field16)
        field17.ParameterFieldName = "fax"
        value17.Value = frmcomdis.fax
        field17.CurrentValues.Add(value17)
        p1.Add(field17)

        Return p1
    End Function

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class