Imports System.Data.SqlClient
Public Class frmbilldis
    Dim temp1 As Integer = 0
    Dim temp2 As Integer = 0
    Public editcheck As Integer = 0
    Private Sub frmbilldis_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FRMDISPATCH.Show()
    End Sub

    Private Sub frmbilldis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '   MsgBox(FRMDISPATCH.editcheck)
            If FRMDISPATCH.editcheck = 1 Then
                TextBox1.Focus()
                editcheck = 1
                '   MsgBox("het")
            End If
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("select Vrno,billdt,billno,Name,Pcs,Qty,NetAmt,BKName,mst,delvary from sale", cn)
            da.Fill(ds)
            dg1.DataSource = ds.Tables(0)
            Try
                dg1.Columns(0).Visible = False
                dg1.Item(1, dg1.RowCount - 1).Selected = True
                dg1.Focus()
            Catch ex As Exception
                ' MsgBox(ex.ToString)
            End Try
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                FRMDISPATCH.Close()
                FRMDISPATCH.edlotno = dg1.Item(0, dg1.CurrentCell.RowIndex).Value
                FRMDISPATCH.Label22.Text = "EDIT"
                FRMDISPATCH.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Dim tv As String
        If e.KeyCode = Keys.Enter Then
            tv = TextBox1.Text
            Dim i, j As Integer
            i = 0
            j = 0
            temp1 = 0
            temp2 = 0
            '  MsgBox("het")
            'tv = txtfind.Text
            '   MsgBox(dg1.Columns(0).Name)
            For i = temp1 To dg1.Rows.Count - 1
                For j = temp2 To dg1.ColumnCount - 1
                    If dg1.Columns(j).Name.ToString.ToLower = "billno" Then
                        '    MsgBox("a")
                        If (dg1.Item(j, i).Value.ToString.ToUpper = (TextBox1.Text.ToUpper)) Then
                            Try
                                dg1.Item(j, i).Selected = True
                                dg1.Focus()
                                GoTo en
                            Catch ex As Exception

                            End Try

                            temp2 = j + 1
                            '    check = 1
                            GoTo en
                        End If


a:
                    End If
                Next
                temp1 = i + 1
                temp2 = 0
            Next
en:
        End If
    End Sub

    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FRMDISPATCH.Show()
    End Sub
End Class