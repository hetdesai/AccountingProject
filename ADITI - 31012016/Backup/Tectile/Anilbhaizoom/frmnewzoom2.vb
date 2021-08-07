Imports System.Data.SqlClient
Public Class frmnewzoom2
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim sql As String
    Public acname As String
    Dim check As Integer = 0
    Public a As String
    Public zoomdata As New DataSet2
    Private Sub frmnewzoom2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        Label4.Text = frmnewzoom1.mhead
        sql = "  Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & frmnewzoom1.mhead & "' group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            If dr.Item("Balance") < 0 Then
                Label6.Text = dr.Item("Balance") * -1
                Label5.Text = "0.00"
            ElseIf dr.Item("Balance") > 0 Then
                Label5.Text = dr.Item("Balance")
                Label6.Text = "0.00"
            Else
            End If
        End While
        dr.Close()
        sql = "Select tblAccount.ACName,tblAccount.ACCode,Sum(Dr) as DR,Sum(Cr) as CR,Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblMH.Mhead='" & frmnewzoom1.mhead & "' group by tblAccount.ACName,tblAccount.ACCode"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        Dim i As Integer = 0
        While dr.Read
            DG1.Rows.Add()
            DG1.Item(0, i).Value = dr.Item(0)
            If dr.Item("Balance") < 0 Then
                DG1.Item(2, i).Value = (dr.Item("Balance") * -1)
                DG1.Item(3, i).Value = "0.00"
            ElseIf dr.Item("Balance") > 0 Then
                DG1.Item(3, i).Value = (dr.Item("Balance"))
                DG1.Item(2, i).Value = "0.00"
            Else
                DG1.Item(2, i).Value = "0.00"
                DG1.Item(3, i).Value = "0.00"
            End If
            i = i + 1
        End While
        dr.Close()
        For i = 0 To DG1.Rows.Count - 1
            connect()
            cmd = New SqlCommand("Select * from tblLedg where ACName='" & DG1.Item(0, i).Value & "' and Book='OPBAL'", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = False Then
                dr.Close()
                DG1.Item(1, i).Value = "0.00"
            Else
                While dr.Read
                    If dr.Item("DR") > 0 Then
                        DG1.Item(1, i).Value = Format(dr.Item("DR"), "0.00") & "DR"
                    Else
                        DG1.Item(1, i).Value = Format(dr.Item("CR"), "0.00") & "CR"
                    End If
                End While
                dr.Close()
            End If
            dr.Close()
            close1()
        Next
        If frmnewZoom3.b <> "" Then
            Dim k As Integer
            For k = 0 To DG1.RowCount - 1
                Try
                    If DG1.Item(0, k).Value.ToString.Trim = frmnewZoom3.b Then
                        DG1.Item(0, k).Selected = True
                        End If
                Catch ex As Exception
                End Try
            Next

        End If
        frmnewZoom3.Close()
en:

        Dim mycol As New DataGridViewCheckBoxColumn
        mycol.HeaderText = " "
        mycol.Name = "Check1"
        DG1.Columns.Add(mycol)
        DG1.Item(DG1.Columns.Count - 1, 0).Selected = True
        For k = 0 To DG1.Columns.Count - 2
            DG1.Columns(k).ReadOnly = True
        Next
        connect()
        For k = 0 To DG1.Rows.Count - 1
            cmd = New SqlCommand("Select * from tblCheckacname where ACNAme='" & DG1.Item(0, k).Value & "'", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                DG1.Rows(k).DefaultCellStyle.ForeColor = Color.Red
                DG1.Rows(k).DefaultCellStyle.SelectionForeColor = Color.Red
                DG1.Item(DG1.Columns.Count - 1, k).Value = True
                dr.Close()
            Else
                dr.Close()
            End If
        Next
        If frmnewzoom1.seachacname <> "" Then
            Dim k As Integer
            For k = 0 To DG1.Rows.Count - 1
                If frmnewzoom1.seachacname = DG1.Item(0, k).Value Then
                    DG1.Item(0, k).Selected = True
                    GoTo en1
                End If
            Next
        End If
en1:
        Dim k2 As Integer
        For k2 = 0 To DG1.Rows.Count - 1
            DG1.Rows(k2).Height = 25
        Next
        countbal()
        close1()
        check = 1
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEnter
        If check = 1 Then
            connect()
            Dim dr1 As SqlDataReader
            cmd = New SqlCommand("Select * from tblAccount where ACName='" & DG1.Item(0, e.RowIndex).Value & "'", cn)
            dr1 = cmd.ExecuteReader
            While dr1.Read
                Label8.Text = dr1.Item("Add1")
                Label9.Text = dr1.Item("Add2")
                Label10.Text = dr1.Item("Place")
                Label11.Text = dr1.Item("State")
            End While
            dr.Close()
            close1()
        End If
    End Sub

    Private Sub DG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        If e.KeyCode = Keys.Enter Then
            acname = DG1.Item(0, DG1.CurrentCell.RowIndex).Value
            Me.Hide()
            frmnewZoom3.Show()
        ElseIf e.KeyCode = Keys.Escape Then
            a = Label4.Text
            frmnewzoom1.Close()
            frmnewzoom1.Show()
        ElseIf e.KeyCode = Keys.Space Then
            If DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = True Then
                DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = False
                connect()
                cmd = New SqlCommand("Delete from tblcheckacname where ACName='" & DG1.Item(0, DG1.CurrentCell.RowIndex).Value & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
            Else
                DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = True
                connect()
                cmd = New SqlCommand("Insert into tblcheckACNAme values('" & DG1.Item(0, DG1.CurrentCell.RowIndex).Value & "')", cn)
                cmd.ExecuteNonQuery()
                close1()
            End If

            If DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = True Then
                DG1.Rows(DG1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                DG1.Rows(DG1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = DG1.DefaultCellStyle.ForeColor
            End If
            If DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = True Then
                DG1.Rows(DG1.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Red
            Else
                DG1.Rows(DG1.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
            End If
            countbal()
        End If
    End Sub

    Private Sub DG1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.RowEnter
        Try
            If e.RowIndex <> -1 Then
                If DG1.Item(DG1.Columns.Count - 1, e.RowIndex).Value = True Then
                    DG1.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Red
                Else
                    DG1.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
                End If

            End If
        Catch ex As Exception
            '    MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub countbal()
        Label13.Text = "0.00"
        Label14.Text = "0.00"
        Dim bal As Decimal
        Dim bal1 As Decimal
        Dim k As Integer
        For k = 0 To DG1.Rows.Count - 1
            If DG1.Item(DG1.Columns.Count - 1, k).Value = True Then
                bal1 = bal1 + Val(DG1.Item(3, k).Value)
                bal = bal + Val(DG1.Item(2, k).Value)
            End If
        Next

        Label13.Text = Format(bal, "0.00")
        Label14.Text = Format(bal1, "0.00")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim k As Integer
            For k = 0 To DG1.Rows.Count - 1
                If DG1.Item(0, k).Value.ToString.ToUpper.StartsWith(TextBox1.Text.ToUpper) Then
                    DG1.Item(0, k).Selected = True
                    DG1.Focus()
                    GoTo en
                End If
            Next
        End If
en:

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim i As Integer
            For i = 0 To DG1.RowCount - 1
                Dim dt As DataRow = zoomdata.Tables("zoom2").NewRow
                dt.Item(0) = DG1.Item(0, i).Value
                Dim bal As Decimal = 0.0
                If DG1.Item(1, i).Value.ToString.EndsWith("DR") Then
                    dt.Item(1) = -Val(DG1.Item(1, i).Value.ToString.Substring(0, DG1.Item(1, i).Value.ToString.Length - 2))
                ElseIf DG1.Item(1, i).Value.ToString.EndsWith("CR") Then
                    dt.Item(1) = Val(DG1.Item(1, i).Value.ToString.Substring(0, DG1.Item(1, i).Value.ToString.Length - 2))
                Else
                    dt.Item(1) = 0.0
                End If

                dt.Item(2) = DG1.Item(2, i).Value
                dt.Item(3) = DG1.Item(3, i).Value
                dt.Item(4) = DG1.Item(3, i).Value - DG1.Item(2, i).Value + dt.Item(1)
                zoomdata.Tables("zoom2").Rows.Add(dt)
            Next
            zoomprint = 2
            frmprintzoom.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class