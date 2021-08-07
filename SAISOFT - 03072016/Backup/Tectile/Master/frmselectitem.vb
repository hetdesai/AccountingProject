Imports System.Data.SqlClient
Public Class frmselectitem
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim TV1 As String = ""
    Dim TEMP1 As Integer
    Dim TEMP2 As Integer

    Private Sub frmselectitem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        Try
            da = New SqlDataAdapter("Select * from tblit2 where code like 'SST%' order by itname", cn)
            da.Fill(ds)
            Dim col As New DataGridViewTextBoxColumn
            col.Name = "col1"
            col.HeaderText = "No of copies"

            DG1.DataSource = ds.Tables(0)
            DG1.Columns.Add(col)
            DG1.Columns(DG1.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DG1.Columns(0).ReadOnly = True
            DG1.Columns(1).ReadOnly = True
            '         Dim i As New DataGridViewTextBoxColumn
            '        i.HeaderText = "No of copies"
            '       DG1.Columns.Add(i)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        close1()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        connect()
        Dim cb As New SqlCommandBuilder(da)
        da.Update(ds)
        close1()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button4.Focus()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox1.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox1.Text
        For i = TEMP1 To dg1.Rows.Count - 1
            For j = TEMP2 To DG1.ColumnCount - 2
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)
                If (DG1.Item(j, i).Value.ToString.ToLower.ToString.Contains(TextBox1.Text.ToLower)) Then
                    DG1.Item(j, i).Selected = True
                    TEMP2 = j + 1
                    '    check = 1
                    GoTo en
                End If
            Next
            TEMP1 = i + 1
            TEMP2 = 0
        Next
en:
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        connect()
        Dim cb As New SqlCommandBuilder(da)
        da.Update(ds)
        close1()
        frmprintbarcode.Show()
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub
End Class