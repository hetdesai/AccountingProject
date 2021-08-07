Imports System.Data.SqlClient
Public Class frmstyle
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim closecheck As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtScode.Clear()
            txtStyle.Clear()
            GroupBox1.Enabled = True
            myserialno("stylemst", txtScode, "stycode")
            txtStyle.Focus()
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
        txtStyle.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        GroupBox1.Enabled = True
        txtStyle.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            If txtStyle.Text.Trim.Length = 0 Then
                MsgBox("style Name Name can not be blank")
                txtStyle.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {txtScode.Text, txtStyle.Text}
                If duplicate("stylemst", "style", txtStyle) Then
                    MsgBox("style already exists")
                    txtStyle.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "stylemst")
                If frmACMaster.mstcheck = 1 Then
                    frmACMaster.Show()
                    frmACMaster.txtMst.Text = txtStyle.Text
                    closecheck = 0
                    frmACMaster.txtMst.Focus()
                    frmACMaster.txtMstcode.Focus()
                    frmACMaster.listMst.Visible = False
                    frmACMaster.butSave.Focus()
                    Me.Close()
                    GoTo en
                End If
                myfilldatagrid(DG1, "stylemst")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                txtScode.Clear()
                txtStyle.Clear()
                myserialno("stylemst", txtScode, "stycode")
                txtStyle.Focus()

                'End If
            ElseIf check = 2 Then
                Dim a() As String = {txtScode.Text, txtStyle.Text}
                If (duplicate("stylemst", "style", txtStyle)) = True Then
                    MsgBox("style already exists")
                    txtStyle.Focus()
                    GoTo en
                End If
                myupdate("stylemst", a, "stycode", txtScode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "stylemst")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                txtStyle.Focus()
            End If
en:     Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            txtScode.Text = DG1.Item(0, i.Item(0).RowIndex).Value
            txtStyle.Text = DG1.Item(1, i.Item(0).RowIndex).Value
            GroupBox1.Enabled = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScode.GotFocus, txtStyle.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScode.LostFocus, txtStyle.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmMst_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If closecheck = 1 Then
            frmACMaster.mstcheck = 1
            frmACMaster.Show()
        End If
    End Sub

    Private Sub frmMst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = dateyf
        dateyl1.Text = dateyl
        If frmACMaster.mstcheck = 1 Then
            closecheck = 1
        End If

        Try
            '  If check = 1 Then
            '  If frmITMaster.ittypecheck = 1 Then
            '   cmdAdd.Enabled = False
            '  cmdEdit.Enabled = False
            ' cmdFind.Enabled = False
            ' DG1.Enabled = False
            ' check = 1
            ' Label5.Text = "ADD Mode"
            ' TextBox1.Clear()
            ' TextBox2.Clear()
            ' GroupBox1.Enabled = True
            ' myserialno("tblITType", TextBox1, "TPCode")
            ' TextBox2.Focus()
            ' Else
            connect()
            myfilldatagrid(DG1, "stylemst")
            Try
                DG1.Item(0, DG1.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try

            butAdd.Focus()

            'End If
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

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStyle.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        End If
    End Sub
End Class