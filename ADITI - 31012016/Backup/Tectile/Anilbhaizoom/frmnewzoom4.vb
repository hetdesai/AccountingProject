Imports System.Data.SqlClient
Public Class frmnewzoom4
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim ds As New DataSet
    Public zoom1 As Boolean = False
    Public book As String
    Public VrNo As String
    Public month As Integer
    Public ds1 As New DataSet2
    Private Sub frmnewzoom4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            frmnewZoom3.Close()
            frmnewZoom3.Show()
        End If
    End Sub
    Private Sub frmnewzoom4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Label4.Text = frmnewZoom3.Label4.Text
            Label5.Text = frmnewZoom3.Label5.Text
            month = frmnewZoom3.month
            connect()
            Dim j As Integer
            If frmnewZoom3.month = 13 Then
                Label7.Text = frmnewZoom3.Label7.Text
                Label10.Text = "ALL"
                j = 13
            ElseIf frmnewZoom3.month = 1 Then
                Label7.Text = frmnewZoom3.Label7.Text
                Label10.Text = "APRIL"
                j = 4
            ElseIf frmnewZoom3.month = 2 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 0).Value
                Label10.Text = "MAY"
                j = 5
            ElseIf frmnewZoom3.month = 3 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 1).Value
                Label10.Text = "JUNE"
                j = 6
            ElseIf frmnewZoom3.month = 4 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 2).Value
                Label10.Text = "JULY"
                j = 7
            ElseIf frmnewZoom3.month = 5 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 3).Value
                Label10.Text = "AUGUST"
                j = 8
            ElseIf frmnewZoom3.month = 6 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 4).Value
                Label10.Text = "SEPTEMBER"
                j = 9
            ElseIf frmnewZoom3.month = 7 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 5).Value
                Label10.Text = "OCTOBER"
                j = 10
            ElseIf frmnewZoom3.month = 8 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 6).Value
                Label10.Text = "NOVEMBER"
                j = 11
            ElseIf frmnewZoom3.month = 9 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 7).Value
                Label10.Text = "DECEMBER"
                j = 12
            ElseIf frmnewZoom3.month = 10 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 8).Value
                Label10.Text = "JANUARY"
                j = 1
            ElseIf frmnewZoom3.month = 11 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 9).Value
                Label10.Text = "FEBRUARY"
                j = 2
            ElseIf frmnewZoom3.month = 12 Then
                Label7.Text = frmnewZoom3.DG1.Item(3, 10).Value
                Label10.Text = "MARCH"
                j = 3
            End If
            If j <> 13 Then
                da = New SqlDataAdapter("Select CONVERT(varchar,tblLedg.Date,105) 'dd/mm/yyyy',tblLedg.VrNo,tblLedg.Book,tblLedg.OPName,tblLedg.Ref,tblLedg.Dr,tblLedg.Cr  from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblLedg.ACName='" & frmnewzoom2.acname & "' and Month(Date)=" & j & " order by tblLedg.date", cn)
            Else
                da = New SqlDataAdapter("Select CONVERT(varchar,tblLedg.Date,105) 'dd/mm/yyyy',tblLedg.VrNo,tblLedg.Book,tblLedg.OPName,tblLedg.Ref,tblLedg.Dr,tblLedg.Cr  from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblLedg.ACName='" & frmnewzoom2.acname & "' order by tblLedg.date", cn)
            End If
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            DG1.Columns(0).HeaderText = "Date"
            DG1.Columns(3).Width = 250
            DG1.Columns.Add("Balance", "Balance")
            DG1.Columns(DG1.ColumnCount - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Dim k As Integer
            For k = 0 To DG1.Rows.Count - 1
                DG1.Item(7, k).Value = calbal(k + 1)
            Next
            If DG1.Rows.Count = 0 Then
            Else
                Label9.Text = DG1.Item(7, DG1.Rows.Count - 1).Value
            End If
            Dim mycol As New DataGridViewCheckBoxColumn
            mycol.HeaderText = " "
            mycol.Name = "Check1"
            DG1.Columns.Add(mycol)
            DG1.Item(DG1.Columns.Count - 1, 0).Selected = True
            For k = 0 To DG1.Columns.Count - 2
                DG1.Columns(k).ReadOnly = True
            Next
            connect()
            k = 0
            For k = 0 To DG1.Rows.Count - 1
                cmd = New SqlCommand("Select * from tblbillCheck where Book='" & DG1.Item(2, k).Value.ToString & "' and VrNo='" & DG1.Item(1, k).Value.ToString & "'", cn)
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
            countbal()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function calbal(ByVal count As Integer) As String
        Dim bal As Decimal = 0
        Dim loop1 As Integer = 0
        For loop1 = 0 To count - 1
            bal = Val(DG1.Item(6, loop1).Value) - Val(DG1.Item(5, loop1).Value) + bal
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

    Private Sub DG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value = "Purchase" Then
                book = "Purchase"
                VrNo = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                zoom1 = True
                Form3.Show()
                Me.Hide()
            End If
            If DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value = "BANK" Then
                book = "Bank"
                VrNo = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim Namecr As String
                connect()
                cmd = New SqlCommand("Select * from tblBank where VrNo='" & VrNo & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Namecr = dr.Item("NameCr")
                    MsgBox(Namecr)
                End While
                dr.Close()
                cmd = New SqlCommand("Select * from tblAccount where ACName='" & Namecr & "' and Book='Bank'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    zoom1 = True
                    frmBank.Show()
                Else
                    zoom1 = True
                    frmBankRecipt.Show()
                End If
                close1()
                '   frmBank.Show()
                Me.Hide()
            End If
            If DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value = "Sales" Then
                book = "Sales"
                zoom1 = True
                VrNo = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                frmSale.Show()
                Me.Hide()
            End If
            If DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value = "Jour" Then
                book = "Jour"
                zoom1 = True
                VrNo = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                frmJour.Show()
                Me.Hide()
            End If
            If DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value = "OPBAL" Then
                book = "OPBAL"
                zoom1 = True
                VrNo = DG1.Item(1, DG1.SelectedCells.Item(0).RowIndex).Value
                frmOpeningMaster.Show()
                Me.Hide()
            End If
        ElseIf e.KeyCode = Keys.Space Then
            If DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = True Then
                DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = False
                connect()
                cmd = New SqlCommand("Delete from tblbillcheck where VrNo='" & DG1.Item(1, DG1.CurrentCell.RowIndex).Value & "' and book='" & DG1.Item(2, DG1.CurrentCell.RowIndex).Value & "'", cn)
                cmd.ExecuteNonQuery()
                close1()
            Else
                DG1.Item(DG1.Columns.Count - 1, DG1.CurrentCell.RowIndex).Value = True
                connect()
                cmd = New SqlCommand("Insert into tblbillcheck values('" & DG1.Item(2, DG1.CurrentCell.RowIndex).Value & "','" & DG1.Item(1, DG1.CurrentCell.RowIndex).Value & "')", cn)
                cmd.ExecuteNonQuery()
                MsgBox("a")
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
    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub
    Private Sub countbal()
        Label13.Text = "0.00"
        Label3.Text = "0.00"
        Dim bal As Decimal
        Dim bal1 As Decimal
        Dim k As Integer
        For k = 0 To DG1.Rows.Count - 1
            If DG1.Item(DG1.Columns.Count - 1, k).Value = True Then
                bal1 = bal1 + Val(DG1.Item(6, k).Value)
                bal = bal + Val(DG1.Item(5, k).Value)
            End If
        Next

        Label13.Text = Format(bal, "0.00")

        Label3.Text = Format(bal1, "0.00")

         End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer
            For i = 0 To DG1.RowCount - 1
                Dim dt As DataRow = ds1.Tables("zoom4").NewRow
                dt.Item(0) = DG1.Item(0, i).Value
                dt.Item(1) = DG1.Item(1, i).Value
                dt.Item(2) = DG1.Item(2, i).Value
                dt.Item(3) = DG1.Item(3, i).Value
                dt.Item(4) = DG1.Item(4, i).Value
                dt.Item(5) = DG1.Item(5, i).Value
                dt.Item(6) = DG1.Item(6, i).Value
                dt.Item(7) = DG1.Item(7, i).Value
                ds1.Tables("zoom4").Rows.Add(dt)
            Next
            zoomprint = 4
            frmprintzoom.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class