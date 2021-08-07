Imports System.Data.SqlClient
Public Class frmSHMaster
    Dim check As Integer = 1
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim rowindex As Integer
    Dim colindex As Integer
    Dim timercount As Integer = 0
    Public shcheck As Integer = 0
    Dim CLOSECHECK As Integer = 0
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim tv1 As String

    Private Sub frmSHMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOSECHECK = 1 Then
            If frmACMaster.accheck = 1 Then
                frmACMaster.Show()
                frmACMaster.txtShead.Focus()
            End If
        End If
    End Sub

    Private Sub frmSHMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus
        Try
            sender.BackColor = Color.Pink
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gotfocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        ListBox2.Visible = True
        ListBox2.BringToFront()
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus, TextBox6.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub frmSHMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            connect()
            cmd = New SqlCommand("Select * from tblMH ORDER BY MHEAD", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ListBox2.Items.Add(dr.Item("Malph") & "  " & dr.Item("Mhead"))
            End While
            dr.Close()
            close1()
            If shcheck = 1 Then
            ElseIf frmACMaster.accheck = 1 Then
                cmdAdd.Enabled = False
                cmdFind.Enabled = False
                cmdEdit.Enabled = False
                DG1.Enabled = False
                check = 1
                Label5.Text = "ADD Mode"
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox8.Clear()
                GroupBox1.Enabled = True
                TextBox1.Focus()
                myfilldatagrid(DG1, "tblSH")
                CLOSECHECK = 1
            Else
                connect()
                '  myfillCustome(TextBox1, "tblMH", "Mhead")
                myfilldatagrid(DG1, "tblSH")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                cmdAdd.Focus()

            End If
            '  If check = 1 Then
            'ElseIf check = 2 Then
            ' End If
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox8.Clear()
            GroupBox1.Enabled = True
            TextBox1.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        frmMHfind.Close()
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        TextBox1.Text = DG1.Item(3, i.Item(0).RowIndex).Value
        TextBox2.Text = DG1.Item(2, i.Item(0).RowIndex).Value
        TextBox3.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        TextBox4.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        Dim dr As SqlDataReader
        dr = myconselect("tblMH", TextBox1.Text, "MHead")
        While dr.Read
            TextBox7.Text = dr.Item("Malph")
        End While
        dr.Close()
        TextBox8.Text = DG1.Item(4, i.Item(0).RowIndex).Value
        TextBox5.Text = TextBox1.Text
        TextBox6.Text = TextBox2.Text
        GroupBox1.Enabled = True
        TextBox1.Focus()
    End Sub
    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            TextBox1.Text = dg1.Item(3, i.Item(0).RowIndex).Value
            TextBox2.Text = dg1.Item(2, i.Item(0).RowIndex).Value
            TextBox3.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            TextBox4.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            TextBox8.Text = dg1.Item(4, i.Item(0).RowIndex).Value
            TextBox11.Text = TextBox2.Text
            connect()
            cmd = New SqlCommand("Select malph from tblMH where Mhead='" & TextBox1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox7.Text = dr.Item(0)
            End While
            dr.Close()
            close1()
            TextBox5.Text = TextBox1.Text
            TextBox6.Text = TextBox2.Text
            ListBox1.Visible = False
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DG1_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub DG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                Dim i As DataGridViewSelectedCellCollection
                i = dg1.SelectedCells
                dg1.Item(i.Item(0).ColumnIndex, i.Item(0).RowIndex - 1).Selected = True
                cmdEdit.Focus()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
            frmSHFind.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        '  frmSHFind.Show()
        GroupBox1.Enabled = True
        tv1 = ""
        GroupBox2.Visible = True
        '    TextBox10.Clear()
        TextBox10.Focus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 1
        If timercount > 10 Then
            timercount = 0
            Timer1.Enabled = False
            Label2.Text = ""
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblmh where mhead='" & TextBox1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox3.Text = dr.Item("mcode")
                TextBox7.Text = dr.Item("malph")
            End While
            dr.Close()
              close1()
            If TextBox1.Text.Trim.Length = 0 Then
                MsgBox("Main  Head can not be blank")
                TextBox1.Focus()
                GoTo en
            End If
            If TextBox2.Text.Trim.Length = 0 Then
                MsgBox("Schedule  Head can not be blank")
                TextBox2.Focus()
                GoTo en
            End If

            If check = 1 Then
                Dim a() As String = {TextBox3.Text, TextBox4.Text, TextBox2.Text, TextBox1.Text, TextBox8.Text}
                If duplicate("tblSH", "Shead", TextBox2) Then
                    MsgBox("Schedule head already exists")
                    TextBox2.Focus()
                    GoTo en
                Else

                End If
                myinsert(a, "tblSH")
                myfilldatagrid(dg1, "tblSH")
                If frmACMaster.accheck = 1 Then
                    frmACMaster.txtShead.Text = TextBox2.Text
                    frmACMaster.Show()
                    frmACMaster.txtShead.Focus()
                    frmACMaster.txtGroup.Focus()
                    frmACMaster.listShead.Visible = False
                    CLOSECHECK = 0
                    Me.Close()
                Else
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                    dg1.Refresh()
                    Timer1.Enabled = True
                    Label2.Text = "SAVED"
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox1.Focus()

                End If

            ElseIf check = 2 Then
                Dim a() As String = {TextBox3.Text, TextBox4.Text, TextBox2.Text, TextBox1.Text, TextBox8.Text}
                If TextBox1.Text.ToUpper <> TextBox5.Text.ToUpper And TextBox2.Text.ToUpper = TextBox6.Text.ToUpper Or 1 = 1 Then
                Else
                    If duplicate("tblSH", "Shead", TextBox2) Then
                        MsgBox("Schedule head already exists")
                        TextBox2.Focus()
                        GoTo en
                    Else
                    End If
                End If

                'MsgBox("het")
                cmd = New SqlCommand("update tblaccount set schedule='" & TextBox2.Text & "',mcode='" & TextBox3.Text & "' where schedule='" & TextBox6.Text & "'", cn)
                cmd.ExecuteNonQuery()
                myupdate("tblSH", a, "Scode", TextBox4.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = dg1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(dg1, "tblSH")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                dg1.Item(coli, rowi).Selected = True
                TextBox1.Focus()
            End If
en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Dim dr As SqlDataReader
        dr = myconselect("tblMH", TextBox1.Text, "Mhead")
        While dr.Read
            TextBox3.Text = dr.Item(0)
        End While
        dr.Close()
        ' ListBox1.Visible = False
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
            ' ElseIf e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '  If ListBox1.Items.Count <> 0 Then
        '   TextBox1.Text = ListBox1.Items(0).ToString
        '   ListBox1.Visible = False
        '   TextBox2.Focus()
        ' ElseIf ListBox1.Items.Count = 0 Then
        '    If MsgBox("The Main Head not exits you want to create New", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        'shcheck = 1
        ' frmMHMaster.Show()
        ' Me.Hide()
        ' End If
        ' End If
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text.Length = 0 And ListBox2.SelectedIndex = 0 Then
                TextBox9.Clear()
                PictureBox1.Visible = True
                PictureBox1.BringToFront()
                TextBox9.Focus()
                '   PictureBox1.Visible = False

                GoTo en
            End If
            connect()
            cmd = New SqlCommand("Select * from tblMH where malph='" & TextBox1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox1.Text = dr.Item("Mhead")
                TextBox7.Text = dr.Item("Malph")
                TextBox2.Focus()
                ListBox2.Visible = False
                dr.Close()
                ListBox1.Visible = False
                GoTo en
            End While
            dr.Close()
            close1()
            TextBox1.Text = ListBox2.SelectedItem.ToString.Substring(3)
            TextBox7.Text = ListBox2.SelectedItem.ToString.Substring(0, 1)
            TextBox2.Focus()
            ListBox2.Visible = False
        ElseIf e.KeyCode = Keys.Up Then
            If ListBox2.SelectedIndex <> 0 Then
                ListBox2.SelectedIndex = ListBox2.SelectedIndex - 1
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If ListBox2.SelectedIndex <> ListBox2.Items.Count - 1 Then
                ListBox2.SelectedIndex = ListBox2.SelectedIndex + 1
            End If
        End If
en:
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        Try
            If check = 1 Then
                myserialno("tblSH", TextBox4, "Scode")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub
    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            '  TextBox1.Text = ListBox1.SelectedItems(0).ToString
            ' ListBox1.Visible = False
            ' TextBox2.Focus()
        End If
    End Sub
    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            GoTo END1
        End If
        'myAutoComplete(TextBox1, ListBox1, "tblMH", "Mhead")
        Dim k As Integer
        For k = 0 To ListBox2.Items.Count - 1
            'MsgBox(ListBox2.Items(k).ToString.Substring(3).ToString())
            If ListBox2.Items(k).ToString.ToUpper.Substring(3).ToString.StartsWith(TextBox1.Text.ToUpper) Then
                ListBox2.SelectedIndex = k
                GoTo END1
            End If
        Next
END1:
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox8.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            TextBox1.Focus()
        End If
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub
    Private Sub TextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp

    End Sub
    Private Sub ListBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox2.KeyDown
        Try

        If e.KeyCode = Keys.Enter Then
                TextBox1.Text = ListBox2.SelectedItem.ToString.Substring(3)
                TextBox7.Text = ListBox2.SelectedItem.ToString.Substring(0, 1)
                TextBox2.Focus()
                ListBox2.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dg1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox9.KeyDown


    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblmh where malph='" & e.KeyChar & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox1.Text = dr.Item("mhead")
                TextBox3.Text = dr.Item("mcode")
                TextBox7.Text = dr.Item("malph")
            End While
            dr.Close()
            PictureBox1.Visible = False
            TextBox2.Focus()
            ListBox2.Visible = False
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If MsgBox("You want to delete this schedue", MsgBoxStyle.YesNo) = Windows.Forms.DialogResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("select * from tblaccount where schedule='" & TextBox2.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    MsgBox("There are accounts whose schedule is same as this .Can not delete this schedule")
                    GoTo en
                    dr.Close()
                Else
                    dr.Close()
                End If
                cmd = New SqlCommand("delete from tblsh where shead='" & TextBox2.Text & "'", cn)
                cmd.ExecuteNonQuery()
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("select * from tblsh", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                MsgBox("Deleted")
                close1()
                myfilldatagrid(dg1, "tblSH")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub TextBox10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button4.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox10.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox10.Text
        For i = temp1 To dg1.Rows.Count - 2
            For j = temp2 To dg1.ColumnCount - 1
                If (dg1.Item(j, i).Value.ToString.ToUpper.Contains(TextBox10.Text.ToUpper)) Then
                    dg1.Item(j, i).Selected = True
                    temp2 = j + 1
                    '    check = 1
                    GoTo en
                End If
            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        GroupBox2.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmprintsh.Show()
    End Sub
End Class