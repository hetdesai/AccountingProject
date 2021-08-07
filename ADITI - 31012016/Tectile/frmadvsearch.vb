Imports System.Data.SqlClient
Public Class frmadvsearch

    Private Sub frmadvsearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            If ComboBox1.Text.ToUpper = "PURCHASE" Then
                da = New SqlDataAdapter("select * from tblPurchase", cn)
            ElseIf ComboBox1.Text.ToUpper = "BANK/CASH" Then
                da = New SqlDataAdapter("select * from tblBANK", cn)
            ElseIf ComboBox1.Text.ToUpper = "JOUR" Then
                da = New SqlDataAdapter("select * from tblJOUR", cn)
            ElseIf ComboBox1.Text.ToUpper = "SALE" Then
                da = New SqlDataAdapter("select * from SALESC", cn)
            ElseIf ComboBox1.Text.ToUpper = "OPENING" Then
                da = New SqlDataAdapter("select * from TBLOPEN", cn)

            End If
            da.Fill(ds)
            ComboBox2.Items.Clear()
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                ComboBox2.Items.Add(ds.Tables(0).Columns(i).ColumnName)
                ComboBox4.Items.Add(ds.Tables(0).Columns(i).DataType)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            ComboBox3.Items.Clear()
            ComboBox4.SelectedIndex = ComboBox2.SelectedIndex
            If ComboBox4.Text.ToUpper = "SYSTEM.DECIMAL" Then
                MsgBox("S")
                ComboBox3.Items.Add("GREATER THAN")
                ComboBox3.Items.Add("GREATER THAN EQUAL TO")
                ComboBox3.Items.Add("LESS THAN")
                ComboBox3.Items.Add("LESS THAN EQUAL TO")
                ComboBox3.Items.Add("EQUAL TO")
                ComboBox3.Items.Add("NOT EQUAL TO")
            ElseIf ComboBox4.Text.ToUpper = "SYSTEM.STRING" Then
                ComboBox3.Items.Add("GREATER THAN")
                ComboBox3.Items.Add("GREATER THAN EQUAL TO")
                ComboBox3.Items.Add("LESS THAN")
                ComboBox3.Items.Add("LESS THAN EQUAL TO")
                ComboBox3.Items.Add("EQUAL TO")
                ComboBox3.Items.Add("NOT EQUAL TO")
                ComboBox3.Items.Add("lIKE")
            ElseIf ComboBox4.Text.ToUpper.Trim = "SYSTEM.DATETIME" Then
                ComboBox3.Items.Add("GREATER THAN")
                ComboBox3.Items.Add("GREATER THAN EQUAL TO")
                ComboBox3.Items.Add("LESS THAN")
                ComboBox3.Items.Add("LESS THAN EQUAL TO")
                ComboBox3.Items.Add("EQUAL TO")
                ComboBox3.Items.Add("NOT EQUAL TO")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            dg1.Rows.Add()
            dg1.Item(0, dg1.Rows.Count - 1).Value = dg1.Rows.Count
            dg1.Item(1, dg1.Rows.Count - 1).Value = ComboBox2.Text
            dg1.Item(2, dg1.Rows.Count - 1).Value = ComboBox3.Text
            dg1.Item(3, dg1.Rows.Count - 1).Value = TextBox1.Text
            dg1.Item(4, dg1.Rows.Count - 1).Value = ComboBox4.Text
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub
    Private Function SYMBOL(ByVal STR As String) As String
        If STR.ToUpper = "GREATER THAN" Then
            Return "> "
        ElseIf STR.ToUpper = "LESS THAN" Then
            Return "< "
        ElseIf STR.ToUpper = "GREATER THAN EQUAL TO" Then
            Return ">= "
        ElseIf STR.ToUpper = "LESS THAN EQUAL TO" Then
            Return "<= "
        ElseIf STR.ToUpper = "LIKE" Then
            Return "LIKE "
        ElseIf STR.ToUpper = "EQUAL TO" Then
            Return "= "
        End If
    End Function
    Private Function STR1(ByVal STR As String) As String
        ' MsgBox(STR)
        If STR.ToUpper = "SYSTEM.DECIMAL" Then
            Return ""
        Else
            Return "'"
        End If
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String = ""
        Dim i As Integer
        Try
            For i = 0 To TextBox2.Text.Length - 1
                If TextBox2.Text.Chars(i) >= "0" And TextBox2.Text.Chars(i) <= "9" And TextBox2.Text.Chars(i + 1) <> "0" And TextBox2.Text.Chars(i + 1) <> "1" And TextBox2.Text.Chars(i + 1) <> "2" And TextBox2.Text.Chars(i + 1) <> "3" And TextBox2.Text.Chars(i + 1) <> "4" And TextBox2.Text.Chars(i + 1) <> "5" And TextBox2.Text.Chars(i + 1) <> "6" And TextBox2.Text.Chars(i + 1) <> "7" And TextBox2.Text.Chars(i + 1) <> "8" And TextBox2.Text.Chars(i + 1) <> "9" Then
                    Dim k As Integer = Val(TextBox2.Text.Chars(i)) - 1
                    If dg1.Item(4, k).Value.ToString.ToUpper.Trim = "system.datetime".ToUpper Then
                        Dim dat As New Date
                        dat = dg1.Item(3, k).Value.ToString
                        sql = sql & dg1.Item(1, Val(TextBox2.Text.Chars(i)) - 1).Value & " " & SYMBOL(dg1.Item(2, Val(TextBox2.Text.Chars(i)) - 1).Value) & STR1(dg1.Item(4, Val(TextBox2.Text.Chars(i)) - 1).Value) & dat.Month & "-" & dat.Day & "-" & dat.Year & STR1(dg1.Item(4, Val(TextBox2.Text.Chars(i)) - 1).Value)
                    Else
                        sql = sql & dg1.Item(1, Val(TextBox2.Text.Chars(i)) - 1).Value & " " & SYMBOL(dg1.Item(2, Val(TextBox2.Text.Chars(i)) - 1).Value) & STR1(dg1.Item(4, Val(TextBox2.Text.Chars(i)) - 1).Value) & dg1.Item(3, Val(TextBox2.Text.Chars(i)) - 1).Value & STR1(dg1.Item(4, Val(TextBox2.Text.Chars(i)) - 1).Value)
                    End If

                ElseIf TextBox2.Text.Chars(i) >= "0" And TextBox2.Text.Chars(i) <= "9" And TextBox2.Text.Chars(i + 1) >= "0" And TextBox2.Text.Chars(i + 1) <= "9" Then
                    Dim K As Integer
                    K = Val(TextBox2.Text.Chars(i)) * 10 + Val(TextBox2.Text.Chars(i + 1)) - 1
                    If dg1.Item(4, K).Value.ToString.ToUpper.Trim = "system.datetime".ToUpper Then
                        Dim dat As New Date
                        dat = dg1.Item(3, K).Value.ToString
                        sql = sql & dg1.Item(1, K).Value & " " & SYMBOL(dg1.Item(2, K).Value) & STR1(dg1.Item(4, K).Value) & dat.Month & "-" & dat.Day & "-" & dat.Year & STR1(dg1.Item(4, K).Value)
                    Else
                        sql = sql & dg1.Item(1, K).Value & " " & SYMBOL(dg1.Item(2, K).Value) & STR1(dg1.Item(4, K).Value) & dg1.Item(3, K).Value & STR1(dg1.Item(4, K).Value)
                    End If

                    i = i + 2
                Else
                    sql = sql & TextBox2.Text.Chars(i)
                End If
            Next
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            Dim table As String
            If ComboBox1.Text.ToUpper = "PURCHASE" Then
                table = "tblPurchase"
            ElseIf ComboBox1.Text.ToUpper = "BANK/CASH" Then
                table = "tblBANK"
            ElseIf ComboBox1.Text.ToUpper = "JOUR" Then
                table = "tblJOUR"
            ElseIf ComboBox1.Text.ToUpper = "SALE" Then
                table = " SALESC"
            ElseIf ComboBox1.Text.ToUpper = "OPENING" Then
                table = " TBLOPEN"
            End If
            MsgBox("select * from " & table & " where " & sql)
            da = New SqlDataAdapter("select * from " & table & " where " & sql, cn)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Try

            If ComboBox4.Text.ToUpper.Trim = "System.datetime".ToUpper Then
                Dim dat As New Date
                dat = TextBox1.Text
            End If
        Catch ex As Exception
            MsgBox("Incorrect date")
            TextBox1.Focus()
        End Try
    End Sub
End Class