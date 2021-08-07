'Option Explicit On
'Option Strict On
Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class frmRegistration
    Dim cmd As New OleDbCommand
    Dim cmd2 As New OleDbCommand
    Dim da As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim dr As OleDbDataReader
    Dim dr1 As OleDbDataReader
    'variables for webcam
    Private CamFrameRate As Integer = 15
    Private OutputHeight As Integer = 240
    Private OutputWidth As Integer = 360
    Public iRunning As Boolean

    Dim mycam As New iCam
    Private Sub focus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAdd.GotFocus, txtCourse.GotFocus, txtDateOfBirthday.GotFocus, txtDateOfEntry.GotFocus, txtDiv.GotFocus, txtDuration.GotFocus, txtEmail.GotFocus, txtHome.GotFocus, txtMob.GotFocus, txtNative.GotFocus, txtS_FName.GotFocus, txtS_SName.GotFocus, txtS_MName.GotFocus, txtSName.GotFocus, txtStandard.GotFocus, txtStudentId.GotFocus, txtTenth.GotFocus, txtTenth.GotFocus, txtYear.GotFocus, TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, cmdSem.GotFocus, cmdStandard.GotFocus
        sender.BackColor = Color.Pink
    End Sub
    Private Sub lofocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtAdd.LostFocus, txtCourse.LostFocus, txtDateOfBirthday.LostFocus, txtDateOfEntry.LostFocus, txtDiv.LostFocus, txtDuration.LostFocus, txtEmail.LostFocus, txtHome.LostFocus, txtMob.LostFocus, txtNative.LostFocus, txtS_FName.LostFocus, txtS_SName.LostFocus, txtS_MName.LostFocus, txtSName.LostFocus, txtStandard.LostFocus, txtStudentId.LostFocus, txtTenth.LostFocus, txtTenth.LostFocus, txtYear.LostFocus, TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, cmdSem.LostFocus, cmdStandard.LostFocus
        sender.BackColor = Color.White
    End Sub

    Private Sub frmRegistration_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Student Entry"
        txtTenth.Text = "0"
        txtMob.Text = "0"
        txtHome.Text = "0"
        cmdStandard.Text = "0"
        cmdSem.Text = "0"
        txtStandard.Text = "0"
        TextBox1.Text = ""
        TextBox2.Text = "0"
        TextBox3.Text = "0"
        txtDuration.Text = "0"
        txtYear.Text = Date.Today.Year
        '      mycam.initCam(Me.pbS_Image.Handle.ToInt32)
        Connect()
        cmd = New OleDbCommand("Select count(ID) from tblStudentInfo", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            If dr.Item(0) = 0 Then
                txtStudentId.Text = 1
            Else
                cmd2 = New OleDbCommand("Select Max(ID) from tblStudentInfo", cn)
                dr1 = cmd2.ExecuteReader
                While dr1.Read
                    txtStudentId.Text = (dr1.Item(0) + 1)
                End While
                dr1.Close()
            End If
        End While
        dr.Close()
        cmd = New OleDbCommand("Select * from tblSchool", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            txtSName.AutoCompleteCustomSource.Add(dr.Item(1))
        End While
        dr.Close()
        Close1()
        txtDateOfEntry.Text = Format(Date.Today, "dd-MM-yyyy")
    End Sub

    Private Sub frmRegistration_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        '     e.Graphics.DrawLine(Pens.Blue, 150, 60, 380, 60)
        '    e.Graphics.DrawLine(Pens.Blue, 470, 60, 750, 60)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        '  If (ValidateFun()) Then
        frmParentsDetail.txtSid.Text = txtStudentId.Text
        ' Me.Close()
        frmParentsDetail.Show()

        'Else
        'End If
    End Sub
    Private Function ValidateFun() As Boolean
        Dim val As Boolean = True
        Dim i As Integer = 0
        If txtAdd.Text.Trim.Length = 0 Then
            MsgBox("Address Empty")
            i = 1
            Return False
        End If
        If txtCourse.Text.Trim.Length = 0 Then
            MsgBox("Course Empty")
            i = 1
            Return False
        End If
        If txtDateOfBirthday.Text.Trim.Length = 0 Then
            MsgBox("Date Of Birth Empty")
            i = 1
            Return False
        End If
        If txtDateOfEntry.Text.Trim.Length = 0 Then
            MsgBox("Date Of Entry Empty")
            i = 1
            Return False
        End If
        If txtDiv.Text.Trim.Length = 0 Then
            MsgBox("Div Empty")
            i = 1
            Return False
        End If
        If txtDuration.Text.Trim.Length = 0 Then
            MsgBox("Duration Empty")
            i = 1
            Return False
        End If
        If txtEmail.Text.Trim.Length = 0 Then
            MsgBox("Email Empty")
            i = 1
            Return False
        End If
        If txtHome.Text.Trim.Length = 0 Then
            MsgBox("Home Phone Empty")
            i = 1
            Return False
        End If
        If txtMob.Text.Trim.Length = 0 Then
            MsgBox("Mobile No Empty")
            i = 1
            Return False
        End If
        If txtNative.Text.Trim.Length = 0 Then
            MsgBox("Native place Empty")
            i = 1
            Return False
        End If
        If txtS_FName.Text.Trim.Length = 0 Then
            MsgBox("Student First Name Empty")
            i = 1
            Return False
        End If
        If txtS_MName.Text.Trim.Length = 0 Then
            MsgBox("Middle Name Empty")
            i = 1
            Return False
        End If
        If txtS_SName.Text.Trim.Length = 0 Then
            MsgBox("Surname Empty")
            i = 1
            Return False
        End If
        If txtStandard.Text.Trim.Length = 0 Then
            MsgBox("Standard Empty")
            i = 1
            Return False
        End If
        If txtTenth.Text.Trim.Length = 0 Then
            MsgBox("Tenth percentage is Empty")
            i = 1
            Return False
        End If
        If cmdSem.Text.Trim.Length = 0 Then
            MsgBox("Sem Empty")
            i = 1
            Return False
        End If
        If cmdStandard.Text.Trim.Length = 0 Then
            MsgBox("Propose Standard Empty")
            i = 1
            Return False
        End If
        Dim loopcount As Integer
        If txtEmail.Text.Contains(".") = False Then
            MsgBox("Invalid E-mail Id")
            i = 1
            Return False
        End If
        Dim j As Integer = 0
        For loopcount = 0 To txtEmail.Text.Length - 1
            If txtEmail.Text.Chars(loopcount) = "@" Then
                If j = 1 Then
                    i = 1
                    MsgBox("Invalid E-mial Id")
                    Return False

                Else
                    j = 1
                End If

            End If
        Next

        If i = 0 Then
            Return True
        Else
            Return False

        End If
    End Function



    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.PictureBox1.Image = mycam.copyFrame(Me.pbS_Image, New RectangleF(0, 0, Me.pbS_Image.Width, Me.pbS_Image.Height))
        PictureBox1.BringToFront()

        '      mycam.closeCam()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.SendToBack()

    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtAdd.Clear()
        txtCourse.Clear()
        txtDateOfEntry.Clear()
        txtDateOfBirthday.Clear()
        txtDiv.Clear()
        txtDuration.Clear()
        txtEmail.Clear()
        txtHome.Clear()
        txtMob.Clear()
        txtNative.Clear()
        txtS_FName.Clear()
        txtS_MName.Clear()
        txtS_SName.Clear()
        txtSName.Clear()
        txtStandard.Clear()
        txtTenth.Clear()
        txtYear.Clear()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frmSchoolMaster.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ' PictureBox1 .Image =
        '  PictureBox1.Load()

    End Sub
End Class
