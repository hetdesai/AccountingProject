Imports System.Data.SqlClient

Public Class frmRateMst
    Dim editcheck As Integer = 0
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProcess.KeyUp
        Try
            myAutoComplete(txtProcess, Liprocess, "prmst", "Process")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub txtStyle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStyle.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtStyle.Text = Listyle.Items(0).ToString
                txtItem.Focus()
                Listyle.Visible = False
            Catch ex As Exception
            End Try
        ElseIf e.KeyCode = Keys.Down Then
            If Listyle.Items.Count <> 0 Then
                Listyle.Focus()
                Listyle.SelectedIndex = 0
            End If
        ElseIf e.KeyCode = Keys.Up Then
            txtProcess.Focus()
            Listyle.Visible = False
        End If
    End Sub
    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStyle.KeyUp
        myAutoComplete(txtStyle, Listyle, "Stylemst", "Style")

    End Sub
    Private Sub TextBox6_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItem.KeyUp
        '   myAutoComplete(txtItem, Liitem, "tblItem", "ITNAME")
        connect()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select * from " & "tblItem" & " where " & "itname" & " like '" & txtItem.Text & "%'", cn)
        dr = cmd.ExecuteReader
        Liitem.Items.Clear()
        While dr.Read
            Liitem.Items.Add(dr.Item("ITNAME"))
        End While
        dr.Close()
        close1()
        Liitem.Left = txtItem.Left
        Liitem.Top = txtItem.Top + 25
        Liitem.Width = txtItem.Width
        Liitem.Visible = True
        Liitem.BringToFront()
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyUp
        Try
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter(acm(txtAcname.Text), cn)
            da.Fill(ds)
            dgacm.DataSource = ds.Tables(0)
            dgacm.Visible = True
            dgacm.AutoResizeColumns()
            dgacm.Top = txtAcname.Top + 22
            dgacm.BringToFront()
            close1()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcname.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgacm.RowCount <> 0 Then
                    txtAcname.Text = dgacm.Item(1, dgacm.CurrentCell.RowIndex).Value
                End If
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                cmd = New SqlCommand("select * from tblAccount where acname='" & txtAcname.Text & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Try

                        txtPgroup.Text = dr.Item("pgroup")
                        txtMst.Text = dr.Item("mstname")
                    Catch ex As Exception

                    End Try
                End While
                dr.Close()
                close1()
                dgacm.Visible = False
                txtProcess.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                dgacm.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgacm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                txtAcname.Text = dgacm.Item(1, dgacm.CurrentCell.RowIndex).Value
                connect()
                cmd = New SqlCommand("select * from tblAccount where acname='" & txtAcname.Text & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Try

                        txtPgroup.Text = dr.Item("pgroup")
                        txtMst.Text = dr.Item("mst")
                    Catch ex As Exception

                    End Try
                End While
                dr.Close()
                txtProcess.Focus()
                close1()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtProcess_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProcess.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtProcess.Text = Liprocess.Items(0).ToString
                txtStyle.Focus()
                Liprocess.Visible = False
            Catch ex As Exception
            End Try
        ElseIf e.KeyCode = Keys.Down Then
            If Liprocess.Items.Count <> 0 Then
                Liprocess.Focus()
                Liprocess.SelectedIndex = 0
            End If
        ElseIf e.KeyCode = Keys.Up Then
            Liprocess.Visible = False
            txtAcname.Focus()
        End If
    End Sub

    Private Sub Liprocess_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Liprocess.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtProcess.Text = Liprocess.SelectedItem.ToString
                txtStyle.Focus()
                Liprocess.Visible = False
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub Listyle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Listyle.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtStyle.Text = Listyle.SelectedItem.ToString
                txtItem.Focus()
                Listyle.Visible = False
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub txtitem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtItem.Text = Liitem.Items(0).ToString
                txtShade.Focus()
                Liitem.Visible = False
            Catch ex As Exception

            End Try
        ElseIf e.KeyCode = Keys.Down Then
            If Liitem.Items.Count <> 0 Then
                Liitem.Focus()
                Liitem.SelectedIndex = 0
            End If
        ElseIf e.KeyCode = Keys.Up Then
            Liitem.Visible = False
            txtStyle.Focus()
        End If
    End Sub

    Private Sub Liitem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Liitem.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtItem.Text = Liitem.SelectedItem.ToString
                txtShade.Focus()
                Liitem.Visible = False
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub txtRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtItem.Focus()
        End If

    End Sub

    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        editcheck = 0
        txtAcname.Focus()
    End Sub

    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        editcheck = 1
        txtPgroup.Text = dg1.Item(0, dg1.CurrentCell.RowIndex).Value
        txtAcname.Text = dg1.Item(1, dg1.CurrentCell.RowIndex).Value
        txtMst.Text = dg1.Item(2, dg1.CurrentCell.RowIndex).Value
        txtProcess.Text = dg1.Item(3, dg1.CurrentCell.RowIndex).Value
        txtStyle.Text = dg1.Item(4, dg1.CurrentCell.RowIndex).Value
        txtItem.Text = dg1.Item(5, dg1.CurrentCell.RowIndex).Value
        txtRate.Text = dg1.Item(6, dg1.CurrentCell.RowIndex).Value
        TextBox1.Text = dg1.Item(7, dg1.CurrentCell.RowIndex).Value
        txtAcname.Focus()
    End Sub

    Private Sub frmRateMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myfilldatagrid(dg1, "ratemst")
        Try
            dg1.Item(0, dg1.Rows.Count - 1).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dg1_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        txtPgroup.Text = dg1.Item(0, dg1.CurrentCell.RowIndex).Value
        txtAcname.Text = dg1.Item(1, dg1.CurrentCell.RowIndex).Value
        txtMst.Text = dg1.Item(2, dg1.CurrentCell.RowIndex).Value
        txtProcess.Text = dg1.Item(3, dg1.CurrentCell.RowIndex).Value
        txtStyle.Text = dg1.Item(4, dg1.CurrentCell.RowIndex).Value
        txtShade.Text = dg1.Item(5, dg1.CurrentCell.RowIndex).Value
        txtItem.Text = dg1.Item(6, dg1.CurrentCell.RowIndex).Value
        txtRate.Text = dg1.Item(7, dg1.CurrentCell.RowIndex).Value
        TextBox1.Text = dg1.Item(8, dg1.CurrentCell.RowIndex).Value
    End Sub

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            If MsgBox("Are you sure you want to delete entry", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Delete from ratemst where serialno=" & Val(TextBox1.Text), cn)
                cmd.ExecuteNonQuery()
                close1()
                myfilldatagrid(dg1, "ratemst")
                Try
                    dg1.Item(0, dg1.Rows.Count - 1).Selected = True
                Catch ex As Exception

                End Try
            End If
            
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txtRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRate.Leave
        txtRate.Text = Format(Val(txtRate.Text), "0.00")
    End Sub

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            If editcheck = 0 Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                cmd = New SqlCommand("Select * from ratemst where pgroup='" & txtPgroup.Text & "' and acname='" & txtAcname.Text & "' and mst='" & txtMst.Text & "' and process='" & txtProcess.Text & "' and style='" & txtStyle.Text & "' and item='" & txtItem.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    MsgBox("This combination already exists")
                    dr.Close()
                    close1()
                    GoTo en
                Else

                    ' MsgBox("het")
                    dr.Close()
                    close1()
                    Dim a() As String = {txtPgroup.Text, txtAcname.Text, txtMst.Text, txtProcess.Text, txtStyle.Text, txtShade.Text, txtItem.Text, txtRate.Text}
                    myinsert(a, "ratemst")
                    MsgBox("Inserted")
                    myfilldatagrid(dg1, "ratemst")
                    Try
                        dg1.Item(0, dg1.Rows.Count - 1).Selected = True
                    Catch ex As Exception

                    End Try
                End If

            ElseIf editcheck = 1 Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Delete from ratemst where serialno=" & Val(TextBox1.Text), cn)
                cmd.ExecuteNonQuery()
                close1()
                Dim a() As String = {txtPgroup.Text, txtAcname.Text, txtMst.Text, txtProcess.Text, txtStyle.Text, txtShade.Text, txtItem.Text, txtRate.Text}
                myinsert(a, "ratemst")
                MsgBox("Updated")
                myfilldatagrid(dg1, "ratemst")
                Try
                    dg1.Item(0, dg1.Rows.Count - 1).Selected = True
                Catch ex As Exception

                End Try

            End If
        Catch ex As Exception

        End Try
en:
    End Sub

    Private Sub txtShade_KeyDown(sender As Object, e As KeyEventArgs) Handles txtShade.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtShade.Text = listshade.Items(0).ToString
                txtRate.Focus()
                listshade.Visible = False
            Catch ex As Exception

            End Try
        ElseIf e.KeyCode = Keys.Down Then
            If listshade.Items.Count <> 0 Then
                listshade.Focus()
                listshade.SelectedIndex = 0
            End If
        ElseIf e.KeyCode = Keys.Up Then
            listshade.Visible = False
            txtItem.Focus()
        End If
    End Sub

    Private Sub txtShade_KeyUp(sender As Object, e As KeyEventArgs) Handles txtShade.KeyUp
        myAutoComplete(txtShade, listshade, "tblShade", "Shade")
    End Sub

    Private Sub listshade_KeyDown(sender As Object, e As KeyEventArgs) Handles listshade.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                txtShade.Text = listshade.SelectedItem.ToString
                txtRate.Focus()
                listshade.Visible = False
            Catch ex As Exception

            End Try

        End If
    End Sub
End Class