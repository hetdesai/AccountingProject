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

    Private Sub MaskedTextBox2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Enter
        MaskedTextBox2.SelectionLength = 0
        MaskedTextBox2.SelectionStart = 0
    End Sub
    Private Sub gfocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAcname.GotFocus, txtAccode.GotFocus, TextBox10.GotFocus, TextBox11.GotFocus, TextBox12.GotFocus, txtMst.GotFocus, txtITNAME.GotFocus, txtIchno.GotFocus, txtITCODE.GotFocus, txtWidth.GotFocus, txtDesc2.GotFocus, TextBox9.GotFocus, masklotno.GotFocus, MaskedTextBox2.GotFocus, TextBox10.GotFocus, TextBox11.GotFocus, TextBox12.GotFocus, txtLrNo.GotFocus, TextBox14.GotFocus, txtWeight.GotFocus, txtDesc.GotFocus, txtMarka.GotFocus, txtBroker.GotFocus, txtBrCode.GotFocus
        sender.BackColor = Color.Pink
    End Sub
    Private Sub gotf(ByVal sender As Object, ByVal e As EventArgs) Handles MaskedTextBox2.GotFocus
        MaskedTextBox2.SelectionLength = 0
        MaskedTextBox2.SelectionStart = 0
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
    Private Sub lfocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAcname.LostFocus, txtAccode.LostFocus, TextBox10.LostFocus, TextBox11.LostFocus, TextBox12.LostFocus, txtMst.LostFocus, txtITNAME.LostFocus, txtIchno.LostFocus, txtITCODE.LostFocus, txtWidth.LostFocus, txtDesc2.LostFocus, TextBox9.LostFocus, masklotno.LostFocus, MaskedTextBox2.LostFocus, TextBox10.LostFocus, TextBox11.LostFocus, TextBox12.LostFocus, txtLrNo.LostFocus, TextBox14.LostFocus, txtWeight.LostFocus, txtDesc.LostFocus, txtMarka.LostFocus, txtBroker.LostFocus, txtBrCode.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox2.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Or DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter Date in Current A/c Year")
                MaskedTextBox2.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox2.Focus()
        End Try
    End Sub
    Private Sub frmlotr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        dg2.Focus()
        dg2.TabIndex = 0
        'GroupBox2.TabIndex = 0
        TextBox11.Text = acycode & "/"
        TextBox14.Text = acycode & "/"
        '  myfilldatagrid(dg2, "tblLotr")
        connect()
        Dim DA As New SqlDataAdapter
        Dim DS As New DataSet
        DA = New SqlDataAdapter("SELECT VrNo,Date,Lotno,IchNo,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR ORDER BY CONVERT(INT,LOTN)", cn)
        DA.Fill(DS)
        dg2.DataSource = DS.Tables(0)
        dg2.Columns(0).Visible = False
        Try
            dg2.Item(1, dg2.RowCount - 1).Selected = True
        Catch ex As Exception

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
    Private Sub MaskedTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox2.KeyDown
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
                MaskedTextBox2.Focus()
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
            txtMst.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAcname.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMst.KeyDown
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
en:
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtITNAME.KeyUp
        myAutoComplete(txtITNAME, ListBox1, "tblItem", "ITName")
        Try
            ListBox1.Visible = True

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cn.Open()
            cmd = New SqlCommand("Select ITNAME from tblItem where ITNAME like '" & txtITNAME.Text & "%' and (ITTYPE='SALES' or ITTYPE='GRAY')", cn)
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
        maxVrNo(TextBox12, "tblLotr")
        MaskedTextBox2.Focus()
      
        Label12.Text = "ADD MODE"
        MaskedTextBox2.Text = Format(Date.Today, "dd-MM-yyyy")
        MaskedTextBox2.SelectionStart = 0
        MaskedTextBox2.SelectionLength = 0

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

    End Sub
    Private Sub Clearall()
        '   TextBox1.Clear()
        '  TextBox2.Clear()
        txtMst.Clear()
        txtITNAME.Clear()
        txtIchno.Clear()
        txtITCODE.Clear()
        '  TextBox7.Clear()
        txtDesc2.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        '   TextBox11.Clear()
        TextBox12.Clear()
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
                TextBox10.Text = ""
                TextBox9.Text = ""
                TextBox9.Text = DG1.Rows.Count - 1
                For i = 0 To DG1.Rows.Count - 1
                    TextBox10.Text = Val(TextBox10.Text) + DG1.Item(1, i).Value
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
            TextBox10.Text = ""
            TextBox9.Text = ""
            TextBox9.Text = DG1.Rows.Count - 1
            For i = 0 To DG1.Rows.Count - 1
                TextBox10.Text = Val(TextBox10.Text) + DG1.Item(1, i).Value
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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            If Label12.Text = "ADD MODE" Then
                connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                cmdcheck = New SqlCommand("select * from tbllotr where VrNo='" & TextBox11.Text & TextBox12.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo last
                Else
                    drcheck.Close()
                End If
                close1()
                Dim dat As New Date
                dat = MaskedTextBox2.Text.ToString
                Dim a() As String = {TextBox11.Text & TextBox12.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, TextBox14.Text & masklotno.Text, txtIchno.Text, txtITNAME.Text, txtITCODE.Text, txtAcname.Text, txtAccode.Text, txtWidth.Text, TextBox9.Text, TextBox10.Text, txtDesc2.Text, txtMst.Text, txtLrNo.Text, TextBox9.Text, TextBox10.Text, "f", TextBox14.Text, lotn(masklotno.Text), lotc(masklotno.Text), masklotno.Text, 0, txtDesc.Text, txtMarka.Text, txtBroker.Text, txtBrCode.Text, dat.Month & "-" & dat.Day & "-" & dat.Year}
                myinsert(a, "tblLotr")
                ' MsgBox("a")
                Dim i As Integer
                For i = 0 To DG1.Rows.Count - 2
                    Dim b() As String = {TextBox11.Text & TextBox12.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, DG1.Item(1, i).Value, DG1.Item(0, i).Value, "Desc", TextBox14.Text & masklotno.Text, txtITCODE.Text, txtAccode.Text, 0, DG1.Item(1, i).Value, TextBox14.Text, lotn(masklotno.Text), lotc(masklotno.Text)}
                    myinsert(b, "tblLotRt")
                Next
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,Lotno,IchNo,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR ORDER BY CONVERT(INT,LOTN)", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                close1()
                Try
                    dg2.Item(1, DG1.RowCount - 1).Selected = True
                Catch ex As Exception
                    '   dg2.Item(1, CURRENTROW).Selected = True
                End Try

                MsgBox("Success")
                Button1.Focus()
            ElseIf Label12.Text = "EDIT MODE" Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("delete from tblLotRt where VrNo='" & TextBox11.Text & TextBox12.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
                Dim dat As New Date
                dat = MaskedTextBox2.Text.ToString
                Dim a() As String = {TextBox11.Text & TextBox12.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, TextBox14.Text & masklotno.Text, txtIchno.Text, txtITNAME.Text, txtITCODE.Text, txtAcname.Text, txtAccode.Text, txtWidth.Text, TextBox9.Text, TextBox10.Text, txtDesc2.Text, txtMst.Text, txtLrNo.Text, TextBox9.Text, TextBox10.Text, "f", TextBox14.Text, lotn(masklotno.Text), lotc(masklotno.Text), masklotno.Text, 0, txtDesc.Text, txtMarka.Text, txtBroker.Text, txtBrCode.Text, dat.Month & "-" & dat.Day & "-" & dat.Year}
                myupdate("tblLotr", a, "VrNo", TextBox11.Text & TextBox12.Text)
                Dim i As Integer
                For i = 0 To DG1.Rows.Count - 2
                    Dim b() As String = {TextBox11.Text & TextBox12.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, DG1.Item(1, i).Value, DG1.Item(0, i).Value, "Desc", TextBox14.Text & masklotno.Text, txtITCODE.Text, txtAccode.Text, 0, DG1.Item(1, i).Value, TextBox14.Text, lotn(masklotno.Text), lotc(masklotno.Text)}
                    myinsert(b, "tblLotRt")
                Next
                MsgBox("Success")
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,Lotno,IchNo,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR ORDER BY CONVERT(INT,LOTN)", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                close1()
                Try
                    dg2.Item(1, CURRENTROW + 1).Selected = True
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    dg2.Item(1, CURRENTROW).Selected = True
                End Try

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
                TextBox11.Text = dr.Item("VrNo").ToString.Substring(0, 3).ToString
                TextBox12.Text = dr.Item("VrNo").ToString.Substring(3).ToString
                txtAcname.Text = dr.Item("ACName")
                txtAccode.Text = dr.Item("ACCode")
                txtMst.Text = dr.Item("Mst")
                txtITNAME.Text = dr.Item("Item")
                txtITCODE.Text = dr.Item("ITCode")
                txtIchno.Text = dr.Item("IChNo")
                txtWidth.Text = dr.Item("Width")
                masklotno.Text = dr.Item("LotNo").ToString.Substring(3)
                MaskedTextBox2.Text = Format(dr.Item("Date"), "dd-MM-yyyy")
                TextBox10.Text = dr.Item("Gmtr")
                TextBox9.Text = dr.Item("Gpcs")
                txtDesc2.Text = dr.Item("Remark")
                txtMarka.Text = dr.Item("Marka")
                txtLrNo.Text = dr.Item("lrNo")
                txtWeight.Text = dr.Item("weg")
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblLotRt where VrNo='" & TextBox11.Text & TextBox12.Text & "'", cn)
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
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Timer1.Enabled = True
            Label12.Text = "EDIT MODE"
            Try
                CURRENTROW = dg2.CurrentCell.RowIndex
            Catch ex As Exception

            End Try
            masklotno.ReadOnly = True
            MaskedTextBox2.Focus()
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select * from tblLotr where VrNo='" & dg2.Item(0, dg2.SelectedCells.Item(0).RowIndex).Value & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox11.Text = dr.Item("VrNo").ToString.Substring(0, 3).ToString
                TextBox12.Text = dr.Item("VrNo").ToString.Substring(3).ToString
                txtAcname.Text = dr.Item("ACName")
                txtAccode.Text = dr.Item("ACCode")
                txtMst.Text = dr.Item("Mst")
                txtITNAME.Text = dr.Item("Item")
                txtITCODE.Text = dr.Item("ITCode")
                txtIchno.Text = dr.Item("IChNo")
                txtWidth.Text = dr.Item("Width")
                masklotno.Text = dr.Item("LotNo").ToString.Substring(3)
                MaskedTextBox2.Text = Format(dr.Item("Date"), "dd-MM-yyyy")
                TextBox10.Text = dr.Item("Gmtr")
                TextBox9.Text = dr.Item("Gpcs")
                txtDesc2.Text = dr.Item("Remark")
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblLotRt where VrNo='" & TextBox11.Text & TextBox12.Text & "'", cn)
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
            CURRENTROW = DG1.CurrentCell.RowIndex
            If MsgBox("You want to delete entry for VrNo=" & TextBox11.Text & TextBox12.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("delete from tblLotRt where VrNo='" & TextBox11.Text & TextBox12.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLotr where VrNo='" & TextBox11.Text & TextBox12.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,Lotno,IchNo,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR ORDER BY CONVERT(INT,LOTN)", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                Try
                    dg2.Item(1, CURRENTROW).Selected = True
                Catch ex As Exception
                    dg2.Item(1, CURRENTROW - 1).Selected = True
                End Try
                close1()
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Clearall()
        maxVrNo(TextBox12, "tblLotr")
        MaskedTextBox2.Focus()
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
            txtMarka.Focus()
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
        If masklotno.Text.Trim.Length = 0 Then
            MsgBox("LOTNO CAN NOT BE BLANK")
            masklotno.Focus()
        End If
        If Label12.Text = "EDIT MODE" Then
        Else
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblLotr where lotno='" & TextBox14.Text & masklotno.Text & "'", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("Duplicate lotno")
                masklotno.Focus()
                dr.Close()
            Else
                dr.Close()
            End If

            close1()

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
            CMD = New SqlCommand("SELECT MSTNAME,MARKO FROM TBLaCCOUNT WHERE ACNAME='" & txtAcname.Text & "'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                txtMst.Text = DR.Item(0)
                txtMarka.Text = DR.Item(1)
            End While
            DR.Close()
            close1()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox20.Focus()
        TextBox20.Text = ""
        GroupBox3.Visible = True
        tv1 = ""
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox20.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox20.Text
        For i = temp1 To dg2.Rows.Count - 1
            For j = temp2 To dg2.ColumnCount - 1
                If 1 <> 1 Then
                    GoTo a
                Else
                    If (dg2.Item(j, i).Value.ToString.ToUpper.Contains(TextBox20.Text.ToUpper)) Then
                        dg2.Item(j, i).Selected = True
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
en:
    End Sub

    Private Sub TextBox20_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox20.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button9.Focus()
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        GroupBox3.Visible = False
    End Sub

    Private Sub MaskedTextBox2_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox2.MaskInputRejected

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
        frmjobcarddis.LOTNO = TextBox14.Text & masklotno.Text
        frmjobcarddis.Show()
        Me.Hide()
    End Sub
End Class