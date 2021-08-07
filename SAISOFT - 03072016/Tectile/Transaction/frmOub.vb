Imports System.Data.SqlClient
Public Class frmoub
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim check As Integer
    Dim timercount As Integer
    Public acbalance As Integer = 0
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub frmOpeningMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmOpeningMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
        comoubyear.Items.Add(acycode - 1 & "/")
        comoubyear.Items.Add(acycode - 2 & "/")
        comoubyear.Items.Add(acycode - 3 & "/")
        comoubyear.Items.Add(acycode - 4 & "/")
        comoubyear.Items.Add(acycode - 5 & "/")
        comBook.SelectedIndex = 0
        comoubyear.SelectedIndex = 0
        'ComboBox2.Text = ComboBox2.Items(ComboBox2.Items(ComboBox2.Items.Count - 1))
        Try
            maskDate.Text = dateyf
            txtType.AutoCompleteCustomSource.Add("DR")
            txtType.AutoCompleteCustomSource.Add("CR")
            txtType.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtType.AutoCompleteSource = AutoCompleteSource.CustomSource
            connect()
            myfilldatagrid(DG1, "tblOub")
            DG1.Item(0, DG1.RowCount - 1).Selected = True
            butAdd.Focus()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            Dim dr1 As Decimal = 0
            Dim cr As Decimal = 0
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
            Dim dat2 As New Date
            dat = maskDate.Text.ToString
            dat2 = MaskedTextBox1.Text.ToString
            If txtAcname.Text.Trim.Length = 0 Then
                MsgBox("Account Name can not be blank")
                txtAcname.Focus()
                GoTo en
            End If
            If check = 1 Then
                connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck1 As SqlDataReader
                cmdcheck = New SqlCommand("select * from tblOub where VrNo='" & txtVrnofirst.Text & txtVrnoSec.Text & "'", cn)
                drcheck1 = cmdcheck.ExecuteReader
                If drcheck1.HasRows Then
                    drcheck1.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo en
                Else
                    drcheck1.Close()
                End If
                close1()
                connect()
                cmdcheck = New SqlCommand("Select * from tblOpen where Acname='" & txtAcname.Text & "'", cn)
                drcheck1 = cmdcheck.ExecuteReader
                If drcheck1.HasRows = True Then
                    drcheck1.Close()
                    close1()
                    GoTo update
                Else
                    drcheck1.Close()
                    close1()

                    GoTo add
                End If
                Dim dramt As Decimal
                Dim cramt As Decimal
                If txtType.Text.ToUpper = "DR" Then
                    dramt = Val(txtAmount.Text)
                    cramt = 0
                Else
                    dramt = 0
                    cramt = Val(txtAmount.Text)
                End If
add:
                
             



