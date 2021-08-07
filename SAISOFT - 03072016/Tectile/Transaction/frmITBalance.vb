Imports System.Data.SqlClient
Public Class frmITBalance
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim check As Integer
    Dim timercount As Integer
    Dim tb As Integer
    Public itbalance As Integer
    Public itbalanceunit As Integer
    Public unitcheck As Integer = 0
    Dim tv1 As String
    Dim temp1 As Integer = 0
    Dim temp2 As Integer = 0
    Private Sub butAdd_Enter(sender As Object, e As EventArgs) Handles butFind.Enter, butExit.Enter, butEdit.Enter, butDelete.Enter, butAdd.Enter, butsave.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub
    Private Sub butAdd_Leave(sender As Object, e As EventArgs) Handles butFind.Leave, butExit.Leave, butEdit.Leave, butDelete.Leave, butAdd.Leave, butsave.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub butAdd_MouseLeave(sender As Object, e As EventArgs) Handles butFind.MouseLeave, butExit.MouseLeave, butEdit.MouseLeave, butDelete.MouseLeave, butAdd.MouseLeave, butsave.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub butAdd_MouseHover(sender As Object, e As EventArgs) Handles butFind.MouseHover, butExit.MouseHover, butEdit.MouseHover, butDelete.MouseHover, butAdd.MouseHover, butsave.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVrNo.GotFocus, txtItName.GotFocus, txtItcode.GotFocus, txtQty.GotFocus, txtRate.GotFocus, txtUnit.GotFocus, txtRemark.GotFocus, txtDate.GotFocus
        Try
            sender.BackColor = Color.LightSteelBlue
            sender.forecolor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVrNo.LostFocus, txtItName.LostFocus, txtItcode.LostFocus, txtQty.LostFocus, txtRate.LostFocus, txtUnit.LostFocus, txtRemark.LostFocus, txtDate.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub frmITBalance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Then
        'SendKeys.Send("{TAB}")
        'End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmITBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            txtDate.Text = Format(dateyf, "dd-MM-yyyy")
            connect()
            myfilldatagrid(DG1, "tblItOpen")
            '   DG1.Item(0, DG1.RowCount - 1).Selected = True
            butAdd.Focus()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtVrNo.Clear()
            txtItName.Clear()
            txtItcode.Clear()
            txtQty.Text = 0.0
            txtRate.Text = 0.0
            txtUnit.Clear()
            txtRemark.Clear()
            myserialno("tblItOpen", txtVrNo, "VRNO")
            GroupBox1.Enabled = True
            txtItName.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        txtDate.Text = Format(DG1.Item(0, i.Item(0).RowIndex).Value, "dd-MM-yyyy")
        txtVrNo.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        txtItName.Text = DG1.Item(2, i.Item(0).RowIndex).Value
        txtItcode.Text = DG1.Item(3, i.Item(0).RowIndex).Value
        txtQty.Text = DG1.Item(4, i.Item(0).RowIndex).Value
        txtRate.Text = DG1.Item(5, i.Item(0).RowIndex).Value
        txtUnit.Text = DG1.Item(6, i.Item(0).RowIndex).Value
        txtRemark.Text = DG1.Item(7, i.Item(0).RowIndex).Value
        TextBox9.Text = txtItName.Text
        GroupBox1.Enabled = True
        ListBox1.Visible = False
        txtItName.Focus()
    End Sub
    Function validate() As Boolean
        If txtDate.Text.Length = 0 Then
            MsgBox("Date can not be blank")
            txtDate.Focus()
            Return False
        ElseIf txtItName.Text.Length = 0 Then
            MsgBox("Item Name can not be blank")
            txtItName.Focus()
            Return False
        ElseIf Val(txtQty.Text) = 0 Then
            MsgBox("Item QTY can not be zero")
            txtQty.Focus()
            Return False
        ElseIf Val(txtRate.Text) = 0 Then
            MsgBox("Item Rate can not be zero")
            txtRate.Focus()
            Return False
        ElseIf txtUnit.Text.Length = 0 Then
            MsgBox("Item Unit can not be blank")
            txtUnit.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            If validate() Then
            Else
                GoTo en
            End If
            Dim dat As New Date
            dat = txtDate.Text
            If txtItName.Text.Trim.Length = 0 Then
                MsgBox("Item Name can not be blank")
                txtItName.Focus()
                GoTo en
            End If
            If check = 1 Then
                connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                cmdcheck = New SqlCommand("select * from tblitopen where vrno=" & txtVrNo.Text, cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo en
                Else
                    drcheck.Close()
                End If
                cmdcheck = New SqlCommand("select * from tblitopen where item='" & txtItName.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Can not insert opening stock for same item twise")
                    txtItName.Focus()
                    GoTo en
                Else
                    drcheck.Close()

                End If

                close1()

                Dim a() As String = {dat.Month & "-" & dat.Day & "-" & dat.Year, txtVrNo.Text, txtItName.Text, txtItcode.Text, txtQty.Text, txtRate.Text, txtUnit.Text, txtRemark.Text}
                myinsert(a, "tblItOpen")
                connect()
                Dim cmdit As New SqlCommand
                Dim drit As SqlDataReader
                cmdit = New SqlCommand("Select ittype from tblItem where ITName='" & txtItName.Text & "'", cn)
                drit = cmdit.ExecuteReader
                Dim ittype As String
                While drit.Read
                    ittype = drit.Item(0)
                End While
                drit.Close()
                '  MsgBox(TextBox1.Text)
                Dim b() As String = {dat.Month & "-" & dat.Day & "-" & dat.Year, "Opening", txtVrNo.Text, txtItName.Text, ittype, txtQty.Text, txtRate.Text, Val(txtQty.Text) * Val(txtRate.Text), 0.0, 0.0, 0.0}
                myinsert(b, "tblStock")
                myfilldatagrid(DG1, "tblItOpen")
                Try
                    DG1.Item(0, DG1.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                txtVrNo.Clear()
                txtItName.Clear()
                txtItcode.Clear()
                txtQty.Clear()
                txtRate.Clear()
                txtUnit.Clear()
                txtRemark.Clear()
                myserialno("tblItOpen", txtVrNo, "VRNO")
                txtItName.Focus()
            ElseIf check = 2 Then
                Dim a() As String = {txtDate.Text, txtVrNo.Text, txtItName.Text, txtItcode.Text, txtQty.Text, txtRate.Text, txtUnit.Text, txtRemark.Text}
                myupdate("tblItOpen", a, "VRNO", txtVrNo.Text)
                Dim cmd As New SqlCommand
                connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                If txtItName.Text.ToUpper <> TextBox9.Text.ToUpper Then
                    cmdcheck = New SqlCommand("select * from tblitopen where item='" & txtItName.Text & "'", cn)
                    drcheck = cmdcheck.ExecuteReader
                    If drcheck.HasRows Then
                        drcheck.Close()
                        MsgBox("Can not insert opening stock for same item twise")
                        GoTo en
                    Else
                        drcheck.Close()
                    End If
                End If
                cmd = New SqlCommand("Delete from tblStock where VrNo='" & txtVrNo.Text & "' and Book='" & "Opening" & "'", cn)
                cmd.ExecuteNonQuery()
                Dim cmdit As New SqlCommand
                Dim drit As SqlDataReader
                cmdit = New SqlCommand("Select ittype from tblItem where ITName='" & txtItName.Text & "'", cn)
                drit = cmdit.ExecuteReader
                Dim ittype As String
                While drit.Read
                    ittype = drit.Item(0)
                End While
                drit.Close()
                close1()
                Dim b() As String = {dat.Month & "-" & dat.Day & "-" & dat.Year, "Opening", txtVrNo.Text, txtItName.Text, ittype, txtQty.Text, txtRate.Text, txtRemark.Text, 0.0, 0.0, 0.0}
                myinsert(b, "tblStock")
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblItOpen")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                txtItName.Focus()
            End If
en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItName.KeyUp
        myAutoComplete(txtItName, ListBox1, "tblItem", "ITName")
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItName.Leave
        Try
            Dim dr As SqlDataReader
            dr = myconselect("tblItem", txtItName.Text, "ITName")
            While dr.Read
                txtItcode.Text = dr.Item("ITCode")
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        'frmItBalanceFind.Show()
        GroupBox2.Visible = True
        TextBox10.Focus()
        TextBox10.Clear()
        tv1 = ""

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItName.KeyDown
        If e.KeyCode = Keys.Down Then
            ListBox1.Focus()
            ListBox1.SelectedIndex = 0
            tb = 2
        ElseIf e.KeyCode = Keys.Enter Then
            If ListBox1.Items.Count <> 0 Then
                txtItName.Text = ListBox1.Items(0).ToString
                ListBox1.Visible = False
                txtQty.Focus()
            Else
                If MsgBox("Item not exits you want to add new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    itbalance = 1
                    Me.Hide()
                    frmITMaster.Show()
                End If
            End If
        ElseIf e.KeyCode = Keys.Up Then
            ListBox1.Visible = False
            txtDate.Focus()
        End If

    End Sub
    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnit.KeyDown
        If e.KeyCode = Keys.Down Then

            Try
                ListBox1.SelectedIndex = 0
                ListBox1.Focus()
                tb = 6
            Catch ex As Exception
                txtUnit.Focus()
            End Try


        ElseIf e.KeyCode = Keys.Enter Then
            If ListBox1.Items.Count <> 0 Then
                txtUnit.Text = ListBox1.Items(0).ToString
                ListBox1.Visible = False
                txtRemark.Focus()
            Else
                If MsgBox(" you want to add new Unit", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    unitcheck = 1
                    Me.Hide()
                    frmUnitMaster.Show()
                Else

                End If
            End If
        ElseIf e.KeyCode = Keys.Up Then
            ListBox1.Visible = False
            txtRate.Focus()
        End If
    End Sub
    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnit.KeyUp
        myAutoComplete(txtUnit, ListBox1, "tblUnit", "Unit")
    End Sub
    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If tb = 2 Then
                    txtItName.Text = ListBox1.SelectedItem.ToString
                    ListBox1.Visible = False
                    txtItName.Focus()
                    txtQty.Focus()
                ElseIf tb = 6 Then
                    txtUnit.Text = ListBox1.SelectedItem.ToString
                    ListBox1.Visible = False
                    txtUnit.Focus()
                    txtRemark.Focus()
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRate.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtItName.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUnit.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtQty.Focus()
        End If
    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtUnit.Focus()
        End If
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.Leave
        numericform(txtRate)
    End Sub

    Private Sub TextBox4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.Leave
        Try
            txtQty.Text = Format(Val(txtQty.Text), "0.000")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 1
        If timercount > 10 Then
            timercount = 0
            Timer1.Enabled = False
            Label2.Text = ""
        End If
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.RowEnter
        Try
            'check = 2
            ' Label5.Text = "Edit Mode"
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            txtDate.Text = Format(DG1.Item(0, e.RowIndex).Value, "dd-MM-yyyy")
            txtVrNo.Text = DG1.Item(1, e.RowIndex).Value
            txtItName.Text = DG1.Item(2, e.RowIndex).Value
            txtItcode.Text = DG1.Item(3, e.RowIndex).Value
            txtQty.Text = DG1.Item(4, e.RowIndex).Value
            txtRate.Text = DG1.Item(5, e.RowIndex).Value
            txtUnit.Text = DG1.Item(6, e.RowIndex).Value
            txtRemark.Text = DG1.Item(7, e.RowIndex).Value
            TextBox9.Text = txtItName.Text
            GroupBox1.Enabled = True
            ListBox1.Visible = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemark.Leave
        'numericform(txtRemark)
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtItName.Focus()
        End If
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress, txtRate.KeyPress, txtRemark.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            If MsgBox("Are you sure want to delete entry", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                connect()
                cmd = New SqlCommand("Delete from tblStock where VrNo='" & txtVrNo.Text & "' and Book='" & "Opening" & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblITOpen where VrNo=" & txtVrNo.Text, cn)
                cmd.ExecuteNonQuery()
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("Select * from tblItopen", cn)
                da.Fill(ds)
                DG1.DataSource = ds.Tables(0)
                If DG1.RowCount <> 0 Then
                    DG1.Item(0, DG1.RowCount - 1).Selected = True
                Else
                    txtItName.Clear()
                    txtVrNo.Clear()
                    txtItcode.Clear()
                    txtQty.Clear()
                    txtRate.Clear()
                    txtUnit.Clear()
                    txtRemark.Clear()
                    txtDate.Clear()
                End If

                close1()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox10.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox10.Text
        For i = temp1 To DG1.Rows.Count - 1
            For j = temp2 To DG1.ColumnCount - 1
                If (DG1.Item(j, i).Value.ToString.ToLower.Contains(TextBox10.Text.ToLower.ToString)) Then
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        GroupBox2.Visible = False
    End Sub

    Private Sub TextBox10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyUp
        If Val(txtQty.Text) > 999999999999.999 Then
            MsgBox("Not valid figure")
            txtQty.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyUp
        If Val(txtRate.Text) > 999999999.999 Then
            MsgBox("Not valid figure")
            txtRate.Focus()
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub butPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrint.Click
        frmPrintItemOpening.Show()
        Me.Close()

    End Sub
End Class
