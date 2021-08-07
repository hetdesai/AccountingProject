Imports System.Data.SqlClient
Public Class frmitemMearge

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you want to mearge the Items", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            GroupBox1.Visible = True
            Dim i As Integer
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                CheckedListBox2.Items.Add(CheckedListBox1.CheckedItems(i).ToString)
            Next
        End If
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        Try
            If ComboBox1.Items.Contains(ComboBox1.Text) = False Then
                MsgBox("Select from List")
                ComboBox1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            If MsgBox("This is the final warning.Are you sure you want to mearge the items ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim i As Integer
                Dim accode As Integer
                Dim acname As String
                For i = 0 To CheckedListBox2.Items.Count - 1
                    accode = CheckedListBox2.Items(i).ToString.Substring(0, CheckedListBox2.Items(i).ToString.Split("&").Length - 1)
                    acname = CheckedListBox2.Items(i).ToString.Substring(CheckedListBox2.Items(i).ToString.Split("&").Length)
                    cmd = New SqlCommand("Update sale1 set itname='" & ComboBox1.Text & "',itcode=" & TextBox1.Text & " where itname='" & acname & "' and itcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salec1 set itname='" & ComboBox1.Text & "',itcode=" & TextBox1.Text & " where itname='" & acname & "' and itcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblit2 set itname='" & ComboBox1.Text & "' where itname='" & acname & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblitopen set item='" & ComboBox1.Text & "',itcode=" & TextBox1.Text & " where item='" & acname & "' and itcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblLotr set item='" & ComboBox1.Text & "',itcode=" & TextBox1.Text & " where item='" & acname & "' and itcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblLotrt set itcode=" & TextBox1.Text & " where itcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurchaseDetail set itname='" & ComboBox1.Text & "',itcode=" & TextBox1.Text & " where itname='" & acname & "' and itcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblStock set itname='" & ComboBox1.Text & "' where itname='" & acname & "'", cn)
                    cmd.ExecuteNonQuery()
                Next
                close1()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmAccountMearge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblitem", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item("itCode") & "&" & dr.Item("itname"))
                ComboBox1.Items.Add(dr.Item("itname"))
            End While
            dr.Close()

            close1()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select * from tblitem where itname='" & ComboBox1.Text & "'", cn)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select itcode from tblitem where itname='" & ComboBox1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox1.Text = dr.Item(0)
            End While
            dr.Close()
            close1()
        Catch ex As Exception

        End Try
    End Sub
End Class