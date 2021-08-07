Imports System.Data.SqlClient
Public Class frmBank
    Dim dr As SqlDataReader
    Public bankac As Integer = 0
    Public checkedit As Integer = 0
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim selectfield As String
    Dim gridamount As Decimal
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim tv1 As String
    Dim billclear As String = ""
    Private Sub frmBank_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If checkedit = 1 Then
            checkedit = 0
            save2()
        End If
    End Sub
    Private Sub frmBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Then
        'SendKeys.Send("{TAB}")
        'End If
        Try
            If e.KeyCode = Keys.Escape Then
                If frmzoom7.zoom = True Then
                    frmzoom7.Close()
                    frmzoom7.Show()
                End If
                If frmnewzoom4.zoom1 = True Then
                    frmnewzoom4.Close()
                    frmnewzoom4.Show()
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F9 Then
                DG1.Height = Me.Height
                DG1.Width = Me.Width
                DG1.BringToFront()
                DG1.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkName.GotFocus, txtBKCode.GotFocus, txtVrnofirst.GotFocus, txtVrNosec.GotFocus, txtRemark.GotFocus, txtAmount.GotFocus, txtChqno.GotFocus, txtAcName.GotFocus, txtAccode.GotFocus, txtRefBank.GotFocus, maskdate.GotFocus
        Try
            sender.BackColor = Color.Pink
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkName.LostFocus, txtBKCode.LostFocus, txtVrnofirst.LostFocus, txtVrNosec.LostFocus, txtRemark.LostFocus, txtAmount.LostFocus, txtChqno.LostFocus, txtAcName.LostFocus, txtAccode.LostFocus, txtRefBank.LostFocus, maskdate.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub frmBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        connect()
        Dim cmd1 As New SqlCommand
        Dim dr1 As SqlDataReader
        cmd1 = New SqlCommand("select fields from tblselectfield where tablename='tblbank'", cn)
        dr1 = cmd1.ExecuteReader
        While dr1.Read
            selectfield = dr1.Item(0).ToString.Substring(0, dr1.Item(0).ToString.Length - 1)
        End While
        dr1.Close()
        close1()
        Try
            If frmzoom7.zoom = True Then
                Dim cmd As New SqlCommand
                Dim drsale As SqlDataReader
                connect()
                cmd = New SqlCommand("Select " & selectfield & " from tblBank where VrNo='" & frmzoom7.VrNo & "'", cn)
                drsale = cmd.ExecuteReader
                While drsale.Read
                    txtBkName.Text = drsale.Item("BkName")
                End While
                drsale.Close()
                close1()
            ElseIf frmnewzoom4.zoom1 = True Then
                Dim cmd As New SqlCommand
                Dim drsale As SqlDataReader
                connect()
                cmd = New SqlCommand("Select " & selectfield & " from tblBank where VrNo='" & frmnewzoom4.VrNo & "'", cn)
                drsale = cmd.ExecuteReader
                While drsale.Read
                    txtBkName.Text = drsale.Item("BkName")
                End While
                drsale.Close()
                close1()

            Else
                txtBkName.Text = (frmMainScreen.bankname)
            End If


            dr = myconselect("tblAccount", txtBkName.Text, "ACName")
            While dr.Read
                txtBKCode.Text = dr.Item("ACCode")
            End While
            dr.Close()
            Dim ds As New DataSet
            connect()
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select " & selectfield & " from tblBank Where BkName='" & txtBkName.Text & "' and Namecr='" & txtBkName.Text & "'ORDER BY convert(int,substring(vrno,4,len(Vrno))) ", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            close1()
            If DG1.RowCount = 0 Then
            Else
                DG1.Item(0, DG1.Rows.Count - 1).Selected = True
            End If
            txtVrnofirst.Text = acycode & "\"

            'TextBox3.Text = "2"
            If frmzoom7.zoom = True Then
                Dim cn1 As Integer
                For cn1 = 0 To DG1.Rows.Count - 1
                    If DG1.Item(0, cn1).Value = frmzoom7.VrNo Then
                        DG1.Item(0, cn1).Selected = True
                        GoTo en
                    End If
                Next
            ElseIf frmnewzoom4.zoom1 = True Then
                Dim cn1 As Integer
                For cn1 = 0 To DG1.Rows.Count - 1
                    If DG1.Item(0, cn1).Value = frmnewzoom4.VrNo Then
                        DG1.Item(0, cn1).Selected = True
                        GoTo en
                    End If
                Next

            End If
