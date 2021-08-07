Imports System.Data.SqlClient
Public Class frmforout
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Public adv1 As Integer
    Private Sub frmforout_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmBankRecipt.checkedit = 1 Then
            frmBankRecipt.save2()
            frmBankRecipt.checkedit = 0
        End If
    End Sub

    Private Sub frmforout_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            connect()
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter
            da1 = New SqlDataAdapter("Select CONVERT(varchar,billdt,105) BillDate,OubNo,NetAmt,OutAmt,Ispaid,BKName,Bkcode from salesc where Name='" & frmBankRecipt.txtAcname.Text & "'", cn)
            da1.Fill(ds1)
            MyDataGridView1.DataSource = ds1.Tables(0)
            MyDataGridView1.Visible = True
            close1()
        End If
    End Sub
    Public Sub FINDNETAMT()
        Dim K As Integer
        Dim CMD As New SqlCommand
        Dim DR As SqlDataReader
        connect()
        For K = 0 To dg2.RowCount - 1
            CMD = New SqlCommand("SELECT NETAMT,OUTAMT FROM SALESC WHERE OUBNO='" & dg2.Item(0, K).Value & "' AND BKNAME='" & dg2.Item(15, K).Value & "' and name='" & frmBankRecipt.txtAcname.Text & "' union SELECT NETAMT,OUTAMT FROM tblOub WHERE OUBNO='" & dg2.Item(0, K).Value & "' AND BKNAME='" & dg2.Item(15, K).Value & "' and book='Sales' and acname='" & frmBankRecipt.txtAcname.Text & "'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                dg2.Item(2, K).Value = DR.Item("NETAMT")
                dg2.Item(3, K).Value = DR.Item("OUTAMT")
            End While
            DR.Close()
        Next
        close1()
    End Sub
    Public Sub FINDNETAMT1()
        Dim K As Integer
        Dim CMD As New SqlCommand
        Dim DR As SqlDataReader
        connect()
        For K = 0 To dg2copy.RowCount - 1
            CMD = New SqlCommand("SELECT NETAMT,OUTAMT FROM SALESC WHERE OUBNO='" & dg2copy.Item(0, K).Value & "' AND BKNAME='" & dg2copy.Item(15, K).Value & "' and name='" & frmBankRecipt.txtAcname.Text & "' union SELECT NETAMT,OUTAMT FROM tblOub WHERE OUBNO='" & dg2copy.Item(0, K).Value & "' AND BKNAME='" & dg2copy.Item(15, K).Value & "' and book='Sales' and acname='" & frmBankRecipt.txtAcname.Text & "'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                dg2copy.Item(2, K).Value = DR.Item("NETAMT")
                dg2copy.Item(3, K).Value = DR.Item("OUTAMT")
            End While
            DR.Close()
        Next
        close1()
    End Sub
    Private Sub frmforout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '  dg2copy.Visible = False
            dg1copy.Visible = False
            If frmBankRecipt.Label11.Text.ToUpper = "EDIT MODE" Then
                connect()
                Dim CMD As New SqlCommand
                Dim DR As SqlDataReader
                CMD = New SqlCommand("sELECT * FROM BANKT WHERE VRNO='" & frmBankRecipt.txtVrNofirst.Text & frmBankRecipt.txtVrNosec.Text & "'", cn)
                DR = CMD.ExecuteReader
                Dim D As Integer = 0
                While DR.Read
                    dg2.Rows.Add()
                    dg2.Item(0, D).Value = DR.Item("OUBNO")
                    dg2.Item(1, D).Value = Format(DR.Item("BILLDT"), "dd-MM-yyyy")
                    dg2.Item(4, D).Value = DR.Item("PAIDAMT")
                    dg2.Item(5, D).Value = DR.Item("DISCPER")
                    dg2.Item(6, D).Value = DR.Item("DISCOUNT")
                    dg2.Item(7, D).Value = DR.Item("RD")
                    dg2.Item(8, D).Value = DR.Item("CLAIM")
                    dg2.Item(10, D).Value = DR.Item("TDS")
                    dg2.Item(9, D).Value = DR.Item("TDSPER")
                    dg2.Item(11, D).Value = DR.Item("UNADAMT")
                    dg2.Item(12, D).Value = DR.Item("OUREMARK")
                    dg2.Item(13, D).Value = DR.Item("CRNTAMT")
                    dg2.Item(14, D).Value = DR.Item("DRNTAMT")
                    dg2.Item(15, D).Value = DR.Item("BKNAME")
                    dg2.Item(16, D).Value = DR.Item("BKCODE")
                    dg2copy.Rows.Add()
                    dg2copy.Item(0, D).Value = DR.Item("OUBNO")
                    dg2copy.Item(1, D).Value = Format(DR.Item("BILLDT"), "dd-MM-yyyy")

                    dg2copy.Item(4, D).Value = DR.Item("PAIDAMT")
                    dg2copy.Item(5, D).Value = DR.Item("DISCPER")
                    dg2copy.Item(6, D).Value = DR.Item("DISCOUNT")
                    dg2copy.Item(7, D).Value = DR.Item("RD")
                    dg2copy.Item(8, D).Value = DR.Item("CLAIM")
                    dg2copy.Item(9, D).Value = DR.Item("TDS")
                    dg2copy.Item(10, D).Value = DR.Item("TDSPER")
                    dg2copy.Item(11, D).Value = DR.Item("UNADAMT")
                    dg2copy.Item(12, D).Value = DR.Item("OUREMARK")
                    dg2copy.Item(13, D).Value = DR.Item("CRNTAMT")
                    dg2copy.Item(14, D).Value = DR.Item("DRNTAMT")
                    dg2copy.Item(15, D).Value = DR.Item("BKNAME")
                    dg2copy.Item(16, D).Value = DR.Item("BKCODE")
                    D = D + 1
                End While
                DR.Close()
                close1()
                frmBankRecipt.deletecode()
                FINDNETAMT()
                FINDNETAMT1()
                cal()
                calcopy()
                caldiff()
            End If
            connect()
            da = New SqlDataAdapter("Select CONVERT(varchar,billdt,105) BillDate,OubNo,NetAmt,OutAmt,Ispaid,BKName,Bkcode,CONVERT(INT,BILLNO) AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from salesc where Name='" & frmBankRecipt.txtAcname.Text & "' and Ispaid='f' UNION Select CONVERT(varchar,Date,105) Date,OUBNO,NetAmt,OutAmt,Ispaid,BKName,Bkcode,CONVERT(INT,SUBSTRING(OUBNO,4,LEN(OUBNO))) AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from tblOub where Book='Sales' and Ispaid='f' AND ACNAME='" & frmBankRecipt.txtAcname.Text & "' ORDER BY YEAR,BILLNO", cn)
            da.Fill(ds)
            dg1.DataSource = ds.Tables(0)
            dg1copy.DataSource = ds.Tables(0)
            Dim a As New DataGridViewCheckBoxColumn
            a.Name = "Check"
            a.HeaderText = "Checked"
            dg1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg1.Columns(7).Visible = False
            dg1.Columns(8).Visible = False
            Label6.Text = frmBankRecipt.txtAmount.Text
            Label6copy.Text = frmBankRecipt.txtAmount.Text
            cmd = New SqlCommand("Select * from adv where acname='" & frmBankRecipt.txtAcname.Text & "' and isclear='f'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Label10.Text = dr.Item("Amount")
                Label10copy.Text = dr.Item("Amount")
            End While
            dr.Close()
            Label11.Text = Val(Label6.Text) + Val(Label10.Text)
            Label11copy.Text = Val(Label11.Text)
            TextBox2.Text = Val(Label11.Text)

            cal()
            caldiff()
            dg1.Columns.Add(a)
            TICKBILL()
            GroupBox1.SendToBack()
            TextBox2copy.Text = Val(TextBox2.Text)
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TICKBILL()
        Try
            Dim K As Integer
            Dim J As Integer
            Dim BILLNO As String
            For K = 0 To dg2.RowCount - 1
                BILLNO = dg2.Item(0, K).Value
                For J = 0 To dg1.RowCount - 1
                    If dg1.Item(1, J).Value = BILLNO Then
                        dg1.Rows(J).DefaultCellStyle.ForeColor = Color.Red
                        dg1.Rows(J).DefaultCellStyle.SelectionForeColor = Color.Red
                        dg1.Item(dg1.ColumnCount - 1, J).Value = True

                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub dg1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        Try

            If e.KeyCode = Keys.Space Then
                If dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True Then
                    dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = False
                Else
                    dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True
                End If
                If dg1.Item(dg1.ColumnCount - 1, dg1.CurrentCell.RowIndex).Value = True Then
                    '   If dg1.Item(2, dg1.CurrentCell.RowIndex).Value <= Val(TextBox2.Text) Then
                    dg2.Rows.Add()
                    dg2.Item(0, dg2.RowCount - 1).Value = dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value
                    dg2.Item(1, dg2.RowCount - 1).Value = dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value
                    dg2.Item(2, dg2.RowCount - 1).Value = Format(dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Value, "0.00")
                    dg2.Item(3, dg2.RowCount - 1).Value = Format(dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value, "0.00")
                    dg2.Item(4, dg2.RowCount - 1).Value = Format(dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value, "0.00")
                    dg2.Item(dg2.ColumnCount - 1, dg2.RowCount - 1).Value = dg1.Item(dg1.ColumnCount - 4, dg1.SelectedCells.Item(0).RowIndex).Value
                    dg2.Item(dg2.ColumnCount - 2, dg2.RowCount - 1).Value = dg1.Item(dg1.ColumnCount - 5, dg1.SelectedCells.Item(0).RowIndex).Value
                    TextBox2.Text = Math.Round(Val(TextBox2.Text) - dg2.Item(4, dg2.RowCount - 1).Value, 2)
                    cal()
                    'Else
                    '   MsgBox("Bill amount is more than rec. amount")
                    '  dg1.Item(dg1.ColumnCount - 1, dg1.SelectedCells.Item(0).RowIndex).Value = False
                    ' GoTo en
                    'End If
                Else
                    For k = 0 To dg2.RowCount - 1
                        If dg2.Item(0, k).Value = dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value And dg2.Item(dg2.ColumnCount - 1, k).Value = dg1.Item(dg1.ColumnCount - 4, dg1.SelectedCells.Item(0).RowIndex).Value Then
                            TextBox2.Text = Math.Round(Val(TextBox2.Text) + dg2.Item(3 + 1, k).Value, 2)
                            dg2.Rows.RemoveAt(k)
                            cal()
                            dg1.Item(dg1.ColumnCount - 1, dg1.SelectedCells.Item(0).RowIndex).Value = False
                            GoTo en1
                        End If
                    Next
                End If
en1:
                If dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True Then
                    dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Red
                Else
                    dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = dg1.DefaultCellStyle.ForeColor
                End If
                If dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True Then
                    dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Red
                Else
                    dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
                End If

            ElseIf e.KeyCode = Keys.F2 Then
                Dim k As Integer
                For k = 0 To dg2.RowCount - 1
                    If dg2.Item(0, k).Value = dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value And dg2.Item(dg2.ColumnCount - 1, k).Value = dg1.Item(dg1.ColumnCount - 4, dg1.SelectedCells.Item(0).RowIndex).Value Then
                        TextBox2.Text = Val(TextBox2.Text) + dg2.Item(3 + 1, k).Value
                        dg2.Rows.RemoveAt(k)
                        cal()
                        dg1.Item(dg1.ColumnCount - 1, dg1.SelectedCells.Item(0).RowIndex).Value = False
                        GoTo en2
                    End If
                Next
en2:
                GroupBox1.BringToFront()
                txtdis.Focus()
            End If

en:
        Catch ex As Exception

        End Try

    End Sub
    Private Sub cal()
        count1(discount, 6)
        count1(tdscount, 10)
        count1(rdcount, 7)
        count1(claimcount, 8)
        count1(pamtcount, 4)
        count1(outamt, 3)
        count1(billamtcount, 2)
    End Sub
    Private Sub calcopy()
        count1(discountcopy, 6)
        count1(tdscountcopy, 10)
        count1(rdcountcopy, 7)
        count1(claimcountcopy, 8)
        count1(pmtamtcopy, 4)
        count1(outamtcopy, 3)
        count1(billamtcountcopy, 2)
    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.Leave
        TextBox7.Text = TextBox7.Text.ToUpper
        If TextBox7.Text.ToUpper = "YES" Or TextBox7.Text.ToUpper = "NO" Then
        Else
            MsgBox("Select YES OR NO")
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdis.KeyDown
        If e.KeyCode = Keys.Enter Then
            txttds.Focus()
        End If
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttds.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtldtds.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtldtds.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox7.Focus()
        End If
    End Sub

    Private Sub TextBox6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtldtds.Leave
        Try
            txtldtds.Text = Format(Val(txtldtds.Text), "0.00")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttds.Leave
        Try
            txttds.Text = Format(Val(txttds.Text), "0.00")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdis.Leave
        Try
            txtdis.Text = Format(Val(txtdis.Text), "0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim amt As New Decimal
            Dim disamt As Decimal
            Dim tdsamt As Decimal
            Dim tdsldamt As Decimal

            If Val(txtdis.Text) > 0 Then
                disamt = Math.Round((Val(txtdis.Text) * dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value) / 100, 0)
            End If
            If Val(txttds.Text) > 0 Then
                tdsamt = Math.Round((Val(txttds.Text) * dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value) / 100, 0)
            End If
            If Val(txtldtds.Text) > 0 Then
                tdsldamt = Math.Round(Val(txtldtds.Text) * (dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value - disamt) / 100, 0)
            End If
            amt = Math.Round(dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value - (disamt + tdsamt + tdsldamt), 0)
            '   If Val(TextBox2.Text) >= amt Then
            If dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True Then
                dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = False
            Else
                dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True
            End If
            If dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True Then
                dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = dg1.DefaultCellStyle.ForeColor
            End If
            If dg1.Item(dg1.Columns.Count - 1, dg1.CurrentCell.RowIndex).Value = True Then
                dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Red
            Else
                dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
            End If
            dg2.Rows.Add()
            dg2.Item(0, dg2.RowCount - 1).Value = dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value
            dg2.Item(1, dg2.RowCount - 1).Value = dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value
            dg2.Item(2, dg2.RowCount - 1).Value = dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Value
            dg2.Item(3, dg2.RowCount - 1).Value = Format(dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value, "0.00")
            dg2.Item(4, dg2.RowCount - 1).Value = amt
            dg2.Item(5, dg2.RowCount - 1).Value = txtdis.Text
            dg2.Item(6, dg2.RowCount - 1).Value = disamt
            dg2.Item(dg2.ColumnCount - 1, dg2.RowCount - 1).Value = dg1.Item(dg1.ColumnCount - 4, dg1.SelectedCells.Item(0).RowIndex).Value
            dg2.Item(dg2.ColumnCount - 2, dg2.RowCount - 1).Value = dg1.Item(dg1.ColumnCount - 5, dg1.SelectedCells.Item(0).RowIndex).Value
            If txttds.Text > 0 Then
                dg2.Item(9, dg2.RowCount - 1).Value = txttds.Text
                dg2.Item(10, dg2.RowCount - 1).Value = tdsamt
            Else
                dg2.Item(9, dg2.RowCount - 1).Value = txtldtds.Text
                dg2.Item(10, dg2.RowCount - 1).Value = tdsldamt
            End If
            TextBox2.Text = Val(TextBox2.Text) - amt
            cal()
            GroupBox1.SendToBack()
            dg1.Focus()
            'Else
            ' MsgBox("Bill Amount is more than Rec amt" & Val(TextBox2.Text) - amt)
            'dg1.Item(dg1.ColumnCount - 1, dg1.SelectedCells.Item(0).RowIndex).Value = False
            'GroupBox1.SendToBack()
            'dg1.Focus()
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub count1(ByRef tb As TextBox, ByVal i As Integer)
        Dim k As Integer
        Dim amt As Decimal = 0.0
        For k = 0 To dg2.RowCount - 1
            amt = amt + Val(dg2.Item(i, k).Value)
        Next
        tb.Text = Format(amt, "0.00")
    End Sub

    Private Sub dg2_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellValidated
        Try
            If e.ColumnIndex = 5 Then
                dg2.Item(6, e.RowIndex).Value = (dg2.Item(3, e.RowIndex).Value * dg2.Item(5, e.RowIndex).Value / 100)
                dg2.Item(4, e.RowIndex).Value = (dg2.Item(3, e.RowIndex).Value - dg2.Item(6, e.RowIndex).Value - dg2.Item(7, e.RowIndex).Value - dg2.Item(8, e.RowIndex).Value - dg2.Item(10, e.RowIndex).Value)
                cal()
                caldiff()
            ElseIf e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 10 Then
                dg2.CurrentCell.Value = (dg2.CurrentCell.Value)
                dg2.Item(4, e.RowIndex).Value = (dg2.Item(3, e.RowIndex).Value - dg2.Item(6, e.RowIndex).Value - dg2.Item(7, e.RowIndex).Value - dg2.Item(8, e.RowIndex).Value - dg2.Item(10, e.RowIndex).Value)
                cal()
                caldiff()
            ElseIf e.ColumnIndex = 11 Then
                dg2.CurrentCell.Value = (dg2.CurrentCell.Value)
                cal()
                dg2.Item(4, e.RowIndex).Value = (dg2.Item(3, e.RowIndex).Value - dg2.Item(6, e.RowIndex).Value - dg2.Item(7, e.RowIndex).Value - dg2.Item(8, e.RowIndex).Value - dg2.Item(10, e.RowIndex).Value)
                caldiff()
                dg2.Item(4, e.RowIndex).Value = (dg2.Item(4, e.RowIndex).Value - dg2.Item(11, e.RowIndex).Value)
                cal()
                caldiff()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub caldiff()
        Dim bal As Decimal
        For k = 0 To dg2.RowCount - 1
            bal = bal + dg2.Item(4, k).Value
        Next
        TextBox2.Text = Format(Val(Label11.Text) - bal, "0.00")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupBox1.SendToBack()
        dg1.Focus()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Val(TextBox2.Text) > 0 Then
            If MsgBox("Bill is not adjected you want to extra amount as Advance or Unadjested", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                adv1 = 1
                frmBankRecipt.txtRemark.Clear()
                Dim i As Integer
                For i = 0 To dg2.RowCount - 1
                    frmBankRecipt.txtRemark.Text = frmBankRecipt.txtRemark.Text & dg2.Item(0, i).Value & ","
                Next
                Try
                    frmBankRecipt.txtRemark.Text = frmBankRecipt.txtRemark.Text.Substring(0, frmBankRecipt.txtRemark.Text.Length - 1)
                Catch ex As Exception

                End Try

                Me.Hide()
                frmBankRecipt.Show()
                frmBankRecipt.txtRemark.Focus()
            End If
            'advance
        ElseIf Val(TextBox2.Text) < 0 Then
            MsgBox("Your paid amount is more than bank/cash amount so please decrese your paid amount till difference became 0")
            'part

        Else
            MsgBox("You have successfully adjested the bill")
            frmBankRecipt.txtRemark.Clear()
            Dim i As Integer
            For i = 0 To dg2.RowCount - 1
                frmBankRecipt.txtRemark.Text = frmBankRecipt.txtRemark.Text & dg2.Item(0, i).Value & ","
            Next
            frmBankRecipt.txtRemark.Text = frmBankRecipt.txtRemark.Text.Substring(0, frmBankRecipt.txtRemark.Text.Length - 1)
            Me.Hide()
            frmBankRecipt.Show()
            frmBankRecipt.txtRemark.Focus()
        End If

    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub dg2_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dg2.DefaultValuesNeeded


    End Sub

    Private Sub dg2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg2.RowsAdded
        dg2.Item(4, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(5, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(6, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(7, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(8, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(9, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(10, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(11, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(12, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(13, e.RowIndex).Value = Format(0.0, "0.00")
        dg2.Item(14, e.RowIndex).Value = Format(0.0, "0.00")
    End Sub

    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub MyDataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyDataGridView1.KeyDown
        If e.KeyCode = Keys.F9 Then
            MyDataGridView1.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmbillno.Show()
    End Sub

    Private Sub dgnew_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgnew.CellContentClick

    End Sub
End Class