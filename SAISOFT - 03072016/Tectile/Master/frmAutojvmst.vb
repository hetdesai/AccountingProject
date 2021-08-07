Imports System.Data.SqlClient
Public Class frmAutojvmst
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private scAutoComplete As New AutoCompleteStringCollection
    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Aujvmst where AujvBook='" & ComboBox1.Text & "'", cn)
            Dim ds As New DataSet
            da.Fill(ds)
            MyDataGridView1.DataSource = ds.Tables(0)
          
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Delete from AUjvmst where AujvBook='" & ComboBox1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            For i = 0 To MyDataGridView1.Rows.Count - 1
                Dim a() As String = {MyDataGridView1.Item(0, i).Value, MyDataGridView1.Item(1, i).Value, MyDataGridView1.Item(2, i).Value, MyDataGridView1.Item(3, i).Value, MyDataGridView1.Item(4, i).Value}
                myinsert(a, "AUjvMst")
            Next
            MsgBox("updated")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub MyDataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MyDataGridView1.CellValidated
        Try
            If e.ColumnIndex = 1 Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("select accode from tblaccount where acname='" & MyDataGridView1.Item(1, e.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    MyDataGridView1.Item(2, e.RowIndex).Value = dr.Item(0)
                End While
                dr.Close()
                close1()
            End If
        Catch ex As Exception
            MsgBox("incorrect account name")
            MyDataGridView1.Item(1, e.RowIndex).Selected = True
        End Try


    End Sub
    Private Sub MyDataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles MyDataGridView1.EditingControlShowing
        If MyDataGridView1.CurrentCell.ColumnIndex = 1 AndAlso TypeOf e.Control Is TextBox Then ' Checking Whether the Editing Control Column Index is 1 or not if 1 Then Enabling Auto Complete Extender
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
    Private Sub bindGrid()
        ' DataGridView1.DataSource = ds.Tables(0) ' To get Data Table for the Grid View
        setAutoComplete()
    End Sub
    Private Sub setAutoComplete()
        connect()
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
    Private Sub frmAutojvmst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bindGrid()
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub MyDataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles MyDataGridView1.RowsAdded
        Try
            '  MyDataGridView1.Item(2, e.RowIndex).Value = ComboBox1.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        If ComboBox1.Items.Contains(ComboBox1.Text) = False Then
            MessageBox.Show("Select from list")
            ComboBox1.Focus()
        End If
    End Sub
End Class