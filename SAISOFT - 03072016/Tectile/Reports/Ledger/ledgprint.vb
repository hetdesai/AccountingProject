Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class ledgprint
    Dim da As New SqlDataAdapter

    Private Sub ledgprint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub ledgprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = ledg.ledgdataset.Tables("tblLedg")
        If ledg.ledgtype = "Normal" Then
            Dim rpt As New rptLedger
            rpt.SetDataSource(ledg.ledgdataset)
            passparam()
            CrystalReportViewer1.ReportSource = rpt
        ElseIf ledg.ledgtype = "Detail" Then

        ElseIf ledg.ledgtype = "Monthly" Then
            Dim rpt As New rptledmonthly
            rpt.SetDataSource(ledg.ledgdataset)
            passparam()
            CrystalReportViewer1.ReportSource = rpt
        ElseIf ledg.ledgtype = "Monthly Summary" Then
            Dim rpt As New rptledmonthlysum
            rpt.SetDataSource(ledg.ledgdataset)
            passparam()
            CrystalReportViewer1.ReportSource = rpt
        ElseIf ledg.ledgtype = "Next Page" Then
            Dim rpt As New rptlednp
            rpt.SetDataSource(ledg.ledgdataset)
            passparam()
            CrystalReportViewer1.ReportSource = rpt
        ElseIf ledg.ledgtype = "Schedule" Then
            Dim rpt As New rptledsch
            rpt.SetDataSource(ledg.ledgdataset)
            passparam()
            CrystalReportViewer1.ReportSource = rpt
        ElseIf ledg.ledgtype = "Schedule Summary" Then
            Dim rpt As New rptledschsummary
            rpt.SetDataSource(ledg.ledgdataset)
            passparam()
            CrystalReportViewer1.ReportSource = rpt
        ElseIf ledg.ledgtype = "Ledger Summary" Then
            Dim rpt As New rptLedgersummary
            rpt.SetDataSource(ledg.ledgdataset)
            passparam()
            CrystalReportViewer1.ReportSource = rpt

        ElseIf ledg.ledgtype = "Confirmation" Then

        End If

        
    End Sub
    Private Sub passparam()
        Dim p1 As New ParameterFields ' tHis requires only one object
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
        field1.ParameterFieldName = "fromdate"
        value1.Value = disledg.MaskedTextBox1.Text
        field1.CurrentValues.Add(value1)
        p1.Add(field1)
        field2.ParameterFieldName = "Todate"
        value2.Value = disledg.MaskedTextBox2.Text
        field2.CurrentValues.Add(value2)
        p1.Add(field2)
        field3.ParameterFieldName = "title"
        value3.Value = "Ledger"
        field3.CurrentValues.Add(value3)
        p1.Add(field3)
        field4.ParameterFieldName = "Comapnyname"
        value4.Value = comname
        field4.CurrentValues.Add(value4)
        p1.Add(field4)
        field5.ParameterFieldName = "Address"
        value5.Value = "5,Ratan Nagar Society" & vbNewLine & "Bhestan,Surat"
        field5.CurrentValues.Add(value5)
        p1.Add(field5)
        CrystalReportViewer1.ParameterFieldInfo = p1

    End Sub
End Class