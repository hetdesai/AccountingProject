Imports System.Data.SqlClient
Public Class FRMOUTSELE
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If frmMainScreen.outtype = "SALE" Then
            frmrptout.Show()
        Else
            frmpurout.Show()
        End If
    End Sub
    Private Sub FRMOUTSELE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MaskedTextBox1.Text = Format(Date.Today, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(Date.Today, "dd-MM-yyyy")
            ComboBox1.Text = ComboBox1.Items(0).ToString
            Try
                connect()
                Dim CMD As New SqlCommand
                Dim DR As SqlDataReader
                CMD = New SqlCommand("SELECT SHEAD FROM TBLSH", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox1.Items.Add(DR.Item(0))
                End While
                DR.Close()
                CMD = New SqlCommand("Select distinct pgroup from tblAccount", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox2.Items.Add(DR.Item(0))
                End While
                DR.Close()
                CMD = New SqlCommand("Select acname from tblAccount order by acname", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox3.Items.Add(DR.Item(0))
                End While
                DR.Close()

                '   CheckBox1.Checked = True
                '  CheckBox2.Checked = True
                ' CheckBox3.Checked = True
                close1()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub


    Private Sub CheckedListBox1_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck, CheckedListBox2.ItemCheck, CheckedListBox3.ItemCheck
        If sender.SelectedIndex = 0 Then
            SendKeys.Send("{DOWN}")
            SendKeys.Send("{UP}")
        ElseIf sender.SelectedIndex = sender.Items.Count - 1 Then
            SendKeys.Send("{UP}")
            SendKeys.Send("{DOWN}")
        Else
            SendKeys.Send("{UP}")
            SendKeys.Send("{DOWN}")

        End If
    End Sub


    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged

        TICK()

    End Sub
    Private Sub TICK()
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim SH As String = "AND ("
            Dim DR As SqlDataReader
            Dim I As Integer
            '    MsgBox(CheckedListBox1.CheckedItems.Count)
            If CheckedListBox1.CheckedItems.Count = 0 Then
                GoTo EN
            End If
            CheckedListBox2.Items.Clear()
            For I = 0 To CheckedListBox1.CheckedItems.Count - 1
                CMD = New SqlCommand("sELECT DISTINCT PGROUP FROM TBLACCOUNT WHERE SCHEDULE='" & CheckedListBox1.CheckedItems(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    If CheckedListBox2.Items.Contains(DR.Item("PGROUP")) Then
                    Else
                        CheckedListBox2.Items.Add(DR.Item("PGROUP"))
                    End If
                    SH = SH & "SCHEDULE='" & CheckedListBox1.CheckedItems(I).ToString & "' OR "
                End While
                DR.Close()
            Next
            SH = SH.Substring(0, SH.Length - 4) & ")"
            CheckedListBox3.Items.Clear()
            For I = 0 To CheckedListBox2.Items.Count - 1
                CMD = New SqlCommand("sELECT ACNAME FROM TBLACCOUNT WHERE PGROUP='" & CheckedListBox2.Items(I).ToString & "' " & SH, cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox3.Items.Add(DR.Item("ACNAME"))
                End While
                DR.Close()
            Next
            close1()
EN:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim I As Integer
        For I = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(I, CheckBox1.Checked)
        Next
        TICK()
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim I As Integer
        For I = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(I, CheckBox2.Checked)
        Next
        TICK2()
    End Sub
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged

        Dim I As Integer
        For I = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(I, CheckBox3.Checked)
        Next
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        TICK2()

    End Sub
    Private Sub TICK2()
        Try
            connect()
            If CheckedListBox2.CheckedItems.Count = 0 And CheckedListBox2.Items.Count = 0 Then
                MsgBox("Select proper schedule or Select all schedule")
                GoTo LAST
            End If
            CheckedListBox3.Items.Clear()
            Dim I As Integer
            Dim CMD As New SqlCommand
            Dim SH As String = "AND ("
            Dim DR As SqlDataReader
            '    MsgBox(CheckedListBox1.CheckedItems.Count)
            If CheckedListBox1.CheckedItems.Count = 0 Then
                For I = 0 To CheckedListBox1.Items.Count - 1
                    SH = SH & "SCHEDULE='" & CheckedListBox1.Items(I).ToString & "' OR "
                Next

            Else
                For I = 0 To CheckedListBox1.CheckedItems.Count - 1
                    SH = SH & "SCHEDULE='" & CheckedListBox1.CheckedItems(I).ToString & "' OR "
                Next
            End If
            SH = SH.Substring(0, SH.Length - 4) & ")"
            If CheckedListBox2.CheckedItems.Count = 0 Then
                For I = 0 To CheckedListBox2.Items.Count - 1
                    CMD = New SqlCommand("sELECT ACNAME FROM TBLACCOUNT WHERE PGROUP='" & CheckedListBox2.Items(I).ToString & "' " & SH, cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        CheckedListBox3.Items.Add(DR.Item("ACNAME"))
                    End While
                    DR.Close()
                Next

            Else
                For I = 0 To CheckedListBox2.CheckedItems.Count - 1
                    CMD = New SqlCommand("sELECT ACNAME FROM TBLACCOUNT WHERE PGROUP='" & CheckedListBox2.CheckedItems(I).ToString & "' " & SH, cn)
                    DR = CMD.ExecuteReader
                    While DR.Read
                        CheckedListBox3.Items.Add(DR.Item("ACNAME"))
                    End While
                    DR.Close()
                Next
            End If
            close1()
LAST:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class