Imports System.Data.SqlClient
Public Class frmacsearch
    Dim check As Integer
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Public acname As String
    Public mhead As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox1.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox1.Text
        For i = temp1 To frmACMaster.DG1.Rows.Count - 2
            For j = temp2 To frmACMaster.DG1.ColumnCount - 1
                If j <> frmACMaster.findcol Then
                    GoTo a
                Else
                    If (frmnewzoom1.DG1.Item(j, i).Value.ToString.ToUpper.StartsWith(TextBox1.Text.ToUpper)) Then
                        frmnewzoom1.DG1.Item(j, i).Selected = True
                        temp2 = j + 1
                        '    check = 1
                        GoTo en
                    End If
                End If

a:

            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmAccountSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        Try
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select ac.ACname,Sum(tblLedg.bal) as Balance from tblAccount ac Left outer join tblLedg On tblLedg.ACname=ac.Acname  group by ac.ACname,tblLedg.ACname order by ac.ACNAme", cn)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Columns(0).Width = 300
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                acname = DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex).Value
                mhead = Label2.Text
                Dim k As Integer
                Try
                    For k = 0 To frmnewzoom1.DG1.Rows.Count - 1
                        If frmnewzoom1.DG1.Item(0, k).Value = mhead Then
                            frmnewzoom1.DG1.Item(2, k).Selected = True
                        ElseIf frmnewzoom1.DG1.Item(3, k).Value = mhead Then
                            frmnewzoom1.DG1.Item(5, k).Selected = True
                        End If
                    Next
                    frmnewzoom1.seachacname = acname
                    frmnewzoom1.mhead = Label2.Text
                    frmnewzoom1.Hide()
                    frmnewzoom2.Show()
                Catch ex As Exception

                End Try
                Me.Hide()
            End If
            If e.KeyCode = Keys.Up Then
                e.Handled = True
                If DataGridView1.SelectedCells.Item(0).RowIndex > 0 Then
                    DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex - 1).Selected = True
                End If
            End If
            If e.KeyCode = Keys.Down Then
                e.Handled = True
                If DataGridView1.SelectedCells.Item(0).RowIndex < DataGridView1.Rows.Count - 1 Then
                    DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex + 1).Selected = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp

        Try
            If (e.KeyCode = Keys.Up) Or e.KeyCode = Keys.Down Then
                GoTo en
            End If

        If TextBox1.Text.Trim.Length = 0 Then
                DataGridView1.Item(0, 0).Selected = True
            End If
            Dim j As Integer
            For j = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Item(0, j).Value.ToString.ToUpper.StartsWith(TextBox1.Text.ToString.ToUpper) Then
                    DataGridView1.Item(0, j).Selected = True
                    GoTo en
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

en:
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Enter
       

    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        Try
            connect()
            Dim mcode As String
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select * from tblAccount where ACNAme='" & DataGridView1.Item(0, e.RowIndex).Value & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Label3.Text = dr.Item("Add1") & "    " & dr.Item("Add2") & " " & dr.Item("Place")
                Label4.Text = dr.Item("State")
                Label5.Text = dr.Item("MobNo")
                Label6.Text = dr.Item("Pin")
                mcode = dr.Item("Mcode")
            End While
            dr.Close()
            cmd = New SqlCommand("Select * from tblLedg where ACNAme='" & DataGridView1.Item(0, e.RowIndex).Value & "' and BOok='OPBAL'", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                dr.Close()
                Label8.Text = "0.00"
            Else
                While dr.Read
                    Label8.Text = dr.Item("bal")
                    If Val(Label8.Text) < 0 Then
                        Label8.Text = Val(Label8.Text) * -1 & "DB"
                    End If

                End While
                dr.Close()
                 End If
            cmd = New SqlCommand("Select * from tblMH where Mcode='" & mcode & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Label1.Text = dr.Item("Malph")
                Label2.Text = dr.Item("Mhead")
            End While
            dr.Close()

            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class