Public Class frmItemSearch
    Dim check As Integer
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

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
        For i = temp1 To frmITMaster.DG1.Rows.Count - 2
            For j = temp2 To frmITMaster.DG1.ColumnCount - 1
                If (frmITMaster.DG1.Item(j, i).Value.ToString.Contains(TextBox1.Text)) Then
                    frmITMaster.DG1.Item(j, i).Selected = True
                    temp2 = j + 1
                    '    check = 1
                    GoTo en
                End If
            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub frmItemSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 500
        Me.Left = 500
    End Sub
End Class