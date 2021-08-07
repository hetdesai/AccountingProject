Imports System.Data.SqlClient
Public Class frmItemTypeMaster
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim CLOSECHECK As Integer = 0
    Dim TEMP1 As Integer
    Dim TEMP2 As Integer
    Dim TV1 As String

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            TextBox1.Clear()
            TextBox2.Clear()
            GroupBox1.Enabled = True
            myserialno("tblITType", TextBox1, "TPCode")
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            TextBox1.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            TextBox2.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            GroupBox1.Enabled = True

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TextBox2.Text.Trim.Length = 0 Then
                MsgBox("Item Type can not be blank")
                TextBox2.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If duplicate("tblITType", "TPName", TextBox2) Then
                    MsgBox("Item Type already exists")
                    TextBox2.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblITType")
                myfilldatagrid(DG1, "tblITType")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                If frmITMaster.ittypecheck = 1 Then
                    frmITMaster.txttype.Text = TextBox2.Text
                    frmITMaster.Show()
                    frmITMaster.listType.Visible = False
                    frmITMaster.txttype.Focus()
                    frmITMaster.txtUnit.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                Else
                    TextBox1.Clear()
                    TextBox2.Clear()
                    myserialno("tblITType", TextBox1, "TPCode")
                    TextBox2.Focus()

                End If
            ElseIf check = 2 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If (duplicate("tblITType", "TPName", TextBox2)) = True Then
                    MsgBox("Record already exists")
                    TextBox2.Focus()
                    GoTo en
                End If
                myupdate("tblITType", a, "TPCode", TextBox1.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblITType")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                TextBox2.Focus()
            End If
en:
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub frmItemTypeMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOSECHECK = 1 Then
            If frmITMaster.ittypecheck = 1 Then
                frmITMaster.Show()
                frmITMaster.listType.Visible = False
                frmITMaster.txttype.Focus()
            End If
        End If
    End Sub

    Private Sub frmItemTypeMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
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
    Private Sub frmItemTypeMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            '  If check = 1 Then
            If frmITMaster.ittypecheck = 1 Then
                cmdAdd.Enabled = False
                cmdEdit.Enabled = False
                cmdFind.Enabled = False
                DG1.Enabled = False
                check = 1
                Label5.Text = "ADD Mode"
                TextBox1.Clear()
                TextBox2.Clear()
                GroupBox1.Enabled = True
                myserialno("tblITType", TextBox1, "TPCode")
                TextBox2.Focus()
                CLOSECHECK = 1
            Else
                connect()
                myfilldatagrid(dg1, "tblITType")
                Try
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try

                cmdAdd.Focus()

            End If
            'ElseIf check = 2 Then
            ' End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        'frmTPFind.Show()
        GroupBox2.Visible = True
        GroupBox1.Enabled = True
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        GroupBox2.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox3.Text = TV1) Then
        Else
            TEMP1 = 0
            TEMP2 = 0
        End If
        TV1 = TextBox3.Text
        For i = TEMP1 To dg1.Rows.Count - 1
            For j = TEMP2 To dg1.ColumnCount - 1
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)
                If (dg1.Item(j, i).Value.ToString.ToLower.ToString.Contains(TextBox3.Text.ToLower)) Then
                    dg1.Item(j, i).Selected = True
                    TEMP2 = j + 1
                    '    check = 1
                    GoTo en
                End If
            Next
            TEMP1 = i + 1
            TEMP2 = 0
        Next
en:
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            CMD = New SqlCommand("SELECT * FROM TBLITEM WHERE ITTYPE='" & TextBox2.Text & "'", cn)
            CMD.ExecuteReader()
            If DR.HasRows = True Then
                MsgBox("THIS TYPE IS USED FOR SOME ITEM DELETE THAT ITEM FIRST")
                DR.Close()
                GoTo EN
            Else
                DR.Close()

            End If
            CMD = New SqlCommand("DELETE FROM TBLITTYPE WHERE TPNAME='" & TextBox2.Text & "'", cn)
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
EN:
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        FRMPRINTITEMTYPE.Show()
    End Sub

    Private Sub cmdAdd_Enter(sender As Object, e As EventArgs) Handles cmdFind.Enter, cmdEdit.Enter, cmdAdd.Enter, Button5.Enter, Button3.Enter, Button1.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub cmdAdd_Leave(sender As Object, e As EventArgs) Handles cmdFind.Leave, cmdEdit.Leave, cmdAdd.Leave, Button5.Leave, Button3.Leave, Button1.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub cmdAdd_MouseLeave(sender As Object, e As EventArgs) Handles cmdFind.MouseLeave, cmdEdit.MouseLeave, cmdAdd.MouseLeave, Button5.MouseLeave, Button3.MouseLeave, Button1.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub cmdAdd_MouseHover(sender As Object, e As EventArgs) Handles cmdFind.MouseHover, cmdEdit.MouseHover, cmdAdd.MouseHover, Button5.MouseHover, Button3.MouseHover, Button1.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub
End Class