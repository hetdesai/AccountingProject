Public Class frmBirthDayNotification
    Public bcheck As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            bcheck = 1
        ElseIf RadioButton2.Checked = True Then
            bcheck = 2
        ElseIf RadioButton3.Checked = True Then
            bcheck = 3
        Else
            bcheck = 4
        End If

        frmbShow.Show()

    End Sub

    Private Sub frmBirthDayNotification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "BirthDay Notification"
    End Sub
End Class