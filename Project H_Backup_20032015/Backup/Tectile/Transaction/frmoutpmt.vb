Imports System.Data.SqlClient
Public Class frmoutpmt
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Public adv1 As Integer

    Private Sub frmoutpmt_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmBank.checkedit = 1 Then
            ' MsgBox("s")
            frmBank.save2()
            frmBank.checkedit = 0
        End If
        frmBank.Show()
    End Sub
    Private Sub frmforout_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            connect()
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter
            da1 = New SqlDataAdapter("Select CONVERT(varchar,billdt,105) BillDate,OubNo,NetAmt,OutAmt,Ispaid,BKName,Bkcode from tblPurchase where Namecr='" & frmBank.txtAcName.Text & "'", cn)
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
        For K = 0 To dgdetail.RowCount - 1
            CMD = New SqlCommand("SELECT NETAMT,OUTAMT FROM tblPurchase WHERE OUBNO='" & dgdetail.Item(0, K).Value & "' AND BKNAME='" & dgdetail.Item(15, K).Value & "' AND NAMECR='" & frmBank.txtAcName.Text & "' union SELECT NETAMT,OUTAMT FROM tblOub WHERE OUBNO='" & dgdetail.Item(0, K).Value & "' AND BKNAME='" & dgdetail.Item(15, K).Value & "' and book='Purchase' AND ACNAME='" & frmBank.txtAcName.Text & "'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                dgdetail.Item(2, K).Value = DR.Item("NETAMT")
                dgdetail.Item(3, K).Value = DR.Item("OUTAMT")
            End While
            DR.Close()
        Next
        close1()
    End Sub
    Public Sub FINDNETAMT2()
        Dim K As Integer
        Dim CMD As New SqlCommand
        Dim DR As SqlDataReader
        connect()
        For K = 0 To dgdetailcopy.RowCount - 1
            CMD = New SqlCommand("SELECT NETAMT,OUTAMT FROM tblPurchase WHERE OUBNO='" & dgdetailcopy.Item(0, K).Value & "' AND BKNAME='" & dgdetailcopy.Item(15, K).Value & "' AND NAMECR='" & frmBank.txtAcName.Text & "' union SELECT NETAMT,OUTAMT FROM tbloub WHERE OUBNO='" & dgdetailcopy.Item(0, K).Value & "' AND BKNAME='" & dgdetailcopy.Item(15, K).Value & "' and book='Purchase' AND acNAME='" & frmBank.txtAcName.Text & "'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                dgdetailcopy.Item(2, K).Value = DR.Item("NETAMT")
                dgdetailcopy.Item(3, K).Value = DR.Item("OUTAMT")
            End While
            DR.Close()
        Next
        close1()
    End Sub
    Private Sub frmforout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If frmBank.Label11.Text.ToUpper = "EDIT MODE" Then
                connect()
                Dim CMD As New SqlCommand
                Dim DR As SqlDataReader
                MsgBox(frmBank.txtVrnofirst.Text & frmBank.txtVrNosec.Text)
                CMD = New SqlCommand("sELECT * FROM BANKT WHERE VRNO='" & frmBank.txtVrnofirst.Text & frmBank.txtVrNosec.Text & "'", cn)
                DR = CMD.ExecuteReader
                Dim D As Integer = 0
                While DR.Read
                    dgdetail.Rows.Add()
                    dgdetail.Item(0, D).Value = DR.Item("OUBNO")
                    dgdetail.Item(1, D).Value = Format(DR.Item("BILLDT"), "dd-MM-yyyy")
                    dgdetail.Item(4, D).Value = DR.Item("PAIDAMT")
                    dgdetail.Item(5, D).Value = DR.Item("DISCPER")
                    dgdetail.Item(6, D).Value = DR.Item("DISCOUNT")
                    dgdetail.Item(7, D).Value = DR.Item("RD")
                    dgdetail.Item(8, D).Value = DR.Item("CLAIM")
                    dgdetail.Item(10, D).Value = DR.Item("TDS")
                    dgdetail.Item(9, D).Value = DR.Item("TDSPER")
                    dgdetail.Item(11, D).Value = DR.Item("UNADAMT")
                    dgdetail.Item(12, D).Value = DR.Item("OUREMARK")
                    dgdetail.Item(13, D).Value = DR.Item("CRNTAMT")
                    dgdetail.Item(14, D).Value = DR.Item("DRNTAMT")
                    dgdetail.Item(15, D).Value = DR.Item("BKNAME")
                    dgdetail.Item(16, D).Value = DR.Item("BKCODE")
                    dgdetailcopy.Rows.Add()
                    dgdetailcopy.Item(0, D).Value = DR.Item("OUBNO")
                    dgdetailcopy.Item(1, D).Value = Format(DR.Item("BILLDT"), "dd-MM-yyyy")
                    dgdetailcopy.Item(4, D).Value = DR.Item("PAIDAMT")
                    dgdetailcopy.Item(5, D).Value = DR.Item("DISCPER")
                    dgdetailcopy.Item(6, D).Value = DR.Item("DISCOUNT")
                    dgdetailcopy.Item(7, D).Value = DR.Item("RD")
                    dgdetailcopy.Item(8, D).Value = DR.Item("CLAIM")
                    dgdetailcopy.Item(9, D).Value = DR.Item("TDS")
                    dgdetailcopy.Item(10, D).Value = DR.Item("TDSPER")
                    dgdetailcopy.Item(11, D).Value = DR.Item("UNADAMT")
                    dgdetailcopy.Item(12, D).Value = DR.Item("OUREMARK")
                    dgdetailcopy.Item(13, D).Value = DR.Item("CRNTAMT")
                    dgdetailcopy.Item(14, D).Value = DR.Item("DRNTAMT")
                    dgdetailcopy.Item(15, D).Value = DR.Item("BKNAME")
                    dgdetailcopy.Item(16, D).Value = DR.Item("BKCODE")
                    D = D + 1
                End While
                DR.Close()
                close1()
                frmBank.deletecode()
                FINDNETAMT()
                FINDNETAMT2()
                cal()
                caldiff()
            End If
            connect()
            da = New SqlDataAdapter("Select CONVERT(varchar,billdt,105) BillDate,OubNo,NetAmt,OutAmt,Ispaid,BKName,Bkcode,BILLNO AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from tblPurchase where Namecr='" & frmBank.txtAcName.Text & "' and Ispaid='f' UNION Select CONVERT(varchar,Date,105) Date,OubNo,NetAmt,OutAmt,Ispaid,BKName,Bkcode,SUBSTRING(OUBNO,4,LEN(OUBNO)) AS BILLNO,CONVERT(INT,SUBSTRING(OUBNO,1,2)) AS YEAR from tblOub where Book='Purchase' and Ispaid='f' AND ACNAME='" & frmBank.txtAcName.Text & "' ORDER BY YEAR,BILLNO", cn)
            da.Fill(ds)
            dgbill.DataSource = ds.Tables(0)
            Dim a As New DataGridViewCheckBoxColumn
            a.Name = "Check"
            a.HeaderText = "Checked"
            Label6.Text = frmBank.txtAmount.Text
            Label6copy.Text = frmBank.txtAmount.Text
            dgbill.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgbill.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgbill.Columns(8).Visible = False
            dgbill.Columns(7).Visible = False
            cmd = New SqlCommand("Select * from advpmt where acname='" & frmBank.txtAcName.Text & "' and isclear='f'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Label10.Text = dr.Item("Amount")
                Label10copy.Text = dr.Item("Amount")
            End While
            dr.Close()
            Label11.Text = Val(Label6.Text) + Val(Label10.Text)
            Label11copy.Text = Val(Label11.Text)
            TextBox2.Text = Val(Label11.Text)
            TextBox2copy.Text = Val(Label11.Text)
            cal()
            caldiff()
            dgbill.Columns.Add(a)
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
            For K = 0 To dgdetail.RowCount - 1
                BILLNO = dgdetail.Item(0, K).Value
                For J = 0 To dgbill.RowCount - 1
                    If dgbill.Item(1, J).Value = BILLNO Then
                        dgbill.Rows(J).DefaultCellStyle.ForeColor = Color.Red
                        dgbill.Rows(J).DefaultCellStyle.SelectionForeColor = Color.Red
                        dgbill.Item(dgbill.ColumnCount - 1, J).Value = True

                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub dg1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgbill.KeyDown
        If e.KeyCode = Keys.Space Then
            If dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True Then
                dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = False
            Else
                dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True
            End If
            If dgbill.Item(dgbill.ColumnCount - 1, dgbill.CurrentCell.RowIndex).Value = True Then
                '   If dg1.Item(2, dg1.CurrentCell.RowIndex).Value <= Val(TextBox2.Text) Then
                dgdetail.Rows.Add()
                dgdetail.Item(0, dgdetail.RowCount - 1).Value = dgbill.Item(1, dgbill.SelectedCells.Item(0).RowIndex).Value
                dgdetail.Item(1, dgdetail.RowCount - 1).Value = dgbill.Item(0, dgbill.SelectedCells.Item(0).RowIndex).Value
                dgdetail.Item(2, dgdetail.RowCount - 1).Value = Format(dgbill.Item(2, dgbill.SelectedCells.Item(0).RowIndex).Value, "0.00")
                dgdetail.Item(3, dgdetail.RowCount - 1).Value = Format(dgbill.Item(3, dgbill.SelectedCells.Item(0).RowIndex).Value, "0.00")
                dgdetail.Item(4, dgdetail.RowCount - 1).Value = Format(dgbill.Item(3, dgbill.SelectedCells.Item(0).RowIndex).Value, "0.00")
                dgdetail.Item(dgdetail.ColumnCount - 1, dgdetail.RowCount - 1).Value = dgbill.Item(dgbill.ColumnCount - 4, dgbill.SelectedCells.Item(0).RowIndex).Value
                dgdetail.Item(dgdetail.ColumnCount - 2, dgdetail.RowCount - 1).Value = dgbill.Item(dgbill.ColumnCount - 5, dgbill.SelectedCells.Item(0).RowIndex).Value
                TextBox2.Text = Val(TextBox2.Text) - dgdetail.Item(4, dgdetail.RowCount - 1).Value
                cal()
                'Else
                '   MsgBox("Bill amount is more than rec. amount")
                '  dg1.Item(dg1.ColumnCount - 1, dg1.SelectedCells.Item(0).RowIndex).Value = False
                ' GoTo en
                'End If
            Else
                For k = 0 To dgdetail.RowCount - 1
                    If dgdetail.Item(0, k).Value = dgbill.Item(1, dgbill.SelectedCells.Item(0).RowIndex).Value And dgdetail.Item(dgdetail.ColumnCount - 1, k).Value = dgbill.Item(dgbill.ColumnCount - 4, dgbill.SelectedCells.Item(0).RowIndex).Value Then
                        TextBox2.Text = Val(TextBox2.Text) + dgdetail.Item(3 + 1, k).Value
                        dgdetail.Rows.RemoveAt(k)
                        cal()
                        dgbill.Item(dgbill.ColumnCount - 1, dgbill.SelectedCells.Item(0).RowIndex).Value = False
                        GoTo en1
                    End If
                Next
            End If
en1:
            If dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True Then
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = dgbill.DefaultCellStyle.ForeColor
            End If
            If dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True Then
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Red
            Else
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
            End If

        ElseIf e.KeyCode = Keys.F2 Then
            Dim k As Integer
            For k = 0 To dgdetail.RowCount - 1
                If dgdetail.Item(0, k).Value = dgbill.Item(1, dgbill.SelectedCells.Item(0).RowIndex).Value And dgdetail.Item(dgdetail.ColumnCount - 1, k).Value = dgbill.Item(dgbill.ColumnCount - 4, dgbill.SelectedCells.Item(0).RowIndex).Value Then
                    TextBox2.Text = Val(TextBox2.Text) + dgdetail.Item(3 + 1, k).Value
                    dgdetail.Rows.RemoveAt(k)
                    cal()
                    dgbill.Item(dgbill.ColumnCount - 1, dgbill.SelectedCells.Item(0).RowIndex).Value = False
                    GoTo en2
                End If
            Next
en2:
            GroupBox1.BringToFront()
            txtdis.Focus()
        End If
en:
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
                disamt = Math.Round((Val(txtdis.Text) * dgbill.Item(3, dgbill.SelectedCells.Item(0).RowIndex).Value) / 100, 0)
            End If
            If Val(txttds.Text) > 0 Then
                tdsamt = Math.Round((Val(txttds.Text) * dgbill.Item(3, dgbill.SelectedCells.Item(0).RowIndex).Value) / 100, 0)
            End If
            If Val(txtldtds.Text) > 0 Then
                tdsldamt = Math.Round(Val(txtldtds.Text) * (dgbill.Item(3, dgbill.SelectedCells.Item(0).RowIndex).Value - disamt) / 100, 0)
            End If
            amt = Math.Round(dgbill.Item(3, dgbill.SelectedCells.Item(0).RowIndex).Value - (disamt + tdsamt + tdsldamt), 0)
            '   If Val(TextBox2.Text) >= amt Then
            If dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True Then
                dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = False
            Else
                dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True
            End If
            If dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True Then
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = dgbill.DefaultCellStyle.ForeColor
            End If
            If dgbill.Item(dgbill.Columns.Count - 1, dgbill.CurrentCell.RowIndex).Value = True Then
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.Red
            Else
                dgbill.Rows(dgbill.CurrentCell.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
            End If
            dgdetail.Rows.Add()
            dgdetail.Item(0, dgdetail.RowCount - 1).Value = dgbill.Item(1, dgbill.SelectedCells.Item(0).RowIndex).Value
            dgdetail.Item(1, dgdetail.RowCount - 1).Value = dgbill.Item(0, dgbill.SelectedCells.Item(0).RowIndex).Value
            dgdetail.Item(2, dgdetail.RowCount - 1).Value = dgbill.Item(2, dgbill.SelectedCells.Item(0).RowIndex).Value
            dgdetail.Item(3, dgdetail.RowCount - 1).Value = Format(dgbill.Item(3, dgbill.SelectedCells.Item(0).RowIndex).Value, "0.00")
            dgdetail.Item(4, dgdetail.RowCount - 1).Value = amt
            dgdetail.Item(5, dgdetail.RowCount - 1).Value = txtdis.Text
            dgdetail.Item(6, dgdetail.RowCount - 1).Value = disamt
            dgdetail.Item(dgdetail.ColumnCount - 1, dgdetail.RowCount - 1).Value = dgbill.Item(dgbill.ColumnCount - 4, dgbill.SelectedCells.Item(0).RowIndex).Value
            dgdetail.Item(dgdetail.ColumnCount - 2, dgdetail.RowCount - 1).Value = dgbill.Item(dgbill.ColumnCount - 5, dgbill.SelectedCells.Item(0).RowIndex).Value
            If txttds.Text > 0 Then
                dgdetail.Item(9, dgdetail.RowCount - 1).Value = txttds.Text
                dgdetail.Item(10, dgdetail.RowCount - 1).Value = tdsamt
            Else
                dgdetail.Item(9, dgdetail.RowCount - 1).Value = txtldtds.Text
                dgdetail.Item(10, dgdetail.RowCount - 1).Value = tdsldamt
            End If
            TextBox2.Text = Format(Val(TextBox2.Text) - amt, "0.00")
            cal()
            GroupBox1.SendToBack()
            dgbill.Focus()
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
        For k = 0 To dgdetail.RowCount - 1
            amt = amt + Val(dgdetail.Item(i, k).Value)
        Next
        tb.Text = Format(amt, "0.00")
    End Sub

    Private Sub dg2_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetail.CellValidated
        Try

            If e.ColumnIndex = 5 Then
                dgdetail.Item(6, e.RowIndex).Value = Math.Round(dgdetail.Item(3, e.RowIndex).Value * dgdetail.Item(5, e.RowIndex).Value / 100, 2)

                dgdetail.Item(4, e.RowIndex).Value = Math.Round(dgdetail.Item(3, e.RowIndex).Value - dgdetail.Item(6, e.RowIndex).Value - dgdetail.Item(7, e.RowIndex).Value - dgdetail.Item(8, e.RowIndex).Value - dgdetail.Item(10, e.RowIndex).Value, 2)
                cal()
                caldiff()
            ElseIf e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 10 Then

                dgdetail.Item(4, e.RowIndex).Value = Math.Round(dgdetail.Item(3, e.RowIndex).Value - dgdetail.Item(6, e.RowIndex).Value - dgdetail.Item(7, e.RowIndex).Value - dgdetail.Item(8, e.RowIndex).Value - dgdetail.Item(10, e.RowIndex).Value, 2)
                cal()
                caldiff()
            ElseIf e.ColumnIndex = 11 Then
                cal()
                dgdetail.Item(4, e.RowIndex).Value = Math.Round(dgdetail.Item(3, e.RowIndex).Value - dgdetail.Item(6, e.RowIndex).Value - dgdetail.Item(7, e.RowIndex).Value - dgdetail.Item(8, e.RowIndex).Value - dgdetail.Item(10, e.RowIndex).Value, 2)
                caldiff()
                dgdetail.Item(4, e.RowIndex).Value = Math.Round(dgdetail.Item(4, e.RowIndex).Value - dgdetail.Item(11, e.RowIndex).Value, 2)
                cal()
                caldiff()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub caldiff()
        Dim bal As Decimal
        For k = 0 To dgdetail.RowCount - 1
            bal = bal + dgdetail.Item(4, k).Value
        Next
        TextBox2.Text = Val(Label11.Text) - bal
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupBox1.SendToBack()
        dgbill.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Val(TextBox2.Text) > 0 Then
            If MsgBox("Bill is not adjected you want to extra amount as Advance or Unadjested", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                adv1 = 1
                Dim i As Integer
                frmBank.txtRemark.Clear()
                For i = 0 To dgdetail.RowCount - 1
                    frmBank.txtRemark.Text = frmBank.txtRemark.Text & dgdetail.Item(0, i).Value & ","
                Next
                Try
                    frmBank.txtRemark.Text = frmBank.txtRemark.Text.Substring(0, frmBank.txtRemark.Text.Length - 1)
                Catch ex As Exception

                End Try

                Me.Hide()
                frmBank.Show()
                frmBank.txtRemark.Focus()
            End If
            'advance
        ElseIf Val(TextBox2.Text) < 0 Then
            MsgBox("Your paid amount is more than bank/cash amount so please decrese your paid amount till difference became 0")
            'part

        Else
            MsgBox("You have successfully adjested the bill")
            Me.Hide()
            Dim i As Integer
            frmBank.txtRemark.Clear()
            For i = 0 To dgdetail.RowCount - 1
                frmBank.txtRemark.Text = frmBank.txtRemark.Text & dgdetail.Item(0, i).Value & ","
            Next
            Try
                frmBank.txtRemark.Text = frmBank.txtRemark.Text.Substring(0, frmBank.txtRemark.Text.Length - 1)
            Catch ex As Exception

            End Try

            Me.Hide()
            frmBank.Show()
            frmBank.txtRemark.Focus()
        End If

    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdetail.CellContentClick

    End Sub

    Private Sub dg2_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgdetail.DefaultValuesNeeded


    End Sub

    Private Sub dg2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgdetail.RowsAdded
        dgdetail.Item(4, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(5, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(6, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(7, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(8, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(9, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(10, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(11, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(12, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(13, e.RowIndex).Value = Format(0.0, "0.00")
        dgdetail.Item(14, e.RowIndex).Value = Format(0.0, "0.00")
    End Sub

    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgbill.CellContentClick

    End Sub

    Private Sub MyDataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyDataGridView1.KeyDown
        If e.KeyCode = Keys.F9 Then
            MyDataGridView1.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmbillnopymt.Show()
    End Sub
End Class