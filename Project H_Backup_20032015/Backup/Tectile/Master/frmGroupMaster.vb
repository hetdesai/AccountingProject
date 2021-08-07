Imports System.Data.SqlClient
Public Class frmGroupMaster
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

    Private Sub frmGroupMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOASECHECK2 = 1 Then
            frmACMaster.Show()
            frmACMaster.txtGroup.Focus()
        End If
    End Sub

    Private Sub frmItemTypeMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Escape Then
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
                TextBox1.Clear()
                TextBox2.Clear()
                GroupBox1.Enabled = True
                myserialno("tblPGroup", TextBox1, "GCode")
                GroupBox1.Focus()
                TextBox2.Focus()
            Else
                connect()
                myfilldatagrid(dg1, "tblPGroup")
                dg1.Item(0, dg1.RowCount - 1).Selected = True
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
            TextBox1.Clear()
            TextBox2.Clear()
            GroupBox1.Enabled = True
            myserialno("tblPgroup", TextBox1, "GCode")
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
        TextBox3.Text = TextBox2.Text
        GroupBox1.Enabled = True
        TextBox2.Focus()
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub


    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            TextBox1.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            TextBox2.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            TextBox3.Text = TextBox2.Text
            GroupBox1.Enabled = True

        Catch ex As Exception

        End Try


    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TextBox2.Text.Trim.Length = 0 Then
                MsgBox("Group Name can not be blank")
                TextBox2.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If duplicate("tblPGroup", "GName", TextBox2) Then
                    MsgBox("Group already exists")
                    TextBox2.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblPGroup")
                myfilldatagrid(DG1, "tblPgroup")
                dg1.Item(0, dg1.RowCount - 1).Selected = True
                MsgBox(frmACMaster.groupcheck)
                If frmACMaster.groupcheck = 1 Then
                    frmACMaster.Show()
                    frmACMaster.txtGroup.Text = TextBox2.Text
                    frmACMaster.txtadd1.Focus()
                    frmACMaster.listGroup.Visible = False
                    frmACMaster.groupcheck = 0
                    CLOSECHECK = 0
                    CLOASECHECK2 = 0
                    Me.Close()
                End If
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
                TextBox1.Clear()
                TextBox2.Clear()
                myserialno("tblPGroup", TextBox1, "GCode")
                TextBox2.Focus()

                'End If
            ElseIf check = 2 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text}
                If (duplicate("tblPGroup", "GName", TextBox2)) = True Then
                    MsgBox("Group already exists")
                    TextBox2.Focus()
                    GoTo en
                End If
                connect()
                Dim CMD As New SqlCommand
                CMD = New SqlCommand("UPDATE TBLACCOUNT SET PGROUP='" & TextBox2.Text & "' WHERE PGROUP='" & TextBox3.Text & "'", cn)
                CMD.ExecuteNonQuery()
                close1()

                myupdate("tblPGroup", a, "GCode", TextBox1.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblPGroup")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                TextBox2.Focus()
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
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            CMD = New SqlCommand("SELECT * FROM TBLACCOUNT WHERE PGROUP='" & TextBox2.Text & "'", cn)
            DR = CMD.ExecuteReader
            If DR.HasRows Then
                MsgBox("THIS GROUP IS IN USE YOU CAN NOT DELETE THIS")
                DR.Close()
                GoTo EN
            Else
                DR.Close()
            End If
            CMD = New SqlCommand("DELETE FROM TBLPGROUP WHERE GNAME='" & TextBox2.Text & "'", cn)
            CMD.ExecuteNonQuery()
            myfilldatagrid(dg1, "TBLPGROUP")
            close1()
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
End Class