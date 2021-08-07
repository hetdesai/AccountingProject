Public Class frmMainScreen
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        frmRegistration.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        '  Me.Close()
        frmdisplay.Show()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        frmEdit.Show()

    End Sub

    Private Sub NormalDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalDataToolStripMenuItem.Click
        frmrptNormalReport.Show()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        frmBirthDayNotification.Show()

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        frmFeeSearch.Show()
    End Sub

    Private Sub GenderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenderToolStripMenuItem.Click
        frmrptGender.Show()
    End Sub

    Private Sub RollNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmrptRollNo.Show()

    End Sub

    Private Sub ClassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassToolStripMenuItem.Click
        frmrptClass.Show()

    End Sub

    Private Sub FirstNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstNameToolStripMenuItem.Click
        frmrptFirstName.Show()
    End Sub

    Private Sub SurnameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SurnameToolStripMenuItem.Click
        frmrptSurname.Show()
    End Sub

    Private Sub FeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FeeToolStripMenuItem.Click
        frmrptFee.Show()

    End Sub

    Private Sub ContactToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactToolStripMenuItem.Click
        frmrptContact.Show()
    End Sub

    Private Sub frmMainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Main Screen"
    End Sub

    Private Sub ChangeSemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeSemToolStripMenuItem.Click
        frmChangeSem.Show()
    End Sub

    Private Sub InOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InOrderToolStripMenuItem.Click
        frmorderedreports.Show()
    End Sub

    Private Sub ExitToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem2.Click
        Me.Close()
    End Sub
End Class