en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub maxVrNo(ByRef tb As TextBox, ByVal ds As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
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
            tb.Text = maxVrNo + 1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcName.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgacm.Rows.Count <> 0 Then
                txtAcName.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                dgacm.Visible = False
                txtChqno.Focus()
            Else
                If MsgBox("Account not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    bankac = 1
                    frmACMaster.Show()
                    Me.Hide()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            dgacm.Focus()
            dgacm.Item(0, 0).Selected = True
        ElseIf e.KeyCode = Keys.Up Then
            dgacm.Visible = False
            maskdate.Focus()
        End If
    End Sub
    Public Sub save2()
        Try
            Dim dat1 As New Date
            With frmoutpmt
                Dim dat2 As New Date
                Dim dat31 As New Date
                Try
                    dat2 = .copybank.Item(1, 0).Value
                    dat31 = .copybank.Item(17, 0).Value
                Catch ex As Exception
                End Try
                dat1 = maskdate.Text.ToString
                Dim a() As String = {.copybank.Item(0, 0).Value, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, .copybank.Item(2, 0).Value, .copybank.Item(3, 0).Value, .copybank.Item(4, 0).Value, .copybank.Item(5, 0).Value, .copybank.Item(6, 0).Value, .copybank.Item(7, 0).Value, .copybank.Item(8, 0).Value, .copybank.Item(9, 0).Value, .copybank.Item(10, 0).Value, .copybank.Item(11, 0).Value, .copybank.Item(12, 0).Value, .copybank.Item(13, 0).Value, .copybank.Item(14, 0).Value, .copybank.Item(15, 0).Value, .copybank.Item(16, 0).Value, dat31.Month & "-" & dat31.Day & "-" & dat31.Year, .copybank.Item(18, 0).Value}
                myinsert(a, "tblBank")
                Dim icount As Integer
                For icount = 0 To .copyledg.Rows.Count() - 1
                    Dim dat3 As New Date
                    dat3 = .copyledg.Item(2, icount).Value
                    Dim b() As String = {.copyledg.Item(0, icount).Value, .copyledg.Item(1, icount).Value, dat3.Month & "-" & dat3.Day & "-" & dat3.Year, .copyledg.Item(3, icount).Value, .copyledg(4, icount).Value, .copyledg(5, icount).Value, .copyledg(6, icount).Value, .copyledg(7, icount).Value, .copyledg(8, icount).Value, .copyledg(9, icount).Value, .copyledg(10, icount).Value, .copyledg(11, icount).Value}
                    myinsert(b, "tblLedg")
                Next
            End With
            Dim cmdcheck As New SqlCommand
            Dim drcheck As SqlDataReader
            With frmoutpmt.dgdetailcopy
                Dim k As Integer
                For k = 0 To frmoutpmt.dgdetailcopy.RowCount - 1
                    Dim dat As New Date
                    dat = .Item(1, k).Value
                    Dim bankt() As String = {txtVrnofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, (.Item(0, k).Value), Format(Val(.Item(6, k).Value), "0.00"), Format(Val(.Item(7, k).Value), "0.00"), Format(Val(.Item(8, k).Value), "0.00"), Format(Val(.Item(10, k).Value), "0.00"), "asdasd", Format(Val(.Item(4, k).Value), "0.00"), Format(Val(.Item(13, k).Value), "0.00"), Format(Val(.Item(14, k).Value), "0.00"), Format(Val(.Item(5, k).Value), "0.00"), Format(Val(.Item(9, k).Value), "0.00"), Format(Val(.Item(11, k).Value), "0.00"), txtChqno.Text, .Item(.ColumnCount - 2, k).Value, .Item(.ColumnCount - 1, k).Value, "0", txtBkName.Text, "0", dat.Month & "-" & dat.Day & "-" & dat.Year, "Purchase"}
                    myinsert(bankt, "bankt")
                Next
            End With
            If ComboBox1.Text = "TRUE" Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Update advpmt set isclear='t' where acname='" & txtAcName.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
                If Val(frmoutpmt.TextBox2copy.Text) > 0 Then
                    Dim tb As New TextBox
                    maxVrNo(tb, "Advpmt")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcName.Text, txtAccode.Text, txtVrnofirst.Text & txtVrNosec.Text, Val(frmoutpmt.TextBox2copy.Text), "Oub No", txtRemark.Text, txtBkName.Text, txtBKCode.Text, "f"}
                    myinsert(adv, "Advpmt")
                End If
            End If
            ' End If
            jourentry1()
            updatebill2()
            ds.Tables("tblBank").Rows.Clear()
            ds.Tables("tblJour").Rows.Clear()
            ds.Tables("tblLedg").Rows.Clear()
            frmoutpmt.dgdetailcopy.Rows.Clear()
            Try
                frmoutpmt.dgbillcopy.Rows.Clear()
                frmoutpmt.copybank.Rows.Clear()
                frmoutpmt.copyledg.Rows.Clear()
                frmoutpmt.copyjour.Rows.Clear()
            Catch ex As Exception

            End Try
            checkedit = 0
            frmoutpmt.Close()
last:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            checkedit = 0
            Dim dat1 As New Date
            dat1 = maskdate.Text.ToString
            Dim a() As String = {txtVrnofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBKCode.Text, txtBkName.Text, txtAccode.Text, txtAcName.Text, txtAmount.Text, txtRemark.Text, txtChqno.Text, txtRefBank.Text, "Bank", txtBkName.Text, txtBKCode.Text, 0, " ", 0, "f", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, ComboBox1.Text}
            Dim b() As String = {txtVrnofirst.Text & txtVrNosec.Text, "BANK", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAccode.Text, txtAcName.Text, txtAmount.Text, 0, (Val(txtAmount.Text) * -1), txtRemark.Text, txtChqno.Text, txtBkName.Text, txtBKCode.Text}
            Dim c() As String = {txtVrnofirst.Text & txtVrNosec.Text, "BANK", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBKCode.Text, txtBkName.Text, 0, txtAmount.Text, Val(txtAmount.Text), txtRemark.Text, txtChqno.Text, txtAcName.Text, txtAccode.Text}
            If Label11.Text = "ADD Mode" Then
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                connect()
                cmdcheck = New SqlCommand("Select * from tblBank where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo last
                Else
                    drcheck.Close()
                End If
                close1()

                myinsert(a, "tblBank")
                myinsert(b, "tblLedg")
                myinsert(c, "tblLedg")
                With frmoutpmt.dgdetail
                    Dim k As Integer
                    For k = 0 To frmoutpmt.dgdetail.RowCount - 1
                        Dim dat As New Date
                        dat = .Item(1, k).Value
                        Dim bankt() As String = {txtVrnofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, (.Item(0, k).Value), Format(Val(.Item(6, k).Value), "0.00"), Format(Val(.Item(7, k).Value), "0.00"), Format(Val(.Item(8, k).Value), "0.00"), Format(Val(.Item(10, k).Value), "0.00"), "asdasd", Format(Val(.Item(4, k).Value), "0.00"), Format(Val(.Item(13, k).Value), "0.00"), Format(Val(.Item(14, k).Value), "0.00"), Format(Val(.Item(5, k).Value), "0.00"), Format(Val(.Item(9, k).Value), "0.00"), Format(Val(.Item(11, k).Value), "0.00"), txtChqno.Text, .Item(.ColumnCount - 2, k).Value, .Item(.ColumnCount - 1, k).Value, "0", txtBkName.Text, "0", dat.Month & "-" & dat.Day & "-" & dat.Year, "Purchase"}
                        myinsert(bankt, "bankt")
                    Next
                End With
                connect()
                If ComboBox1.Text.ToUpper = "TRUE" Then
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("Update advpmt set isclear='t' where acname='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                    '   If frmoutpmt.adv1 = 1 Then
                    Dim tb As New TextBox
                    maxVrNo(tb, "Advpmt")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcName.Text, txtAccode.Text, txtVrnofirst.Text & txtVrNosec.Text, Val(frmoutpmt.TextBox2.Text), "Oub No", txtRemark.Text, txtBkName.Text, txtBKCode.Text, "f"}
                    myinsert(adv, "Advpmt")
                End If
                ' End If

                jourentry()
                updatebill()
                frmoutpmt.Close()
            ElseIf Label11.Text.ToLower = "EDIT Mode".ToLower Then
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                connect()
                cmdcheck = New SqlCommand("Select * from tblBank where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo last
                Else
                    drcheck.Close()
                End If
                close1()
                myinsert(a, "tblBank")
                myinsert(b, "tblLedg")
                myinsert(c, "tblLedg")
                With frmoutpmt.dgdetail
                    Dim k As Integer
                    For k = 0 To frmoutpmt.dgdetail.RowCount - 1
                        Dim dat As New Date
                        dat = .Item(1, k).Value
                        Dim bankt() As String = {txtVrnofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, (.Item(0, k).Value), Format(Val(.Item(6, k).Value), "0.00"), Format(Val(.Item(7, k).Value), "0.00"), Format(Val(.Item(8, k).Value), "0.00"), Format(Val(.Item(10, k).Value), "0.00"), "asdasd", Format(Val(.Item(4, k).Value), "0.00"), Format(Val(.Item(13, k).Value), "0.00"), Format(Val(.Item(14, k).Value), "0.00"), Format(Val(.Item(5, k).Value), "0.00"), Format(Val(.Item(9, k).Value), "0.00"), Format(Val(.Item(11, k).Value), "0.00"), txtChqno.Text, .Item(.ColumnCount - 2, k).Value, .Item(.ColumnCount - 1, k).Value, "0", txtBkName.Text, "0", dat.Month & "-" & dat.Day & "-" & dat.Year, "Purchase"}
                        myinsert(bankt, "bankt")

                    Next
                End With
                connect()
                If ComboBox1.Text.ToUpper = "TRUE" Then
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("Update advpmt set isclear='t' where acname='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                    '   If frmoutpmt.adv1 = 1 Then
                    Dim tb As New TextBox
                    maxVrNo(tb, "Advpmt")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcName.Text, txtAccode.Text, txtVrnofirst.Text & txtVrNosec.Text, Val(frmoutpmt.TextBox2.Text), "Oub No", txtRemark.Text, txtBkName.Text, txtBKCode.Text, "f"}
                    myinsert(adv, "Advpmt")
                End If
                ' End If
                jourentry()
                updatebill()
                frmoutpmt.Close()
            Else
                MsgBox("Incorrect Option")
            End If
            connect()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select " & selectfield & " from tblBank Where BkName='" & txtBkName.Text & "' and Namecr='" & txtBkName.Text & "'ORDER BY convert(int,substring(vrno,4,len(Vrno))) ", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            If DG1.RowCount = 0 Then
            Else
                DG1.Item(0, DG1.Rows.Count - 1).Selected = True
            End If
            close1()
            MsgBox("success")
            'clearall()
            '    Button2.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
last:
    End Sub
    Private Function calout(ByVal i As Integer) As Decimal
        With frmoutpmt.dgdetail
            Dim amt As Decimal = 0
            amt = Val(.Item(4, i).Value) + Val(.Item(6, i).Value) + Val(.Item(7, i).Value) + Val(.Item(8, i).Value) + Val(.Item(10, i).Value)
            Return Format(Val(.Item(3, i).Value) - amt, "0.00")
        End With
    End Function
    Private Function calout2(ByVal i As Integer) As Decimal
        With frmoutpmt.dgdetailcopy
            Dim amt As Decimal = 0
            amt = Val(.Item(4, i).Value) + Val(.Item(6, i).Value) + Val(.Item(7, i).Value) + Val(.Item(8, i).Value) + Val(.Item(10, i).Value)
            Return Format(Val(.Item(3, i).Value) - amt, "0.00")
        End With
    End Function
    Private Sub updatebill()
        With frmoutpmt
            Dim k As Integer
            Dim cmd As New SqlCommand
            connect()
            For k = 0 To .dgdetail.RowCount - 1
                cmd = New SqlCommand("Update tblPurchase set OutAmt=" & calout(k) & " where OubNo='" & .dgdetail.Item(0, k).Value & "' and BKname='" & .dgdetail.Item(.dgdetail.ColumnCount - 2, k).Value & "' and namecr='" & txtAcName.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update tblOub set OutAmt=" & calout(k) & " where OubNo='" & .dgdetail.Item(0, k).Value & "' and BKname='" & .dgdetail.Item(.dgdetail.ColumnCount - 2, k).Value & "' and acname='" & txtAcName.Text & "'", cn)
                cmd.ExecuteNonQuery()
                If calout(k) = 0 Then
                    cmd = New SqlCommand("Update tblPurchase set Ispaid='" & "t" & "' where OubNo='" & .dgdetail.Item(0, k).Value & "' and BKname='" & .dgdetail.Item(.dgdetail.ColumnCount - 2, k).Value & "' and namecr='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Ispaid='" & "t" & "' where OubNo='" & .dgdetail.Item(0, k).Value & "' and BKname='" & .dgdetail.Item(.dgdetail.ColumnCount - 2, k).Value & "' and acname='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            close1()
        End With
    End Sub
    Private Sub updatebill2()
        With frmoutpmt
            Dim k As Integer
            Dim cmd As New SqlCommand
            connect()
            For k = 0 To .dgdetailcopy.RowCount - 1
                cmd = New SqlCommand("Update tblPurchase set OutAmt=" & calout2(k) & " where OubNo='" & .dgdetailcopy.Item(0, k).Value & "' and BKname='" & .dgdetailcopy.Item(.dgdetailcopy.ColumnCount - 2, k).Value & "' and namecr='" & txtAcName.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update tblOub set OutAmt=" & calout2(k) & " where OubNo='" & .dgdetailcopy.Item(0, k).Value & "' and BKname='" & .dgdetailcopy.Item(.dgdetailcopy.ColumnCount - 2, k).Value & "' and acname='" & txtAcName.Text & "'", cn)
                cmd.ExecuteNonQuery()
                If calout2(k) = 0 Then
                    cmd = New SqlCommand("Update tblPurchase set Ispaid='" & "t" & "' where OubNo='" & .dgdetailcopy.Item(0, k).Value & "' and BKname='" & .dgdetailcopy.Item(.dgdetailcopy.ColumnCount - 2, k).Value & "'and namecr='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Ispaid='" & "t" & "' where OubNo='" & .dgdetailcopy.Item(0, k).Value & "' and BKname='" & .dgdetailcopy.Item(.dgdetailcopy.ColumnCount - 2, k).Value & "' and acname='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            close1()
        End With
    End Sub

    Private Sub jourentry()
        Try
            Dim amt As Decimal = 0.0
            Dim tb As New TextBox
            maxVrNo(tb, "tblJour")
            tb.Text = acycode & "/" & tb.Text
            '  MsgBox(tb.Text)
            Dim dat As New Date
            dat = maskdate.Text
            Dim k As Integer = 0
            With frmoutpmt
                If Val(.discount.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.discount.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.discount.Text), (Val(.discount.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                    amt = amt + Val(.discount.Text)
                    close1()
                End If
                If Val(.rdcount.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.rdcount.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.rdcount.Text), (Val(.rdcount.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                    amt = amt + Val(.rdcount.Text)
                    close1()
                End If
                If Val(.claimcount.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.claimcount.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.claimcount.Text), (Val(.claimcount.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")

                    amt = amt + Val(.claimcount.Text)
                    close1()
                End If
                If Val(.tdscount.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.tdscount.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.tdscount.Text), (Val(.tdscount.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                    amt = amt + Val(.tdscount.Text)
                    close1()
                End If
                If amt > 0 Then
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", txtAcName.Text, txtAccode.Text, amt, 0.0, txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, txtAccode.Text, txtAcName.Text, Val(amt), 0.0, (-Val(amt)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub jourentry1()
        Try
            Dim amt As Decimal = 0.0
            Dim tb As New TextBox
            maxVrNo(tb, "tblJour")
            tb.Text = acycode & "/" & tb.Text
            '  MsgBox(tb.Text)
            Dim dat As New Date
            dat = maskdate.Text
            Dim k As Integer = 0
            With frmoutpmt
                If Val(.discountcopy.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.discountcopy.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.discountcopy.Text), (Val(.discountcopy.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                    amt = amt + Val(.discountcopy.Text)
                    close1()
                End If
                If Val(.rdcountcopy.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.rdcountcopy.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.rdcountcopy.Text), (Val(.rdcountcopy.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                    amt = amt + Val(.rdcountcopy.Text)
                    close1()
                End If
                If Val(.claimcountcopy.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.claimcountcopy.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.claimcountcopy.Text), (Val(.claimcountcopy.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")

                    amt = amt + Val(.claimcountcopy.Text)
                    close1()
                End If
                If Val(.tdscountcopy.Text) > 0 Then
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
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", disacname, disccode, 0.0, Val(.tdscountcopy.Text), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, 0.0, Val(.tdscountcopy.Text), (Val(.tdscountcopy.Text)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                    amt = amt + Val(.tdscountcopy.Text)
                    close1()
                End If
                If amt > 0 Then
                    Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", txtAcName.Text, txtAccode.Text, amt, 0.0, txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, txtAccode.Text, txtAcName.Text, Val(amt), 0.0, (-Val(amt)), txtVrnofirst.Text & txtVrNosec.Text, "BKPYMT", 0, 0}
                    myinsert(b, "tblLedg")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearall()
        txtVrNosec.Clear()
        txtRemark.Clear()
        txtAmount.Text = "0.00"
        txtChqno.Clear()
        txtAcName.Clear()
        txtAccode.Clear()
        txtRefBank.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            If checkedit = 1 Then
                save2()
            End If
        Catch ex As Exception
        End Try
        GroupBox1.Enabled = True
        Label11.Text = "ADD Mode"
        clearall()
        maxVrNo(txtVrNosec, "tblBank")
        maskdate.Focus()
        '  MaskedTextBox1.Text = Format(Date.Today, "dd-MM-yyyy")
        maskdate.SelectionStart = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        GroupBox1.Enabled = True
        Try
            If checkedit = 1 Then
                save2()
            End If
        Catch ex As Exception
        End Try

        Try
            Try
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("select * from tblbank where vrno='" & DG1.Item(0, DG1.CurrentCell.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    txtVrnofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                    txtVrNosec.Text = dr.Item("vrno").ToString.Substring(3)
                    txtBKCode.Text = dr.Item("bkcode")
                    txtBkName.Text = dr.Item("bkname")
                    maskdate.Text = Format(dr.Item("dat"), "dd-MM-yyyy")
                    txtAcName.Text = dr.Item("Name")
                    txtAccode.Text = dr.Item("accode")
                    txtChqno.Text = dr.Item("checkno")
                    txtRefBank.Text = dr.Item("refbank")
                    txtAmount.Text = dr.Item("amount")
                    gridamount = dr.Item("amount")
                    txtRemark.Text = dr.Item("desce")
                End While
                dr.Close()
                close1()
                Label11.Text = "EDIT MODE"
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            maskdate.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        If frmzoom7.zoom = True Then
            frmzoom7.Close()
            frmzoom7.Show()
        End If
        If frmnewzoom4.zoom1 = True Then
            frmnewzoom4.Close()
            frmnewzoom4.Show()
        End If
        Me.Close()
    End Sub
    Private Sub DG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DG1.Width = 400
            DG1.Height = 1000
            e.Handled = True
        End If
    End Sub
    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.RowEnter
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblbank where vrno='" & DG1.Item(0, e.RowIndex).Value & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtVrnofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                txtVrNosec.Text = dr.Item("vrno").ToString.Substring(3)
                txtBKCode.Text = dr.Item("bkcode")
                txtBkName.Text = dr.Item("bkname")
                maskdate.Text = Format(dr.Item("dat"), "dd-MM-yyyy")
                txtAcName.Text = dr.Item("Name")
                txtAccode.Text = dr.Item("accode")
                txtChqno.Text = dr.Item("checkno")
                txtRefBank.Text = dr.Item("refbank")
                txtAmount.Text = dr.Item("amount")
                txtRemark.Text = dr.Item("desce")
                gridamount = dr.Item("amount")
                ComboBox1.Text = dr.Item("billclear")
                billclear = dr.Item("billclear")
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub dgacm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcName.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
            Dim dr As SqlDataReader
            dr = myconselect("tblAccount", txtAcName.Text, "ACName")
            While dr.Read
                txtAccode.Text = dr.Item("ACCode")
            End While
            txtChqno.Focus()
            dgacm.Visible = False
        End If
    End Sub
    Private Sub TextBox7_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcName.KeyUp
        ' myAutoComplete(TextBox7, ListBox1, "tblAccount", "ACName")
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            connect()
            da = New SqlDataAdapter(acm(sender.Text), cn)
            da.Fill(ds)
            'da.Fill(ds, "b")
            dgacm.Visible = True
            dgacm.DataSource = ds.Tables(0)
            dgacm.AutoResizeColumns()
            dgacm.BringToFront()
            dgacm.BringToFront()
            '  dgacm.Top = sender.Top + 22
            '     dgacm.Left = sender.Left
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcName.Leave
        dr = myconselect("tblAccount", txtAcName.Text, "ACName")
        While dr.Read
            txtAccode.Text = dr.Item("ACCode")
        End While
        dr.Close()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Public Sub deletecode()
        Try
            Dim dat1 As New Date
            dat1 = maskdate.Text.ToString
            Dim paidamt As New ListBox
            Dim oubNo As New ListBox
            Dim bkcode As New ListBox
            Dim RD As Decimal
            Dim TDS As Decimal
            Dim CLAIM As Decimal
            Dim DISCOUNT As Decimal
            connect()
            If MsgBox("You want to delete entry for VrNo=" & txtVrnofirst.Text & txtVrNosec.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim cmd As New SqlCommand
                Dim da1 As New SqlDataAdapter
                cmd = New SqlCommand("Delete from tblBank where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='BANK'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where Remark='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Type='BKPYMT'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where Remark='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='JOUR'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Select * from bankt where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                dr = cmd.ExecuteReader
                Dim tamt As Decimal = 0.0
                While dr.Read
                    paidamt.Items.Add(dr.Item("Paidamt"))
                    oubNo.Items.Add(dr.Item("OubNo"))
                    bkcode.Items.Add(dr.Item("Bkcode"))
                    tamt = tamt + dr.Item("Paidamt")
                    RD = dr.Item("RD")
                    CLAIM = dr.Item("CLAIM")
                    TDS = dr.Item("TDS")
                    DISCOUNT = dr.Item("DISCOUNT")
                End While
                dr.Close()
                Dim itcount As Integer
                For itcount = 0 To paidamt.Items.Count - 1
                    Dim amt1 As Decimal = 0.0
                    Dim dr3 As SqlDataReader
                    cmd = New SqlCommand("Select outamt from tblOub where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and acname='" & txtAcName.Text & "'", cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                    End While
                    dr3.Close()
                    cmd = New SqlCommand("Select outamt from tblPurchase where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and namecr='" & txtAcName.Text & "'", cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                    End While
                    dr3.Close()
                    cmd = New SqlCommand("Update tblPurchase set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and namecr='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and acname='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                Next
                ' MsgBox(tamt)
                If billclear.ToUpper = "TRUE" Then
                    cmd = New SqlCommand("Select Amount from advpmt where acname='" & txtAcName.Text & "' and isclear='f'", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        tamt = tamt + 0
                    Else
                        While dr.Read
                            tamt = tamt + Val(dr.Item(0))
                        End While
                        dr.Close()
                        cmd = New SqlCommand("Update advpmt set isclear='t' where acname='" & txtAcName.Text & "'", cn)
                        cmd.ExecuteNonQuery()
                    End If
                    '  MsgBox(tamt - Val(TextBox5.Text))
                    Dim tb As New TextBox
                    maxVrNo(tb, "Advpmt")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcName.Text, txtAccode.Text, txtVrnofirst.Text & txtVrNosec.Text, Val(tamt - gridamount), "Oub No", txtRemark.Text, txtBkName.Text, txtBKCode.Text, "f"}
                    myinsert(adv, "Advpmt")
                End If
                connect()
                cmd = New SqlCommand("Delete from bankt where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            If checkedit = 1 Then
                save2()
            End If
        Catch ex As Exception
        End Try

        Try
            Dim dat1 As New Date
            dat1 = maskdate.Text.ToString
            Dim paidamt As New ListBox
            Dim oubNo As New ListBox
            Dim bkcode As New ListBox
            Dim RD As Decimal
            Dim TDS As Decimal
            Dim CLAIM As Decimal
            Dim DISCOUNT As Decimal
            connect()
            If MsgBox("You want to delete entry for VrNo=" & txtVrnofirst.Text & txtVrNosec.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim cmd As New SqlCommand
                Dim da1 As New SqlDataAdapter
                cmd = New SqlCommand("Delete from tblBank where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='BANK'", cn)
                cmd.ExecuteNonQuery()
                '   MsgBox("Delete from tblJour where Remark='" & TextBox10.Text & TextBox3.Text & "' and Type='BKPYMT'")
                cmd = New SqlCommand("Delete from tblJour where Remark='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Type='BKPYMT'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where Remark='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='JOUR'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Select * from bankt where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                dr = cmd.ExecuteReader
                Dim tamt As Decimal = 0.0
                While dr.Read
                    paidamt.Items.Add(dr.Item("Paidamt"))
                    oubNo.Items.Add(dr.Item("OubNo"))
                    bkcode.Items.Add(dr.Item("Bkcode"))
                    tamt = tamt + dr.Item("Paidamt")
                    RD = dr.Item("RD")
                    CLAIM = dr.Item("CLAIM")
                    TDS = dr.Item("TDS")
                    DISCOUNT = dr.Item("DISCOUNT")
                End While
                dr.Close()
                Dim itcount As Integer
                For itcount = 0 To paidamt.Items.Count - 1
                    Dim amt1 As Decimal = 0.0
                    Dim dr3 As SqlDataReader
                    cmd = New SqlCommand("Select outamt from tblOub where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and acname='" & txtAcName.Text & "'", cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                    End While
                    dr3.Close()
                    cmd = New SqlCommand("Select outamt from tblPurchase where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and namecr='" & txtAcName.Text & "'", cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                        '  MsgBox(amt1)
                    End While
                    dr3.Close()
                    'MsgBox(Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT)
                    cmd = New SqlCommand("Update tblPurchase set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and namecr='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and acname='" & txtAcName.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                Next
                ' MsgBox(tamt)
                If billclear = "TRUE" Then
                    cmd = New SqlCommand("Select Amount from advpmt where acname='" & txtAcName.Text & "' and isclear='f'", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        tamt = tamt + 0
                    Else
                        While dr.Read
                            tamt = tamt + Val(dr.Item(0))
                        End While
                        dr.Close()
                        cmd = New SqlCommand("Update advpmt set isclear='t' where acname='" & txtAcName.Text & "'", cn)
                        cmd.ExecuteNonQuery()
                    End If
                    '  MsgBox(tamt - Val(TextBox5.Text))
                    Dim tb As New TextBox
                    maxVrNo(tb, "Advpmt")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcName.Text, txtAccode.Text, txtVrnofirst.Text & txtVrNosec.Text, Val(tamt - Val(txtAmount.Text)), "Oub No", txtRemark.Text, txtBkName.Text, txtBKCode.Text, "f"}
                    myinsert(adv, "Advpmt")
                End If
                connect()
                cmd = New SqlCommand("Delete from bankt where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()

                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                connect()
                da = New SqlDataAdapter("Select " & selectfield & " from tblBank Where BkName='" & txtBkName.Text & "' and Namecr='" & txtBkName.Text & "'", cn)
                da.Fill(ds)
                DG1.DataSource = ds.Tables(0)
                Try
                    DG1.Item(0, DG1.RowCount - 1).Selected = True
                Catch ex As Exception
                    txtAccode.Clear()
                    txtAcName.Clear()
                    txtAmount.Clear()
                    txtChqno.Clear()
                    txtFind.Clear()
                    txtRefBank.Clear()
                    txtRemark.Clear()
                    txtVrnofirst.Clear()
                    txtVrNosec.Clear()
                End Try
                close1()
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        numericform(txtAmount)
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcName.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChqno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRefBank.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAcName.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtChqno.Focus()
        End If
    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            'TextBox4.Focus()
            If Label11.Text.ToUpper = "EDIT MODE" Then
                checkedit = 1
            End If
            Me.Hide()
            frmoutpmt.Close()
            connect()
            da = New SqlDataAdapter("Select * from tblBank where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
            da.Fill(ds, "tblbank")
            frmoutpmt.copybank.DataSource = ds.Tables("tblbank")
            da = New SqlDataAdapter("Select * from tblLedg where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='Bank'", cn)
            da.Fill(ds, "tblLedg")
            frmoutpmt.copyledg.DataSource = ds.Tables("tblLedg")
            da = New SqlDataAdapter("Select * from tblJour where Remark='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Type='BKPYMT'", cn)
            da.Fill(ds, "tbljour")
            frmoutpmt.copyjour.DataSource = ds.Tables("tbljour")
            If ComboBox1.Text.ToLower = "false" Then
                Me.Show()
                '  deletecode()
                txtRemark.Focus()
                GoTo k
            End If
            frmoutpmt.Show()
            '  frmoutpmt.Show()
k:
            close1()

        ElseIf e.KeyCode = Keys.Up Then
            txtRefBank.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAmount.Focus()
        End If
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub Button5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butExit.KeyDown

    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maskdate.Leave
        Try
            Dim dat As New Date
            dat = maskdate.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Or DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter Date in Current A/c Year")
                maskdate.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            maskdate.Focus()
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        save2()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        Try
            If checkedit = 1 Then
                save2()
            End If
            GroupBox2.Visible = True
            txtFind.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
    End Sub
    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        If Val(txtAmount.Text) > 100000000000000.0 Then
            MsgBox("Not valid figure")
            txtAmount.Focus()
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (txtFind.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = txtFind.Text
        For i = temp1 To DG1.Rows.Count - 1
            For j = temp2 To DG1.ColumnCount - 1
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)
                If (DG1.Item(j, i).Value.ToString.ToLower.ToString.Contains(tv1.ToLower)) Then
                    DG1.Item(j, i).Selected = True
                    temp2 = j + 1
                    '    check = 1
                    GoTo en
                End If
            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub

    Private Sub TextBox11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            butOK.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAmount.Focus()
        End If
    End Sub
End Class