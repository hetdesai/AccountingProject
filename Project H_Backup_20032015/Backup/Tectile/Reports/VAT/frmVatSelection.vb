Imports System.Data.SqlClient
Public Class frmVatSelection
    Public dat1 As New Date
    Public dat2 As New Date
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmVatSelection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            dat1 = MaskedTextBox1.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dateyf) > 0 Or DateDiff(DateInterval.Day, dat1, dateyl) < 0 Then
                MsgBox("Enter date in current A/c. Year")
                MaskedTextBox1.Focus()
                sender.backcolor = Color.Yellow
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter proper date")
            MaskedTextBox1.Focus()
        End Try
    End Sub
    Private Sub MaskedTextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Try
            dat2 = MaskedTextBox2.Text.ToString
            If DateDiff(DateInterval.Day, dat2, dateyf) > 0 Or DateDiff(DateInterval.Day, dat2, dateyl) < 0 Then
                MsgBox("Enter date in current A/c. Year")
                MaskedTextBox2.Focus()
                sender.backcolor = Color.Yellow
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter proper date")
            MaskedTextBox2.Focus()
        End Try
    End Sub
    Private Sub frmVatSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = dateyf
            dateyl1.Text = dateyl
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            dat1 = dateyf
            dat2 = dateyl
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select distinct tax from taxmst where bktype='Sale'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct type from tax1", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox2.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionStart = 0
        sender.BackColor = Color.Yellow
    End Sub
    Private Sub MaskedTextBox1_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.LostFocus, MaskedTextBox2.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub CheckedListBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.GotFocus, CheckedListBox2.GotFocus
        sender.SelectedIndex = 0
        sender.BackColor = Color.LightYellow
    End Sub
    Private Sub CheckedListBox1_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.LostFocus, CheckedListBox2.LostFocus
        sender.SelectedIndex = -1
        sender.BackColor = Color.White
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmvat1.Show()
    End Sub
End Class