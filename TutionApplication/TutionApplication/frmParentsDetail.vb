Imports System.Data.OleDb
Public Class frmParentsDetail
    Dim cmd As New OleDbCommand
    Dim da As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim dr As OleDbDataReader

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        frmRegistration.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String
        Dim gender As String
        Dim picture As String
        Dim fo As String
        Dim mo As String
        If radService.Checked = True Then
            fo = "Service"
        Else
            fo = "Business"
        End If
        If radMService.Checked = True Then
            mo = "Service"
        ElseIf radMbusiness.Checked = True Then
            mo = "Business"
        Else
            mo = "HouseWife"
        End If
        If frmRegistration.radFemale.Checked = True Then
            gender = "Female"
        Else
            gender = "Male"
        End If
        Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp
        frmRegistration.PictureBox1.Image.Save("C:\ITSoftware\Images\" & txtSid.Text, format)
        picture = txtSid.Text
        Connect()
        sql = "insert into tblStudentInfo values(" & frmRegistration.txtStudentId.Text & ",'" & frmRegistration.txtS_FName.Text & "','" & frmRegistration.txtS_MName.Text & "','" & frmRegistration.txtS_SName.Text & "','" & frmRegistration.txtEmail.Text & "','" & frmRegistration.txtAdd.Text & "','" & frmRegistration.txtSName.Text & "','" & gender & "','" & frmRegistration.txtCourse.Text & "','" & frmRegistration.txtDuration.Text & "','" & frmRegistration.txtHome.Text & "','" & frmRegistration.txtMob.Text & "','" & frmRegistration.txtNative.Text & "','" & frmRegistration.txtDateOfBirthday.Text & "'," & frmRegistration.txtStandard.Text & ",'" & frmRegistration.txtDiv.Text & "','" & Date.Today & "'," & frmRegistration.cmdStandard.Text & "," & frmRegistration.txtTenth.Text & ",'" & picture & "'," & frmRegistration.txtYear.Text & "," & frmRegistration.cmdSem.Text & ",'" & frmRegistration.TextBox1.Text & "'," & frmRegistration.TextBox2.Text & "," & frmRegistration.TextBox3.Text & "," & "'ACTIVE'" & ")"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        sql = "insert into tblParentsInfo values(" & txtSid.Text & ",'" & txtMName.Text & "','" & txtFName.Text & "','" & txtSuname.Text & "','" & fo & "','" & txtFdetail.Text & "','" & txtFContact.Text & "','" & txtFAddress.Text & "','" & mo & "','" & txtMdetail.Text & "','" & txtMaddress.Text & "')"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        sql = "insert into tblRemFee values(" & txtSid.Text & "," & frmRegistration.TextBox3.Text & ")"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        MsgBox("successfully inserted")
        Close1()
        frmRegistration.Show()

    End Sub
    Private Sub focus(ByVal sender As Object, ByVal e As EventArgs) Handles txtFAddress.GotFocus, txtFContact.GotFocus, txtFdetail.GotFocus, txtFName.GotFocus, txtMaddress.GotFocus, txtMdetail.GotFocus, txtMName.GotFocus, txtMaddress.GotFocus, txtMdetail.GotFocus, txtSid.GotFocus, txtSname.GotFocus, txtSuname.GotFocus
        sender.BackColor = Color.Pink
    End Sub
    Private Sub lofocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtFAddress.LostFocus, txtFContact.LostFocus, txtFdetail.LostFocus, txtFName.LostFocus, txtMaddress.LostFocus, txtMdetail.LostFocus, txtMName.LostFocus, txtMaddress.LostFocus, txtMdetail.LostFocus, txtSid.LostFocus, txtSname.LostFocus, txtSuname.LostFocus
        sender.BackColor = Color.White
    End Sub

    Private Sub frmParentsDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frmParentsDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Parent Detail Entry"
        txtFContact.Text = "0"
        txtSname.Text = frmRegistration.txtS_FName.Text & " " & frmRegistration.txtS_MName.Text & " " & frmRegistration.txtS_SName.Text
        txtSuname.Text = frmRegistration.txtS_SName.Text
        txtFName.Focus()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmRegistration.Close()
        frmRegistration.Show()
        Me.Close()
    End Sub

    Private Sub txtMaddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaddress.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Hide()
        frmRegistration.Show()

    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class