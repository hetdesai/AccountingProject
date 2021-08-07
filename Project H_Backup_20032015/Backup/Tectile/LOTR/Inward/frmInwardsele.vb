Imports System.Data.SqlClient
Public Class frmInwardsele

    Private Sub frmInwardsele_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmInwardsele_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            ComboBox1.Text = ComboBox1.Items(0).ToString
            ComboBox2.Text = ComboBox2.Items(0).ToString
            If frmMainScreen.inwardrpt.ToUpper = "Lot".ToUpper Then
                Label4.Visible = False
                ComboBox2.Visible = False
            Else
                Label3.Visible = False
                ComboBox1.Visible = False
            End If
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select max(convert(int,lotn)),min(convert(int,lotn)),min(convert(varchar,lotc)),min(convert(varchar,lotc)) from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox1.Text = dr.Item(1)
                TextBox2.Text = dr.Item(0)
                TextBox4.Text = dr.Item(2)
                TextBox3.Text = dr.Item(3)
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct pgroup from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct acname from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox2.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct item from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox5.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct mst from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox4.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select lotno from tblLotr order by convert(int,lotn)", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox3.Items.Add(dr.Item(0))
            End While
            dr.Close()

            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmPrintinward.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            CheckedListBox3.Items.Clear()
            connect()
            cmd = New SqlCommand("select lotno from tblLotr where convert(int,lotn)>=" & TextBox1.Text & " and convert(int,lotn)<=" & TextBox2.Text & " and ((convert(varchar,lotc)>'=" & TextBox3.Text & "' and convert(varchar,lotc)<='" & TextBox4.Text & "') or convert(varchar,lotc)='') order by convert(int,lotn)", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox3.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub CheckedListBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox2.GotFocus, CheckedListBox1.GotFocus, CheckedListBox3.GotFocus, CheckedListBox4.GotFocus, CheckedListBox5.GotFocus
        Try
            sender.SelectedIndex = 0
            sender.backcolor = Color.Pink
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox3.SelectedIndexChanged

    End Sub

    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.LostFocus, CheckedListBox2.LostFocus, CheckedListBox3.LostFocus, CheckedListBox4.LostFocus, CheckedListBox5.LostFocus
        Try
            sender.selectedindex = -1
            sender.backcolor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            Dim dat As New Date
            dat = sender.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox1.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox1.Focus()
        End Try
    End Sub
    Private Sub MaskedTextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Try
            Dim dat As New Date
            dat = sender.Text
            If DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox2.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox1.Focus()
        End Try
    End Sub
End Class