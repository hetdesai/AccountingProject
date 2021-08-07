Imports System.Data.SqlClient
Public Class frmStateMaster
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim CLOASECHECK As Integer = 0

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtScode.Clear()
            txtState.Clear()
            GroupBox1.Enabled = True
            myserialno("tblState", txtScode, "STCode")
            txtState.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        txtScode.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        txtState.Text = dg1.Item(1, i.Item(0).RowIndex).Value
        TextBox1.Text = txtState.Text
        GroupBox1.Enabled = True
        txtState.Focus()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        frmStateFind.Show()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            If txtState.Text.Trim.Length = 0 Then
                MsgBox("State can not be blank")
                txtState.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {txtScode.Text, txtState.Text}
                If duplicate("tblState", "STName", txtState) Then
                    MsgBox("State already exists")
                    txtState.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblState")
                myfilldatagrid(DG1, "tblState")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                If frmACMaster.stcheck = 1 Then
                    frmACMaster.listState.Visible = False
                    frmACMaster.Show()
                    frmACMaster.txtState.Text = txtState.Text
                    frmACMaster.txtState.Focus()
                    frmACMaster.txtGstno.Focus()
                    CLOASECHECK = 0
                    Me.Close()
                Else
                    txtScode.Clear()
                    txtState.Clear()
                    myserialno("tblState", txtScode, "STCode")
                    txtState.Focus()
                End If
            ElseIf check = 2 Then
                Dim a() As String = {txtScode.Text, txtState.Text}
                If (duplicate("tblState", "STName", txtState)) = True Then
                    MsgBox("Record already exists")
                    txtState.Focus()
                    GoTo en
                End If
                Try
                    connect()
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("Update tblAccount set state='" & txtState.Text & "' where state='" & TextBox1.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                Catch ex As Exception

                End Try
                myupdate("tblState", a, "STCode", txtScode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblState")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                txtState.Focus()
            End If
en:
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScode.GotFocus, txtState.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScode.LostFocus, txtState.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmStateMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOASECHECK = 1 Then
            If frmACMaster.stcheck = 1 Then
                frmACMaster.Show()
                frmACMaster.txtState.Focus()
            End If
        End If
    End Sub

    Private Sub frmStateMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmStateMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            If frmACMaster.stcheck = 1 Then
                CLOASECHECK = 1
                butAdd.Enabled = False
                butFind.Enabled = False
                butAdd.Enabled = False
                DG1.Enabled = False
                check = 1
                Label5.Text = "ADD Mode"
                txtScode.Clear()
                txtState.Clear()
                GroupBox1.Enabled = True
                myserialno("tblState", txtScode, "STCode")
                txtState.Focus()
            Else
                connect()
                myfilldatagrid(dg1, "tblState")
                Try
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try

                butAdd.Focus()

            End If
            '  If check = 1 Then
            'ElseIf check = 2 Then
            ' End If
        Catch ex As Exception
            MsgBox(ex.ToString)
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

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtState.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        End If
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            txtScode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            txtState.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            TextBox1.Text = txtState.Text
            GroupBox1.Enabled = True

        Catch ex As Exception

        End Try


    End Sub

    Private Sub butAdd_Enter(sender As Object, e As EventArgs) Handles butSave.Enter, butFind.Enter, butExit.Enter, butEdit.Enter, butAdd.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub butAdd_Leave(sender As Object, e As EventArgs) Handles butSave.Leave, butFind.Leave, butExit.Leave, butEdit.Leave, butAdd.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub butAdd_MouseHover(sender As Object, e As EventArgs) Handles butSave.MouseHover, butFind.MouseHover, butExit.MouseHover, butEdit.MouseHover, butAdd.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub butAdd_MouseLeave(sender As Object, e As EventArgs) Handles butSave.MouseLeave, butFind.MouseLeave, butExit.MouseLeave, butEdit.MouseLeave, butAdd.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub
End Class