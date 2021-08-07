Imports System.Data.OleDb
Public Class frmSchoolMaster
    Dim cmd As New OleDbCommand
    Dim cmd2 As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim dr1 As OleDbDataReader
    Private Sub frmSchoolMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ("School Entry")
        Connect()
        cmd = New OleDbCommand("Select count(ID) from tblSchool", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            If dr.Item(0) = 0 Then
                TextBox1.Text = 1
            Else
                cmd2 = New OleDbCommand("Select Max(ID) from tblSchool", cn)
                dr1 = cmd2.ExecuteReader
                While dr1.Read
                    TextBox1.Text = (dr1.Item(0) + 1)
                End While
                dr1.Close()
            End If
        End While
        dr.Close()
        Close1()
        Connect()
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        da = New OleDbDataAdapter("Select * from tblSchool", cn)
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Close1()


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Connect()
        cmd = New OleDbCommand("Select count(ID) from tblSchool", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            If dr.Item(0) = 0 Then
                TextBox1.Text = 1
            Else
                cmd2 = New OleDbCommand("Select Max(ID) from tblSchool", cn)
                dr1 = cmd2.ExecuteReader
                While dr1.Read
                    TextBox1.Text = (dr1.Item(0) + 1)
                End While
                dr1.Close()
            End If
        End While
        dr.Close()
        Close1()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Connect()
        cmd = New OleDbCommand("insert into tblSchool values(" & TextBox1.Text & ",'" & TextBox2.Text & "')", cn)
        cmd.ExecuteNonQuery()
        Close1()
        Dim ds As New DataSet
        Dim da As New OleDbDataAdapter
        da = New OleDbDataAdapter("Select * from tblSchool", cn)
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Close1()
        Connect()
        cmd = New OleDbCommand("Select count(ID) from tblSchool", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            If dr.Item(0) = 0 Then
                TextBox1.Text = 1
            Else
                cmd2 = New OleDbCommand("Select Max(ID) from tblSchool", cn)
                dr1 = cmd2.ExecuteReader
                While dr1.Read
                    TextBox1.Text = (dr1.Item(0) + 1)
                End While
                dr1.Close()
            End If
        End While
        dr.Close()
        Close1()
        frmRegistration.txtSName.AutoCompleteCustomSource.Add(TextBox2.Text)
        TextBox2.Clear()
    End Sub
End Class