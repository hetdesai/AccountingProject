Public Class frmAccountSearch
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
        For i = temp1 To frmACMaster.dg1.Rows.Count - 1
            For j = temp2 To frmACMaster.dg1.ColumnCount - 1
                If j <> frmACMaster.findcol Then
                    GoTo a
                Else
                    If (frmACMaster.dg1.Item(j, i).Value.ToString.ToUpper.Contains(TextBox1.Text.ToUpper)) Then
                        frmACMaster.dg1.Item(j, i).Selected = True
                        temp2 = j + 1
                        '    check = 1
                        GoTo en
                    End If
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