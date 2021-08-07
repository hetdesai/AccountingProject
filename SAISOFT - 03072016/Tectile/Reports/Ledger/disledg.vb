Imports System.Data.SqlClient
Public Class disledg
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Private Sub disledg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            '  SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionStart = 0
        sender.backcolor = Color.Yellow
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
    Private Sub disledg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            connect()
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            cmd = New SqlCommand("Select ACName from tblAccount order by acname", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox1.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select distinct Schedule from tblAccount order by Schedule", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox2.AddItem(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ledg.Show()
    End Sub
    Private Sub MaskedTextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Enter, MaskedTextBox2.Enter
        sender.SelectionStart = 0
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim i As Integer
            Dim schedule As String = ""
            For i = 0 To CustomeChecklistbox2.CheckedItemsCount - 1
                schedule = schedule & "schedule='" & CustomeChecklistbox2.getCheckedItems(i) & "' or "
            Next
            schedule = schedule.Substring(0, schedule.Length - 4)
            cmd = New SqlCommand("Select acname from tblAccount where " & schedule, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox1.AddItem(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class