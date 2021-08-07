Imports System.Data.SqlClient
Public Class frmMst
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim closecheck As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtMstCode.Clear()
            txtMstName.Clear()
            GroupBox1.Enabled = True
            myserialno("Mst", txtMstCode, "MstCode")
            txtMstName.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Try

            check = 2
            Label5.Text = "Edit Mode"
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            txtMstCode.Text = DG1.Item(0, i.Item(0).RowIndex).Value
            txtMstName.Text = DG1.Item(1, i.Item(0).RowIndex).Value
            TextBox3.Text = txtMstName.Text
            GroupBox1.Enabled = True
            txtMstName.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If txtMstName.Text.Trim.Length = 0 Then
                MsgBox("Mst Name Name can not be blank")
                txtMstName.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {txtMstCode.Text, txtMstName.Text}
                If duplicate("Mst", "Mst", txtMstName) Then
                    MsgBox("Mst already exists")
                    txtMstName.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "Mst")
                If frmACMaster.mstcheck = 1 Then
                    frmACMaster.Show()
                    frmACMaster.txtMst.Text = txtMstName.Text
                    closecheck = 0
                    frmACMaster.txtMst.Focus()
                    frmACMaster.txtMstcode.Focus()
                    frmACMaster.listMst.Visible = False
                    frmACMaster.butSave.Focus()
                    Me.Close()
                    GoTo en
                ElseIf frmlotr.mstcheck = 1 Then
                    frmlotr.Show()
                    frmlotr.txtMst.Text = txtMstName.Text
                    closecheck = 0
                    frmlotr.txtMst.Focus()
                    frmlotr.txtITName.Focus()
                    frmlotr.ListBox1.Visible = False
                    Me.Close()
                    GoTo en
                ElseIf frmLotNew.mstcheck = 1 Then
                    frmLotNew.Show()
                    frmLotNew.txtMst.Text = txtMstName.Text
                    closecheck = 0
                    frmLotNew.txtMst.Focus()
                    frmLotNew.txtITNAME.Focus()
                    frmLotNew.ListBox1.Visible = False
                    Me.Close()
                    GoTo en

                End If
                myfilldatagrid(DG1, "Mst")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                '   If frmITMaster.ittypecheck = 1 Then
                'frmITMaster.TextBox3.Text = TextBox2.Text
                ' frmITMaster.Show()
                'frmITMaster.ListBox1.Visible = False
                'frmITMaster.TextBox3.Focus()
                'frmITMaster.TextBox4.Focus()
                '     Me.Close()
                ' Else
                txtMstCode.Clear()
                txtMstName.Clear()
                myserialno("Mst", txtMstCode, "MstCode")
                txtMstName.Focus()

                'End If
            ElseIf check = 2 Then
                Dim a() As String = {txtMstCode.Text, txtMstName.Text}
                If (duplicate("Mst", "Mst", txtMstName)) = True Then
                    MsgBox("Mst already exists")
                    txtMstName.Focus()
                    GoTo en
                End If
                Try
                    connect()
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("update tblaccount set mstname='" & txtMstName.Text & "' where mstname='" & TextBox3.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("update tbllotr set mst='" & txtMstName.Text & "' where mst='" & TextBox3.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("update sale1 set mst='" & txtMstName.Text & "' where mst='" & TextBox3.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("update salec1 set mst='" & txtMstName.Text & "' where mst='" & TextBox3.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("update sale set mst='" & txtMstName.Text & "' where mst='" & TextBox3.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("update salesc set mst='" & txtMstName.Text & "' where mst='" & TextBox3.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
                myupdate("Mst", a, "MstCode", txtMstCode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "Mst")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                txtMstName.Focus()
            End If
en:     Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            txtMstCode.Text = DG1.Item(0, i.Item(0).RowIndex).Value
            txtMstName.Text = DG1.Item(1, i.Item(0).RowIndex).Value
            TextBox3.Text = txtMstName.Text
            GroupBox1.Enabled = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMstCode.GotFocus, txtMstName.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMstCode.LostFocus, txtMstName.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmMst_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If closecheck = 1 Then
            If frmACMaster.mstcheck = 1 Then
                frmACMaster.mstcheck = 0
                frmACMaster.Show()
            ElseIf frmlotr.mstcheck = 1 Then
                frmlotr.mstcheck = 0
                frmlotr.Show()
            ElseIf frmLotNew.mstcheck = 1 Then
                frmLotNew.mstcheck = 0
                frmLotNew.Show()
            End If


        End If
    End Sub

    Private Sub frmMst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DG1.DefaultCellStyle.BackColor = My.Settings.gridbackcolor
        DG1.DefaultCellStyle.ForeColor = My.Settings.gridforecolor
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = dateyf
        dateyl1.Text = dateyl
        If frmACMaster.mstcheck = 1 Or frmlotr.mstcheck = 1 Or frmLotNew.mstcheck = 1 Then
            closecheck = 1
            check = 1
            Label5.Text = "ADD Mode"
            txtMstCode.Clear()
            txtMstName.Clear()
            GroupBox1.Enabled = True
            myserialno("Mst", txtMstCode, "MstCode")
            GroupBox1.Focus()
            txtMstName.Focus()

        Else
            Try
                txtMstName.TabIndex = 1
                cmdAdd.TabIndex = 0
                cmdAdd.Focus()
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
                myfilldatagrid(DG1, "Mst")
                DG1.Columns(1).Width = 200
                Try
                    DG1.Item(0, DG1.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try
                cmdAdd.Focus()
                'End If
                'ElseIf check = 2 Then
                ' End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 1
        If timercount > 10 Then
            timercount = 0
            Timer1.Enabled = False
            Label2.Text = ""
        End If
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMstName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cmdAdd_Enter(sender As Object, e As EventArgs) Handles cmdEdit.Enter, cmdAdd.Enter, Button3.Enter, Button1.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub cmdAdd_Leave(sender As Object, e As EventArgs) Handles cmdEdit.Leave, cmdAdd.Leave, Button3.Leave, Button1.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub cmdAdd_MouseHover(sender As Object, e As EventArgs) Handles cmdEdit.MouseHover, cmdAdd.MouseHover, Button3.MouseHover, Button1.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub cmdAdd_MouseLeave(sender As Object, e As EventArgs) Handles cmdEdit.MouseLeave, cmdAdd.MouseLeave, Button3.MouseLeave, Button1.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub DG1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub
End Class