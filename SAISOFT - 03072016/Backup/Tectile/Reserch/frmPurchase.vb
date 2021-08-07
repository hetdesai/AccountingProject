Imports System.Data.SqlClient
Imports System.Collections.ObjectModel
Public Class frmPurchase
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim cmd As New SqlCommand
    Dim flag As Integer
    Dim rowno As Integer = 0
    Dim frmtxt As Integer = 0

    Private Sub frmPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            End If
    End Sub


    Private Sub frmPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            connect()
            dg2.Focus()
            dg2.Item(0, 0).Selected = True

            ' SendKeys.Send("z")
            TextBox1.Text = frmMainScreen.bkname
            dr = myconselect("tblAccount", frmMainScreen.bkname, "ACName")
            While dr.Read
                TextBox2.Text = dr.Item("ACCode").ToString
            End While
            dr.Close()
            close1()
            Me.Column1.HeaderText = "Column1"
            For i = 1 To 20
                dg2.Rows.Add()
            Next
            TextBox5.Top = 194
            TextBox6.Top = 194
            TextBox7.Top = 194
            TextBox8.Top = 194
            TextBox9.Top = 194
            TextBox10.Top = 194
            TextBox11.Top = 194
            TextBox12.Top = 194
            TextBox13.Top = 194
            rowno = 0
            TextBox3.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp, TextBox4.KeyUp
        connect()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da = New SqlDataAdapter("Select * from tblAccount where ACName like'" & sender.Text & "%' order by ACName", cn)
        da.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
        DataGridView3.Visible = True
        DataGridView3.Top = sender.Top + 22
        close1()
    End Sub

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.Leave, TextBox4.Leave
        If flag = 0 Then
            DataGridView3.Visible = False
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Down Then
            DataGridView3.Visible = True
            flag = 1
            DataGridView3.Focus()
            DataGridView3.Item(1, 0).Selected = True
            frmtxt = 0
        ElseIf e.KeyCode = Keys.Enter Then
            Dim i As DataGridViewSelectedCellCollection
            i = DataGridView3.SelectedCells
            TextBox3.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
            TextBox4.Focus()
            flag = 0
        ElseIf e.KeyCode = Keys.Tab Then
            flag = 0
        End If

    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellEnter
        Try
            If e.ColumnIndex = 0 Then
                DataGridView3.Item(1, e.RowIndex).Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.Leave
        dg2.Item(0, rowno).Value = TextBox5.Text
    End Sub
    Private Sub TextBox6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.Leave
        If flag = 0 Then
            dr = myconselect("tblItem", TextBox6.Text, "ITName")
            While dr.Read
                TextBox7.Text = dr.Item("ITCode").ToString
                TextBox11.Text = dr.Item("Rate").ToString
            End While
            dr.Close()
            dg2.Item(1, rowno).Value = TextBox6.Text
            DataGridView3.Visible = False
        End If

    End Sub
    Private Sub TextBox7_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        dg2.Item(2, rowno).Value = TextBox7.Text
    End Sub
    Private Sub TextBox8_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.Leave
        dg2.Item(3, rowno).Value = TextBox8.Text
    End Sub
    Private Sub TextBox9_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.Leave
        TextBox10.Text = Val(TextBox8.Text) * Val(TextBox9.Text)

        dg2.Item(4, rowno).Value = TextBox9.Text
    End Sub
    Private Sub TextBox10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.Leave
        dg2.Item(5, rowno).Value = TextBox10.Text
        Dim i As Integer
        Dim j As Integer
        For i = 0 To dg2.Rows.Count - 1
            j = j + dg2.Item(5, i).Value
        Next
        TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
        TextBox14.Text = j
    End Sub
    Private Sub TextBox11_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.Leave
        dg2.Item(6, rowno).Value = TextBox11.Text
        TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
    End Sub
    Private Sub TextBox12_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.Leave
        dg2.Item(7, rowno).Value = TextBox12.Text
    End Sub
    Private Sub TextBox13_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.Leave
        Try

            dg2.Item(8, rowno).Value = TextBox13.Text
            dg2.Item(0, rowno).Value = TextBox5.Text
            dg2.Item(1, rowno).Value = TextBox6.Text
            dg2.Item(2, rowno).Value = TextBox7.Text
            dg2.Item(3, rowno).Value = TextBox8.Text
            dg2.Item(4, rowno).Value = TextBox9.Text
            dg2.Item(5, rowno).Value = TextBox10.Text
            dg2.Item(6, rowno).Value = TextBox11.Text
            dg2.Item(7, rowno).Value = TextBox12.Text
            dg2.Item(8, rowno).Value = TextBox13.Text
            rowno = rowno + 1
            TextBox5.Top = TextBox5.Top + (22)
            TextBox6.Top = TextBox6.Top + (22)
            TextBox7.Top = TextBox7.Top + (22)
            TextBox8.Top = TextBox8.Top + (22)
            TextBox9.Top = TextBox9.Top + (22)
            TextBox10.Top = TextBox10.Top + (22)
            TextBox11.Top = TextBox11.Top + (22)
            TextBox12.Top = TextBox12.Top + (22)
            TextBox13.Top = TextBox13.Top + (22)
            TextBox5.Text = TextBox5.Text + 1
            dg2.Item(0, rowno).Value = TextBox5.Text
            '  TextBox5.Focus()
            ' TextBox5.Clear()
            ' TextBox6.Focus()
            TextBox6.Clear()
            TextBox7.Clear()
            TextBox8.Clear()
            TextBox9.Clear()
            TextBox10.Clear()
            TextBox11.Clear()
            TextBox12.Clear()
            TextBox13.Clear()
            TextBox6.Focus()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub dg2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellEnter
        Try
            '  MsgBox(e.RowIndex)
            rowno = e.RowIndex
            TextBox5.Top = 194 + (e.RowIndex * 23)
            TextBox5.BringToFront()
            TextBox5.Text = dg2.Item(0, e.RowIndex).Value
            TextBox6.Top = 194 + (e.RowIndex * 23)
            TextBox6.BringToFront()
            TextBox6.Text = dg2.Item(1, e.RowIndex).Value
            TextBox7.Top = 194 + (e.RowIndex * 23)
            TextBox7.BringToFront()
            TextBox7.Text = dg2.Item(2, e.RowIndex).Value
            TextBox8.Top = 194 + (e.RowIndex * 23)
            TextBox8.BringToFront()
            TextBox8.Text = dg2.Item(3, e.RowIndex).Value
            TextBox9.Top = 194 + (e.RowIndex * 23)
            TextBox9.BringToFront()
            TextBox9.Text = dg2.Item(4, e.RowIndex).Value
            TextBox10.Top = 194 + (e.RowIndex * 23)
            TextBox10.BringToFront()
            TextBox10.Text = dg2.Item(5, e.RowIndex).Value
            TextBox11.Top = 194 + (e.RowIndex * 23)
            TextBox11.BringToFront()
            TextBox11.Text = dg2.Item(6, e.RowIndex).Value
            TextBox12.Top = 194 + (e.RowIndex * 23)
            TextBox12.BringToFront()
            TextBox12.Text = dg2.Item(7, e.RowIndex).Value
            TextBox13.Top = 194 + (e.RowIndex * 23)
            TextBox13.BringToFront()
            TextBox13.Text = dg2.Item(8, e.RowIndex).Value
            focus(e.ColumnIndex)
        Catch ex As Exception
            '    MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub focus(ByVal b As Integer)
        If b = 0 Then
            TextBox5.Focus()
        ElseIf b = 1 Then
            TextBox6.Focus()
        ElseIf b = 2 Then
            TextBox7.Focus()
        ElseIf b = 3 Then
            TextBox8.Focus()
        ElseIf b = 4 Then
            TextBox9.Focus()
        ElseIf b = 5 Then
            TextBox10.Focus()
        ElseIf b = 6 Then
            TextBox11.Focus()
        ElseIf b = 7 Then
            TextBox12.Focus()
        ElseIf b = 8 Then
            TextBox13.Focus()
        End If
    End Sub
    Private Sub dg2_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellLeave
        Try
            If e.ColumnIndex = 8 Then
                Dim r As New DataGridViewRow
                dg2.Rows.Add(r)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Up Then
            ' rowno = rowno - 1
            'dg2.Item(1, rowno).Selected = True
        End If
        If e.KeyCode = Keys.Down Then
            'rowno = rowno + 1
            'dg2.Item(1, rowno).Selected = True
            DataGridView3.Visible = True
            flag = 1
            frmtxt = 1
            DataGridView3.Focus()
            DataGridView3.Item(1, 0).Selected = True

        End If
        If e.KeyCode = Keys.Enter Then
            Dim i As DataGridViewSelectedCellCollection
            i = DataGridView3.SelectedCells
            TextBox6.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
            DataGridView3.Visible = False
            TextBox7.Focus()
            flag = 0
        End If
        If e.KeyCode = Keys.Tab Then
            flag = 0
            MsgBox("het")
        End If
    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Up Then
            rowno = rowno - 1
            dg2.Item(2, rowno).Selected = True
        End If
        If e.KeyCode = Keys.Down Then
            rowno = rowno + 1
            dg2.Item(2, rowno).Selected = True
        End If
        If e.KeyCode = Keys.Enter Then
            TextBox8.Focus()
        End If

    End Sub
    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Up Then
            If rowno - 1 > -1 Then
                dg2.Item(3, rowno).Value = TextBox8.Text
                TextBox10.Text = Val(TextBox8.Text) * Val(TextBox9.Text)
                dg2.Item(5, rowno).Value = TextBox10.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()
                rowno = rowno - 1
                dg2.Item(3, rowno).Selected = True
            Else
                GoTo en
            End If
              End If
        If e.KeyCode = Keys.Down Then
            If rowno + 1 < dg2.Rows.Count - 1 Then
                TextBox10.Text = Val(TextBox8.Text) * Val(TextBox9.Text)
                dg2.Item(5, rowno).Value = TextBox10.Text

                dg2.Item(3, rowno).Value = TextBox8.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                rowno = rowno + 1
                dg2.Item(3, rowno).Selected = True
            Else
                GoTo en
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            TextBox10.Text = Val(TextBox8.Text) * Val(TextBox9.Text)
            dg2.Item(5, rowno).Value = TextBox10.Text

            dg2.Item(3, rowno).Value = TextBox8.Text
            TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
            dg2.Item(8, rowno).Value = TextBox13.Text
            countqty()
            countamount()

            TextBox9.Focus()
        End If
