Imports System.Data.SqlClient
Public Class frmOpeningMaster
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim check As Integer
    Dim timercount As Integer
    Public acbalance As Integer
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If frmzoom7.zoom = True Then
            frmzoom7.Show()
        End If
        Me.Close()
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVrNo.GotFocus, txtAcname.GotFocus, txtAccode.GotFocus, txtAmount.GotFocus, txtType.GotFocus, txtDesc.GotFocus, maskDate.GotFocus
        Try
            sender.BackColor = Color.LightSteelBlue
            sender.forecolor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVrNo.LostFocus, txtAcname.LostFocus, txtAccode.LostFocus, txtAmount.LostFocus, txtType.LostFocus, txtDesc.LostFocus, maskDate.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub frmOpeningMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Then
        'SendKeys.Send("{TAB}")
        'End If
        If e.KeyCode = Keys.Escape Then
            If frmzoom7.zoom = True Then
                frmzoom7.Show()
            End If
            If frmnewzoom4.zoom1 = True Then
                frmnewzoom4.Close()
                frmnewzoom4.Show()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub frmOpeningMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            maskDate.Text = Format(dateyf, "dd-MM-yyyy")
            txtType.AutoCompleteCustomSource.Add("DR")
            txtType.AutoCompleteCustomSource.Add("CR")
            txtType.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtType.AutoCompleteSource = AutoCompleteSource.CustomSource
            connect()
            myfilldatagrid(DG1, "tblOPEN")
            Try
                DG1.Item(0, DG1.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try
            cmdAdd.Focus()
            'ElseIf check = 2 Then
            ' End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If txtAcname.Text <> txtcopyAcname.Text Then
                connect()
                cmd = New SqlCommand("Select * from tblOpen where Acname='" & txtAcname.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Close()
                    MsgBox("Can not insert opening balance twice")
                    GoTo en
                End If
                close1()
            End If
            Dim dr1 As Integer = 0
            Dim cr As Integer = 0
            If txtType.Text.ToUpper.ToString = ("DR") Then
                dr1 = txtAmount.Text
            ElseIf txtType.Text.ToUpper.ToString = ("CR") Then
                cr = txtAmount.Text
            Else
                MsgBox("Incorrect option")
                txtType.Focus()
                GoTo en
            End If
            Dim dat As New Date
            dat = maskDate.Text.ToString
            If txtAcname.Text.Trim.Length = 0 Then
                MsgBox("Account Name can not be blank")
                txtAcname.Focus()
                GoTo en
            End If
            If check = 1 Then
                connect()
                cmd = New SqlCommand("Select * from tblOpen where Acname='" & txtAcname.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Close()
                    MsgBox("Can not insert opening balance twice")
                    GoTo en
                End If
                close1()
                connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                cmdcheck = New SqlCommand("Select * from tblOpen where SerialNo=" & txtVrNo.Text, cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo en
                Else
                    drcheck.Close()
                End If
                close1()

                Dim a() As String = {txtVrNo.Text, txtAcname.Text, txtAccode.Text, txtAmount.Text, txtType.Text.ToUpper, txtDesc.Text, dat.Month & "-" & dat.Day & "-" & dat.Year}
                myinsert(a, "tblOPEN")
                Dim b() As String = {acycode & "/" & txtVrNo.Text, "OPBAL", dat.Month & "-" & dat.Day & "-" & dat.Year, txtAccode.Text, txtAcname.Text, dr1, cr, Val(cr - dr1), txtDesc.Text, "Ref", "OPBAL", 0}
                myinsert(b, "tblLedg")
                myfilldatagrid(DG1, "tblOPEN")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                txtVrNo.Clear()
                txtAcname.Clear()
                txtAccode.Clear()
                txtAmount.Clear()
                txtType.Text = "DR"
                txtDesc.Clear()
                maskDate.Clear()
                myserialno("tblOPEN", txtVrNo, "SerialNo")
                txtAcname.Focus()
            ElseIf check = 2 Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & acycode & "/" & txtVrNo.Text & "' and Book='OPBAL'", cn)
                cmd.ExecuteNonQuery()
                close1()
                Dim b() As String = {acycode & "/" & txtVrNo.Text, "OPBAL", dat.Month & "-" & dat.Day & "-" & dat.Year, txtAccode.Text, txtAcname.Text, dr1, cr, Val(cr - dr1), txtDesc.Text, "Ref", "OPBAL", 0}
                myinsert(b, "tblLedg")
                Dim a() As String = {txtVrNo.Text, txtAcname.Text, txtAccode.Text, txtAmount.Text, txtType.Text.ToUpper, txtDesc.Text, dat.Month & "-" & dat.Day & "-" & dat.Year}
                myupdate("tblOPEN", a, "SerialNo", txtVrNo.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblOPEN")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                txtAcname.Focus()
            End If
            maskDate.Text = fdat(dateyf.ToString)
en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtVrNo.Clear()
            txtAcname.Clear()
            txtAccode.Clear()
            txtAmount.Text = "0.00"
            txtType.Text = "DR"
            txtDesc.Clear()
            txtcopyAcname.Clear()
            myserialno("tblOPEN", txtVrNo, "SerialNo")
            GroupBox1.Enabled = True

            Dim dat As New Date
            If dateyf.Month < 10 Then
                If dateyf.Day < 10 Then
                    maskDate.Text = "0" & dateyf.Day & "0" & dateyf.Month & dateyf.Year
                Else
                    maskDate.Text = dateyf.Day & "0" & dateyf.Month & dateyf.Year
                End If
            Else
                maskDate.Text = dateyf.Day & dateyf.Month & dateyf.Year
            End If
            maskDate.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        frmMHfind.Close()
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        txtVrNo.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        txtAcname.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        txtAccode.Text = DG1.Item(2, i.Item(0).RowIndex).Value
        txtAmount.Text = DG1.Item(3, i.Item(0).RowIndex).Value
        txtType.Text = DG1.Item(4, i.Item(0).RowIndex).Value
        txtDesc.Text = DG1.Item(5, i.Item(0).RowIndex).Value
        maskDate.Text = fdat(DG1.Item(6, i.Item(0).RowIndex).Value)
        GroupBox1.Enabled = True
        ' ListBox1.Visible = False
        maskDate.Focus()
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEnter
        Try

            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            txtVrNo.Text = DG1.Item(0, e.RowIndex).Value
            txtAcname.Text = DG1.Item(1, e.RowIndex).Value
            txtAccode.Text = DG1.Item(2, e.RowIndex).Value
            txtAmount.Text = DG1.Item(3, e.RowIndex).Value
            txtType.Text = DG1.Item(4, e.RowIndex).Value
            txtDesc.Text = DG1.Item(5, e.RowIndex).Value
            txtcopyAcname.Text = txtAcname.Text
            maskDate.Text = fdat(DG1.Item(6, e.RowIndex).Value)

            '   If dat.Month < 10 Then
            'If dat.Day < 10 Then
            ' MaskedTextBox1.Text = "0" & dat.Day & "0" & dat.Month & dat.Year
            'Else
            'MaskedTextBox1.Text = dat.Day & "0" & dat.Month & dat.Year
            'End If
            'Else
            'MaskedTextBox1.Text = dat.Day & dat.Month & dat.Year
            'End If


            GroupBox1.Enabled = True
            '     MaskedTextBox1.Focus()
            ' ListBox1.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyUp
        ' myAutoComplete(TextBox2, ListBox1, "tblAccount", "ACName")
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
            dgacm.BringToFront()
            dgacm.Top = sender.Top + 22
            dgacm.Left = sender.Left
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAcname.Leave
        dr = myconselect("tblAccount", txtAcname.Text, "ACName")
        While dr.Read
            txtAccode.Text = dr.Item("ACCode")
        End While
        dr.Close()

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        'frmOpenFind.Show()
        GroupBox2.Visible = True
        txtFind.Focus()
        txtFind.Clear()
        tv1 = ""
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyDown
        If e.KeyCode = Keys.Down Then
            dgacm.Focus()
        ElseIf e.KeyCode = Keys.Enter Then
            If dgacm.Rows.Count <> 0 Then
                txtAcname.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                txtAmount.Focus()
                dgacm.Visible = False
            Else
                If MsgBox("Account not exits you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    acbalance = 1
                    frmACMaster.Show()
                    Me.Hide()
                Else
                    txtAcname.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Up Then
            dgacm.Visible = False
            maskDate.Focus()
        End If
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtAcname.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
            dgacm.Visible = False
            txtAcname.Focus()
            txtAmount.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcname.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtType.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAcname.Focus()
        End If
    End Sub
    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtType.Focus()
        End If
    End Sub
    Private Sub Button3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button3.KeyDown

    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDesc.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAmount.Focus()
        End If
    End Sub

    Private Sub TextBox4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        numericform(txtAmount)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 1
        If timercount > 10 Then
            timercount = 0
            Timer1.Enabled = False
            Label2.Text = ""
        End If
    End Sub

    Private Sub TextBox4_Keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dgacm.Visible = False
        If MsgBox("You want to delete opening balance for this A/c.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            connect()
            cmd = New SqlCommand("Delete from tblOpen where SerialNo=" & txtVrNo.Text, cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Delete from tblLedg where Book='OPBAL' and VrNo='" & acycode & "/" & txtVrNo.Text & "'", cn)
            cmd.ExecuteNonQuery()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select * from tblOpen", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            If DG1.RowCount <> 0 Then
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Focus()
            End If

            close1()
        End If


    End Sub
    Private Sub DG1_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles DG1.GiveFeedback
    End Sub

    Private Sub DG1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG1.GotFocus
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            txtVrNo.Text = DG1.Item(0, i.Item(0).RowIndex).Value
            txtAcname.Text = DG1.Item(1, i.Item(0).RowIndex).Value
            txtAccode.Text = DG1.Item(2, i.Item(0).RowIndex).Value
            txtAmount.Text = DG1.Item(3, i.Item(0).RowIndex).Value
            txtType.Text = DG1.Item(4, i.Item(0).RowIndex).Value
            txtDesc.Text = DG1.Item(5, i.Item(0).RowIndex).Value
            txtcopyAcname.Text = txtAcname.Text
            maskDate.Text = fdat(DG1.Item(6, i.Item(0).RowIndex).Value)

        Catch ex As Exception

        End Try
       

    End Sub

    Private Sub TextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtType.Leave
        txtType.Text = txtType.Text.ToUpper
        If txtType.Text <> "DR" And txtType.Text <> "CR" Then
            MsgBox("Select DR or CR Only")
            txtType.Focus()
        End If
    End Sub

    Private Sub dgacm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcname.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
            Dim dr As SqlDataReader
            dr = myconselect("tblAccount", txtAcname.Text, "ACName")
            While dr.Read
                txtAccode.Text = dr.Item("ACCode")
            End While
            txtAmount.Focus()
            dgacm.Visible = False

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
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
                If (DG1.Item(j, i).Value.ToString.ToLower.Contains(txtFind.Text.ToLower.ToString)) Then
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

    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        GroupBox2.Visible = False
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        If Val(txtAmount.Text) = 100000000000000.0 Then
            MsgBox("Not valid figure")
            txtAmount.Focus()
        End If
    End Sub

    Private Sub butPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrint.Click
        Me.Close()
        frmopeningfilter.Show()
    End Sub
End Class