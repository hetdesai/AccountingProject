Imports System.Data.SqlClient
Public Class frmnewZoom3
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader '
    Public b As String
    Public month As Integer
    Public ds As New DataSet2
    Private Sub frmnewZoom3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As Integer = 0
            Label4.Text = frmnewzoom1.mhead
            Label5.Text = frmnewzoom2.acname
            connect()
            cmd = New SqlCommand("Select * from tblLedg where Acname='" & frmnewzoom2.acname & "' and Book='OPBAL'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                If dr.Item("DR") > 0 Then
                    Label7.Text = Convert.ToDecimal(dr.Item("DR")) & "DB"
                Else
                    Label7.Text = Convert.ToDecimal(dr.Item("CR"))
                End If
            End While
            dr.Close()
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "April"
            DG1.Item(1, i).Value = countDr(4)
            DG1.Item(2, i).Value = countCr(4)
            DG1.Item(3, i).Value = calbal(1)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "May"
            DG1.Item(1, i).Value = countDr(5)
            DG1.Item(2, i).Value = countCr(5)
            DG1.Item(3, i).Value = calbal(2)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "June"
            DG1.Item(1, i).Value = countDr(6)
            DG1.Item(2, i).Value = countCr(6)
            DG1.Item(3, i).Value = calbal(3)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "July"
            DG1.Item(1, i).Value = countDr(7)
            DG1.Item(2, i).Value = countCr(7)
            DG1.Item(3, i).Value = calbal(4)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "Augest"
            DG1.Item(1, i).Value = countDr(8)
            DG1.Item(2, i).Value = countCr(8)
            DG1.Item(3, i).Value = calbal(5)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "Sepetmber"
            DG1.Item(1, i).Value = countDr(9)
            DG1.Item(2, i).Value = countCr(9)
            DG1.Item(3, i).Value = calbal(6)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "October"
            DG1.Item(1, i).Value = countDr(10)
            DG1.Item(2, i).Value = countCr(10)
            DG1.Item(3, i).Value = calbal(7)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "November"
            DG1.Item(1, i).Value = countDr(11)
            DG1.Item(2, i).Value = countCr(11)
            DG1.Item(3, i).Value = calbal(8)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "December"
            DG1.Item(1, i).Value = countDr(12)
            DG1.Item(2, i).Value = countCr(12)
            DG1.Item(3, i).Value = calbal(9)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "January"
            DG1.Item(1, i).Value = countDr(1)
            DG1.Item(2, i).Value = countCr(1)
            DG1.Item(3, i).Value = calbal(10)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "February"
            DG1.Item(1, i).Value = countDr(2)
            DG1.Item(2, i).Value = countCr(2)
            DG1.Item(3, i).Value = calbal(11)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "March"
            DG1.Item(1, i).Value = countDr(3)
            DG1.Item(2, i).Value = countCr(3)
            DG1.Item(3, i).Value = calbal(12)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "TOTAL"
            DG1.Item(1, i).Value = caldr()
            DG1.Item(2, i).Value = calcr()
            Label9.Text = DG1.Item(3, 11).Value
            Dim k As Integer
            For k = 0 To DG1.Rows.Count - 1
                If DG1.Item(1, k).Value = "0.00" And DG1.Item(2, k).Value = "0.00" Then
                    DG1.Rows(k).DefaultCellStyle.ForeColor = Color.DarkBlue
                    DG1.Rows(k).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                End If
            Next
            'MsgBox(frmnewzoom4.month)
            If frmnewzoom4.month <> 0 Then
                DG1.Item(0, frmnewzoom4.month - 1).Selected = True
            Else
                DG1.Item(0, 12).Selected = True
            End If
            frmnewzoom4.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function countDr(ByVal month As Integer) As String
        connect()
        cmd = New SqlCommand("Select SUm(DR) from tblLedg where Acname='" & frmnewzoom2.acname & "' and Month(Date)=" & month & "Group By ACNAme,Month(Date)", cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                Return Format(dr.Item(0), "0.00")
            End While
            dr.Close()
        End If
        close1()
    End Function
    Private Function countCr(ByVal month As Integer) As String
        connect()
        cmd = New SqlCommand("Select SUm(CR) from tblLedg where Acname='" & frmnewzoom2.acname & "' and Month(Date)=" & month & " Group By ACNAme,Month(Date)", cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                Return Format(dr.Item(0), "0.00")
            End While
            dr.Close()
        End If
        close1()
    End Function
    Private Function calbal(ByVal count As Integer) As String
        Dim bal As Decimal = 0
        Dim loop1 As Integer = 0
        For loop1 = 0 To count - 1
            bal = Val(DG1.Item(2, loop1).Value) - Val(DG1.Item(1, loop1).Value) + bal
        Next
        If Label7.Text.EndsWith("DB") Then
            bal = bal - Val(Label7.Text.Substring(0, Label7.Text.Length - 2))
        Else
            bal = bal + Val(Label7.Text)
        End If
        If bal > 0 Then
            Return Format(bal, "0.00")
        ElseIf bal < 0 Then
            Return (Val(bal) * -1).ToString & "DB"
        Else
            Return "0.00"
        End If
    End Function
    Private Function calcr() As Decimal
        Dim j As Integer
        Dim bal As Decimal = 0
        For j = 0 To 11
            bal = bal + Val(DG1.Item(2, j).Value)
        Next
        Return Format(bal, "0.00")
    End Function
    Private Function caldr() As Decimal
        Dim j As Integer
        Dim bal As Decimal = 0
        For j = 0 To 11
            bal = bal + Val(DG1.Item(1, j).Value)
        Next
        Return Format(bal, "0.00")
    End Function

    Private Sub DG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        If e.KeyCode = Keys.Escape Then
            b = frmnewzoom2.acname
            frmnewzoom2.Close()
            frmnewzoom2.Show()
        ElseIf e.KeyCode = Keys.Enter Then
            month = DG1.CurrentCell.RowIndex + 1
            Me.Hide()
            frmnewzoom4.Show()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer
            For i = 0 To DG1.RowCount - 2
                Dim dt As DataRow = ds.Tables("zoom3").NewRow
                dt.Item(0) = DG1.Item(0, i).Value
                dt.Item(1) = DG1.Item(1, i).Value
                dt.Item(2) = DG1.Item(2, i).Value
                '  MsgBox(DG1.Item(3, i).Value)
                If DG1.Item(3, i).Value.ToString.EndsWith("DB") = True Then
                    dt.Item(3) = Val(DG1.Item(3, i).Value.ToString.Substring(0, DG1.Item(3, i).Value.ToString.Length - 2)) * -1
                Else
                    dt.Item(3) = DG1.Item(3, i).Value
                End If
                ds.Tables("zoom3").Rows.Add(dt)
            Next
            zoomprint = 3
            frmprintzoom.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class