en:
    End Sub
    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.Up Then
            If rowno - 1 > -1 Then
                dg2.Item(4, rowno).Value = TextBox9.Text
                TextBox10.Text = Val(TextBox8.Text) * Val(TextBox9.Text)
                dg2.Item(5, rowno).Value = TextBox10.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                rowno = rowno - 1
                dg2.Item(4, rowno).Selected = True
            Else
                GoTo en
            End If

        End If
            If e.KeyCode = Keys.Down Then
            If rowno + 1 < dg2.Rows.Count - 1 Then
                dg2.Item(4, rowno).Value = TextBox9.Text
                TextBox10.Text = Val(TextBox8.Text) * Val(TextBox9.Text)
                dg2.Item(5, rowno).Value = TextBox10.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                rowno = rowno + 1
                dg2.Item(4, rowno).Selected = True
            Else
                GoTo en
            End If
        End If
            If e.KeyCode = Keys.Enter Then
                dg2.Item(4, rowno).Value = TextBox9.Text
                TextBox10.Text = Val(TextBox8.Text) * Val(TextBox9.Text)
                dg2.Item(5, rowno).Value = TextBox10.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
            countqty()
            countamount()

                TextBox10.Focus()
            End If
en:
    End Sub
    Private Sub TextBox10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown
        If e.KeyCode = Keys.Up Then
            If rowno - 1 > -1 Then
                dg2.Item(5, rowno).Value = TextBox10.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                rowno = rowno - 1
                dg2.Item(5, rowno).Selected = True
            Else
                GoTo en
            End If
            End If
        If e.KeyCode = Keys.Down Then
            If rowno + 1 < dg2.Rows.Count - 1 Then
                dg2.Item(5, rowno).Value = TextBox10.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                rowno = rowno + 1
                dg2.Item(5, rowno).Selected = True
            Else
                GoTo en
            End If
        End If
            If e.KeyCode = Keys.Enter Then
                dg2.Item(5, rowno).Value = TextBox10.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
            countqty()
            countamount()

                TextBox11.Focus()
            End If
