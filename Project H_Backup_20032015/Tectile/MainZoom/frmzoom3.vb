Imports System.Data.SqlClient
Public Class frmzoom3
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Public shead As String
    Public mhead As String
    Private Sub frmzoom3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If zoomfrom = "Main" Then
                connect()
                da = New SqlDataAdapter("Select tblSH.Shead,tblSH.Scode ,Sum(Dr) as DR,Sum(Cr) as CR,Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblMH.Mhead='" & frmzoom2.mhead & "' group by tblSH.Shead,tblSH.Scode", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                close1()
                frmzoom2.Hide()
                Try
                    If frmzoom4.shead.Trim.Length <> 0 Then
                        Dim i As Integer
                        For i = 0 To dg1.Rows.Count - 1
                            If dg1.Item(0, i).Value = frmzoom4.shead Then
                                dg1.Item(0, i).Selected = True
                                frmzoom4.Close()
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
                    If dg1.Item(4, j).Value < 0 Then
                        dg1.Item(4, j).Value = dg1.Item(4, j).Value * -1
                        dg1.Item(5, j).Value = "DR"
                    End If

                Next
            End If
            

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub dg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                shead = dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value
                frmzoom4.Show()
            ElseIf e.KeyCode = Keys.Escape Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                cmd = New SqlCommand("Select Mhead from tblSH where Shead='" & dg1.Item(0, 0).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    mhead = dr.Item("Mhead")
                End While
                dr.Close()
                close1()
                '  Me.Hide()
                frmzoom2.Close()
                frmzoom2.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class