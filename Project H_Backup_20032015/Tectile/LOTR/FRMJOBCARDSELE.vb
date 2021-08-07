Public Class FRMJOBCARDSELE

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub MaskedTextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Enter, MaskedTextBox2.Enter
        sender.SelectionLength = 0
        sender.SelectionStart = 0
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionLength = 0
        sender.SelectionStart = 0
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmjobcarddis.Show()
    End Sub

    Private Sub FRMJOBCARDSELE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Date.Today
        MaskedTextBox2.Text = Date.Today
    End Sub
End Class