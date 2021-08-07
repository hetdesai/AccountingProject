Imports System.Data.SqlClient
Public Class frmnewzoom1
    Public mhead As String
    Public seachacname As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = dateyf
        dateyl1.Text = dateyl
        Try
            Dim clStock As Decimal
            Try
en1:            clStock = InputBox("Closing Stock", "Closing Stock", "0.00")
            Catch ex As Exception
                MsgBox("Enter proper value")
                GoTo en1
            End Try
            DG1.Columns(0).ReadOnly = True
            DG1.Columns(1).ReadOnly = True
            DG1.Columns(3).ReadOnly = True
            Dim sql As String
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim mhead As String
            Dim i As Integer
            i = 0
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "Liabilities"
            DG1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DG1.Item(0, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
            DG1.Item(0, i).Style.ForeColor = Color.Blue
            DG1.Item(2, i).Value = "Amount"
            DG1.Item(2, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DG1.Item(2, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
            DG1.Item(2, i).Style.ForeColor = Color.Blue
            DG1.Item(3, i).Value = "Assets"
            DG1.Item(3, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DG1.Item(3, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
            DG1.Item(3, i).Style.ForeColor = Color.Blue
            DG1.Item(5, i).Value = "Amount"
            DG1.Item(5, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DG1.Item(5, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
            DG1.Item(5, i).Style.ForeColor = Color.Blue
            DG1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
            DG1.AutoResizeRow(0)
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "Capital"
            DG1.Item(1, i).Value = "A"
            DG1.Item(2, i).Value = mysub("Capital")
            DG1.Item(3, i).Value = "Fixed Assets"
            DG1.Item(4, i).Value = "H"
            DG1.Item(5, i).Value = mysub3("Fixed Assets")
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "Reserves & Surplus"
            DG1.Item(1, i).Value = "B"
            DG1.Item(2, i).Value = mysub("Reserves & Surplus")
            DG1.Item(3, i).Value = "Investments"
            DG1.Item(4, i).Value = "I"
            DG1.Item(5, i).Value = mysub3("Investments")
            i = i + 1
            DG1.Rows.Add()
            DG1.Item(0, i).Value = "Secured Loans"
            DG1.Item(1, i).Value = "C"
            DG1.Item(2, i).Value = mysub("Secured Loans")
            DG1.Item(3, i).Value = "Current Assets"
            DG1.Item(3, i).Style.ForeColor = Color.Firebrick
            DG1.Item(3, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
            With DG1
                i = i + 1
                DG1.Rows.Add()
                DG1.Item(0, i).Value = "Unecured Loans"
                DG1.Item(1, i).Value = "D"
                DG1.Item(2, i).Value = mysub("Unsecured Loans")
                DG1.Item(3, i).Value = "     Stock In Trade"
                DG1.Item(4, i).Value = "J"
                DG1.Item(5, i).Value = mysub3("Stock In Trade")
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "Current Liabilities"
                .Item(0, i).Style.ForeColor = Color.Firebrick
                .Item(0, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                .Item(3, i).Value = "     Sundry Debtors"
                .Item(4, i).Value = "K"
                DG1.Item(5, i).Value = mysub3("Sundry Debtors")
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "     Sundry Creditors"
                .Item(1, i).Value = "E"
                DG1.Item(2, i).Value = mysub("Sundry Creditors")
                .Item(3, i).Value = "     Loans & Advances"
                .Item(4, i).Value = "L"
                'problem of & may occur
                DG1.Item(5, i).Value = mysub3("Loans & Advances")
                'problem
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "     Provisions"
                .Item(1, i).Value = "F"
                DG1.Item(2, i).Value = mysub("Provisions")
                .Item(3, i).Value = "     Cash On Hand"
                .Item(4, i).Value = "M"
                DG1.Item(5, i).Value = mysub3("Cash On Hand")
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "     Other Liabilities"
                .Item(1, i).Value = "G"
                DG1.Item(2, i).Value = mysub("Other Liabilities")
                .Item(3, i).Value = "     Cash At Bank"
                .Item(4, i).Value = "N"
                DG1.Item(5, i).Value = mysub3("Cash At Bank")
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "Trial Balance Difference"
                .Item(0, i).Style.ForeColor = Color.Red
                .Item(1, i).Value = "Z"
                .Item(2, i).Value = "-"
                .Item(3, i).Value = "Other Assets"
                .Item(4, i).Value = "O"
                DG1.Item(5, i).Value = mysub3("Other Assets")
                i = i + 1
                .Rows.Add()
                .Item(1, i).Value = "Rs."
                .Item(4, i).Value = "Rs."
                DG1.Item(2, i).Value = mysub2("Liabilities")
                .Item(2, i).Style.ForeColor = Color.DarkMagenta
                .Item(2, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                DG1.Item(5, i).Value = mysub4("Assets")
                .Item(5, i).Style.ForeColor = Color.DarkMagenta
                .Item(5, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "----------------------------------------------------------"
                .Item(1, i).Value = "----"
                .Item(2, i).Value = "-------------------------"
                .Item(3, i).Value = "----------------------------------------------------------"
                .Item(4, i).Value = "----"
                .Item(5, i).Value = "-------------------------"
                .Rows(i).DefaultCellStyle.ForeColor = Color.DarkRed
                .Rows(i).DefaultCellStyle.Font = New Font("Arial", 15, FontStyle.Bold)
                i = i + 1
                DG1.Rows.Add()
                DG1.Item(0, i).Value = "Expenditure"
                DG1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DG1.Item(0, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                DG1.Item(0, i).Style.ForeColor = Color.Blue
                DG1.Item(2, i).Value = "Amount"
                DG1.Item(2, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DG1.Item(2, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                DG1.Item(2, i).Style.ForeColor = Color.Blue
                DG1.Item(3, i).Value = "Income"
                DG1.Item(3, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DG1.Item(3, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                DG1.Item(3, i).Style.ForeColor = Color.Blue
                DG1.Item(5, i).Value = "Amount"
                DG1.Item(5, i).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DG1.Item(5, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                DG1.Item(5, i).Style.ForeColor = Color.Blue
                DG1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                DG1.AutoResizeRow(0)
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "Opening Stock"
                .Item(1, i).Value = "P"
                .Item(2, i).Value = "-"
                .Item(3, i).Value = "Sales"
                .Item(4, i).Value = "S"
                DG1.Item(5, i).Value = mysub("Sales")
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "Purchases"
                .Item(1, i).Value = "P"
                DG1.Item(2, i).Value = mysub3("Purchases")
                .Item(3, i).Value = "Closing Stock"
                .Item(3, i).Style.ForeColor = Color.Brown
                .Item(4, i).Style.ForeColor = Color.Brown
                .Item(5, i).Style.ForeColor = Color.Brown
                .Item(4, i).Value = "V"
                .Item(5, i).Value = "-"
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "Trading Expences"
                .Item(1, i).Value = "U"
                DG1.Item(2, i).Value = mysub3("Trading Expenses")
                .Item(3, i).Value = "Trading Incomes"
                .Item(4, i).Value = "V"
                DG1.Item(5, i).Value = mysub("Trading Incomes")
                i = i + 1
                .Rows.Add()
                .Item(0, i).Value = "P & L Expences"
                .Item(1, i).Value = "X"
                DG1.Item(2, i).Value = mysub3("P & L Expences")
                .Item(3, i).Value = "P & L Income"
                .Item(4, i).Value = "Y"
                DG1.Item(5, i).Value = mysub("P & L Income")
                i = i + 1
                connect()
                Dim exp As Decimal
                Dim inc As Decimal
                cmd = New SqlCommand("Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.ASD='" & "Expenditure" & "' group by tblMh.ASD order by tblMH.ASD", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    exp = dr.Item("Balance") * -1
                End While
                dr.Close()
                cmd = New SqlCommand("Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.ASD='" & "Income" & "' group by tblMh.ASD order by tblMH.ASD", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    inc = dr.Item("Balance")
                End While
                dr.Close()
                close1()
                If inc > exp Then
                    .Rows.Add()
                    .Item(0, i).Value = "Net Profit"
                    .Item(1, i).Value = ""
                    .Item(2, i).Value = Format((inc - exp), "0.00")
                    .Item(3, i).Value = ""
                    .Item(4, i).Value = ""
                    .Item(5, i).Value = ""
                    .Item(2, 2).Value = Format((inc - exp), "0.00")
                    .Item(2, 10).Value = Format((Val(.Item(2, 10).Value) + Val(.Item(2, 2).Value)), "0.00")
                    i = i + 1
                ElseIf inc < exp Then
                    .Rows.Add()
                    .Item(0, i).Value = ""
                    .Item(1, i).Value = ""
                    .Item(2, i).Value = ""
                    .Item(3, i).Value = "Net Loss"
                    .Item(4, i).Value = ""
                    .Item(5, i).Value = Format((exp - inc), "0.00")
                    .Item(2, 2).Value = Format((inc - exp), "0.00")
                    .Item(2, 10).Value = Format((Val(.Item(2, 10).Value) + Val(.Item(2, 2).Value)), "0.00")

                    i = i + 1
                End If
                .Rows.Add()
                .Item(0, i).Value = ""
                .Item(1, i).Value = "Rs."
                DG1.Item(2, i).Value = mysub4("Expenditure")
                .Item(3, i).Value = ""
                .Item(4, i).Value = "Rs."
                DG1.Item(5, i).Value = mysub2("Income")
                .Item(2, i).Style.ForeColor = Color.DarkMagenta
                .Item(2, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                .Item(5, i).Style.ForeColor = Color.DarkMagenta
                .Item(5, i).Style.Font = New Font("Arial", 15, FontStyle.Bold)
                i = i + 1
                If exp > inc Then
                    .Item(5, 18).Value = Format((Val(.Item(5, 18).Value) + Val(.Item(2, 2).Value) * -1), "0.00")
                Else
                    .Item(2, 18).Value = Format(Convert.ToDecimal(Val(.Item(2, 18).Value) + Val(.Item(2, 2).Value)), "0.00")
                End If
                DG1.Item(2, 1).Selected = True
                If clStock <> 0 Then
                    DG1.Item(5, 14).Value = Format(clStock, "0.00")
                    DG1.Item(5, 4).Value = Format(clStock, "0.00")
                    DG1.Item(5, 18).Value = Format(Val(DG1.Item(5, 18).Value) + clStock, "0.00")
                    DG1.Item(5, 10).Value = Format(Val(DG1.Item(5, 10).Value) + clStock, "0.00")
                    If Val(DG1.Item(2, 17).Value) > 0 Then
                        DG1.Item(2, 17).Value = Format(Val(DG1.Item(2, 17).Value) + clStock, "0.00")
                        DG1.Item(2, 18).Value = Format(Val(DG1.Item(2, 18).Value) + clStock, "0.00")
                        DG1.Item(2, 2).Value = Format(Val(DG1.Item(2, 2).Value) + clStock, "0.00")
                        DG1.Item(2, 10).Value = Format(Val(DG1.Item(2, 10).Value) + clStock, "0.00")
                        GoTo en2
                    End If
                    If Val(.Item(5, 18).Value) - Val((.Item(5, 17).Value)) > Val(.Item(2, 18).Value) - Val((.Item(2, 17).Value)) Then
                        Dim rs As Decimal
                        rs = .Item(2, 2).Value
                        .Item(5, 18).Value = Format(Val(.Item(5, 18).Value) - Val(.Item(5, 17).Value), "0.00")
                        .Item(5, 17).Value = ""
                        .Item(3, 17).Value = ""
                        .Item(0, 17).Value = "Net Profit"
                        .Item(2, 18).Value = Format(Val(.Item(2, 18).Value) + Val(.Item(2, 17).Value), "0.00")
                        .Item(2, 17).Value = (Val(.Item(5, 18).Value) - Val((.Item(5, 17).Value)) - (Val(.Item(2, 18).Value) - Val((.Item(2, 17).Value))))
                        .Item(2, 17).Value = Format(.Item(2, 17).Value, "0.00")
                        .Item(2, 2).Value = Format(.Item(2, 17).Value, "0.00")
                        .Item(2, 18).Value = Format(.Item(2, 18).Value + Val(.Item(2, 17).Value), "0.00")
                        .Item(2, 10).Value = Format((Val(.Item(2, 10).Value) + Val(.Item(2, 2).Value) - rs), "0.00")
                    ElseIf Val(.Item(5, 18).Value) - Val((.Item(5, 17).Value)) < Val(.Item(2, 18).Value) - Val((.Item(2, 17).Value)) Then
                        Dim rs As Decimal
                        rs = .Item(2, 2).Value
                        Dim val1 As Decimal
                        val1 = (Val(.Item(5, 18).Value) - Val((.Item(5, 17).Value)))
                        .Item(2, 17).Value = ""
                        .Item(0, 17).Value = ""
                        .Item(3, 17).Value = "Net Loss"
                        .Item(5, 17).Value = Format(Val(.Item(2, 18).Value) - Val((.Item(2, 17).Value)) - (Val(.Item(5, 18).Value) - Val((.Item(5, 17).Value))), "0.00")
                        .Item(5, 18).Value = Format(val1 + Val(.Item(5, 17).Value), "0.00")
                        .Item(2, 2).Value = Format(.Item(5, 17).Value * -1, "0.00")
                        .Item(2, 10).Value = (Val(.Item(2, 10).Value) + Val(.Item(2, 2).Value) - rs)
                        .Item(2, 10).Value = Format(.Item(2, 10).Value, "0.00")
                    End If
                End If
            End With

en2:
            If frmnewzoom2.a <> "" Then
                Dim k As Integer
                For k = 0 To DG1.RowCount - 1
                    Try
                        If DG1.Item(0, k).Value.ToString.Trim.ToUpper = frmnewzoom2.a.ToUpper Then
                            DG1.Item(2, k).Selected = True
                            frmnewzoom2.Close()
                            GoTo en
                        End If
                        If DG1.Item(3, k).Value.ToString.Trim.ToUpper = frmnewzoom2.a.ToUpper Then
                            DG1.Item(5, k).Selected = True
                            frmnewzoom2.Close()
                            GoTo en
                        End If

                    Catch ex As Exception

                    End Try
                Next

            End If
en:
            DG1.Rows(0).Height = 50
            DG1.Rows(12).Height = 50
            Dim k2 As Integer
            For k2 = 0 To DG1.Rows.Count - 1
                If k2 = 0 Or k2 = 12 Then
                Else
                    DG1.Rows(k2).Height = 30
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function mysub(ByVal mhead As String) As String
        connect()
        Dim sql As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        sql = "  Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                If dr.Item("Bal") > 0 Then
                    Return Convert.ToDecimal(dr.Item("Bal"))
                ElseIf dr.Item("Bal") < 0 Then
                    Return Convert.ToDecimal((Val(dr.Item("Bal"))))
                Else
                    Return "0.00"
                End If
            End While

            dr.Close()
        End If
        close1()

    End Function
    Private Function mysub3(ByVal mhead As String) As String
        connect()
        Dim sql As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        sql = "  Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                If dr.Item("Bal") < 0 Then
                    Return Format(Val(dr.Item("Bal")) * -1, "0.00")
                ElseIf dr.Item("Bal") > 0 Then
                    Return Convert.ToDecimal((dr.Item("Bal")) * -1)
                Else
                    Return "0.00"
                End If
            End While
            dr.Close()
        End If
        close1()

    End Function
    Private Function mysub2(ByVal asd As String) As String
        connect()
        Dim sql As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        sql = "  Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.ASD='" & asd & "' group by tblMh.ASD order by tblMH.ASD"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                If dr.Item("Bal") > 0 Then
                    Return Convert.ToDecimal(dr.Item("Bal"))
                ElseIf dr.Item("Bal") < 0 Then
                    Return Convert.ToDecimal((Val(dr.Item("Bal"))))
                Else
                    Return "0.00"
                End If

            End While
            dr.Close()
        End If
        close1()

    End Function
    Private Function mysub4(ByVal asd As String) As String
        connect()
        Dim sql As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        sql = "  Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.ASD='" & asd & "' group by tblMh.ASD order by tblMH.ASD"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                If dr.Item("Balance") < 0 Then
                    Return Format((Val(dr.Item("Balance")) * -1), "0.00")
                ElseIf dr.Item("Balance") > 0 Then
                    Return Format(Convert.ToDecimal((dr.Item("Balance"))) * -1, "0.00")
                Else
                    Return "0.00"
                End If
            End While
            dr.Close()
        End If
        close1()

    End Function
    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick
        Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellEnter
        If e.ColumnIndex < 3 And e.RowIndex <> 0 Then
            DG1.Item(0, e.RowIndex).Style.BackColor = DG1.DefaultCellStyle.SelectionBackColor
            DG1.Item(1, e.RowIndex).Style.BackColor = DG1.DefaultCellStyle.SelectionBackColor
        End If
        If e.ColumnIndex > 2 And e.RowIndex <> 0.0 Then
            DG1.Item(3, e.RowIndex).Style.BackColor = DG1.DefaultCellStyle.SelectionBackColor
            DG1.Item(4, e.RowIndex).Style.BackColor = DG1.DefaultCellStyle.SelectionBackColor
        End If
    End Sub

    Private Sub DG1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellLeave
        If e.ColumnIndex < 3 And e.RowIndex <> 0 Then
            DG1.Item(0, e.RowIndex).Style.BackColor = Color.White
            DG1.Item(1, e.RowIndex).Style.BackColor = Color.White
        End If
        If e.ColumnIndex > 2 And e.RowIndex <> 0 Then
            DG1.Item(3, e.RowIndex).Style.BackColor = Color.White
            DG1.Item(4, e.RowIndex).Style.BackColor = Color.White
        End If
    End Sub

    Private Sub DG1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellValidated
       
    End Sub

    Private Sub DG1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If DG1.CurrentCell.ColumnIndex < 3 Then
                    mhead = DG1.Item(0, DG1.CurrentCell.RowIndex).Value.ToString.Trim
                Else
                    mhead = DG1.Item(3, DG1.CurrentCell.RowIndex).Value.ToString.Trim
                End If
                Try
                    frmnewzoom2.Show()
                    Me.Hide()
                Catch ex As Exception

                End Try

            ElseIf e.KeyCode = Keys.Left Then
                If DG1.CurrentCell.ColumnIndex = 2 Then
                    e.Handled = True
                ElseIf DG1.CurrentCell.ColumnIndex = 5 And DG1.CurrentCell.RowIndex <> 5 Then
                    DG1.Item(2, DG1.CurrentCell.RowIndex).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.ColumnIndex = 5 And DG1.CurrentCell.RowIndex = 5 Then
                    DG1.Item(2, 4).Selected = True
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.Right Then
                If DG1.CurrentCell.ColumnIndex = 2 And (DG1.CurrentCell.RowIndex <> 14 And DG1.CurrentCell.RowIndex <> 3) Then
                    DG1.Item(5, DG1.CurrentCell.RowIndex).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.ColumnIndex = 2 And DG1.CurrentCell.RowIndex = 14 Then
                    DG1.Item(5, 13).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.ColumnIndex = 2 And DG1.CurrentCell.RowIndex = 3 Then
                    DG1.Item(5, 2).Selected = True
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.Down Then
                If DG1.CurrentCell.RowIndex = 4 And DG1.CurrentCell.ColumnIndex < 3 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 6).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.RowIndex = 2 And DG1.CurrentCell.ColumnIndex > 2 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 4).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.RowIndex = 9 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 13).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.RowIndex = 13 And DG1.CurrentCell.ColumnIndex > 2 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 15).Selected = True
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.Up Then
                If DG1.CurrentCell.RowIndex = 6 And DG1.CurrentCell.ColumnIndex < 3 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 4).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.RowIndex = 4 And DG1.CurrentCell.ColumnIndex > 2 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 2).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.RowIndex = 13 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 9).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.RowIndex = 15 And DG1.CurrentCell.ColumnIndex > 2 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 13).Selected = True
                    e.Handled = True
                ElseIf DG1.CurrentCell.RowIndex = 1 Then
                    DG1.Item(DG1.CurrentCell.ColumnIndex, 1).Selected = True
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmacsearch.Close()
        frmacsearch.Show()
    End Sub
End Class
