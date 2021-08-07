Imports System.Data.SqlClient
Public Class frmUnitMaster
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim CLOSECHECK As Integer = 0

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtUcode.Clear()
            txtUnit.Clear()
            GroupBox1.Enabled = True
            myserialno("tblUnit", txtUcode, "SerialNo")
            txtUnit.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        txtUcode.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        txtUnit.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        GroupBox1.Enabled = True
        txtUnit.Focus()
    End Sub
    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            txtUcode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            txtUnit.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            GroupBox1.Enabled = True

        Catch ex As Exception

        End Try


    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            If txtUnit.Text.Trim.Length = 0 Then
                MsgBox("Unit can not be blank")
                txtUnit.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {txtUcode.Text, txtUnit.Text}
                If duplicate("tblUnit", "Unit", txtUnit) Then
                    MsgBox("Unit already exists")
                    txtUnit.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblUnit")
                myfilldatagrid(DG1, "tblUnit")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                If frmITMaster.unitcheck = 1 Then
                    frmITMaster.txtUnit.Text = txtUnit.Text
                    frmITMaster.Show()
                    frmITMaster.listType.Visible = False
                    frmITMaster.txtUnit.Focus()
                    frmITMaster.txtRate.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmITBalance.unitcheck = 1 Then
                    frmITBalance.txtUnit.Text = txtUnit.Text
                    frmITBalance.Show()
                    frmITBalance.ListBox1.Visible = False
                    frmITBalance.txtUnit.Focus()
                    frmITBalance.txtRemark.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                Else
                    txtUcode.Clear()
                    txtUnit.Clear()
                    myserialno("tblUnit", txtUcode, "SerialNo")
                    txtUnit.Focus()

                End If

            ElseIf check = 2 Then
                Dim a() As String = {txtUcode.Text, txtUnit.Text}
                If (duplicate("tblUnit", "Unit", txtUnit)) = True Then
                    MsgBox("Record already exists")
                    txtUnit.Focus()
                    GoTo en
                End If
                myupdate("tblUnit", a, "SerialNo", txtUcode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblUnit")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                txtUnit.Focus()
            End If
en:
        Catch ex As Exception
            ex.ToString()
        End Try

    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUcode.GotFocus, txtUnit.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUcode.LostFocus, txtUnit.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmUnitMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOSECHECK = 1 Then
            If frmITMaster.unitcheck = 1 Then
                frmITMaster.Show()
                frmITMaster.txtUnit.Focus()
            ElseIf frmITBalance.unitcheck = 1 Then
                frmITBalance.Show()
                frmITBalance.txtUnit.Focus()
            End If
        End If
    End Sub

    Private Sub frmUnitMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmUnitMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")


        Try
            If frmITMaster.unitcheck = 1 Or frmITBalance.unitcheck = 1 Then
                CLOSECHECK = 1
                butAdd.Enabled = True
                dg1.Enabled = False
                check = 1
                Label5.Text = "ADD Mode"
                txtUcode.Clear()
                txtUnit.Clear()
                GroupBox1.Enabled = True
                txtUnit.TabIndex = 0
                txtUnit.Focus()
                butAdd.TabIndex = 3
                myfilldatagrid(dg1, "tblUnit")
                myserialno("tblUnit", txtUcode, "SerialNo")
                txtUnit.Focus()
            Else
                butAdd.TabIndex = 0
                txtUnit.TabIndex = 2
                connect()
                myfilldatagrid(dg1, "tblUnit")
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

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        End If
    End Sub

    Private Sub butAdd_MouseHover(sender As Object, e As EventArgs) Handles butSave.MouseHover, butExit.MouseHover, butEdit.MouseHover, butAdd.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White

    End Sub

    Private Sub butAdd_MouseLeave(sender As Object, e As EventArgs) Handles butSave.MouseLeave, butExit.MouseLeave, butEdit.MouseLeave, butAdd.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black

    End Sub

    Private Sub butAdd_Enter(sender As Object, e As EventArgs) Handles butSave.Enter, butExit.Enter, butEdit.Enter, butAdd.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White

    End Sub

    Private Sub butAdd_Leave(sender As Object, e As EventArgs) Handles butSave.Leave, butExit.Leave, butEdit.Leave, butAdd.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black

    End Sub

    Private Sub frmUnitMaster_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'drawgradient(My.Settings.FormColor1, My.Settings.FormColor2, Me)
    End Sub
End Class