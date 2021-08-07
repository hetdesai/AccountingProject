Imports System.Data.SqlClient
Public Class frmlotr
    Dim tb As Integer
    Public mstcheck As Integer = 0
    Public lotracm As Integer = 0
    Public itcheck As Integer = 0
    Public markacheck As Integer = 0
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim tv1 As String
    Dim CURRENTROW As Integer = 0
    Dim columncheck As Integer
    Dim TIMERCOUNT As Integer = 0
    Dim curentrow As Integer = 0
    Private Sub MaskedTextBox2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskDate.Enter
        maskDate.SelectionLength = 0
        maskDate.SelectionStart = 0
    End Sub
    Private Sub gfocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAcname.GotFocus, txtAccode.GotFocus, txtTotalwidth.GotFocus, txtVrNo1.GotFocus, txtVrNo2.GotFocus, txtMst.GotFocus, txtITNAME.GotFocus, txtIchno.GotFocus, txtITCODE.GotFocus, txtWidth.GotFocus, txtDesc2.GotFocus, txttotalpcs.GotFocus, masklotno.GotFocus, maskDate.GotFocus, txtTotalwidth.GotFocus, txtVrNo1.GotFocus, txtVrNo2.GotFocus, txtLrNo.GotFocus, txtLotno1.GotFocus, txtWeight.GotFocus, txtDesc.GotFocus, txtMarka.GotFocus, txtBroker.GotFocus, txtBrCode.GotFocus
        sender.BackColor = Color.Yellow
    End Sub
    Private Sub gotf(ByVal sender As Object, ByVal e As EventArgs) Handles maskDate.GotFocus
        maskDate.SelectionLength = 0
        maskDate.SelectionStart = 0
    End Sub

    Private Sub TextBox17_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarka.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox2.Items.Count > 0 Then
                txtMarka.Text = ListBox2.Items(0).ToString
            Else
                If MsgBox("marka not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    markacheck = 1
                    Me.Hide()
                    frmMarko.Show()
                    GoTo en
                End If
            End If
            If Label12.Text = "ADD MODE" Then
                DG1.Rows.Clear()
                DG1.Rows.Add()
                If e.KeyCode = Keys.Enter Then
                    DG1.Item(0, 0).Value = 1
                    DG1.Item(1, 0).Selected = True
                    DG1.Focus()
                End If
            ElseIf Label12.Text = "EDIT MODE" Then
                DG1.Focus()
            Else
            End If
        ElseIf e.KeyCode = Keys.Up Then
            txtWeight.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            Try
                ListBox2.SelectedIndex = 0
                ListBox2.Focus()
            Catch ex As Exception

            End Try


            GoTo en


        End If
        ListBox2.Visible = False
en:
    End Sub
    Private Sub lfocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAcname.LostFocus, txtAccode.LostFocus, txtTotalwidth.LostFocus, txtVrNo1.LostFocus, txtVrNo2.LostFocus, txtMst.LostFocus, txtITNAME.LostFocus, txtIchno.LostFocus, txtITCODE.LostFocus, txtWidth.LostFocus, txtDesc2.LostFocus, txttotalpcs.LostFocus, masklotno.LostFocus, maskDate.LostFocus, txtTotalwidth.LostFocus, txtVrNo1.LostFocus, txtVrNo2.LostFocus, txtLrNo.LostFocus, txtLotno1.LostFocus, txtWeight.LostFocus, txtDesc.LostFocus, txtMarka.LostFocus, txtBroker.LostFocus, txtBrCode.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maskDate.Leave
        Try

        Catch ex As Exception
            MsgBox("Enter Proper Date")
            maskDate.Focus()
        End Try
    End Sub

    Private Sub frmlotr_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("DO YOU WANT TO EXIT?", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        ElseIf e.KeyCode = Keys.W AndAlso e.Control Then
            txtDesc.Focus()
        End If
    End Sub
    Private Sub frmlotr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '    MessageBox.Show(Button1.BackColor.ToArgb.ToString )
        '   Me.BackColor = Application.
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        dg2.Focus()
        dg2.TabIndex = 0
        'GroupBox2.TabIndex = 0
        txtVrNo1.Text = acycode & "/"
        txtLotno1.Text = acycode & "/"
        '  myfilldatagrid(dg2, "tblLotr")
        connect()
        Dim DA As New SqlDataAdapter
        Dim DS As New DataSet
        DA = New SqlDataAdapter("SELECT VrNo,Date,IchNo,Lotno,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR order by convert(INT,substring(vrno,4,LEN(vrno)-3))", cn)
        DA.Fill(DS)
        dg2.DataSource = DS.Tables(0)

        dg2.Columns(0).Visible = False
        dg2.AutoResizeColumns()


        Try
            dg2.Item(1, dg2.RowCount - 1).Selected = True
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try
        close1()
        'DG1.Columns(1).DefaultCellStyle.Format = "f2"
        dg2.Focus()
        Try
            ' dg2.Item(0, 0).Selected = True
        Catch ex As Exception
        End Try
    End Sub
    Private Function maxlotno() As Integer
        connect()
        Dim max As Integer = 0
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("Select LotNo from tblLotr", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        While dr.Read
            If max < dr.Item(0).ToString.Substring(3, 6).ToString Then
                max = dr.Item(0).ToString.Substring(3, 6).ToString
            End If
        End While
        Return max + 1
        dr.Close()
        close1()
    End Function
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

    Private Sub MaskedTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskDate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtIchno.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter Proper Ddate")
        End Try
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIchno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtAcname.Focus()
            ElseIf e.KeyCode = Keys.Up Then
                maskDate.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyUp
        'myAutoComplete(TextBox1, ListBox1, "tblAccount", "ACName")
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter(acm(txtAcname.Text), cn)
            da.Fill(ds)
            dgacm.DataSource = ds.Tables(0)
            dgacm.Visible = True
            dgacm.Top = txtAcname.Top + 22
            dgacm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgacm.Rows.Count > 0 Then
                txtAcname.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                dgacm.Visible = False
                masklotno.Focus()
            Else
                If MsgBox("Account not exists You want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    lotracm = 1
                    frmACMaster.Show()
                    Me.Hide()
                    GoTo en
                Else
                    txtAcname.Focus()
                End If

            End If
        ElseIf e.KeyCode = Keys.Down Then
            If dgacm.RowCount > 0 Then
                dgacm.Item(1, 0).Selected = True
                dgacm.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            txtIchno.Focus()
        End If
en:
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles masklotno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCheck.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAcname.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMst.KeyDown
        Try

        
        If e.KeyCode = Keys.Enter Then
            If ListBox1.Items.Count > 0 Then
                txtMst.Text = ListBox1.Items(0).ToString
                ListBox1.Visible = False
                txtITNAME.Focus()
            Else
                If MsgBox("Mst Not exists You want to add new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    mstcheck = 1
                    Me.Hide()
                    frmMst.Show()
                End If
                GoTo en
            End If
        ElseIf e.KeyCode = Keys.Down Then
            ListBox1.SelectedIndex = 0
            ListBox1.Focus()
            tb = 3
        ElseIf e.KeyCode = Keys.Up Then
            masklotno.Focus()
            End If
        Catch ex As Exception

        End Try
en:
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtITNAME.KeyUp
        myAutoComplete(txtITNAME, ListBox1, "tblItem", "ITName")
        Try
            ListBox1.Visible = True

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cn.Open()
            cmd = New SqlCommand("Select ITNAME from tblItem where ITNAME like '" & txtITNAME.Text & "%' and (ITTYPE='SALES' or ITTYPE='GREY')", cn)
            dr = cmd.ExecuteReader
            ListBox1.Items.Clear()
            While dr.Read
                ListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            ListBox1.Left = txtITNAME.Left
            ListBox1.Top = txtITNAME.Top + 25
            ListBox1.Width = txtITNAME.Width
            ListBox1.Visible = True
            ListBox1.BringToFront()
            cn.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtITNAME.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox1.Items.Count > 0 Then
                txtITNAME.Text = ListBox1.Items(0).ToString
                ListBox1.Visible = False
                txtWidth.Focus()
            Else
                If MsgBox("Item not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    itcheck = 1
                    Me.Hide()
                    frmITMaster.Show()
                Else
                    txtITNAME.Focus()
                End If
                '    GoTo en
            End If
        ElseIf e.KeyCode = Keys.Down Then
            ListBox1.SelectedIndex = 0
            ListBox1.Focus()
            tb = 4
        ElseIf e.KeyCode = Keys.Up Then
            txtMst.Focus()
        End If
en:
    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWidth.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLrNo.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtITNAME.Focus()
        End If
    End Sub
    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesc2.KeyDown
        If e.KeyCode = Keys.Up Then
            txtMarka.Focus()
        End If
    End Sub
    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb = 1 Then
                txtAcname.Text = ListBox1.SelectedItem.ToString
                txtAcname.Focus()
                masklotno.Focus()
            ElseIf tb = 3 Then
                txtMst.Text = ListBox1.SelectedItem.ToString
                txtMst.Focus()
                txtITNAME.Focus()
            ElseIf tb = 4 Then
                txtITNAME.Text = ListBox1.SelectedItem.ToString
                txtITNAME.Focus()
                txtWidth.Focus()
            End If
            ListBox1.Visible = False
        End If
    End Sub
    Private Sub TextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMst.KeyUp
        myAutoComplete(txtMst, ListBox1, "Mst", "Mst")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        masklotno.ReadOnly = False
        GroupBox1.TabIndex = 0
        Clearall()
        maxVrNo(txtVrNo2, "tblLotr")
        maskDate.Focus()

        Label12.Text = "ADD MODE"
        ' maskDate.Text = Format(Date.Today, "dd-MM-yyyy")
        maskDate.SelectionStart = 0
        maskDate.SelectionLength = 0

        connect()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select max(convert(int,ichno)) from tblLotr", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            Try
                txtIchno.Text = Val(dr.Item(0)) + 1
            Catch ex As Exception
                txtIchno.Text = 1
            End Try

        End While
        dr.Close()
        Dim strf As String
        cmd = New SqlCommand("Select value from tblSetup where book='LOTR' and Operation='NEXTLOTNO'", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            strf = dr.Item(0)
        End While
        dr.Close()
        If strf = "MAX" Then
            cmd = New SqlCommand("Select max(convert(int,lotn)) from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Try
                    masklotno.Text = Val(dr.Item(0)) + 1
                Catch ex As Exception
                    masklotno.Text = 1
                End Try
            End While
            dr.Close()
            close1()
        Else
            connect()
            Dim tb As New TextBox
            maxVrNo(tb, "tblLotr")
            cmd = New SqlCommand("Select convert(int,lotn),lotc from tblLotr where vrno='" & acycode & "/" & Val(tb.Text) - 1 & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Try
                    masklotno.Text = Val(dr.Item(0)) + 1 & dr.Item(1)
                Catch ex As Exception
                    masklotno.Text = 1
                End Try
            End While
            dr.Close()
            close1()
        End If
    End Sub
    Private Sub Clearall()
        '   TextBox1.Clear()
        '  TextBox2.Clear()
        '  txtMst.Clear()
        ' txtITNAME.Clear()
        '  txtIchno.Clear()
        ' txtITCODE.Clear()
        '  TextBox7.Clear()
        '  txtDesc2.Clear()
        txttotalpcs.Text = 0
        txtTotalwidth.Text = 0.0
        '   TextBox11.Clear()
        txtVrNo2.Clear()
        masklotno.Clear()
        '  MaskedTextBox2.Clear()
        DG1.Rows.Clear()
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcname.LostFocus
        Dim dr As SqlDataReader
        dr = myconselect("tblAccount", txtAcname.Text, "ACName")
        While dr.Read
            txtAccode.Text = dr.Item("ACCode")
        End While
        dr.Close()
    End Sub
    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtITNAME.LostFocus
        Dim dr As SqlDataReader
        dr = myconselect("tblItem", txtITNAME.Text, "ITName")
        While dr.Read
            txtITCODE.Text = dr.Item("ITCode")
        End While
        dr.Close()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
    Private Sub DG1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellValidated
        Try
            If e.ColumnIndex = 1 Then
                DG1.Item(1, e.RowIndex).Value = Convert.ToDecimal(DG1.Item(1, e.RowIndex).Value)
                txtTotalwidth.Text = ""
                txttotalpcs.Text = "0"

                For i = 0 To DG1.Rows.Count - 1
                    If Val(DG1.Item(1, i).Value) <> 0 Then
                        txtTotalwidth.Text = Val(txtTotalwidth.Text) + DG1.Item(1, i).Value
                        txttotalpcs.Text = Val(txttotalpcs.Text) + 1
                    End If
                 
                Next
            End If
            If e.ColumnIndex = 1 Then
                DG1.CurrentCell.Value = Format(Val(DG1.CurrentCell.Value), "0.00")
                If Format(Val(DG1.Item(1, e.RowIndex).Value), "0.00") > 99999.99 Then
                    MsgBox("Not valid number")
                    DG1.Item(1, e.RowIndex).Selected = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DataGridView1_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.RowEnter
        Try
            DG1.Item(0, e.RowIndex).Value = DG1.Item(0, e.RowIndex - 1).Value + 1
            Dim i As Integer
            txtTotalwidth.Text = ""


            For i = 0 To DG1.Rows.Count - 1
                txtTotalwidth.Text = Val(txtTotalwidth.Text) + DG1.Item(1, i).Value
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DG1_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DG1.EditingControlShowing
        Try
            Dim editingControl As TextBox = TryCast(e.Control, TextBox)

            If editingControl IsNot Nothing Then
                AddHandler editingControl.KeyPress, AddressOf Me.KeyPress1
                '       IsHandleAdded = True
                RemoveHandler Me.DG1.EditingControlShowing, AddressOf Me.DG1_EditingControlShowing
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub KeyPress1(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            '  MsgBox(Asc(e.KeyChar))
            'old
            ' Try
            ' If (Me.DG1.CurrentCell.ColumnIndex = 1) Then
            '    If (e.KeyChar <= "9" And e.KeyChar >= "0") Then
            '    ElseIf Asc(e.KeyChar) = 8 Then
            '   ElseIf e.KeyChar = "." Then

            '     Else
            '    e.Handled = True

            '      End If
            '     End If
            '

            '   Catch ex As Exception
            '      MsgBox(ex.ToString)
            '  End Try
            '     If (Me.dgpurch.CurrentCell.ColumnIndex = 3 Or dgpurch.CurrentCell.ColumnIndex = 4 Or dgpurch.CurrentCell.ColumnIndex = 5 Or dgpurch.CurrentCell.ColumnIndex = 6) Then
            'onlyNumbers(sender, e)
            ' End If
            '*****************************new editing'''''''''''''''''''''''''''''
            Try
                If e.KeyChar = "." Then
                    If sender.Text.Contains(".") Then
                        e.Handled = True
                    End If
                End If
                Dim i As Integer
                Dim check As Integer = 0
                Dim pos As Integer
                For i = 0 To sender.Text.Length - 1
                    If sender.Text.Chars(i) = "." Then
                        pos = i
                        check = 1
                    End If
                Next
                If check = 1 Then
                    If (sender.Text.Substring(pos + 1).Length > 1) Then
                        ' MsgBox("het")
                        If sender.SelectionStart > pos Then
                            e.Handled = True
                        End If
                    End If
                End If
                If (e.KeyChar <= "9" And e.KeyChar >= "0") Then
                ElseIf Asc(e.KeyChar) = 8 Then
                ElseIf e.KeyChar = "." Then

                Else
                    e.Handled = True
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub
    Private Function check1() As Boolean
        If txtAccode.Text.Length() = 0 Then
            MessageBox.Show("Account name can not be blank")
            txtAcname.Focus()
            Return False
        ElseIf txtITNAME.Text.Length = 0 Then
            MessageBox.Show("Iteam name can not be blank")
            txtITNAME.Focus()
            Return False
        ElseIf masklotno.Text.Length = 0 Then
            MessageBox.Show("Lotno can not be blank")
            masklotno.Focus()
            Return False
        Else
            Return True



        End If
    End Function
    Private Function getType1() As String
        Dim s As String = ""
        If RadioButton1.Checked Then
            s = "Mtr"
        Else
            s = "Weg"
        End If
        Return s


    End Function


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If Label12.Text = "ADD MODE" Then
                If check1() Then
                Else
                    GoTo last
                End If
                connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                cmdcheck = New SqlCommand("select * from tbllotr where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo last
                Else
                    drcheck.Close()
                End If
                cmdcheck = New SqlCommand("Select vrno from tblLotr where lotno='" & txtLotno1.Text & masklotno.Text & "' and check1='" & txtCheck.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MessageBox.Show("Duplicate lot no")
                    GoTo last
                Else
                    drcheck.Close()

                End If
                close1()
                Dim dat As New Date
                dat = maskDate.Text.ToString
                Dim a() As String = {txtVrNo1.Text & txtVrNo2.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtLotno1.Text & masklotno.Text, txtIchno.Text, txtITNAME.Text, txtITCODE.Text, txtAcname.Text, txtAccode.Text, txtWidth.Text, txttotalpcs.Text, txtTotalwidth.Text, txtDesc2.Text, txtMst.Text, txtLrNo.Text, txttotalpcs.Text, txtTotalwidth.Text, "f", txtLotno1.Text, lotn(masklotno.Text), lotc(masklotno.Text), masklotno.Text, 0, txtDesc.Text, txtMarka.Text, txtBroker.Text, txtBrCode.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtCheck.Text, getType1()}
                myinsert(a, "tblLotr")
                ' MsgBox("a")
                Dim i As Integer
                For i = 0 To DG1.Rows.Count - 1
                    If Val(DG1.Item(1, i).Value) <> 0 Then


                        Dim b() As String = {txtVrNo1.Text & txtVrNo2.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, DG1.Item(1, i).Value, DG1.Item(0, i).Value, "Desc", txtLotno1.Text & masklotno.Text, txtITCODE.Text, txtAccode.Text, 0, DG1.Item(1, i).Value, txtLotno1.Text, lotn(masklotno.Text), lotc(masklotno.Text)}
                        myinsert(b, "tblLotRt")
                    End If
                Next
                UserAction(frmlogin.TextBox1.Text, "ADD", "lotno=" & masklotno.Text, "LOTR")
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,IchNo,Lotno,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR order by convert(INT,substring(vrno,4,LEN(vrno)-3))", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                close1()
                Try
                    dg2.Item(1, dg2.RowCount - 1).Selected = True
                Catch ex As Exception
                    '   dg2.Item(1, CURRENTROW).Selected = True
                End Try

                MsgBox("Success")
                Button1.Focus()
            ElseIf Label12.Text = "EDIT MODE" Then
                Dim dat As New Date
                dat = maskDate.Text.ToString
                Dim a() As String = {txtVrNo1.Text & txtVrNo2.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtLotno1.Text & masklotno.Text, txtIchno.Text, txtITNAME.Text, txtITCODE.Text, txtAcname.Text, txtAccode.Text, txtWidth.Text, txttotalpcs.Text, txtTotalwidth.Text, txtDesc2.Text, txtMst.Text, txtLrNo.Text, txttotalpcs.Text, txtTotalwidth.Text, "f", txtLotno1.Text, lotn(masklotno.Text), lotc(masklotno.Text), masklotno.Text, 0, txtDesc.Text, txtMarka.Text, txtBroker.Text, txtBrCode.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtCheck.Text, getType1()}
                myupdate("tblLotr", a, "VrNo", txtVrNo1.Text & txtVrNo2.Text)
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("delete from tblLotrt where vrno='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
                cmd.ExecuteNonQuery()
                Dim i As Integer
                For i = 0 To DG1.Rows.Count - 1
                    If Val(DG1.Item(1, i).Value) <> 0 Then
                        Dim b() As String = {txtVrNo1.Text & txtVrNo2.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, DG1.Item(1, i).Value, DG1.Item(0, i).Value, "Desc", txtLotno1.Text & masklotno.Text, txtITCODE.Text, txtAccode.Text, 0, DG1.Item(1, i).Value, txtLotno1.Text, lotn(masklotno.Text), lotc(masklotno.Text)}
                        myinsert(b, "tblLotRt")
                    End If
                Next
                UserAction(frmlogin.TextBox1.Text, "EDIT", "lotno=" & masklotno.Text, "LOTR")
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,IchNo,Lotno,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR order by convert(INT,substring(vrno,4,LEN(vrno)-3))", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                close1()
                Try
                    dg2.Item(1, CURRENTROW + 1).Selected = True
                Catch ex As Exception
                    Try
                        dg2.Item(1, CURRENTROW).Selected = True
                    Catch ex1 As Exception

                    End Try

                End Try
                MessageBox.Show("Edited")
            End If

            'myfilldatagrid(dg2, "tblLotr")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
last:
    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub dg2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.RowEnter
        Try

            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select * from tblLotr where VrNo='" & dg2.Item(0, e.RowIndex).Value & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                txtVrNo1.Text = dr.Item("VrNo").ToString.Substring(0, 3).ToString
                txtVrNo2.Text = dr.Item("VrNo").ToString.Substring(3).ToString
                txtAcname.Text = dr.Item("ACName")
                txtAccode.Text = dr.Item("ACCode")
                txtMst.Text = dr.Item("Mst")
                txtITNAME.Text = dr.Item("Item")
                txtITCODE.Text = dr.Item("ITCode")
                txtIchno.Text = dr.Item("IChNo")
                txtWidth.Text = dr.Item("Width")
                masklotno.Text = dr.Item("LotNo").ToString.Substring(3)
                maskDate.Text = Format(dr.Item("Date"), "dd-MM-yyyy")
                txtTotalwidth.Text = dr.Item("Gmtr")
                txttotalpcs.Text = dr.Item("Gpcs")
                txtDesc2.Text = dr.Item("Remark")
                txtMarka.Text = dr.Item("Marka")
                txtLrNo.Text = dr.Item("lrNo")
                txtWeight.Text = dr.Item("weg")
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblLotRt where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            DG1.Rows.Clear()
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, i).Value = dr.Item("Sr")
                DG1.Item(1, i).Value = dr.Item("Gmtr")
                i = i + 1
            End While
            dr.Close()
            Try
                connect()
                cmd = New SqlCommand("SELECT MSTNAME,MARKO,Add1,Add2,Place,Pin,State FROM TBLaCCOUNT WHERE ACNAME='" & txtAcname.Text & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    'txtMst.Text = dr.Item(0)
                    txtMarka.Text = dr.Item(1)
                    txtAddress.Text = dr.Item(2) & "," & dr.Item(3) & "," & dr.Item(4) & "," & dr.Item(6) & "," & dr.Item(5)
                End While
                dr.Close()
                close1()

            Catch ex As Exception

            End Try
            '   DG1.Rows.Add()
        Catch ex As Exception
            '        MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            masklotno.ReadOnly = True
            Timer1.Enabled = True
            Label12.Text = "EDIT MODE"
            Try
                CURRENTROW = dg2.CurrentCell.RowIndex
            Catch ex As Exception

            End Try
            masklotno.ReadOnly = True
            maskDate.Focus()
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select * from tblLotr where VrNo='" & dg2.Item(0, dg2.SelectedCells.Item(0).RowIndex).Value & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                txtVrNo1.Text = dr.Item("VrNo").ToString.Substring(0, 3).ToString
                txtVrNo2.Text = dr.Item("VrNo").ToString.Substring(3).ToString
                txtAcname.Text = dr.Item("ACName")
                txtAccode.Text = dr.Item("ACCode")
                txtMst.Text = dr.Item("Mst")
                txtITNAME.Text = dr.Item("Item")
                txtITCODE.Text = dr.Item("ITCode")
                txtIchno.Text = dr.Item("IChNo")
                txtWidth.Text = dr.Item("Width")
                masklotno.Text = dr.Item("LotNo").ToString.Substring(3)
                maskDate.Text = Format(dr.Item("Date"), "dd-MM-yyyy")
                txtTotalwidth.Text = dr.Item("Gmtr")
                txttotalpcs.Text = dr.Item("Gpcs")
                txtDesc2.Text = dr.Item("Remark")
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblLotRt where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            DG1.Rows.Clear()
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, i).Value = dr.Item("Sr")
                DG1.Item(1, i).Value = dr.Item("Gmtr")
                i = i + 1
            End While
            dr.Close()

            '   DG1.Rows.Add()
        Catch ex As Exception
            '        MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Try
                CURRENTROW = dg2.CurrentCell.RowIndex
            Catch ex As Exception

            End Try
            MessageBox.Show(CURRENTROW)
            If MessageBox.Show("You want to delete entry for VrNo=" & txtVrNo1.Text & txtVrNo2.Text, "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("delete from tblLotRt where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLotr where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
                DG1.Rows.Clear()
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,Lotno,IchNo,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR ORDER BY CONVERT(INT,LOTN)", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                Try
                    dg2.Item(1, CURRENTROW).Selected = True
                Catch ex As Exception
                    Try
                        dg2.Item(1, CURRENTROW - 1).Selected = True
                    Catch ex1 As Exception
                        MessageBox.Show(ex.ToString)
                    End Try

                End Try
                close1()
                UserAction(frmlogin.TextBox1.Text, "DELETE", "lotno=" & masklotno.Text, "LOTR")
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Clearall()
        maxVrNo(txtVrNo2, "tblLotr")
        maskDate.Focus()
        Label12.Text = "ADD MODE"

        masklotno.Text = "11-" & maxlotno()
    End Sub

    Private Sub TextBox13_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLrNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWeight.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtWidth.Focus()
        End If
    End Sub

    Private Sub TextBox15_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        numbersonly(sender, e)
    End Sub

    Private Sub TextBox16_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If (e.KeyChar >= "A" And e.KeyChar <= "Z") = True Then
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox16_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  MaskedTextBox1.Text = TextBox14.Text & TextBox15.Text & TextBox16.Text
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWidth.Leave
        txtWidth.Text = Format(Val(txtWidth.Text), "0.00")
    End Sub

    Private Sub TextBox15_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWeight.Leave
        txtWeight.Text = Format(Val(txtWeight.Text), "0.000")
    End Sub

    Private Sub dgacm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtAcname.Text = dgacm.Item(1, dgacm.CurrentCell.RowIndex).Value
                txtAccode.Text = dgacm.Item(0, dgacm.CurrentCell.RowIndex).Value
                masklotno.Focus()
                dgacm.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox15_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Label12.Text = "ADD MODE" Then
                DG1.Rows.Clear()
                DG1.Rows.Add()
                If e.KeyCode = Keys.Enter Then
                    DG1.Item(0, 0).Value = 1
                    DG1.Item(1, 0).Selected = True
                    DG1.Focus()
                End If
            ElseIf Label12.Text = "EDIT MODE" Then
                DG1.Focus()
            Else
            End If
            ' txtMarka.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtLrNo.Focus()
        End If
    End Sub

    Private Sub TextBox16_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button6.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtMarka.Focus()
        End If
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub MaskedTextBox1_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles masklotno.Leave
        masklotno.Text = masklotno.Text.ToUpper
        If masklotno.Text.Trim.Length = 0 Then
            MsgBox("LOTNO CAN NOT BE BLANK")
            masklotno.Focus()
        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        txtDesc.Focus()
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIchno.TextChanged

    End Sub

    Private Sub TextBox17_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarka.KeyUp
        myAutoComplete(txtMarka, ListBox2, "mrkmst", "marka")
    End Sub

    Private Sub ListBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox2.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                txtMarka.Text = ListBox2.SelectedItem.ToString
                If Label12.Text = "ADD MODE" Then
                    DG1.Rows.Clear()
                    DG1.Rows.Add()
                    If e.KeyCode = Keys.Enter Then
                        DG1.Item(0, 0).Value = 1
                        DG1.Item(1, 0).Selected = True
                        DG1.Focus()
                    End If
                ElseIf Label12.Text = "EDIT MODE" Then
                    DG1.Focus()
                Else
                End If
                ListBox2.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAcname.Leave
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            CMD = New SqlCommand("SELECT MSTNAME,MARKO,Add1,Add2,Place,Pin,State FROM TBLaCCOUNT WHERE ACNAME='" & txtAcname.Text & "'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                If Label12.Text = "ADD MODE" Then
                    txtMst.Text = DR.Item(0)
                End If

                txtMarka.Text = DR.Item(1)
                txtAddress.Text = DR.Item(2) & "," & DR.Item(3) & "," & DR.Item(4) & "," & DR.Item(6) & "," & DR.Item(5)
            End While
            DR.Close()
            close1()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GroupBox3.Visible = True
        tv1 = ""
        TextBox20.Focus()
        TextBox20.Text = ""

    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox20.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 1
        End If
        Dim columncount As Integer
        If RadioButton3.Checked = True Then
            columncount = 3
            temp2 = 3
        Else
            columncount = dg2.ColumnCount - 1
        End If

        tv1 = TextBox20.Text
        If RadioButton3.Checked = False Then
            For i = temp1 To dg2.Rows.Count - 1
                For j = temp2 To columncount
                    If 1 <> 1 Then
                        GoTo a
                    Else
                        If (dg2.Item(j, i).Value.ToString.ToUpper.Contains(TextBox20.Text.ToUpper)) Then
                            Try
                                dg2.Item(j, i).Selected = True

                            Catch ex As Exception

                            End Try
                            temp2 = j + 1
                            '    check = 1
                            GoTo en
                        End If
                    End If

a:

                Next
                temp1 = i + 1
                temp2 = 0
            Next
        Else
            For i = temp1 To dg2.Rows.Count - 1
                If (dg2.Item(3, i).Value.ToString.ToUpper.Contains(TextBox20.Text.ToUpper)) Then
                    Try
                        dg2.Item(3, i).Selected = True

                    Catch ex As Exception

                    End Try
                    temp1 = i + 1
                    '    check = 1
                    GoTo en
                End If
            Next
en:


        End If
       
    End Sub
    Public Function lotn(ByVal a As String) As String
        a = a.ToUpper().Trim
        If a.Chars(0) <= "Z" And a.Chars(0) >= "A" Then
            MsgBox("LotNo cannot start with Alphabet")
            GoTo en
        End If
        Dim i As Integer
        For i = 0 To a.Length - 1
            If a.Chars(i) <= "Z" And a.Chars(i) >= "A" Then
                If i <> 1 Then
                    Return a.Substring(0, i)
                    '  TextBox3.Text = TextBox1.Text.Substring(i)
                    GoTo en
                Else
                    Return a.Substring(0, 1)
                    '  TextBox3.Text = TextBox1.Text.Substring(1)
                    GoTo en
                End If
            End If
        Next
        Return a
en:
    End Function
    Public Function lotc(ByVal a As String) As String
        Dim b As String = ""
        a = a.ToUpper().Trim
        If a.Chars(0) <= "Z" And a.Chars(0) >= "A" Then
            MsgBox("LotNo cannot start with Alphabet")
            GoTo en
        End If
        Dim i As Integer
        For i = 0 To a.Length - 1
            If a.Chars(i) <= "Z" And a.Chars(i) >= "A" Then
                If i <> 1 Then
                    '    Return a.Substring(0, i)
                    Return a.Substring(i)
                    GoTo en
                Else
                    '  Return a.Substring(0, 1)
                    Return a.Substring(1)
                    GoTo en
                End If
            End If
        Next
        Return b
en:
    End Function
    Private Sub TextBox20_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox20.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button9.Focus()
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        GroupBox3.Visible = False
    End Sub

    Private Sub MaskedTextBox2_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles maskDate.MaskInputRejected

    End Sub

    Private Sub txtMst_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMst.TextChanged

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If TIMERCOUNT > 20 Then
            Label3.Visible = False
            Timer1.Enabled = False
            TIMERCOUNT = 0
        Else
            Label3.Visible = True
            TIMERCOUNT = TIMERCOUNT + 1
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        frmjobcarddis.Close()
        frmjobcarddis.FROMWHERE = ""
        frmjobcarddis.LOTNO = txtLotno1.Text & masklotno.Text
        frmjobcarddis.Show()
        Me.Hide()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub txtCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheck.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMst.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            masklotno.Focus()

        End If
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button6.MouseHover, Button5.MouseHover, Button4.MouseHover, Button3.MouseHover, Button2.MouseHover, Button11.MouseHover, Button1.MouseHover

        sender.backcolor = Color.BlueViolet
        sender.forecolor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave, Button5.MouseLeave, Button4.MouseLeave, Button3.MouseLeave, Button2.MouseLeave, Button11.MouseLeave, Button1.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black

    End Sub


    Private Sub Button5_Enter(sender As Object, e As EventArgs) Handles Button6.Enter, Button5.Enter, Button4.Enter, Button3.Enter, Button2.Enter, Button11.Enter, Button1.Enter
        sender.backcolor = Color.BlueViolet
        sender.forecolor = Color.White
    End Sub

    Private Sub Button5_Leave(sender As Object, e As EventArgs) Handles Button6.Leave, Button5.Leave, Button4.Leave, Button3.Leave, Button2.Leave, Button11.Leave, Button1.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black

    End Sub




End Class