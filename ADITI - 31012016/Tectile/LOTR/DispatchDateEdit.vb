Imports System.Data.SqlClient
Public Class DispatchDateEdit

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            CheckedListBox1.Items.Clear()
            Dim dat As New Date
            dat = MaskedTextBox1.Text
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select convert(INT,BILLNO) from sale where billdt='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and Convert(INT,BILLNO) >= " & Val(TextBox1.Text) & " and Convert(INT,BILLNO) <= " & Val(TextBox2.Text), cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))

            End While
            dr.Close()
            Dim i As Integer
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub DispatchDateEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select acname from tblAccount where book='Sales'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox1.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If MessageBox.Show("Do you want to delete all selected tables", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If MsgBox("This is the final warning. Are you want to delete all the selected tables", vbYesNo) = Windows.Forms.DialogResult.Yes Then

                    Dim olddat As New Date
                    Dim newdat As New Date
                    olddat = MaskedTextBox1.Text
                    newdat = MaskedTextBox2.Text
                    connect()

                    Dim cmd As New SqlCommand
                    Dim i As Integer
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        cmd = New SqlCommand("Update sale set billdt='" & newdat.Month & "-" & newdat.Day & "-" & newdat.Year & "' where billno='" & CheckedListBox1.CheckedItems(i) & "'", cn)
                        cmd.ExecuteNonQuery()
                        cmd = New SqlCommand("Update sale1 set billdt='" & newdat.Month & "-" & newdat.Day & "-" & newdat.Year & "' where billno='" & CheckedListBox1.CheckedItems(i) & "'", cn)
                        cmd.ExecuteNonQuery()
                        cmd = New SqlCommand("Update salet set billdt='" & newdat.Month & "-" & newdat.Day & "-" & newdat.Year & "' where billno='" & CheckedListBox1.CheckedItems(i) & "'", cn)
                        cmd.ExecuteNonQuery()
                    Next
                    MessageBox.Show("Bill date Edited")
                    close1()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub
End Class