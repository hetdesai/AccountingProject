Imports System.Data.SqlClient
Public Class frmtaxmst
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private scAutoComplete As New AutoCompleteStringCollection

    Private Sub frmtaxmst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmtaxmst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select distinct tax from taxmst", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select acname from tblAccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox4.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub bindGrid()
        ' DataGridView1.DataSource = ds.Tables(0) ' To get Data Table for the Grid View
        setAutoComplete()
    End Sub
    Private Sub setAutoComplete()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select * from tblAccount", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            scAutoComplete.Add(dr.Item("ACName").ToString)
        End While
        dr.Close()
        cn.Close()
    End Sub
    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                connect()
                Dim ds As New DataSet
                da = New SqlDataAdapter("Select * from taxmst where tax='" & ComboBox1.Text & "'", cn)
                da.Fill(ds, "as")
                '          dg1.DataSource = ds.Tables(0)
                '         da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim i As Integer
                    dg1.Rows.Clear()
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        With dg1
                            dg1.Rows.Add()
                            .Item(0, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(0)
                            .Item(1, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(1)
                            .Item(2, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(2)
                            .Item(3, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(3)
                            .Item(4, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(4)
                            .Item(5, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(5)
                            .Item(6, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(6)
                            .Item(7, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(7)
                            .Item(8, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(8)
                            .Item(9, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(9)
                            .Item(10, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(10)
                            .Item(11, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(11)
                            .Item(12, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(12)
                            .Item(13, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(13)
                            .Item(14, .RowCount - 1).Value = ds.Tables(0).Rows(i).Item(14)
                        End With
                    Next
                End If
                dg1.Columns(0).ReadOnly = True
                dg1.Columns(5).Width = 300
                dg1.Columns(1).ReadOnly = True
                dg1.Columns(1).DefaultCellStyle.ForeColor = Color.Red
                Try
                    ComboBox2.Text = dg1.Item(0, 0).Value
                Catch ex As Exception

                End Try
                bindGrid()
                close1()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub MyDataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try

            If e.ColumnIndex = 6 Then
                Dim dr As SqlDataReader
                Dim cmd As New SqlCommand
                connect()
                cmd = New SqlCommand("Select ACCOde from tblAccount where ACName='" & dg1.Item(5, e.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    dg1.Item(6, e.RowIndex).Value = dr.Item(0)
                End While
                dr.Close()
                close1()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub MyDataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellValidated
        Try
            If dg1.Item(0, e.RowIndex).Value.ToString.ToLower = "purchase" Or dg1.Item(0, e.RowIndex).Value.ToString.ToLower = "sale" Then
            Else
                MsgBox("Not valid")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MyDataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dg1.DefaultValuesNeeded
        dg1.Item(1, e.Row.Index).Value = ComboBox1.Text
        dg1.Item(0, e.Row.Index).Value = ComboBox2.Text
    End Sub

    Private Sub MyDataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dg1.EditingControlShowing
        If dg1.CurrentCell.ColumnIndex = 5 AndAlso TypeOf e.Control Is TextBox Then ' Checking Whether the Editing Control Column Index is 1 or not if 1 Then Enabling Auto Complete Extender
            With DirectCast(e.Control, TextBox)
                .AutoCompleteCustomSource = scAutoComplete
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
            End With
        Else ' we are not Enabling Auto Complete Extendar
            With DirectCast(e.Control, TextBox)
                .AutoCompleteMode = AutoCompleteMode.None
            End With
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            connect()

            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Delete from taxmst where tax='" & ComboBox1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            For i = 0 To dg1.Rows.Count - 1
                If ComboBox2.Text.ToUpper = "Purchase".ToUpper Then
                    connect()
                    cmd = New SqlCommand("Update tblpurtax set poname='" & dg1.Item(5, i).Value & "',pocode=" & dg1.Item(6, i).Value & " where bktype='Purchase' and tax='" & ComboBox1.Text & "' and taxnara='" & dg1.Item(2, i).Value & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()

                ElseIf ComboBox2.Text.ToUpper = "SAle".ToUpper Then
                    connect()
                    cmd = New SqlCommand("Update saltax set poname='" & dg1.Item(5, i).Value & "',pocode=" & dg1.Item(6, i).Value & " where bktype='Sale' and tax='" & ComboBox1.Text & "' and taxnara='" & dg1.Item(2, i).Value & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                End If

                Dim a() As String = {dg1.Item(0, i).Value, dg1.Item(1, i).Value, dg1.Item(2, i).Value, dg1.Item(3, i).Value.ToString, dg1.Item(4, i).Value, dg1.Item(5, i).Value, dg1.Item(6, i).Value, dg1.Item(7, i).Value, dg1.Item(8, i).Value, dg1.Item(9, i).Value, dg1.Item(10, i).Value, dg1.Item(11, i).Value, dg1.Item(12, i).Value, dg1.Item(14, i).Value}
                myinsert(a, "taxmst")
            Next
            MsgBox("updated")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub
    Private Sub dg1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg1.RowsAdded

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Delete from taxmst where tax='" & ComboBox1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            MsgBox("Deleted")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave, ComboBox3.Leave, ComboBox4.Leave, ComboBox5.Leave, ComboBox6.Leave, ComboBox7.Leave, ComboBox8.Leave, ComboBox9.Leave
        If sender.Items.Contains(sender.Text) = False Then
            MsgBox("Select from list")
            sender.Focus()
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select accode from tblAccount where acname='" & ComboBox4.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox2.Text = dr.Item(0)
            End While
            dr.Close()
            close1()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Label14.Text = "ADD"
        ComboBox1.Focus()
     
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try

        With dg1

                Label14.Text = "EDIT"
                ComboBox2.Text = .Item(0, .CurrentCell.RowIndex).Value
                ComboBox1.Text = .Item(1, .CurrentCell.RowIndex).Value
                TextBox1.Text = .Item(2, .CurrentCell.RowIndex).Value
                ComboBox3.Text = .Item(3, .CurrentCell.RowIndex).Value
                TextBox3.Text = .Item(4, .CurrentCell.RowIndex).Value
                ComboBox4.Text = .Item(5, .CurrentCell.RowIndex).Value
                TextBox2.Text = .Item(6, .CurrentCell.RowIndex).Value
                ComboBox5.Text = .Item(7, .CurrentCell.RowIndex).Value
                ComboBox7.Text = .Item(8, .CurrentCell.RowIndex).Value
                ComboBox9.Text = .Item(9, .CurrentCell.RowIndex).Value
                ComboBox6.Text = .Item(11, .CurrentCell.RowIndex).Value
                ComboBox8.Text = .Item(12, .CurrentCell.RowIndex).Value
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try

        If Label14.Text = "ADD" Then


                dg1.Rows.Add()
                With dg1
                    .Item(0, .RowCount - 1).Value = ComboBox2.Text
                    .Item(1, .RowCount - 1).Value = ComboBox1.Text
                    .Item(2, .RowCount - 1).Value = TextBox1.Text
                    .Item(3, .RowCount - 1).Value = ComboBox3.Text
                    .Item(4, .RowCount - 1).Value = TextBox3.Text
                    .Item(5, .RowCount - 1).Value = ComboBox4.Text
                    .Item(6, .RowCount - 1).Value = TextBox2.Text
                    .Item(7, .RowCount - 1).Value = ComboBox5.Text
                    .Item(8, .RowCount - 1).Value = ComboBox7.Text
                    .Item(9, .RowCount - 1).Value = ComboBox9.Text
                    .Item(10, .RowCount - 1).Value = 0
                    .Item(11, .RowCount - 1).Value = ComboBox6.Text
                    .Item(12, .RowCount - 1).Value = ComboBox8.Text
                    .Item(13, .RowCount - 1).Value = ""
                    .Item(14, .RowCount - 1).Value = 0
                End With
            ElseIf Label14.Text = "EDIT" Then
                With dg1
                    .Item(0, .CurrentCell.RowIndex).Value = ComboBox2.Text
                    .Item(1, .CurrentCell.RowIndex).Value = ComboBox1.Text
                    .Item(2, .CurrentCell.RowIndex).Value = TextBox1.Text
                    .Item(3, .CurrentCell.RowIndex).Value = ComboBox3.Text
                    .Item(4, .CurrentCell.RowIndex).Value = TextBox3.Text
                    .Item(5, .CurrentCell.RowIndex).Value = ComboBox4.Text
                    .Item(6, .CurrentCell.RowIndex).Value = TextBox2.Text
                    .Item(7, .CurrentCell.RowIndex).Value = ComboBox5.Text
                    .Item(8, .CurrentCell.RowIndex).Value = ComboBox7.Text
                    .Item(9, .CurrentCell.RowIndex).Value = ComboBox9.Text
                    .Item(10, .CurrentCell.RowIndex).Value = 0
                    .Item(11, .CurrentCell.RowIndex).Value = ComboBox6.Text
                    .Item(12, .CurrentCell.RowIndex).Value = ComboBox8.Text
                    .Item(13, .CurrentCell.RowIndex).Value = ""
                    .Item(14, .CurrentCell.RowIndex).Value = 0
                End With

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            dg1.Rows.RemoveAt(dg1.CurrentCell.RowIndex)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            connect()
            ComboBox1.Items.Clear()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select distinct(tax) from taxmst where bktype='" & ComboBox2.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class