Imports System.Data.SqlClient
Public Class frmdissh
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim mhead As String = ""
    Private Sub frmdissh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select * from tblMh where malph='" & frmACMaster.TextBox22.Text & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                mhead = dr.Item("Mhead")
            End While
            dr.Close()
            da = New SqlDataAdapter("Select Shead,alias,Mhead from tblSH where tblSH.Mhead like'" & mhead & "%' order by Mhead", cn)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Columns(0).Width = 200
            DataGridView1.Columns(1).Width = 100
            DataGridView1.Columns(2).Width = 200
            Try
                DataGridView1.Rows(0).Selected = True
            Catch ex As Exception
            End Try
            close1()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Try
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
            Dim k As Integer
            For k = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Item(0, k).Value.ToString.ToUpper.StartsWith(TextBox1.Text.ToUpper) Then
                    DataGridView1.Rows(k).Selected = True
                    GoTo en
                End If
            Next
en:
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Up Then
            Try
                DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex - 1).Selected = True
            Catch ex As Exception
            End Try
        ElseIf e.KeyCode = Keys.Down Then
            Try
                DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex + 1).Selected = True
            Catch ex As Exception
            End Try
        ElseIf e.KeyCode = Keys.Enter Then
            frmACMaster.txtShead.Text = DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex).Value
            frmACMaster.txtShead.Focus()
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmACMaster.accheck = 1
        frmSHMaster.Show()
        Me.Close()
        frmACMaster.PictureBox1.SendToBack()
        frmSHMaster.TextBox1.Text = mhead
        connect()
        Dim CMD As New SqlCommand
        CMD = New SqlCommand("sELECT * FROM TBLMH WHERE MHEAD='" & mhead & "'", cn)
        Dim DR As SqlDataReader
        DR = CMD.ExecuteReader
        While DR.Read
            frmSHMaster.TextBox7.Text = DR.Item("MALPH")
        End While
        DR.Close()
        close1()
        frmSHMaster.cmdAdd.Enabled = True
        frmSHMaster.GroupBox1.Focus()
        frmSHMaster.TextBox2.Focus()
        connect()
        CMD = New SqlCommand("Select * from tblMh where mhead='" & mhead & "'", cn)
        DR = CMD.ExecuteReader
        While dr.Read
            frmSHMaster.TextBox3.Text = dr.Item("Mcode")
        End While
        dr.Close()
        close1()
    End Sub
End Class