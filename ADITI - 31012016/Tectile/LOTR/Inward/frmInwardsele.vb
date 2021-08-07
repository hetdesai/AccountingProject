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

            Try


                cmd = New SqlCommand("Select max(convert(int,lotn)),min(convert(int,lotn)),min(convert(varchar,lotc)),min(convert(varchar,lotc)) from tblLotr", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    TextBox1.Text = dr.Item(1)
                    TextBox2.Text = dr.Item(0)
                    TextBox4.Text = dr.Item(2)
                    TextBox3.Text = dr.Item(3)
                End While
                dr.Close()
            Catch ex As Exception
                dr.Close()
            End Try
            cmd = New SqlCommand("select distinct pgroup from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox1.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct acname from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox2.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct item from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox3.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct mst from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox5.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select lotno from tblLotr order by convert(int,lotn)", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox4.AddItem(dr.Item(0))
            End While
            dr.Close()
            MaskedTextBox1.Focus()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmPrintinward.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Try
        '    Dim cmd As New SqlCommand
        '    Dim dr As SqlDataReader
        '    CheckedListBox3.Items.Clear()
        '    connect()
        '    cmd = New SqlCommand("select lotno from tblLotr where convert(int,lotn)>=" & TextBox1.Text & " and convert(int,lotn)<=" & TextBox2.Text & " and ((convert(varchar,lotc)>'=" & TextBox3.Text & "' and convert(varchar,lotc)<='" & TextBox4.Text & "') or convert(varchar,lotc)='') order by convert(int,lotn)", cn)
        '    dr = cmd.ExecuteReader
        '    While dr.Read
        '        CheckedListBox3.Items.Add(dr.Item(0))
        '    End While
        '    dr.Close()
        '    close1()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

    End Sub

    Private Sub CheckedListBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            sender.SelectedIndex = 0
            sender.backcolor = Color.Pink
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            sender.selectedindex = -1
            sender.backcolor = Color.White
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MaskedTextBox1_GotFocus(sender As Object, e As EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionStart = 0
        sender.SelectionLength = 0
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        'Try
        '    Dim dat As New Date
        '    dat = sender.Text
        '    If DateDiff(DateInterval.Day, dat, dateyf) > 0 Then
        '        MsgBox("Enter date in current A/c Year")
        '        MaskedTextBox1.Focus()
        '    End If
        '    sender.backcolor = Color.White
        'Catch ex As Exception
        '    MsgBox("Enter Proper Date")
        '    MaskedTextBox1.Focus()
        'End Try
    End Sub

    Private Sub MaskedTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        End If
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

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

   

   
    Private Sub CustomeChecklistbox1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CustomeChecklistbox5_Load(sender As Object, e As EventArgs) Handles CustomeChecklistbox5.Load

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub CustomeChecklistbox1_GotFocus(sender As Object, e As EventArgs) Handles CustomeChecklistbox1.GotFocus, CustomeChecklistbox2.GotFocus, CustomeChecklistbox3.GotFocus, CustomeChecklistbox4.GotFocus, CustomeChecklistbox5.GotFocus
        '  sender.backcolor = Color.Yellow
    End Sub

    Private Sub CustomeChecklistbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CustomeChecklistbox1.KeyDown
        If e.KeyCode = Keys.N Then
            ' MessageBox.Show("sd")
            CustomeChecklistbox2.Focus()
        End If
    End Sub

    Private Sub CustomeChecklistbox1_LostFocus(sender As Object, e As EventArgs) Handles CustomeChecklistbox1.LostFocus, CustomeChecklistbox2.LostFocus, CustomeChecklistbox3.LostFocus, CustomeChecklistbox4.LostFocus, CustomeChecklistbox5.LostFocus
        '  sender.backcolor = Color.White
    End Sub
End Class