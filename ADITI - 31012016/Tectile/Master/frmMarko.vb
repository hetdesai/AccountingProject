﻿Imports System.Data.SqlClient
Public Class frmMarko
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
            TextBox1.Clear()
            TextBox2.Clear()
            GroupBox1.Enabled = True
            myserialno("mrkmst", TextBox1, "mrkcode")
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        TextBox1.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        TextBox2.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        GroupBox1.Enabled = True
        TextBox2.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TextBox2.Text.Trim.Length = 0 Then
                MsgBox("marka Name Name can not be blank")
                TextBox2.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If duplicate("mrkmst", "marka", TextBox2) Then
                    MsgBox("marka already exists")
                    TextBox2.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "mrkmst")
                If frmACMaster.markacheck = 1 Then
                    frmACMaster.Show()
                    frmACMaster.txtMarka.Text = TextBox2.Text
                    closecheck = 0
                    frmACMaster.txtMst.Focus()
                    frmACMaster.listMarka.Visible = False
                    'frmACMaster.Button3.Focus()
                    Me.Close()
                    GoTo en
                ElseIf frmlotr.markacheck = 1 Then
                    frmlotr.Show()
                    frmlotr.txtMarka.Text = TextBox2.Text
                    closecheck = 0
                    frmlotr.txtMarka.Focus()
                    frmlotr.ListBox2.Visible = False
                    If frmlotr.Label12.Text = "ADD MODE" Then
                        frmlotr.DG1.Rows.Clear()
                        frmlotr.DG1.Rows.Add()
                        ' If e.KeyCode = Keys.Enter Then
                        DG1.Item(0, 0).Value = 1
                        DG1.Item(1, 0).Selected = True
                        DG1.Focus()
                        'End If
                    ElseIf frmlotr.Label12.Text = "EDIT MODE" Then
                        frmlotr.DG1.Focus()
                    End If
                    'frmACMaster.Button3.Focus()
                    Me.Close()
                    GoTo en
                ElseIf frmLotNew.markacheck = 1 Then
                    frmLotNew.txtMarka.Text = TextBox2.Text
                    frmLotNew.Show()
                    frmLotNew.txtMarka.Focus()
                    frmLotNew.txttotalpcs.Focus()
                    closecheck = 0
                    frmLotNew.ListBox2.Visible = False
                    Me.Close()
                    GoTo en
                End If
                myfilldatagrid(DG1, "mrkmst")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                TextBox1.Clear()
                TextBox2.Clear()
                myserialno("mrkmst", TextBox1, "mrkcode")
                TextBox2.Focus()

                'End If
            ElseIf check = 2 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If (duplicate("mrkmst", "marka", TextBox2)) = True Then
                    MsgBox("marka already exists")
                    TextBox2.Focus()
                    GoTo en
                End If
                myupdate("mrkmst", a, "mrkcode", TextBox1.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "mrkmst")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                TextBox2.Focus()
            End If
en:     Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = DG1.SelectedCells
            TextBox1.Text = DG1.Item(0, i.Item(0).RowIndex).Value
            TextBox2.Text = DG1.Item(1, i.Item(0).RowIndex).Value
            GroupBox1.Enabled = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus
        Try
            sender.BackColor = Color.LightSteelBlue
            sender.forecolor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmMst_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If closecheck = 1 Then
            If frmACMaster.markacheck = 1 Then
                frmACMaster.markacheck = 0
                frmACMaster.Show()
            ElseIf frmlotr.markacheck = 1 Then
                frmlotr.markacheck = 0
                frmlotr.Show()
            ElseIf frmLotNew.markacheck = 1 Then
                frmLotNew.markacheck = 0
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
        datagridcolor(DG1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = dateyf
        dateyl1.Text = dateyl

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
            myfilldatagrid(DG1, "mrkmst")
            Try
                DG1.Item(0, DG1.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try
            cmdAdd.TabIndex = 0
            cmdAdd.Focus()
            If frmACMaster.markacheck = 1 Or frmlotr.markacheck = 1 Or frmLotNew.markacheck = 1 Then
                closecheck = 1
                check = 1
                Label5.Text = "ADD Mode"
                TextBox1.Clear()
                TextBox2.Clear()
                GroupBox1.Enabled = True
                myserialno("mrkmst", TextBox1, "mrkcode")
                GroupBox1.Focus()
                TextBox2.Focus()
                GroupBox1.TabIndex = 0
                cmdAdd.TabIndex = 1
                ' MsgBox("het")
            End If

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

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub

    Private Sub cmdAdd_Enter(sender As Object, e As EventArgs) Handles cmdEdit.Enter, cmdAdd.Enter, Button3.Enter, Button1.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub cmdAdd_Leave(sender As Object, e As EventArgs) Handles cmdEdit.Leave, cmdAdd.Leave, Button3.Leave, Button1.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black

    End Sub

    Private Sub cmdAdd_MouseEnter(sender As Object, e As EventArgs) Handles cmdEdit.MouseEnter, cmdAdd.MouseEnter, Button3.MouseEnter, Button1.MouseEnter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub cmdAdd_MouseHover(sender As Object, e As EventArgs) Handles cmdEdit.MouseHover, cmdAdd.MouseHover, Button3.MouseHover, Button1.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub cmdAdd_MouseLeave(sender As Object, e As EventArgs) Handles cmdEdit.MouseLeave, cmdAdd.MouseLeave, Button3.MouseLeave, Button1.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black

    End Sub
End Class