update:
                connect()
                cmdcheck = New SqlCommand("Update tblOpen set amount=amount+" & txtAmount.Text & " where acname='" & txtAcname.Text & "' and accode=" & txtAccode.Text, cn)
                cmdcheck.ExecuteNonQuery()
                Dim dramt1 As Decimal
                Dim cramt1 As Decimal
                close1()
                Dim a1() As String = {txtVrnofirst.Text & txtVrnoSec.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, comBook.Text, txtAcname.Text, txtAccode.Text, txtAmount.Text, txtType.Text.ToUpper, txtDesc.Text, txtBkname.Text, txtBkcode.Text, comoubyear.Text & txtOubnosec.Text, Val(txtAmount.Text), "f"}
                myinsert(a1, "tbloub")
                

                myfilldatagrid(DG1, "tblOub")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"

                maxVrNo(txtVrnoSec, "tblOub")
                comBook.Focus()
                txtVrnofirst.Text = "10/"
            ElseIf check = 2 Then
                Dim DRCHECK As Decimal
                Dim CRCHECK As Decimal
                connect()
                If txtType.Text = "DR" Then
                    DRCHECK = Val(txtAmount.Text)
                    CRCHECK = 0
                Else
                    CRCHECK = Val(txtAmount.Text)
                    DRCHECK = 0
                End If
                Dim cmd As New SqlCommand
                close1()
                Dim a() As String = {txtVrnofirst.Text & txtVrnoSec.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, comBook.Text, txtAcname.Text, txtAccode.Text, txtAmount.Text, txtType.Text.ToUpper, txtDesc.Text, txtBkname.Text, txtBkcode.Text, comoubyear.Text & txtOubnosec.Text, Val(txtAmount.Text), "f"}
                myupdate("tblOub", a, "VrNo", txtVrnofirst.Text & txtVrnoSec.Text)

               
               
            End If
           
            maskDate.Focus()
            Dim cmd1 As New SqlCommand
            Dim dr11 As SqlDataReader
            Dim ledgdr As Decimal
            Dim ledgcr As Decimal

            connect()
            cmd1 = New SqlCommand("Delete from tblLedg where book='OPBAL' and acname='" & txtAcname.Text & "'", cn)
            cmd1.ExecuteNonQuery()
            cmd1 = New SqlCommand("Delete from tblopen where acname='" & txtAcname.Text & "'", cn)
            cmd1.ExecuteNonQuery()
            cmd1 = New SqlCommand("Select sum(netamt) from tblOub where acname='" & txtAcname.Text & "' and type='DR'", cn)
            dr11 = cmd1.ExecuteReader
            While dr11.Read
                Try
                    ledgdr = dr11.Item(0)

                Catch ex As Exception

                End Try

            End While
            dr11.Close()
            cmd1 = New SqlCommand("Select sum(netamt) from tblOub where acname='" & txtAcname.Text & "' and type='CR'", cn)
            dr11 = cmd1.ExecuteReader
            While dr11.Read
                Try
                    ledgcr = dr11.Item(0)
                Catch ex As Exception

                End Try

            End While
            dr11.Close()

            If ledgdr > ledgcr Then
                Dim b() As String = {acycode & "/" & txtVrnoSec.Text, "OPBAL", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccode.Text, txtAcname.Text, ledgdr - ledgcr, 0, -(ledgdr - ledgcr), txtDesc.Text, "Ref", "OPBAL", 0}
                myinsert(b, "tblLedg")
                Dim textbox1 As New TextBox
                myserialno("tblOPEN", textbox1, "SerialNo")
                Dim a() As String = {textbox1.Text, txtAcname.Text, txtAccode.Text, ledgdr - ledgcr, "DR", "", dat2.Month & "-" & dat2.Day & "-" & dat2.Year}
                myinsert(a, "tblOPEN")
            ElseIf ledgcr > ledgdr Then
                Dim b() As String = {acycode & "/" & txtVrnoSec.Text, "OPBAL", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccode.Text, txtAcname.Text, 0, ledgcr - ledgdr, ledgcr - ledgdr, txtDesc.Text, "Ref", "OPBAL", 0}
                myinsert(b, "tblLedg")
                Dim textbox1 As New TextBox
                myserialno("tblOPEN", textbox1, "SerialNo")
                Dim a() As String = {textbox1.Text, txtAcname.Text, txtAccode.Text, ledgcr - ledgdr, "CR", "", dat2.Month & "-" & dat2.Day & "-" & dat2.Year}
                myinsert(a, "tblOPEN")
            Else

            End If
            close1()
            Dim rowi As Integer
            Dim coli As Integer
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            rowi = i.Item(0).RowIndex
            coli = i.Item(0).ColumnIndex
            myfilldatagrid(DG1, "tblOub")
            Timer1.Enabled = True
            Label2.Text = "UPDATE"
            ' DG1.Item(coli, rowi).Selected = True
            comBook.Focus()
            '  MaskedTextBox1.Text = dateyf
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
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtVrnofirst.Text = "10/"
            txtAcname.Clear()
            txtAccode.Clear()
            txtAmount.Text = "0.00"
            txtType.Clear()
            txtDesc.Clear()
            maxVrNo(txtVrnoSec, "tbloub")
            GroupBox1.Enabled = True
            maskDate.Focus()
            maskDate.Text = Format(dateyf, "dd-MM-yyyy")
            maskDate.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        frmMHfind.Close()
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        txtVrnoSec.Text = DG1.Item(0, i.Item(0).RowIndex).Value.ToString.Substring(3)
        maskDate.Text = Format(DG1.Item(1, i.Item(0).RowIndex).Value, "dd-MM-yyyy")
        comBook.Text = DG1.Item(2, i.Item(0).RowIndex).Value
        txtAcname.Text = DG1.Item(3, i.Item(0).RowIndex).Value
        txtAccode.Text = DG1.Item(4, i.Item(0).RowIndex).Value
        txtAmount.Text = DG1.Item(5, i.Item(0).RowIndex).Value
        txtType.Text = DG1.Item(6, i.Item(0).RowIndex).Value
        txtDesc.Text = DG1.Item(7, i.Item(0).RowIndex).Value
        GroupBox1.Enabled = True
        dgacm.Visible = False
        maskDate.Focus()
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.RowEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            txtVrnoSec.Text = DG1.Item(0, e.RowIndex).Value.ToString.Substring(3)
            maskDate.Text = Format(DG1.Item(1, e.RowIndex).Value, "dd-MM-yyyy")
            comBook.Text = DG1.Item(2, e.RowIndex).Value
            comcopyBook.Text = DG1.Item(2, e.RowIndex).Value
            txtAcname.Text = DG1.Item(3, e.RowIndex).Value
            txtAccode.Text = DG1.Item(4, e.RowIndex).Value
            txtAmount.Text = DG1.Item(5, e.RowIndex).Value
            txtType.Text = DG1.Item(6, e.RowIndex).Value
            txtDesc.Text = DG1.Item(7, e.RowIndex).Value
            txtBkname.Text = DG1.Item(8, e.RowIndex).Value
            txtBkcode.Text = DG1.Item(9, e.RowIndex).Value
            txtOubnosec.Text = DG1.Item(10, e.RowIndex).Value.ToString.Substring(3)
            comoubyear.Text = DG1.Item(10, e.RowIndex).Value.ToString.Substring(0, 3)
            GroupBox1.Enabled = True
            '     MaskedTextBox1.Focus()
            dgacm.Visible = False
        Catch ex As Exception
            '    MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyUp
        '     myAutoComplete(TextBox2, ListBox1, "tblAccount", "ACName")
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

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        frmOpenFind.Show()

    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyDown
        If e.KeyCode = Keys.Down Then
            dgacm.Focus()
            dgacm.Item(1, 0).Selected = True
        ElseIf e.KeyCode = Keys.Enter Then
            If dgacm.Rows.Count <> 0 Then
                txtAcname.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                dgacm.Visible = False
                txtAmount.Focus()
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
            comBook.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskDate.GotFocus
        maskDate.SelectionStart = 0
        maskDate.SelectionLength = 0
    End Sub
    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            '  TextBox2.Focus()
            comBook.Focus()
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
            butSave.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtType.Focus()
        End If
    End Sub
    Private Sub Button3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butSave.KeyDown

    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDesc.Focus()
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

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comBook.KeyDown
        If e.KeyCode = Keys.Enter Then
            comoubyear.Focus()
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select  ACNAme from tblAccount where Book='" & comBook.Text & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            txtBkname.AutoCompleteCustomSource.Clear()
            While dr.Read
                txtBkname.AutoCompleteCustomSource.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        End If
    End Sub

    Private Sub TextBox8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkname.Leave
        txtBkname.Text = txtBkname.Text.ToUpper()
    End Sub

    Private Sub TextBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkname.LostFocus
        Try
            connect()
            cmd = New SqlCommand("Select * from tblAccount where ACNAme='" & txtBkname.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtBkcode.Text = dr.Item("ACCode")
            End While
            dr.Close()
            close1()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        numbersonly(sender, e)
    End Sub

    Private Sub ComboBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comoubyear.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOubnosec.Focus()
        End If
    End Sub

    Private Sub TextBox10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOubnosec.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBkname.Focus()
        ElseIf e.KeyCode = Keys.Up Then
        End If
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBkname.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcname.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtBkname.Focus()
        End If
    End Sub

    Private Sub cmdAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles butAdd.GotFocus, butEdit.GotFocus, butExit.GotFocus, butFind.GotFocus, butSave.GotFocus
        sender.BackColor = Color.Blue
        sender.ForeColor = Color.White
    End Sub
    Private Sub cmdAdd_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles butAdd.LostFocus, butEdit.LostFocus, butExit.LostFocus, butFind.LostFocus, butSave.LostFocus
        sender.BackColor = Color.Crimson
        sender.ForeColor = Color.White
    End Sub

    Private Sub dgacm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            If MsgBox("You want to delete this entry", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim dat2 As New Date

                dat2 = MaskedTextBox1.Text.ToString
                connect()
                Dim cmd As New SqlCommand
                 cmd = New SqlCommand("Delete from tblOub where VrNo='" & txtVrnofirst.Text & txtVrnoSec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                Dim cmd1 As New SqlCommand
                Dim dr11 As SqlDataReader
                Dim ledgdr As Decimal
                Dim ledgcr As Decimal

                connect()
                cmd1 = New SqlCommand("Delete from tblLedg where book='OPBAL' and acname='" & txtAcname.Text & "'", cn)
                cmd1.ExecuteNonQuery()
                cmd1 = New SqlCommand("Delete from tblopen where acname='" & txtAcname.Text & "'", cn)
                cmd1.ExecuteNonQuery()
                cmd1 = New SqlCommand("Select sum(netamt) from tblOub where acname='" & txtAcname.Text & "' and type='DR'", cn)
                dr11 = cmd1.ExecuteReader
                While dr11.Read
                    Try
                        ledgdr = dr11.Item(0)

                    Catch ex As Exception

                    End Try

                End While
                dr11.Close()
                cmd1 = New SqlCommand("Select sum(netamt) from tblOub where acname='" & txtAcname.Text & "' and type='CR'", cn)
                dr11 = cmd1.ExecuteReader
                While dr11.Read
                    Try
                        ledgcr = dr11.Item(0)
                    Catch ex As Exception

                    End Try

                End While
                dr11.Close()

                If ledgdr > ledgcr Then
                    Dim b() As String = {acycode & "/" & txtVrnoSec.Text, "OPBAL", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccode.Text, txtAcname.Text, ledgdr - ledgcr, 0, -(ledgdr - ledgcr), txtDesc.Text, "Ref", "OPBAL", 0}
                    myinsert(b, "tblLedg")
                    Dim textbox1 As New TextBox
                    myserialno("tblOPEN", textbox1, "SerialNo")
                    Dim a() As String = {textbox1.Text, txtAcname.Text, txtAccode.Text, ledgdr - ledgcr, "DR", "", dat2.Month & "-" & dat2.Day & "-" & dat2.Year}
                    myinsert(a, "tblOPEN")
                ElseIf ledgcr > ledgdr Then
                    Dim b() As String = {acycode & "/" & txtVrnoSec.Text, "OPBAL", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccode.Text, txtAcname.Text, 0, ledgcr - ledgdr, ledgcr - ledgdr, txtDesc.Text, "Ref", "OPBAL", 0}
                    myinsert(b, "tblLedg")
                    Dim textbox1 As New TextBox
                    myserialno("tblOPEN", textbox1, "SerialNo")
                    Dim a() As String = {textbox1.Text, txtAcname.Text, txtAccode.Text, ledgcr - ledgdr, "CR", "", dat2.Month & "-" & dat2.Day & "-" & dat2.Year}
                    myinsert(a, "tblOPEN")
                Else

                End If

                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("Select * from tblOub", cn)
                da.Fill(ds)
                DG1.DataSource = ds.Tables(0)
                Try
                    DG1.Item(0, DG1.RowCount - 1).Selected = True
                Catch ex As Exception
                    txtAccode.Clear()
                    txtAcname.Clear()
                    txtDesc.Clear()
                    txtBkcode.Clear()
                    txtBkname.Clear()
                    txtType.Clear()
                    txtOubnosec.Clear()
                    txtVrnofirst.Clear()
                    txtVrnoSec.Clear()
                    comBook.Text = ""
                    comcopyBook.Text = ""
                End Try
                close1()
                MsgBox("Deleted")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub MaskedTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maskDate.Enter
        maskDate.SelectionStart = 0

    End Sub

    Private Sub comBook_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comBook.SelectedIndexChanged
        If check = 2 Then
            If comBook.Text.ToLower <> comcopyBook.Text.ToLower Then
                txtBkname.Text = ""
                txtBkcode.Text = "0"
            End If
        End If
    End Sub

    Private Sub butPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrint.Click
        Me.Close()
        frmprintprev.Show()
    End Sub

    
    Private Sub txtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub maskDate_Leave(sender As Object, e As EventArgs) Handles maskDate.Leave
        Try

            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime
            dat1 = dateyf
            dat2 = dateyl
            dat = maskDate.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                MsgBox("Enter date in previous year")
                maskDate.Focus()
            Else


            End If
        Catch ex As Exception
            MsgBox("Enter proper date")
        End Try
    End Sub
End Class