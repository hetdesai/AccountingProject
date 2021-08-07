Imports System.Data.OleDb
Public Class frmLogin
    Dim cmd As New OleDbCommand
    Dim da As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim dr As OleDbDataReader
    Public i As Integer = 0
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' MsgBox(System.IO.File.Exists("C:\Intel\ExtremeGraphics\CUI\Resource\Document.txt"))
        'If System.IO.File.Exists("C:\Intel\ExtremeGraphics\CUI\Resource\Document1.txt") = False Then
        'MsgBox("Do not copy my Software without my permission")
        'Me.Close()
        'End If
        Me.Text = "Login Form"
        Dim dat As New Date
        dat = "01-08-2012"
        If DateDiff(DateInterval.Day, Date.Today, dat) < 0 Then
            Me.Close()
        End If
        SplashScreen1.Show()
        Me.Hide()
        txtUserName.Focus()
        Timer1.Enabled = True
        Timer1.Interval = 500
        txtUserName.Text = ""
        txtPassword.Text = ""
        cmdUserType.Text = ""



    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If i = 0 Then
            Label4.ForeColor = Color.DarkViolet
            i = 1
        Else
            Label4.ForeColor = Color.Red
            i = 0
        End If
    End Sub

    Private Sub btSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSignIn.Click
        Connect()
        cmd = New OleDbCommand("Select * from tblLogin where UserName='" & txtUserName.Text & "' and Password='" & txtPassword.Text & "' and UserType='" & cmdUserType.Text & "'", cn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            frmMainScreen.Show()
            txtUserName.Clear()
            txtPassword.Clear()
            cmdUserType.Text = ""
        Else
            MsgBox("Incorrect UserName and Password")
        End If
        Close1()
    End Sub

    Private Sub btExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExit.Click
        Me.Close()
    End Sub
End Class
