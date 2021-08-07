Imports System.Data.OleDb
Public Class frmFee
    Dim ds As New DataSet
    Dim da As New OleDbDataAdapter
    Dim dr As OleDbDataReader
    Dim cmd As New OleDbCommand

    Private Sub frmFee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Fee Entry"
        Connect()
        cmd = New OleDbCommand("Select * from tblStudentInfo Where ID=" & frmFeeSearch.ID1, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            TextBox4.Text = dr.Item("ID")
            TextBox10.Text = dr.Item("RollNo")
            TextBox11.Text = dr.Item("Batch")
            TextBox1.Text = dr.Item("St_FName")
            TextBox2.Text = dr.Item("St_SName")
            TextBox3.Text = dr.Item("St_MName")
            TextBox5.Text = dr.Item("Standard")
            TextBox6.Text = dr.Item("Div")
            TextBox7.Text = dr.Item("SchoolName")
            TextBox8.Text = dr.Item("Fee")
            TextBox13.Text = dr.Item("Sem")
        End While
        dr.Close()
        cmd = New OleDbCommand("Select count(Rasid_No) from tblFee", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            If (dr.Item(0) = 0) Then
                TextBox12.Text = 1
                GoTo en
            Else
            End If
        End While
        dr.Close()
        cmd = New OleDbCommand("Select max(Rasid_no) from tblFee", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            TextBox12.Text = dr.Item(0) + 1
        End While
        dr.Close()
        cmd = New OleDbCommand("Select * from tblFee where StudentId=" & TextBox4.Text, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            TextBox8.Text = dr.Item("RemainingFee")
        End While
        dr.Close()


        Close1()
en:

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmFeeSearch.Show()
        frmFeeSearch.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Connect()
        Dim Amount As Integer
        Dim type As String
        Dim inwords As String
        If TextBox9.Text.Equals("500") Then
            TextBox9.Text = "0500"
        End If
        If TextBox9.Text.Length = 4 Then
            If TextBox9.Text.Chars(0) = "3" Then
                inwords = "Four Thousand "
            End If
            If TextBox9.Text.Chars(0) = "2" Then
                inwords = "Two Thousand "
            End If
            If TextBox9.Text.Chars(0) = "1" Then
                inwords = "One Thousand "
            End If
            If TextBox9.Text.Chars(0) = "0" Then
                inwords = ""
            End If

            If TextBox9.Text.Chars(1) = "1" Then
                inwords = inwords & "One Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "2" Then
                inwords = inwords & "Two Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "3" Then
                inwords = inwords & "Three Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "4" Then
                inwords = inwords & "Four Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "5" Then
                inwords = inwords & "Five Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "6" Then
                inwords = inwords & "Six Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "7" Then
                inwords = inwords & "Seven Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "8" Then
                inwords = inwords & "Eight Hunderd "
            End If
            If TextBox9.Text.Chars(1) = "9" Then
                inwords = inwords & "Nine Hunderd "
            End If
            If TextBox9.Text.Chars(2) = "0" Then
                inwords = inwords & ""
            End If
            If TextBox9.Text.Chars(3) = "5" Then
                inwords = inwords & "Fifty "
            End If
            inwords = inwords & "Rupees Only"
        End If
        If RadioButton1.Checked = True Then
            Amount = Val(TextBox8.Text) - Val(TextBox9.Text)
            type = "Deposite"
        Else
            Amount = Val(TextBox8.Text) + Val(TextBox9.Text)
            type = "Withdraw"
        End If
        cmd = New OleDbCommand("insert into tblFee values(" & TextBox12.Text & ",'" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "'," & TextBox5.Text & ",'" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox11.Text & "'," & TextBox10.Text & "," & Amount & "," & TextBox4.Text & ",'" & type & "'," & TextBox9.Text & ",'" & inwords & "')", cn)
        cmd.ExecuteNonQuery()
        cmd = New OleDbCommand("update  tblRemFee set RemainingFee=" & Amount & " where ID=" & TextBox4.Text, cn)
        cmd.ExecuteNonQuery()
        Close1()
        MsgBox("inserted")
        frmrptReceipt.TextBox1.Text = TextBox12.Text
        frmrptReceipt.Show()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class