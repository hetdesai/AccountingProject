Imports System.Data.SqlClient
Public Class frmBankRecipt
    Dim dr As SqlDataReader
    Public tempds As New DataSet1
    Public bankrac As Integer = 0
    Public checkedit As Integer = 0
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim selectfield As String
    Dim gridamt As Decimal
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim tv1 As String
    Dim billclear As String = ""
    Private Sub frmBankRecipt_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If checkedit = 1 Then
            checkedit = 0
            save2()
        End If
    End Sub
    Private Sub frmBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            DG1.Focus()
        End If

    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkname.GotFocus, txtBkcode.GotFocus, txtVrNofirst.GotFocus, txtVrNosec.GotFocus, txtRemark.GotFocus, txtAmount.GotFocus, txtChqNo.GotFocus, txtAcname.GotFocus, txtAccode.GotFocus, txtRefBank.GotFocus, maskdate.GotFocus
        Try
            sender.BackColor = Color.LightSteelBlue
            sender.forecolor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkname.LostFocus, txtBkcode.LostFocus, txtVrNofirst.LostFocus, txtVrNosec.LostFocus, txtRemark.LostFocus, txtAmount.LostFocus, txtChqNo.LostFocus, txtAcname.LostFocus, txtAccode.LostFocus, txtRefBank.LostFocus, maskdate.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub butAdd_Enter(sender As Object, e As EventArgs) Handles butFind.Enter, butExit.Enter, butEdit.Enter, butDelete.Enter, butAdd.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub
    Private Sub butAdd_Leave(sender As Object, e As EventArgs) Handles butFind.Leave, butExit.Leave, butEdit.Leave, butDelete.Leave, butAdd.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub butAdd_MouseLeave(sender As Object, e As EventArgs) Handles butFind.MouseLeave, butExit.MouseLeave, butEdit.MouseLeave, butDelete.MouseLeave, butAdd.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub butAdd_MouseHover(sender As Object, e As EventArgs) Handles butFind.MouseHover, butExit.MouseHover, butEdit.MouseHover, butDelete.MouseHover, butAdd.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub
    Private Sub frmBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        Dim da1 As New SqlDataAdapter
        Dim ds1 As New DataSet
        da1 = New SqlDataAdapter("Select ac.ACCode,ac.ACname,ac.Schedule,ac.Add1,ac.add2,ac.Place,ac.Pin,ac.State,ac.GSTNo,ac.CSTNo,ac.GstDT,ac.CSTDt,ac.PanNo,ac.Emailid,ac.MObNo,ac.Homeno,ac.Book,ac.Scode,ac.Mcode,ac.Pgroup,Sum(tblLedg.bal) as Balance,tblOpen.Amount,tblOpen.type from tblAccount ac Left outer join tblLedg On tblLedg.ACname=ac.Acname left outer join tblOpen on tblLedg.acname=tblOpen.ACNAME group by ac.ACCode,ac.ACname,ac.Schedule,ac.Add1,ac.add2,ac.Place,ac.Pin,ac.State,ac.GSTNo,ac.CSTNo,ac.GstDT,ac.CSTDt,ac.PanNo,ac.Emailid,ac.MObNo,ac.Homeno,ac.Book,ac.Scode,ac.Mcode,ac.Pgroup,tblLedg.ACname,tblOPen.amount,tblopen.type order by ac.ACNAME", cn)
        da1.Fill(ds1)
        DataGridView1.DataSource = ds1.Tables(0)
        Dim cmd1 As New SqlCommand
        Dim dr1 As SqlDataReader
        cmd1 = New SqlCommand("select fields from tblselectfield where tablename='tblbank'", cn)
        dr1 = cmd1.ExecuteReader
        While dr1.Read
            selectfield = dr1.Item(0).ToString.Substring(0, dr1.Item(0).ToString.Length - 1)
        End While
        dr1.Close()
        close1()
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            If frmzoom7.zoom = True Then
                Dim cmd As New SqlCommand
                Dim drsale As SqlDataReader
                connect()
                cmd = New SqlCommand("Select " & selectfield & " from tblBank where VrNo='" & frmzoom7.VrNo & "'", cn)
                drsale = cmd.ExecuteReader
                While drsale.Read
                    txtBkname.Text = drsale.Item("BkName")
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
                    txtBkname.Text = drsale.Item("BkName")
                End While
                drsale.Close()
                close1()
            Else
                txtBkname.Text = (frmMainScreen.bankrnam)
                Try
                    'TextBox1.Text = (frmMainScreen.bankrnam)
                    Dim book As String
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    connect()
                    cmd = New SqlCommand("Select BOOK from tblAccount where ACNAME='" & txtBkname.Text & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        book = dr.Item(0).ToString
                    End While
                    dr.Close()
                    If book.ToUpper = "CASH" Then
                        Label12.Visible = False
                        txtSlipNo.Visible = False
                        txtSlipNo.Text = 0
                        Button7.Visible = False
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
            dr = myconselect("tblAccount", txtBkname.Text, "ACName")
            While dr.Read
                txtBkcode.Text = dr.Item("ACCode")
            End While
            dr.Close()
            Dim ds As New DataSet
            connect()
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select " & selectfield & " from tblBank Where BkName='" & txtBkname.Text & "' and Name='" & txtBkname.Text & "' ORDER BY convert(int,BookVr) ", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            close1()
            If DG1.RowCount = 0 Then
            Else
                DG1.Item(0, DG1.Rows.Count - 1).Selected = True
            End If
            txtVrNofirst.Text = acycode & "\"

            'TextBox3.Text = "2"
            txtRefBank.SendToBack()
            If frmzoom7.zoom = True Then
                Dim cn As Integer
                For cn = 0 To DG1.Rows.Count - 1
                    If DG1.Item(0, cn).Value = frmzoom7.VrNo Then
                        DG1.Item(0, cn).Selected = True
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


en:


            End If
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
            Dim maxVrNo1 As Integer
            maxVrNo1 = 0
            While dr.Read
                If maxVrNo1 < dr.Item("VrNo").ToString.Substring(3) Then
                    maxVrNo1 = dr.Item("VrNo").ToString.Substring(3)
                End If
            End While
            dr.Close()
            tb.Text = maxVrNo1 + 1
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyDown
        'Me.KeyPreview = False
        If e.KeyCode = Keys.Enter Then
            '    frmforout.Show()
            If dgacm.Rows.Count <> 0 Then
                txtAcname.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                dgacm.Visible = False
                txtChqNo.Focus()
            Else
                If MsgBox("Account not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    bankrac = 1
                    frmACMaster.Show()
                    Me.Hide()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            dgacm.Focus()
            dgacm.Item(1, 0).Selected = True
        ElseIf e.KeyCode = Keys.Up Then
            dgacm.Visible = False
            maskdate.Focus()
        End If
    End Sub
    Private Function validate() As Boolean
        If Val(txtReciptVrNo.Text) = 0 Or txtReciptVrNo.Text.Length = 0 Then
            MsgBox("Enter proper recipt no")
            txtReciptVrNo.Focus()
            Return False
        ElseIf Val(txtSlipNo.Text) = 0 Or txtSlipNo.Text.Length = 0 Then
            MsgBox("Enter proper slip no")
            txtSlipNo.Focus()
            Return False
        ElseIf txtAcname.Text.Trim.Length = 0 Then
            MsgBox("A/c name can not be blank")
            txtAcname.Focus()
            Return False
        ElseIf txtChqNo.Text.Trim.Length = 0 Then
            MsgBox("Check no can not be blank")
            txtChqNo.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub saveproc()
        Try
            checkedit = 0
            If validate() Then
            Else
                GoTo last
            End If
            Try
                Me.ds.Tables("tblBank").Rows.Clear()
                Me.ds.Tables("tblJour").Rows.Clear()
                Me.ds.Tables("tblLedg").Rows.Clear()
                frmforout.dg2copy.Rows.Clear()
                checkedit = 0
            Catch ex As Exception
            End Try
            Try
                frmforout.dg1copy.Rows.Clear()
                frmforout.copybank.Rows.Clear()
                frmforout.copyledg.Rows.Clear()
                frmforout.copyjour.Rows.Clear()

            Catch ex As Exception
            End Try
            Dim dat1 As New Date
            dat1 = maskdate.Text.ToString
            maxVrNo(txtVrNosec, "tblbank")
            If Label11.Text = "ADD Mode" Then
                jourentry()
                updatebill()
                Dim a() As String = {txtVrNofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBkcode.Text, txtBkname.Text, txtBkcode.Text, txtBkname.Text, txtAmount.Text, txtRemark.Text, txtChqNo.Text, txtRefBank.Text, "Bank", txtAcname.Text, txtAccode.Text, txtSlipNo.Text, " ", txtReciptVrNo.Text, "f", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, ComboBox1.Text.ToUpper, txtJVVRNO.Text}
                Dim b() As String = {txtVrNofirst.Text & txtVrNosec.Text, "BANK", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBkcode.Text, txtBkname.Text, txtAmount.Text, 0, (Val(txtAmount.Text) * -1), txtRemark.Text, txtChqNo.Text, txtAcname.Text, txtAccode.Text}
                Dim c() As String = {txtVrNofirst.Text & txtVrNosec.Text, "BANK", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAccode.Text, txtAcname.Text, 0, txtAmount.Text, Val(txtAmount.Text), txtRemark.Text, txtChqNo.Text, txtBkname.Text, txtBkcode.Text}

                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                connect()
                cmdcheck = New SqlCommand("Select * from tblBank where BookVr='" & txtReciptVrNo.Text & "'", cn)
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
                With frmforout.dg2
                    Dim k As Integer
                    For k = 0 To frmforout.dg2.RowCount - 1
                        Dim dat As New Date
                        dat = .Item(1, k).Value
                        Dim bankt() As String = {txtVrNofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, (.Item(0, k).Value), Format(Val(.Item(6, k).Value), "0.00"), Format(Val(.Item(7, k).Value), "0.00"), Format(Val(.Item(8, k).Value), "0.00"), Format(Val(.Item(10, k).Value), "0.00"), "asdasd", Format(Val(.Item(4, k).Value), "0.00"), Format(Val(.Item(13, k).Value), "0.00"), Format(Val(.Item(14, k).Value), "0.00"), Format(Val(.Item(5, k).Value), "0.00"), Format(Val(.Item(9, k).Value), "0.00"), Format(Val(.Item(11, k).Value), "0.00"), txtChqNo.Text, .Item(.ColumnCount - 2, k).Value, .Item(.ColumnCount - 1, k).Value, "0", txtBkname.Text, "0", dat.Month & "-" & dat.Day & "-" & dat.Year, "Sales"}
                        myinsert(bankt, "bankt")
                    Next
                End With
                connect()
                If ComboBox1.Text.ToUpper = "TRUE" Then
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("Update adv set isclear='t' where acname='" & txtAcname.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                    '   If frmforout.adv1 = 1 Then
                    Dim tb As New TextBox
                    maxVrNo(tb, "Adv")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcname.Text, txtAccode.Text, txtVrNofirst.Text & txtVrNosec.Text, Val(frmforout.TextBox2.Text), "Oub No", txtRemark.Text, txtBkname.Text, txtBkcode.Text, "f"}
                    myinsert(adv, "Adv")
                End If
                ' End If

                
            ElseIf Label11.Text = "EDIT Mode" Then
                jourentry()
                updatebill()
                Dim a() As String = {txtVrNofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBkcode.Text, txtBkname.Text, txtBkcode.Text, txtBkname.Text, txtAmount.Text, txtRemark.Text, txtChqNo.Text, txtRefBank.Text, "Bank", txtAcname.Text, txtAccode.Text, txtSlipNo.Text, " ", txtReciptVrNo.Text, "f", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, ComboBox1.Text.ToUpper, txtJVVRNO.Text}
                Dim b() As String = {txtVrNofirst.Text & txtVrNosec.Text, "BANK", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBkcode.Text, txtBkname.Text, txtAmount.Text, 0, (Val(txtAmount.Text) * -1), txtRemark.Text, txtChqNo.Text, txtAcname.Text, txtAccode.Text}
                Dim c() As String = {txtVrNofirst.Text & txtVrNosec.Text, "BANK", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAccode.Text, txtAcname.Text, 0, txtAmount.Text, Val(txtAmount.Text), txtRemark.Text, txtChqNo.Text, txtBkname.Text, txtBkcode.Text}

                myinsert(a, "tblBank")
                myinsert(b, "tblLedg")
                myinsert(c, "tblLedg")
                With frmforout.dg2
                    Dim k As Integer
                    For k = 0 To frmforout.dg2.RowCount - 1
                        Dim dat As New Date
                        dat = .Item(1, k).Value
                        Dim bankt() As String = {txtVrNofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, (.Item(0, k).Value), Format(Val(.Item(6, k).Value), "0.00"), Format(Val(.Item(7, k).Value), "0.00"), Format(Val(.Item(8, k).Value), "0.00"), Format(Val(.Item(10, k).Value), "0.00"), "asdasd", Format(Val(.Item(4, k).Value), "0.00"), Format(Val(.Item(13, k).Value), "0.00"), Format(Val(.Item(14, k).Value), "0.00"), Format(Val(.Item(5, k).Value), "0.00"), Format(Val(.Item(9, k).Value), "0.00"), Format(Val(.Item(11, k).Value), "0.00"), txtChqNo.Text, .Item(.ColumnCount - 2, k).Value, .Item(.ColumnCount - 1, k).Value, "0", txtBkname.Text, "0", dat.Month & "-" & dat.Day & "-" & dat.Year, "Sales"}
                        myinsert(bankt, "bankt")
                    Next
                End With
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Update adv set isclear='t' where acname='" & txtAcname.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
                If ComboBox1.Text.ToUpper = "TRUE" Then
                    If frmforout.adv1 = 1 Then
                        Dim tb As New TextBox
                        maxVrNo(tb, "Adv")
                        tb.Text = acycode & "/" & tb.Text
                        Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcname.Text, txtAccode.Text, txtVrNofirst.Text & txtVrNosec.Text, Val(frmforout.TextBox2.Text), "Oub No", txtRemark.Text, txtBkname.Text, txtBkcode.Text, "f"}
                        myinsert(adv, "Adv")
                    End If
                End If
                Else
                MsgBox("Incorrect Option")
            End If
            MsgBox("success")
            clearall()
            connect()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select " & selectfield & " from tblBank Where BkName='" & txtBkname.Text & "' and Name='" & txtBkname.Text & "'ORDER BY convert(int,BookVr) ", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            Try
                DG1.Item(0, DG1.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try
            close1()
            butAdd.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
last:
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        saveproc()
    End Sub
    Private Sub clearall()
        txtVrNosec.Clear()
        txtRemark.Clear()
        txtAmount.Text = "0.00"
        txtChqNo.Clear()
        txtAcname.Clear()
        txtAccode.Clear()
        txtRefBank.Clear()
    End Sub
    Private Sub maxbkvrno()
        Dim check1 As Integer = 0
        connect()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select (Vrno) from tblBank Where BkName='" & txtBkname.Text & "' and Name='" & txtBkname.Text & "'", cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            check1 = 1
        Else
            check1 = 0
            dr.Close()
            txtReciptVrNo.Text = 1
        End If
        dr.Close()
        If check1 = 1 Then
            cmd = New SqlCommand("Select max(convert(int,BookVr)) from tblBank Where BkName='" & txtBkname.Text & "' and Name='" & txtBkname.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                '   MsgBox(dr.Item(0).ToString)
                txtReciptVrNo.Text = dr.Item(0) + 1
            End While
            dr.Close()
        End If
        close1()
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
        '   clearall()
        txtVrNofirst.Text = acycode & "\"
        maxVrNo(txtVrNosec, "tblBank")
        maskdate.Focus()
        '   MaskedTextBox1.Text = Format(Date.Today, "dd-MM-yyyy")
        maskdate.SelectionStart = 0
        maxbkvrno()
        txtSlipNo.Text = 1
        txtSlipNo.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        Try

            If checkedit = 1 Then
                save2()
            End If
        Catch ex As Exception

        End Try
        Label11.Text = "EDIT Mode"
        GroupBox1.Enabled = True
        maskdate.Focus()
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblbank where vrno='" & DG1.Item(0, DG1.CurrentCell.RowIndex).Value & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtVrNofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                txtVrNosec.Text = dr.Item("vrno").ToString.Substring(3)
                txtBkcode.Text = dr.Item("bkcode")
                txtBkname.Text = dr.Item("bkname")
                maskdate.Text = Format(dr.Item("dat"), "dd-MM-yyyy")
                txtAcname.Text = dr.Item("Namecr")
                txtAccode.Text = dr.Item("accodecr")
                txtChqNo.Text = dr.Item("checkno")
                txtRefBank.Text = dr.Item("refbank")
                txtAmount.Text = dr.Item("amount")
                txtRemark.Text = dr.Item("desce")
                txtSlipNo.Text = dr.Item("slipno")
                txtReciptVrNo.Text = dr.Item("bookvr")
                gridamt = dr.Item("amount")
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        If frmzoom7.zoom = True Then
            frmzoom7.Close()
            frmzoom7.Show()
        End If
        Me.Close()
    End Sub
    Private Sub TextBox13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            butOK.Focus()
        End If
    End Sub
    Private Sub DG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DG1.Width = 400
            DG1.Height = 700
            DG1.BringToFront()
            e.Handled = True
        End If
    End Sub
    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.RowEnter
        Try
            Try
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("select * from tblbank where vrno='" & DG1.Item(0, e.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    txtVrNofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                    txtVrNosec.Text = dr.Item("vrno").ToString.Substring(3)
                    txtBkcode.Text = dr.Item("bkcode")
                    txtBkname.Text = dr.Item("bkname")
                    maskdate.Text = Format(dr.Item("dat"), "dd-MM-yyyy")
                    txtAcname.Text = dr.Item("Namecr")
                    txtAccode.Text = dr.Item("accodecr")
                    txtChqNo.Text = dr.Item("checkno")
                    txtRefBank.Text = dr.Item("refbank")
                    txtAmount.Text = dr.Item("amount")
                    txtRemark.Text = dr.Item("desce")
                    txtSlipNo.Text = dr.Item("slipno")
                    txtReciptVrNo.Text = dr.Item("bookvr")
                    gridamt = dr.Item("amount")
                    ComboBox1.Text = dr.Item("Billclear")
                    billclear = dr.Item("Billclear")
                End While
                dr.Close()
                close1()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgacm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcname.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
            Dim dr As SqlDataReader
            dr = myconselect("tblAccount", txtAcname.Text, "ACName")
            While dr.Read
                txtAccode.Text = dr.Item("ACCode")
            End While
            txtChqNo.Focus()
            dgacm.Visible = False
        End If
    End Sub
    Private Sub TextBox7_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyUp
        '        myAutoComplete(TextBox7, ListBox1, "TBLACCOUNT", "ACNAME")
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
            '  dgacm.Top = sender.Top + 22
            ' dgacm.Left = sender.Left
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcname.Leave
        dr = myconselect("tblAccount", txtAcname.Text, "ACName")
        While dr.Read
            txtAccode.Text = dr.Item("ACCode")
        End While
        dr.Close()
    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try

            If checkedit = 1 Then
                save2()
            End If
        Catch ex As Exception

        End Try
        Try
            '    deletecode()
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
            If MsgBox("You want to delete entry for VrNo=" & txtVrNofirst.Text & txtVrNosec.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim cmd As New SqlCommand
                Dim da1 As New SqlDataAdapter
                cmd = New SqlCommand("Delete from tblBank where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='BANK'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where Remark='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Type='BKRCPT'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where Remark='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='JOUR'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Select * from bankt where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
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
                    cmd = New SqlCommand("Select outamt from tblOub where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString, cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                    End While
                    dr3.Close()

                    cmd = New SqlCommand("Select outamt from salesc where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString, cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                    End While
                    dr3.Close()
                    cmd = New SqlCommand("Update salesc set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and name='" & txtAcname.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString & " and acname='" & txtAcname.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                Next
                ' MsgBox(tamt)
                If billclear = "TRUE" Then
                    cmd = New SqlCommand("Select Amount from adv where acname='" & txtAcname.Text & "' and isclear='f'", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        tamt = tamt + 0
                    Else
                        While dr.Read
                            tamt = tamt + Val(dr.Item(0))
                        End While
                        dr.Close()
                        cmd = New SqlCommand("Update adv set isclear='t' where acname='" & txtAcname.Text & "'", cn)
                        cmd.ExecuteNonQuery()
                    End If
                    ' MsgBox(tamt)
                    'MsgBox(gridamt)
                    '  MsgBox(tamt - Val(TextBox5.Text))
                    Dim tb As New TextBox
                    maxVrNo(tb, "Adv")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcname.Text, txtAccode.Text, txtVrNofirst.Text & txtVrNosec.Text, Val(tamt - gridamt), "Oub No", txtRemark.Text, txtBkname.Text, txtBkcode.Text, "f"}
                    myinsert(adv, "Adv")
                End If
                connect()
                cmd = New SqlCommand("Delete from bankt where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()

                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                connect()
                da = New SqlDataAdapter("Select " & selectfield & " from tblBank Where BkName='" & txtBkname.Text & "' and Name='" & txtBkname.Text & "'", cn)
                da.Fill(ds)
                DG1.DataSource = ds.Tables(0)
                Try
                    DG1.Item(0, DG1.RowCount - 1).Selected = True
                Catch ex As Exception
                    txtAccode.Clear()
                    txtAcname.Clear()
                    txtChqNo.Clear()
                    txtReciptVrNo.Clear()
                    txtRefBank.Clear()
                    txtRemark.Clear()
                    txtSearch.Clear()
                    txtVrNofirst.Clear()
                    txtVrNosec.Clear()
                    txtSlipNo.Clear()
                End Try
                close1()
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

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
            If MsgBox("You want to delete entry for VrNo=" & txtVrNofirst.Text & txtVrNosec.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim cmd As New SqlCommand
                Dim bankamt As Decimal
                cmd = New SqlCommand("Select * from tblbank where vrno='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    bankamt = dr.Item(6)
                End While
                dr.Close()
                Dim da1 As New SqlDataAdapter
                cmd = New SqlCommand("Delete from tblBank where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='BANK'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where Remark='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Type='BKRCPT'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where Remark='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='JOUR'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Select * from bankt where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
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
                    cmd = New SqlCommand("Select outamt from tblOub where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString, cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                    End While
                    dr3.Close()
                    cmd = New SqlCommand("Select outamt from salesc where oubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString, cn)
                    dr3 = cmd.ExecuteReader
                    While dr3.Read
                        amt1 = Val(dr3.Item(0).ToString)
                    End While
                    dr3.Close()
                    cmd = New SqlCommand("Update salesc set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Outamt=" & Val(amt1) + Val(paidamt.Items(itcount).ToString) + RD + TDS + CLAIM + DISCOUNT & ",Ispaid='f' where OubNo='" & oubNo.Items(itcount).ToString & "' and Bkcode=" & bkcode.Items(itcount).ToString, cn)
                    cmd.ExecuteNonQuery()
                Next
                ' MsgBox(tamt)
                If billclear = "TRUE" Then
                    cmd = New SqlCommand("Select Amount from adv where acname='" & txtAcname.Text & "' and isclear='f'", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        tamt = tamt + 0
                    Else
                        While dr.Read
                            MsgBox(dr.Item(0))
                            tamt = tamt + Val(dr.Item(0))
                        End While
                        dr.Close()
                        cmd = New SqlCommand("Update adv set isclear='t' where acname='" & txtAcname.Text & "'", cn)
                        cmd.ExecuteNonQuery()
                    End If
                    '  MsgBox(tamt - Val(TextBox5.Text))
                    Dim tb As New TextBox
                    maxVrNo(tb, "Adv")
                    tb.Text = acycode & "/" & tb.Text
                    Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcname.Text, txtAccode.Text, txtVrNofirst.Text & txtVrNosec.Text, Val(tamt - Val(bankamt)), "Oub No", txtRemark.Text, txtBkname.Text, txtBkcode.Text, "f"}
                    myinsert(adv, "Adv")
                End If
                connect()
                cmd = New SqlCommand("Delete from bankt where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
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
    Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcname.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChqNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRefBank.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAcname.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtChqNo.Focus()
        End If
    End Sub
    Public Sub save2()
        If validate() Then
        Else
            GoTo last
        End If
        Try
            jourentry2()
            updatebill1()

            With frmforout
                Dim dat1 As New Date
                dat1 = maskdate.Text.ToString
                maxVrNo(txtVrNosec, "tblbank")
                Dim dat2 As New Date
                Dim dat31 As New Date
                Try
                    dat2 = .copybank.Item(1, 0).Value
                    dat31 = .copybank.Item(17, 0).Value
                Catch ex As Exception

                End Try
                Dim a() As String = {.copybank.Item(0, 0).Value, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, .copybank.Item(2, 0).Value, .copybank.Item(3, 0).Value, .copybank.Item(4, 0).Value, .copybank.Item(5, 0).Value, .copybank.Item(6, 0).Value, .copybank.Item(7, 0).Value, .copybank.Item(8, 0).Value, .copybank.Item(9, 0).Value, .copybank.Item(10, 0).Value, .copybank.Item(11, 0).Value, .copybank.Item(12, 0).Value, .copybank.Item(13, 0).Value, .copybank.Item(14, 0).Value, .copybank.Item(15, 0).Value, .copybank.Item(16, 0).Value, dat31.Month & "-" & dat31.Day & "-" & dat31.Year, .copybank.Item(18, 0).Value, txtJVVRNO.Text}
                myinsert(a, "tblBank")
                Dim icount As Integer
                For icount = 0 To .copyledg.Rows.Count() - 1
                    Dim dat3 As New Date
                    dat3 = .copyledg.Item(2, icount).Value
                    Dim b() As String = {.copyledg.Item(0, icount).Value, .copyledg.Item(1, icount).Value, dat3.Month & "-" & dat3.Day & "-" & dat3.Year, .copyledg.Item(3, icount).Value, .copyledg(4, icount).Value, .copyledg(5, icount).Value, .copyledg(6, icount).Value, .copyledg(7, icount).Value, .copyledg(8, icount).Value, .copyledg(9, icount).Value, .copyledg(10, icount).Value, .copyledg(11, icount).Value}
                    myinsert(b, "tblLedg")
                Next
                With frmforout.dg2copy
                    Dim k As Integer
                    For k = 0 To frmforout.dg2copy.RowCount - 1
                        Dim dat As New Date
                        dat = .Item(1, k).Value
                        Dim bankt() As String = {txtVrNofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, (.Item(0, k).Value), Format(Val(.Item(6, k).Value), "0.00"), Format(Val(.Item(7, k).Value), "0.00"), Format(Val(.Item(8, k).Value), "0.00"), Format(Val(.Item(10, k).Value), "0.00"), "asdasd", Format(Val(.Item(4, k).Value), "0.00"), Format(Val(.Item(13, k).Value), "0.00"), Format(Val(.Item(14, k).Value), "0.00"), Format(Val(.Item(5, k).Value), "0.00"), Format(Val(.Item(9, k).Value), "0.00"), Format(Val(.Item(11, k).Value), "0.00"), txtChqNo.Text, .Item(.ColumnCount - 2, k).Value, .Item(.ColumnCount - 1, k).Value, "0", txtBkname.Text, "0", dat.Month & "-" & dat.Day & "-" & dat.Year, "Sales"}
                        myinsert(bankt, "bankt")
                    Next
                End With
                If .copybank.Item(18, 0).Value.ToString.ToUpper = "TRUE" Then
                    connect()
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("Update adv set isclear='t' where acname='" & txtAcname.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                    If Val(frmforout.TextBox2copy.Text) > 0 Then
                        Dim tb As New TextBox
                        maxVrNo(tb, "Adv")
                        tb.Text = acycode & "/" & tb.Text
                        Dim adv() As String = {tb.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtAcname.Text, txtAccode.Text, txtVrNofirst.Text & txtVrNosec.Text, Val(frmforout.TextBox2copy.Text), "Oub No", txtRemark.Text, txtBkname.Text, txtBkcode.Text, "f"}
                        myinsert(adv, "Adv")
                    End If
                End If
                ds.Tables("tblBank").Rows.Clear()
                ds.Tables("tblJour").Rows.Clear()
                ds.Tables("tblLedg").Rows.Clear()
                .dg2copy.Rows.Clear()
                Try
                    .dg1copy.Rows.Clear()
                    .copybank.Rows.Clear()
                    .copyledg.Rows.Clear()
                    .copyjour.Rows.Clear()
                Catch ex As Exception
                End Try
                checkedit = 0
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
last:
    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Label11.Text = "EDIT Mode" Then
                ' deletecode()
                frmforout.Close()
                connect()
                da = New SqlDataAdapter("Select * from tblBank where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                da.Fill(ds, "tblbank")
                frmforout.copybank.DataSource = ds.Tables("tblbank")
                da = New SqlDataAdapter("Select * from tblLedg where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='Bank'", cn)
                da.Fill(ds, "tblLedg")
                frmforout.copyledg.DataSource = ds.Tables("tblLedg")
                da = New SqlDataAdapter("Select * from tblJour where Remark='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Type='BKRCPT'", cn)
                da.Fill(ds, "tbljour")
                frmforout.copyjour.DataSource = ds.Tables("tbljour")
                close1()
                checkedit = 1
            Else
                frmforout.Close()
            End If
            If ComboBox1.Text.ToUpper = "TRUE" Then
                frmforout.Show()
            Else
                deletecode()
                txtRemark.Focus()
            End If
            'TextBox4.Focus()
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
    Private Sub jourentry()
        Try
            If Val(frmforout.discount.Text) > 0 Or Val(frmforout.rdcount.Text) > 0 Or Val(frmforout.claimcount.Text) > 0 Or Val(frmforout.tdscount.Text) > 0 Then
                Dim amt As Decimal = 0.0
                Dim tb As New TextBox
                maxVrNo(tb, "tblJour")
                tb.Text = acycode & "/" & tb.Text
                '  MsgBox(tb.Text)
                txtJVVRNO.Text = tb.Text
                Dim dat As New Date
                dat = maskdate.Text
                Dim k As Integer = 0
                With frmforout
                    If Val(.discount.Text) > 0 Then
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
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.discount.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.discount.Text), 0.0, -(Val(.discount.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
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
                        CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='RD'", cn)
                        dr = CMD.ExecuteReader
                        While dr.Read
                            disccode = dr.Item("ACCODe")
                            disacname = dr.Item("ACNAME")
                        End While
                        dr.Close()
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.rdcount.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.rdcount.Text), 0.0, -(Val(.rdcount.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
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
                        CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='CLAIM'", cn)
                        dr = CMD.ExecuteReader
                        While dr.Read
                            disccode = dr.Item("ACCODe")
                            disacname = dr.Item("ACNAME")
                        End While
                        dr.Close()
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.claimcount.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.claimcount.Text), 0.0, -(Val(.claimcount.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
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
                        CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='TDS'", cn)
                        dr = CMD.ExecuteReader
                        While dr.Read
                            disccode = dr.Item("ACCODe")
                            disacname = dr.Item("ACNAME")
                        End While
                        dr.Close()
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.tdscount.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.tdscount.Text), 0.0, -(Val(.tdscount.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
                        myinsert(b, "tblLedg")
                        amt = amt + Val(.tdscount.Text)
                        close1()
                    End If
                    If amt > 0 Then
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", txtAcname.Text, txtAccode.Text, 0.0, amt, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, txtAccode.Text, txtAcname.Text, 0.0, Val(amt), (Val(amt)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
                        myinsert(b, "tblLedg")
                    End If

                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub jourentry2()

        Try
            If Val(frmforout.discountcopy.Text) > 0 Or Val(frmforout.rdcountcopy.Text) > 0 Or Val(frmforout.claimcountcopy.Text) Or Val(frmforout.tdscountcopy.Text) > 0 Then
                Dim amt As Decimal = 0.0
                Dim tb As New TextBox
                maxVrNo(tb, "tblJour")
                tb.Text = acycode & "/" & tb.Text
                txtJVVRNO.Text = tb.Text
                '  MsgBox(tb.Text)
                Dim dat As New Date
                dat = maskdate.Text
                Dim k As Integer = 0
                With frmforout
                    If Val(.discountcopy.Text) > 0 Then
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
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.discountcopy.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.discountcopy.Text), 0.0, -(Val(.discountcopy.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
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
                        CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='RD'", cn)
                        dr = CMD.ExecuteReader
                        While dr.Read
                            disccode = dr.Item("ACCODe")
                            disacname = dr.Item("ACNAME")
                        End While
                        dr.Close()
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.rdcountcopy.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.rdcountcopy.Text), 0.0, -(Val(.rdcountcopy.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
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
                        CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='CLAIM'", cn)
                        dr = CMD.ExecuteReader
                        While dr.Read
                            disccode = dr.Item("ACCODe")
                            disacname = dr.Item("ACNAME")
                        End While
                        dr.Close()
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.claimcountcopy.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.claimcountcopy.Text), 0.0, -(Val(.claimcountcopy.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
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
                        CMD = New SqlCommand("Select * from AujvMst where Aujvbook='SALE' and AUjvType='TDS'", cn)
                        dr = CMD.ExecuteReader
                        While dr.Read
                            disccode = dr.Item("ACCODe")
                            disacname = dr.Item("ACNAME")
                        End While
                        dr.Close()
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "DR", disacname, disccode, Val(.tdscountcopy.Text), 0.0, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, disccode, disacname, Val(.tdscountcopy.Text), 0.0, -(Val(.tdscountcopy.Text)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
                        myinsert(b, "tblLedg")
                        amt = amt + Val(.tdscountcopy.Text)
                        close1()
                    End If
                    If amt > 0 Then
                        Dim a() As String = {tb.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, k + 1, "CR", txtAcname.Text, txtAccode.Text, 0.0, amt, txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT"}
                        myinsert(a, "tblJour")
                        Dim b() As String = {tb.Text, "JOUR", dat.Month & "-" & dat.Day & "-" & dat.Year, txtAccode.Text, txtAcname.Text, 0.0, Val(amt), (Val(amt)), txtVrNofirst.Text & txtVrNosec.Text, "BKRCPT", 0, 0}
                        myinsert(b, "tblLedg")
                    End If
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub updatebill()
        With frmforout
            Dim k As Integer
            Dim cmd As New SqlCommand
            connect()
            For k = 0 To .dg2.RowCount - 1
                cmd = New SqlCommand("Update salesc set OutAmt=" & calout(k) & " where OubNo='" & .dg2.Item(0, k).Value & "' and BKname='" & .dg2.Item(.dg2.ColumnCount - 2, k).Value & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update tblOub set OutAmt=" & calout(k) & " where OubNo='" & .dg2.Item(0, k).Value & "' and BKname='" & .dg2.Item(.dg2.ColumnCount - 2, k).Value & "'", cn)
                cmd.ExecuteNonQuery()
                If calout(k) = 0 Then
                    cmd = New SqlCommand("Update salesc set Ispaid='" & "t" & "' where OubNo='" & .dg2.Item(0, k).Value & "' and BKname='" & .dg2.Item(.dg2.ColumnCount - 2, k).Value & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Ispaid='" & "t" & "' where OubNo='" & .dg2.Item(0, k).Value & "' and BKname='" & .dg2.Item(.dg2.ColumnCount - 2, k).Value & "'", cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            close1()
        End With
    End Sub
    Private Sub updatebill1()
        With frmforout
            Dim k As Integer
            Dim cmd As New SqlCommand
            connect()
            For k = 0 To .dg2copy.RowCount - 1
                cmd = New SqlCommand("Update salesc set OutAmt=" & calout1(k) & " where OubNo='" & .dg2copy.Item(0, k).Value & "' and BKname='" & .dg2copy.Item(.dg2copy.ColumnCount - 2, k).Value & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update tblOub set OutAmt=" & calout1(k) & " where OubNo='" & .dg2copy.Item(0, k).Value & "' and BKname='" & .dg2copy.Item(.dg2copy.ColumnCount - 2, k).Value & "'", cn)
                cmd.ExecuteNonQuery()
                If calout1(k) = 0 Then
                    cmd = New SqlCommand("Update salesc set Ispaid='" & "t" & "' where OubNo='" & .dg2copy.Item(0, k).Value & "' and BKname='" & .dg2copy.Item(.dg2copy.ColumnCount - 2, k).Value & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOub set Ispaid='" & "t" & "' where OubNo='" & .dg2copy.Item(0, k).Value & "' and BKname='" & .dg2copy.Item(.dg2copy.ColumnCount - 2, k).Value & "'", cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            close1()
        End With
    End Sub
    Private Function calout(ByVal i As Integer) As Decimal
        With frmforout.dg2
            Dim amt As Decimal = 0
            amt = Val(.Item(4, i).Value) + Val(.Item(6, i).Value) + Val(.Item(7, i).Value) + Val(.Item(8, i).Value) + Val(.Item(10, i).Value)
            Return Format(Val(.Item(3, i).Value) - amt, "0.00")
        End With
    End Function
    Private Function calout1(ByVal i As Integer) As Decimal
        With frmforout.dg2copy
            Dim amt As Decimal = 0
            amt = Val(.Item(4, i).Value) + Val(.Item(6, i).Value) + Val(.Item(7, i).Value) + Val(.Item(8, i).Value) + Val(.Item(10, i).Value)
            Return Format(Val(.Item(3, i).Value) - amt, "0.00")
        End With
    End Function
    Private Sub TextBox5_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAmount.MouseDown

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        saveproc()
        txtSlipNo.Text = Val(txtSlipNo.Text) + 1
    End Sub

    Private Sub TextBox11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSlipNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            maskdate.Focus()
        End If
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


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        save2()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        Try

            If checkedit = 1 Then
                save2()
            End If
            GroupBox2.Visible = True
            txtSearch.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress

    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        If Val(txtAmount.Text) > 99999999999999.984 Then
            MsgBox("Not valid figure")
            txtAmount.Focus()
        End If
    End Sub

    Private Sub dgacm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgacm.CellContentClick

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (txtSearch.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = txtSearch.Text
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

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAmount.Focus()
        End If
    End Sub

    
End Class