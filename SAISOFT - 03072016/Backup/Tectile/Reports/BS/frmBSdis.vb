Imports System.Data.SqlClient
Public Class frmBSdis
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Public rpttype As String = ""
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmBSdis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmBSdis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
         MaskedTextBox1.Text = dateyf
        MaskedTextBox2.Text = dateyl
        calbs()
  

    End Sub
    Private Sub calbs()
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
            connect()
            Dim sql As String
            Dim ex1 As Decimal = 0.0
            Dim in1 As Decimal = 0.0
            sql = "Select Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and (ASD='Expenditure' OR ASD='Income') and " & dat
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ex1 = dr.Item("Balance")
            End While
            dr.Close()
            ' MsgBox(ex1)
            sql = "Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and ASD='Income' group by tblMh.ASD order by ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                in1 = dr.Item("Bal")
            End While
            dr.Close()
            Dim d1 As Integer = 0
            Dim d2 As Integer = 0
            dg1.Rows.Add()
            '   MsgBox(ex1 & "     " & in1)
            If (ex1) < 0 Then
                dg1.Item(0, d1).Value = "Reserve And Surplus"
                dg1.Item(1, d1).Value = (ex1)
                dg1.Item(2, d1).Value = 0.0

            ElseIf (ex1) > 0 Then
                dg1.Item(0, d1).Value = "Reserve And Surplus"
                dg1.Item(1, d1).Value = (ex1)
                dg1.Item(2, d1).Value = 0.0
            Else
                dg1.Item(0, d1).Value = "Reserve And Surplus"
                dg1.Item(1, d1).Value = 0.0
                dg1.Item(2, d1).Value = 0.0

            End If
            ' MsgBox(dg1.Item(1, d1).Value)
            'for datagrdi2 starts
            Dim shead As String = ""
            Dim mhead As String = ""
            Dim asd As String = ""
            Dim shead1 As String = ""
            Dim mhead1 As String = ""
            Dim asd1 As String = ""

            Dim asdtotal As Decimal
            Dim i As Integer
            i = 0
            Dim mheadtotal As Decimal
            Dim sheadtotal As Decimal

            connect()
            sql = "Select ASD,tblledg.ACName as ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.asd='Assets' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD order by ASD,tblMh.Mhead,tblSh.Shead"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    If i = 1 Or i = 0 Then
                    Else
                        dg2.Rows.Add()
                        dg2.Item(0, i).Value = "TOTAL:"
                        dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg2.Item(0, i).Style.ForeColor = Color.Blue
                        dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        If sheadtotal <> 0 Then
                            dg2.Item(2, i).Value = Format(Val(sheadtotal) * -1, "0.00")
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
                        dg2.Item(0, i).Value = "TOTAL:"
                        dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg2.Item(0, i).Style.ForeColor = Color.BlueViolet
                        dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        If mheadtotal <> 0 Then
                            dg2.Item(2, i).Value = Format(Val(mheadtotal) * -1, "0.00")
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
                        dg2.Item(0, i).Value = "TOTAL:"
                        dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg2.Item(0, i).Style.ForeColor = Color.Red
                        dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        If asdtotal <> 0 Then
                            dg2.Item(2, i).Value = Format(Val(asdtotal) * -1, "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg2.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg2.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        dg2.Rows(i).DefaultCellStyle.ForeColor = Color.BurlyWood
                        i = i + 1
                        asd = dr.Item("Asd")
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
                    dg2.Rows(i).DefaultCellStyle.ForeColor = Color.BlueViolet
                    dg2.Rows(i).DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                    mhead = dr.Item("Mhead")
                    mhead1 = dr.Item("Mhead")
                    i = i + 1
                End If
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    dg2.Rows.Add()
                    dg2.Item(0, i).Value = dr.Item("Shead")
                    dg2.Rows(i).ReadOnly = True
                    dg2.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                    dg2.Rows(i).DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Bold)
                    shead = dr.Item("Shead")
                    shead1 = dr.Item("Shead")
                    i = i + 1
                End If
                dg2.Rows.Add()
                dg2.Item(0, i).Value = dr.Item("ACName")
                If dr.Item("bal") <> 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("bal")) * -1, "0.00")
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
            sql = "Select ASD,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblSh.shead='" & shead & "' and tblMH.asd='Assets' and " & dat & " group by tblSh.shead,tblMh.Mhead,tblMh.ASD order by tblSh.Shead,tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg2.Rows.Add()
                dg2.Rows.Add()
                dg2.Item(0, i).Value = "TOTAL:"
                dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg2.Item(0, i).Style.ForeColor = Color.Blue
                dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                If dr.Item("bal") <> 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("Bal")) * -1, "0.00")
                    dg2.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' and tblMh.asd='Assets' and " & dat & " group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg2.Rows.Add()
                dg2.Rows.Add()
                dg2.Item(0, i).Value = "TOTAL:"
                dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg2.Item(0, i).Style.ForeColor = Color.BlueViolet
                dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)

                If dr.Item("bal") <> 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("Bal")) * -1, "0.00")
                    dg2.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.Asd='" & asd & "' and tblMh.asd='Assets' and " & dat & " group by tblMh.ASD order by ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg2.Rows.Add()
                dg2.Rows.Add()
                dg2.Item(0, i).Value = "TOTAL:"
                dg2.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg2.Item(0, i).Style.ForeColor = Color.Red
                dg2.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)

                If dr.Item("bal") <> 0 Then
                    dg2.Item(2, i).Value = Format(Val(dr.Item("Bal")) * -1, "0.00")
                    dg2.Item(1, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            close1()
            'datagridview2 ends
            'for datagridview1 starts
            shead = ""
            mhead = ""
            asd = ""
            shead1 = ""
            mhead1 = ""
            asd1 = ""

            asdtotal = 0.0
            i = 1
            mheadtotal = 0.0
            sheadtotal = 0.0

            connect()
            sql = "Select ASD,tblledg.ACName as ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and asd='Liabilities' and " & dat & " group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD order by ASD,tblMh.Mhead,tblSh.Shead"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                '            MsgBox("het")
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    If i = 2 Or i = 1 Then
                    Else
                        dg1.Rows.Add()
                        dg1.Item(0, i).Value = "TOTAL:"
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.ForeColor = Color.Blue
                        dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        If sheadtotal <> 0 Then
                            dg1.Item(1, i).Value = Format(Val(sheadtotal), "0.00")
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
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
                    If i = 1 Then
                    Else
                        dg1.Rows.Add()
                        dg1.Item(0, i).Value = "TOTAL:"
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.ForeColor = Color.BlueViolet
                        dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                        If mheadtotal <> 0 Then
                            dg1.Item(1, i).Value = Format(Val(mheadtotal), "0.00")
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                        Else
                            dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                            dg1.Item(1, i).Value = Format(Val(0.0), "0.00")
                        End If
                        i = i + 1
                        ' mhead = dr.Item("Mhead")
                        mheadtotal = 0.0
                    End If
                End If
                '    If asd.Trim.ToUpper <> dr.Item("Asd").ToString.Trim.ToUpper Then
                'If i = 1 Then
                '    Else
                '    DataGridView1.Rows.Add()
                '    DataGridView1.Item(0, i).Value = "TOTAL:"
                '    DataGridView1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                '    DataGridView1.Item(0, i).Style.ForeColor = Color.Red
                '    DataGridView1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                '    If asdtotal < 0 Then
                '     DataGridView1.Item(1, i).Value = Format(Val(asdtotal * -1), "0.00")
                '     DataGridView1.Item(2, i).Value = Format(Val(0.0), "0.00")
                '    ElseIf asdtotal > 0 Then
                '     DataGridView1.Item(2, i).Value = Format(Val(asdtotal), "0.00")
                '    DataGridView1.Item(1, i).Value = Format(Val(0.0), "0.00")
                '   Else
                '     DataGridView1.Item(2, i).Value = Format(Val(0.0), "0.00")
                '    DataGridView1.Item(1, i).Value = Format(Val(0.0), "0.00")
                '   End If
                '  DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.BurlyWood
                '   i = i + 1
                '  '     asd = dr.Item("Asd")
                ' asdtotal = 0.0
                '     End If
                '    End If
                asd = "Liabilities"
                If mhead.Trim.ToUpper <> dr.Item("Mhead").ToString.Trim.ToUpper Then
                    dg1.Rows.Add()
                    dg1.Item(0, i).Value = dr.Item("Mhead")
                    dg1.Rows(i).ReadOnly = True
                    dg1.Rows(i).DefaultCellStyle.ForeColor = Color.BlueViolet
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
                If dr.Item("bal") <> 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("bal")), "0.00")
                    dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
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
            sql = "Select ASD,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblSh.shead='" & shead & "' and asd='Liabilities' and " & dat & " group by tblSh.shead,tblMh.Mhead,tblMh.ASD order by tblSh.Shead,tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Rows.Add()
                dg1.Item(0, i).Value = "TOTAL:"
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.ForeColor = Color.Blue
                dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)

                If dr.Item("bal") <> 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg1.Item(2, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' and asd='Liabilities' and " & dat & " group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Rows.Add()
                dg1.Item(0, i).Value = "TOTAL:"
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.ForeColor = Color.BlueViolet
                dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)
                If dr.Item("bal") <> 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("Bal")), "0.00")
                    dg1.Item(2, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            sql = "Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.Asd='" & asd & "' and asd='Liabilities' and " & dat & " group by tblMh.ASD order by ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Rows.Add()
                dg1.Item(0, i).Value = "TOTAL:"
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.ForeColor = Color.Red
                dg1.Item(0, i).Style.Font = New Font("Arial", 10, FontStyle.Bold)

                If dr.Item("bal") <> 0 Then
                    dg1.Item(1, i).Value = Format(Val(dr.Item("Bal")) + Val(dg1.Item(1, 0).Value), "0.00")
                    dg1.Item(2, i).Value = "0.00"
                End If
                i = i + 1
            End While
            dr.Close()
            Dim count As Integer
            For count = 0 To dg1.RowCount - 1
                Try
                    If Val(dg1.Item(1, count).Value < 0) Then
                        dg1.Item(1, count).Value = Format(Val(dg1.Item(1, count).Value) * -1, "0.00")
                        dg1.Item(3, count).Value = "DR"
                    End If
                Catch ex2 As Exception
                End Try
            Next
            For count = 0 To dg2.RowCount - 1
                Try
                    If Val(dg2.Item(2, count).Value < 0) Then
                        dg2.Item(2, count).Value = Format(Val(dg2.Item(2, count).Value) * -1, "0.00")
                        dg2.Item(3, count).Value = "CR"
                    End If
                Catch ex2 As Exception
                End Try
            Next
            close1()
            'for datagridview1 starts
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            rpttype = "Account"
        Else
            rpttype = "Schedule"
        End If
        frmbldis.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        dg1.Rows.Clear()
        dg2.Rows.Clear()
        calbs()
    End Sub
End Class