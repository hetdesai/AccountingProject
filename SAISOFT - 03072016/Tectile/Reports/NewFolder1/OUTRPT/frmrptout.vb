Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.Mail

Public Class frmrptout
    Dim ds As New DataSet2
    Dim mail As New MailMessage()
    Dim CrExportOptions As ExportOptions
    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
    'Dim CrFormatTypeOptions As New ExcelFormatOptions
    Dim RPT As New rptout
    Dim RPT1 As New rptoutsum1
    Dim RPt2 As New rptoutgrp1
    Dim RPT3 As New rptoutgrpsum1
    Private Sub frmrptout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        connect()
            Dim da As New SqlDataAdapter
            Dim dat As New Date
            Dim dat2 As New Date
            Dim OUBNO As New ListBox
            Dim OUBNO2 As New ListBox
            Dim NETAMT As New ListBox
            Dim NETAMT2 As New ListBox
            Dim ACNAME1 As New ListBox
            Dim ACNAME2 As New ListBox
            Dim BILLDT As New ListBox
            Dim DR As SqlDataReader
            Dim CMD As New SqlCommand
            Dim ACCCOUNT1 As String = "("
            Dim ACCOUNT2 As String = "AND ("
            Dim KJ As New Integer
            If FRMOUTSELE.CheckedListBox3.CheckedItems.Count = 0 Then
                For KJ = 0 To FRMOUTSELE.CheckedListBox3.Items.Count - 1
                    ACCCOUNT1 = ACCCOUNT1 & "ACNAME='" & FRMOUTSELE.CheckedListBox3.Items(KJ).ToString & "' OR "
                    ACCOUNT2 = ACCOUNT2 & "NAME='" & FRMOUTSELE.CheckedListBox3.Items(KJ).ToString & "' OR "
                Next

            Else
                For KJ = 0 To FRMOUTSELE.CheckedListBox3.CheckedItems.Count - 1
                    ACCCOUNT1 = ACCCOUNT1 & "ACNAME='" & FRMOUTSELE.CheckedListBox3.CheckedItems(KJ).ToString & "' OR "
                    ACCOUNT2 = ACCOUNT2 & "NAME='" & FRMOUTSELE.CheckedListBox3.CheckedItems(KJ).ToString & "' OR "
                Next

            End If
            ACCCOUNT1 = ACCCOUNT1.Substring(0, ACCCOUNT1.Length - 4) & ")"
            ACCOUNT2 = ACCOUNT2.Substring(0, ACCOUNT2.Length - 4) & ")"
            dat = FRMOUTSELE.MaskedTextBox1.Text
            dat2 = FRMOUTSELE.MaskedTextBox2.Text
            Dim j As Integer
            '   For j = 0 To 300
            CMD = New SqlCommand("select NAME,oubno,NETAMT,BILLDT from salesc where billdt<='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' " & ACCOUNT2 & " UNION select ACNAME,oubno,NETAMT,date from TBLOUB where DATE<='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' AND BOOK='SALEs' AND " & ACCCOUNT1, cn)
            DR = CMD.ExecuteReader
            While DR.Read
                OUBNO.Items.Add(DR.Item("OUBNO"))
                NETAMT.Items.Add(DR.Item("NETAMT"))
                ACNAME1.Items.Add(DR.Item("NAME"))
                BILLDT.Items.Add(Format(DR.Item("BILLDT"), "dd-MM-yyyy"))
            End While
            DR.Close()
            Dim I As Integer
            Dim billdt1 As New Date
            Dim pmtdt As New Date

            ' MsgBox(OUBNO.Items.Count)
            ' MsgBox(OUBNO.Items.Count)
            For I = 0 To OUBNO.Items.Count - 1
                CMD = New SqlCommand("SELECT SUM(PAIDAMT)+SUM(RD)+SUM(CLAIM)+SUM(TDS)+SUM(DISCOUNT) FROM BANKT WHERE OUBNO='" & OUBNO.Items(I).ToString & "' and date<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and refbook='Sales' GROUP BY OUBNO", cn)
                DR = CMD.ExecuteReader
                If DR.HasRows = False Then
                    DR.Close()
                    Dim DT As DataRow = ds.Tables("OUT1").NewRow
                    DT.Item(1) = OUBNO.Items(I).ToString
                    DT.Item(0) = ACNAME1.Items(I).ToString
                    DT.Item(2) = Val(NETAMT.Items(I).ToString)
                    DT.Item(3) = 0
                    DT.Item(4) = BILLDT.Items(I).ToString
                    DT.Item(5) = Val(NETAMT.Items(I).ToString)
                    billdt1 = BILLDT.Items(I).ToString
                    pmtdt = FRMOUTSELE.MaskedTextBox2.Text
                    DT.Item(6) = DateDiff(DateInterval.Day, billdt1, pmtdt)
                    ds.Tables("OUT1").Rows.Add(DT)
                Else
                    While DR.Read
                        If Val(NETAMT.Items(I).ToString) > Val((DR.Item(0))) Then
                            Dim DT As DataRow = ds.Tables("OUT1").NewRow
                            DT.Item(1) = OUBNO.Items(I).ToString
                            DT.Item(0) = ACNAME1.Items(I).ToString
                            DT.Item(2) = Val(NETAMT.Items(I).ToString) - (DR.Item(0))
                            DT.Item(3) = 0
                            DT.Item(4) = BILLDT.Items(I).ToString
                            DT.Item(5) = Val(NETAMT.Items(I).ToString)
                            billdt1 = BILLDT.Items(I).ToString
                            pmtdt = FRMOUTSELE.MaskedTextBox2.Text
                            DT.Item(6) = DateDiff(DateInterval.Day, billdt1, pmtdt)
                            ds.Tables("OUT1").Rows.Add(DT)
                        Else
                            Dim DT As DataRow = ds.Tables("OUT1").NewRow
                            DT.Item(1) = OUBNO.Items(I).ToString
                            DT.Item(0) = ACNAME1.Items(I).ToString
                            '  DT.Item(2) = Val(NETAMT.Items(I).ToString) - (DR.Item(0))
                            DT.Item(2) = 0
                            DT.Item(3) = 0
                            DT.Item(4) = BILLDT.Items(I).ToString
                            DT.Item(5) = Val(NETAMT.Items(I).ToString)
                            '        ds.Tables("OUT1").Rows.Add(DT)
                        End If
                    End While
                    DR.Close()
                End If
            Next
            Dim K As Integer
            For K = 0 To ds.Tables("OUT1").Rows.Count - 1
                If ACNAME2.Items.Contains(ds.Tables("OUT1").Rows(K).Item(0).ToString) = True Then
                Else
                    ACNAME2.Items.Add(ds.Tables("OUT1").Rows(K).Item(0))
                    Dim AMT As Decimal = 0
                    Dim ADV As Decimal = 0
                    CMD = New SqlCommand("SELECT SUM(PAIDAMT) FROM BANKT WHERE BILLDT>'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' AND DATE<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and refbook='Sales'", cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        Try
                            AMT = DR.Item(0)
                        Catch ex As Exception
                        End Try
                    End While
                    DR.Close()
                    CMD = New SqlCommand("SELECT AMOUNT FROM ADV WHERE DATE <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' AND ACNAME='" & ds.Tables("OUT1").Rows(K).Item(0).ToString & "' and isclear='f'", cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        ADV = DR.Item(0)
                    End While
                    DR.Close()
                    MsgBox(ADV)
                    ds.Tables("OUT1").Rows(K).Item(3) = ADV + AMT
                End If
            Next
            da = New SqlDataAdapter("select * from tblaccount WHERE " & ACCCOUNT1, cn)
            da.Fill(ds, "tblaccount")
            '  Next
            If FRMOUTSELE.ComboBox1.Text = "Party Detail" Then
                RPT.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = RPT
                CrystalReportViewer1.ParameterFieldInfo = passparam()
            ElseIf FRMOUTSELE.ComboBox1.Text = "Party Summary" Then
                RPT1.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = RPT1
                CrystalReportViewer1.ParameterFieldInfo = passparam()
            ElseIf FRMOUTSELE.ComboBox1.Text = "Group+Party Detail" Then

                RPt2.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = RPt2
                CrystalReportViewer1.ParameterFieldInfo = passparam()
            ElseIf FRMOUTSELE.ComboBox1.Text = "Group+Party Summary" Then
                RPT3.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = RPT3
                CrystalReportViewer1.ParameterFieldInfo = passparam()

            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Function passparam() As ParameterFields
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
            field1.ParameterFieldName = "COMPANYNAME"
            value1.Value = frmcomdis.CompanyName
            field1.CurrentValues.Add(value1)
            p1.Add(field1)
            field2.ParameterFieldName = "ADDRESS"
            value2.Value = frmcomdis.add1 & "," & frmcomdis.add2 & "," & frmcomdis.add3
            field2.CurrentValues.Add(value2)
            p1.Add(field2)
            field3.ParameterFieldName = "BILLUPTO"
            value3.Value = FRMOUTSELE.MaskedTextBox1.Text
            field3.CurrentValues.Add(value3)
            p1.Add(field3)
            field4.ParameterFieldName = "PAYMENTUPTO"
            value4.Value = FRMOUTSELE.MaskedTextBox2.Text
            field4.CurrentValues.Add(value4)
            p1.Add(field4)
            Return p1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
    End Sub
    Private Sub RPTCHECK()
        If FRMOUTSELE.ComboBox1.Text = "Party Detail" Then
            CrExportOptions = RPT.ExportOptions
        ElseIf FRMOUTSELE.ComboBox1.Text = "Party Summary" Then
            CrExportOptions = RPT1.ExportOptions
        ElseIf FRMOUTSELE.ComboBox1.Text = "Group+Party Detail" Then
            CrExportOptions = RPt2.ExportOptions
        ElseIf FRMOUTSELE.ComboBox1.Text = "Group+Party Summary" Then
            CrExportOptions = RPT3.ExportOptions
        End If

    End Sub
    Private Sub RPTCHECK2()
        If FRMOUTSELE.ComboBox1.Text = "Party Detail" Then
            RPT.Export()
        ElseIf FRMOUTSELE.ComboBox1.Text = "Party Summary" Then
            RPT1.Export()
        ElseIf FRMOUTSELE.ComboBox1.Text = "Group+Party Detail" Then
            RPt2.Export()
        ElseIf FRMOUTSELE.ComboBox1.Text = "Group+Party Summary" Then
            RPT3.Export()
        End If

    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        CrDiskFileDestinationOptions.DiskFileName = "D:\" & FRMOUTSELE.ComboBox1.Text & Date.Today & ".PDF"
        CrFormatTypeOptions.FirstPageNumber = 1 ' Start Page in the Report
        CrFormatTypeOptions.LastPageNumber = 3 ' End Page in the Report
        CrFormatTypeOptions.UsePageRange = False
        RPTCHECK()
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        RPTCHECK2()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
        CrDiskFileDestinationOptions.DiskFileName = "D:\" & FRMOUTSELE.ComboBox1.Text & Date.Today & ".doc"
        CrFormatTypeOptions.FirstPageNumber = 1 ' Start Page in the Report
        CrFormatTypeOptions.LastPageNumber = 3 ' End Page in the Report
        CrFormatTypeOptions.UsePageRange = False
        RPTCHECK()
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.WordForWindows
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        RPTCHECK2()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim CrFormatTypeOptions As New ExcelFormatOptions
        CrDiskFileDestinationOptions.DiskFileName = "D:\" & FRMOUTSELE.ComboBox1.Text & Date.Today & ".xls"
        CrFormatTypeOptions.FirstPageNumber = 1 ' Start Page in the Report
        CrFormatTypeOptions.LastPageNumber = 3 ' End Page in the Report
        CrFormatTypeOptions.UsePageRange = False
        RPTCHECK()
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.Excel
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        RPTCHECK2()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        CrystalReportViewer1.PrintReport()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hetdesai13@gmail.com", "prakashbhai")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True

        mail = New MailMessage()
        TextBox1.Text = "hetdesai13@gmail.com"
        Dim addr() As String = TextBox1.Text.Split(",")
        Try
            mail.From = New MailAddress("hetdesai13@gmail.com", "het desai", System.Text.Encoding.UTF8)

            Dim i As Byte
            For i = 0 To addr.Length - 1
                mail.To.Add(addr(i))
            Next
            TextBox3.Text = "report"
            TextBox4.Text = "report"
            ListBox1.Items.Add("D:\1.PDF")
            mail.Subject = TextBox3.Text
            mail.Body = TextBox4.Text
            If ListBox1.Items.Count <> 0 Then
                For i = 0 To ListBox1.Items.Count - 1
                    mail.Attachments.Add(New Attachment(ListBox1.Items.Item(i)))
                Next
            End If
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            mail.ReplyTo = New MailAddress(TextBox1.Text)
            SmtpServer.Send(mail)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class