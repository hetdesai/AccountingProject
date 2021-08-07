Imports System.Data.SqlClient
Public Class frmmanualposting

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmmanualposting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Dim i As Integer
        For i = 0 To ComboBox1.Items.Count - 1
            CheckedListBox1.Items.Add(ComboBox1.Items(i))
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text.ToUpper = "SALE" Then
            SALE()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "SALE WITHOUT POSTING" Then
            SALEWPOST()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "PURCHASE" Then
            PURCHASE()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "PURCHASE WITHOUT POSTING" Then
            PURCHASEWPOST()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "BANK R" Then
            BANKR()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "BANK P" Then
            BANKP()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "JOURNAL" Then
            JOUR()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "PREVIOUS" Then
            ' PREV()
            MsgBox("OK")
        ElseIf ComboBox1.Text.ToUpper = "OPENING" Then
            opening()
            MsgBox("OK")
        End If
    End Sub
    Private Sub opening()
        Try
            connect()
            '     *** SAN CHNG
            '     Dim cmd As New SqlCommand
            '    cmd = New SqlCommand("delete from tblLedg", cn)
            '   cmd.ExecuteNonQuery()
            '  Dim vrno As New ListBox
            ' Dim dr As SqlDataReader
            'cmd = New SqlCommand("select * from tblLEDG", cn)
            '  dr = cmd.ExecuteReader
            ' While dr.Read
            'vrno.Items.Add(dr.Item("serialno"))
            ' End While
            ' dr.Close()


            Dim cmd As New SqlCommand
            cmd = New SqlCommand("delete from tblLedg where book='OPBAL'", cn)
            cmd.ExecuteNonQuery()
            Dim vrno As New ListBox
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblOpen", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                vrno.Items.Add(dr.Item("serialno"))
            End While
            dr.Close()
            Dim i As Integer
            Dim LEDGVRNO As String
            Dim LEdGBOOK As String
            Dim LEDGDATE As New Date
            Dim LEDGACCODE As String
            Dim LEDGACNAME As String
            Dim LEDGDR As Decimal
            Dim LEDGCR As Decimal
            Dim LEDGBAL As Decimal
            Dim LEDGREMARK As String
            Dim LEDGREF As String
            Dim LEDGOPNAME As String
            Dim LEDGOPCODE As String
            ProgressBar1.Value = 0
            For i = 0 To vrno.Items.Count - 1
                ProgressBar1.Maximum = vrno.Items.Count
                ProgressBar1.Value = ProgressBar1.Value + 1
                connect()
                cmd = New SqlCommand("select * from tblOpen where serialno=" & vrno.Items(i), cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    LEDGVRNO = acycode & "/" & vrno.Items(i)
                    LEdGBOOK = "OPBAL"
                    MaskedTextBox1.Text = Format(dr.Item("date"), "dd-MM-yyyy")
                    LEDGACCODE = dr.Item("accode")
                    '     MsgBox(dr.Item("ACNAME"))
                    LEDGACNAME = dr.Item("acname")
                    If dr.Item("type") = "CR" Then
                        LEDGDR = 0
                        LEDGCR = dr.Item("Amount")
                    Else
                        LEDGDR = dr.Item("Amount")
                        LEDGCR = 0
                    End If
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = dr.Item("Discr")
                    LEDGREF = "ref"
                    LEDGOPCODE = 0
                    LEDGOPNAME = "OPBAL"
                End While
                dr.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim a() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(a, "tblLedg")
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SALE()
        Try
            Dim LEDGVRNO As String
            Dim LEdGBOOK As String
            Dim LEDGDATE As New Date
            Dim LEDGACCODE As String
            Dim LEDGACNAME As String
            Dim LEDGDR As Decimal
            Dim LEDGCR As Decimal
            Dim LEDGBAL As Decimal
            Dim LEDGREMARK As String
            Dim LEDGREF As String
            Dim LEDGOPNAME As String
            Dim LEDGOPCODE As String

            Dim BILLNO As New ListBox
            Dim VRNO As New ListBox
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim COUNT As Integer = 0
            connect()
            CMD = New SqlCommand("delete from tblledg where book='Sales'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("delete from tbljour where type='JVSL'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Delete from tblLedg where book='JVSL'", cn)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("sELECT * FROM SALESC", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                BILLNO.Items.Add(DR.Item("OUBNO"))
                VRNO.Items.Add(DR.Item("VRNO"))
                COUNT = COUNT + 1
            End While
            DR.Close()
            Dim I As Integer
            ProgressBar1.Value = 0
            For I = 0 To COUNT - 1
                ProgressBar1.Maximum = COUNT
                ProgressBar1.Value = ProgressBar1.Value + 1
                connect()
                Dim jvvrno As String
                CMD = New SqlCommand("sELECT * FROM SALESC WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Sales"
                    '   MsgBox(Format(DR.Item("billdt"), "dd-MM-yyyy"))
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accodecr")
                    LEDGACNAME = DR.Item("namecr")
                    LEDGDR = 0
                    LEDGCR = DR.Item("gramt")
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accode")
                    LEDGOPNAME = DR.Item("name")
                    jvvrno = DR.Item("jVVrno")
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim a() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(a, "tblLedg")
                connect()
                CMD = New SqlCommand("sELECT * FROM SALESC WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Sales"
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accode")
                    LEDGACNAME = DR.Item("name")
                    LEDGDR = DR.Item("netamt")
                    LEDGCR = 0
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accodecr")
                    LEDGOPNAME = DR.Item("namecr")
                    jvvrno = DR.Item("jVVrno")
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim b() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(b, "tblLedg")
                connect()
                Dim tax As New ListBox
                Dim taxnara As New ListBox
                Dim changable As New ListBox
                Dim value As New ListBox
                Dim poname As New ListBox
                Dim pocode As New ListBox
                Dim al As New ListBox
                Dim onwhich As New ListBox
                Dim optype As New ListBox
                Dim amt As New ListBox
                Dim ispost As New ListBox
                CMD = New SqlCommand("Select * from saltax where vrno='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                Dim k As Integer
                While DR.Read
                    tax.Items.Add(DR.Item("tax"))
                    taxnara.Items.Add(DR.Item("taxnara"))
                    changable.Items.Add(DR.Item("changable"))
                    value.Items.Add(DR.Item("value"))
                    poname.Items.Add(DR.Item("poname"))
                    pocode.Items.Add(DR.Item("pocode"))
                    al.Items.Add(DR.Item("al"))
                    amt.Items.Add(DR.Item("amt"))
                    ispost.Items.Add(DR.Item("ispost"))
                End While
                DR.Close()
                Dim partyamt As Decimal = 0
                Dim i3 As Integer = 1
                For k = 0 To al.Items.Count - 1
                    If taxnara.Items(k).ToString.Trim.ToLower = "gramt" Or taxnara.Items(k).ToString.Trim.ToLower = "netamt" Then
                    Else
                        If ispost.Items(k).ToString.ToLower = "t" And Val(amt.Items(k)) <> 0 Then
                            If al.Items(k).ToString.ToLower.Trim = "less".Trim Then
                                partyamt = partyamt - Val(amt.Items(k))
                                Dim a2() As String = {VRNO.Items(I).ToString, "JVSL", LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, pocode.Items(k).ToString, poname.Items(k).ToString, Val(amt.Items(k)), 0, -Val(amt.Items(k)), LEDGREMARK, LEDGREF, LEDGACNAME, LEDGACCODE}
                                myinsert(a2, "tblLedg")
                                Dim a3() As String = {jvvrno, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, i3, "DR", poname.Items(k).ToString, pocode.Items(k).ToString, Val(amt.Items(k)), 0, LEDGREF, "JVSL"}
                                myinsert(a3, "tblJour")
                            Else
                                partyamt = partyamt + Val(amt.Items(k))
                                Dim a2() As String = {VRNO.Items(I).ToString, "JVSL", LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, pocode.Items(k).ToString, poname.Items(k).ToString, 0, Val(amt.Items(k)), Val(amt.Items(k)), LEDGREMARK, LEDGREF, LEDGACNAME, LEDGACCODE}
                                myinsert(a2, "tblLedg")
                                Dim a3() As String = {jvvrno, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, i3, "CR", poname.Items(k).ToString, pocode.Items(k).ToString, 0, Val(amt.Items(k)), LEDGREF, "JVSL"}
                                myinsert(a3, "tblJour")
                            End If
                            i3 = i3 + 1
                        Else

                        End If
                    End If
                Next
                Dim a4() As String = {jvvrno, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, i3, "DR", LEDGACNAME, LEDGACCODE, partyamt, 0, LEDGREF, "JVSL"}
                myinsert(a4, "tblJour")
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub PURCHASE()
        Try
            Dim LEDGVRNO As String
            Dim LEdGBOOK As String
            Dim LEDGDATE As New Date
            Dim LEDGACCODE As String
            Dim LEDGACNAME As String
            Dim LEDGDR As Decimal
            Dim LEDGCR As Decimal
            Dim LEDGBAL As Decimal
            Dim LEDGREMARK As String
            Dim LEDGREF As String
            Dim LEDGOPNAME As String
            Dim LEDGOPCODE As String

            Dim BILLNO As New ListBox
            Dim VRNO As New ListBox
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim COUNT As Integer = 0
            connect()
            CMD = New SqlCommand("delete from tblledg where book='Purchase'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("delete from tbljour where type='JVPU'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Delete from tblLedg where book='JVPU'", cn)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("sELECT * FROM tblPurchase", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                BILLNO.Items.Add(DR.Item("OUBNO"))
                VRNO.Items.Add(DR.Item("VRNO"))
                COUNT = COUNT + 1
            End While
            DR.Close()
            Dim I As Integer
            ProgressBar1.Value = 0
            For I = 0 To COUNT - 1
                ProgressBar1.Maximum = COUNT
                ProgressBar1.Value = ProgressBar1.Value + 1

                connect()
                Dim jvvrno As String
                CMD = New SqlCommand("sELECT * FROM tblPurchase WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Purchase"
                    '   MsgBox(Format(DR.Item("billdt"), "dd-MM-yyyy"))
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accode")
                    LEDGACNAME = DR.Item("name")
                    LEDGDR = DR.Item("gramt")
                    LEDGCR = 0
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accodecr")
                    LEDGOPNAME = DR.Item("namecr")
                    jvvrno = DR.Item("jVVrno")
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim a() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(a, "tblLedg")
                connect()
                CMD = New SqlCommand("sELECT * FROM tblPurchase WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Purchase"
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accodecr")
                    LEDGACNAME = DR.Item("namecr")
                    LEDGDR = 0
                    LEDGCR = DR.Item("netamt")
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accode")
                    LEDGOPNAME = DR.Item("name")
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim b() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(b, "tblLedg")
                connect()
                Dim tax As New ListBox
                Dim taxnara As New ListBox
                Dim changable As New ListBox
                Dim value As New ListBox
                Dim poname As New ListBox
                Dim pocode As New ListBox
                Dim al As New ListBox
                Dim onwhich As New ListBox
                Dim optype As New ListBox
                Dim amt As New ListBox
                Dim ispost As New ListBox
                CMD = New SqlCommand("Select * from tblPurtax where vrno='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                Dim k As Integer
                While DR.Read
                    tax.Items.Add(DR.Item("tax"))
                    taxnara.Items.Add(DR.Item("taxnara"))
                    changable.Items.Add(DR.Item("changable"))
                    value.Items.Add(DR.Item("value"))
                    poname.Items.Add(DR.Item("poname"))
                    pocode.Items.Add(DR.Item("pocode"))
                    al.Items.Add(DR.Item("al"))
                    amt.Items.Add(DR.Item("amt"))
                    ispost.Items.Add(DR.Item("ispost"))
                End While
                DR.Close()
                Dim partyamt As Decimal = 0
                Dim i3 As Integer = 1
                For k = 0 To al.Items.Count - 1
                    If taxnara.Items(k).ToString.Trim.ToLower = "gramt" Or taxnara.Items(k).ToString.Trim.ToLower = "netamt" Then
                    Else
                        If ispost.Items(k).ToString.ToLower = "t" And Val(amt.Items(k)) <> 0 Then
                            '        Label2.Text = al.Items(k).ToString.ToLower()
                            If al.Items(k).ToString.ToLower.Trim = "add".ToLower Then
                                partyamt = partyamt + Val(amt.Items(k))
                                Dim a2() As String = {VRNO.Items(I).ToString, "JVPU", LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, pocode.Items(k).ToString, poname.Items(k).ToString, Val(amt.Items(k)), 0, -Val(amt.Items(k)), LEDGREMARK, LEDGREF, LEDGACNAME, LEDGACCODE}
                                myinsert(a2, "tblLedg")
                                Dim a3() As String = {jvvrno, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, i3, "DR", poname.Items(k).ToString, pocode.Items(k).ToString, Val(amt.Items(k)), 0, LEDGREF, "JVPU"}
                                myinsert(a3, "tblJour")
                            Else
                                '   MsgBox("het")
                                partyamt = partyamt - Val(amt.Items(k))
                                Dim a2() As String = {VRNO.Items(I).ToString, "JVPU", LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, pocode.Items(k).ToString, poname.Items(k).ToString, 0, Val(amt.Items(k)), Val(amt.Items(k)), LEDGREMARK, LEDGREF, LEDGACNAME, LEDGACCODE}
                                myinsert(a2, "tblLedg")
                                Dim a3() As String = {jvvrno, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, i3, "CR", poname.Items(k).ToString, pocode.Items(k).ToString, 0, Val(amt.Items(k)), LEDGREF, "JVPU"}
                                myinsert(a3, "tblJour")
                            End If
                            i3 = i3 + 1
                        Else

                        End If
                    End If
                Next
                Dim a4() As String = {jvvrno, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, i3, "CR", LEDGACNAME, LEDGACCODE, 0, partyamt, LEDGREF, "JVPU"}
                myinsert(a4, "tblJour")
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub maxVrNo(ByRef tb As TextBox, ByVal ds As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Try
                cn.Close()
            Catch ex As Exception

            End Try
            connect()
            cmd = New SqlCommand("Select VrNo from " & ds, cn)
            dr = cmd.ExecuteReader
            Dim maxVrNo As Integer
            maxVrNo = 0
            While dr.Read
                If maxVrNo < dr.Item("VrNo").ToString.Substring(3) Then
                    maxVrNo = dr.Item("VrNo").ToString.Substring(3)
                End If
            End While
            dr.Close()
            tb.Text = acycode & "/" & Val(maxVrNo) + 1
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub jourentry(ByVal discount As Decimal, ByVal rd As Decimal, ByVal claim As Decimal, ByVal tds As Decimal, ByVal vrno As String, ByVal acname As String, ByVal accode As String, ByVal dat1 As String)
        Try
            Dim amt As Decimal = 0.0
            Dim tb As New TextBox
            maxVrNo(tb, "tblJour")
            '    tb.Text = acycode & "/" & tb.Text
            '  MsgBox(tb.Text)
            Dim dat As New Date
            MaskedTextBox1.Text = dat1
            dat = MaskedTextBox1.Text
            Dim k As Integer = 0
            If Val(discount) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='DISC'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(discount), 0.0, vrno, "BKRCPT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(discount), 0.0, -(Val(discount)), vrno, "BKRCPT", 0, 0}
                myinsert(b, "tblLedg")
                amt = amt + Val(discount)
                close1()
            End If
            If Val(rd) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='RD'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(rd), 0.0, vrno, "BKRCPT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(rd), 0.0, -(Val(rd)), vrno, "BKRCPT", 0, 0}
                myinsert(b, "tblLedg")
                amt = amt + Val(rd)
                close1()
            End If
            If Val(claim) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='CLAIM'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(claim), 0.0, vrno, "BKRCPT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(claim), 0.0, -(Val(claim)), vrno, "BKRCPT", 0, 0}
                myinsert(b, "tblLedg")

                amt = amt + Val(claim)
                close1()
            End If
            If Val(tds) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='TDS'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(tds), 0.0, vrno, "BKRCPT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(tds), 0.0, -(Val(tds)), vrno, "BKRCPT", 0, 0}
                myinsert(b, "tblLedg")
                amt = amt + Val(tds)
                close1()
            End If
            If amt > 0 Then
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", acname, accode, 0.0, amt, vrno, "BKRCPT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, accode, acname, 0.0, Val(amt), (Val(amt)), vrno, "BKRCPT", 0, 0}
                myinsert(b, "tblLedg")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BANKR()
        Try
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim ACNAME As New ListBox
            Dim ACCODE As New ListBox
            Dim AMOUNT As New ListBox
            Dim VRNO As New ListBox
            connect()
            CMD = New SqlCommand("Delete from tblLedg where book='BANK'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Update adv set isclear='t'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("update salesc set outamt=netamt", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Update tblOub set outamt=netamt where book='Sales'", cn)
            CMD.ExecuteNonQuery()
            Dim itcount As Integer
            Dim vrno1 As New ListBox
            Dim name1 As New ListBox
            Dim namecr1 As New ListBox
            Dim accode1 As New ListBox
            Dim accodecr1 As New ListBox
            Dim amount1 As New ListBox
            Dim remark1 As New ListBox
            Dim ref1 As New ListBox
            Dim dat1 As New ListBox
            Dim itcount2 As Integer = 0

            CMD = New SqlCommand("Select * from tblBank where bkname=name", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                vrno1.Items.Add(DR.Item("Vrno"))
                name1.Items.Add(DR.Item("name"))
                namecr1.Items.Add(DR.Item("namecr"))
                accode1.Items.Add(DR.Item("accode"))
                accodecr1.Items.Add(DR.Item("accodecr"))
                amount1.Items.Add(DR.Item("amount"))
                remark1.Items.Add(DR.Item("desce"))
                ref1.Items.Add(DR.Item("checkno"))
                dat1.Items.Add(DR.Item("dat").ToString)
                itcount2 = itcount2 + 1
            End While
            DR.Close()
            Dim newdat As New Date
            For itcount = 0 To vrno1.Items.Count - 1
                '  MsgBox(dat1.Items(itcount).ToString)
                MaskedTextBox2.Text = dat1.Items(itcount).ToString
                newdat = MaskedTextBox2.Text
                '  MsgBox(newdat.Month & "-" & newdat.Day & "-" & newdat.Year)
                Dim in1() As String = {vrno1.Items(itcount), "BANK", newdat.Month & "-" & newdat.Day & "-" & newdat.Year, accode1.Items(itcount), name1.Items(itcount), Val(amount1.Items(itcount).ToString), 0, -Val(amount1.Items(itcount).ToString), remark1.Items(itcount), ref1.Items(itcount), namecr1.Items(itcount), accodecr1.Items(itcount)}
                myinsert(in1, "tblLedg")
                Dim in2() As String = {vrno1.Items(itcount), "BANK", newdat.Month & "-" & newdat.Day & "-" & newdat.Year, accode1.Items(itcount), namecr1.Items(itcount), 0, Val(amount1.Items(itcount).ToString), Val(amount1.Items(itcount).ToString), remark1.Items(itcount), ref1.Items(itcount), name1.Items(itcount), accode1.Items(itcount)}
                myinsert(in2, "tblLedg")
            Next
            connect()
            CMD = New SqlCommand("sELECT SUM(AMOUNT) AS BAL,NAMECR,ACCODECR FROM TBLBANK WHERE BKNAME=NAME and billclear='TRUE' GROUP BY NAMECR,ACCODECR", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                AMOUNT.Items.Add(DR.Item("BAL"))
                ACNAME.Items.Add(DR.Item("NAMECR"))
                ACCODE.Items.Add(DR.Item("ACCODECR"))
            End While
            DR.Close()
            Dim I As Integer
            For I = 0 To ACCODE.Items.Count - 1
                connect()
                Dim AMT As Decimal
                CMD = New SqlCommand("SELECT ISNULL(SUM(PAIDAMT),0) FROM BANKT,TBLBANK WHERE TBLBANK.NAMECR='" & ACNAME.Items(I).ToString & "' AND TBLBANK.VRNO=BANKT.VRNO GROUP BY TBLBANK.NAMECR", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    AMT = DR.Item(0)
                End While
                DR.Close()
                CMD = New SqlCommand("Select vrno from adv where acname='" & ACNAME.Items(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                If DR.HasRows = False Then
                    DR.Close()
                    Dim tb As New TextBox
                    Dim dat As New Date
                    maxVrNo(tb, "adv")
                    dat = Date.Today
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, ACNAME.Items(I).ToString, ACCODE.Items(I).ToString, "REFBANKVR", Val(AMOUNT.Items(I).ToString) - AMT, "Oub No", "New Update", "New", 0, "f"}
                    myinsert(a, "adv")
                Else
                    DR.Close()
                    CMD = New SqlCommand("Update adv set amount=" & Val(AMOUNT.Items(I).ToString) - AMT & ",isclear='f' where serialno in (Select max(serialno) from adv where acname='" & ACNAME.Items(I).ToString & "' group by acname) ", cn)
                    CMD.ExecuteNonQuery()
                End If
                Dim oubno As New ListBox
                Dim bkname As New ListBox
                Dim bkcode As New ListBox
                CMD = New SqlCommand("Select CONVERT(varchar,billdt,105) BillDate,OubNo,NetAmt,OutAmt,Ispaid,BKName,Bkcode,CONVERT(INT,BILLNO) AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from salesc where Name='" & ACNAME.Items(I).ToString & "' UNION Select CONVERT(varchar,Date,105) Date,OUBNO,NetAmt,OutAmt,Ispaid,BKName,Bkcode,CONVERT(INT,SUBSTRING(OUBNO,4,LEN(OUBNO))) AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from tblOub where Book='Sales' ORDER BY YEAR,BILLNO", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    oubno.Items.Add(DR.Item("oubno"))
                    bkname.Items.Add(DR.Item("bkname"))
                    bkcode.Items.Add(DR.Item("bkcode"))
                End While
                DR.Close()
                Dim j As Integer
                Dim amt2 As Decimal
                ProgressBar1.Value = 0
                For j = 0 To oubno.Items.Count - 1
                    ProgressBar1.Maximum = oubno.Items.Count
                    ProgressBar1.Value = ProgressBar1.Value + 1
                    CMD = New SqlCommand("Select sum(paidamt)+sum(rd)+sum(claim)+sum(tds)+sum(discount),namecr,bankt.bkname,oubno from bankt,tblBank  where tblBank.vrno=bankt.vrno and tblbank.namecr='" & ACNAME.Items(I).ToString & "' and bankt.bkname='" & bkname.Items(j).ToString & "' and oubno='" & oubno.Items(j).ToString & "' group by bankt.oubno,namecr,bankt.bkname", cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        amt2 = DR.Item(0)
                    End While
                    DR.Close()
                    'MsgBox(amt2)
                    CMD = New SqlCommand("Update Salesc set outamt=outamt-" & amt2 & " where bkname='" & bkname.Items(j).ToString & "' and name='" & ACNAME.Items(I).ToString & "' and oubno='" & oubno.Items(j).ToString & "'", cn)
                    CMD.ExecuteNonQuery()
                    CMD = New SqlCommand("Update tblOub set outamt=outamt-" & amt2 & " where bkname='" & bkname.Items(j).ToString & "' and acname='" & ACNAME.Items(I).ToString & "' and oubno='" & oubno.Items(j).ToString & "'", cn)
                    CMD.ExecuteNonQuery()
                Next
                close1()

            Next
            
            autojvr()
            '  BANKP()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BANKP()
        Try
            Dim k As Integer
            '  For k = 0 To 3
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim ACNAME As New ListBox
            Dim ACCODE As New ListBox
            Dim AMOUNT As New ListBox
            Dim VRNO As New ListBox
            connect()
            CMD = New SqlCommand("Delete from tblLedg where book='BANK'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Update advPMT set isclear='t'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("update TBLPURCHASE set outamt=netamt", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Update tblOub set outamt=netamt where book='Purchase'", cn)
            CMD.ExecuteNonQuery()
            Dim itcount As Integer
            Dim vrno1 As New ListBox
            Dim name1 As New ListBox
            Dim namecr1 As New ListBox
            Dim accode1 As New ListBox
            Dim accodecr1 As New ListBox
            Dim amount1 As New ListBox
            Dim remark1 As New ListBox
            Dim ref1 As New ListBox
            Dim dat1 As New ListBox
            Dim itcount2 As Integer = 0

            CMD = New SqlCommand("Select * from tblBank where bkname=namecr", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                vrno1.Items.Add(DR.Item("Vrno"))
                name1.Items.Add(DR.Item("name"))
                namecr1.Items.Add(DR.Item("namecr"))
                accode1.Items.Add(DR.Item("accode"))
                accodecr1.Items.Add(DR.Item("accodecr"))
                amount1.Items.Add(DR.Item("amount"))
                remark1.Items.Add(DR.Item("desce"))
                ref1.Items.Add(DR.Item("checkno"))
                dat1.Items.Add(DR.Item("dat").ToString)
                itcount2 = itcount2 + 1
            End While
            DR.Close()
            Dim newdat As New Date
            For itcount = 0 To vrno1.Items.Count - 1
                MaskedTextBox2.Text = dat1.Items(itcount).ToString
                newdat = MaskedTextBox2.Text
                Dim in1() As String = {vrno1.Items(itcount), "BANK", newdat.Month & "-" & newdat.Day & "-" & newdat.Year, accode1.Items(itcount), name1.Items(itcount), Val(amount1.Items(itcount).ToString), 0, -Val(amount1.Items(itcount).ToString), remark1.Items(itcount), ref1.Items(itcount), namecr1.Items(itcount), accodecr1.Items(itcount)}
                myinsert(in1, "tblLedg")
                Dim in2() As String = {vrno1.Items(itcount), "BANK", newdat.Month & "-" & newdat.Day & "-" & newdat.Year, accode1.Items(itcount), namecr1.Items(itcount), 0, Val(amount1.Items(itcount).ToString), Val(amount1.Items(itcount).ToString), remark1.Items(itcount), ref1.Items(itcount), name1.Items(itcount), accode1.Items(itcount)}
                myinsert(in2, "tblLedg")
            Next
            connect()
            CMD = New SqlCommand("sELECT SUM(AMOUNT) AS BAL,NAME,ACCODE FROM TBLBANK WHERE BKNAME=NAMECR and billclear='TRUE' GROUP BY NAME,ACCODE", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                AMOUNT.Items.Add(DR.Item("BAL"))
                ACNAME.Items.Add(DR.Item("NAME"))
                ACCODE.Items.Add(DR.Item("ACCODE"))
            End While
            DR.Close()
            Dim I As Integer
            close1()
            For I = 0 To ACCODE.Items.Count - 1
                Try
                    connect()
                Catch ex As Exception
                End Try
                Dim AMT As Decimal
                CMD = New SqlCommand("SELECT ISNULL(SUM(PAIDAMT),0) FROM BANKT,TBLBANK WHERE TBLBANK.NAME='" & ACNAME.Items(I).ToString & "' AND TBLBANK.VRNO=BANKT.VRNO GROUP BY TBLBANK.NAME", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    AMT = DR.Item(0)
                End While
                DR.Close()
                CMD = New SqlCommand("Select vrno from advPMT where acname='" & ACNAME.Items(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                If DR.HasRows = False Then
                    DR.Close()
                    Dim tb As New TextBox
                    Dim dat As New Date
                    maxVrNo(tb, "advPMT")
                    dat = Date.Today
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, ACNAME.Items(I).ToString, ACCODE.Items(I).ToString, "REFBANKVR", Val(AMOUNT.Items(I).ToString) - AMT, "Oub No", "New Update", "New", 0, "f"}
                    myinsert(a, "advPMT")
                Else
                    DR.Close()
                    CMD = New SqlCommand("Update advPMT set amount=" & Val(AMOUNT.Items(I).ToString) - AMT & ",isclear='f' where serialno in (Select max(serialno) from advPMT where acname='" & ACNAME.Items(I).ToString & "' group by acname) ", cn)
                    CMD.ExecuteNonQuery()
                End If
                Dim oubno As New ListBox
                Dim bkname As New ListBox
                Dim bkcode As New ListBox
                connect()
                CMD = New SqlCommand("Select CONVERT(varchar,billdt,105) BillDate,OubNo,NetAmt,OutAmt,Ispaid,BKName,Bkcode,BILLNO AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from TBLPURCHASE where NameCR='" & ACNAME.Items(I).ToString & "' UNION Select CONVERT(varchar,Date,105) Date,OUBNO,NetAmt,OutAmt,Ispaid,BKName,Bkcode,SUBSTRING(OUBNO,4,LEN(OUBNO)) AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from tblOub where Book='Purchase' and acName='" & ACNAME.Items(I).ToString & "' ORDER BY YEAR,billdate", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    oubno.Items.Add(DR.Item("oubno"))
                    bkname.Items.Add(DR.Item("bkname"))
                    bkcode.Items.Add(DR.Item("bkcode"))
                End While
                DR.Close()
                Dim j As Integer
                Dim amt2 As Decimal
                ProgressBar1.Value = 0
                For j = 0 To oubno.Items.Count - 1
                    amt2 = 0
                    ProgressBar1.Maximum = oubno.Items.Count
                    ProgressBar1.Value = ProgressBar1.Value + 1
                    CMD = New SqlCommand("Select sum(paidamt)+sum(rd)+sum(claim)+sum(tds)+sum(discount),name,bankt.bkname,oubno from bankt,tblBank  where tblBank.vrno=bankt.vrno and tblbank.name='" & ACNAME.Items(I).ToString & "' and bankt.bkname='" & bkname.Items(j).ToString & "' and oubno='" & oubno.Items(j).ToString & "' and tblBank.name='" & ACNAME.Items(I).ToString & "' group by bankt.oubno,name,bankt.bkname", cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        amt2 = DR.Item(0)
                        If ACNAME.Items(I).ToString.ToUpper.StartsWith("FINO") Then
                            MsgBox(oubno.Items(I).ToString & "     " & amt2)
                        End If
                    End While
                    DR.Close()

                    CMD = New SqlCommand("Update TBLpURCHASE set outamt=outamt-" & amt2 & " where bkname='" & bkname.Items(j).ToString & "' and nameCR='" & ACNAME.Items(I).ToString & "' and oubno='" & oubno.Items(j).ToString & "'", cn)
                    CMD.ExecuteNonQuery()
                    CMD = New SqlCommand("Update tblOub set outamt=outamt-" & amt2 & " where bkname='" & bkname.Items(j).ToString & "' and acname='" & ACNAME.Items(I).ToString & "' and oubno='" & oubno.Items(j).ToString & "'", cn)
                    CMD.ExecuteNonQuery()
                Next
                close1()
            Next
            autojvp()
            ' BANKR()
            close1()
            '    Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BANKR1()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim acname As New ListBox
            Dim amount As New ListBox
            Dim accode As New ListBox
            Dim sql As String
            sql = "Select sum(amount)- isnull(sum(paidamt),0) as bal,namecr,Accodecr from Bankt right join tblbank on bankt.vrno=tblBank.vrno group by namecr,accodecr"
            connect()
            cmd = New SqlCommand("Update adv set isclear='t'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                amount.Items.Add(dr.Item("bal"))
                acname.Items.Add(dr.Item("namecr"))
                accode.Items.Add(dr.Item("accodecr"))
            End While
            dr.Close()
            Dim i As Integer
            For i = 0 To acname.Items.Count - 1
                connect()
                cmd = New SqlCommand("Select vrno from adv where acname='" & acname.Items(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    dr.Close()
                    Dim tb As New TextBox
                    Dim dat As New Date
                    maxVrNo(tb, "adv")
                    dat = Date.Today
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, acname.Items(i).ToString, accode.Items(i).ToString, "REFBANKVR", amount.Items(i).ToString, "Oub No", "New Update", "New", 0, "f"}
                    myinsert(a, "adv")
                Else
                    dr.Close()
                    cmd = New SqlCommand("Update adv set amount=" & amount.Items(i).ToString & ",isclear='f' where serialno in (Select max(serialno) from adv where acname='" & acname.Items(i).ToString & "' group by acname) ", cn)
                    cmd.ExecuteNonQuery()
                End If
                close1()
            Next
            updatebillr()
            autojvr()
            close1()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BANKP1()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim acname As New ListBox
            Dim amount As New ListBox
            Dim accode As New ListBox
            Dim sql As String
            sql = "Select sum(amount)-isnull(sum(paidamt),0) as bal,name,Accode from Bankt right join tblbank on bankt.vrno=tblBank.vrno group by name,accode"
            connect()
            cmd = New SqlCommand("update advpmt set isclear='t'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                amount.Items.Add(dr.Item("bal"))
                acname.Items.Add(dr.Item("name"))
                accode.Items.Add(dr.Item("accode"))
            End While
            dr.Close()
            Dim i As Integer
            For i = 0 To acname.Items.Count - 1
                connect()
                cmd = New SqlCommand("Select vrno from advpmt where acname='" & acname.Items(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    dr.Close()
                    Dim tb As New TextBox
                    Dim dat As New Date
                    maxVrNo(tb, "advpmt")
                    dat = Date.Today
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, acname.Items(i).ToString, accode.Items(i).ToString, "REFBANKVR", amount.Items(i).ToString, "Oub No", "New Update", "New", 0, "F"}
                    myinsert(a, "advpmt")
                Else
                    dr.Close()
                    cmd = New SqlCommand("Update advpmt set amount=" & amount.Items(i).ToString & ",isclear='f' where serialno in (Select max(serialno) from advpmt where acname='" & acname.Items(i).ToString & "'" & " group by acname) ", cn)
                    cmd.ExecuteNonQuery()
                End If
                close1()
            Next
            updatebillp()
            autojvp()
            close1()
            MsgBox("Success")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub updatebillr()
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("update salesc set outamt=netamt", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Update tblOub set outamt=netamt where book='Sales'", cn)
            cmd.ExecuteNonQuery()
            Dim sql As String
            sql = "update salesc set outamt=Salesc.outamt-(Select sum(paidamt) from bankt where bankt.oubno=salesc.oubno and bankt.bkname=salesc.bkname group by bankt.oubno,bankt.bkname) from salesc,bankt where salesc.oubno=bankt.oubno and salesc.bkname=bankt.bkname"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub updatebillp()
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("update tblPurchase set outamt=netamt", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Update tblOub set outamt=netamt where book='Purchase'", cn)
            cmd.ExecuteNonQuery()
            Dim sql As String
            sql = "update tblPurchase set outamt=tblPurchase.outamt-isnull((Select isnull(sum(paidamt),0)+isnull(sum(discount),0)+isnull(sum(rd),0)+isnull(sum(claim),0)+isnull(sum(tds),0) from bankt,tblBank where bankt.oubno=tblPurchase.oubno and bankt.bkname=tblPurchase.bkname and tblBank.name=tblPurchase.namecr group by bankt.oubno,tblBank.name,bankt.bkname),0) from tblPurchase,bankt where tblPurchase.oubno=bankt.oubno and tblPurchase.bkname=bankt.bkname"
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub jourentry1(ByVal discount As Decimal, ByVal rd As Decimal, ByVal claim As Decimal, ByVal tds As Decimal, ByVal vrno As String, ByVal acname As String, ByVal accode As String, ByVal dt As String)
        Try
            Dim amt As Decimal = 0.0
            Dim tb As New TextBox
            maxVrNo(tb, "tblJour")
            Dim dat As New Date
            MaskedTextBox1.Text = dt
            dat = MaskedTextBox1.Text
            Dim k As Integer = 0
            If Val(discount) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='PURC' and AUjvType='DISC'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(discount), vrno, "BKPYMT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(discount), (Val(discount)), vrno, "BKPYMT", 0, 0}
                myinsert(b, "tblLedg")
                amt = amt + Val(discount)
                close1()
            End If
            If Val(rd) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='PURC' and AUjvType='RD'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(rd), vrno, "BKPYMT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(rd), (Val(rd)), vrno, "BKPYMT", 0, 0}
                myinsert(b, "tblLedg")
                amt = amt + Val(rd)
                close1()
            End If
            If Val(claim) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='PURC' and AUjvType='CLAIM'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(claim), vrno, "BKPYMT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(claim), (Val(claim)), vrno, "BKPYMT", 0, 0}
                myinsert(b, "tblLedg")

                amt = amt + Val(claim)
                close1()
            End If
            If Val(tds) > 0 Then
                Dim disacname As String
                Dim disccode As Integer
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("Select * from AujvMst where Aujvbook='PURC' and AUjvType='TDS'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    disccode = dr.Item("ACCODe")
                    disacname = dr.Item("ACNAME")
                End While
                dr.Close()
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(tds), vrno, "BKPYMT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(tds), (Val(tds)), vrno, "BKPYMT", 0, 0}
                myinsert(b, "tblLedg")
                amt = amt + Val(tds)
                close1()
            End If
            If amt > 0 Then
                Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", acname, accode, amt, 0.0, vrno, "BKPYMT"}
                myinsert(a, "tblJour")
                Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, accode, acname, Val(amt), 0.0, (-Val(amt)), vrno, "BKPYMT", 0, 0}
                myinsert(b, "tblLedg")
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub autojvr()
        Try
            Dim cmd1 As New SqlCommand
            connect()
            cmd1 = New SqlCommand("Delete from tbljour where Type='BKRCPT'", cn)
            cmd1.ExecuteNonQuery()
            cmd1 = New SqlCommand("Delete from tblLedg where ref='BKRCPT'", cn)
            cmd1.ExecuteNonQuery()

            close1()
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim vrno As New ListBox
            Dim acname As New ListBox
            Dim accode As New ListBox
            Dim bkname As New ListBox
            Dim bkcode As New ListBox
            Dim dt As New ListBox
            cmd = New SqlCommand("Select * from tblBank where bkname=name", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                vrno.Items.Add(dr.Item("vrno"))
                acname.Items.Add(dr.Item("Namecr"))
                accode.Items.Add(dr.Item("Accodecr"))
                bkname.Items.Add(dr.Item("BKNAME"))
                bkcode.Items.Add(dr.Item("bkcode"))
                dt.Items.Add(dr.Item("dat"))
            End While
            dr.Close()
            Dim i As Integer
            Dim discount As Decimal = 0.0
            Dim rd As Decimal = 0.0
            Dim claim As Decimal = 0.0
            Dim tds As Decimal = 0.0
            ProgressBar1.Value = 0
            For i = 0 To vrno.Items.Count - 1
                ProgressBar1.Maximum = vrno.Items.Count
                ProgressBar1.Value = ProgressBar1.Value + 1
                connect()
                cmd = New SqlCommand("Select isnull(sum(discount),0) as dis,isnull(sum(rd),0) as rd,isnull(sum(claim),0) as claim,isnull(sum(tds),0) as tds from bankt where vrno='" & vrno.Items(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    discount = dr.Item("dis")
                    rd = dr.Item("rd")
                    claim = dr.Item("claim")
                    tds = dr.Item("tds")
                End While
                dr.Close()
                jourentry(discount, rd, claim, tds, vrno.Items(i).ToString, acname.Items(i), accode.Items(i), dt.Items(i))
                close1()
            Next
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub
    Private Sub autojvp()
        Try
            Dim cmd1 As New SqlCommand
            connect()
            cmd1 = New SqlCommand("Delete from tbljour where Type='BKPYMT'", cn)
            cmd1.ExecuteNonQuery()
            cmd1 = New SqlCommand("Delete from tblLedg where ref='BKPYMT'", cn)
            cmd1.ExecuteNonQuery()

            close1()

            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim vrno As New ListBox
            Dim acname As New ListBox
            Dim accode As New ListBox
            Dim bkname As New ListBox
            Dim bkcode As New ListBox
            Dim dt As New ListBox
            cmd = New SqlCommand("Select * from tblBank where bkname=namecr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                vrno.Items.Add(dr.Item("vrno"))
                acname.Items.Add(dr.Item("Name"))
                accode.Items.Add(dr.Item("Accode"))
                bkname.Items.Add(dr.Item("BKNAME"))
                bkcode.Items.Add(dr.Item("bkcode"))
                dt.Items.Add(dr.Item("dat"))
            End While
            dr.Close()
            Dim i As Integer
            Dim discount As Decimal = 0.0
            Dim rd As Decimal = 0.0
            Dim claim As Decimal = 0.0
            Dim tds As Decimal = 0.0
            ProgressBar1.Value = 0
            For i = 0 To vrno.Items.Count - 1
                ProgressBar1.Maximum = vrno.Items.Count
                ProgressBar1.Value = ProgressBar1.Value + 1
                connect()
                cmd = New SqlCommand("Select isnull(sum(discount),0) as dis,isnull(sum(rd),0) as rd,isnull(sum(claim),0) as claim,isnull(sum(tds),0) as tds from bankt where vrno='" & vrno.Items(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    discount = dr.Item("dis")
                    rd = dr.Item("rd")
                    claim = dr.Item("claim")
                    tds = dr.Item("tds")
                End While
                dr.Close()
                jourentry1(discount, rd, claim, tds, vrno.Items(i).ToString, acname.Items(i), accode.Items(i), dt.Items(i))
                close1()
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub JOUR()
        Try
            connect()
            Dim LEDGVRNO As String
            Dim LEdGBOOK As String
            Dim LEDGDATE As New Date
            Dim LEDGACCODE As String
            Dim LEDGACNAME As String
            Dim LEDGDR As Decimal
            Dim LEDGCR As Decimal
            Dim LEDGBAL As Decimal
            Dim LEDGREMARK As String
            Dim LEDGREF As String
            Dim LEDGOPNAME As String
            Dim LEDGOPCODE As String
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim vrno As New ListBox
            Dim serialno As New ListBox
            cmd = New SqlCommand("Select serialno from tblJour", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                serialno.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Dim i As Integer
            ProgressBar1.Value = 0
            For i = 0 To serialno.Items.Count - 1
                ProgressBar1.Maximum = serialno.Items.Count
                ProgressBar1.Value = ProgressBar1.Value + 1
                connect()
                cmd = New SqlCommand("Select * from tblJour where serialno=" & serialno.Items(i), cn)
                dr = cmd.ExecuteReader
                While dr.Read

                End While
                dr.Close()
                close1()
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub PREV()
        Try
            Dim LEDGVRNO As String
            Dim LEdGBOOK As String
            Dim LEDGDATE As New Date
            Dim LEDGACCODE As String
            Dim LEDGACNAME As String
            Dim LEDGDR As Decimal
            Dim LEDGCR As Decimal
            Dim LEDGBAL As Decimal
            Dim LEDGREMARK As String
            Dim LEDGREF As String
            Dim LEDGOPNAME As String
            Dim LEDGOPCODE As String

            Dim BILLNO As New ListBox
            Dim VRNO As New ListBox
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim COUNT As Integer = 0
            connect()
            CMD = New SqlCommand("delete from tblledg where book='PREPurchase' or book='PRESales'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("sELECT * FROM tblOub", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                BILLNO.Items.Add(DR.Item("OUBNO"))
                VRNO.Items.Add(DR.Item("VRNO"))
                COUNT = COUNT + 1
            End While
            DR.Close()
            Dim I As Integer
            For I = 0 To COUNT - 1
                connect()
                Dim jvvrno As String
                CMD = New SqlCommand("sELECT * FROM tblOub WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    If DR.Item("book") = "Purchase" Then
                        LEdGBOOK = "PREPurchase"
                        MaskedTextBox1.Text = Format(DR.Item("date"), "dd-MM-yyyy")
                        LEDGACCODE = DR.Item("accode")
                        LEDGACNAME = DR.Item("acname")
                        LEDGDR = 0
                        LEDGCR = DR.Item("Netamt")
                        LEDGBAL = LEDGCR - LEDGDR
                        LEDGREMARK = "PREV"
                        LEDGREF = DR.Item("oubno")
                        LEDGOPCODE = DR.Item("bkcode")
                        LEDGOPNAME = DR.Item("bkname")
                    Else
                        LEdGBOOK = "PRESales"
                        MaskedTextBox1.Text = Format(DR.Item("date"), "dd-MM-yyyy")
                        LEDGACCODE = DR.Item("bkcode")
                        LEDGACNAME = DR.Item("bkname")
                        LEDGDR = 0
                        LEDGCR = DR.Item("Netamt")
                        LEDGBAL = LEDGCR - LEDGDR
                        LEDGREMARK = "PREV"
                        LEDGREF = DR.Item("oubno")
                        LEDGOPCODE = DR.Item("accode")
                        LEDGOPNAME = DR.Item("acname")
                    End If
                    '   MsgBox(Format(DR.Item("billdt"), "dd-MM-yyyy"))
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim a() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                '   myinsert(a, "tblLedg")
                connect()
                CMD = New SqlCommand("sELECT * FROM tblOub WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    If DR.Item("Book") = "Purchase" Then
                        LEdGBOOK = "PREPurchase"
                        MaskedTextBox1.Text = Format(DR.Item("date"), "dd-MM-yyyy")
                        LEDGACCODE = DR.Item("bkcode")
                        LEDGACNAME = DR.Item("bkname")
                        LEDGDR = DR.Item("netamt")
                        LEDGCR = 0
                        LEDGBAL = LEDGCR - LEDGDR
                        LEDGREMARK = "PREV"
                        LEDGREF = DR.Item("oubno")
                        LEDGOPCODE = DR.Item("accode")
                        LEDGOPNAME = DR.Item("acname")
                    Else
                        LEdGBOOK = "PRESales"
                        MaskedTextBox1.Text = Format(DR.Item("date"), "dd-MM-yyyy")
                        LEDGACCODE = DR.Item("accode")
                        LEDGACNAME = DR.Item("acname")
                        LEDGDR = DR.Item("netamt")
                        LEDGCR = 0
                        LEDGBAL = LEDGCR - LEDGDR
                        LEDGREMARK = "PREV"
                        LEDGREF = DR.Item("oubno")
                        LEDGOPCODE = DR.Item("bkcode")
                        LEDGOPNAME = DR.Item("bkname")
                    End If
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim b() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                '  myinsert(b, "tblLedg")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PURCHASEWPOST()
        Try
            Dim LEDGVRNO As String
            Dim LEdGBOOK As String
            Dim LEDGDATE As New Date
            Dim LEDGACCODE As String
            Dim LEDGACNAME As String
            Dim LEDGDR As Decimal
            Dim LEDGCR As Decimal
            Dim LEDGBAL As Decimal
            Dim LEDGREMARK As String
            Dim LEDGREF As String
            Dim LEDGOPNAME As String
            Dim LEDGOPCODE As String

            Dim BILLNO As New ListBox
            Dim VRNO As New ListBox
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim COUNT As Integer = 0
            connect()
            CMD = New SqlCommand("delete from tblledg where book='Purchase'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("delete from tbljour where type='JVPU'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Delete from tblLedg where book='JVPU'", cn)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("sELECT * FROM tblPurchase", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                BILLNO.Items.Add(DR.Item("OUBNO"))
                VRNO.Items.Add(DR.Item("VRNO"))
                COUNT = COUNT + 1
            End While
            DR.Close()
            Dim I As Integer
            ProgressBar1.Value = 0
            For I = 0 To COUNT - 1
                connect()
                ProgressBar1.Maximum = COUNT
                ProgressBar1.Value = ProgressBar1.Value + 1
                Dim jvvrno As String
                CMD = New SqlCommand("sELECT * FROM tblPurchase WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Purchase"
                    '   MsgBox(Format(DR.Item("billdt"), "dd-MM-yyyy"))
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accode")
                    LEDGACNAME = DR.Item("name")
                    LEDGDR = DR.Item("netamt")
                    LEDGCR = 0
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accodecr")
                    LEDGOPNAME = DR.Item("namecr")
                    jvvrno = DR.Item("jVVrno")
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim a() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(a, "tblLedg")
                connect()
                CMD = New SqlCommand("sELECT * FROM tblPurchase WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Purchase"
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accodecr")
                    LEDGACNAME = DR.Item("namecr")
                    LEDGDR = 0
                    LEDGCR = DR.Item("netamt")
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accode")
                    LEDGOPNAME = DR.Item("name")
                    jvvrno = DR.Item("jVVrno")
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim b() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(b, "tblLedg")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SALEWPOST()
        Try
            Dim LEDGVRNO As String
            Dim LEdGBOOK As String
            Dim LEDGDATE As New Date
            Dim LEDGACCODE As String
            Dim LEDGACNAME As String
            Dim LEDGDR As Decimal
            Dim LEDGCR As Decimal
            Dim LEDGBAL As Decimal
            Dim LEDGREMARK As String
            Dim LEDGREF As String
            Dim LEDGOPNAME As String
            Dim LEDGOPCODE As String

            Dim BILLNO As New ListBox
            Dim VRNO As New ListBox
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim COUNT As Integer = 0
            connect()
            CMD = New SqlCommand("delete from tblledg where book='Sales'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("delete from tbljour where type='JVSL'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("Delete from tblLedg where book='JVSL'", cn)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("sELECT * FROM SALESC", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                BILLNO.Items.Add(DR.Item("OUBNO"))
                VRNO.Items.Add(DR.Item("VRNO"))
                COUNT = COUNT + 1
            End While
            DR.Close()
            Dim I As Integer
            ProgressBar1.Value = 0
            For I = 0 To COUNT - 1
                ProgressBar1.Maximum = COUNT
                ProgressBar1.Value = ProgressBar1.Value + 1
                connect()
                Dim jvvrno As String
                CMD = New SqlCommand("sELECT * FROM SALESC WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Sales"
                    '   MsgBox(Format(DR.Item("billdt"), "dd-MM-yyyy"))
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accodecr")
                    LEDGACNAME = DR.Item("namecr")
                    LEDGDR = 0
                    LEDGCR = DR.Item("netamt")
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accode")
                    LEDGOPNAME = DR.Item("name")
                    jvvrno = acycode & "/0"
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim a() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(a, "tblLedg")
                connect()
                CMD = New SqlCommand("sELECT * FROM SALESC WHERE VRNO='" & VRNO.Items(I) & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    LEDGVRNO = VRNO.Items(I)
                    LEdGBOOK = "Sales"
                    MaskedTextBox1.Text = Format(DR.Item("billdt"), "dd-MM-yyyy")
                    LEDGACCODE = DR.Item("accode")
                    LEDGACNAME = DR.Item("name")
                    LEDGDR = DR.Item("netamt")
                    LEDGCR = 0
                    LEDGBAL = LEDGCR - LEDGDR
                    LEDGREMARK = DR.Item("remark")
                    LEDGREF = DR.Item("oubno")
                    LEDGOPCODE = DR.Item("accodecr")
                    LEDGOPNAME = DR.Item("namecr")
                    jvvrno = acycode & "/0"
                End While
                DR.Close()
                LEDGDATE = MaskedTextBox1.Text
                Dim b() As String = {LEDGVRNO, LEdGBOOK, LEDGDATE.Month & "-" & LEDGDATE.Day & "-" & LEDGDATE.Year, LEDGACCODE, LEDGACNAME, LEDGDR, LEDGCR, LEDGBAL, LEDGREMARK, LEDGREF, LEDGOPNAME, LEDGOPCODE}
                myinsert(b, "tblLedg")
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
            If CheckedListBox1.CheckedItems(i).ToString = "SALE" Then
                Label6.Text = "SALE"
                SALE()
                MsgBox("SALE COMPLETE")
                Label4.Text = Label4.Text & vbNewLine & "   SALE COMPLETE "
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "PURCHASE" Then
                Label6.Text = "PURCHSE"
                PURCHASE()
                MsgBox("   PURCHASE COMPLETE ")
                Label4.Text = Label4.Text & vbNewLine & "   PURCHASE COMPLETE "
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "PURCHASE WITHOUT POSTING" Then
                Label6.Text = "PURCHSE WITHOUT POSTING"
                PURCHASEWPOST()
                MsgBox("PURCHASE WITHOUT POSTING COMPLETE")
                Label4.Text = Label4.Text & vbNewLine & "   PURCHASE WITHOUT POSTING COMPLETE"
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "SALE WITHOUT POSTING" Then
                Label6.Text = "SALE WITHOUT POSTING"
                SALEWPOST()
                MsgBox("SALE WITHOUT POSTING COMPLETE")
                Label4.Text = Label4.Text & vbNewLine & "  SALE WITHOUT POSTING COMPLETE"
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "BANK R" Then
                Label6.Text = "BANK R"
                BANKR()
                MsgBox("BANK R COMPLETE")
                Label4.Text = Label4.Text & vbNewLine & "  BANK R COMPLETE"
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "BANK P" Then
                Label6.Text = "BANK P"
                BANKP()
                MsgBox("BANK P COMPLETE")
                Label4.Text = Label4.Text & vbNewLine & "  BANK P COMPLETE"
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "OPENING" Then
                Label6.Text = "OPENING"
                opening()
                MsgBox("OPENING COMPLETE")
                Label4.Text = Label4.Text & vbNewLine & "  OPENING COMPLETE"
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "PREVIOUS" Then
                '  PREV()
                Label4.Text = Label4.Text & vbNewLine & "  PREVIOUS COMPLETE"
            ElseIf CheckedListBox1.CheckedItems(i).ToString = "JOUR" Then
                JOUR()
                MsgBox("JOUR COMPLETE")
                Label4.Text = Label4.Text & vbNewLine & "  JOUR COMPLETE"
            End If
        Next
        MsgBox("OK")
    End Sub
End Class