en:
    End Sub
    Private Sub TextBox11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox11.KeyDown
        Try
            If e.KeyCode = Keys.Up Then
                dg2.Item(6, rowno).Value = TextBox11.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                rowno = rowno - 1
                dg2.Item(6, rowno).Selected = True

            End If
            If e.KeyCode = Keys.Down Then
                dg2.Item(6, rowno).Value = TextBox11.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                rowno = rowno + 1
                dg2.Item(6, rowno).Selected = True

            End If
            If e.KeyCode = Keys.Enter Then
                dg2.Item(6, rowno).Value = TextBox11.Text
                TextBox13.Text = Val(TextBox10.Text) * Val(TextBox11.Text)
                dg2.Item(8, rowno).Value = TextBox13.Text
                countqty()
                countamount()

                TextBox12.Focus()
            End If
        Catch ex As Exception
            MsgBox("Incorrect Selection")
        End Try
    End Sub
    Private Sub TextBox12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox12.KeyDown

        Try

        If e.KeyCode = Keys.Up Then
                If rowno - 1 > -1 Then
                    dg2.Item(7, rowno).Value = TextBox12.Text
                    countqty()
                    countamount()

                    rowno = rowno - 1
                    dg2.Item(7, rowno).Selected = True
                Else
                    GoTo en
                End If
                
            End If
            If e.KeyCode = Keys.Down Then
                If rowno + 1 < dg2.Rows.Count - 1 Then
                    dg2.Item(7, rowno).Value = TextBox12.Text
                    countqty()
                    countamount()

                    rowno = rowno + 1
                    dg2.Item(7, rowno).Selected = True
                Else
                    GoTo en
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                dg2.Item(7, rowno).Value = TextBox12.Text
                '        countqty()
                '       countamount()
                dg2.Item(8, rowno).Value = TextBox13.Text
                dg2.Item(0, rowno).Value = TextBox5.Text
                dg2.Item(1, rowno).Value = TextBox6.Text
                dg2.Item(2, rowno).Value = TextBox7.Text
                dg2.Item(3, rowno).Value = TextBox8.Text
                dg2.Item(4, rowno).Value = TextBox9.Text
                dg2.Item(5, rowno).Value = TextBox10.Text
                dg2.Item(6, rowno).Value = TextBox11.Text
                dg2.Item(7, rowno).Value = TextBox12.Text
                dg2.Item(8, rowno).Value = TextBox13.Text
                rowno = rowno + 1
                TextBox5.Top = TextBox5.Top + (22)
                TextBox6.Top = TextBox6.Top + (22)
                TextBox7.Top = TextBox7.Top + (22)
                TextBox8.Top = TextBox8.Top + (22)
                TextBox9.Top = TextBox9.Top + (22)
                TextBox10.Top = TextBox10.Top + (22)
                TextBox11.Top = TextBox11.Top + (22)
                TextBox12.Top = TextBox12.Top + (22)
                TextBox13.Top = TextBox13.Top + (22)
                TextBox5.Text = TextBox5.Text + 1
                dg2.Item(0, rowno).Value = TextBox5.Text
                '  TextBox5.Focus()
                ' TextBox5.Clear()
                ' TextBox6.Focus()
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                TextBox10.Clear()
                TextBox11.Clear()
                TextBox12.Clear()
                TextBox13.Clear()


                TextBox6.Focus()
            End If
        Catch ex As Exception
            MsgBox("Incorrect Key")
        End Try
