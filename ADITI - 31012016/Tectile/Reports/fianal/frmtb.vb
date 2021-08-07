Imports System.Data.SqlClient

Public Class frmtb
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Private Sub frmtb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmtb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            connect()
            cmd = New SqlCommand("Select Mhead from tblMH", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox3.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select Shead from tblSH", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select ACName from tblAccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox2.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim I As Integer
            '    MsgBox(CheckedListBox1.CheckedItems.Count)
            If CheckedListBox1.CheckedItems.Count = 0 Then
                GoTo EN
            End If
            CheckedListBox2.Items.Clear()
            For I = 0 To CheckedListBox1.CheckedItems.Count - 1
                CMD = New SqlCommand("sELECT * FROM TBLACCOUNT WHERE Schedule='" & CheckedListBox1.CheckedItems(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox2.Items.Add(DR.Item("ACNAME"))
                End While
                DR.Close()
            Next
            close1()
EN:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox3.SelectedIndexChanged
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim I As Integer
            '    MsgBox(CheckedListBox1.CheckedItems.Count)
            If CheckedListBox3.CheckedItems.Count = 0 Then
                GoTo EN
            End If
            CheckedListBox1.Items.Clear()
            For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                CMD = New SqlCommand("sELECT * FROM TBLSH WHERE Mhead='" & CheckedListBox3.CheckedItems(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox1.Items.Add(DR.Item("Shead"))
                End While
                DR.Close()
            Next
            CheckedListBox2.Items.Clear()
            For I = 0 To CheckedListBox1.Items.Count - 1
                CMD = New SqlCommand("sELECT * FROM TBLACCOUNT WHERE Schedule='" & CheckedListBox1.Items(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox2.Items.Add(DR.Item("ACNAME"))
                End While
                DR.Close()
            Next
            close1()
EN:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '        frmprinttb.Show()
        frmtbdis.Show()
    End Sub

    Private Sub MaskedTextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Enter, MaskedTextBox2.Enter
        sender.SelectionStart = 0

    End Sub
End Class