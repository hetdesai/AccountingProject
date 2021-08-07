Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.Shared
Public Class frmsalebill
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet2
    Dim rptmain As New rptbill
    Dim rpttax As New rptbilltax2
    Dim rptitem As New rptbillitem2
    Dim rptsum As New Copy_of_rptbillitem2
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
    Private Sub frmsalebill_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged

    End Sub

    Private Sub frmsalebill_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmsalebill_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmSale.Show()
    End Sub
    Private Sub frmbill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmbill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim rptlogo As New rptlogo
            Dim dt As DataRow = ds.Tables("tblLogo").NewRow
            Dim lFSFileStream As FileStream
            Dim lBRBinaryReader As BinaryReader
            Dim lBImageByte As Byte()
            lFSFileStream = New FileStream(Application.StartupPath & "\Images\" & frmcomdis.companycode, FileMode.Open)
            lBRBinaryReader = New BinaryReader(lFSFileStream)
            lBImageByte = New Byte(lFSFileStream.Length + 1) {}
            lBImageByte = lBRBinaryReader.ReadBytes(Convert.ToInt32(lFSFileStream.Length))
            dt.Item(0) = lBImageByte
            ds.Tables("tblLogo").Rows.Add(dt)
            lFSFileStream.Close()
            rptlogo.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rptlogo
            da = New SqlDataAdapter("Select * from saltax", cn)
            da.Fill(ds, "salTax")
            rpttax.SetDataSource(ds)
            'new editing
            da = New SqlDataAdapter("Select * from salec1 where (billno='" & frmSale.billno & "')", cn)
            da.Fill(ds, "salec1")
            da = New SqlDataAdapter("Select * from salesc,tblAccount where tblAccount.ACCode=salesc.ACCode and (billno='" & frmSale.billno & "')", cn)
            da.Fill(ds, "Datatable3")
            rptmain.SetDataSource(ds)
            Dim i As Integer
            Dim deletecombo As New ListBox
            For i = 0 To ds.Tables("saltax").Rows.Count - 1
                If ds.Tables("saltax").Rows(i).Item("Taxnara").ToString = "Gr Amt" Or ds.Tables("saltax").Rows(i).Item("Taxnara").ToString = "Net Amt" Then
                    deletecombo.Items.Add(i)
                End If
            Next
            For i = 0 To deletecombo.Items.Count - 1
                ds.Tables("saltax").Rows(deletecombo.Items(i)).Delete()
            Next
            'new editng end
            rptitem.SetDataSource(ds)
            rptsum.SetDataSource(ds)
            CrystalReportViewer1.ParameterFieldInfo = param1()
            CrystalReportViewer1.ReportSource = rptmain
            CrystalReportViewer1.Zoom(70)
            '   rptmain .PrintOptions .
            rptmain.PrintOptions.PrinterName = "EPSON TM-T81 Receipt"
            Me.CrystalReportViewer1.PrintReport()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class