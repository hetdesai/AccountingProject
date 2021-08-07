Public Class Form2
    Dim check As Integer
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
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
        For i = temp1 To frmFeeSearch.DataGridView1.Rows.Count - 2
            For j = temp2 To frmFeeSearch.DataGridView1.ColumnCount - 1
                If (frmFeeSearch.DataGridView1.Item(j, i).Value.ToString.Contains(TextBox1.Text)) Then
                    frmFeeSearch.DataGridView1.Item(j, i).Selected = True
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

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Search"
    End Sub
End Class