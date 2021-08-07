Imports System.Data.SqlClient
Public Class frmzoomMonth
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Public month As Integer
    Public ACName As String
    Dim sql As String
    Private Sub frmzoomMonth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            If zoomfrom = "Main" Then
                sql = "Select Month(Date) as Month,Year(Date) as Year,Sum(Dr) as DR,Sum(Cr) as CR,Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblLedg.ACName='" & frmzoom4.ACName & "' group By Month(Date),Year(Date)"
            End If
            If zoomfrom = "Ledger" Then
                sql = "Select Month(Date) as Month,Year(Date) as Year,Sum(Dr) as DR,Sum(Cr) as CR,Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblLedg.ACName='" & rptledggrid.Acname & "'and tblLedg.Date > '" & rptledggrid.datfrom.Month & "-" & rptledggrid.datfrom.Day & "-" & rptledggrid.datto.Year & "' and tblLedg.Date < '" & rptledggrid.datto.Month & "-" & rptledggrid.datto.Day & "-" & rptledggrid.datfrom.Year & "' group By Month(Date),Year(Date)"
                MsgBox(sql)
            End If
            Dim da As New SqlDataAdapter(sql, cn)
            da.Fill(ds)
            ACName = frmzoom4.ACName
            frmzoom4.Hide()
            dg1.Columns.Add("Month", "Month")
            dg1.DataSource = ds.Tables(0)
            Dim i As Integer
            For i = 0 To dg1.Rows.Count - 1
                If dg1.Item(1, i).Value = "1" Then
                    dg1.Item(0, i).Value = "January"
                ElseIf dg1.Item(1, i).Value = "2" Then
                    dg1.Item(0, i).Value = "Febuary"
                ElseIf dg1.Item(1, i).Value = "3" Then
                    dg1.Item(0, i).Value = "March"
                ElseIf dg1.Item(1, i).Value = "4" Then
                    dg1.Item(0, i).Value = "April"
                ElseIf dg1.Item(1, i).Value = "5" Then
                    dg1.Item(0, i).Value = "May"
                ElseIf dg1.Item(1, i).Value = "6" Then
                    dg1.Item(0, i).Value = "June"
                ElseIf dg1.Item(1, i).Value = "7" Then
                    dg1.Item(0, i).Value = "July"
                ElseIf dg1.Item(1, i).Value = "8" Then
                    dg1.Item(0, i).Value = "Augest"
                ElseIf dg1.Item(1, i).Value = "9" Then
                    dg1.Item(0, i).Value = "September"
                ElseIf dg1.Item(1, i).Value = "10" Then
                    dg1.Item(0, i).Value = "October"
                ElseIf dg1.Item(1, i).Value = "11" Then
                    dg1.Item(0, i).Value = "November"
                ElseIf dg1.Item(1, i).Value = "12" Then
                    dg1.Item(0, i).Value = "December"
                End If
            Next
            dg1.Columns.RemoveAt(1)
            dg1.Columns.Add("col5", "")
            Dim j As Integer
            For j = 0 To dg1.Rows.Count - 1
                If dg1.Item(4, j).Value < 0 Then
                    dg1.Item(4, j).Value = dg1.Item(4, j).Value * -1
                    dg1.Item(5, j).Value = "DR"
                End If
            Next
            Try
                If frmzoom7.month.Trim.Length <> 0 Then
                    Dim k As Integer
                    For k = 0 To dg1.Rows.Count - 1
                        If dg1.Item(0, k).Value = frmzoom7.month Then
                            dg1.Item(0, k).Selected = True
                            frmzoom7.Close()
                            GoTo en
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try



        Catch ex As Exception
        End Try
en:
    End Sub
    Private Sub dg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "January" Then
                month = 1
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "Febuary" Then
                month = 2
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "March" Then
                month = 3
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "April" Then
                month = 4
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "May" Then
                month = 5
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "June" Then
                month = 6
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "July" Then
                month = 7
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "Augest" Then
                month = 8
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "September" Then
                month = 9
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "October" Then
                month = 10
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "November" Then
                month = 11
            ElseIf dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value = "December" Then
                month = 12
            End If
            Me.Hide()
            frmzoom7.Show()
        ElseIf e.KeyCode = Keys.Escape Then
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            ' connect()
            ' cmd = New SqlCommand("Select * from tblAccount where ACName='" & DG1.Item(2, 0).Value & "'", cn)
            'dr = cmd.ExecuteReader
            'While dr.Read
            ' End While
            '   dr.Close()
            '  close1()
            Me.Hide()
            frmzoom4.Close()
            frmzoom4.Show()
        End If
    End Sub
End Class