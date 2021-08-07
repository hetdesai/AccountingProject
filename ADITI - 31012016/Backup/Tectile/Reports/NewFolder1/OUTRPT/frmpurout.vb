Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmpurout
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet2
    Dim rpt As New rptout
    Dim RPT1 As New rptoutsum1
    Dim RPt2 As New rptoutgrp1
    Dim RPT3 As New rptoutgrpsum1
    Private Sub frmpurout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                    ACCOUNT2 = ACCOUNT2 & "NAMEcr='" & FRMOUTSELE.CheckedListBox3.Items(KJ).ToString & "' OR "
                Next

            Else

                For KJ = 0 To FRMOUTSELE.CheckedListBox3.CheckedItems.Count - 1
                    ACCCOUNT1 = ACCCOUNT1 & "ACNAME='" & FRMOUTSELE.CheckedListBox3.CheckedItems(KJ).ToString & "' OR "
                    ACCOUNT2 = ACCOUNT2 & "NAMEcr='" & FRMOUTSELE.CheckedListBox3.CheckedItems(KJ).ToString & "' OR "
                Next
            End If
            ACCCOUNT1 = ACCCOUNT1.Substring(0, ACCCOUNT1.Length - 4) & ")"
            ACCOUNT2 = ACCOUNT2.Substring(0, ACCOUNT2.Length - 4) & ")"
            dat = FRMOUTSELE.MaskedTextBox1.Text
            dat2 = FRMOUTSELE.MaskedTextBox2.Text
            Dim j As Integer
            '   For j = 0 To 300
            CMD = New SqlCommand("select NAMEcr,oubno,NETAMT,BILLDT from tblPurchase where billdt<='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' " & ACCOUNT2 & " UNION select ACNAME,oubno,NETAMT,date from TBLOUB where DATE<='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' AND BOOK='Purchase' AND " & ACCCOUNT1, cn)
            DR = CMD.ExecuteReader
            While DR.Read
                OUBNO.Items.Add(DR.Item("OUBNO"))
                NETAMT.Items.Add(DR.Item("NETAMT"))
                ACNAME1.Items.Add(DR.Item("NAMEcr"))
                BILLDT.Items.Add(Format(DR.Item("BILLDT"), "dd-MM-yyyy"))
            End While
            DR.Close()
            Dim I As Integer
            Dim billdt1 As New Date
            Dim pmtdt As New Date

            ' MsgBox(OUBNO.Items.Count)
            ' MsgBox(OUBNO.Items.Count)
            For I = 0 To OUBNO.Items.Count - 1
                CMD = New SqlCommand("SELECT SUM(PAIDAMT)+SUM(RD)+SUM(CLAIM)+SUM(TDS)+SUM(DISCOUNT) FROM BANKT WHERE OUBNO='" & OUBNO.Items(I).ToString & "' and date<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' GROUP BY OUBNO", cn)
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
                    CMD = New SqlCommand("SELECT SUM(PAIDAMT) FROM BANKT WHERE BILLDT>'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' AND DATE<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'", cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        Try
                            AMT = DR.Item(0)
                        Catch ex As Exception
                        End Try
                    End While
                    DR.Close()
                    CMD = New SqlCommand("SELECT AMOUNT FROM ADVpmt WHERE DATE <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' AND ACNAME='" & ds.Tables("OUT1").Rows(K).Item(0).ToString & "' and isclear='f'", cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        ADV = DR.Item(0)
                    End While
                    DR.Close()
                    ds.Tables("OUT1").Rows(K).Item(3) = ADV + AMT
                End If
            Next
            da = New SqlDataAdapter("select * from tblaccount WHERE " & ACCCOUNT1, cn)
            da.Fill(ds, "tblaccount")
            If FRMOUTSELE.ComboBox1.Text = "Party Detail" Then
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ReportSource = rpt
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
            '  rpt.SetDataSource(ds)
            ' CrystalReportViewer1.ReportSource = rpt
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
End Class