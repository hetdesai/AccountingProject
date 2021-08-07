Imports System.Data.SqlClient
Public Class frmadmin

    Private Sub frmadmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand(TextBox1.Text, cn)
                dr = cmd.ExecuteReader
                Dim sql As String = ""
                Dim i As Integer
                While dr.Read
                    sql = ""
                    For i = 0 To dr.VisibleFieldCount - 1
                        sql = sql & "     " & dr.Item(i)
                    Next
                    ListBox1.Items.Add(sql)
                End While
                dr.Close()
                ListBox1.Visible = True
                DataGridView1.Visible = False
                close1()
            ElseIf e.KeyCode = Keys.F3 Then
                connect()
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter(TextBox1.Text, cn)
                da.Fill(ds)
                DataGridView1.Visible = True
                ListBox1.Visible = False
                DataGridView1.DataSource = ds.Tables(0)
                close1()
            ElseIf e.KeyCode = Keys.F4 Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand(TextBox1.Text, cn)
                cmd.ExecuteNonQuery()
                MsgBox("Done")
                close1()


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class