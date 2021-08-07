Imports System.Data.SqlClient
Public Class frmTransfer
    'variable declaration
    Dim bkname As String
    Dim bkcode As Integer
    Dim chno As String
    Dim chdt As DateTime
    Dim billno As String
    Dim oubno As String
    Dim billdt As DateTime
    Dim name As String
    Dim namecr As String
    Dim purtype As String
    Dim srno As Integer
    Dim itname As String
    Dim itcode As Integer
    Dim pcs As Decimal
    Dim pack As Decimal
    Dim qty As Decimal
    Dim rate As Decimal
    Dim unit As String
    Dim amount As Decimal
    Dim vrno As String
    Dim accode As Integer
    Dim accodecr As Integer
    Dim itcode2 As String
    Dim ch As String
    Dim prcode As Integer
    Dim process As String
    Dim style As String
    Dim mstcode As Integer
    Dim mst As String
    Dim width As Decimal
    Dim grpcs As Decimal
    Dim grmtr As Decimal
    Dim grrate As Decimal
    Dim grval As Decimal
    Dim desgno As String
    Dim lotno As String
    Dim Mbillno As String
    Dim fromwhere As String = "MILL"
    Dim srno1 As New ListBox
    Dim maxentry As Integer
    Dim txtvrno As New TextBox
    Dim billdate As New Date
    Dim spcs As Decimal
    Dim sqty As Decimal
    Dim sgramt As Decimal
    Dim sgrdisper As Decimal = 0
    Dim sgrdis As Decimal = 0
    Dim sexc As Decimal = 0
    Dim svatper As Decimal = 0
    Dim svat As Decimal = 0
    Dim sadvatper As Decimal = 0
    Dim sadvat As Decimal = 0
    Dim sgst As Decimal = 0
    Dim scst As Decimal = 0
    Dim ssertax As Decimal = 0
    Dim saddnara As Decimal = 0
    Dim saddper As Decimal = 0
    Dim slessnara As Decimal = 0
    Dim sprefix As String = "-"
    Dim sjvvrno As String = "-"
    Dim snetamt As Decimal = 0
    Dim sinwords As String = "-"
    Dim sremark As String = "-"
    Dim soutamt As Decimal = 0
    Dim sispaid As String = "f"
    Dim sworkno As String = "-"
    Dim sshipto As String = "-"
    Dim sgrpcs As Decimal = 0
    Dim sgrqty As Decimal = 0
    Dim sgrval As Decimal = 0
    Dim sdelvary As Integer = 1
    Dim spttime As String = "-"
    Dim svehicalno As String = "-"
    Dim saddamt As Decimal = 0
    'variable declaration ends


    'variable declaration for ledger
    Dim lvrno As String = ""
    Dim lbook As String = ""
    Dim ldate1 As String
    Dim laccode As Integer = 0
    Dim lacname As String = ""
    Dim ldr As Decimal = 0
    Dim lcr As Decimal = 0
    Dim lbal As Decimal = 0
    Dim lremark As String = ""
    Dim lref As String = ""
    Dim lopname As String = ""
    Dim lopcode As Decimal = 0
    Private Sub frmTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            maskbill1.Text = Date.Today
            maskbill2.Text = Date.Today
            maskbill3.Text = Date.Today
            maskbill4.Text = Date.Today
            txtBKNAME1.Text = "Sales Job"
            txtREGCODE1.Text = "99"
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select acname from tblAccount where book='Sales'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtBKNAME1.AutoCompleteCustomSource.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function billnocount() As String
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim billsr As String
            Dim billno As Integer
            Dim maxbill As Integer = 0
            Dim place As Integer
            Dim yesno As String
            connect()
            cmd = New SqlCommand("Select billsr from tblAccount where ACcode=" & txtREGCODE1.Text, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                billsr = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select SRYN from tblAccount where ACCode=" & txtREGCODE1.Text, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                yesno = dr.Item(0).ToString.ToUpper
            End While
            dr.Close()
            If yesno = "YES" Then
                cmd = New SqlCommand("Select billNo from salesc where prefix like'" & billsr & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    maxbill = 0
                    dr.Close()
                    GoTo en
                Else
                    While dr.Read
                        If maxbill < dr.Item(0).ToString.Substring(billsr.Length) Then
                            maxbill = dr.Item(0).ToString.Substring(billsr.Length)
                        End If
                    End While
                    dr.Close()
                End If
en:
                cmd = New SqlCommand("Select MaxBill from tblAccount where BKCOde=" & txtREGCODE1.Text, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    place = dr.Item(0)
                End While
                dr.Close()
                Dim str1 As String
                str1 = maxbill + 1
                If place = 1 Then
                    GoTo last1
                End If
                If str1.ToString.Length < place Then
                    Dim k1 As Integer
                    For k1 = 0 To place - str1.ToString.Length - 1
                        str1 = "0" & str1
                    Next
                End If
last1:
                Return billsr & str1
                close1()
            Else
                cmd = New SqlCommand("Select billNo from salesc where Prefix ='" & billsr & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    maxbill = 0
                    dr.Close()
                    GoTo en1
                Else
                    While dr.Read
                        If maxbill < dr.Item(0) Then
                            maxbill = dr.Item(0)
                        End If
                    End While
                    dr.Close()
                End If
en1:
                cmd = New SqlCommand("Select MaxBill from tblAccount where ACCOde=" & txtREGCODE1.Text, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    place = dr.Item(0)
                End While
                dr.Close()
                Dim str1 As String
                str1 = maxbill + 1
                If place = 1 Then
                    GoTo last
                End If
                If str1.ToString.Length < place Then
                    Dim k1 As Integer
                    For k1 = 0 To place - str1.ToString.Length - 1
                        str1 = "0" & str1
                    Next
                End If
last:
                Return str1
            End If
            '    txtBillSr.Text = billsr

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Function
    Private Sub maxVrNo(ByRef tb As TextBox, ByVal ds As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            cmd = New SqlCommand("Select VrNo from " & ds, cn)
            dr = cmd.ExecuteReader
            Dim maxVrNo1 As Integer
            maxVrNo1 = 0
            Try
                While dr.Read
                    If maxVrNo1 < dr.Item("VrNo").ToString.Substring(3) Then
                        maxVrNo1 = dr.Item("VrNo").ToString.Substring(3)
                    End If
                End While
                dr.Close()
            Catch ex As Exception
                maxVrNo1 = 0
            End Try
            If tb.Name = "TextBox27" Then
                tb.Text = acycode & "/" & (maxVrNo1 + 1)
            Else
                tb.Text = acycode & "/" & (maxVrNo1 + 1)
            End If
            '    MsgBox(tb.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub insert11(ByRef count1 As Integer, ByRef billno2 As String, ByRef accode1 As Integer, ByVal name1 As String, ByVal namecr1 As String, ByVal accodecr1 As Integer)
        Dim i As Integer
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        '   MsgBox(count1)
        spcs = 0
        sqty = 0
        sgramt = 0
        snetamt = 0
        sgrpcs = 0
        sgrqty = 0
        sgrval = 0
        For i = 1 To maxentry
            ' MsgBox((maxentry * count1 + i - 1))
            If (maxentry * count1 + i - 1) > (srno1.Items.Count - 1) Then
                GoTo en
            End If
            connect()
            cmd = New SqlCommand("select * from sale1 where serilano=" & srno1.Items(maxentry * count1 + i - 1), cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ' bkname = TextBox1.Text
                'bkcode = txtRegCode.Text
                chno = dr.Item("chno")
                maskbill3.Text = dr.Item("chdt")
                chdt = maskbill3.Text
                billno = billno
                oubno = acycode & "/" & billno
                '   MaskedTextBox3.Text = 
                '    billdt = MaskedTextBox3.Text
                '  name = dr.Item("Name")
                ' namecr = dr.Item("Namecr")
                'purtype = dr.Item("Purtype")
                srno = i
                itname = dr.Item("itname")
                itcode = dr.Item("itcode")
                pcs = dr.Item("pcs")
                spcs = spcs + Val(dr.Item("pcs"))
                pack = dr.Item("pack")

                qty = dr.Item("qty")
                sqty = sqty + Val(dr.Item("qty"))
                rate = dr.Item("rate")
                unit = dr.Item("unit")
                amount = dr.Item("amount")
                sgramt = sgramt + Val(dr.Item("amount"))
                '  accode = dr.Item("accode")
                ' accodecr = dr.Item("accodecr")
                '   itcode2 = 0
                '  ch = 0
                prcode = dr.Item("prcode")
                process = dr.Item("process")
                style = dr.Item("style")
                mstcode = dr.Item("mstcode")
                mst = dr.Item("mst")
                width = dr.Item("width")
                grpcs = dr.Item("grpcs")
                sgrpcs = sgrpcs + Val(dr.Item("grpcs"))
                grmtr = dr.Item("grmtr")
                sgrqty = sgrqty + Val(dr.Item("grmtr"))
                grrate = dr.Item("grrate")
                grval = dr.Item("grval")
                sgrval = sgrval + Val(dr.Item("grval"))
                desgno = dr.Item("desgno")
                lotno = dr.Item("lotno")
                Mbillno = dr.Item("billno")
            End While
            dr.Close()
            Dim a() As String = {bkname, bkcode, chno, chdt.Month & "-" & chdt.Day & "-" & chdt.Year, billno2, acycode & "/" & billno2, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, name1, namecr1, " ", srno, itname, itcode, pcs, pack, qty, rate, unit, amount, txtvrno.Text, accode1, accodecr1, 0, 0, prcode, process, style, mstcode, mst, width, grpcs, grmtr, grrate, grval, desgno, lotno, Mbillno, "MILL"}
            myinsert(a, "salec1")
            close1()
        Next
en:
        snetamt = sgramt
        sinwords = AmtInWord(snetamt)
        soutamt = snetamt
        sispaid = "f"

        Dim b() As String = {txtvrno.Text, bkname, bkcode, "chno", billdate.Month & "-" & billdate.Day & "-" & billdate.Year, billno2, acycode & "/" & billno2, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, name1, namecr1, " ", spcs, sqty, sgramt, sgrdisper, sgrdis, sexc, svatper, svat, sadvatper, sadvat, sgst, scst, ssertax, saddnara, saddper, saddamt, slessnara, sprefix, sjvvrno, snetamt, sinwords, sremark, accode1, accodecr1, soutamt, sispaid, sworkno, sshipto, mstcode, mst, sgrpcs, sgrqty, sgrval, sdelvary, spttime, svehicalno}
        myinsert(b, "salesc")
        lvrno = txtvrno.Text
        lbook = "Sales"
        laccode = accode1
        lacname = name1
        ldr = snetamt
        lcr = 0
        lbal = -snetamt
        lremark = ""
        lref = ""
        lopname = namecr1
        lopcode = accodecr1

        Dim c() As String = {lvrno, lbook, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, laccode, lacname, ldr, lcr, lbal, lremark, lref, lopname, lopcode}
        myinsert(c, "tblLedg")

        lvrno = txtvrno.Text
        lbook = "Sales"
        laccode = accodecr1
        lacname = namecr1
        ldr = 0
        lcr = snetamt
        lbal = snetamt
        lremark = ""
        lref = ""
        lopname = name1
        lopcode = accode1
        '   MsgBox("0")
        Dim d() As String = {lvrno, lbook, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, laccode, lacname, ldr, lcr, lbal, lremark, lref, lopname, lopcode}
        myinsert(d, "tblLedg")
        ' MsgBox("f")
    End Sub
    Private Sub transfer1(ByVal name1 As String, ByVal namecr1 As String, ByVal accode1 As Integer, ByVal accodecr1 As Integer)

        Dim count1 As Integer = 0
        Dim check As Integer = 0

        If (srno1.Items.Count / maxentry) = 0 Then
            check = 1
        Else
            check = 0
        End If
        If check = 0 Then
l:
            If count1 + 1 < (srno1.Items.Count / maxentry) + 1 Then
                maxVrNo(txtvrno, "salesc")
                insert11(count1, billnocount, accode1, name1, namecr1, accodecr1)
                count1 = count1 + 1
                GoTo l
            Else
                GoTo en
            End If

        Else
m:
            If count1 + 1 <= srno1.Items.Count / maxentry Then
                maxVrNo(txtvrno, "salesc")
                insert11(count1, billnocount, accode1, name1, namecr1, accodecr1)
                count1 = count1 + 1
                GoTo m
            Else
                GoTo en
            End If

        End If
en:
    End Sub
    Private Sub option1()
        If MsgBox("Are you sure want to transfer", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            bkname = txtBKNAME1.Text
            bkcode = txtREGCODE1.Text
            billdate = maskbill4.Text
            maxentry = Val(txtMaxBill.Text)
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = maskbill1.Text
            dat2 = maskbill2.Text
            Dim sql As String
            connect()
            Dim liaccode As New ListBox
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select billsr from tblAccount where acname='" & txtBKNAME1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                sprefix = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select distinct accode from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                liaccode.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Dim k As Integer
            Dim liacname As New ListBox
            For k = 0 To liaccode.Items.Count - 1
                cmd = New SqlCommand("Select acname from tblAccount where accode=" & liaccode.Items(k), cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    liacname.Items.Add(dr.Item(0))
                End While
                dr.Close()
            Next
            dr.Close()
            For k = 0 To liaccode.Items.Count - 1
                srno1.Items.Clear()
                sql = "Select serilano from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and accode=" & liaccode.Items(k)
                cmd = New SqlCommand(sql, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    srno1.Items.Add(dr.Item(0))
                End While
                dr.Close()
                '   MsgBox(srno1.Items.Count)
                transfer1(liacname.Items(k), txtBKNAME1.Text, liaccode.Items(k), txtREGCODE1.Text)
            Next
            close1()
        End If
    End Sub
    Private Sub option2()
        If MsgBox("Are you sure want to transfer", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            bkname = txtBKNAME1.Text
            bkcode = txtREGCODE1.Text
            billdate = maskbill4.Text
            maxentry = Val(txtMaxBill.Text)
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = maskbill1.Text
            dat2 = maskbill2.Text
            Dim sql As String
            connect()
            Dim liaccode As New ListBox
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select billsr from tblAccount where acname='" & txtMaxBill.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                sprefix = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select distinct accode from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                liaccode.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Dim k As Integer
            Dim liacname As New ListBox
            For k = 0 To liaccode.Items.Count - 1
                cmd = New SqlCommand("Select acname from tblAccount where accode=" & liaccode.Items(k), cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    liacname.Items.Add(dr.Item(0))
                End While
                dr.Close()
            Next
            For k = 0 To liaccode.Items.Count - 1
                srno1.Items.Clear()
                connect()
                sql = "Select serilano from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and accode=" & liaccode.Items(k)
                cmd = New SqlCommand(sql, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    srno1.Items.Add(dr.Item(0))
                End While
                dr.Close()
                '   MsgBox(srno1.Items.Count)
                txtMaxBill.Text = srno1.Items.Count
                maxentry = Val(txtMaxBill.Text)
                transfer1(liacname.Items(k), txtBKNAME1.Text, liaccode.Items(k), txtREGCODE1.Text)
                txtMaxBill.Text = 0
                close1()

            Next

            close1()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(txtMaxBill.Text) > 0 Then
                option1()
            Else
                option2()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txtBKNAME1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBKNAME1.Leave
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            CMD = New SqlCommand("SELECT ACCODE FROM TBLACCOUNT WHERE ACNAME='" & txtBKNAME1.Text & "'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                txtREGCODE1.Text = DR.Item(0)
            End While
            DR.Close()
            close1()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBKNAME1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBKNAME1.TextChanged

    End Sub
End Class