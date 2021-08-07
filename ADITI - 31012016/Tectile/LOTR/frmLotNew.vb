Imports System.Data.SqlClient



Public Class frmLotNew
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
    Private Sub Clearall()
        '   txtMst.Clear()
        '  txtITNAME.Clear()
        txtIchno.Clear()
        '  txtITCODE.Clear()
        txtDesc2.Clear()
        txttotalpcs.Clear()
        txtTotalwidth.Clear()
        txtVrNo2.Clear()
        ' masklotno.Clear()
        txttotalpcs.Clear()

        txtTotalwidth.Clear()


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
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button6.MouseHover, Button5.MouseHover, Button4.MouseHover, Button3.MouseHover, Button2.MouseHover, Button11.MouseHover, Button1.MouseHover

        sender.backcolor = Color.BlueViolet
        sender.forecolor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave, Button5.MouseLeave, Button4.MouseLeave, Button3.MouseLeave, Button2.MouseLeave, Button11.MouseLeave, Button1.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        masklotno.ReadOnly = False
        GroupBox1.TabIndex = 0
        GroupBox3.Visible = False
        Clearall()
        maxVrNo(txtVrNo2, "tblLotr")
        maskDate.Focus()

        Label12.Text = "ADD MODE"
        '  maskDate.Text = Format(Date.Today, "dd-MM-yyyy")
        maskDate.SelectionStart = 0
        maskDate.SelectionLength = 0

        txttotalpcs.Text = 0.0
        txtTotalwidth.Text = 0.0
        txtWeight.Text = "0.000"
        ' txtCheck.Clear()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
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
            cmd = New SqlCommand("Select convert(int,lotn) from tblLotr where vrno='" & acycode & "/" & Val(tb.Text) - 1 & "'", cn)
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
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Timer1.Enabled = True
            Label12.Text = "EDIT MODE"
            Try
                CURRENTROW = dg2.CurrentCell.RowIndex
            Catch ex As Exception

            End Try
            GroupBox3.Visible = False
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
                txtWeight.Text = dr.Item("weg")
                txttotalpcs.Text = dr.Item("Gpcs")
                txtTotalwidth.Text = dr.Item("Gmtr")
                txtCheck.Text = dr.Item("Check1")
            End While
            dr.Close()


        Catch ex As Exception
            '        MsgBox(ex.ToString)
        End Try
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

    Private Sub frmLotNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("DO YOU WANT TO EXIT?", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If


        End If
    End Sub
    Private Sub frmLotNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        dg2.Columns(2).Width = 70
        dg2.Columns(1).Width = 80
        dg2.Columns(3).Width = 250
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
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try

            If Label12.Text = "ADD MODE" Then
                If check1() Then
                Else
                    GoTo last
                End If
                 connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                cmdcheck = New SqlCommand("select vrno from tbllotr where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    masklotno.Focus()
                    GoTo last
                Else
                    drcheck.Close()
                End If
                ' MessageBox.Show("Select vrno from tblLotr where lotno='" & txtLotno1.Text & masklotno.Text & "' and check1='" & txtCheck.Text & "'")

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
                Dim a() As String = {txtVrNo1.Text & txtVrNo2.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtLotno1.Text & masklotno.Text, txtIchno.Text, txtITNAME.Text, txtITCODE.Text, txtAcname.Text, txtAccode.Text, txtWidth.Text, txttotalpcs.Text, txtTotalwidth.Text, txtDesc2.Text, txtMst.Text, txtLrNo.Text, txttotalpcs.Text, txtTotalwidth.Text, "f", txtLotno1.Text, 0, "", masklotno.Text, txtWeight.Text, txtDesc.Text, txtMarka.Text, txtBroker.Text, txtBrCode.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtCheck.Text, "Mtr"}
                myinsert(a, "tblLotr")
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,IchNo,Lotno,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR order by convert(INT,substring(vrno,4,LEN(vrno)-3))", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                dg2.Columns(2).Width = 70
                dg2.Columns(1).Width = 80
                dg2.Columns(3).Width = 250


                close1()
                Try
                    dg2.Item(1, dg2.RowCount - 1).Selected = True
                Catch ex As Exception
                    '   dg2.Item(1, CURRENTROW).Selected = True
                End Try

                MsgBox("Success")
                Button1.Focus()
            ElseIf Label12.Text = "EDIT MODE" Then
                If check1() Then
                Else
                    GoTo last
                End If
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("delete from tblLotRt where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
                Dim dat As New Date
                dat = maskDate.Text.ToString
                Dim a() As String = {txtVrNo1.Text & txtVrNo2.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtLotno1.Text & masklotno.Text, txtIchno.Text, txtITNAME.Text, txtITCODE.Text, txtAcname.Text, txtAccode.Text, txtWidth.Text, txttotalpcs.Text, txtTotalwidth.Text, txtDesc2.Text, txtMst.Text, txtLrNo.Text, txttotalpcs.Text, txtTotalwidth.Text, "f", txtLotno1.Text, 0, "", masklotno.Text, txtWeight.Text, txtDesc.Text, txtMarka.Text, txtBroker.Text, txtBrCode.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtCheck.Text, "Mtr"}
                myupdate("tblLotr", a, "VrNo", txtVrNo1.Text & txtVrNo2.Text)

                MsgBox("Success")
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,IchNo,Lotno,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR order by convert(INT,substring(vrno,4,LEN(vrno)-3))", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                dg2.Columns(2).Width = 70
                dg2.Columns(1).Width = 80
                dg2.Columns(3).Width = 250


                close1()
                Try
                    dg2.Item(1, dg2.RowCount - 1).Selected = True
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    dg2.Item(1, dg2.RowCount - 1).Selected = True
                End Try

            End If
            'myfilldatagrid(dg2, "tblLotr")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
last:
    End Sub
    Private Sub TextBox17_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarka.KeyUp
        myAutoComplete(txtMarka, ListBox2, "mrkmst", "marka")
    End Sub
    

    Private Sub txtAcname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAcname.KeyDown
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
            dgacm.Visible = False
        End If
en:
    End Sub

    Private Sub txtAcname_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAcname.KeyUp
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter(acm(txtAcname.Text), cn)
            da.Fill(ds)
            dgacm.DataSource = ds.Tables(0)
            dgacm.Visible = True
            dgacm.Columns(1).Width = 300
            dgacm.Columns(3).Width = 300
            dgacm.Columns(0).Width = 50
            dgacm.Top = txtAcname.Top + 22
            dgacm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAcname_Leave(sender As Object, e As EventArgs) Handles txtAcname.Leave
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

    Private Sub txtITNAME_KeyDown(sender As Object, e As KeyEventArgs) Handles txtITNAME.KeyDown
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

    Private Sub txtITNAME_KeyUp(sender As Object, e As KeyEventArgs) Handles txtITNAME.KeyUp
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

    Private Sub txtMarka_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarka.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If ListBox2.Items.Count > 0 Then
                    txtMarka.Text = ListBox2.Items(0).ToString
                    txttotalpcs.Focus()
                    ListBox2.Visible = False
                Else
                    If MsgBox("marka not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        markacheck = 1
                        Me.Hide()
                        frmMarko.Show()
                        GoTo en
                    End If
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
        Catch ex As Exception
            ex.ToString()
        End Try
     
    End Sub

    

    Private Sub MaskedTextBox2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskDate.Enter
        maskDate.SelectionLength = 0
        maskDate.SelectionStart = 0
    End Sub
    Private Sub gfocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAcname.GotFocus, txtAccode.GotFocus, txtTotalwidth.GotFocus, txtVrNo1.GotFocus, txtVrNo2.GotFocus, txtMst.GotFocus, txtITNAME.GotFocus, txtIchno.GotFocus, txtITCODE.GotFocus, txtWidth.GotFocus, txtDesc2.GotFocus, txttotalpcs.GotFocus, masklotno.GotFocus, maskDate.GotFocus, txtTotalwidth.GotFocus, txtVrNo1.GotFocus, txtVrNo2.GotFocus, txtLrNo.GotFocus, txtLotno1.GotFocus, txtWeight.GotFocus, txtDesc.GotFocus, txtMarka.GotFocus, txtBroker.GotFocus, txtBrCode.GotFocus
        sender.BackColor = Color.Pink
    End Sub
    Private Sub gotf(ByVal sender As Object, ByVal e As EventArgs) Handles maskDate.GotFocus
        maskDate.SelectionLength = 0
        maskDate.SelectionStart = 0
    End Sub

    

    Private Sub txtTotalwidth_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalwidth.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            txtDesc.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txttotalpcs.Focus()
        End If
    End Sub

    Private Sub txtDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button6.Focus()

        End If
    End Sub
    Private Sub lfocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAcname.LostFocus, txtAccode.LostFocus, txtTotalwidth.LostFocus, txtVrNo1.LostFocus, txtVrNo2.LostFocus, txtMst.LostFocus, txtITNAME.LostFocus, txtIchno.LostFocus, txtITCODE.LostFocus, txtWidth.LostFocus, txtDesc2.LostFocus, txttotalpcs.LostFocus, masklotno.LostFocus, maskDate.LostFocus, txtTotalwidth.LostFocus, txtVrNo1.LostFocus, txtVrNo2.LostFocus, txtLrNo.LostFocus, txtLotno1.LostFocus, txtWeight.LostFocus, txtDesc.LostFocus, txtMarka.LostFocus, txtBroker.LostFocus, txtBrCode.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maskDate.Leave
        Try
            Dim dat As New Date
            dat = maskDate.Text
            If DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter Date in Current A/c Year")
                maskDate.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            maskDate.Focus()
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

   

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles masklotno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCheck.Focus()
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
            txtCheck.Focus()
            ListBox1.Visible = False
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

    Private Sub dg2_CellEnter1(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellEnter
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
                txttotalpcs.Text = dr.Item("Gpcs")
                txtTotalwidth.Text = dr.Item("Gmtr")
                txtCheck.Text = dr.Item("Check1")
            End While
            dr.Close()
            
        Catch ex As Exception
            '        MsgBox(ex.ToString)
        End Try
    End Sub
   

    Private Sub txttotalpcs_KeyDown(sender As Object, e As KeyEventArgs) Handles txttotalpcs.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            txtTotalwidth.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtMarka.Focus()
        End If
    End Sub

    Private Sub txttotalweight_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtDesc.Focus()
        End If
    End Sub

    Private Sub txtLrNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLrNo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then

            txtWeight.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtWidth.Focus()
        End If
    End Sub

    Private Sub txtWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWeight.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down Then
            txttotalpcs.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtLrNo.Focus()
        End If
    End Sub

    
    Private Sub txtTotalwidth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalwidth.KeyPress
        numbersonly(sender, e)

    End Sub

    Private Sub txttotalpcs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotalpcs.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub txtWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtWeight.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub txttotalpcs_Leave(sender As Object, e As EventArgs) Handles txttotalpcs.Leave
        numericform(sender)
    End Sub

    Private Sub txtTotalwidth_Leave(sender As Object, e As EventArgs) Handles txtTotalwidth.Leave
        numericform(sender)
    End Sub

    Private Sub txtWeight_Leave(sender As Object, e As EventArgs) Handles txtWeight.Leave
        numericformweight(sender)
    End Sub

    Private Sub dg2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox3.Visible = True
        TextBox20.Focus()
        TextBox20.Text = ""

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
en:
    End Sub


    Private Sub TextBox20_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox20.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button9.Focus()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        GroupBox3.Hide()
    End Sub

    Private Sub txtCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheck.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMst.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            masklotno.Focus()

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            CURRENTROW = dg2.CurrentCell.RowIndex
            If MessageBox.Show("You want to delete entry for VrNo=" & txtVrNo1.Text & txtVrNo2.Text, "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("delete from tblLotr where VrNo='" & txtVrNo1.Text & txtVrNo2.Text & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
                GroupBox3.Visible = False
                connect()
                Dim DA As New SqlDataAdapter
                Dim DS As New DataSet
                DA = New SqlDataAdapter("SELECT VrNo,Date,IchNo,Lotno,Gbalmtr,GbalPcs,Acname,Item,Gmtr,gpcs FROM TBLlOTR order by convert(INT,substring(vrno,4,LEN(vrno)-3))", cn)
                DA.Fill(DS)
                dg2.DataSource = DS.Tables(0)
                dg2.Columns(2).Width = 70
                dg2.Columns(1).Width = 80
                dg2.Columns(3).Width = 250

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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ListBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox2.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                txtMarka.Text = ListBox2.SelectedItem.ToString
                ListBox2.Visible = False
                txttotalpcs.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

 
End Class