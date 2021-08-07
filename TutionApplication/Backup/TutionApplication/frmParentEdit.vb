Imports System.Data.OleDb
Public Class frmParentEdit
    Public ID As Integer
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
    Dim da As New OleDbDataAdapter
    Dim dr As OleDbDataReader
    Private Sub focus(ByVal sender As Object, ByVal e As EventArgs) Handles txtFAddress.GotFocus, txtFContact.GotFocus, txtFdetail.GotFocus, txtFName.GotFocus, txtMaddress.GotFocus, txtMdetail.GotFocus, txtMName.GotFocus, txtMaddress.GotFocus, txtMdetail.GotFocus, txtSid.GotFocus, txtSuname.GotFocus
        sender.BackColor = Color.Pink
    End Sub
    Private Sub lofocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtFAddress.LostFocus, txtFContact.LostFocus, txtFdetail.LostFocus, txtFName.LostFocus, txtMaddress.LostFocus, txtMdetail.LostFocus, txtMName.LostFocus, txtMaddress.LostFocus, txtMdetail.LostFocus, txtSid.LostFocus, txtSuname.LostFocus
        sender.BackColor = Color.White
    End Sub

    Private Sub frmParentEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmParentEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Edit Parents Detail"
        ID = frmEdit2.txtStudentId.Text
        Connect()
        cmd = New OleDbCommand("Select * from tblParentsInfo where ID=" & ID, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            txtFAddress.Text = dr.Item("Address")
            txtFContact.Text = dr.Item("ContactNo")
            txtFdetail.Text = dr.Item("Details")
            txtFName.Text = dr.Item("FName")
            txtMaddress.Text = dr.Item("MAddress")
            txtMdetail.Text = dr.Item("MDetails")
            txtMName.Text = dr.Item("MName")
            txtSid.Text = dr.Item("ID")
            txtSuname.Text = dr.Item("SName")
            If dr.Item("Foccupation").Equals("Service") Then
                radService.Checked = True
            Else
                radBusiness.Checked = True
            End If
            If dr.Item("Moccupation").Equals("Service") Then
                radMService.Checked = True
            ElseIf dr.Item("Moccupation").Equals("Business") Then
                radMbusiness.Checked = True
            Else
                radMHouse.Checked = True
            End If
        End While
        dr.Close()
        txtFName.Focus()
        Close1()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        frmEdit2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Connect()
        Dim sql As String
        If frmEdit.mode = 1 Then
            Dim Gender As String
            If frmEdit2.radMale.Checked = True Then
                Gender = "Male"
            Else
                Gender = "Female"
            End If
            'If System.IO.File.Exists("E:\My VB WORK\" & frmEdit2.TextBox1.Text & frmEdit2.TextBox2.Text) Then
            'System.IO.File.Delete("E:\My VB WORK\" & frmEdit2.TextBox1.Text & frmEdit2.TextBox2.Text)
            'End If
            'Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp
            'Dim image As String
            'image = frmEdit2.TextBox1.Text & frmEdit2.TextBox2.Text
            'frmEdit2.pbS_Image.Image.Save("E:\My VB WORK\" & frmEdit2.TextBox1.Text & frmEdit2.TextBox2.Text, Format)
            sql = "Update tblStudentInfo set St_FName='" & frmEdit2.txtS_FName.Text & "', St_MName='" & frmEdit2.txtS_MName.Text & "', St_SName='" & frmEdit2.txtS_SName.Text & "', Email='" & frmEdit2.txtEmail.Text & "', "
            sql = sql & "Address='" & frmEdit2.txtAdd.Text & "', SchoolName='" & frmEdit2.txtSName.Text & "', Gender='" & Gender & "', Course='" & frmEdit2.txtCourse.Text & "', "
            sql = sql & "Duration='" & frmEdit2.txtDuration.Text & "', HomePhone='" & frmEdit2.txtHome.Text & "', MobileNo='" & frmEdit2.txtMob.Text & "', NetivePlace='" & frmEdit2.txtNative.Text & "', "
            sql = sql & "DateOfBirthday='" & frmEdit2.txtDateOfBirthday.Text & "', Standard=" & frmEdit2.txtStandard.Text & ", Div='" & frmEdit2.txtDiv.Text & "', DateOfEntry='" & frmEdit2.txtDateOfEntry.Text & "', "
            sql = sql & "ProposedStandardEntry=" & frmEdit2.cmdStandard.Text & ", Tenth=" & frmEdit2.txtTenth.Text & ", Year1=" & frmEdit2.txtYear.Text & ", Sem=" & frmEdit2.cmdSem.Text & ",Batch='" & frmEdit2.TextBox1.Text & "',RollNo=" & frmEdit2.TextBox2.Text & ",Fee=" & frmEdit2.TextBox3.Text & " where ID=" & txtSid.Text
            cmd = New OleDbCommand(sql, cn)
            cmd.ExecuteNonQuery()
            MsgBox("Successfuly Updated")
        Else
            sql = "Delete from tblStudentInfo where ID=" & txtSid.Text
            cmd = New OleDbCommand(sql, cn)
            cmd.ExecuteNonQuery()
            MsgBox("Successfuly Done")
        End If
        Close1()
        Me.Close()
        frmEdit2.Close()
        frmEdit.Close()
        frmEdit.Show()
    End Sub

End Class