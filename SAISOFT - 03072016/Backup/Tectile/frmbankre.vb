Imports System.Data.SqlClient
Public Class frmbankre
    Dim da As SqlDataAdapter
    Dim ds As New DataSet

    Private Sub frmbankre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.AllowUserToAddRows = False
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select acname from tblaccount where book='bank'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            connect()
            Dim sql As String
            If RadioButton1.Checked = True Then
                sql = "Select vrno,Namecr,checkno,dat,ispassed,passdt from tblBank where namecr<>bkname and bkname='" & CheckedListBox1.CheckedItems(0).ToString & "' and ispassed='f'"
            ElseIf RadioButton2.Checked = True Then
                sql = "Select vrno,Name,checkno,dat,ispassed,passdt from tblBank where name<>bkname and bkname='" & CheckedListBox1.CheckedItems(0).ToString & "' and ispassed='f'"
            Else
                sql = "Select vrno,Name,Namecr,checkno,dat,ispassed,passdt from tblBank where bkname='" & CheckedListBox1.CheckedItems(0).ToString & "' and ispassed='f'"
            End If
            da = New SqlDataAdapter(sql, cn)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.AutoResizeColumns()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DataGridView1.Focus()
            DataGridView1.Item(DataGridView1.ColumnCount - 2, DataGridView1.CurrentCell.RowIndex).Value = "t"
        End If
        
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try

            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime

            dat1 = dateyf.ToString
            dat2 = dateyl.ToString
            dat = MaskedTextBox1.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                DataGridView1.Item(DataGridView1.ColumnCount - 1, DataGridView1.CurrentCell.RowIndex).Value = MaskedTextBox1.Text
            Else
                MsgBox("Please enter date in current year")
                MaskedTextBox1.Focus()
            End If


        Catch ex As Exception
            MsgBox("enter proper date")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            ' Dim cb As New SqlCommandBuilder(da)
            ' da.Update(ds)
            Dim i As Integer
            Dim cmd As New SqlCommand
            connect()
            Dim dat As New Date
            For i = 0 To DataGridView1.RowCount - 1

                MaskedTextBox1.Text = DataGridView1.Item(DataGridView1.ColumnCount - 1, i).Value.ToString
                dat = MaskedTextBox1.Text
                cmd = New SqlCommand("update tblbank set ispassed='" & DataGridView1.Item(DataGridView1.ColumnCount - 2, i).Value & "',passdt='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' where vrno='" & DataGridView1.Item(0, i).Value & "'", cn)
                cmd.ExecuteNonQuery()
            Next
            close1()

            MsgBox("succeddful")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.F9 Then
            MaskedTextBox1.Focus()
        End If
    End Sub
End Class