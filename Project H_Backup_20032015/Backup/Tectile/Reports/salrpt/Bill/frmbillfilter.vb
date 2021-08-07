Imports System.Data.SqlClient
Public Class frmbillfilter
    Public dat1 As New Date
    Public dat2 As New Date
    Private Sub frmbillfilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmbillfilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = dateyf
        dateyl1.Text = dateyl
        dat1 = dateyf
        dat2 = dateyl
        Try
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select Distinct PGROUP from tblAccount", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select acname from tblAccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox2.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select billno from salesc", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox3.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CheckedListBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.GotFocus, CheckedListBox2.GotFocus, CheckedListBox3.GotFocus
        Try
            sender.SelectedIndex = 0
            sender.BackColor = Color.LightYellow
        Catch ex As Exception

        End Try
       
    End Sub
    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.LostFocus, CheckedListBox2.LostFocus, CheckedListBox3.LostFocus
        sender.SelectedIndex = -1
        sender.BackColor = Color.White
    End Sub

    Private Sub CheckedListBox1_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck, CheckedListBox2.ItemCheck, CheckedListBox3.ItemCheck
        If CheckedListBox1.SelectedIndex = 0 Then
            SendKeys.Send("{DOWN}")
            SendKeys.Send("{UP}")
        ElseIf CheckedListBox1.SelectedIndex = CheckedListBox1.Items.Count - 1 Then
            SendKeys.Send("{UP}")
            SendKeys.Send("{DOWN}")
        Else
            SendKeys.Send("{UP}")
            SendKeys.Send("{DOWN}")

        End If
    End Sub
    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim I As Integer
            CheckedListBox2.Items.Clear()
            If CheckedListBox1.CheckedItems.Count = 0 Then
                CMD = New SqlCommand("Select ACName from tblAccount", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox2.Items.Add(DR.Item(0))
                End While
                DR.Close()
                GoTo EN
            End If
            CheckedListBox2.Items.Clear()
            For I = 0 To CheckedListBox1.CheckedItems.Count - 1
                CMD = New SqlCommand("sELECT * FROM TBLACCOUNT WHERE PGROUP='" & CheckedListBox1.CheckedItems(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox2.Items.Add(DR.Item("ACNAME"))
                End While
                DR.Close()
            Next
            CheckedListBox3.Items.Clear()
            For I = 0 To CheckedListBox2.Items.Count - 1
                CMD = New SqlCommand("Select billno from salesc where name='" & CheckedListBox2.Items(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox3.Items.Add(DR.Item(0))
                End While
                DR.Close()
            Next
            close1()
EN:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmbill.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim i As Integer
            CheckedListBox3.Items.Clear()
            If CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To CheckedListBox2.Items.Count - 1
                    cmd = New SqlCommand("select billno from salesc where name='" & CheckedListBox2.Items(i).ToString & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        CheckedListBox3.Items.Add(dr.Item(0))
                    End While
                    dr.Close()
                Next
            Else
                For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                    cmd = New SqlCommand("select billno from salesc where name='" & CheckedListBox2.CheckedItems(i).ToString & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        CheckedListBox3.Items.Add(dr.Item(0))
                    End While
                    dr.Close()
                Next
            End If

            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionStart = 0
        sender.backcolor = Color.Yellow
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            dat1 = MaskedTextBox1.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dateyf) > 0 Or DateDiff(DateInterval.Day, dat1, dateyl) < 0 Then
                MsgBox("Enter date in current A/c. Year")
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
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter proper date")
            MaskedTextBox2.Focus()
        End Try
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected

    End Sub

    Private Sub UserControl11_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserControl11.Leave
        MaskedTextBox1.Text = UserControl11.mydat
    End Sub

    Private Sub UserControl12_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserControl12.Leave
        MaskedTextBox2.Text = UserControl12.mydat
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            CheckedListBox3.Items.Clear()
            connect()
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text
            dat2 = MaskedTextBox2.Text
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select billno from salesc where billdt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox3.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

            Dim i As Integer
            For i = 0 To CheckedListBox3.Items.Count - 1
                If Val(CheckedListBox3.Items(i).ToString) >= Val(TextBox1.Text) And Val(CheckedListBox3.Items(i).ToString) <= Val(TextBox2.Text) Then
                    CheckedListBox3.SetItemChecked(i, True)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class