Imports System.Data.SqlClient
Public Class frmtbdis
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Public rpttype As String = ""
    Dim sumcr As New Decimal
    Dim sumdr As New Decimal
    Private Sub frmtbdis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmtbdis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            If frmtb.CheckedListBox2.Items.Count = 0 Then
                MsgBox("NO ACCOUNTS TO DISPLAY")
                GoTo LAST
            End If
            Dim i As Integer = 0
            Dim ac As String = "and ("
            If frmtb.CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To frmtb.CheckedListBox2.Items.Count - 1
                    ac = ac & "tblAccount.ACName='" & frmtb.CheckedListBox2.Items(i).ToString & "' Or "
                Next
            End If
            For i = 0 To frmtb.CheckedListBox2.CheckedItems.Count - 1
                ac = ac & "tblAccount.ACName='" & frmtb.CheckedListBox2.CheckedItems(i).ToString & "' Or "
            Next
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = frmtb.MaskedTextBox1.Text.ToString
            dat2 = frmtb.MaskedTextBox2.Text.ToString
            MsgBox(dat1)

            ac = ac.Substring(0, ac.Length - 4).ToString & ")"
            Dim k As Integer
            ' For k = 0 To 100
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
            sql = "Select ASD,tblledg.ACName as ACName,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode " & ac & " AND DATE>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' AND DATE<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' group by tblLedg.ACName,tblSh.shead,tblMh.Mhead,tblMh.ASD order by ASD,tblMh.Mhead,tblSh.Shead"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    If i = 1 Or i = 0 Then
                    Else
                        dg1.Rows.Add()
                        dg1.Item(0, i).Value = "TOTAL:"
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.ForeColor = Color.Blue
                        dg1.Item(0, i).Style.Font = New Font("Arial", 14, FontStyle.Bold)
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
                        dg1.Item(0, i).Value = "TOTAL:"
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.ForeColor = Color.BlueViolet
                        dg1.Item(0, i).Style.Font = New Font("Arial", 14, FontStyle.Bold)
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
                        dg1.Item(0, i).Value = "TOTAL:"
                        dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        dg1.Item(0, i).Style.ForeColor = Color.Red
                        dg1.Item(0, i).Style.Font = New Font("Arial", 14, FontStyle.Bold)
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
                    dg1.Rows(i).DefaultCellStyle.Font = New Font("Arial", 14, FontStyle.Bold)
                    asd = dr.Item("asd")
                    asd1 = dr.Item("asd")
                    i = i + 1
                End If

                If mhead.Trim.ToUpper <> dr.Item("Mhead").ToString.Trim.ToUpper Then
                    dg1.Rows.Add()
                    dg1.Item(0, i).Value = dr.Item("Mhead")
                    dg1.Rows(i).ReadOnly = True
                    dg1.Rows(i).DefaultCellStyle.ForeColor = Color.BlueViolet
                    dg1.Rows(i).DefaultCellStyle.Font = New Font("Arial", 14, FontStyle.Bold)
                    mhead = dr.Item("Mhead")
                    mhead1 = dr.Item("Mhead")
                    i = i + 1
                End If
                If shead.Trim.ToUpper <> dr.Item("Shead").ToString.Trim.ToUpper Then
                    dg1.Rows.Add()
                    dg1.Item(0, i).Value = dr.Item("Shead")
                    dg1.Rows(i).ReadOnly = True
                    dg1.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                    dg1.Rows(i).DefaultCellStyle.Font = New Font("Arial", 13, FontStyle.Bold)
                    shead = dr.Item("Shead")
                    shead1 = dr.Item("Shead")
                    i = i + 1
                End If
                dg1.Rows.Add()
                dg1.Item(0, i).Value = dr.Item("ACName")
                If dr.Item("bal") < 0 Then
                    sumdr = sumdr + Val(dr.Item("bal") * -1)
                    dg1.Item(1, i).Value = Format(Val(dr.Item("bal") * -1), "0.00")
                    dg1.Item(2, i).Value = Format(Val(0.0), "0.00")
                ElseIf dr.Item("bal") > 0 Then
                    sumcr = sumcr + Val(dr.Item("bal") * 1)
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

            sql = "Select ASD,tblSh.Shead,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblSh.shead='" & shead & "' " & ac & " AND DATE>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' AND DATE<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' group by tblSh.shead,tblMh.Mhead,tblMh.ASD order by tblSh.Shead,tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, i).Value = "TOTAL:"
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.ForeColor = Color.Blue
                dg1.Item(0, i).Style.Font = New Font("Arial", 14, FontStyle.Bold)

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
            sql = "Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' " & ac & " AND DATE>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' AND DATE<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, i).Value = "TOTAL:"
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.ForeColor = Color.BlueViolet
                dg1.Item(0, i).Style.Font = New Font("Arial", 14, FontStyle.Bold)

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
            sql = "Select ASD,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.Asd='" & asd & "' " & ac & " AND DATE>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' AND DATE<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' group by tblMh.ASD order by ASD"
            cmd = New SqlCommand(sql, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, i).Value = "TOTAL:"
                dg1.Item(0, i).Style.Alignment = DataGridViewContentAlignment.MiddleRight
                dg1.Item(0, i).Style.ForeColor = Color.Red
                dg1.Item(0, i).Style.Font = New Font("Arial", 14, FontStyle.Bold)

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
            dg1.Rows(dg1.RowCount - 1).DefaultCellStyle.ForeColor = Color.BurlyWood
            cal()
            close1()
            '   Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
LAST:
    End Sub
    Private Sub cal()
        dg1.Rows.Add()
        dg1.Item(1, dg1.Rows.Count - 1).Value = Format(sumdr, "0.00")
        dg1.Item(1, dg1.Rows.Count - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Item(2, dg1.Rows.Count - 1).Value = Format(sumcr, "0.00")
        dg1.Item(2, dg1.Rows.Count - 1).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Rows(dg1.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
        dg1.Item(0, dg1.Rows.Count - 1).Value = "SUMMARY"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            rpttype = "Account"
        ElseIf RadioButton2.Checked = True Then
            rpttype = "Schedule"
        Else
            rpttype = "Zero"
        End If
        frmprinttb.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class