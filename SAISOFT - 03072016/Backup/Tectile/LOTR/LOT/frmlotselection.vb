Imports System.Data.SqlClient
Public Class frmlotselection
    Private Sub frmlotselection_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Close()
        End If
    End Sub

    Private Sub frmlotselection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        connect()
        MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
        MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("select billno from sale order by convert(INT,Billno)", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            CheckedListBox1.Items.Add(dr.Item(0))
        End While
        dr.Close()
        close1()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            CheckedListBox1.Items.Clear()
            connect()
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text
            dat2 = MaskedTextBox2.Text
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select billno from sale where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' order by convert(INT,billno)", cn)
            dr = cmd.ExecuteReader
            CheckedListBox1.Items.Clear()
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
            frmchlnprint.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class