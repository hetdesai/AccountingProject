Imports System.Data.SqlClient
Public Class frmPurc
    Dim tb As Integer
    WithEvents dgpurch As New MyDataGridView
    Private Sub frmPurc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            TextBox3.Focus()
            'SerialNO
            dgpurch.Columns.Add("col1", "SerialNo")
            dgpurch.Columns(0).Width = 50
            dgpurch.Columns(0).ReadOnly = True
            'Item Name
            dgpurch.Columns.Add("col2", "Item Name")
            dgpurch.Columns(1).Width = 200
            'Item Code
            dgpurch.Columns.Add("col3", "Item Code")
            dgpurch.Columns(2).Width = 70
            dgpurch.Columns(2).ReadOnly = True

            'Pcs
            dgpurch.Columns.Add("col4", "Pcs")
            dgpurch.Columns(3).Width = 70
            dgpurch.Columns(3).DefaultCellStyle.Format = "f2"

            'Pack
            dgpurch.Columns.Add("col5", "Pack")
            dgpurch.Columns(4).Width = 70
            dgpurch.Columns(4).DefaultCellStyle.Format = "f2"
            'Qty
            dgpurch.Columns.Add("col6", "Qty")
            dgpurch.Columns(5).Width = 100
            dgpurch.Columns(5).DefaultCellStyle.Format = "f2"
            'Rate
            dgpurch.Columns.Add("col7", "Rate")
            dgpurch.Columns(6).Width = 100
            dgpurch.Columns(6).DefaultCellStyle.Format = "f2"
            'Unit
            dgpurch.Columns.Add("col8", "Unit")
            dgpurch.Columns(7).Width = 50
            'Amount
            dgpurch.Columns.Add("col9", "Amount")
            dgpurch.Columns(8).Width = 100
            dgpurch.Columns(8).ReadOnly = True
            dgpurch.Columns(8).DefaultCellStyle.Format = "f2"
            'Properties
            dgpurch.MultiSelect = False
            Dim pt As New Point
            pt.X = 350
            pt.Y = 270

            dgpurch.Width = 850

            dgpurch.Height = 300
            dgpurch.Location = pt
            Dim j As Integer
            For j = 0 To 5000
                dgpurch.Rows.Add()
            Next
            dgpurch.Columns(3).DefaultCellStyle.Format = "f2"
            dgpurch.Columns(4).DefaultCellStyle.Format = "f2"
            dgpurch.Columns(5).DefaultCellStyle.Format = "f2"
            dgpurch.Columns(6).DefaultCellStyle.Format = "f2"
            dgpurch.Columns(8).DefaultCellStyle.Format = "f2"
            dgpurch.AllowUserToAddRows = False
            dgpurch.Left = 350
            DG1.Left = 430
            dgpurch.Top = 270
            '  dgpurch.StandardTab = True
            Me.Controls.Add(dgpurch)
            ' dgpurch.TabStop = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox3_KeyPup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        Try
            connect()
            DG1.Visible = True
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select * from tblAccount where ACName like '" & TextBox3.Text & "%'", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            DG1.Left = 448
            DG1.Top = TextBox3.Top + 50
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                TextBox3.Text = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                TextBox4.Focus()
                DG1.Visible = False
            ElseIf e.KeyCode = Keys.Down Then
                tb = 1
                DG1.Focus()
                DG1.Item(1, 0).Selected = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        End Sub
    Private Sub dgpurch_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpurch.CellEndEdit
        Try
            If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Then
                dgpurch.Item(e.ColumnIndex, e.RowIndex).Value = Convert.ToDecimal(dgpurch(e.ColumnIndex, e.RowIndex).Value)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyUp
        Try
            DG1.Visible = True
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select * from tblAccount where ACName like '" & TextBox4.Text & "%'", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            DG1.Left = 448
            DG1.Top = TextBox4.Top + 50
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        End Sub
    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                TextBox4.Text = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                ComboBox1.Focus()
                DG1.Visible = False
            ElseIf e.KeyCode = Keys.Down Then
                tb = 2
                DG1.Focus()
                DG1.Item(1, 0).Selected = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub

    Private Sub DG1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If tb = 1 Then
                    TextBox3.Text = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                    DG1.Visible = False
                    GroupBox1.Enabled = True
                    TextBox4.Focus()

                End If
                If tb = 2 Then
                    TextBox4.Text = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                    DG1.Visible = False
                    GroupBox1.Enabled = True
                    ComboBox1.Focus()
                End If
                If tb = 3 Then
                    dgpurch.CurrentCell.Value = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                    DG1.Visible = False
                    GroupBox1.Enabled = True
                    dgpurch.Item(3, dgpurch.CurrentCell.RowIndex).Selected = True
                    dgpurch.Focus()

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
         End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                TextBox5.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
         End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                MaskedTextBox1.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                TextBox6.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
         End Sub
    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                MaskedTextBox2.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
         End Sub
    Private Sub MaskedTextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                GroupBox1.Enabled = False
                dgpurch.Focus()
                dgpurch.Item(0, 0).Value = 1
                dgpurch.Item(1, 0).Selected = True
                ' TextBox6.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
         End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            GroupBox1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub GroupBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Leave
        Try
            GroupBox1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dgpurch_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpurch.CellLeave
        Try
            If e.ColumnIndex = 7 Then
                '  MsgBox("het")
                dgpurch.Item(0, e.RowIndex + 1).Value = dgpurch.Item(0, e.RowIndex).Value + 1
                SendKeys.Send("{ENTER}")
                SendKeys.Send("{ENTER}")
                'dgpurch.Item(1, 1).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgpurch_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgpurch.CellValidated
        Try
            If e.ColumnIndex = 1 Then
                dgpurch.CurrentCell.Value = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                'DG1.Visible = False
                Dim dr As SqlDataReader
                dr = myconselect("tblItem", dgpurch.CurrentCell.Value, "ITName")
                While dr.Read
                    dgpurch.Item(2, dgpurch.CurrentCell.RowIndex).Value = dr.Item("ITCode")
                    dgpurch.Item(6, dgpurch.CurrentCell.RowIndex).Value = dr.Item("Rate")
                    dgpurch.Item(7, dgpurch.CurrentCell.RowIndex).Value = dr.Item("ITUnit")
                End While
                dr.Close()
            ElseIf e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                If dgpurch.Item(3, e.RowIndex).Value = 0 And dgpurch.Item(4, e.RowIndex).Value = 0 Then

                Else
                    dgpurch.Item(5, e.RowIndex).Value = dgpurch.Item(3, e.RowIndex).Value * dgpurch.Item(4, e.RowIndex).Value
                    dgpurch.Item(8, e.RowIndex).Value = dgpurch.Item(5, e.RowIndex).Value * dgpurch.Item(6, e.RowIndex).Value


                End If
            ElseIf e.ColumnIndex = 5 Then
                If dgpurch.Item(3, e.RowIndex).Value = 0 And dgpurch.Item(4, e.RowIndex).Value = 0 And dgpurch.Item(5, e.RowIndex).Value <> 0 Then
                    dgpurch.Item(8, e.RowIndex).Value = dgpurch.Item(5, e.RowIndex).Value * dgpurch.Item(6, e.RowIndex).Value
                End If
            ElseIf e.ColumnIndex = 6 Then
                dgpurch.Item(8, e.RowIndex).Value = dgpurch.Item(5, e.RowIndex).Value * dgpurch.Item(6, e.RowIndex).Value
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        End Sub

    Private Sub dgpurch_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgpurch.EditingControlShowing

        Try
            Dim editingControl As TextBox = TryCast(e.Control, TextBox)

            If editingControl IsNot Nothing Then
                AddHandler editingControl.KeyDown, AddressOf Me.tx_Keydown
                '       IsHandleAdded = True
                RemoveHandler Me.dgpurch.EditingControlShowing, AddressOf Me.dgpurch_EditingControlShowing
                AddHandler editingControl.KeyPress, AddressOf Me.tx_KeyPress

                '       IsHandleAdded = True
                RemoveHandler Me.dgpurch.EditingControlShowing, AddressOf Me.dgpurch_EditingControlShowing

                AddHandler editingControl.KeyUp, AddressOf Me.tx_KeyUp
                '       IsHandleAdded = True
                RemoveHandler Me.dgpurch.EditingControlShowing, AddressOf Me.dgpurch_EditingControlShowing
                AddHandler editingControl.GotFocus, AddressOf Me.tx_Focus
                RemoveHandler Me.dgpurch.EditingControlShowing, AddressOf Me.dgpurch_EditingControlShowing
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    

    Private Sub tx_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            Try
                If (Me.dgpurch.CurrentCell.ColumnIndex = 1) Then
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            '     If (Me.dgpurch.CurrentCell.ColumnIndex = 3 Or dgpurch.CurrentCell.ColumnIndex = 4 Or dgpurch.CurrentCell.ColumnIndex = 5 Or dgpurch.CurrentCell.ColumnIndex = 6) Then
            'onlyNumbers(sender, e)
            ' End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub tx_Keydown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If dgpurch.CurrentCell.ColumnIndex = 1 Then
            If e.KeyCode = 113 Then
                DG1.Focus()
            End If
        End If
    End Sub
    Private Sub tx_Focus(ByVal sender As Object, ByVal e As System.EventArgs)
        If dgpurch.CurrentCell.ColumnIndex = 1 Then
            MsgBox("het")

        End If
        
    End Sub
    Private Sub tx_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        Try
            If (Me.dgpurch.CurrentCell.ColumnIndex = 1) Then
                connect()
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("Select * from tblItem where ITName like '" & sender.text & "%'", cn)
                da.Fill(ds)
                DG1.DataSource = ds.Tables(0)
                DG1.BringToFront()
                DG1.Visible = True
                Dim re As New Rectangle
                re = dgpurch.GetCellDisplayRectangle(dgpurch.CurrentCell.ColumnIndex, dgpurch.CurrentCell.RowIndex, True)
                DG1.Top = re.Top + 300
                tb = 3
                'DG1.Top = 320 + Me.dgpurch.CurrentCell.RowIndex * 22
                close1()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dgpurch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgpurch.KeyDown
     
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim max As Integer = 0
        Try
            Dim i As Integer
            For i = 0 To dgpurch.Rows.Count - 1
                max = max + 1
                ' MsgBox(max)
                MsgBox(dgpurch.Item(1, i).Value)
                If dgpurch.Item(1, i).Value = "" Then
                    GoTo en
                End If
            Next
en:
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        MsgBox(max)
    End Sub
End Class