en:
    End Sub
    Private Sub TextBox13_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox13.KeyDown
        If e.KeyCode = Keys.Up Then
            If rowno - 1 > -1 Then
                dg2.Item(8, rowno).Value = TextBox13.Text
                '        countqty()
                '       countamount()
                rowno = rowno - 1
                dg2.Item(8, rowno).Selected = True
            Else
                GoTo en
            End If
          End If
        If e.KeyCode = Keys.Down Then
            If rowno + 1 < dg2.Rows.Count - 1 Then
                dg2.Item(8, rowno).Value = TextBox13.Text
                'countqty()
                'countamount()
                rowno = rowno + 1
                dg2.Item(8, rowno).Selected = True
            Else
                GoTo en

            End If
             End If
        If e.KeyCode = Keys.Enter Then
            dg2.Item(8, rowno).Value = TextBox13.Text
            '          countqty()
            '         countamount()

            TextBox5.Focus()
        End If
en:
    End Sub
    Private Sub countqty()
        Dim i As Integer
        TextBox14.Clear()
        For i = 0 To dg2.Rows.Count - 1
            TextBox14.Text = Val(TextBox14.Text) + dg2.Item(5, i).Value
        Next
    End Sub
    Private Sub countamount()
        Dim i As Integer
        TextBox15.Clear()
        For i = 0 To dg2.Rows.Count - 1
            TextBox15.Text = Val(TextBox15.Text) + dg2.Item(8, i).Value
        Next
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Up Then
            If rowno - 1 > -1 Then
                dg2.Item(0, rowno).Value = TextBox5.Text
                rowno = rowno - 1
                dg2.Item(0, rowno).Selected = True
            Else
                GoTo en
            End If
        End If
        If e.KeyCode = Keys.Down Then
            If rowno + 1 < dg2.Rows.Count - 1 Then
                dg2.Item(0, rowno).Value = TextBox5.Text
                rowno = rowno + 1
                dg2.Item(0, rowno).Selected = True
            Else
                GoTo en
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            dg2.Item(0, rowno).Value = TextBox5.Text
            TextBox6.Focus()
        End If
