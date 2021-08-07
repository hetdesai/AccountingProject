Public NotInheritable Class SplashScreen1
    Dim i As Integer
    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = True
        Timer1.Interval = 1000
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        ApplicationTitle.Text = "It Software Solution"
        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

      End Sub

    Private Sub ApplicationTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplicationTitle.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If i = 2 Then
            frmLogin.Show()
            Me.Close()
        Else
            i = i + 1
        End If
    End Sub


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub MainLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
