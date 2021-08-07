Public Class frmtrndis

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
            My.Settings.tranbkcolor = Me.BackColor
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.Save()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label1.Font = FontDialog1.Font
            Label2.Font = FontDialog1.Font
            Label3.Font = FontDialog1.Font
            My.Settings.tranfont = FontDialog1.Font
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label1.ForeColor = ColorDialog1.Color
            Label2.ForeColor = ColorDialog1.Color
            Label3.ForeColor = ColorDialog1.Color
            My.Settings.tranfocolor = ColorDialog1.Color
        End If
    End Sub

    Private Sub frmtrndis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmtrndis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class