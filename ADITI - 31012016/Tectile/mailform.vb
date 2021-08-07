Imports System.Net.Mail
Imports System.Data.SqlClient
Public Class mailform
    Dim mail As New MailMessage()
    Private Sub mailform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Text = "xyz@gmail.com"
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select acname from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential("hetdesai13@gmail.com", "337244381")
        SmtpServer.Port = 587
        SmtpServer.Host = "smtp.gmail.com"
        SmtpServer.EnableSsl = True

        mail = New MailMessage()
        Dim addr() As String = TextBox1.Text.Split(",")
        Try
            mail.From = New MailAddress("hetdesai13@gmail.com", "het desai", System.Text.Encoding.UTF8)
            Dim i As Byte
            For i = 0 To addr.Length - 1
                mail.To.Add(addr(i))
            Next
            mail.Subject = TextBox3.Text
            mail.Body = TextBox4.Text
            If ListBox1.Items.Count <> 0 Then
                For i = 0 To ListBox1.Items.Count - 1
                    mail.Attachments.Add(New Attachment(ListBox1.Items.Item(i)))
                Next
            End If
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            mail.ReplyTo = New MailAddress(TextBox1.Text)
            SmtpServer.Send(mail)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ListBox1.Items.Add(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim i As Integer
            TextBox1.Clear()
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                cmd = New SqlCommand("select emailid from tblaccount where acname='" & CheckedListBox1.CheckedItems(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    TextBox1.Text = TextBox1.Text & dr.Item(0) & ","
                End While
                dr.Close()
            Next
            close1()
            TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class