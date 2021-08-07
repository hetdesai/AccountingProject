Imports System.Data.SqlClient
Public Class frmzoom2
    Public pass As Integer
    Public mhead As String
    Public asd As String
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Private Sub frmzoom2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If zoomfrom = "Main" Then
                connect()
                da = New SqlDataAdapter("Select tblMH.Mhead,tblMH.Mcode,ASD,Sum(Dr) as DR ,Sum(Cr) as CR ,Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode group by tblMH.Mhead,tblMH.Mcode,ASD order by tblMH.Mcode ", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                close1()
                frmzoom1.Hide()
                Try
                    If frmzoom3.mhead.Trim.Length <> 0 Then
                        Dim i As Integer
                        For i = 0 To dg1.Rows.Count - 1
                            If dg1.Item(0, i).Value = frmzoom3.mhead Then
                                dg1.Item(0, i).Selected = True
                                frmzoom3.Close()
                                GoTo en
                            End If
                        Next
                    End If
                Catch ex As Exception

                End Try

en:
                dg1.Columns.Add("col5", "")
                Dim j As Integer
                For j = 0 To dg1.Rows.Count - 1
                    If dg1.Item(5, j).Value < 0 Then
                        dg1.Item(5, j).Value = dg1.Item(5, j).Value * -1
                        dg1.Item(6, j).Value = "DR"
                    End If

                Next

            End If
            '            mytree()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub mytree()
        Try
            connect()

            Tv1.Nodes.Add("BalanceSheet")
            Tv1.Nodes.Add("Profit & Loss")
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select tblMH.Mhead,tblMH.Mcode,ASD,Sum(Dr) as DR ,Sum(Cr) as CR ,Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode group by tblMH.Mhead,tblMH.Mcode,ASD order by tblMH.Mcode ", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                If dr.Item(1).ToString.StartsWith("B") Then
                    Tv1.Nodes(0).Nodes.Add(dr.Item(0))
                Else
                    Tv1.Nodes(1).Nodes.Add(dr.Item(0))
                End If
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                mhead = dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value
                Me.Hide()
                frmzoom3.Show()
            ElseIf e.KeyCode = Keys.Escape Then
                '           Dim cmd As New SqlCommand
                '          Dim dr As SqlDataReader
                '         connect()
                '        cmd = New SqlCommand("Select asd from tblMH where Mhead='" & dg1.Item(0, 0).Value & "'", cn)
                '       dr = cmd.ExecuteReader
                '      While dr.Read
                'asd = dr.Item("ASD")
                '   End While
                '   dr.Close()
                '    close1()
                '  Me.Hide()
                '   frmzoom1.Close()
                '   frmzoom1.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class