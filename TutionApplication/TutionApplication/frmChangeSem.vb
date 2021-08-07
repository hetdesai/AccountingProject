Imports System.Data.OleDb
Public Class frmChangeSem
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        CheckedListBox1.Items.Clear()
        Connect()
        cmd = New OleDbCommand("Select * from tblStudentInfo where Sem=" & ComboBox1.Text, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            CheckedListBox1.Items.Add(dr.Item("ID") & " " & dr.Item("St_SName") & " " & dr.Item("St_FName") & " " & dr.Item("St_MName"))
        End While
        dr.Close()
        Close1()
        ComboBox2.Text = Val(ComboBox1.Text) + 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CheckedListBox2.Items.Clear()
        Dim i As Integer = CheckedListBox1.CheckedItems.Count
        Dim j As New Integer
        For j = 0 To i - 1
            CheckedListBox2.Items.Add(CheckedListBox1.CheckedItems(j).ToString)
        Next
        Connect()
        cmd = New OleDbCommand("Select Max(ID) from tblStudentInfo", cn)
        dr = cmd.ExecuteReader
        Dim count As Integer
        While dr.Read
            count = dr.Item(0)
        End While
        Close1()
        Connect()
        'Dim i As Integer
        For i = 0 To CheckedListBox2.Items.Count - 1
            cmd = New OleDbCommand("Select * from tblStudentInfo where ID=" & CheckedListBox2.Items(i).ToString.Chars(0), cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sql As String
                Try
                    sql = "insert into tblStudentInfo values(" & (count + 1) & ",'" & dr.Item("St_FName") & "','" & dr.Item("St_SName") & "','" & dr.Item("St_MName") & "','" & dr.Item("Email") & "','" & dr.Item("Address") & "','" & dr.Item("SchoolName") & "','" & dr.Item("Gender") & "','" & dr.Item("Course") & "','" & dr.Item("Duration") & "','" & dr.Item("HomePhone") & "','" & dr.Item("MobileNo") & "','" & dr.Item("NetivePlace") & "','" & dr.Item("DateOfBirthday") & "'," & dr.Item("Standard") & ",'" & dr.Item("Div") & "','" & Date.Today & "'," & dr.Item("ProposedStandardEntry") & "," & dr.Item("Tenth") & ",'" & dr.Item("Pict") & "'," & Today.Year & "," & ComboBox2.Text & ",'" & dr.Item("Batch") & "'," & dr.Item("RollNo") & "," & dr.Item("Fee") & "," & "'ACTIVE'" & ")"
                    '  MsgBox(sql)
                Catch ex As Exception
                End Try
                Dim cmd2 As New OleDbCommand
                cmd2 = New OleDbCommand(sql, cn)
                System.IO.File.Copy("C:\ITSoftware\Images\" & dr.Item("ID"), "C:\ITSoftware\Images\" & (count + 1))
                cmd2.ExecuteNonQuery()
            End While
            dr.Close()
            cmd = New OleDbCommand("Select * from tblParentsInfo where ID=" & CheckedListBox2.Items(i).ToString.Chars(0), cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sql As String
                sql = "insert into tblParentsInfo values(" & (count + 1) & ",'" & dr.Item("MName") & "','" & dr.Item("FName") & "','" & dr.Item("SName") & "','" & dr.Item("Foccupation") & "','" & dr.Item("Details") & "','" & dr.Item("ContactNo") & "','" & dr.Item("Address") & "','" & dr.Item("Moccupation") & "','" & dr.Item("MDetails") & "','" & dr.Item("MAddress") & "')"
                Dim cmd2 As New OleDbCommand
                cmd2 = New OleDbCommand(sql, cn)
                cmd2.ExecuteNonQuery()
            End While
            dr.Close()
            cmd = New OleDbCommand("Select * from tblStudentInfo where ID=" & CheckedListBox2.Items(i).ToString.Chars(0), cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sql As String
                sql = "insert into tblRemFee values(" & (count + 1) & "," & dr.Item("Fee") & ")"
                Dim cmd2 As New OleDbCommand
                cmd2 = New OleDbCommand(sql, cn)
                cmd2.ExecuteNonQuery()
            End While

            count = count + 1
        Next
        Close1()
        MsgBox("Sucsess")
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CheckedListBox2.Items.Clear()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
      
    End Sub

    Private Sub frmChangeSem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Change Sem"
        CheckedListBox1.BackColor = My.Settings.backcolor
        CheckedListBox2.BackColor = My.Settings.backcolor
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub
End Class