Imports System.Data.SqlClient
Public Class frmtradingdis
    Dim i As Integer
    Dim dr As SqlDataReader
    Public rpttype As String = ""
    Private Sub frmtradingdis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmtradingdis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        MaskedTextBox1.Text = dateyf
        MaskedTextBox2.Text = dateyl
        caltrad()
    End Sub
    Private Sub caltrad()
        Try
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text
            dat2 = MaskedTextBox2.Text
            Dim dat As String
            dat = "tblLedg.date >='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and tblLedg.date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
            dg1.ReadOnly = True
            dg1.MultiSelect = False
            dg1.AllowUserToAddRows = False
            dg2.ReadOnly = True
            dg2.MultiSelect = False
            dg2.AllowUserToAddRows = False
            dg2.RowHeadersVisible = False
            dg2.DefaultCellStyle.SelectionBackColor = Color.White
            dg2.DefaultCellStyle.SelectionForeColor = Color.Black
            Dim cmd As New SqlCommand
            Dim sql As String
            Dim shead As String = ""
            Dim mhead As String = ""
            Dim asd As String = ""
            Dim shead1 As String = ""
            Dim mhead1 As String = ""
            Dim asd1 As String = ""
            Dim asdtotal As Decimal
            i = 0
            Dim mheadtotal As Decimal
            Dim sheadtotal As Decimal
            connect()
            sql = "Select ASD,tblledg.ACName as ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode " & " and ASD='Expenditure' and tblMH.Treading='True' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD order by ASD,tblMh.Mhead,tblSh.Shead"
            '   MsgBox(sql)
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    If i = 1 Or i = 0 Then
                    Else
                        dg1.Rows.Add()
                        dg1.Item(0, i).Style.ForeColor = Color.Blue
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        dg1.Item(0, i).Value = "TOTAL:"
                        If sheadtotal < 0 Then
                            dg1.Item(1, i).Value = Format(Val(sheadtotal * -1), "0.00")
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                        ElseIf sheadtotal > 0 Then
                            dg1.Item(2, i).Value = Format(Val(mheadtotal), "0.00")
                            dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        i = i + 1
                        sheadtotal = 0.0
                        'shead1 = dr.Item("Shead")
                    End If
                End If
                If mhead.Trim.ToUpper <> dr.Item("Mhead").ToString.Trim.ToUpper Then
                    If i = 0 Then
                    Else
                        dg1.Rows.Add()
                        dg1.Item(0, i).Style.ForeColor = Color.Purple
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        dg1.Item(0, i).Value = "TOTAL:"

                        If mheadtotal < 0 Then
                            dg1.Item(1, i).Value = Format(Val(mheadtotal * -1), "0.00")
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                        ElseIf mheadtotal > 0 Then
                            dg1.Item(2, i).Value = Format(Val(mheadtotal), "0.00")
                            dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        i = i + 1
                        ' mhead = dr.Item("Mhead")
                        mheadtotal = 0.0
                    End If
                End If
                If asd.Trim.ToUpper <> dr.Item("Asd").ToString.Trim.ToUpper Then
                    If i = 0 Then
                    Else
                        dg1.Rows.Add()
                        dg1.Item(0, i).Style.ForeColor = Color.Red
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        dg1.Item(0, i).Value = "TOTAL:"
                        If asdtotal < 0 Then
                            dg1.Item(1, i).Value = Format(Val(asdtotal * -1), "0.00")
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                        ElseIf asdtotal > 0 Then
                            dg1.Item(2, i).Value = Format(Val(asdtotal), "0.00")
                            dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        dg1.Rows(i).DefaultCellStyle.ForeColor = Color.BurlyWood
                        i = i + 1
                        '     asd = dr.Item("Asd")
                        asdtotal = 0.0
                    End If
                End If
                If asd.Trim.ToUpper <> dr.Item("Asd").ToString.Trim.ToUpper Then
                    dg1.Rows.Add()
                    dg1.Item(0, i).Value = dr.Item("asd")
                    dg1.Rows(i).ReadOnly = True
                    dg1.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    dg1.Rows(i).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    asd = dr.Item("asd")
                    asd1 = dr.Item("asd")
                    i = i + 1
                End If

                If mhead.Trim.ToUpper <> dr.Item("Mhead").ToString.Trim.ToUpper Then
                    dg1.Rows.Add()
                    dg1.Item(0, i).Value = dr.Item("Mhead")
                    dg1.Rows(i).ReadOnly = True
                    dg1.Rows(i).DefaultCellStyle.ForeColor = Color.Purple
                    dg1.Rows(i).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    mhead = dr.Item("Mhead")
                    mhead1 = dr.Item("Mhead")
                    i = i + 1
                End If
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    dg1.Rows.Add()
                    dg1.Item(0, i).Value = dr.Item("Shead")
                    dg1.Rows(i).ReadOnly = True
                    dg1.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                    dg1.Rows(i).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                    shead = dr.Item("Shead")
                    shead1 = dr.Item("Shead")
                    i = i + 1
                End If
                dg1.Rows.Add()
                dg1.Item(0, i).Value = dr.Item("ACName")
                If dr.Item("bal") < 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("bal") * -1), "0.00")
                    dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                ElseIf dr.Item("bal") > 0 Then
                    dg1.Item(2, i).Value = Format(Val(dr.Item("bal")), "0.00")
                    dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                Else
                    dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                    dg1.Item(1, i).Value = Format(Val(0.0), "0.00")

                End If
                mheadtotal = mheadtotal + dr.Item("bal")
                sheadtotal = sheadtotal + dr.Item("bal")
                asdtotal = asdtotal + dr.Item("Bal")
                i = i + 1





            End While
            dr.Close()

            sql = "Select ASD,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblSh.shead='" & shead & "' and ASD='Expenditure' and tblMH.Treading='True' and " & dat & " group by tblSh.shead,tblMh.Mhead,tblMh.ASD order by tblSh.Shead,tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, i).Style.ForeColor = Color.Blue
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg1.Item(0, i).Value = "TOTAL:"

                If dr.Item("bal") < 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("Bal") * -1), "0.00")
                    dg1.Item(2, i).Value = "0.00"
                End If
                If dr.Item("bal") > 0 Then
                    dg1.Item(2, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg1.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' and ASD='Expenditure' and Treading='True' and " & dat & " group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, i).Style.ForeColor = Color.Purple
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg1.Item(0, i).Value = "TOTAL:"

                If dr.Item("bal") < 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("Bal") * -1), "0.00")
                    dg1.Item(2, i).Value = "0.00"
                End If
                If dr.Item("bal") > 0 Then
                    dg1.Item(2, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg1.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and ASD='Expenditure' and tblMH.Treading='True' and " & dat & " group by tblMh.ASD order by ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, i).Style.ForeColor = Color.Red
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg1.Item(0, i).Value = "TOTAL:"
                If dr.Item("bal") < 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("Bal") * -1), "0.00")
                    dg1.Item(2, i).Value = "0.00"
                End If
                If dr.Item("bal") > 0 Then
                    dg1.Item(2, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg1.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            shead = ""
            mhead = ""
            asd = ""
            shead1 = ""
            mhead1 = ""
            asd1 = ""
            asdtotal = 0
            i = 0
            mheadtotal = 0
            sheadtotal = 0
            connect()
            sql = "Select ASD,tblledg.ACName as ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode " & " and ASD='Income' and Treading='True' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD order by ASD,tblMh.Mhead,tblSh.Shead"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    If i = 1 Or i = 0 Then
                    Else
                        dg2.Rows.Add()
                        dg2.Item(0, i).Style.ForeColor = Color.Blue
                        dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        dg2.Item(0, i).Value = "TOTAL:"

                        If sheadtotal < 0 Then
                            dg2.Item(1, i).Value = Format(Val(sheadtotal * -1), "0.00")
                            dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                        ElseIf sheadtotal > 0 Then
                            dg2.Item(2, i).Value = Format(Val(mheadtotal), "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        i = i + 1
                        sheadtotal = 0.0
                        'shead1 = dr.Item("Shead")
                    End If
                End If
                If mhead.Trim.ToUpper <> dr.Item("Mhead").ToString.Trim.ToUpper Then
                    If i = 0 Then
                    Else
                        dg2.Rows.Add()
                        dg2.Item(0, i).Style.ForeColor = Color.Purple
                        dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        dg2.Item(0, i).Value = "TOTAL:"

                        If mheadtotal < 0 Then
                            dg2.Item(1, i).Value = Format(Val(mheadtotal * -1), "0.00")
                            dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                        ElseIf mheadtotal > 0 Then
                            dg2.Item(2, i).Value = Format(Val(mheadtotal), "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        i = i + 1
                        ' mhead = dr.Item("Mhead")
                        mheadtotal = 0.0
                    End If
                End If
                If asd.Trim.ToUpper <> dr.Item("Asd").ToString.Trim.ToUpper Then
                    If i = 0 Then
                    Else
                        dg2.Rows.Add()
                        dg2.Item(0, i).Style.ForeColor = Color.Red
                        dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        dg2.Item(0, i).Value = "TOTAL:"
                        If asdtotal < 0 Then
                            dg2.Item(1, i).Value = Format(Val(asdtotal * -1), "0.00")
                            dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                        ElseIf asdtotal > 0 Then
                            dg2.Item(2, i).Value = Format(Val(asdtotal), "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        dg2.Rows(i).DefaultCellStyle.ForeColor = Color.BurlyWood
                        i = i + 1
                        '     asd = dr.Item("Asd")
                        asdtotal = 0.0
                    End If
                End If
                If asd.Trim.ToUpper <> dr.Item("Asd").ToString.Trim.ToUpper Then
                    dg2.Rows.Add()
                    dg2.Item(0, i).Value = dr.Item("asd")
                    dg2.Rows(i).ReadOnly = True
                    dg2.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    dg2.Rows(i).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    asd = dr.Item("asd")
                    asd1 = dr.Item("asd")
                    i = i + 1
                End If

                If mhead.Trim.ToUpper <> dr.Item("Mhead").ToString.Trim.ToUpper Then
                    dg2.Rows.Add()
                    dg2.Item(0, i).Value = dr.Item("Mhead")
                    dg2.Rows(i).ReadOnly = True
                    dg2.Rows(i).DefaultCellStyle.ForeColor = Color.Purple
                    dg2.Rows(i).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    mhead = dr.Item("Mhead")
                    mhead1 = dr.Item("Mhead")
                    i = i + 1
                End If
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    dg2.Rows.Add()
                    dg2.Item(0, i).Value = dr.Item("Shead")
                    dg2.Rows(i).ReadOnly = True
                    dg2.Rows(i).DefaultCellStyle.ForeColor = Color.Purple
                    dg2.Rows(i).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                    shead = dr.Item("Shead")
                    shead1 = dr.Item("Shead")
                    i = i + 1
                End If
                dg2.Rows.Add()
                dg2.Item(0, i).Value = dr.Item("ACName")
                If dr.Item("bal") < 0 Then
                    dg2.Item(1, i).Value = Format(Val(dr.Item("bal") * -1), "0.00")
                    dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                ElseIf dr.Item("bal") > 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("bal")), "0.00")
                    dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                Else
                    dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                    dg2.Item(1, i).Value = Format(Val(0.0), "0.00")

                End If
                mheadtotal = mheadtotal + dr.Item("bal")
                sheadtotal = sheadtotal + dr.Item("bal")
                asdtotal = asdtotal + dr.Item("Bal")
                i = i + 1





            End While
            dr.Close()

            sql = "Select ASD,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblSh.shead='" & shead & "' and ASD='Income' and tblMH.Treading='True' and " & dat & " group by tblSh.shead,tblMh.Mhead,tblMh.ASD order by tblSh.Shead,tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg2.Rows.Add()
                dg2.Item(0, i).Style.ForeColor = Color.Blue
                dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg2.Item(0, i).Value = "TOTAL:"

                If dr.Item("bal") < 0 Then
                    dg2.Item(1, i).Value = Format(Val(dr.Item("Bal") * -1), "0.00")
                    dg2.Item(2, i).Value = "0.00"
                End If
                If dr.Item("bal") > 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg2.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' and ASD='Income' and tblMH.Treading='True' and " & dat & " group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg2.Rows.Add()
                dg2.Item(0, i).Style.ForeColor = Color.Purple
                dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg2.Item(0, i).Value = "TOTAL:"

                If dr.Item("bal") < 0 Then
                    dg2.Item(1, i).Value = Format(Val(dr.Item("Bal") * -1), "0.00")
                    dg2.Item(2, i).Value = "0.00"
                End If
                If dr.Item("bal") > 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg2.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and ASD='Income' and tblMH.Treading='True' and " & dat & " group by tblMh.ASD order by ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg2.Rows.Add()
                dg2.Item(0, i).Style.ForeColor = Color.Red
                dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg2.Item(0, i).Value = "TOTAL:"
                If dr.Item("bal") < 0 Then
                    dg2.Item(1, i).Value = Format(Val(dr.Item("Bal") * -1), "0.00")
                    dg2.Item(2, i).Value = "0.00"
                End If
                If dr.Item("bal") > 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg2.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            '          Dim ex1 As Decimal
            '         Dim in1 As Decimal
            '            Try
            'If dg1.Rows.Count = 0 Then
            'ex1 = 0
            '          Else
            '         ex1 = (dg1.Item(1, dg1.Rows.Count - 1).Value)
            '        End If

            '        If dg2.Rows.Count = 0 Then
            '     in1 = 0
            '       Else
            '       in1 = (dg2.Item(2, dg2.Rows.Count - 1).Value)
            '       End If
            '    Catch ex As Exception
            '  End Try
            Dim rmcount As Integer
            For rmcount = 0 To dg2.Rows.Count - 1
                Try
                    ' MsgBox (
                    If dg2.Item(0, dg2.Rows.Count - 1 - rmcount).Value.ToString.Length = 0 Then
                        dg2.Rows.RemoveAt(dg2.Rows.Count - 1 - rmcount)
                    End If
                Catch ex As Exception
                    dg2.Rows.RemoveAt(dg2.Rows.Count - 1 - rmcount)
                End Try
            Next
            If profitcal() > 0 Then
                Try
                    dg1.Rows.RemoveAt(dg1.Rows.Count - 1)
                Catch ex As Exception
                    dg1.Rows.Add()
                    dg1.Item(0, 0).Value = "Expenditure"
                    dg1.Item(0, 0).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                    dg1.Item(0, 0).Style.ForeColor = Color.Red
                End Try
                dg1.Rows.Add()
                dg1.Item(0, dg1.Rows.Count - 1).Style.ForeColor = Color.Purple
                dg1.Item(0, dg1.Rows.Count - 1).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg1.Item(0, dg1.Rows.Count - 1).Value = "Profit & Loss"
                dg1.Rows.Add()
                dg1.Item(0, dg1.Rows.Count - 1).Value = " "
                dg1.Rows.Add()
                dg1.Item(0, dg1.Rows.Count - 1).Value = "Gross Profit transfer to Profit & Loss"
                dg1.Item(1, dg1.Rows.Count - 1).Value = Format(profitcal(), "0.00")
                dg1.Rows.Add()
                dg1.Item(0, dg1.Rows.Count - 1).Value = " "
                dg1.Rows.Add()
                dg1.Item(0, dg1.Rows.Count - 1).Style.ForeColor = Color.Red
                dg1.Item(0, dg1.Rows.Count - 1).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg1.Item(0, dg1.Rows.Count - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, dg1.Rows.Count - 1).Value = "TOTAL:"
                dg1.Item(1, dg1.Rows.Count - 1).Value = Format(Val(dg2.Item(2, dg2.Rows.Count - 1).Value), "0.00")
            ElseIf profitcal() < 0 Then
                Try
                    dg2.Rows.RemoveAt(dg2.Rows.Count - 1)
                Catch ex As Exception
                    dg2.Rows.Add()
                    dg2.Item(0, 0).Value = "Expenditure"
                    dg2.Item(0, 0).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                    dg2.Item(0, 0).Style.ForeColor = Color.Red
                End Try
                dg2.Rows.Add()
                dg2.Item(0, dg2.Rows.Count - 1).Style.ForeColor = Color.Purple
                dg2.Item(0, dg2.Rows.Count - 1).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg2.Item(0, dg2.Rows.Count - 1).Value = "Profit & Loss"
                dg2.Rows.Add()
                dg2.Item(0, dg2.Rows.Count - 1).Value = " "
                dg2.Rows.Add()
                dg2.Item(0, dg2.Rows.Count - 1).Value = "Gross Profit/Loss transfer to Profir & Loss"
                dg2.Item(2, dg2.Rows.Count - 1).Value = Format(profitcal() * -1, "0.00")
                dg2.Rows.Add()
                dg2.Item(0, dg2.Rows.Count - 1).Value = " "
                dg2.Rows.Add()
                dg2.Item(0, dg2.Rows.Count - 1).Style.ForeColor = Color.Red
                dg2.Item(0, dg2.Rows.Count - 1).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                dg2.Item(0, dg2.Rows.Count - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg2.Item(0, dg2.Rows.Count - 1).Value = "TOTAL:"
                dg2.Item(2, dg2.Rows.Count - 1).Value = Format(Val(dg1.Item(1, dg1.Rows.Count - 1).Value), "0.00")
                '  MsgBox(Val(dg2.Item(1, dg2.Rows.Count - 1).Value))
            End If
            ' If Val(dg1.Item(1, dg1.RowCount - 1).Value) < 0 Then
            'dg1.Item(1, dg1.Rows.Count - 1).Value = Format(finalsum * -1, "0.00")
            '     dg1.Item(3, dg1.Rows.Count - 1).Value = "CR"
            '    End If
            '   ElseIf ex1 - in1 > 0 Then
            '      Try
            'dg2.Rows.RemoveAt(dg2.Rows.Count - 1)
            '   Catch ex As Exception
            '      dg2.Rows.Add()
            '     dg2.Item(0, 0).Value = "Income"
            '    dg2.Item(0, 0).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            '   dg2.Item(0, 0).Style.ForeColor = Color.Red
            ' End Try
            '  dg2.Rows.Add()
            ' dg2.Item(0, dg2.Rows.Count - 1).Style.ForeColor = Color.Purple
            '  dg2.Item(0, dg2.Rows.Count - 1).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            ' dg2.Item(0, dg2.Rows.Count - 1).Value = "Profit & Loss"
            'dg2.Rows.Add()
            '  dg2.Item(0, dg2.Rows.Count - 1).Value = " "
            ' dg2.Rows.Add()
            '  dg2.Item(0, dg2.Rows.Count - 1).Value = "Gross Loss transfer to"
            ' dg2.Item(2, dg2.Rows.Count - 1).Value = Format(ex1 - in1, "0.00")
            '  dg2.Rows.Add()
            ' dg2.Item(0, dg2.Rows.Count - 1).Value = " "
            '   DataGridView2.Rows.Add()
            '  DataGridView2.Item(0, DataGridView2.Rows.Count - 1).Style.ForeColor = Color.Purple
            ' DataGridView2.Item(0, DataGridView2.Rows.Count - 1).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            'DataGridView2.Item(0, DataGridView2.Rows.Count - 1).Value = "Profit & Loss"
            '  dg2.Rows.Add()
            '   Dim sql2 As String
            ' Dim dr2 As SqlDataReader
            '  Dim cmd2 As New SqlCommand
            '   Dim finalsum As Decimal
            ' sql2 = "Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and ASD='Expenditure' and tblMH.Treading='True' group by tblMh.ASD order by ASD"
            '  cmd2 = New SqlCommand(sql2, cn)
            '   dr2 = cmd2.ExecuteReader
            '    While dr2.Read
            '      finalsum = dr2.Item("bal")
            '   End While

            '  dr2.Close()
            '   dg2.Item(0, dg2.Rows.Count - 1).Style.ForeColor = Color.Red
            'dg2.Item(0, dg2.Rows.Count - 1).Style.Font = New Font("Arial", 10, FontStyle.Bold)
            ' dg2.Item(0, dg2.Rows.Count - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
            '  dg2.Item(0, dg2.Rows.Count - 1).Value = "TOTAL:"
            'dg2.Item(2, dg2.Rows.Count - 1).Value = Format(finalsum * -1, "0.00")
            ' If finalsum > 0 Then
            '    dg2.Item(2, dg2.Rows.Count - 1).Value = Format(finalsum, "0.00")
            '   dg2.Item(3, dg2.Rows.Count - 1).Value = "DR"
            'End If
            ' End If
            If dg1.Rows.Count < dg2.Rows.Count Then
                Dim v As Integer
                v = dg2.Rows.Count - dg1.Rows.Count
                Dim j As Integer
                For j = 0 To v - 1
                    dg1.Rows.Add()
                Next
            Else
                Dim v As Integer
                v = dg1.Rows.Count - dg2.Rows.Count
                Dim j As Integer
                For j = 0 To v - 1
                    dg2.Rows.Add()
                Next
            End If
            Dim count As Integer
            For count = 0 To dg1.RowCount - 1
                Try
                    If Val(dg1.Item(2, count).Value > 0) Then
                        dg1.Item(1, count).Value = Format(Val(dg1.Item(2, count).Value), "0.00")
                        dg1.Item(3, count).Value = "CR"
                    End If
                Catch ex As Exception

                End Try
            Next
            For count = 0 To dg2.RowCount - 1
                Try
                    If Val(dg2.Item(1, count).Value > 0) Then
                        dg2.Item(2, count).Value = Format(Val(dg2.Item(1, count).Value), "0.00")
                        dg2.Item(3, count).Value = "DR"
                    End If
                Catch ex As Exception
                End Try
            Next

            ' DataGridView1.Columns(2).Visible = False
            '  DataGridView2.Columns(1).Visible = False
            'dg1.ScrollBars = ScrollBars.None
            'dg2.ScrollBars = ScrollBars.None
            close1()
            '    Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function profitcal() As Decimal
        Try
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text
            dat2 = MaskedTextBox2.Text
            Dim dat As String
            dat = "tblLedg.date >='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and tblLedg.date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"

            Dim bal As Decimal = 0.0
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String
            sql = "Select Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and (ASD='Expenditure' OR ASD='Income') and tblMH.Treading='True' and " & dat
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                bal = dr.Item(2)
            End While
            dr.Close()

            close1()
            Return bal
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Private Sub DataGridView1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.GotFocus
        dg1.DefaultCellStyle.SelectionBackColor = Color.Blue
        dg1.DefaultCellStyle.SelectionForeColor = Color.White
    End Sub

    Private Sub DataGridView1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.LostFocus
        dg1.DefaultCellStyle.SelectionBackColor = Color.White
        dg1.DefaultCellStyle.SelectionForeColor = Color.Black
    End Sub

    Private Sub DataGridView2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg2.GotFocus
        dg2.DefaultCellStyle.SelectionBackColor = Color.Blue
        dg2.DefaultCellStyle.SelectionForeColor = Color.White
    End Sub

    Private Sub DataGridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg2.KeyDown
        Try
            If e.KeyCode = Keys.Left And dg2.SelectedCells.Item(0).ColumnIndex = 0 Then
                dg1.Item(1, dg2.SelectedCells.Item(0).RowIndex).Selected = True
                dg1.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg2.LostFocus
        dg2.DefaultCellStyle.SelectionBackColor = Color.White
        dg2.DefaultCellStyle.SelectionForeColor = Color.Black
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        Try
            If e.KeyCode = Keys.Right And dg1.SelectedCells.Item(0).ColumnIndex = 1 Then
                dg2.Item(0, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                dg2.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            rpttype = "Account"
        ElseIf RadioButton2.Checked = True Then
            rpttype = "Schedule"
        End If
        frmTreading.Close()
        frmTreading.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            dg1.Rows.Clear()
            dg2.Rows.Clear()
            caltrad()
        Catch ex As Exception

        End Try
    End Sub
End Class