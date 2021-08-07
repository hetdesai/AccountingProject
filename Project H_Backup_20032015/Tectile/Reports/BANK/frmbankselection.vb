Imports System.Data.SqlClient
Public Class frmbankselection
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Public sql As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            '     If CheckedListBox1.CheckedItems.Count <> 0 Then
            connect()
            close1()
            frmbankreport.Show()
            'End If
            '  If frmMainScreen.bankreport <> "Summary" Then
            'If CheckedListBox1.CheckedItems.Count <> 1 Then
            'MsgBox("Pleace select one bank")
            'GoTo en
            ' End If
            'End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
    End Sub

    Private Sub frmbankselection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")

        End If
    End Sub
    Private Sub frmbankselection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            connect()
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select ACName from tblAccount where tblAccount.Book='BANK'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox1.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox1.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox1.Focus()
        End Try
    End Sub

    Private Sub MaskedTextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.GotFocus, MaskedTextBox1.GotFocus
        sender.SelectionStart = 0
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub MaskedTextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox2.Text
            If DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox2.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox2.Focus()
        End Try
    End Sub

   
    Private Sub CheckedListBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.GotFocus
        CheckedListBox1.SelectedIndex = 0
        CheckedListBox1.BackColor = Color.LightYellow
    End Sub

    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.LostFocus
        CheckedListBox1.SelectedIndex = -1
        CheckedListBox1.BackColor = Color.White
    End Sub
End Class