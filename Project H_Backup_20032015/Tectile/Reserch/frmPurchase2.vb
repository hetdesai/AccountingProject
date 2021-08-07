Imports System.Data.SqlClient
Public Class frmPurchase2
    Dim flag As Integer
    Dim frmtxt As Integer
    Dim dr As SqlDataReader
    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        Try
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
                flag = 0
                DataGridView3.Visible = False
                TextBox4.Focus()
            ElseIf e.KeyCode = Keys.Tab Then
                flag = 0
            End If

        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        connect()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da = New SqlDataAdapter("Select * from tblAccount where ACName like'" & sender.Text & "%' order by ACName", cn)
        da.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
        DataGridView3.Visible = True
        DataGridView3.Top = sender.Top + 22
        DataGridView3.Left = sender.left
        close1()

    End Sub

    Private Sub TextBox3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Leave
        '      If flag = 0 Then
        'DataGridView3.Visible = False
        'End If
    End Sub

    Private Sub DataGridView3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim i As DataGridViewSelectedCellCollection
                i = DataGridView3.SelectedCells
                If frmtxt = 0 Then
                    TextBox3.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
                    TextBox3.Focus()
                    DataGridView3.Visible = False
                    flag = 0
                ElseIf frmtxt = 1 Then
                    TextBox5.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
                    TextBox5.Focus()
                    DataGridView3.Visible = False
                    flag = 0
                ElseIf frmtxt = 2 Then
                    TextBox4.Text = (DataGridView3.Item(1, i.Item(0).RowIndex).Value)
                    TextBox4.Focus()
                    DataGridView3.Visible = False
                    flag = 0
                End If

            End If
        Catch ex As Exception

        End Try
        
        '  MsgBox("het")


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
            flag = 0
        ElseIf e.KeyCode = Keys.Tab Then
            flag = 0

        End If
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyUp
        connect()
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter
        da = New SqlDataAdapter("Select * from tblAccount where ACName like'" & sender.Text & "%' order by ACName", cn)
        da.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
        DataGridView3.Visible = True
        DataGridView3.Top = sender.Top + 22
        DataGridView3.Left = sender.left
        close1()
    End Sub

    Private Sub TextBox4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.Leave
        If flag = 0 Then
            DataGridView3.Visible = False
        End If
    End Sub

    Private Sub frmPurchase2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Private Sub dg2_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dg2.CellBeginEdit
        Try
            ' MsgBox("h")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dg2_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellEnter
        ''     Try
        'If e.ColumnIndex = 1 Then
        '  connect()
        '  Dim da As New SqlDataAdapter("Select * from tblItem where ITName like '" & dg2.Item(e.ColumnIndex, e.RowIndex).Value & "%'", cn)
        '  Dim ds As New DataSet
        '  da.Fill(ds)
        '  DataGridView3.DataSource = ds.Tables(0)
        '  DataGridView3.Visible = True
        '  DataGridView3.Top = 194 + (e.RowIndex * 22) + 22
        '  close1()
        '  End If
        '  Catch ex As Exception
        'MsgBox(ex.ToString)
        '  End Try
        Try
            Try
                If e.ColumnIndex = 0 Then
                    Dim I As Integer
                    TextBox15.Clear()
                    For I = 0 To dg2.Rows.Count - 2
                        TextBox15.Text = dg2.Item(8, I).Value + Val(TextBox15.Text)
                        '  MsgBox(TextBox15.Text)
                    Next
                End If

            Catch ex As Exception

            End Try
            If e.ColumnIndex = 1 Then
                dg2.SendToBack()
                TextBox5.BringToFront()
                TextBox5.Text = dg2.CurrentCell.Value
                TextBox5.Focus()
                TextBox5.Top = 194 + (e.RowIndex * 22)
            End If
            If e.ColumnIndex = 5 Then
                '  MsgBox(dg2.Item(3, e.RowIndex).Value)
                dg2.Item(5, e.RowIndex).Value = dg2.Item(4, e.RowIndex).Value * dg2.Item(3, e.RowIndex).Value
            End If
            If e.ColumnIndex = 8 Then
                '  MsgBox(dg2.Item(3, e.RowIndex).Value)
                dg2.Item(8, e.RowIndex).Value = dg2.Item(5, e.RowIndex).Value * dg2.Item(6, e.RowIndex).Value
            End If
            If e.ColumnIndex = 6 Then
                Dim i As Integer
                TextBox14.Clear()
                For i = 0 To dg2.Rows.Count - 1
                    TextBox14.Text = dg2.Item(5, i).Value + Val(TextBox14.Text)
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dg2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg2.KeyUp
        'MsgBox("a")
        '  If dg2.CurrentCell.ColumnIndex = 1 Then
        'connect()
        ' Dim da As New SqlDataAdapter("Select * from tblItem where ITName like '" & dg2.CurrentCell.Value & "%' order by ITName", cn)
        ' Dim ds As New DataSet
        ' da.Fill(ds)
        ' DataGridView3.DataSource = ds.Tables(0)
        ' DataGridView3.Visible = True
        ' DataGridView3.Top = 194 + (dg2.CurrentCell.RowIndex * 22) + 22
        ' close1()
        ' End If
    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub TextBox5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus

    End Sub

   
    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyUp
        If dg2.CurrentCell.ColumnIndex = 1 Then
            connect()
            Dim da As New SqlDataAdapter("Select * from tblItem where ITName like '" & TextBox5.Text & "%' order by ITName", cn)
            Dim ds As New DataSet
            da.Fill(ds)
            DataGridView3.DataSource = ds.Tables(0)
            DataGridView3.Visible = True
            DataGridView3.Top = 194 + (dg2.CurrentCell.RowIndex * 22) + 22
            DataGridView3.Left = TextBox5.Left
            close1()
        End If
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
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
        End If
        If e.KeyCode = Keys.Enter Then
            Dim i As DataGridViewSelectedCellCollection
            i = DataGridView3.SelectedCells
            TextBox5.Text = DataGridView3.Item(2, (DataGridView3.SelectedCells.Item(0).RowIndex)).Value
            DataGridView3.Item(2, 0).Selected = True
            flag = 0
        End If
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.Leave
        If flag = 0 Then
            DataGridView3.Visible = False
            dg2.CurrentCell.Value = TextBox5.Text
            TextBox5.SendToBack()
            dg2.Focus()
            Dim dr As SqlDataReader
            dr = myconselect("tblItem", TextBox5.Text, "ITName")
            While dr.Read
                dg2.Item(2, dg2.SelectedCells.Item(0).RowIndex).Value = dr.Item("ITCode")
                dg2.Item(6, dg2.SelectedCells.Item(0).RowIndex).Value = dr.Item("Rate")
                dg2.Item(7, dg2.SelectedCells.Item(0).RowIndex).Value = dr.Item("ITUnit")
            End While
            dr.Close()
            dg2.Item(2, dg2.SelectedCells.Item(0).RowIndex).Selected = True
            '  SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dg2_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellLeave
        If e.ColumnIndex = 8 Then
            dg2.Item(0, e.RowIndex + 1).Value = dg2.Item(0, e.RowIndex).Value + 1
             End If
    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dat1 As New Date
        Dim dat2 As New Date
        dat1 = MaskedTextBox1.Text.ToString
        dat2 = MaskedTextBox2.Text.ToString
        Dim i As Integer
        For i = 0 To dg2.Rows.Count - 1
            Dim b() As String = {TextBox1.Text, TextBox2.Text, TextBox16.Text, dat1, TextBox17.Text, dat2, TextBox3.Text, TextBox4.Text, ComboBox1.Text, dg2.Item(0, i).Value, dg2.Item(1, i).Value, dg2.Item(2, i).Value, dg2.Item(3, i).Value, dg2.Item(4, i).Value, dg2.Item(5, i).Value, dg2.Item(6, i).Value, dg2.Item(7, i).Value, dg2.Item(8, i).Value}
            myinsert(b, "tblPurchaseDetail")
            MsgBox("inserted")
        Next
        Dim a() As String = {TextBox1.Text, TextBox2.Text, TextBox16.Text, dat1, TextBox17.Text, dat2, TextBox3.Text, TextBox4.Text, ComboBox1.Text, TextBox15.Text, TextBox14.Text}
        myinsert(a, "tblPurchase")
        MsgBox("het")
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        '   If Asc(e.KeyChar) = (13) Then
        'Dim i As DataGridViewSelectedCellCollection
        'i = DataGridView3.SelectedCells
        'TextBox5.Text = DataGridView3.Item(2, (DataGridView3.SelectedCells.Item(0).RowIndex)).Value
        'DataGridView3.Visible = False
        'dg2.Item(2, 0).Selected = True
        'flag = 0
        'End If

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class