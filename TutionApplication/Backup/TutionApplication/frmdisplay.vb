Public Class frmdisplay

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label1.Font = FontDialog1.Font
            Label2.Font = FontDialog1.Font
            Label2.Font = FontDialog1.Font
            My.Settings.Lblfont = FontDialog1.Font
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label1.ForeColor = ColorDialog1.Color
            Label2.ForeColor = ColorDialog1.Color
            Label2.ForeColor = ColorDialog1.Color
            My.Settings.lblcol = ColorDialog1.Color
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
            My.Settings.backcolor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        My.Settings.Save()
    End Sub
End Class