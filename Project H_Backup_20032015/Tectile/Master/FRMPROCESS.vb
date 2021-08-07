Imports System.Data.SqlClient
Public Class frmProcess
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
            TextBox1.Clear()
            TextBox2.Clear()
            GroupBox1.Enabled = True
            myserialno("prmst", TextBox1, "prcode")
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        TextBox1.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        TextBox2.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        GroupBox1.Enabled = True
        TextBox2.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            If TextBox2.Text.Trim.Length = 0 Then
                MsgBox("Process Name Name can not be blank")
                TextBox2.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If duplicate("Prmst", "process", TextBox2) Then
                    MsgBox("Process already exists")
                    TextBox2.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "prmst")
                If frmACMaster.mstcheck = 1 Then
                    frmACMaster.Show()
                    frmACMaster.txtMst.Text = TextBox2.Text
                    closecheck = 0
                    frmACMaster.txtMst.Focus()
                    frmACMaster.txtMstcode.Focus()
                    frmACMaster.listMst.Visible = False
                    frmACMaster.butSave.Focus()
                    Me.Close()
                    GoTo en
                End If
                myfilldatagrid(DG1, "prmst")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                TextBox1.Clear()
                TextBox2.Clear()
                myserialno("prMst", TextBox1, "prCode")
                TextBox2.Focus()

                'End If
            ElseIf check = 2 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If (duplicate("prMst", "process", TextBox2)) = True Then
                    MsgBox("Process already exists")
                    TextBox2.Focus()
                    GoTo en
                End If
                myupdate("prMst", a, "prCode", TextBox1.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "prMst")
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
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
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
            myfilldatagrid(DG1, "prMst")
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

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        End If
    End Sub
End Class