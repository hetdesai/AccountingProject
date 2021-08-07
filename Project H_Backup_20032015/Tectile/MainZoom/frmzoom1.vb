Imports System.Data.SqlClient
Public Class frmzoom1
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Public asd As String

    Private Sub frmzoom1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'da = New SqlDataAdapter("Select Sum(Cr),Sum(Dr),Shead from tblLedg,tblAccount,tblSH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode group by Shead", cn)
            If zoomfrom = "Main" Then
                da = New SqlDataAdapter("Select ASD,Sum(Dr) As DR, Sum(Cr) as CR, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode group by ASD", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                close1()
                Try
                    If frmzoom2.asd.Trim.Length <> 0 Then
                        Dim i As Integer
                        For i = 0 To dg1.Rows.Count - 1
                            If dg1.Item(0, i).Value = frmzoom2.asd Then
                                dg1.Item(0, i).Selected = True
                                frmzoom2.Close()
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
                    If dg1.Item(3, j).Value < 0 Then
                        dg1.Item(3, j).Value = dg1.Item(3, j).Value * -1
                        dg1.Item(4, j).Value = "DR"
                    End If

                Next

            End If
            Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            asd = dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Value
            frmzoom2.Show()
            Me.Hide()
        End If
    End Sub
End Class