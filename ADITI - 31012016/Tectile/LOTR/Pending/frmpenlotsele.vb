Imports System.Data.SqlClient
Public Class frmpenlotsele

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmpenlotsele_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmpenlotsele_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            If frmMainScreen.pending.ToUpper = "lot".ToUpper Then
                ComboBox2.Visible = False
            Else
                ComboBox1.Visible = False
            End If
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox3.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            MaskedTextBox4.Text = Format(dateyl, "dd-MM-yyyy")
            ComboBox1.Text = ComboBox1.Items(0)
            ComboBox2.Text = ComboBox2.Items(0)
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select distinct pgroup from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox1.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct acname from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox2.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct item from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox3.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct mst from tblLotr", cn)
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
            close1()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmprintpending.Show()
    End Sub

    Private Sub MaskedTextBox4_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox4.MaskInputRejected

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Try
        '    Dim cmd As New SqlCommand
        '    Dim dr As SqlDataReader
        '    CheckedListBox3.Items.Clear()
        '    connect()
        '    cmd = New SqlCommand("select lotno from tblLotr", cn)
        '    dr = cmd.ExecuteReader
        '    While dr.Read
        '        CheckedListBox3.Items.Add(dr.Item(0))
        '    End While
        '    dr.Close()
        '    close1()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox3_GotFocus(sender As Object, e As EventArgs) Handles MaskedTextBox3.GotFocus, MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus, MaskedTextBox4.GotFocus
        sender.SelectionStart = 0
        sender.SelectionLength = 0

    End Sub

    Private Sub MaskedTextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox4.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave, MaskedTextBox3.Leave
        'Try
        '    Dim dat As New Date
        '    dat = sender.Text
        '    If DateDiff(DateInterval.Day, dat, dateyf) > 0 Then
        '        MsgBox("Enter date in current A/c Year")
        '        sender.Focus()
        '    End If
        '    sender.backcolor = Color.White
        'Catch ex As Exception
        '    MsgBox("Enter Proper Date")
        '    MaskedTextBox1.Focus()
        'End Try
    End Sub

    Private Sub MaskedTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox3.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave, MaskedTextBox4.Leave
        'Try
        '    Dim dat As New Date
        '    dat = sender.Text
        '    If DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
        '        MsgBox("Enter date in current A/c Year")
        '        sender.Focus()
        '    End If
        '    sender.backcolor = Color.White
        'Catch ex As Exception
        '    MsgBox("Enter Proper Date")
        '    MaskedTextBox1.Focus()
        'End Try
    End Sub
    Private Sub CheckedListBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            sender.SelectedIndex = 0
            sender.backcolor = Color.Pink
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            sender.selectedindex = -1
            sender.backcolor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MaskedTextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class