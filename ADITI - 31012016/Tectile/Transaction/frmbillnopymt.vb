Public Class frmbillnopymt
    Dim check As Integer
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox1.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox1.Text
        For i = temp1 To frmoutpmt.dgbill.Rows.Count - 1
            For j = temp2 To frmoutpmt.dgbill.ColumnCount - 1
                If j = -1 Then
                    GoTo a
                Else
                    Try
                        If (frmoutpmt.dgbill.Item(j, i).Value.ToString.ToUpper.Contains(TextBox1.Text.ToUpper)) Then
                            frmoutpmt.dgbill.Item(j, i).Selected = True
                            temp2 = j + 1
                            '    check = 1
                            GoTo en
                        End If
                    Catch ex As Exception

                    End Try

                End If

a:

            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAccountSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 550
        Me.Left = 600
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Button1.Focus()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class