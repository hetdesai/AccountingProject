Imports System.Data.SqlClient
Public Class frmbrow
    Dim da As SqlDataAdapter
    Dim ds As New DataSet

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                connect()
                da = New SqlDataAdapter("Select * from " & TextBox1.Text, cn)
                da.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                DataGridView1.Columns(DataGridView1.ColumnCount - 4).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                DataGridView1.Columns(DataGridView1.ColumnCount - 4).Width = 300
                DataGridView1.AutoResizeRows()
                close1()
            End If
        Catch ex As Exception
        End Try
         End Sub

    Private Sub frmbrow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            Dim DA As New SqlDataAdapter
            Dim DS As New DataSet
            DA = New SqlDataAdapter("Select Table_Name from INFORMATION_SCHEMA.tables order by table_name", cn)
            DA.Fill(DS)
            DataGridView1.DataSource = DS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
       
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        Try

        If e.KeyCode = Keys.F1 Then
                da = New SqlDataAdapter(TextBox2.Text, cn)
                da.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                DataGridView2.BringToFront()
                DataGridView2.Focus()
            ElseIf e.KeyCode = Keys.F2 Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand(TextBox2.Text, cn)
                cmd.ExecuteNonQuery()
                MsgBox("Query Successful")
                close1()
            End If

        Catch ex As Exception
            MsgBox("INCORRECT QUERY")
        End Try

    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        TextBox3.Text = DataGridView1.CurrentCell.Value
        If e.KeyCode = Keys.Enter Then
            DataGridView2.BringToFront()
            da = New SqlDataAdapter("Select * from " & DataGridView1.CurrentCell.Value, cn)
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub DataGridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        If e.KeyCode = Keys.Escape Then
            DataGridView1.BringToFront()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If MsgBox("Are You sure you want to clear all the data", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim i As Integer
                Dim cmd As New SqlCommand
                For i = 0 To DataGridView1.RowCount - 1
                    If DataGridView1.Item(0, i).Value = "tblMH" Then
                        GoTo en
                    End If
                    connect()
                    cmd = New SqlCommand("Delete from " & DataGridView1.Item(0, i).Value, cn)
                    cmd.ExecuteNonQuery()
                    close1()
en:
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim CB As New SqlCommandBuilder(da)
        da.Update(ds)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        connect()
        Dim sql As String = ""

        Dim cmd As New SqlCommand

        close1()

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class