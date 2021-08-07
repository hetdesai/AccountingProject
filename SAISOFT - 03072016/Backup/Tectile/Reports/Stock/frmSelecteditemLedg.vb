Imports System.Data.SqlClient
Public Class frmSelecteditemLedg
    Public ds As New DataSet2
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionStart = 0
        sender.backcolor = Color.Yellow
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox1.Text
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

    Private Sub MaskedTextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox2.Text
            If DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox2.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox2.Focus()
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ds.Tables("tblStock").Rows.Clear()
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text.ToString
            dat2 = MaskedTextBox2.Text.ToString
            Dim i As Integer
            Dim li As New ListBox
            If CheckedListBox1.CheckedItems.Count = 0 Then
                For i = 0 To CheckedListBox1.Items.Count - 1
                    li.Items.Add(CheckedListBox1.Items(i).ToString)
                Next
            Else
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    li.Items.Add(CheckedListBox1.CheckedItems(i).ToString)
                Next
            End If
            connect()
            For i = 0 To li.Items.Count - 1
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select ITName,ITType,SUm(RQty)-SUm(DQty) as bal from tblStock where BillDt<='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and ITName='" & li.Items(i).ToString & "' group By ITName,ITType", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim dt As DataRow = ds.Tables("tblStock").NewRow
                    dt.Item("BillDt") = dat1
                    dt.Item("Book") = "Opening"
                    dt.Item("VrNo") = " "
                    dt.Item("ITName") = dr.Item("ITName")
                    dt.Item("ITType") = dr.Item("ITType")
                    If dr.Item("bal") > 0 Then
                        dt.Item("RQty") = dr.Item("Bal")
                        dt.Item("DAmt") = 0.0
                    ElseIf dr.Item("Bal") < 0 Then
                        dt.Item("DQty") = dr.Item("Bal")
                        dt.Item("RQty") = 0.0
                    End If
                    dt.Item("Rate") = 0.0
                    dt.Item("RAmt") = 0.0
                    dt.Item("DAmt") = 0.0
                    dt.Item("DRate") = 0.0
                    ds.Tables("tblStock").Rows.Add(dt)
                End While
                dr.Close()
                Dim da As New SqlDataAdapter
                da = New SqlDataAdapter("Select * from tblStock where BillDt>'" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "'and BillDt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ITName='" & li.Items(i).ToString & "' order by billdt", cn)
                da.Fill(ds, "tblStock")
            Next
            close1()
            frmselectedprint.Show()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmSelecteditemLedg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmSelecteditemLedg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select * from tblItem", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item("ITName"))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    
    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub
    Private Sub MaskedTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckedListBox1.Focus()
        End If
    End Sub

    Private Sub CheckedListBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.GotFocus
        Try
            CheckedListBox1.SelectedIndex = 0
            CheckedListBox1.BackColor = Color.LightYellow
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.LostFocus
        CheckedListBox1.SelectedIndex = -1
        CheckedListBox1.BackColor = Color.White

    End Sub
    Private Sub CheckedListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckedListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class