en:
    End Sub

    Private Sub DataGridView3_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView3.Enter
        DataGridView3.Columns(0).Visible = False
    End Sub


    Private Sub DataGridView3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim i As DataGridViewSelectedCellCollection
            i = DataGridView3.SelectedCells
            If frmtxt = 0 Then
                TextBox3.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
                TextBox3.Focus()
                DataGridView3.Visible = False
                TextBox4.Focus()
                flag = 0
            ElseIf frmtxt = 1 Then
                TextBox6.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
                TextBox6.Focus()
                DataGridView3.Visible = False
                dg2.Item(1, rowno).Value = TextBox6.Text
                TextBox7.Focus()
                flag = 0
            ElseIf frmtxt = 2 Then
                TextBox4.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
                TextBox4.Focus()
                DataGridView3.Visible = False
                ComboBox1.Focus()
                flag = 0
            End If


            '  MsgBox("het")
        End If
    End Sub

    Private Sub TextBox6_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyUp
        connect()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da = New SqlDataAdapter("Select * from tblItem where ITName like'" & TextBox6.Text & "%' order by ITName", cn)
        da.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
        DataGridView3.Visible = True
        DataGridView3.Top = TextBox6.Top + 22
        close1()
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Down Then
            DataGridView3.Visible = True
            flag = 1
            DataGridView3.Focus()
            DataGridView3.Item(1, 0).Selected = True
            frmtxt = 2
        ElseIf e.KeyCode = Keys.Enter Then
            Dim i As DataGridViewSelectedCellCollection
            i = DataGridView3.SelectedCells
            TextBox4.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
            ComboBox1.Focus()
            flag = 0
        ElseIf e.KeyCode = Keys.Tab Then
            flag = 0

        End If
    End Sub

    Private Sub dg2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg2.KeyDown

    End Sub

    Private Sub TextBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Enter
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        connect()
        da = New SqlDataAdapter("Select * from tblAccount where ACName like '" & TextBox3.Text & "%'", cn)
        da.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
        DataGridView3.Visible = True
        DataGridView3.Left = TextBox3.Left
        DataGridView3 .Top=TextBox3 .Top + 22
        close1()

    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox16.Focus()
        End If
    End Sub

    Private Sub TextBox16_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox16.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox1.Focus()
        End If

    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox17.Focus()
        End If
    End Sub

    Private Sub TextBox17_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox17.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox5.Text = 1
            TextBox5.Focus()
        End If
    End Sub
    Private Sub TextBox7_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.Enter
        Dim dr As SqlDataReader
        dr = myconselect("tblItem", TextBox6.Text, "ITName")
        While dr.Read
            TextBox7.Text = dr.Item("ITCode")
            TextBox11.Text = dr.Item("Rate")
        End While
        dr.Close()
        dg2.Item(2, rowno).Value = TextBox7.Text
        dg2.Item(6, rowno).Value = TextBox11.Text
        TextBox8.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            countamount()
            countqty()
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text.ToString
            dat2 = MaskedTextBox2.Text.ToString
            '     MsgBox(dg2.Item(1, 6).Value.ToString.Length)
            Dim j As Integer
            Dim countrow As Integer
            For j = 0 To dg2.Rows.Count - 1
                Try
                    If dg2.Item(1, j).Value.ToString.Length <> 0 And dg2.Item(6, j).Value <> 0 Then
                        countrow = countrow + 1
                    Else
                        GoTo en
                    End If
                Catch ex As Exception
                    GoTo en
                End Try
                 Next

en:
            MsgBox(countrow)
            Dim i As Integer
            For i = 0 To j - 1
                Dim b() As String = {TextBox1.Text, TextBox2.Text, TextBox16.Text, dat1, TextBox17.Text, dat2, TextBox3.Text, TextBox4.Text, ComboBox1.Text, dg2.Item(0, i).Value, dg2.Item(1, i).Value, dg2.Item(2, i).Value, dg2.Item(3, i).Value, dg2.Item(4, i).Value, dg2.Item(5, i).Value, dg2.Item(6, i).Value, dg2.Item(7, i).Value, dg2.Item(8, i).Value}
                myinsert(b, "tblPurchaseDetail")
                MsgBox("inserted")
            Next
            Dim a() As String = {TextBox1.Text, TextBox2.Text, TextBox16.Text, dat1, TextBox17.Text, dat2, TextBox3.Text, TextBox4.Text, ComboBox1.Text, TextBox15.Text, TextBox14.Text}
            myinsert(a, "tblPurchase")
            MsgBox("het")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub

    Private Sub TextBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.Enter
        TextBox6.Focus()
    End Sub

    Private Sub TextBox12_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.Enter
        'TextBox6.Focus()
    End Sub

    Private Sub TextBox13_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.Enter
        '      TextBox6.Focus()
    End Sub
End Class