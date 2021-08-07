Imports System.Data.SqlClient
Public Class frmACMaster
    Dim check As Integer = 1
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim rowindex As Integer
    Dim colindex As Integer
    Dim timercount As Integer
    Public findcol As String
    Dim tb As Integer
    Public accheck As Integer = 0
    Public plcheck As Integer = 0
    Public stcheck As Integer = 0
    Public groupcheck As Integer = 0
    Public mstcheck As Integer = 0
    Dim CLOSECHECK As Integer = 0
    Public markacheck As Integer = 0
    Dim tv As String = ""
    Dim temp1 As Integer
    Dim temp2 As Integer
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccode.GotFocus, txtAcname.GotFocus, txtPanno.GotFocus, txtmobno.GotFocus, txthomeno.GotFocus, txtAccode.GotFocus, txtScode.GotFocus, txtMhead.GotFocus, txtHead.GotFocus, txtcopyacname.GotFocus, txtShead.GotFocus, TextBox20.GotFocus, txtGroup.GotFocus, txtadd1.GotFocus, txtadd2.GotFocus, txtPlace.GotFocus, txtPin.GotFocus, txtState.GotFocus, txtGstno.GotFocus, txtCstno.GotFocus, MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus, txtemailid.GotFocus
        Try
            sender.BackColor = Color.Yellow
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccode.LostFocus, txtAcname.LostFocus, txtPanno.LostFocus, txtmobno.LostFocus, txthomeno.LostFocus, txtAccode.LostFocus, txtScode.LostFocus, txtMhead.LostFocus, txtHead.LostFocus, txtcopyacname.LostFocus, txtShead.LostFocus, TextBox20.LostFocus, txtGroup.LostFocus, txtadd1.LostFocus, txtadd2.LostFocus, txtPlace.LostFocus, txtPin.LostFocus, txtState.LostFocus, txtGstno.LostFocus, txtCstno.LostFocus, MaskedTextBox1.LostFocus, MaskedTextBox2.LostFocus, txtemailid.LostFocus
        Try
            sender.BackColor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmACMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOSECHECK = 1 Then
            If Form3.newac = 1 Then
                Form3.txtAcDr.Focus()
                Form3.Show()
                Form3.newac = 0
            ElseIf Form3.newac = 2 Then
                Form3.Show()
                Form3.txtAcCr.Focus()
                Form3.newac = 0
            ElseIf frmSale.newac = 1 Then
                frmSale.Show()
                frmSale.txtAcDr.Focus()
                frmSale.newac = 0
            ElseIf frmSale.newac = 2 Then
                frmSale.Show()
                frmSale.txtAcCr.Focus()
                frmSale.newac = 0
            ElseIf frmOpeningMaster.acbalance = 1 Then
                frmOpeningMaster.Show()
                frmOpeningMaster.txtAmount.Focus()
                frmOpeningMaster.acbalance = 0
            ElseIf frmBank.bankac = 1 Then
                frmBank.Show()
                frmBank.txtAcName.Focus()
                frmBank.bankac = 0
            ElseIf frmBankRecipt.bankrac = 1 Then
                frmBankRecipt.Show()
                frmBankRecipt.txtAcname.Focus()
                frmBankRecipt.bankrac = 0
            ElseIf frmJour.jourac = 1 Then
                frmJour.Show()
                frmJour.TextBox4.Focus()
                frmJour.jourac = 0
            ElseIf frmoub.acbalance = 1 Then
                frmoub.Show()
                frmoub.txtAmount.Focus()
                frmoub.acbalance = 0
            ElseIf frmlotr.lotracm = 1 Then
                frmlotr.Show()
                frmlotr.txtAcname.Focus()
                frmlotr.lotracm = 0
            ElseIf FRMChalan.newac = 2 Then
                FRMChalan.Show()
                FRMChalan.TextBox2.Focus()
                FRMChalan.newac = 0
            ElseIf FRMChalan.newac = 3 Then
                FRMChalan.Show()
                FRMChalan.TextBox3.Focus()
                FRMChalan.newac = 0
            ElseIf frmLotNew.lotracm = 1 Then
                frmLotNew.Show()
                frmLotNew.masklotno.Focus()
                frmLotNew.lotracm = 0
            End If
        End If
    End Sub
    Private Sub frmACMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel2.Width = Me.Width

        datagridcolor(dg1)
        Try
            companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
            dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
            '            If Form3.newac = 1 Or Form3.newac = 2 Or frmOpeningMaster.acbalance = 1 Or frmSale.newac = 1 Or frmSale.newac = 2 Or frmBank.bankac = 1 Or frmBankRecipt.bankrac = 1 Or frmJour.jourac = 1 Or frmoub.acbalance = 1 Or frmlotr.lotracm = 1 Or FRMChalan.newac = 2 Or FRMChalan.newac = 3 Or frmLotNew.lotracm = 1 Then
            '                dg1.Enabled = False
            '                Label5.Text = "ADD Mode"
            '                butEdit.Visible = False
            '                butFind.Visible = False
            '                check = 1
            '                Label5.Text = "ADD Mode"
            '                txtAcname.Clear()
            '                txtShead.Clear()
            '                txtadd1.Clear()
            '                txtadd2.Clear()
            '                txtPlace.Clear()
            '                txtPin.Clear()
            '                txtState.Clear()
            '                txtGstno.Clear()
            '                txtCstno.Clear()
            '                txtPanno.Clear()
            '                txtemailid.Clear()
            '                txtmobno.Clear()
            '                txthomeno.Clear()
            '                txtAccode.Clear()
            '                txtScode.Clear()
            '                txtMhead.Clear()
            '                txtHead.Clear()
            '                txtcopyacname.Clear()
            '                'ComboBox1.Clear()
            '                txtGroup.Clear()
            '                MaskedTextBox1.Clear()
            '                MaskedTextBox2.Clear()
            '                myserialno("tblAccount", txtAccode, "ACCode")
            '                GroupBox1.TabIndex = 0
            '                butAdd.TabIndex = 1
            '                GroupBox1.Enabled = True
            '                GroupBox1.Focus()
            '                txtBillPlace.Text = 0
            '                txtPreyn.Text = "NO"
            '                txtBillPre.Text = "NO"
            '                CLOSECHECK = 1
            '                If frmlotr.lotracm = 1 Or frmLotNew.lotracm = 1 Then

            '                    connect()
            '                    Try
            '                        Dim DR As SqlDataReader
            '                        Dim LOTN As Integer = 0
            '                        cmd = New SqlCommand("SELECT MAX(LOTN) FROM TBLLOTR", cn)
            '                        DR = cmd.ExecuteReader
            '                        While DR.Read
            '                            LOTN = DR.Item(0)
            '                        End While
            '                        DR.Close()
            '                        Dim ACCODE As Integer = 0
            '                        cmd = New SqlCommand("SELECT ACCODE FROM TBLLOTR WHERE LOTN=" & LOTN, cn)
            '                        DR = cmd.ExecuteReader
            '                        While DR.Read
            '                            ACCODE = DR.Item(0)
            '                        End While
            '                        DR.Close()
            '                        cmd = New SqlCommand("sELECT SCODE FROM TBLACCOUNT WHERE ACCODE=" & ACCODE, cn)
            '                        DR = cmd.ExecuteReader
            '                        While DR.Read
            '                            txtScode.Text = DR.Item(0)
            '                        End While
            '                        DR.Close()
            '                        cmd = New SqlCommand("Select * from tblSH where SCODE='" & txtScode.Text & "'", cn)
            '                        DR = cmd.ExecuteReader
            '                        While DR.Read
            '                            txtShead.Text = DR.Item("Shead")
            '                            txtGroup.Focus()
            '                            ' dr.Close()
            '                            listShead.Visible = False
            '                            ' GoTo en
            '                        End While
            '                        DR.Close()

            '                        DR = myconselect("tblSH", txtShead.Text, "Shead")
            '                        While DR.Read
            '                            txtScode.Text = DR.Item("Scode")
            '                            txtMhead.Text = DR.Item("Mhead")
            '                        End While
            '                        DR.Close()
            '                        DR = myconselect("tblMH", txtMhead.Text, "Mhead")
            '                        While DR.Read
            '                            txtHead.Text = DR.Item("ASD")
            '                        End While
            '                        DR.Close()
            '                        close1()
            '                        comBook.Text = "Other"
            '                        txtAcname.Focus()
            'EN:
            '                    Catch ex As Exception
            '                        MsgBox(ex.ToString)
            '                    End Try

            '                End If
            '                '    comBook.Focus()
            '            Else
            '                If check = 1 Then
            connect()
            '      myfillCustome(TextBox2, "tblSH", "Shead")
            '     myfillCustome(TextBox5, "tblPlace", "PLName")
            '    myfillCustome(TextBox7, "tblState", "STName")
            myfilldatagrid(dg1, "tblAccount")
            myhide()
            dg1.Columns(0).Width = 80
            dg1.Columns(1).Width = 180
            dg1.Columns(2).Width = 150
            dg1.Item(0, dg1.RowCount - 1).Selected = True
            butAdd.Focus()
            butAdd.TabIndex = 0
            GroupBox1.TabIndex = 1
            '                End If


            '                '      ElseIf check = 2 Then
            '            End If
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub frmACMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            '   If e.KeyCode = Keys.Enter Then
            'SendKeys.Send("{TAB}")
            If e.KeyCode = Keys.Escape Then
                Try
                    frmAccountSearch.Close()
                    Me.Close()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub myhide()
        dg1.Columns(3).Visible = False
        dg1.Columns(4).Visible = False
        dg1.Columns(5).Visible = False
        dg1.Columns(6).Visible = False
        dg1.Columns(7).Visible = False
        dg1.Columns(8).Visible = False
        dg1.Columns(9).Visible = False
        dg1.Columns(10).Visible = False
        dg1.Columns(11).Visible = False
        dg1.Columns(12).Visible = False
        dg1.Columns(13).Visible = False
        dg1.Columns(14).Visible = False
        dg1.Columns(15).Visible = False

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            '  dg1.Enabled = False
            check = 1
            Label5.Text = "ADD Mode"
            txtAcname.Clear()
            '      txtShead.Clear()
            txtadd1.Clear()
            txtadd2.Clear()
            txtPlace.Clear()
            txtPin.Clear()
            '     txtState.Clear()
            txtGstno.Clear()
            txtCstno.Clear()
            txtPanno.Clear()
            txtemailid.Clear()
            txtmobno.Clear()
            txthomeno.Clear()
            txtAccode.Clear()
            '    txtScode.Clear()
            '   txtMhead.Clear()
            '  txtHead.Clear()
            txtcopyacname.Clear()
            '  ComboBox1.Clear()
            ' txtGroup.Clear()
            MaskedTextBox1.Clear()
            MaskedTextBox2.Clear()
            myserialno("tblAccount", txtAccode, "ACCode")
            GroupBox1.Enabled = True
            comBook.Focus()
            txtBillPlace.Text = 0
            txtPreyn.Text = "NO"
            txtBillPre.Text = "NO"
            txtMst.Text = ""
            txtMstcode.Text = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        Try
            frmAccountSearch.Close()
            check = 2
            Label5.Text = "Edit Mode"
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            Dim dr As SqlDataReader
            '    MsgBox(i.Item(0).RowIndex)
            txtAccode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            txtcopyacname.Text = txtAccode.Text
            dr = myconselect("tblAccount", txtAccode.Text, "ACCode")
            While dr.Read
                txtAcname.Text = dr.Item(1)
                txtShead.Text = dr.Item(2)
                txtadd1.Text = dr.Item(3)
                txtadd2.Text = dr.Item(4)
                txtPlace.Text = dr.Item(5)
                txtPin.Text = dr.Item(6)
                txtState.Text = dr.Item(7)
                txtGstno.Text = dr.Item(8)
                txtCstno.Text = dr.Item(9)
                txtMarka.Text = dr.Item("marko")
                txtMst.Text = dr.Item("mstname")
                txtMstcode.Text = dr.Item("mstcode")
                MaskedTextBox1.Text = Format(dr.Item(10), "dd-MM-yyyy")
                MaskedTextBox2.Text = Format(dr.Item(11), "dd-MM-yyyy")
                txtPanno.Text = dr.Item(12)
                txtemailid.Text = dr.Item(13)
                txtmobno.Text = dr.Item(14)
                txthomeno.Text = dr.Item(15)
                txtcopyacname.Text = txtAcname.Text
                Try
                    txtBillPre.Text = dr.Item("BillSr")
                Catch ex As Exception

                End Try
                Try
                    txtBillPlace.Text = dr.Item("MaxBill")
                Catch ex As Exception

                End Try
                Try
                    txtPreyn.Text = dr.Item("SRYN")
                Catch ex As Exception

                End Try
            End While
            dr.Close()
            dr = myconselect("tblSH", txtShead.Text, "Shead")
            While dr.Read
                txtScode.Text = dr.Item("Scode")
                txtMhead.Text = dr.Item("Mhead")
            End While
            dr.Close()
            dr = myconselect("tblMH", txtMhead.Text, "Mhead")
            While dr.Read
                txtHead.Text = dr.Item("ASD")
            End While
            dr.Close()
            GroupBox1.Enabled = True
            comBook.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub DG1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellClick
        Try
            'MsgBox(e.RowIndex)
            If e.RowIndex = -1 Then
                findcol = e.ColumnIndex
                frmAccountSearch.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            Dim dr As SqlDataReader
            '    MsgBox(i.Item(0).RowIndex)
            txtAccode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            dr = myconselect("tblAccount", txtAccode.Text, "ACCode")
            While dr.Read
                txtAcname.Text = dr.Item(1)
                txtShead.Text = dr.Item(2)
                txtadd1.Text = dr.Item(3)
                txtadd2.Text = dr.Item(4)
                txtPlace.Text = dr.Item(5)
                txtPin.Text = dr.Item(6)
                txtState.Text = dr.Item(7)
                txtGstno.Text = dr.Item(8)
                txtCstno.Text = dr.Item(9)
                txtMarka.Text = dr.Item("marko")
                txtMst.Text = dr.Item("mstname")
                txtMstcode.Text = dr.Item("mstcode")
                MaskedTextBox1.Text = Format(dr.Item(10), "dd-MM-yyyy")
                MaskedTextBox2.Text = Format(dr.Item(11), "dd-MM-yyyy")
                txtPanno.Text = dr.Item(12)
                txtemailid.Text = dr.Item(13)
                txtmobno.Text = dr.Item(14)
                txthomeno.Text = dr.Item(15)
                comBook.Text = dr.Item(16)
                txtcopyacname.Text = txtAcname.Text
                txtGroup.Text = dr.Item("pgroup")
                txtBillPre.Text = dr.Item("BillSr")
                txtBillPlace.Text = dr.Item("MaxBill")
                txtPreyn.Text = dr.Item("SRYN")
            End While
            dr.Close()
            dr = myconselect("tblSH", txtShead.Text, "Shead")
            While dr.Read
                txtScode.Text = dr.Item("Scode")
                txtMhead.Text = dr.Item("Mhead")
            End While
            dr.Close()
            dr = myconselect("tblMH", txtMhead.Text, "Mhead")
            While dr.Read
                txtHead.Text = dr.Item("ASD")
            End While
            dr.Close()
            listShead.Visible = False
            listState.Visible = False
        Catch ex As Exception
            '      MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShead.TextChanged

    End Sub
    Private Sub defval()
        If txtadd1.Text.Trim.Length = 0 Then
            txtadd1.Text = "0"
        End If
        If txtadd2.Text.Trim.Length = 0 Then
            txtadd2.Text = "0"
        End If
        If txtadd1.Text.Trim.Length = 0 Then
            txtadd1.Text = "0"
        End If
        If txtadd2.Text.Trim.Length = 0 Then
            txtadd2.Text = "0"
        End If
        If txtPlace.Text.Trim.Length = 0 Then
            txtPlace.Text = "0"
        End If
        If txtPin.Text.Trim.Length = 0 Then
            txtPin.Text = "0"
        End If
        If txtState.Text.Trim.Length = 0 Then
            txtState.Text = "0"
        End If
        If txtGstno.Text.Trim.Length = 0 Then
            txtGstno.Text = "0"
        End If
        If txtCstno.Text.Trim.Length = 0 Then
            txtCstno.Text = "0"
        End If
        If txtPanno.Text.Trim.Length = 0 Then
            txtPanno.Text = "0"
        End If
        If txtemailid.Text.Trim.Length = 0 Then
            txtemailid.Text = "0"
        End If
        If txtmobno.Text.Trim.Length = 0 Then
            txtmobno.Text = "0"
        End If
        If txthomeno.Text.Trim.Length = 0 Then
            txthomeno.Text = "0"
        End If
        '  MsgBox(MaskedTextBox1.Text)
        If MaskedTextBox1.Text.Trim.Length = 4 Then
            MaskedTextBox1.Text = "01-04-2011"
        End If
        If MaskedTextBox2.Text.Trim.Length = 4 Then
            MaskedTextBox2.Text = "01-04-2011"
        End If
        If txtBillPre.Text.Length = 0 Then
            txtBillPre.Text = "0"
        End If
        If txtBillPlace.Text.Length = 0 Then
            txtBillPlace.Text = "0"
        End If
        If txtPreyn.Text.Length = 0 Then
            txtPreyn.Text = "0"
        End If
        If txtMstcode.Text.Length = 0 Then
            txtMstcode.Text = "0"
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            '   MsgBox("het")
            defval()
            If txtMst.Text.Trim.Length = 0 Then
                txtMst.Text = "-"
                txtMstcode.Text = "0"
            End If
            If txtShead.Text.Trim.Length = 0 Then
                MsgBox("Schedule  Head can not be blank")
                txtShead.Focus()
                GoTo en
            End If
            If txtAcname.Text.Trim.Length = 0 Then
                MsgBox("A/C Name can not be blank")
                txtAcname.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim dat1 As New Date
                dat1 = (MaskedTextBox1.Text.ToString)
                Dim dat2 As New Date
                dat2 = (MaskedTextBox2.Text.ToString)
                Dim mcode As String
                dr = myconselect("tblMH", txtMhead.Text, "Mhead")
                While dr.Read
                    mcode = dr.Item("MCode")
                End While
                dr.Close()

                Dim a() As String = {txtAccode.Text, txtAcname.Text.ToUpper, txtShead.Text, txtadd1.Text, txtadd2.Text, txtPlace.Text, txtPin.Text, txtState.Text, txtGstno.Text, txtCstno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtPanno.Text, txtemailid.Text, txtmobno.Text, txthomeno.Text, comBook.Text, txtScode.Text, mcode, txtGroup.Text, txtBillPre.Text, txtBillPlace.Text, txtPreyn.Text, txtMst.Text, txtMstcode.Text, txtMarka.Text}
                If duplicate("tblAccount", "ACName", txtAcname) Then
                    MsgBox("Account Name already exists")
                    txtAcname.Focus()
                    GoTo en
                Else
                End If


                myinsert(a, "tblAccount")
                Label12.Visible = True
                Timer1.Enabled = True

                myfilldatagrid(dg1, "tblAccount")
                dg1.Item(0, dg1.RowCount - 1).Selected = True
                dg1.Refresh()
                If Form3.newac = 1 Then
                    Form3.txtAcDr.Text = txtAcname.Text
                    Form3.txtAcDr.Focus()
                    Form3.txtAccodedr.Text = txtAccode.Text
                    Form3.dgAcm.Visible = False
                    Form3.Show()
                    Form3.txtAcCr.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf Form3.newac = 2 Then
                    Form3.Show()
                    Form3.txtAcCr.Text = txtAcname.Text
                    Form3.txtAccodecr.Text = txtAccode.Text
                    Form3.dgAcm.Visible = False
                    Form3.txtAcCr.Focus()
                    Form3.comPurtype.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmSale.newac = 1 Then
                    frmSale.txtAcDr.Text = txtAcname.Text
                    frmSale.txtAcDr.Focus()
                    frmSale.txtAccodedr.Text = txtAccode.Text
                    frmSale.dgacm.Visible = False
                    frmSale.Show()
                    frmSale.txtAcCr.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmSale.newac = 2 Then
                    frmSale.Show()
                    frmSale.txtAcCr.Text = txtAcname.Text
                    frmSale.txtAccodeCr.Text = txtAccode.Text
                    frmSale.dgacm.Visible = False
                    frmSale.txtAcCr.Focus()
                    frmSale.comSaleType.Focus()
                    CLOSECHECK = 0
                    Me.Close()

                ElseIf frmOpeningMaster.acbalance = 1 Then
                    frmOpeningMaster.Show()
                    frmOpeningMaster.txtAcname.Text = txtAcname.Text
                    frmOpeningMaster.dgacm.Visible = False
                    frmOpeningMaster.txtAmount.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmBank.bankac = 1 Then
                    frmBank.Show()
                    frmBank.txtAcName.Text = txtAcname.Text
                    frmBank.dgacm.Visible = False
                    frmBank.txtChqno.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmBankRecipt.bankrac = 1 Then
                    frmBankRecipt.Show()
                    frmBankRecipt.txtAcname.Text = txtAcname.Text
                    frmBankRecipt.dgacm.Visible = False
                    frmBankRecipt.txtChqNo.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmJour.jourac = 1 Then
                    frmJour.Show()
                    frmJour.TextBox4.Text = txtAcname.Text
                    '   frmjour.dgacm.Visible = False
                    '  frmBankRecipt.TextBox6.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmoub.acbalance = 1 Then
                    frmoub.Show()
                    frmoub.txtAcname.Text = txtAcname.Text
                    frmoub.dgacm.Visible = False
                    frmoub.txtAmount.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmlotr.lotracm = 1 Then
                    frmlotr.Show()
                    frmlotr.txtAcname.Text = txtAcname.Text
                    frmlotr.dgacm.Visible = False
                    frmlotr.masklotno.Focus()
                    frmlotr.lotracm = 0
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf FRMChalan.newac = 2 Then
                    FRMChalan.Show()
                    FRMChalan.TextBox2.Text = txtAcname.Text
                    FRMChalan.dgacm.Visible = False
                    FRMChalan.TextBox3.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf FRMChalan.newac = 2 Then
                    FRMChalan.Show()
                    FRMChalan.TextBox2.Text = txtAcname.Text
                    FRMChalan.dgacm.Visible = False
                    FRMChalan.TextBox5.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmLotNew.lotracm = 1 Then
                    frmLotNew.Show()
                    frmLotNew.txtAcname.Text = txtAcname.Text
                    frmLotNew.txtAccode.Text = txtAccode.Text
                    frmLotNew.dgacm.Visible = False
                    frmLotNew.txtAcname.Focus()
                    frmLotNew.masklotno.Focus()
                    CLOSECHECK = 0
                    Me.Close()


                End If
                txtAcname.Clear()
                '   TextBox2.Clear()
                txtadd1.Clear()
                txtadd2.Clear()
                txtPlace.Clear()
                txtPin.Clear()
                txtState.Clear()
                txtGstno.Clear()
                txtCstno.Clear()
                txtPanno.Clear()
                txtemailid.Clear()
                txtmobno.Clear()
                txthomeno.Clear()
                txtAccode.Clear()
                '  TextBox15.Clear()
                ' TextBox16.Clear()
                'TextBox17.Clear()
                txtcopyacname.Clear()
                '    ComboBox1.Clear()
                TextBox20.Clear()
                ' TextBox21.Clear()
                MaskedTextBox1.Clear()
                MaskedTextBox2.Clear()
                comBook.Focus()
                myserialno("tblAccount", txtAccode, "ACCode")
            ElseIf check = 2 Then
                'MsgBox("het")
                ' MsgBox("desai")
                Dim dat1 As New Date
                dat1 = CDate(MaskedTextBox1.Text.ToString)
                Dim dat2 As New Date
                dat2 = CDate(MaskedTextBox2.Text.ToString)
                Dim mcode As String
                dr = myconselect("tblMH", txtMhead.Text, "Mhead")
                While dr.Read
                    mcode = dr.Item("MCode")
                End While
                dr.Close()

                Dim a() As String = {txtAccode.Text, txtAcname.Text.ToUpper, txtShead.Text, txtadd1.Text, txtadd2.Text, txtPlace.Text, txtPin.Text, txtState.Text, txtGstno.Text, txtCstno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtPanno.Text, txtemailid.Text, txtmobno.Text, txthomeno.Text, comBook.Text, txtScode.Text, mcode, txtGroup.Text, txtBillPre.Text, txtBillPlace.Text, txtPreyn.Text, txtMst.Text, txtMstcode.Text, txtMarka.Text}
                If txtAcname.Text.Trim <> txtcopyacname.Text.Trim Then
                    If (duplicate("tblAccount", "ACName", txtAcname)) = True Then
                        MsgBox("Record already exists")
                        txtShead.Focus()
                        GoTo en
                    End If
                End If
                If txtAcname.Text.Trim <> txtcopyacname.Text.Trim Then
                    updateaccount()

                End If
                myupdate("tblAccount", a, "ACCode", txtAccode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = dg1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(dg1, "tblAccount")
                Label17.Visible = True
                Timer1.Enabled = True
                dg1.Item(coli, rowi).Selected = True
                comBook.Focus()
            End If
            myfilldatagrid(dg1, "tblAccount")
en:

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub updateaccount()
        Try
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("update advpmt set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update adv set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update aujvmst set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update bankt set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update salec1 set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update salec1 set name='" & txtAcname.Text & "' where name='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update salec1 set namecr='" & txtAcname.Text & "' where namecr='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update salesc set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update salesc set name='" & txtAcname.Text & "' where name='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update salesc set namecr='" & txtAcname.Text & "' where namecr='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update saltax set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update saltax set poname='" & txtAcname.Text & "' where poname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update taxmst set poname='" & txtAcname.Text & "' where poname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update saltax set poname='" & txtAcname.Text & "' where poname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblbank set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblbank set name='" & txtAcname.Text & "' where name='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblbank set namecr='" & txtAcname.Text & "' where namecr='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblcheckacname set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tbljour set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblLedg set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tbllotr set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblOPEN set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tbloub set acname='" & txtAcname.Text & "' where acname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tbloub set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblPurchase set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblPurchase set name='" & txtAcname.Text & "' where name='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblPurchase set namecr='" & txtAcname.Text & "' where namecr='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblPurchaseDetail set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblPurchaseDetail set name='" & txtAcname.Text & "' where name='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblPurchaseDetail set namecr='" & txtAcname.Text & "' where namecr='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblpurtax set bkname='" & txtAcname.Text & "' where bkname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblpurtax set poname='" & txtAcname.Text & "' where poname='" & txtcopyacname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShead.Leave
        Try
            Dim dr As SqlDataReader
            dr = myconselect("tblSH", txtShead.Text, "Shead")
            While dr.Read
                txtScode.Text = dr.Item("Scode")
                txtMhead.Text = dr.Item("Mhead")
            End While
            dr.Close()
            dr = myconselect("tblMH", txtMhead.Text, "Mhead")
            While dr.Read
                txtHead.Text = dr.Item("ASD")
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 1
        If timercount > 1 Then
            Label17.Visible = False
            Label12.Visible = False
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub TextBox13_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txthomeno.KeyDown
        If e.KeyCode = Keys.Enter Then
            If comBook.Text.ToUpper = "Sales".ToUpper Then
                txtBillPre.Focus()
            ElseIf comBook.Text.ToUpper = "other".ToUpper Then
                butSave.Focus()
            Else
                butSave.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            txtmobno.Focus()
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox12_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmobno.Leave
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthomeno.TextChanged

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        GroupBox1.Enabled = True
        'frmAccountSearch.Show()
        tv = ""

        GroupBox2.Visible = True
        txtfind.TabIndex = 0
        GroupBox2.TabIndex = 0

        GroupBox2.Focus()
        txtfind.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Try
            If Form3.newac = 1 Then
                Form3.txtAcDr.Focus()
                Form3.Show()
                Me.Close()
            ElseIf Form3.newac = 2 Then
                Form3.Show()
                Form3.txtAcCr.Focus()
                Me.Close()
            ElseIf frmSale.newac = 1 Then
                frmSale.txtAcDr.Focus()
                frmSale.Show()
                Me.Close()
            ElseIf frmSale.newac = 2 Then
                frmSale.Show()
                frmSale.txtAcCr.Focus()
                Me.Close()
            ElseIf frmOpeningMaster.acbalance = 1 Then
                frmOpeningMaster.Show()
                frmOpeningMaster.txtAmount.Focus()
                Me.Close()
            End If
            frmAccountSearch.Close()
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    End Sub
    Private Sub TextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShead.KeyUp
        myAutoComplete(txtShead, listShead, "tblSH", "Shead")
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShead.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtShead.Text.Trim.Length = 0 Then
                TextBox22.Text = ""
                PictureBox1.BringToFront()
                TextBox22.Focus()
                GoTo en
            End If
            connect()
            cmd = New SqlCommand("Select * from tblSH where alias='" & txtShead.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtShead.Text = dr.Item("Shead")
                txtGroup.Focus()
                dr.Close()
                listShead.Visible = False
                GoTo en
            End While
            dr.Close()
            close1()
            If listShead.Items.Count <> 0 Then
                txtShead.Text = listShead.Items(0).ToString
                listShead.Visible = False
                txtGroup.Focus()
            Else
                If MsgBox("Schedule Head not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    accheck = 1
                    Me.Hide()
                    frmSHMaster.Show()
                    frmSHMaster.GroupBox1.Focus()
                    frmSHMaster.TextBox1.Focus()

                Else
                    txtShead.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            listShead.SelectedIndex = 0
            listShead.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            listShead.Visible = False
            txtAcname.Focus()
        ElseIf e.KeyCode = Keys.F10 Then
            e.Handled = True
            '    DataGridView1.BringToFront()
            '   DataGridView1.Visible = True
            '  Dim da As New SqlDataAdapter
            ' da = New SqlDataAdapter("Select * from tblSH order by Mhead", cn)
            ' da.Fill(ds)
            'DataGridView1.DataSource = ds.Tables(0)
            frmdissh.Show()
        End If
en:
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles listShead.KeyDown
        ' Me.KeyPreview = False
        If e.KeyCode = Keys.Enter Then
            txtShead.Text = listShead.SelectedItem.ToString
            listShead.Visible = False
            txtShead.Focus()
            txtGroup.Focus()
            '    Me.KeyPreview = True
        End If
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlace.KeyDown
        If e.KeyCode = Keys.Enter Then
            If listState.Items.Count <> 0 Then
                txtPlace.Text = listState.Items(0).ToString
                listState.Visible = False
                txtPin.Focus()
            Else
                If MsgBox("Place not exits you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    plcheck = 1
                    Me.Hide()
                    frmPlaceMaster.Show()
                    frmPlaceMaster.GroupBox1.Focus()
                    frmPlaceMaster.txtPlace.Focus()
                Else
                    txtPlace.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            tb = 5
            Try
                listState.SelectedIndex = 0
                listState.Focus()

            Catch ex As Exception

            End Try
        ElseIf e.KeyCode = Keys.Up Then
            listState.Visible = False
            txtadd2.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlace.KeyUp
        myAutoComplete(txtPlace, listState, "tblPlace", "PLName")
    End Sub
    Private Sub ListBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles listState.KeyDown
        Me.KeyPreview = False
        If e.KeyCode = Keys.Enter Then
            If tb = 5 Then
                txtPlace.Text = listState.SelectedItem.ToString
                listState.Visible = False
                txtPin.Focus()

            ElseIf tb = 7 Then
                txtState.Text = listState.SelectedItem.ToString
                listState.Visible = False
                txtState.Focus()
                txtGstno.Focus()

            End If

        End If
    End Sub

    Private Sub TextBox7_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtState.KeyUp
        myAutoComplete(txtState, listState, "tblState", "STName")
    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtState.KeyDown
        If e.KeyCode = Keys.Enter Then
            If listState.Items.Count <> 0 Then
                txtState.Text = listState.Items(0).ToString
                listState.Visible = False
                txtGstno.Focus()
            Else
                If MsgBox("State not exits you want to create it", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    stcheck = 1
                    frmStateMaster.Show()
                    frmStateMaster.GroupBox1.Focus()
                    frmStateMaster.txtState.Focus()
                    Me.Hide()
                Else
                    txtState.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            tb = 7
            listState.SelectedIndex = 0
            listState.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtPin.Focus()
            listState.Visible = False
        End If
    End Sub

    Private Sub TextBox7_TabStopChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtState.TabStopChanged

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub combobox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtAcname.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtadd1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtadd2.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtGroup.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtadd2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPlace.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtadd1.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPin.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtState.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtPlace.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGstno.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox1.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtState.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCstno.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtGstno.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCstno.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            MaskedTextBox1.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPanno.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtCstno.Focus()
        End If
    End Sub

    Private Sub TextBox10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPanno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtemailid.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtemailid.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtmobno.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtPanno.Focus()
        End If

    End Sub

    Private Sub TextBox12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmobno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txthomeno.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtemailid.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtShead.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            comBook.Focus()
        End If
    End Sub

    Private Sub TextBox21_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGroup.KeyUp
        myAutoComplete(txtGroup, listGroup, "tblPGroup", "GName")
    End Sub

    Private Sub TextBox21_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGroup.KeyDown
        If e.KeyCode = Keys.Enter Then
            If listGroup.Items.Count <> 0 Then
                txtGroup.Text = listGroup.Items(0).ToString
                listGroup.Visible = False
                '        TextBox3.Focus()
                txtMarka.Focus()
            Else
                If MsgBox("Group not exits you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    groupcheck = 1
                    frmGroupMaster.Show()
                    frmGroupMaster.GroupBox1.Focus()
                    frmGroupMaster.TextBox2.Focus()
                    Me.Hide()
                Else
                    txtGroup.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            listGroup.Focus()
            listGroup.SelectedIndex = 0
        ElseIf e.KeyCode = Keys.Up Then
            listGroup.Visible = False
            txtShead.Focus()
        End If
    End Sub

    Private Sub ListBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles listGroup.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGroup.Text = listGroup.SelectedItem.ToString
            '     TextBox3.Focus()
            txtMarka.Focus()
            listGroup.Visible = False
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            If e.KeyCode = Keys.Back Then
                e.Handled = True
                txtShead.Text = DataGridView1.Item(DataGridView1.Columns.Count - 1, DataGridView1.SelectedCells.Item(0).RowIndex).Value
                DataGridView1.Visible = False
                txtShead.Focus()

            End If

        Catch ex As Exception
            txtShead.Focus()
        End Try
    End Sub

    Private Sub TextBox22_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox22.KeyDown

    End Sub

    Private Sub TextBox22_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox22.KeyUp
        If TextBox22.Text.Length = 1 Then
            frmdissh.Close()
            frmdissh.Show()
            PictureBox1.SendToBack()
            TextBox22.Clear()
        End If
    End Sub

    Private Sub TextBox24_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillPlace.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPreyn.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtBillPre.Focus()
        End If
    End Sub

    Private Sub TextBox23_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillPre.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBillPlace.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txthomeno.Focus()
        End If
    End Sub

    Private Sub dg1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub TextBox24_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBillPlace.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub TextBox24_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillPlace.KeyUp
    End Sub

    Private Sub TextBox25_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPreyn.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        End If
    End Sub

    Private Sub TextBox25_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreyn.Leave
        If txtPreyn.Text.ToUpper = "YES" Or txtPreyn.Text.ToUpper = "NO" Then
        Else
            MsgBox("Select Yes Or No")
        End If
    End Sub

    Private Sub TextBox26_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMst.KeyUp
        myAutoComplete(txtMst, listMst, "Mst", "Mst")
    End Sub

    Private Sub TextBox26_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMst.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If listMst.Items.Count <> 0 Then
                    txtMst.Text = listMst.Items(0).ToString
                    listMst.Visible = False
                    txtadd1.Focus()
                Else
                    If MsgBox("Mst not exits You want to create New", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        mstcheck = 1
                        frmMst.Show()
                        Me.Hide()
                    Else
                        txtMst.Focus()
                    End If
                End If
            ElseIf e.KeyCode = Keys.Down Then
                listMst.Focus()
                listMst.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox26_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMst.Leave
        connect()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select * from mst where mst='" & txtMst.Text & "'", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            txtMstcode.Text = dr.Item("mstcode")
        End While
        dr.Close()
        close1()
    End Sub

    Private Sub TextBox28_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarka.KeyUp
        myAutoComplete(txtMarka, listMarka, "mrkmst", "marka")
    End Sub

    Private Sub TextBox28_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarka.KeyDown
        If e.KeyCode = Keys.Enter Then
            If listMarka.Items.Count <> 0 Then
                txtMarka.Text = listMarka.Items(0).ToString
                txtMst.Focus()
                listMarka.Visible = False
            Else
                If MsgBox("Marka not exisrs you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    markacheck = 1
                    Me.Hide()
                    frmMarko.Show()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            Try
                listMarka.SelectedIndex = 0
                listMarka.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ComboBox1_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comBook.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcname.Focus()
        End If
    End Sub

    Private Sub TextBox20_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox20.KeyDown

    End Sub

    Private Sub ListBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles listMst.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtMst.Text = listMst.SelectedItem.ToString
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("select * from mst", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    txtMstcode.Text = dr.Item(0)
                End While
                dr.Close()
                close1()
                listMst.Visible = False
                txtadd1.Focus()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub ListBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles listMarka.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtMarka.Text = listMarka.SelectedItem.ToString
                txtMst.Focus()
                listMarka.Visible = False
                '  MsgBox("d")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub dg1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg1.Enter
        listShead.Visible = False
        listState.Visible = False
        listGroup.Visible = False
        listMst.Visible = False
        listMarka.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblLedg where accode=" & txtAccode.Text, cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("There are transaction available for this account you cannot delete account")
                dr.Close()
                GoTo en
            Else
                dr.Close()
            End If
            If MsgBox("You want to delete this Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cmd = New SqlCommand("delete from tblAccount where accode=" & txtAccode.Text, cn)
                cmd.ExecuteNonQuery()
                MsgBox("deleted")
            End If
            close1()

            myfilldatagrid(dg1, "tblAccount")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrint.Click
        frmprintaccount.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        GroupBox2.Visible = False

    End Sub

    Private Sub TextBox19_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtfind.KeyDown
        If e.KeyCode = Keys.Enter Then
            butOk.Focus()
        End If
    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        GroupBox2.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (txtfind.Text = tv) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv = txtfind.Text
        For i = temp1 To dg1.Rows.Count - 1
            For j = temp2 To dg1.ColumnCount - 1
                If (dg1.Item(j, i).Value.ToString.ToUpper.Contains(txtfind.Text.ToUpper)) Then
                    Try
                        dg1.Item(j, i).Selected = True
                    Catch ex As Exception

                    End Try

                    temp2 = j + 1
                    '    check = 1
                    GoTo en
                End If


a:

            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub


    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPin.KeyPress
        Try
            onlyNumbers2(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPanno.TextChanged

    End Sub

    Private Sub butAdd_Enter(sender As Object, e As EventArgs) Handles butPrint.Enter, butFind.Enter, butExit.Enter, butEdit.Enter, butDelete.Enter, butAdd.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub butAdd_Leave(sender As Object, e As EventArgs) Handles butPrint.Leave, butFind.Leave, butExit.Leave, butEdit.Leave, butDelete.Leave, butAdd.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub butAdd_MouseLeave(sender As Object, e As EventArgs) Handles butPrint.MouseLeave, butFind.MouseLeave, butExit.MouseLeave, butEdit.MouseLeave, butDelete.MouseLeave, butAdd.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub butAdd_MouseHover(sender As Object, e As EventArgs) Handles butPrint.MouseHover, butFind.MouseHover, butExit.MouseHover, butEdit.MouseHover, butDelete.MouseHover, butAdd.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub
End Class