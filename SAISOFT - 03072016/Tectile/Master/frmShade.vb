Imports System.Data.SqlClient
Public Class frmShade
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim CLOSECHECK As Integer = 0
    Dim CLOASECHECK2 As Integer
    Dim TV As String
    Dim TEMP1 As Integer
    Dim TEMP2 As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShadeCode.GotFocus, txtShade.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtShade.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShadeCode.LostFocus, txtShade.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmGroupMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmItemTypeMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmGroupMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")


        Try
            '  If check = 1 Then
            If frmACMaster.groupcheck = 1 Then
                CLOSECHECK = 1
                CLOASECHECK2 = 1
                cmdAdd.Enabled = False
                cmdEdit.Enabled = False
                'cmdFind.Enabled = False
                dg1.Enabled = False
                check = 1
                Label5.Text = "ADD Mode"
                txtShadeCode.Clear()
                txtShade.Clear()
                GroupBox1.Enabled = True
                myserialno("tblShade", txtShadeCode, "SHCode")
                GroupBox1.Focus()
                txtShade.Focus()
            Else
                connect()
                myfilldatagrid(dg1, "tblShade")
                Try
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try

                cmdAdd.Focus()

                'End If
                'ElseIf check = 2 Then
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtShadeCode.Clear()
            txtShade.Clear()
            GroupBox1.Enabled = True
            myserialno("tblShade", txtShadeCode, "SHCode")
            txtShade.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = dg1.SelectedCells
        txtShadeCode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
        txtShade.Text = dg1.Item(1, i.Item(0).RowIndex).Value
        TextBox3.Text = txtShade.Text
        GroupBox1.Enabled = True
        txtShade.Focus()
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub


    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            txtShadeCode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            txtShade.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            TextBox3.Text = txtShade.Text
            GroupBox1.Enabled = True

        Catch ex As Exception

        End Try


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If txtShade.Text.Trim.Length = 0 Then
                MsgBox("Shade Name can not be blank")
                txtShade.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {txtShadeCode.Text, txtShade.Text}
                If duplicate("tblShade", "SHADE", txtShade) Then
                    MsgBox("Group already exists")
                    txtShade.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblShade")
                myfilldatagrid(dg1, "tblShade")
                dg1.Item(0, dg1.RowCount - 1).Selected = True

                dg1.Refresh()
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
                MessageBox.Show("Saved")
                txtShadeCode.Clear()
                txtShade.Clear()
                myserialno("tblShade", txtShadeCode, "SHCode")
                txtShade.Focus()

                'End If
            ElseIf check = 2 Then
                Dim a() As String = {txtShadeCode.Text, txtShade.Text}
                If (duplicate("tblShade", "SHADE", txtShade)) = True Then
                    MsgBox("Shade already exists")
                    txtShade.Focus()
                    GoTo en
                End If

                Try
                    connect()
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("update sale1 set shade='" & txtShade.Text & "' where shade='" & TextBox3.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    'cmd = New SqlCommand("update salec1 set shade='" & txtShade.Text & "' where shade='" & TextBox3.Text & "'", cn)
                    'cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
                myupdate("tblShade", a, "SHCode", txtShadeCode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = dg1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(dg1, "tblShade")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                MessageBox.Show("Updated")
                dg1.Item(coli, rowi).Selected = True
                txtShade.Focus()
            End If
en:     Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub dg1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        FRMPRINTGROUP.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupBox2.Visible = True
        GroupBox1.Enabled = True
        TV = ""
        TextBox4.Focus()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If MessageBox.Show("Are you sure? Do you want to delete this shade", "Verify", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select * from sale1 where shade='" & txtShade.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Close()
                    MessageBox.Show("There is entry in sale so you can not delete this shade")
                    GoTo en
                Else
                    dr.Close()
                End If
                'cmd = New SqlCommand("Select * from salec1 where shade='" & txtShade.Text & "'", cn)
                'dr = cmd.ExecuteReader
                'If dr.HasRows Then
                '    dr.Close()
                '    MessageBox.Show("There is entry in sale so you can not delete this shade")
                '    GoTo en
                'Else
                '    dr.Close()
                'End If
                cmd = New SqlCommand("DELETE FROM tblShade WHERE SHADE='" & txtShade.Text & "'", cn)
                cmd.ExecuteNonQuery()
                myfilldatagrid(dg1, "tblShade")
                close1()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
EN:
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        'MsgBox("HET")
        If e.KeyCode = Keys.Enter Then
            Button6.Focus()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox4.Text = TV) Then
        Else
            TEMP1 = 0
            TEMP2 = 0
        End If
        TV = TextBox4.Text
        For i = TEMP1 To dg1.Rows.Count - 2
            For j = TEMP2 To dg1.ColumnCount - 1
                If (dg1.Item(j, i).Value.ToString.ToUpper.Contains(TextBox4.Text.ToUpper)) Then
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

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub GroupBox2_LocationChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.LocationChanged

    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        GroupBox2.Visible = False
    End Sub

    Private Sub cmdAdd_Enter(sender As Object, e As EventArgs) Handles cmdEdit.Enter, cmdAdd.Enter, Button4.Enter, Button3.Enter, Button2.Enter, Button1.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub cmdAdd_Leave(sender As Object, e As EventArgs) Handles cmdEdit.Leave, cmdAdd.Leave, Button4.Leave, Button3.Leave, Button2.Leave, Button1.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub cmdAdd_MouseLeave(sender As Object, e As EventArgs) Handles cmdEdit.MouseLeave, cmdAdd.MouseLeave, Button4.MouseLeave, Button3.MouseLeave, Button2.MouseLeave, Button1.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub cmdAdd_MouseHover(sender As Object, e As EventArgs) Handles cmdEdit.MouseHover, cmdAdd.MouseHover, Button4.MouseHover, Button3.MouseHover, Button2.MouseHover, Button1.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub
End Class