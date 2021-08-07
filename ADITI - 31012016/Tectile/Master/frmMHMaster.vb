Imports System.Data.SqlClient
Public Class frmMHMaster
    Dim check As Integer = 1
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim rowindex As Integer
    Dim colindex As Integer
    Dim timercount As Integer
    Dim CLOSECHECK As Integer = 0
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, ComboBox1.GotFocus
        Try
            sender.BackColor = Color.DodgerBlue
            sender.forecolor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, ComboBox2.LostFocus, ComboBox1.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmMHMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOSECHECK = 1 Then
            If frmSHMaster.shcheck = 1 Then
                frmSHMaster.TextBox1.Text = TextBox2.Text
                MsgBox(frmSHMaster.TextBox1.Text)
                frmSHMaster.Show()
                frmSHMaster.ListBox1.Visible = False
                frmSHMaster.TextBox1.Focus()
                frmSHMaster.TextBox2.Focus()
                CLOSECHECK = 0
                Me.Close()
            End If
        End If
    End Sub
    Private Sub frmMHMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
             Me.companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = dateyf
            dateyl1.Text = dateyl
            If frmSHMaster.shcheck = 1 Then
                cmdAdd.Enabled = False
                cmdFind.Enabled = False
                cmdEdit.Enabled = False
                DG1.Enabled = False
                myfilldatagrid(DG1, "tblMH")
                check = 1
                GroupBox1.Enabled = True
                ComboBox1.Focus()
                SendKeys.Send("{q}")
                check = 1
                Label5.Text = "ADD Mode"
                ComboBox1.Text = ""
                TextBox1.Clear()
                TextBox2.Clear()
                GroupBox1.Enabled = True
                ComboBox1.Focus()
                CLOSECHECK = 1

            Else
                '  If check = 1 Then
                connect()
                myfilldatagrid(DG1, "tblMH")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                cmdAdd.Focus()
                DG1.AutoResizeColumn(1)
                'ElseIf check = 2 Then
                ' End If
            End If
            DG1.DefaultCellStyle.BackColor = My.Settings.gridbackcolor
            DG1.DefaultCellStyle.ForeColor = My.Settings.gridforecolor
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub

  
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            ComboBox1.Text = ""
            TextBox1.Clear()
            TextBox2.Clear()
            GroupBox1.Enabled = True
            ComboBox1.Focus()
            TextBox5.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        Try
            If check = 1 Then
                connect()
                If ComboBox1.Text = "Income" Then
                    cmd = New SqlCommand("select * from tblMH where Mcode like 'PIN%'", cn)
                    dr = cmd.ExecuteReader
                    Dim i As New String("")
                    While dr.Read
                        i = dr.Item("Mcode")
                    End While
                    dr.Close()
                    If i.ToString.Trim.Length = 0 Then
                        TextBox1.Text = "PIN" & "100"
                    Else
                        i = i.Substring(3)
                        TextBox1.Text = "PIN" & (i + 1).ToString
                    End If
                ElseIf ComboBox1.Text = "Expenditure" Then
                    cmd = New SqlCommand("select * from tblMH where Mcode like 'PEX%'", cn)
                    dr = cmd.ExecuteReader
                    Dim i As New String("")
                    While dr.Read
                        i = dr.Item("Mcode")
                    End While
                    If i.ToString.Trim.Length = 0 Then
                        TextBox1.Text = "PEX" & "100"
                    Else
                        i = i.Substring(3)
                        TextBox1.Text = "PEX" & (i + 1).ToString
                    End If
                ElseIf ComboBox1.Text = "Assets" Then
                    cmd = New SqlCommand("select * from tblMH where Mcode like 'BAS%'", cn)
                    dr = cmd.ExecuteReader
                    Dim i As New String("")
                    While dr.Read
                        i = dr.Item("Mcode")
                    End While
                    If i.ToString.Trim.Length = 0 Then
                        TextBox1.Text = "BAS" & "100"
                    Else
                        i = i.Substring(3)
                        TextBox1.Text = "BAS" & (i + 1).ToString
                    End If
                ElseIf ComboBox1.Text = "Liabilities" Then
                    cmd = New SqlCommand("select * from tblMH where Mcode like 'BLI%'", cn)
                    dr = cmd.ExecuteReader
                    Dim i As New String("")
                    While dr.Read
                        i = dr.Item("Mcode")
                    End While
                    If i.ToString.Trim.Length = 0 Then
                        TextBox1.Text = "BLI" & "100"
                    Else
                        i = i.Substring(3)
                        TextBox1.Text = "BLI" & (i + 1).ToString
                    End If
                Else
                    MsgBox("Select from list")
                    ComboBox1.Focus()
                End If
                close1()
            ElseIf check = 2 Then
                If ComboBox1.Text.ToString.Equals(ComboBox2.Text) Then
                    TextBox1.Text = TextBox3.Text
                Else
                    connect()
                    If ComboBox1.Text = "Income" Then
                        cmd = New SqlCommand("select * from tblMH where Mcode like 'PIN%'", cn)
                        dr = cmd.ExecuteReader
                        Dim i As New String("")
                        While dr.Read
                            i = dr.Item("Mcode")
                        End While
                        If i.ToString.Trim.Length = 0 Then
                            TextBox1.Text = "PIN" & "100"
                        Else
                            i = i.Substring(3)
                            TextBox1.Text = "PIN" & (i + 1).ToString
                        End If
                    ElseIf ComboBox1.Text = "Expenditure" Then
                        cmd = New SqlCommand("select * from tblMH where Mcode like 'PEX%'", cn)
                        dr = cmd.ExecuteReader
                        Dim i As New String("")
                        While dr.Read
                            i = dr.Item("Mcode")
                        End While
                        If i.ToString.Trim.Length = 0 Then
                            TextBox1.Text = "PEX" & "100"
                        Else
                            i = i.Substring(3)
                            TextBox1.Text = "PEX" & (i + 1).ToString
                        End If

                    ElseIf ComboBox1.Text = "Assets" Then
                        cmd = New SqlCommand("select * from tblMH where Mcode like 'BAS%'", cn)
                        dr = cmd.ExecuteReader
                        Dim i As New String("")
                        While dr.Read
                            i = dr.Item("Mcode")
                        End While
                        If i.ToString.Trim.Length = 0 Then
                            TextBox1.Text = "BAS" & "100"
                        Else
                            i = i.Substring(3)
                            TextBox1.Text = "BAS" & (i + 1).ToString
                        End If

                    ElseIf ComboBox1.Text = "Liabilities" Then
                        cmd = New SqlCommand("select * from tblMH where Mcode like 'BLI%'", cn)
                        dr = cmd.ExecuteReader
                        Dim i As New String("")
                        While dr.Read
                            i = dr.Item("Mcode")
                        End While
                        If i.ToString.Trim.Length = 0 Then
                            TextBox1.Text = "BLI" & "100"
                        Else
                            i = i.Substring(3)
                            TextBox1.Text = "BLI" & (i + 1).ToString
                        End If
                    Else
                        MsgBox("Select from list")
                        ComboBox1.Focus()
                    End If
                    close1()

                End If

            End If
            
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub frmMHMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                '  SendKeys.Send("{TAB}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
                ' ElseIf (e.Modifiers And Keys.Shift = Keys.Shift) And e.KeyCode = Keys.Tab Then
                '    SendKeys.Send("{SHIFT},{TAB}")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
         End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim treading As String
            If TextBox2.Text.Trim.Length = 0 Then
                MsgBox("Main Head can not be blank")
                TextBox2.Focus()
                GoTo en
            End If
            If TextBox5.Text.Trim.Length = 0 Then
                MsgBox("Alpha can not be blank")
                TextBox5.Focus()
                GoTo en
            End If
            Try
                If (TextBox5.Text.Chars(0) >= "A" And TextBox5.Text.Chars(0) <= "Z") = False Then
                    MsgBox("Only char allowed")
                    TextBox5.Focus()
                    GoTo en
                End If

            Catch ex As Exception

            End Try
            If CheckBox1.Checked = True Then
                treading = "True"
            Else
                treading = "Fals"
            End If
            If check = 1 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text, ComboBox1.Text, treading, TextBox5.Text.ToUpper}
                If duplicate("tblMH", "Mhead", TextBox2) Then
                    MsgBox("Mhead already exists")
                    TextBox2.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblMH")
                myfilldatagrid(dg1, "tblMH")
                If frmSHMaster.shcheck = 1 Then
                    frmSHMaster.TextBox1.Text = TextBox2.Text
                    MsgBox(frmSHMaster.TextBox1.Text)
                    frmSHMaster.Show()
                    frmSHMaster.ListBox1.Visible = False
                    frmSHMaster.TextBox1.Focus()
                    frmSHMaster.TextBox2.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                Else
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                    dg1.Refresh()
                    Timer1.Enabled = True
                    Label2.Text = "SAVED"
                    TextBox1.Clear()
                    TextBox2.Clear()
                    ComboBox1.Focus()
                End If
            ElseIf check = 2 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text, ComboBox1.Text, treading, TextBox5.Text.ToUpper}
                If TextBox2.Text = TextBox4.Text Then
                Else
                    If (duplicate("tblMH", "Mhead", TextBox2)) = True Then
                        MsgBox("Record already exists")
                        TextBox2.Focus()
                        GoTo en
                    End If
                End If
                myupdate("tblMH", a, "Mcode", TextBox3.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = dg1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(dg1, "tblMH")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                dg1.Item(coli, rowi).Selected = True
                ComboBox1.Focus()
            End If
en:
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        frmMHfind.Close()
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        TextBox1.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        TextBox2.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        ComboBox1.Text = DG1.Item(2, i.Item(0).RowIndex).Value
        TextBox3.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        ComboBox2.Text = DG1.Item(2, i.Item(0).RowIndex).Value
        TextBox4.Text = TextBox2.Text
        GroupBox1.Enabled = True
        TextBox5.Text = DG1.Item(4, i.Item(0).RowIndex).Value
        ComboBox1.Focus()
        '   ComboBox1 .Text =DG1.
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            TextBox1.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            TextBox2.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            ComboBox1.Text = dg1.Item(2, i.Item(0).RowIndex).Value
            TextBox5.Text = dg1.Item(4, i.Item(0).RowIndex).Value
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
            frmMHfind.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        'frmMHfind.Show()
        GroupBox2.Visible = True
        tv1 = ""
        TextBox6.Focus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 1
        If timercount > 10 Then
            timercount = 0
            Timer1.Enabled = False
            Label2.Text = ""
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

   
    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox5.Focus()
        End If
        If e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            connect()

            Dim cmd As New SqlCommand
            Dim sql As String
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select * from tblSH where mhead='" & TextBox2.Text & "'", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("There are entries in Schedule You can not delete this")
                GoTo en
            Else
                dr.Close()
            End If
            cmd = New SqlCommand("delete from tblMH where mcode ='" & TextBox1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            Label5.Text = "Deleted"
            Timer1.Enabled = True
            close1()
            myfilldatagrid(dg1, "tblMH")
        Catch ex As Exception

        End Try

en:
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.Focus()
        End If
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox6.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox6.Text
        For i = temp1 To dg1.Rows.Count - 1
            For j = temp2 To dg1.ColumnCount - 1
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)
                Try

                    If dg1.Item(j, i).Value.ToString.ToLower.ToString.Contains(TextBox6.Text.ToLower) Then
                        dg1.Item(j, i).Selected = True
                        temp2 = j + 1

                        '    check = 1
                        GoTo en
                    End If
                Catch ex As Exception

                End Try

            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmprintmh.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.Leave
        TextBox5.Text = TextBox5.Text.ToUpper
    End Sub
End Class