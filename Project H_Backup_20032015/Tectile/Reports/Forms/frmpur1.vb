Imports System.Data.SqlClient
Public Class frmpur1
    Dim ds As New DataSet2
    Dim da As New SqlDataAdapter

    Private Sub frmpur1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmpur1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\" & frmcomdis.companycode & "NEWdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            cn.Open()
             If frmMainScreen.report = "Register Detail" Then
                Dim rpt As New purdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "tblPurchase")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Register Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Register Monthly" Then
                Dim rpt As New purmonthsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "tblPurchase")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Register Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Register Summary" Then
                Dim rpt As New purregsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "tblPurchase")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Register Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Detail" Then
                Dim rpt As New groupbill
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Bill Wise" Then
                Dim rpt As New groupdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Monthly" Then
                Dim rpt As New groupmonth
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Summary" Then
                Dim rpt As New grouplist
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Party Detail" Then
                Dim rpt As New partybill
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "DAtatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Party Monthly" Then
                Dim rpt As New partymonth
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "DAtatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Party Summary" Then
                Dim rpt As New partylist
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "DAtatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Party Bill Wise" Then
                Dim rpt As New partydetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "DAtatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Item Detail" Then
                Dim rpt As New Itemlistdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Item Monthly" Then
                Dim rpt As New itemmonth
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Item Summary" Then
                Dim rpt As New itemsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Party Detail" Then
                Dim rpt As New grouppartybill
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Party Monthly" Then
                Dim rpt As New grouppartymonth
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Party Summary" Then
                Dim rpt As New grouppartylist
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Group Party Bill Wise" Then
                Dim rpt As New grouppartydetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Party Item Detail" Then
                '     MsgBox(frmpurrpt.sql)
                Dim rpt As New PartyItemlistdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Party Item Monthly" Then
                Dim rpt As New partyitemmonth
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "Party Item Summary" Then
                Dim rpt As New partyitemsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable2")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Item Summary")
                CrystalReportViewer1.ReportSource = rpt
                '************************************for sale********************
            ElseIf frmMainScreen.report = "SRegister Detail" Then
                Dim rpt As New sregdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salesc")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Register Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SRegister Monthly" Then
                Dim rpt As New sregmonthly
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salesc")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Register Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SRegister Summary" Then
                Dim rpt As New sregsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salesc")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Register Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Detail" Then
                Dim rpt As New sgroupdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable3")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Bill Wise" Then
                Dim rpt As New sgroupfulldetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable4")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Monthly" Then
                Dim rpt As New sgroupmonthly
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable3")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Summary" Then
                Dim rpt As New sgroupsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable3")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SParty Detail" Then
                Dim rpt As New spartydetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salesc")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SParty Monthly" Then
                Dim rpt As New spartymonthly
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salesc")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SParty Summary" Then
                Dim rpt As New spartysum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salesc")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SParty Bill Wise" Then
                Dim rpt As New spartyfulldetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salec1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SItem Detail" Then
                Dim rpt As New sitemdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salec1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SItem Monthly" Then
                Dim rpt As New sitemmonthly
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salec1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SItem Summary" Then
                Dim rpt As New sitemsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salec1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Party Detail" Then
                Dim rpt As New sgrouppartydetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable3")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Party Monthly" Then
                Dim rpt As New sgrouppartymonthly
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable3")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Party Summary" Then
                Dim rpt As New sgrouppartysum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable3")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Summary")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SGroup Party Bill Wise" Then
                Dim rpt As New sgrouppartyfulldetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "Datatable4")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Group Party Bill Wise")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SParty Item Detail" Then
                '    MsgBox(frmpurrpt.sql)
                Dim rpt As New spartyitemdetail
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salec1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Item Detail")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SParty Item Monthly" Then
                Dim rpt As New spartyitemmonthly
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salec1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Item Monthly")
                CrystalReportViewer1.ReportSource = rpt
            ElseIf frmMainScreen.report = "SParty Item Summary" Then
                '   MsgBox(frmpurrpt.sql)
                Dim rpt As New spartyitemsum
                da = New SqlDataAdapter(frmpurrpt.sql, cn)
                da.Fill(ds, "salec1")
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmpurrpt.MaskedTextBox1.Text, frmpurrpt.MaskedTextBox2.Text, "Party Item Summary")
                CrystalReportViewer1.ReportSource = rpt
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class