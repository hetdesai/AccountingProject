Imports System.Data.SqlClient

Public Class frmoutward

    Private Sub frmoutward_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmoutward_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            If frmMainScreen.outward.ToUpper = "Lot".ToUpper Then
                ComboBox2.Visible = False
            Else
                ComboBox1.Visible = False
            End If
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            ComboBox1.Text = ComboBox1.Items(0).ToString
            ComboBox2.Text = ComboBox2.Items(0).ToString
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select ACNAME from tblAccount where book='Sales'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct pgroup from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox1.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct name from sale", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox2.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct itname from sale1", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox3.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct mst from sale", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox5.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select lotno from tblLotr order by convert(int,lotn)", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox4.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct process from sale1", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox6.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
            MaskedTextBox1.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CheckedListBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox6.GotFocus
        Try
            sender.SelectedIndex = 0
            sender.backcolor = Color.Pink
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox6.LostFocus
        Try
            sender.selectedindex = -1
            sender.backcolor = Color.White
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Try
        '    Dim cmd As New SqlCommand
        '    Dim dr As SqlDataReader
        '    CheckedListBox3.Items.Clear()
        '    connect()
        '    cmd = New SqlCommand("select lotno from tblLotr where convert(int,lotn)>=" & TextBox1.Text & " and convert(int,lotn)<=" & TextBox2.Text & " and ((convert(varchar,lotc)>'=" & TextBox3.Text & "' and convert(varchar,lotc)<='" & TextBox4.Text & "') or convert(varchar,lotc)='') order by convert(int,lotn)", cn)
        '    dr = cmd.ExecuteReader
        '    While dr.Read
        '        CheckedListBox3.Items.Add(dr.Item(0))
        '    End While
        '    dr.Close()
        '    close1()
        'Catch ex As Exception
        '    '  MsgBox(ex.ToString)
        'End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmprintout.Show()
    End Sub

    Private Sub MaskedTextBox1_GotFocus(sender As Object, e As EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionStart = 0
        sender.SelectionLength = 0
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        'Try
        '    Dim dat As New Date
        '    dat = sender.Text
        '    If DateDiff(DateInterval.Day, dat, dateyf) > 0 Then
        '        MsgBox("Enter date in current A/c Year")
        '        MaskedTextBox1.Focus()
        '    End If
        '    sender.backcolor = Color.White
        'Catch ex As Exception
        '    MsgBox("Enter Proper Date")
        '    MaskedTextBox1.Focus()
        'End Try
    End Sub

    Private Sub MaskedTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        End If
    End Sub
    Private Sub MaskedTextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Try
            Dim dat As New Date
            dat = sender.Text
            If DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox2.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox1.Focus()
        End Try
    End Sub

    Private Sub CheckedListBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox6.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class