Imports System.Data.SqlClient
Public Class frmzoom4
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Public ACName As String
    Public shead As String
    Private Sub frmzoom4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If zoomfrom = "Main" Then
                connect()
                da = New SqlDataAdapter("Select tblAccount.ACName,tblAccount.ACCode,Sum(Dr) as DR,Sum(Cr) as CR,Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblSH.Shead='" & frmzoom3.shead & "' group by tblAccount.ACName,tblAccount.ACCode", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                close1()
                frmzoom3.Hide()
                Try
                    If frmzoomMonth.ACName.Trim.Length <> 0 Then
                        Dim i As Integer
                        For i = 0 To dg1.Rows.Count - 1
                            If dg1.Item(0, i).Value = frmzoomMonth.ACName Then
                                dg1.Item(0, i).Selected = True
                                frmzoomMonth.Close()
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
                Me.Hide()
                ACName = dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value
                frmzoomMonth.Show()
            ElseIf e.KeyCode = Keys.Escape Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                cmd = New SqlCommand("Select * from tblAccount where ACName='" & dg1.Item(0, 0).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    shead = dr.Item("Schedule")
                End While
                dr.Close()
                close1()
                '    Me.Hide()
                frmzoom3.Close()
                frmzoom3.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class