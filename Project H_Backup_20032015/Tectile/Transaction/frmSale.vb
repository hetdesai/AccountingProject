Imports System.Data.SqlClient
Public Class frmSale
    Dim i As Integer = 0
    Dim tbcheck As Integer
    Dim editcheck As Integer = 0
    Public newac As Integer
    Public newit As Integer
    Dim VATCHECK As String
    Dim STOCKCCHECK As String
    Public billcheck As Integer
    Public billno As String = 0
    Dim check As Integer
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim selectfield As String
    Dim chcheck As Boolean = False
    '*********************************tax related***************************
    Private Sub acnamehandle(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        connect()
        da = New SqlDataAdapter(acm(sender.text), cn)
        da.Fill(ds)
        dgacm.Visible = True
        dgacm.DataSource = ds.Tables(0)
        dgacm.BringToFront()
        'DataGridView4.Top = sender.Top + 22
        'DataGridView4.Left = sender.Left
        dgacm.AutoResizeColumns()
        close1()
    End Sub
    '  Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox14.GotFocus, TextBox1.GotFocus, TextBox10.GotFocus, Button2.GotFocus, TextBox12.GotFocus, TextBox13.GotFocus, TextBox14.GotFocus, TextBox15.GotFocus, TextBox16.GotFocus, TextBox17.GotFocus, TextBox18.GotFocus, TextBox19.GotFocus, TextBox2.GotFocus, TextBox20.GotFocus, TextBox21.GotFocus, TextBox22.GotFocus, TextBox23.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus, TextBox7.GotFocus, TextBox8.GotFocus, TextBox9.GotFocus
    '     Try
    '        sender.BackColor = Color.LightSteelBlue
    '       sender.forecolor = Color.White
    '  Catch ex As Exception
    '     MsgBox(ex.ToString)
    'End Try
    'End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function totalnetamt() As Decimal
        Try
            Dim bal As New Decimal
            bal = txtNetAmt.Text
            Dim i As Integer
            For i = 0 To mydg1cal.Rows.Count - 1
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select * from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn)
                dr = cmd.ExecuteReader
                Dim ispost As String
                While dr.Read
                    ispost = dr.Item("ispost")
                End While
                dr.Close()
                If ispost.ToLower = "f" Then
                ElseIf ispost.ToLower = "t" Then
                    bal = bal - mydg1cal.Item(10, i).Value
                End If
            Next
            Return bal
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Private Sub taxinsert()
        Try

            Dim i As Integer
            Dim dat1 As New Date
            dat1 = maskbilldate.Text.ToString
            For i = 0 To mydg1cal.Rows.Count - 1
                Dim a1() As String = {txtVrnofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegCode.Text, txtBillNofirst.Text & txtBillNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, mydg1cal.Item(0, i).Value, mydg1cal.Item(1, i).Value, mydg1cal.Item(2, i).Value, mydg1cal.Item(3, i).Value, mydg1cal.Item(4, i).Value, mydg1cal.Item(5, i).Value, mydg1cal.Item(6, i).Value, mydg1cal.Item(7, i).Value, mydg1cal.Item(8, i).Value, mydg1cal.Item(9, i).Value, mydg1cal.Item(10, i).Value, mydg1cal.Item(11, i).Value, mydg1cal.Item(12, i).Value, mydg1cal.Item(13, i).Value, mydg1cal.Item(14, i).Value}
                myinsert(a1, "saltax")
            Next
            Dim a() As String = {txtVrnofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegCode.Text, txtBillNofirst.Text & txtBillNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, "Sale", comInvoiceType.Text, "Gr Amt", "false", "0", "xxx", "0", "0", "0", "0", Val(txtGrAmt.Text), "Z", "0", "0", "0"}
            myinsert(a, "SALTAX")
            Dim b() As String = {txtVrnofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegCode.Text, txtBillNofirst.Text & txtBillNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, "Sale", comInvoiceType.Text, "Net Amt", "false", "0", "xxx", "0", "0", "0", "0", Val(txtNetAmt.Text), "Z", "0", "0", "0"}
            myinsert(b, "SALTAX")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub posting()
        Try
            Dim amt As Decimal = 0.0

            Dim k As Integer = 0
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = maskchdt.Text.ToString
            dat2 = maskbilldate.Text.ToString
            maxVrNo(txtJvVrNo, "tblJour")
            Dim i As Integer
            For i = 0 To mydg1cal.Rows.Count - 1
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select * from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn)
                dr = cmd.ExecuteReader
                Dim ispost As String
                Dim poaccount As String
                Dim poaccode As Integer
                While dr.Read
                    ispost = dr.Item("ispost")
                    poaccode = dr.Item("pocode")
                    poaccount = dr.Item("poname")
                End While
                dr.Close()
                If ispost.ToUpper.Trim = "f".ToUpper.Trim Then
                ElseIf ispost.ToUpper.Trim = "t".ToUpper.Trim Then
                    amt = amt + mydg1cal.Item(10, i).Value
                    If mydg1cal.Item(10, i).Value <> 0 Then
                        Dim b() As String = {acycode & "/" & txtJvVrNo.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, k + 1, "CR", poaccount, poaccode, mydg1cal.Item(10, i).Value, 0.0, txtBillNofirst.Text & txtBillNosec.Text, "JVSL"}
                        myinsert(b, "tblJour")
                        Dim a() As String = {acycode & "/" & txtJvVrNo.Text, "JVSL", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, poaccode, poaccount, 0.0, mydg1cal.Item(10, i).Value, (mydg1cal.Item(10, i).Value), txtDescription.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcDr.Text, txtAccodedr.Text}
                        myinsert(a, "tblLedg")
                    End If
                    k = k + 1
                End If
            Next
            If amt <> 0 Then
                Dim v() As String = {acycode & "/" & txtJvVrNo.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, k + 1, "DR", txtAcCr.Text, txtAccodeCr.Text, 0.0, amt, txtBillNofirst.Text & txtBillNosec.Text & txtDescription.Text, "JVSL"}
                myinsert(v, "tblJour")
            Else
                txtJvVrNo.Text = 0
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim i As Integer
            txtNetAmt.Text = mydg1cal.Item(14, mydg1cal.Rows.Count - 1).Value
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ComboBox2_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comInvoiceType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If editcheck = 0 Then
                Try
                    Dim da As New SqlDataAdapter
                    Dim ds As New DataSet
                    connect()
                    da = New SqlDataAdapter("Select * from taxmst where tax='" & comInvoiceType.Text & "' and BkType='Sale'", cn)
                    da.Fill(ds, "tax")
                    mydg1cal.DataSource = ds.Tables(0)
                    mydg1cal.Columns(10).DefaultCellStyle.Format = "N2"
                    mydg1cal.Columns(14).DefaultCellStyle.Format = "N2"
                    mydg1cal.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    mydg1cal.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    close1()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf editcheck = 1 Then
                If MsgBox("You want to change tax", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Try
                        Dim da As New SqlDataAdapter
                        Dim ds As New DataSet
                        connect()
                        da = New SqlDataAdapter("Select * from taxmst where tax='" & comInvoiceType.Text & "' and BkType='Sale'", cn)
                        da.Fill(ds, "tax")
                        mydg1cal.DataSource = ds.Tables(0)
                        mydg1cal.Columns(10).DefaultCellStyle.Format = "N2"
                        mydg1cal.Columns(14).DefaultCellStyle.Format = "N2"
                        mydg1cal.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        mydg1cal.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        close1()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If

                End If
            txtWorkNo.Focus()
            ' MaskedTextBox2.Focus()
        ElseIf (e.Modifiers And Keys.Shift) = Keys.Shift And e.KeyCode = Keys.Tab Then
            comSaleType.Focus()
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter("Select * from taxmst where tax='" & comInvoiceType.Text & "'", cn)
            da.Fill(ds, "tax")
            mydg1cal.DataSource = ds.Tables(0)
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub MyDataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mydg1cal.CellValidated
        Try
            If e.ColumnIndex = 4 Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                i = e.RowIndex
                cmd = New SqlCommand("Select Al,onwhich,optype from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn)
                dr = cmd.ExecuteReader
                Dim amt As New Decimal
                While dr.Read
                    If dr.Item("optype").ToString.ToUpper = "per".ToUpper Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            If VATCHECK = "FALSE" Then
                                amt = (mydg1cal.Item(4, i).Value * txtGrAmt.Text) / 100
                            Else
                                amt = Math.Round((mydg1cal.Item(4, i).Value * txtGrAmt.Text) / 100, 0)
                            End If

                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = mydg1cal.Item(14, c).Value
                                End If
                            Next
                            If VATCHECK = "FALSE" Then
                                amt = (mydg1cal.Item(4, i).Value * value) / 100
                            Else
                                amt = Math.Round((mydg1cal.Item(4, i).Value * value) / 100, 0)
                            End If

                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + value
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = value - amt
                                End If

                            End If

                        End If
                    ElseIf dr.Item("optype").ToString.ToUpper.Trim = "fixed".ToUpper.Trim Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            amt = (mydg1cal.Item(4, i).Value)

                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = mydg1cal.Item(14, c).Value
                                End If
                            Next
                            amt = (mydg1cal.Item(4, i).Value)
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + value
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = value - amt
                                End If
                            End If
                        End If
                    End If
                End While
                dr.Close()
                close1()
            ElseIf e.ColumnIndex = 10 Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                i = e.RowIndex
                cmd = New SqlCommand("Select Al,onwhich,optype from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn)
                dr = cmd.ExecuteReader
                Dim amt As New Decimal
                While dr.Read
                    If dr.Item("optype").ToString.ToUpper = "per".ToUpper Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            If VATCHECK = "FALSE" Then
                                amt = mydg1cal.Item(10, i).Value
                            Else
                                amt = Math.Round(mydg1cal.Item(10, i).Value, 0)
                            End If
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = mydg1cal.Item(14, c).Value
                                End If
                            Next
                            amt = mydg1cal.Item(10, i).Value
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + value
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = value - amt
                                End If

                            End If

                        End If
                    ElseIf dr.Item("optype").ToString.ToUpper.Trim = "fixed".ToUpper.Trim Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            amt = mydg1cal.Item(10, i).Value
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = mydg1cal.Item(14, c).Value
                                End If
                            Next
                            amt = mydg1cal.Item(10, i).Value
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + value
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = value - amt
                                End If
                            End If
                        End If
                    End If
                End While
                dr.Close()
                close1()
            End If
            If e.RowIndex = mydg1cal.RowCount - 1 Then
                netamtcal()
            Else
                arrange(e.RowIndex + 1)
            End If

            If e.ColumnIndex = 10 Or e.ColumnIndex = 14 Then
                If e.ColumnIndex = 10 Or e.ColumnIndex = 14 Then
                    mydg1cal.CurrentCell.Value = Convert.ToDecimal(mydg1cal.CurrentCell.Value)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub arrange(ByVal j As Integer)
        Dim i As Integer
        For i = j To mydg1cal.Rows.Count - 1
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            cmd = New SqlCommand("Select Al,onwhich,optype from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn)
            dr = cmd.ExecuteReader
            Dim amt As New Decimal
            While dr.Read
                If dr.Item("optype").ToString.ToUpper = "per".ToUpper Then
                    If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                        If VATCHECK = "FALSE" Then
                            amt = (mydg1cal.Item(4, i).Value * txtGrAmt.Text) / 100
                        Else
                            amt = Math.Round((mydg1cal.Item(4, i).Value * txtGrAmt.Text) / 100, 0)
                        End If

                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                            Else
                                mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                            End If

                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                            Else
                                mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                            End If

                        End If
                    Else
                        Dim onwhich As String
                        onwhich = dr.Item("Onwhich").ToString
                        Dim c As Integer
                        Dim value As Decimal
                        For c = 0 To mydg1cal.Rows.Count - 1
                            If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                value = mydg1cal.Item(14, c).Value
                            End If
                        Next
                        If VATCHECK = "FALSE" Then
                            amt = (mydg1cal.Item(4, i).Value * value) / 100
                        Else
                            amt = Math.Round((mydg1cal.Item(4, i).Value * value) / 100, 0)
                        End If
                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                            Else
                                mydg1cal.Item(14, i).Value = amt + value
                            End If
                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                            Else
                                mydg1cal.Item(14, i).Value = value - amt
                            End If

                        End If
                    End If
                ElseIf dr.Item("optype").ToString.ToUpper.Trim = "fixed".ToUpper.Trim Then
                    If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                        amt = (mydg1cal.Item(4, i).Value)

                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                            Else
                                mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                            End If

                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                            Else
                                mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                            End If

                        End If
                    Else
                        Dim onwhich As String
                        onwhich = dr.Item("Onwhich").ToString
                        Dim c As Integer
                        Dim value As Decimal
                        For c = 0 To mydg1cal.Rows.Count - 1
                            If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                value = mydg1cal.Item(14, c).Value
                            End If
                        Next
                        amt = (mydg1cal.Item(4, i).Value)
                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                            Else
                                mydg1cal.Item(14, i).Value = amt + value
                            End If
                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                            Else
                                mydg1cal.Item(14, i).Value = value - amt
                            End If
                        End If
                    End If
                End If
            End While
            dr.Close()
            close1()

        Next
        netamtcal()
    End Sub
    Private Sub maskBilldate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskbilldate.GotFocus, maskchdt.GotFocus
        sender.BackColor = Color.Yellow
    End Sub
    Private Sub maskBilldate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskbilldate.LostFocus, maskchdt.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            txtGrAmt.Text = Convert.ToDecimal(TotalAmount)
            '  If editcheck = 0 Then
            'gridsetup()
            '  cal()
            ' ElseIf editcheck = 1 and Then
            ' cal()
            ' End If
            If txtGrAmt.Text = TextBox24.Text And txtGrAmt.Text.Trim.Length <> 0 Then
            Else
                gridsetup()
                cal()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub cal()
        Try
            Dim i As Integer
            For i = 0 To mydg1cal.Rows.Count - 1
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                cmd = New SqlCommand("Select Al,onwhich,optype from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn)
                dr = cmd.ExecuteReader
                Dim amt As New Decimal
                While dr.Read
                    If dr.Item("optype").ToString.ToUpper = "per".ToUpper Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            If VATCHECK = "FALSE" Then
                                amt = (mydg1cal.Item(4, i).Value * txtGrAmt.Text) / 100
                            Else
                                amt = Math.Round((mydg1cal.Item(4, i).Value * txtGrAmt.Text) / 100, 0)
                            End If
                            mydg1cal.Item(10, i).Value = amt
                            '    MsgBox(MyDataGridView1.Item(4, i).Value)
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = mydg1cal.Item(14, c).Value
                                End If
                            Next
                            If VATCHECK = "FALSE" Then
                                amt = (mydg1cal.Item(4, i).Value * value) / 100
                            Else
                                amt = Math.Round((mydg1cal.Item(4, i).Value * value) / 100, 0)
                            End If

                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + value
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = value - amt
                                End If

                            End If

                        End If
                    ElseIf dr.Item("optype").ToString.ToUpper.Trim = "fixed".ToUpper.Trim Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            amt = (mydg1cal.Item(4, i).Value)

                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGrAmt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGrAmt.Text) - amt
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = mydg1cal.Item(14, c).Value
                                End If
                            Next
                            amt = (mydg1cal.Item(4, i).Value)
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + value
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = value - amt
                                End If

                            End If

                        End If


                    End If
                End While
                dr.Close()
                close1()

            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub gridsetup()
        Try
            ' MsgBox(TotalAmount)

            txtNetAmt.Text = txtGrAmt.Text
            mydg1cal.Focus()
            mydg1cal.Columns(0).Visible = False
            mydg1cal.Columns(1).Visible = False
            mydg1cal.Columns(3).Visible = False
            Dim i As Integer
            For i = 0 To mydg1cal.Rows.Count - 1
                If mydg1cal.Item(3, i).Value.ToString.ToUpper = "FalSe".ToUpper Then
                    mydg1cal.Item(4, i).ReadOnly = True
                    mydg1cal.Item(4, i).Style.ForeColor = Color.Red
                End If
            Next
            mydg1cal.Item(4, 0).Selected = True
            mydg1cal.Columns(5).Visible = False
            mydg1cal.Columns(6).Visible = False
            mydg1cal.Columns(7).ReadOnly = True
            mydg1cal.Columns(8).Visible = False
            mydg1cal.Columns(9).Visible = False
            mydg1cal.Columns(11).Visible = False
            mydg1cal.Columns(12).Visible = False
            mydg1cal.Columns(13).Visible = False
            mydg1cal.Columns(14).Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    '**************************************** Tax editing ends **********************************************************
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles maindg.CellEnter
        Try

            If e.ColumnIndex = 0 Then
                one(txtSrNo)
            ElseIf e.ColumnIndex = 1 Then
                one(TextBox31)
            ElseIf e.ColumnIndex = 2 Then
                one(txtITName)
            ElseIf e.ColumnIndex = 3 Then
                one(txtItcode)
            ElseIf e.ColumnIndex = 4 Then
                one(txtPcs)
            ElseIf e.ColumnIndex = 5 Then
                one(txtPack)
            ElseIf e.ColumnIndex = 6 Then
                one(txtQty)
            ElseIf e.ColumnIndex = 7 Then
                one(txtRate)
            ElseIf e.ColumnIndex = 8 Then
                one(txtUnit)
            ElseIf e.ColumnIndex = 9 Then
                one(txtAmount)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub one(ByRef tb As TextBox)
        Dim re As New Rectangle
        re = maindg.GetCellDisplayRectangle(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex, True)
        tb.Top = re.Top + 183
        tb.Left = re.Left + 5
        tb.BringToFront()
        txtSrNo.Text = maindg.Item(0, maindg.CurrentCell.RowIndex).Value
        TextBox31.Text = maindg.Item(1, maindg.CurrentCell.RowIndex).Value
        txtITName.Text = maindg.Item(2, maindg.CurrentCell.RowIndex).Value
        txtItcode.Text = maindg.Item(3, maindg.CurrentCell.RowIndex).Value
        txtPcs.Text = maindg.Item(4, maindg.CurrentCell.RowIndex).Value
        txtPack.Text = maindg.Item(5, maindg.CurrentCell.RowIndex).Value
        txtQty.Text = maindg.Item(6, maindg.CurrentCell.RowIndex).Value
        txtRate.Text = maindg.Item(7, maindg.CurrentCell.RowIndex).Value
        txtUnit.Text = maindg.Item(8, maindg.CurrentCell.RowIndex).Value
        txtAmount.Text = maindg.Item(9, maindg.CurrentCell.RowIndex).Value
        If txtPcs.Text.Trim.Length = 0 Then
            txtPcs.Text = 0.0
        End If
        If txtPack.Text.Trim.Length = 0 Then
            txtPack.Text = 0.0
        End If
        If txtQty.Text.Trim.Length = 0 Then
            txtQty.Text = 0.0
        End If
        If txtRate.Text.Trim.Length = 0 Then
            txtRate.Text = 0.0
        End If
        tb.Focus()
    End Sub
    Private Sub maxVrNo(ByRef tb As TextBox, ByVal ds As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            cmd = New SqlCommand("Select VrNo from " & ds, cn)
            dr = cmd.ExecuteReader
            Dim maxVrNo1 As Integer
            maxVrNo1 = 0
            Try
                While dr.Read
                    If maxVrNo1 < dr.Item("VrNo").ToString.Substring(3) Then
                        maxVrNo1 = dr.Item("VrNo").ToString.Substring(3)
                    End If
                End While
                dr.Close()
            Catch ex As Exception
                maxVrNo1 = 0
            End Try
            If tb.Name = "TextBox27" Then
                tb.Text = (maxVrNo1 + 1)
            Else
                tb.Text = (maxVrNo1 + 1)
            End If

            '    MsgBox(tb.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub enableall()
        maindg.Enabled = True
        dgItem.Enabled = True
        dgacm.Enabled = True
        txtSrNo.Enabled = True
        txtITName.Enabled = True
        txtItcode.Enabled = True
        txtPcs.Enabled = True
        txtPack.Enabled = True
        txtQty.Enabled = True
        txtRate.Enabled = True
        txtUnit.Enabled = True
        txtAmount.Enabled = True
        txtRegister.Enabled = True
        txtRegCode.Enabled = True
        txtAcDr.Enabled = True
        txtAccodedr.Enabled = True
        txtAcCr.Enabled = True
        txtAccodeCr.Enabled = True
        txtChno.Enabled = True
        txtBillNosec.Enabled = True
        txtGrAmt.Enabled = True
        txtBillNofirst.Enabled = True
        txtVrNosec.Enabled = True
        txtVrnofirst.Enabled = True
        txtDescription.Enabled = True
    End Sub
    Private Sub deasableall()
        maindg.Enabled = False

        dgItem.Enabled = False
        dgacm.Enabled = False
        txtSrNo.Enabled = False
        txtITName.Enabled = False
        txtItcode.Enabled = False
        txtPcs.Enabled = False
        txtPack.Enabled = False
        txtQty.Enabled = False
        txtRate.Enabled = False
        txtUnit.Enabled = False
        txtAmount.Enabled = False
        txtRegister.Enabled = False
        txtRegCode.Enabled = False
        txtAcDr.Enabled = False
        txtAccodedr.Enabled = False
        txtAcCr.Enabled = False
        txtAccodeCr.Enabled = False
        txtChno.Enabled = False
        txtBillNosec.Enabled = False
        txtGrAmt.Enabled = False
        txtBillNofirst.Enabled = False
        txtVrNosec.Enabled = False
        txtVrnofirst.Enabled = False
        txtDescription.Enabled = False

    End Sub
    Private Sub frmSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If frmzoom7.zoom = True Then
                frmzoom7.Close()
                frmzoom7.Show()
            End If
            If frmnewzoom4.zoom1 = True Then
                frmnewzoom4.Close()
                frmnewzoom4.Show()
            End If
            Me.Close()
        ElseIf e.KeyCode = Keys.F9 Then
            dg1.Width = 1000
            dg1.Height = 600
            dg1.BringToFront()
            dg1.Visible = True
            butFind.Visible = True
            dg1.Focus()
        End If
    End Sub
    Private Sub frmSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        connect()
        Dim CMD1 As New SqlCommand
        Dim DR1 As SqlDataReader
        CMD1 = New SqlCommand("sELECT VALUE FROM TBLSETUP WHERE BOOK='SALE' AND OPERATION='VATROUND'", cn)
        DR1 = CMD1.ExecuteReader
        While DR1.Read
            VATCHECK = DR1.Item(0)
        End While
        DR1.Close()
        CMD1 = New SqlCommand("sELECT VALUE FROM TBLSETUP WHERE BOOK='SALE' AND OPERATION='STOCKREQUIRED'", cn)
        DR1 = CMD1.ExecuteReader
        While DR1.Read
            STOCKCCHECK = DR1.Item(0)
        End While
        DR1.Close()
        CMD1 = New SqlCommand("select fields from tblselectfield where tablename='salesc'", cn)
        DR1 = CMD1.ExecuteReader
        While DR1.Read
            selectfield = DR1.Item(0).ToString.Substring(0, DR1.Item(0).ToString.Length - 1)
        End While
        DR1.Close()
        close1()

        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            deasableall()
            myfillCustome(txtUnit, "tblUnit", "Unit")
            txtBillNofirst.ReadOnly = True
            txtBillNofirst.Text = acycode & "/"
            txtVrnofirst.Text = acycode & "/"
            connect()
            Dim cmdtax As New SqlCommand
            Dim drtax As SqlDataReader
            cmdtax = New SqlCommand("select distinct tax from Taxmst where bktype='SALE'", cn)
            drtax = cmdtax.ExecuteReader
            While drtax.Read
                comInvoiceType.Items.Add(drtax.Item(0))
            End While
            drtax.Close()
            close1()
            ' MsgBox(frmMainScreen.bkname)
            If frmzoom7.zoom = True Then
                Dim cmd As New SqlCommand
                Dim drsale As SqlDataReader
                connect()
                Try
                    cmd = New SqlCommand("Select " & selectfield & " from Salesc where VrNo='" & frmzoom7.VrNo & "'", cn)
                    drsale = cmd.ExecuteReader
                    While drsale.Read
                        txtRegister.Text = drsale.Item("BkName")
                    End While
                    drsale.Close()
                    close1()

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
               ElseIf frmnewzoom4.zoom1 = True Then
                '  MsgBox(frmnewzoom4.VrNo)
                Dim cmd As New SqlCommand
                Dim drsale As SqlDataReader
                connect()
                Try
                    cmd = New SqlCommand("Select " & selectfield & " from salesc where VrNo='" & frmnewzoom4.VrNo & "'", cn)
                    drsale = cmd.ExecuteReader
                    While drsale.Read
                        txtRegister.Text = drsale.Item("BkName")
                        '      MsgBox("het")
                    End While
                    drsale.Close()
                    close1()

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
               
            Else
                txtRegister.Text = (frmMainScreen.sbkname)
            End If

            Dim dr As SqlDataReader
            dr = myconselect("tblAccount", txtRegister.Text, "ACName")
            While dr.Read
                txtRegCode.Text = dr.Item("ACCode")
            End While
            dr.Close()
            Dim dat1 As DateTime
            Dim dat2 As DateTime
            dat1 = dateyf.ToString
            'myfilldatagrid(DataGridView3, "Salesc")
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter("Select " & selectfield & " from Salesc Where BkName='" & txtRegister.Text & "' order by CONVERT(INT,BillNo) ", cn)
            da.Fill(ds)
            dg1.DataSource = ds.Tables(0)

            Try
                If frmnewzoom4.VrNo = "" Then
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                End If
            Catch ex As Exception

            End Try
            close1()
            maindg.Rows.Add()
            txtRegister.Focus()
            i = 1
            txtSrNo.ReadOnly = True
            txtItcode.ReadOnly = True
            txtAmount.ReadOnly = True
            txtSrNo.Width = 50
            txtITName.Width = 700
            txtItcode.Width = 50
            txtPcs.Width = 50
            txtPack.Width = 50
            txtQty.Width = 70
            txtRate.Width = 70
            txtUnit.Width = 40
            txtAmount.Width = 100
            TextBox31.Width = 100
            txtSrNo.Visible = True
            txtITName.Visible = True
            txtItcode.Visible = True
            txtPcs.Visible = True
            txtPack.Visible = True
            txtQty.Visible = True
            txtRate.Visible = True
            txtUnit.Visible = True
            txtAmount.Visible = True
            TextBox31.Visible = True
            If frmzoom7.zoom = True Then
                Dim cn As Integer
                For cn = 0 To dg1.Rows.Count - 1
                    If dg1.Item(0, cn).Value = frmzoom7.VrNo Then
                        dg1.Item(0, cn).Selected = True
                        GoTo en
                    End If
                Next
en:

            End If
            If frmnewzoom4.zoom1 = True Then
                Dim cn As Integer
                For cn = 0 To dg1.Rows.Count - 1
                    If dg1.Item(0, cn).Value = frmnewzoom4.VrNo Then
                        dg1.Item(0, cn).Selected = True
                        GoTo en1
                    End If
                Next
en1:

            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrNo.GotFocus, txtItcode.GotFocus, txtPcs.GotFocus, txtPack.GotFocus, txtQty.GotFocus, txtRate.GotFocus, txtUnit.GotFocus, txtAmount.GotFocus, TextBox31.GotFocus, txtShipTo.GotFocus, txtWorkNo.GotFocus, TextBox31.GotFocus, txtFind.GotFocus
        sender.backcolor = Color.Yellow
        txtSrNo.SendToBack()
        txtITName.SendToBack()
        txtItcode.SendToBack()
        txtPcs.SendToBack()
        txtPack.SendToBack()
        txtQty.SendToBack()
        txtRate.SendToBack()
        txtUnit.SendToBack()
        txtAmount.SendToBack()
        TextBox31.SendToBack()
        sender.BringtoFront()
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSrNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                maindg.CurrentCell.Value = txtSrNo.Text
                maindg.Item(1, maindg.CurrentCell.RowIndex).Selected = True
            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtSrNo.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtSrNo.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True
            ElseIf e.KeyCode = Keys.Tab Then
                'Button9.Focus()
                Try
                    Dim rowcount As Integer
                    Dim chcombo As New ComboBox
                    For rowcount = 0 To maindg.RowCount - 1
                        Try
                            If maindg.Item(maindg.Columns.Count - 1, rowcount).Value <> 0 And chcombo.Items.Contains(maindg.Item(maindg.Columns.Count - 1, rowcount).Value) = False Then
                                chcombo.Items.Add(maindg.Item(maindg.Columns.Count - 1, rowcount).Value)
                            End If

                        Catch ex As Exception

                        End Try
                    Next
                    If chcombo.Items.Count > 0 Then
                        txtChno.Clear()
                        For rowcount = 0 To chcombo.Items.Count - 1
                            txtChno.Text = txtChno.Text & chcombo.Items(rowcount) & ","
                        Next
                        txtChno.Text = txtChno.Text.Substring(0, txtChno.Text.Length - 1)
                    End If
                    '   If editcheck = 0 Then
                    'gridsetup()
                    'cal()
                    'ElseIf editcheck = 1 Then
                    'cal()
                    'End If
                    Dim cmd1 As New SqlCommand
                    Dim dr1 As SqlDataReader
                    Dim STRCHECK As String
                    connect()
                    cmd1 = New SqlCommand("Select value from tblsetup where BOOK='SALE' AND OPERATION='GRAMTCHANGE'", cn)
                    dr1 = cmd1.ExecuteReader
                    While dr1.Read
                        STRCHECK = dr1.Item("VALUE")
                    End While
                    dr1.Close()
                    If STRCHECK = "FALSE" Then
                        txtGrAmt.Enabled = False
                    Else
                        txtGrAmt.Enabled = True
                    End If
                    cmd1 = New SqlCommand("Select value from tblsetup where BOOK='SALE' AND OPERATION='GRAMTROUND'", cn)
                    dr1 = cmd1.ExecuteReader
                    While dr1.Read
                        STRCHECK = dr1.Item("VALUE")
                    End While
                    dr1.Close()
                    If STRCHECK = "FALSE" Then
                        txtGrAmt.Text = Convert.ToDecimal(TotalAmount)
                    Else
                        txtGrAmt.Text = Convert.ToDecimal(Math.Round(TotalAmount))
                    End If
                    close1()


                    If Val(txtGrAmt.Text) = Val(TextBox24.Text) And txtGrAmt.Text.Trim.Length <> 0 Then
                        If MsgBox("You want to change tax", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            gridsetup()
                            cal()
                        End If

                    Else
                        gridsetup()
                        cal()

                    End If
                    netamtcal()
                    mydg1cal.Focus()
                    Try
                        mydg1cal.Item(3, 0).Selected = True
                    Catch ex As Exception

                    End Try

                    '      TextBox29.Focus()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub TextBox31_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox31.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                maindg.CurrentCell.Value = TextBox31.Text
                maindg.Item(2, maindg.CurrentCell.RowIndex).Selected = True
            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = TextBox31.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = TextBox31.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If TextBox31.SelectionStart = TextBox31.Text.Length Then
                    maindg.CurrentCell.Value = TextBox31.Text
                    maindg.Focus()
                    txtITName.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If TextBox31.SelectionStart = 0 Or TextBox31.Text.Length = 0 Then
                    maindg.CurrentCell.Value = TextBox31.Text
                    maindg.Focus()
                    txtSrNo.Focus()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtITName.GotFocus
        Try
            sender.BringToFront()
            '    DataGridView2.Left = TextBox2.Left
            dgItem.Top = txtITName.Top + 22
            Dim cn As New SqlConnection
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\" & frmcomdis.companycode & "NewDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            cn.Open()
            da = New SqlDataAdapter("Select itcode,itname,ittype,itunit,rate from tblItem where ITName like '" & txtITName.Text & "%'", cn)
            da.Fill(ds)
            dgItem.DataSource = ds.Tables(0)
            dgItem.AutoResizeColumns()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPcs.KeyDown
        Try

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                maindg.CurrentCell.Value = txtPcs.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = False Then
                        dr.Close()
                        If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Else
                            GoTo en
                        End If
                    Else
                        While dr.Read
                            If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                                If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Else
                                    GoTo en
                                End If
                            End If
                        End While
                        dr.Close()
                    End If
                    close1()

                Else

                End If
                maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(5, maindg.CurrentCell.RowIndex).Selected = True
                txtPcs.SendToBack()
                maindg.Focus()
                txtPack.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtPcs.Text
                connect()

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If
                        End If
                    End While
                    dr.Close()
                    close1()

                Else
                End If

                maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True
            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtPcs.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If
                        End If
                    End While
                    dr.Close()
                    close1()
                Else
                End If

                maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtPcs.SelectionStart = txtPcs.Text.Length Or txtPcs.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtPcs.Text
                    connect()

                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    If STOCKCCHECK = "TRUE" Then
                        cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                                If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Else
                                    GoTo en
                                End If
                            End If
                        End While
                        dr.Close()
                        close1()

                    Else

                    End If

                    maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Item(5, maindg.CurrentCell.RowIndex).Selected = True
                    txtPcs.SendToBack()
                    maindg.Focus()
                    txtPack.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtPcs.SelectionStart = 0 Or txtPcs.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtPcs.Text
                    connect()
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    If STOCKCCHECK = "TRUE" Then
                        cmd = New SqlCommand("Select SUm(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                                If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Else
                                    GoTo en
                                End If
                            End If
                        End While
                        dr.Close()
                        close1()
                    Else

                    End If


                    maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Item(2, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Focus()
                    txtITName.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
en:
    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPack.KeyDown
        Try

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                maindg.CurrentCell.Value = txtPack.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If
                        End If
                    End While
                    dr.Close()
                    close1()

                Else

                End If

                maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(6, maindg.CurrentCell.RowIndex).Selected = True
                txtPcs.SendToBack()
                maindg.Focus()
                txtQty.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtPcs.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If

                        End If
                    End While
                    dr.Close()
                    close1()
                Else
                End If
                maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True
            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtPcs.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If
                        End If
                    End While
                    dr.Close()
                    close1()

                Else

                End If


                maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtPack.SelectionStart = txtPack.Text.Length Or txtPack.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtPack.Text
                    connect()
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    If STOCKCCHECK = "TRUE" Then
                        cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                                If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Else
                                    GoTo en
                                End If
                            End If
                        End While
                        dr.Close()
                        close1()

                    Else

                    End If


                    maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Item(6, maindg.CurrentCell.RowIndex).Selected = True
                    txtPcs.SendToBack()
                    maindg.Focus()
                    txtQty.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                ' MsgBox(TextBox5.SelectionStart)
                If txtPack.SelectionStart = 0 Or txtPack.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtPack.Text
                    connect()
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    If STOCKCCHECK = "TRUE" Then
                        cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            If maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                                If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Else
                                    GoTo en
                                End If
                            End If
                        End While
                        dr.Close()
                        close1()

                    Else

                    End If


                    maindg.Item(6, maindg.CurrentCell.RowIndex).Value = maindg.Item(4, maindg.CurrentCell.RowIndex).Value * maindg.Item(5, maindg.CurrentCell.RowIndex).Value
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Item(4, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Focus()
                    txtPcs.Focus()
                End If

            End If
        Catch ex As Exception

        End Try
en:
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        Try

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                maindg.CurrentCell.Value = txtQty.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(6, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If
                        End If
                    End While
                    dr.Close()
                    close1()

                Else

                End If
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(7, maindg.CurrentCell.RowIndex).Selected = True
                maindg.Focus()
                txtRate.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtQty.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(6, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If

                        End If
                    End While
                    dr.Close()
                    close1()

                Else

                End If


                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtQty.Text
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                If STOCKCCHECK = "TRUE" Then
                    cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        If maindg.Item(6, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                            If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Else
                                GoTo en
                            End If
                        End If
                    End While
                    dr.Close()
                    close1()

                Else

                End If


                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtQty.SelectionStart = txtQty.Text.Length Or txtQty.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtQty.Text
                    connect()
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    If STOCKCCHECK = "TRUE" Then
                        cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            If maindg.Item(6, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                                If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Else
                                    GoTo en
                                End If
                            End If
                        End While
                        dr.Close()
                        close1()

                    Else

                    End If


                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Item(7, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Focus()
                    txtRate.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Or txtQty.Text.Length = 0 Then
                If txtQty.SelectionStart = 0 Then

                    maindg.CurrentCell.Value = txtQty.Text
                    connect()
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    If STOCKCCHECK = "TRUE" Then
                        cmd = New SqlCommand("Select Sum(RQty)-Sum(DQty) from tblStock where ITName='" & maindg.Item(1, maindg.CurrentCell.RowIndex).Value & "' group by ITName", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            If maindg.Item(6, maindg.CurrentCell.RowIndex).Value > dr.Item(0) Then
                                If MsgBox("Not enough Qty", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Else
                                    GoTo en
                                End If

                            End If
                        End While
                        dr.Close()
                        close1()

                    Else

                    End If


                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Item(5, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Focus()
                    txtPack.Focus()
                End If
            End If

        Catch ex As Exception

        End Try
en:
    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                maindg.CurrentCell.Value = txtRate.Text
                maindg.Item(8, maindg.CurrentCell.RowIndex).Selected = True
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Focus()
                txtUnit.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtRate.Text
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtRate.Text
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Or txtRate.Text.Length = 0 Then
                If txtRate.SelectionStart = txtRate.Text.Length Then
                    maindg.CurrentCell.Value = txtRate.Text
                    maindg.Item(8, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Focus()
                    txtUnit.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtRate.SelectionStart = 0 Or txtRate.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtRate.Text
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Format(Val(maindg.Item(6, maindg.CurrentCell.RowIndex).Value * maindg.Item(7, maindg.CurrentCell.RowIndex).Value), "0.00")
                    maindg.Item(6, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Focus()
                    txtQty.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnit.KeyDown
        Try

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                '    DataGridView1.CurrentCell.Value = TextBox8.Text
                '   DataGridView1.Item(8, DataGridView1.CurrentCell.RowIndex).Selected = True
                '  DataGridView1.Focus()
                ' TextBox9.Focus()
                ' DataGridView1.Rows.Add()
                ' DataGridView1.Item(8, DataGridView1.CurrentCell.RowIndex).Value = TextBox9.Text
                ' DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex + 1).Selected = True
                ' TextBox1.Text = 1 + DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex - 1).Value
                ' DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value = TextBox1.Text
                ' TextBox1.Focus()
                ' DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Selected = True
                If maindg.Rows.Count < maindg.Item(0, maindg.SelectedCells.Item(0).RowIndex).Value + 1 Then
                    maindg.Rows.Add()
                End If
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = txtAmount.Text
                maindg.Item(0, maindg.CurrentCell.RowIndex + 1).Selected = True
                txtSrNo.Text = 1 + maindg.Item(0, maindg.CurrentCell.RowIndex - 1).Value
                maindg.Item(0, maindg.CurrentCell.RowIndex).Value = txtSrNo.Text
                txtSrNo.Focus()
                maindg.Item(0, maindg.CurrentCell.RowIndex).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtUnit.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtUnit.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtUnit.SelectionStart = txtUnit.Text.Length Or txtUnit.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtUnit.Text
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Focus()
                    txtAmount.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtUnit.SelectionStart = 0 Or txtUnit.Text.Length = 0 Then
                    maindg.CurrentCell.Value = txtUnit.Text
                    maindg.Item(7, maindg.CurrentCell.RowIndex).Selected = True
                    maindg.Focus()
                    txtRate.Focus()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPcs.KeyPress, txtPack.KeyPress, txtQty.KeyPress, txtRate.KeyPress
        Try
            If e.KeyChar >= "0" And e.KeyChar <= "9" = False Then
                If e.KeyChar = "." = False Then
                    e.Handled = True
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPcs.KeyUp
        If Val(txtPcs.Text) > 99999999 Then
            MsgBox("Not valid figure")
            txtPcs.Focus()
        End If
    End Sub

    Private Sub TextBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPcs.Leave

    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPack.KeyUp
        If Val(txtPack.Text) > 999999999999.99 Then
            MsgBox("Not valid figure")
            txtPack.Focus()
        End If
    End Sub
    Private Sub TextBox6_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyUp
        If Val(txtQty.Text) > 999999999999.999 Then
            MsgBox("Not valid figure")
            txtQty.Focus()
        End If
    End Sub

    Private Sub TextBox7_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyUp
        If Val(txtRate.Text) > 999999999999.999 Then
            MsgBox("Not valid figure")
            txtRate.Focus()
        End If
    End Sub

    Private Sub TextBox1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrNo.LocationChanged, txtITName.LocationChanged, txtItcode.LocationChanged, txtPcs.LocationChanged, txtPack.LocationChanged, txtQty.LocationChanged, txtRate.LocationChanged, txtUnit.LocationChanged, txtAmount.LocationChanged, TextBox31.LocationChanged
        txtSrNo.Top = sender.top
        txtITName.Top = sender.top
        txtItcode.Top = sender.top
        txtPcs.Top = sender.top
        txtPack.Top = sender.top
        txtQty.Top = sender.top
        txtRate.Top = sender.top
        txtUnit.Top = sender.top
        txtAmount.Top = sender.top
        TextBox31.Top = sender.top
        '    DataGridView2.Left = TextBox2.Left
        dgItem.Top = txtITName.Top + 22
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtITName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim itorcode As Integer = 0
                'DataGridView1.Rows.Add()
                Try
                    Try
                        connect()
                        Dim cmd As New SqlCommand
                        Dim drqty As SqlDataReader
                        cmd = New SqlCommand("select * from tblit2 where code='" & (txtITName.Text) & "'", cn)
                        drqty = cmd.ExecuteReader
                        While drqty.Read
                            txtPcs.Text = 1
                            txtPack.Text = 1
                            txtQty.Text = drqty.Item("qty")
                            txtRate.Text = drqty.Item("rate")
                            txtAmount.BringToFront()
                            txtAmount.Text = drqty.Item("RATE")
                            maindg.Item(2, maindg.CurrentCell.RowIndex).Value = drqty.Item("itname")
                            maindg.Item(2, maindg.CurrentCell.RowIndex).Value = drqty.Item("itname")
                            maindg.Item(4, maindg.CurrentCell.RowIndex).Value = 1
                            maindg.Item(5, maindg.CurrentCell.RowIndex).Value = 1
                            maindg.Item(6, maindg.CurrentCell.RowIndex).Value = txtQty.Text
                            maindg.Item(7, maindg.CurrentCell.RowIndex).Value = txtRate.Text
                            maindg.Item(9, maindg.CurrentCell.RowIndex).Value = Val(txtAmount.Text)
                            maindg.Item(9, maindg.CurrentCell.RowIndex).Selected = True
                            txtAmount.Visible = True
                            txtAmount.Focus()
                            dgItem.Visible = False
                            itorcode = 1
                            GoTo ene
                        End While
                        drqty.Close()
                        close1()

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
ene:
                    If itorcode = 1 Then
                        Try
                            connect()
                            Dim cmd As New SqlCommand
                            Dim dr4 As SqlDataReader
                            cmd = New SqlCommand("select itcode,itname,ittype,itunit,rate from tblItem where itname='" & maindg.Item(2, maindg.CurrentCell.RowIndex).Value & "'", cn)
                            dr4 = cmd.ExecuteReader
                            While dr4.Read
                                maindg.Item(3, maindg.CurrentCell.RowIndex).Value = dr4.Item("itcode")
                            End While
                            dr4.Close()
                            close1()
                            maindg.Rows.Add()
                            maindg.Item(9, maindg.CurrentCell.RowIndex).Value = txtAmount.Text
                            maindg.Item(2, maindg.CurrentCell.RowIndex + 1).Selected = True
                            txtSrNo.Text = 1 + maindg.Item(0, maindg.CurrentCell.RowIndex - 1).Value
                            maindg.Item(0, maindg.CurrentCell.RowIndex).Value = txtSrNo.Text
                            'TextBox2.Focus()
                            maindg.Item(0, maindg.CurrentCell.RowIndex).Selected = True
                            txtITName.Focus()

                            GoTo en
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                    txtITName.Text = dgItem.Item(1, 0).Value
                    '   If TextBox2.Text.Length = 0 Then
                    'If MsgBox("You want to insert a new Item", MsgBoxStyle.YesNo) = MsgBoxResult.Ok Then
                    'newit = 1
                    'frmITMaster.Show()
                    'Me.Hide()
                    'End If
                    ' End If
                    If txtITName.Text.Length = 0 Then
                        If MsgBox("You want to insert a new Item", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            newit = 1
                            frmITMaster.Show()
                            Me.Hide()
                        Else
                            GoTo en
                        End If

                    End If

                    maindg.Item(2, maindg.CurrentCell.RowIndex).Value = txtITName.Text
                    Dim dr As SqlDataReader
                    dr = myconselect("tblItem", txtITName.Text, "ITName")
                    While dr.Read
                        txtItcode.Text = dr.Item("ITCode")
                        maindg.Item(3, maindg.CurrentCell.RowIndex).Value = txtItcode.Text
                        txtRate.Text = dr.Item("Rate")
                        maindg.Item(7, maindg.CurrentCell.RowIndex).Value = txtRate.Text
                        txtUnit.Text = dr.Item("ITUnit")
                        maindg.Item(8, maindg.CurrentCell.RowIndex).Value = txtUnit.Text
                    End While
                    dr.Close()
                Catch ex As Exception
                    If txtITName.Text.Length = 0 Then
                        If MsgBox("You want to insert a new Item", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            newit = 1
                            frmITMaster.Show()
                            Me.Hide()
                        End If
                    End If

                End Try
                maindg.Item(4, maindg.CurrentCell.RowIndex).Selected = True
                maindg.Focus()
                dgItem.Visible = False
                txtPcs.Focus()
            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtITName.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                dgItem.Focus()
                maindg.Enabled = False
                dgItem.Item(0, 0).Selected = True
            ElseIf e.KeyCode = Keys.Left Then
                '      MsgBox("a")
                maindg.Item(1, maindg.CurrentCell.RowIndex).Selected = True
                TextBox31.Focus()
                dgItem.Visible = False
            ElseIf e.KeyCode = Keys.Tab Then
                dgItem.Visible = False
                '  MsgBox("d")
                'Button9.Focus()
                Try
                    '   If editcheck = 0 Then
                    'gridsetup()
                    'cal()
                    'ElseIf editcheck = 1 Then
                    'cal()
                    'End If
                    Dim cmd1 As New SqlCommand
                    Dim dr1 As SqlDataReader
                    Dim STRCHECK As String
                    connect()
                    cmd1 = New SqlCommand("Select value from tblsetup where BOOK='SALE' AND OPERATION='GRAMTCHANGE'", cn)
                    dr1 = cmd1.ExecuteReader
                    While dr1.Read
                        STRCHECK = dr1.Item("VALUE")
                    End While
                    dr1.Close()
                    If STRCHECK = "FALSE" Then
                        txtGrAmt.Enabled = False
                    Else
                        txtGrAmt.Enabled = True
                    End If
                    cmd1 = New SqlCommand("Select value from tblsetup where BOOK='SALE' AND OPERATION='GRAMTROUND'", cn)
                    dr1 = cmd1.ExecuteReader
                    While dr1.Read
                        STRCHECK = dr1.Item("VALUE")
                    End While
                    dr1.Close()
                    If STRCHECK = "FALSE" Then
                        txtGrAmt.Text = Convert.ToDecimal(TotalAmount)
                    Else
                        txtGrAmt.Text = Convert.ToDecimal(Math.Round(TotalAmount))
                    End If
                    close1()


                    If Val(txtGrAmt.Text) = Val(TextBox24.Text) And txtGrAmt.Text.Trim.Length <> 0 Then
                        If MsgBox("You want to change tax", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            gridsetup()
                            cal()
                        End If

                    Else
                        gridsetup()
                        cal()

                    End If
                    netamtcal()
                    txtDescription.Focus()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then

                maindg.CurrentCell.Value = txtItcode.Text
                maindg.Item(4, maindg.CurrentCell.RowIndex).Selected = True
                txtPcs.Focus()
                maindg.Focus()

            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtSrNo.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtSrNo.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        maindg.Rows.Add()
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtITName.KeyUp
        Try

            Dim cn As New SqlConnection
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            dgItem.Visible = True
            cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\" & frmcomdis.companycode & "NewDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            cn.Open()
            da = New SqlDataAdapter("Select itcode,itname,ittype,itunit,rate from tblItem where ITName like '" & txtITName.Text & "%'", cn)
            da.Fill(ds)
            dgItem.DataSource = ds.Tables(0)
            dgItem.AutoResizeColumns()
            dgItem.BringToFront()
            close1()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub DataGridView2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgItem.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                maindg.Enabled = True
                txtITName.Text = dgItem.Item(1, dgItem.SelectedCells(0).RowIndex).Value
                maindg.CurrentCell.Value = txtITName.Text
                Dim dr As SqlDataReader
                dr = myconselect("tblItem", txtITName.Text, "ITName")
                While dr.Read
                    txtItcode.Text = dr.Item("ITCode")
                    maindg.Item(3, maindg.CurrentCell.RowIndex).Value = txtItcode.Text
                    txtRate.Text = dr.Item("Rate")
                    maindg.Item(7, maindg.CurrentCell.RowIndex).Value = txtRate.Text
                    txtUnit.Text = dr.Item("ITUnit")
                    maindg.Item(8, maindg.CurrentCell.RowIndex).Value = txtUnit.Text
                End While
                dr.Close()
                maindg.Item(4, maindg.CurrentCell.RowIndex).Selected = True
                maindg.Focus()
                dgItem.Visible = False
                txtPcs.Focus()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If maindg.Rows.Count < maindg.Item(0, maindg.SelectedCells.Item(0).RowIndex).Value + 1 Then
                    maindg.Rows.Add()
                End If
                maindg.Rows.Add()
                maindg.Item(9, maindg.CurrentCell.RowIndex).Value = txtAmount.Text
                maindg.Item(2, maindg.CurrentCell.RowIndex + 1).Selected = True
                txtSrNo.Text = 1 + maindg.Item(0, maindg.CurrentCell.RowIndex - 1).Value
                maindg.Item(0, maindg.CurrentCell.RowIndex).Value = txtSrNo.Text
                'TextBox2.Focus()
                maindg.Item(0, maindg.CurrentCell.RowIndex).Selected = True
                txtSrNo.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                maindg.CurrentCell.Value = txtAmount.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                maindg.CurrentCell.Value = txtAmount.Text
                maindg.Item(maindg.CurrentCell.ColumnIndex, maindg.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtAmount.SelectionStart = txtAmount.Text.Length Then


                    maindg.Rows.Add()
                    maindg.Item(9, maindg.CurrentCell.RowIndex).Value = txtAmount.Text
                    maindg.Item(2, maindg.CurrentCell.RowIndex + 1).Selected = True
                    txtSrNo.Text = 1 + maindg.Item(0, maindg.CurrentCell.RowIndex - 1).Value
                    maindg.Item(0, maindg.CurrentCell.RowIndex).Value = txtSrNo.Text
                    txtITName.Focus()
                    maindg.Item(2, maindg.CurrentCell.RowIndex).Selected = True
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtAmount.SelectionStart = 0 Then
                    maindg.CurrentCell.Value = txtSrNo.Text
                    maindg.Item(maindg.CurrentCell.ColumnIndex - 1, maindg.CurrentCell.RowIndex).Selected = True
                    txtUnit.Focus()
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            connect()
            If MsgBox("You want to delete purchase entry for VrNo=" & txtVrnofirst.Text & txtVrNosec.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Delete from Salesc where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from Salec1 where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='Sales'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from salTax where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and BkName='" & txtRegister.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblStock where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='" & "Sales" & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where VrNo='" & txtJvVrNo.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLedg where VrNo='" & txtJvVrNo.Text & "' and book='JVSL'", cn)
                cmd.ExecuteNonQuery()

                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                connect()
                da = New SqlDataAdapter("Select " & selectfield & " from Salesc Where bkName='" & frmMainScreen.sbkname & "' ORDER BY CONVERT(INT,BillNo)", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                Try
                    dg1.Item(0, dg1.Rows.Count - 1).Selected = True
                Catch ex As Exception
                    clearall()
                End Try
                close1()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub clearall()
        txtSrNo.Clear()
        txtITName.Clear()
        txtItcode.Clear()
        txtPcs.Clear()
        txtPack.Clear()
        txtQty.Clear()
        txtRate.Clear()
        txtUnit.Clear()
        txtAmount.Clear()
        txtRegister.Clear()
        txtRegCode.Clear()
        txtAcDr.Clear()
        txtAccodedr.Clear()
        txtAcCr.Clear()
        txtAccodeCr.Clear()
        txtChno.Clear()
        txtBillNosec.Clear()
        txtGrAmt.Clear()
        txtBillNofirst.Clear()
        txtBillNosec.Clear()
        txtGrAmt.Clear()
        txtBillNofirst.Clear()
        txtVrNosec.Clear()
        txtVrnofirst.Clear()
        txtDescription.Clear()
        txtNetAmt.Clear()
        TextBox24.Clear()
        TextBox25.Clear()
        txtBillSr.Clear()
        txtJvVrNo.Clear()
        TextBox28.Clear()
        TextBox29.Clear()
        '   TextBox30.Clear()
        comSaleType.Text = ""
        comInvoiceType.Text = ""
        maindg.Rows.Clear()
    End Sub
    Private Function rowcount() As Integer
        Dim i, j As Integer
        Try
            For i = 0 To maindg.Rows.Count - 1
                If maindg.Item(0, i).Value = "" Then
                    GoTo en
                Else
                    j = j + 1
                End If
            Next
en:
            Return j

        Catch ex As Exception
            Return (j + 1)
        End Try
    End Function
    Private Function totalpcs()
        Dim i As Integer
        Dim max As Integer
        Try
            For i = 0 To maindg.Rows.Count - 1
                If maindg.Item(2, i).Value = "" Then

                End If
                max = i + 1
            Next

        Catch ex As Exception
            max = i
        End Try
        Dim amount As Integer
        For i = 0 To max - 1
            amount = amount + maindg.Item(4, i).Value
        Next
        Return amount

    End Function
    Private Function TotalAmount() As Decimal
        Try
            Dim i As Integer
            Dim max As Integer = 0
            Try
                For i = 0 To maindg.Rows.Count - 1
                    If maindg.Item(2, i).Value = "" Then

                    End If
                    max = i + 1
                Next

            Catch ex As Exception
                max = i
            End Try

            Dim amount As Decimal
            For i = 0 To max - 1
                amount = amount + maindg.Item(9, i).Value
            Next
            Return amount

        Catch ex As Exception

        End Try

    End Function
    Private Function totalqty() As Decimal
        Try
            Dim i As Integer
            Dim max As Integer = 0
            Try
                For i = 0 To maindg.Rows.Count - 1
                    If maindg.Item(2, i).Value = "" Then
                    End If
                    max = i + 1
                Next
            Catch ex As Exception
                max = i
            End Try

            Dim amount As Decimal
            For i = 0 To max - 1
                amount = amount + maindg.Item(6, i).Value
            Next
            Return amount

        Catch ex As Exception

        End Try
    End Function
    Private Function validat() As Boolean
        If txtAcDr.Text.Trim.Length = 0 Then
            MsgBox("Ac Dr can not be blank")
            txtAcDr.Focus()
            Return False
        ElseIf txtAccodedr.Text.Trim.Length = 0 Or Val(txtAccodedr.Text) = 0 Then
            MsgBox("Something wrong in Ac Dr ")
            txtAcDr.Focus()
            Return False
        ElseIf txtAccodeCr.Text.Trim.Length = 0 Or Val(txtAccodeCr.Text) = 0 Then
            MsgBox("Something wrong in Ac Cr ")
            txtAcCr.Focus()
            Return False
        ElseIf txtAcCr.Text.Trim.Length = 0 Then
            MsgBox("Ac Cr can not be blank")
            txtAcCr.Focus()
            Return False
        ElseIf comSaleType.Items.Contains(comSaleType.Text) = False Then
            MsgBox("Select sale type from list")
            comSaleType.Focus()
            Return False
        ElseIf comInvoiceType.Items.Contains(comInvoiceType.Text) = False Then
            MsgBox("Select invoice type from list")
            comInvoiceType.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click

        Try
            If validat() Then
            Else
                GoTo last
            End If
            Try
                If maindg.Item(9, 0).Value > 0 Then
                    '  MsgBox(DataGridView1.Rows.Count)

                Else
                    MsgBox("Enter atleast one detail entry")
                    txtITName.Focus()
                    GoTo last
                End If

            Catch ex As Exception
                MsgBox("Not valid entry")
                GoTo last
            End Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet

            If editcheck = 0 Then
                connect()
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                cmdcheck = New SqlCommand("Select * from salesc where vrno='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows = True Then
                    MsgBox("Duplicate VrNo")
                    drcheck.Close()
                    GoTo last
                Else
                    drcheck.Close()
                End If
                close1()
                Dim i As Integer
                Dim max As Integer = 0
                Try
                    For i = 0 To maindg.Rows.Count - 1
                        If maindg.Item(2, i).Value.ToString = "" Then

                        End If
                        '  If max < DataGridView1.Item(0, i).Value Then
                        'max = DataGridView1.Item(0, i).Value
                        'End If
                        max = i + 1
                    Next
                Catch ex As Exception
                    max = i
                End Try
                Dim dat1 As New Date
                Dim dat2 As New Date
                dat1 = maskchdt.Text.ToString
                dat2 = maskbilldate.Text.ToString
                Dim r As Integer
                Dim cmdit As New SqlCommand
                Dim drit As SqlDataReader
                '  r = max - 1
                For i = 0 To max - 1
                    Dim a() As String = {txtRegister.Text, txtRegCode.Text, txtChno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comSaleType.Text, maindg.Item(0, i).Value, maindg.Item(2, i).Value, maindg.Item(3, i).Value, maindg.Item(4, i).Value, maindg.Item(5, i).Value, maindg.Item(6, i).Value, maindg.Item(7, i).Value, maindg.Item(8, i).Value, maindg.Item(9, i).Value, txtVrnofirst.Text & txtVrNosec.Text, txtAccodedr.Text, txtAccodeCr.Text, maindg.Item(1, i).Value, maindg.Item(maindg.ColumnCount - 1, i).Value, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "TRADING"}
                    myinsert(a, "Salec1")
                    connect()
                    cmdit = New SqlCommand("Select ittype from tblItem where itcode=" & maindg.Item(3, i).Value.ToString, cn)
                    drit = cmdit.ExecuteReader
                    Dim ittype As String
                    While drit.Read
                        ittype = drit.Item(0)
                    End While
                    drit.Close()
                    close1()
                    Dim b1() As String = {dat2.Month & "-" & dat2.Day & "-" & dat2.Year, "Sales", txtVrnofirst.Text & txtVrNosec.Text, maindg.Item(2, i).Value, ittype, 0.0, 0.0, 0.0, maindg.Item(6, i).Value, maindg.Item(7, i).Value, maindg.Item(9, i).Value}
                    myinsert(b1, "tblStock")
                    '      MsgBox("Successful")
                Next
                posting()
                Dim c() As String = {txtVrnofirst.Text & txtVrNosec.Text, "Sales", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodeCr.Text, txtAcCr.Text, 0, totalnetamt(), (totalnetamt()), txtDescription.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcDr.Text, txtAccodedr.Text}
                myinsert(c, "tblLedg")
                Dim d() As String = {txtVrnofirst.Text & txtVrNosec.Text, "Sales", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodedr.Text, txtAcDr.Text, txtNetAmt.Text, 0, (Val(txtNetAmt.Text) * -1), txtDescription.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcCr.Text, txtAccodeCr.Text}
                myinsert(d, "tblLedg")
                taxinsert()
                '      Dim b() As String = {TextBox21.Text & TextBox20.Text, TextBox10.Text, TextBox11.Text, TextBox16.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, TextBox17.Text, TextBox19.Text & TextBox17.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, TextBox12.Text, TextBox14.Text, ComboBox1.Text, totalpcs(), totalqty(), TotalAmount(), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", TextBox26.Text, acycode & "/" & TextBox27.Text, TextBox23.Text, AmtInWord(TextBox23.Text), TextBox22.Text, TextBox13.Text, TextBox15.Text, Val(TextBox23.Text), "f"}
                '     myinsert(b, "Salesc")
                Dim b() As String = {txtVrnofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegCode.Text, txtChno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comSaleType.Text, totalpcs(), totalqty(), Val(txtGrAmt.Text), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", txtBillSr.Text, acycode & "/" & txtJvVrNo.Text, txtNetAmt.Text, AmtInWord(txtNetAmt.Text), txtDescription.Text, txtAccodedr.Text, txtAccodeCr.Text, Val(txtNetAmt.Text), "f", txtWorkNo.Text, txtShipTo.Text, 0, 0, 0, 0, 0, 0, 0, 0}
                myinsert(b, "Salesc")

                maxVrNo(txtVrNosec, "Salesc")
                Label17.Text = "SAVED"
                Timer1.Enabled = True
                connect()
                da = New SqlDataAdapter("Select " & selectfield & " from Salesc Where BkName='" & frmMainScreen.sbkname & "' ORDER BY CONVERT(INT,BillNo)", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                Try
                    dg1.Item(0, dg1.Rows.Count - 1).Selected = True
                Catch ex As Exception

                End Try

                butAdd.Focus()
                GoTo last
                '    MsgBox("Success")
            ElseIf editcheck = 1 Then
                Dim dat1 As New Date
                Dim dat2 As New Date
                dat1 = maskchdt.Text.ToString
                dat2 = maskbilldate.Text.ToString
                Dim i As Integer
                Dim max As Integer = 0
                Try
                    For i = 0 To maindg.Rows.Count - 1
                        If maindg.Item(2, i).Value.ToString = "" Then

                        End If
                        '  If max < DataGridView1.Item(0, i).Value Then
                        'max = DataGridView1.Item(0, i).Value
                        'End If
                        max = i + 1
                    Next

                Catch ex As Exception
                    max = i
                End Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                MsgBox("Delete from tblLedg where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='Sales'")
                connect()
                cmd = New SqlCommand("Delete from Salec1 where NameCr='" & txtAcCr.Text & "' and OubNo='" & txtBillNofirst.Text & txtBillNosec.Text & "' and bkname='" & txtRegister.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where VrNo='" & txtJvVrNo.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLedg where VrNo='" & txtJvVrNo.Text & "' and book='JVSL'", cn)
                cmd.ExecuteNonQuery()
                Try
                    cn.Open()
                Catch ex As Exception
                End Try
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='Sales'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from salTax where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and BkName='" & txtRegister.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblStock where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "' and Book='" & "Sales" & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where VrNo='" & txtJvVrNo.Text & "'", cn)
                cmd.ExecuteNonQuery()
                Try
                    cn.Close()
                Catch ex As Exception

                End Try
                taxinsert()
                posting()
                Dim c() As String = {txtVrnofirst.Text & txtVrNosec.Text, "Sales", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodeCr.Text, txtAcCr.Text, 0, totalnetamt(), (totalnetamt()), txtDescription.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcDr.Text, txtAccodedr.Text}
                myinsert(c, "tblLedg")
                Dim d() As String = {txtVrnofirst.Text & txtVrNosec.Text, "Sales", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodedr.Text, txtAcDr.Text, txtNetAmt.Text, 0, (Val(txtNetAmt.Text) * -1), txtDescription.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcCr.Text, txtAccodeCr.Text}
                myinsert(d, "tblLedg")
                close1()
                ' Dim r As Integer
                ' r = rowcount()
                '   MsgBox(r)
                '  Dim i As Integer
                Dim cmdit As New SqlCommand
                Dim drit As SqlDataReader
                For i = 0 To max - 1
                    Dim a() As String = {txtRegister.Text, txtRegCode.Text, txtChno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comSaleType.Text, maindg.Item(0, i).Value, maindg.Item(2, i).Value, maindg.Item(3, i).Value, maindg.Item(4, i).Value, maindg.Item(5, i).Value, maindg.Item(6, i).Value, maindg.Item(7, i).Value, maindg.Item(8, i).Value, maindg.Item(9, i).Value, txtVrnofirst.Text & txtVrNosec.Text, txtAccodedr.Text, txtAccodeCr.Text, maindg.Item(1, i).Value, maindg.Item(maindg.ColumnCount - 1, i).Value, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "TRADING"}
                    myinsert(a, "Salec1")
                    connect()
                    cmdit = New SqlCommand("Select ittype from tblItem where itcode=" & maindg.Item(3, i).Value.ToString, cn)
                    drit = cmdit.ExecuteReader
                    Dim ittype As String
                    While drit.Read
                        ittype = drit.Item(0)
                    End While
                    drit.Close()
                    close1()
                    Dim b1() As String = {dat2.Month & "-" & dat2.Day & "-" & dat2.Year, "Sales", txtVrnofirst.Text & txtVrNosec.Text, maindg.Item(2, i).Value, ittype, 0.0, 0.0, 0.0, maindg.Item(6, i).Value, maindg.Item(7, i).Value, maindg.Item(9, i).Value}
                    myinsert(b1, "tblStock")
                    ' MsgBox("Successful")
                Next
                Dim b() As String = {txtVrnofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegCode.Text, txtChno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comSaleType.Text, totalpcs(), totalqty(), Val(txtGrAmt.Text), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", txtBillSr.Text, acycode & "/" & txtJvVrNo.Text, txtNetAmt.Text, AmtInWord(txtNetAmt.Text), txtDescription.Text, txtAccodedr.Text, txtAccodeCr.Text, Val(txtNetAmt.Text), "f", txtWorkNo.Text, txtShipTo.Text, 0, 0, 0, 0, 0, 0, 0, 0}
                myupdate("Salesc", b, "VrNo", txtVrnofirst.Text & txtVrNosec.Text)
                Label17.Text = "EDITED"
                '       MsgBox("Successful")
            End If
            billno = txtBillNosec.Text
            '  frmsalebill.Close()
            '   frmsalebill.Show()

            '   Me.Hide()
            txtSrNo.SendToBack()
            txtITName.SendToBack()
            txtItcode.SendToBack()
            txtPcs.SendToBack()
            txtPack.SendToBack()
            txtQty.SendToBack()
            txtRate.SendToBack()
            txtUnit.SendToBack()
            txtAmount.SendToBack()
            '   Dim da As New SqlDataAdapter
            '  Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter("Select " & selectfield & " from Salesc Where BkName='" & frmMainScreen.sbkname & "' ORDER BY CONVERT(INT,BillNo)", cn)
            da.Fill(ds)
            dg1.DataSource = ds.Tables(0)
            Try
                dg1.Item(0, dg1.Rows.Count - 1).Selected = True
            Catch ex As Exception

            End Try
            butAdd.Enabled = True
            butEdit.Enabled = True

last:
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub TextBox12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcDr.KeyDown
        Try

            If e.KeyCode = Keys.Down Then
                tbcheck = 1
                dgacm.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                txtAcDr.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
                While dr.Read
                    txtAccodedr.Text = dr.Item("ACCode")
                End While
                dr.Close()
                If txtAcDr.Text = "" Then
                    If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        newac = 2
                        frmACMaster.Show()
                    Else
                        txtAcDr.Focus()
                    End If
                End If
                txtAcCr.Focus()
                dgacm.Visible = False
            ElseIf e.KeyCode = Keys.Up Then
                ' TextBox10.Focus()
            End If
        Catch ex As Exception
            If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                newac = 1
                frmACMaster.Show()
                Me.Hide()
            Else
                txtAcDr.Focus()
            End If

        End Try

    End Sub

    Private Sub TextBox14_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcCr.KeyDown
        Try

            If e.KeyCode = Keys.Down Then
                tbcheck = 2
                dgacm.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                txtAcCr.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
                While dr.Read
                    txtAccodeCr.Text = dr.Item("ACCode")
                End While
                dr.Close()
                comSaleType.Focus()
                dgacm.Visible = False
            ElseIf e.KeyCode = Keys.Up Then
                txtAcDr.Focus()
            End If
        Catch ex As Exception
            If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                newac = 2
                frmACMaster.Show()
                Me.Hide()
            Else
                txtAcDr.Focus()
            End If

        End Try

    End Sub

    Private Sub TextBox12_Up(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcDr.KeyUp, txtAcCr.KeyUp
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter(acm(sender.text), cn)
            da.Fill(ds)
            dgacm.Visible = True
            dgacm.DataSource = ds.Tables(0)
            dgacm.BringToFront()
            '   DataGridView4.Top = sender.Top + 22
            '  DataGridView4.Left = sender.Left
            dgacm.AutoResizeColumns()
            close1()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tbcheck = 1 Then
                txtAcDr.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
                While dr.Read
                    txtAccodedr.Text = dr.Item("ACCode")
                End While
                txtAcCr.Focus()
                dgacm.Visible = False
            End If
            If tbcheck = 2 Then
                txtAcCr.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
                While dr.Read
                    txtAccodeCr.Text = dr.Item("ACCode")
                End While

                comSaleType.Focus()
                dgacm.Visible = False
            End If
        End If
    End Sub

    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs)
        If sender.ToString = txtAcDr.ToString Then

        End If
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comSaleType.KeyDown
        If e.KeyCode = Keys.Enter Then
            '  TextBox16.Focus()
            comInvoiceType.Focus()
            If e.KeyCode = Keys.Up Then
                txtAcCr.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox16_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChno.KeyDown
        If e.KeyCode = Keys.Enter Then
            If chcheck = False Then
                maindg.Rows.Add()
                maindg.Item(0, 0).Selected = True
                maindg.Item(0, 0).Value = 1
                txtSrNo.Text = 1
                maindg.Item(1, 0).Selected = True
                'TextBox31.Focus()
            End If
            '  End If

        ElseIf e.KeyCode = Keys.Up Then
            maskbilldate.Focus()
        ElseIf e.KeyCode = Keys.F8 Then
            Try
                If editcheck = 0 Then
                    chlichno.Items.Clear()
                End If
                If chlichno.Items.Count = 0 Then
                    '   MsgBox("d")
                    connect()
                    Dim cmd As New SqlCommand("Select chno from ch1 where bkname='" & txtRegister.Text & "' and acname='" & txtAcDr.Text & "' and acnamecr='" & txtAcCr.Text & "' and chno not in (select ch from salec1 where bkname='" & txtRegister.Text & "')", cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader
                    chlichno.Items.Clear()
                    While dr.Read
                        chlichno.Items.Add(dr.Item(0))
                    End While
                    dr.Close()
                    close1()
                End If
                If editcheck = 1 Then
                    connect()
                    Dim i As Integer = 0
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    cmd = New SqlCommand("Select distinct ch from salec1 where vrno='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        i = i + 1
                        chlichno.Items.Add(dr.Item(0))
                    End While
                    Dim j As Integer
                    For j = 0 To i - 1
                        chlichno.SetItemChecked(chlichno.Items.Count - 1 - j, True)
                    Next
                    dr.Close()
                    close1()

                End If
                chlichno.Visible = True
                chlichno.Left = txtChno.Left
                chlichno.Top = txtChno.Top + 22
                chlichno.Focus()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


        End If
    End Sub



    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskchdt.GotFocus
        maskchdt.SelectionStart = 0
        maskchdt.SelectionLength = 0
    End Sub

    Private Sub MaskedTextBox1_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskchdt.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim dat As DateTime
                Dim dat1 As DateTime
                Dim dat2 As DateTime
                dat1 = dateyf.ToString
                dat2 = dateyl.ToString
                dat = maskchdt.Text.ToString
                If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                    txtBillNosec.Focus()
                End If
            ElseIf e.KeyCode = Keys.Up Then
                txtWorkNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub TextBox17_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillNosec.KeyDown
        If e.KeyCode = Keys.Enter Then
            If editcheck = 1 Then
                maskbilldate.Focus()
            Else
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select * from Salesc where BillNo='" & txtBillNosec.Text & "' and prefix='" & txtBillSr.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    MsgBox("Bill Already exits")
                    txtBillNosec.Focus()
                Else
                    maskbilldate.Focus()
                End If
                dr.Close()
                close1()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            maskchdt.Focus()
        End If
    End Sub



    Private Sub MaskedTextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskbilldate.GotFocus
        maskbilldate.SelectionLength = 0
        maskbilldate.SelectionStart = 0
    End Sub

    Private Sub MaskedTextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskbilldate.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim dat As DateTime
                Dim dat1 As DateTime
                Dim dat2 As DateTime
                dat1 = dateyf.ToString
                dat2 = dateyl.ToString
                dat = maskbilldate.Text.ToString
                '
                If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then

                    txtChno.Focus()
                End If
en:
            ElseIf e.KeyCode = Keys.Up Then
                txtBillNosec.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.RowEnter

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        Label17.Text = ""
        butAdd.Enabled = False
        editcheck = 1
        Label10.Text = "EDIT MODE"
        enableall()
        Try
            Dim dr As SqlDataReader
            Dim gramt As Decimal
            Dim netamt As Decimal
            '    MsgBox("het")
            dr = myconselect("Salesc", dg1.Item(0, dg1.CurrentCell.RowIndex).Value, "VrNo")
            While dr.Read
                txtRegister.Text = dr.Item("BkName")
                txtRegCode.Text = dr.Item("BkCode")
                txtChno.Text = dr.Item("ChNo")
                maskchdt.Text = Format(dr.Item("ChDt"), "dd-MM-yyyy")
                Dim dat As New Date
                dat = maskchdt.Text.ToString
                txtBillNosec.Text = dr.Item("BillNo")
                maskbilldate.Text = Format(dr.Item("BillDt"), "dd-MM-yyyy")
                dat = maskbilldate.Text.ToString
                txtAcDr.Text = dr.Item("Name")
                txtAcCr.Text = dr.Item("NameCr")
                txtVrNosec.Text = dr.Item("VrNo").ToString.Substring(3)
                comSaleType.Text = dr.Item("PurType")
                ' TextBox23.Text = dr.Item("NetAmt")
                txtJvVrNo.Text = dr.Item("JVVRNO")
                gramt = dr.Item("gramt")
                netamt = dr.Item("netamt")
                txtWorkNo.Text = dr.Item("workno")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
            While dr.Read
                txtAccodedr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
            While dr.Read
                txtAccodeCr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            connect()
            cmd = New SqlCommand("Select * from Salec1 where BillNo='" & txtBillNosec.Text & "' and NameCr='" & txtAcCr.Text & "' and bkname='" & txtRegister.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            maindg.Rows.Clear()
            While dr.Read
                maindg.Rows.Add()
                txtSrNo.Text = 1
                maindg.Item(0, i).Value = i + 1
                maindg.Item(1, i).Value = dr.Item("Itcode2")
                maindg.Item(2, i).Value = dr.Item("ITName")
                maindg.Item(3, i).Value = dr.Item("ITCode")
                maindg.Item(4, i).Value = dr.Item("Pcs")
                maindg.Item(5, i).Value = dr.Item("Pack")
                maindg.Item(6, i).Value = dr.Item("Qty")
                maindg.Item(7, i).Value = dr.Item("Rate")
                maindg.Item(8, i).Value = dr.Item("Unit")
                maindg.Item(9, i).Value = dr.Item("Amount")
                maindg.Item(10, i).Value = dr.Item("ch")
                i = i + 1
            End While
            dr.Close()
            close1()
            connect()
            chlichno.Items.Clear()
            Dim datax As New SqlDataAdapter
            Dim dstax As New DataSet
            datax = New SqlDataAdapter("Select  bktype,tax,taxnara,changable,value,poname,pocode,al,onwhich,optype,amt,taxindex,ispost,serialno,totalamt from salTax where VrNo='" & dg1.Item(0, dg1.CurrentCell.RowIndex).Value & "' order by taxIndex", cn)
            datax.Fill(dstax)
            mydg1cal.DataSource = dstax.Tables(0)
            Dim gramtcount As Integer
            ' TextBox18.Clear()
            '   For gramtcount = 0 To DataGridView1.Rows.Count - 1
            'TextBox18.Text = Val(TextBox18.Text) + DataGridView1.Item(DataGridView1.Columns.Count - 1, gramtcount).Value
            '   Next
            txtGrAmt.Text = gramt
            TextBox24.Text = txtGrAmt.Text
            'gridsetup2()
            Try
                comInvoiceType.Text = mydg1cal.Item(1, 0).Value
            Catch ex As Exception

            End Try
            txtNetAmt.Text = netamt
            mydg1cal.Rows.RemoveAt(mydg1cal.Rows.Count - 1)
            mydg1cal.Rows.RemoveAt(mydg1cal.Rows.Count - 1)
            mydg1cal.Columns(0).Visible = False
            mydg1cal.Columns(1).Visible = False
            mydg1cal.Columns(3).Visible = False
            Dim i1 As Integer
            For i1 = 0 To mydg1cal.Rows.Count - 1
                If mydg1cal.Item(3, i1).Value.ToString.ToUpper = "FalSe".ToUpper Then
                    mydg1cal.Item(4, i1).ReadOnly = True
                    mydg1cal.Item(4, i1).Style.ForeColor = Color.Red
                End If
            Next
            ' MyDataGridView1.Item(4+5, 0).Selected = True
            mydg1cal.Columns(5).Visible = False
            mydg1cal.Columns(6).Visible = False
            mydg1cal.Columns(7).ReadOnly = True
            mydg1cal.Columns(8).Visible = False
            mydg1cal.Columns(9).Visible = False
            mydg1cal.Columns(11).Visible = False
            mydg1cal.Columns(12).Visible = False
            mydg1cal.Columns(13).Visible = False
            mydg1cal.Columns(14).Visible = False
            close1()
            txtNetAmt.Text = netamt
            dgItem.Visible = False
            dgacm.Visible = False
            txtAcDr.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Label17.Text = ""
        butEdit.Enabled = False
        TextBox24.Clear()
        txtSrNo.Enabled = True
        enableall()
        editcheck = 0
        Label10.Text = "ADD MODE"
        txtSrNo.Clear()
        txtITName.Clear()
        txtItcode.Clear()
        txtPcs.Clear()
        txtPack.Clear()
        txtQty.Clear()
        txtRate.Clear()
        txtUnit.Clear()
        txtAmount.Clear()

        ' TextBox10.Clear()
        '  TextBox11.Clear()
        '   TextBox12.Clear()
        '   TextBox13.Clear()
        '  TextBox14.Clear()
        ' TextBox15.Clear()
        '  TextBox16.Clear()
        txtBillNosec.Clear()
        txtGrAmt.Clear()
        TextBox24.Clear()
        '   MaskedTextBox1.Clear()
        '  MaskedTextBox2.Clear()
        maindg.Rows.Clear()
        maxVrNo(txtVrNosec, "Salesc")
        If txtVrNosec.Text.Length = 0 Then
            txtVrNosec.Text = 1
        End If
        txtAcDr.Focus()
        txtSrNo.SendToBack()
        txtITName.SendToBack()
        txtItcode.SendToBack()
        txtPcs.SendToBack()
        txtPack.SendToBack()
        txtQty.SendToBack()
        txtRate.SendToBack()
        txtUnit.SendToBack()
        txtAmount.SendToBack()
        dgItem.Visible = False
        '   MaskedTextBox1.Text = Format(Date.Today, "dd-MM-yyyy")
        '  MaskedTextBox2.Text = Format(Date.Today, "dd-MM-yyyy")
        Try
            comSaleType.Text = comSaleType.Items(0)
            comInvoiceType.Text = comInvoiceType.Items(0)

        Catch ex As Exception

        End Try
        billnocount()
        connect()
        txtWorkNo.AutoCompleteCustomSource.Clear()
        Dim CMD As New SqlCommand
        Dim DR As SqlDataReader
        CMD = New SqlCommand("sELECT DISTINCT WORKNO FROM SALESC", cn)
        DR = CMD.ExecuteReader
        While DR.Read
            txtWorkNo.AutoCompleteCustomSource.Add(DR.Item(0))
        End While
        DR.Close()
        close1()

        '   ComboBox2.Focus()

    End Sub
    Private Sub MyDataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles mydg1cal.EditingControlShowing
        Try
            Dim editingControl As TextBox = TryCast(e.Control, TextBox)

            If editingControl IsNot Nothing Then
                AddHandler editingControl.KeyPress, AddressOf Me.KeyPress1
                '       IsHandleAdded = True
                RemoveHandler Me.mydg1cal.EditingControlShowing, AddressOf Me.MyDataGridView1_EditingControlShowing
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub KeyPress1(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            ' MsgBox(Asc(e.KeyChar))
            If Asc(e.KeyChar) = 8 Then
                GoTo last
            End If
            If e.KeyChar = "." Then
                If sender.Text.Contains(".") Then
                    e.Handled = True
                End If
            End If
            Dim i As Integer
            Dim check As Integer = 0
            Dim pos As Integer
            For i = 0 To sender.Text.Length - 1
                If sender.Text.Chars(i) = "." Then
                    pos = i
                    check = 1
                End If
            Next
            If check = 1 Then
                If (sender.Text.Substring(pos + 1).Length > 1) Then
                    ' MsgBox("het")
                    If sender.SelectionStart > pos Then
                        e.Handled = True
                    End If
                End If
            End If
            If (e.KeyChar <= "9" And e.KeyChar >= "0") Then
            ElseIf Asc(e.KeyChar) = 8 Then
            ElseIf e.KeyChar = "." Then

            Else
                e.Handled = True
            End If
last:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemove.Click
        Try
            Dim k As Integer = 1
            Dim i As Integer
            If maindg.Item(0, maindg.SelectedCells.Item(0).RowIndex).Selected = True Then
                maindg.Item(2, maindg.SelectedCells.Item(0).RowIndex).Selected = True
                k = 0
            End If
            i = maindg.SelectedCells.Item(0).RowIndex
            maindg.Rows.RemoveAt(i)
            For i = 0 To maindg.Rows.Count - 1
                maindg.Item(0, i).Value = i + 1
            Next
            If k = 0 Then
                maindg.Item(0, maindg.CurrentCell.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub billnocount()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim billsr As String
            Dim billno As Integer
            Dim maxbill As Integer = 0
            Dim place As Integer
            Dim yesno As String
            connect()
            cmd = New SqlCommand("Select billsr from tblAccount where ACcode=" & txtRegCode.Text, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                billsr = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select SRYN from tblAccount where ACCode=" & txtRegCode.Text, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                yesno = dr.Item(0).ToString.ToUpper
            End While
            dr.Close()
            If yesno = "YES" Then
                cmd = New SqlCommand("Select billNo from salesc where prefix like'" & billsr & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    maxbill = 0
                    dr.Close()
                    GoTo en
                Else
                    While dr.Read
                        If maxbill < dr.Item(0).ToString.Substring(billsr.Length) Then
                            maxbill = dr.Item(0).ToString.Substring(billsr.Length)
                        End If
                    End While
                    dr.Close()
                End If
en:
                cmd = New SqlCommand("Select MaxBill from tblAccount where BKCOde=" & txtRegCode.Text, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    place = dr.Item(0)
                End While
                dr.Close()
                Dim str1 As String
                str1 = maxbill + 1
                If place = 1 Then
                    GoTo last1
                End If
                If str1.ToString.Length < place Then
                    Dim k1 As Integer
                    For k1 = 0 To place - str1.ToString.Length - 1
                        str1 = "0" & str1
                    Next
                End If
last1:
                txtBillNosec.Text = billsr & str1
                close1()
            Else
                cmd = New SqlCommand("Select billNo from salesc where Prefix ='" & billsr & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    maxbill = 0
                    dr.Close()
                    GoTo en1
                Else
                    While dr.Read
                        If maxbill < dr.Item(0) Then
                            maxbill = dr.Item(0)
                        End If
                    End While
                    dr.Close()
                End If
en1:
                cmd = New SqlCommand("Select MaxBill from tblAccount where ACCOde=" & txtRegCode.Text, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    place = dr.Item(0)
                End While
                dr.Close()
                Dim str1 As String
                str1 = maxbill + 1
                If place = 1 Then
                    GoTo last
                End If
                If str1.ToString.Length < place Then
                    Dim k1 As Integer
                    For k1 = 0 To place - str1.ToString.Length - 1
                        str1 = "0" & str1
                    Next
                End If
last:
                txtBillNosec.Text = str1
            End If
            txtBillSr.Text = billsr

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox14_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcCr.KeyDown

    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        viewDatabse.Show()
        viewDatabse.TextBox1.Text = "Salesc"

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        viewDatabse.Show()
        viewDatabse.TextBox1.Text = "Salec1"
    End Sub

    Private Sub DataGridView1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles maindg.Scroll

    End Sub

    Private Sub DataGridView3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg1.Enter
        dgItem.Visible = False
    End Sub

    Private Sub Button3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Enter
        dgItem.Visible = False
    End Sub

    Private Sub Button1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Enter
        dgItem.Visible = False
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click

        If frmzoom7.zoom = True Then
            frmzoom7.Close()
            frmzoom7.Show()
        End If
        If frmnewzoom4.zoom1 = True Then
            frmnewzoom4.Close()
            frmnewzoom4.Show()
        End If
        Me.Close()
    End Sub
    Private Sub DataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles maindg.CellValidated
        Try
            If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Then
                maindg.CurrentCell.Value = Convert.ToDecimal(maindg.CurrentCell.Value)
            End If
            If e.ColumnIndex = 5 Then
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox22_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.GotFocus
        sender.BACKCOLOR = Color.Pink
        sender.FORECOLOR = Color.Black
    End Sub
    Private Sub TextBox22_LOSTFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.LostFocus
        sender.BACKCOLOR = Color.White
        sender.FORECOLOR = Color.Black
    End Sub
    Private Sub TextBox22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged

    End Sub
    Private Sub TextBox23_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles txtNetAmt.Invalidated
        Try
            numericform(txtNetAmt)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub netamtcal()
        Try
            Dim i As Integer
            Dim CMD1 As New SqlCommand
            Dim DR1 As SqlDataReader
            Dim STRCHECK As String
            txtNetAmt.Text = mydg1cal.Item(14, mydg1cal.Rows.Count - 1).Value
            txtNetAmt.Text = Format(Convert.ToDecimal(Val(txtNetAmt.Text)), "0.00")

            connect()
            CMD1 = New SqlCommand("sELECT VALUE FROM TBLSETUP WHERE BOOK='SALE' AND OPERATION='NETAMTROUND'", cn)
            DR1 = CMD1.ExecuteReader
            While DR1.Read
                STRCHECK = DR1.Item("VALUE")
            End While
            DR1.Close()
            If STRCHECK = "TRUE " Then
                txtNetAmt.Text = Format(Math.Round(Val(txtNetAmt.Text), 0), "0.00")
            Else
                txtNetAmt.Text = Format((Val(txtNetAmt.Text)), "0.00")
            End If
            CMD1 = New SqlCommand("sELECT VALUE FROM TBLSETUP WHERE BOOK='SALE' AND OPERATION='NETAMTCHANGE'", cn)
            DR1 = CMD1.ExecuteReader
            While DR1.Read
                STRCHECK = DR1.Item("VALUE")
            End While
            DR1.Close()
            If STRCHECK = "FALSE" Then
                txtNetAmt.Enabled = False
            Else
                txtNetAmt.Enabled = True
            End If
            close1()
            '  numericform(TextBox23)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub MyDataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mydg1cal.KeyDown
        If e.KeyCode = Keys.Tab Then
            Try
                Dim i As Integer
                txtNetAmt.Text = mydg1cal.Item(14, mydg1cal.Rows.Count - 1).Value
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            '    Button1.Focus()
            txtDescription.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles maindg.CellContentClick

    End Sub
    Private Function inwords(ByVal number As Decimal) As String
        Dim str As String
        Dim amt As String
        amt = "Only"
        str = number
        Dim check As Integer = 0
        If str.Chars(str.Length - 1) & str.Chars(str.Length - 2) = "50" Then
            amt = "Rupees Fifty paise" & amt
        Else
            amt = "Rupees Only"
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "01" Then
            amt = "One" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "02" Then
            amt = "Two" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "03" Then
            amt = "Three" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "04" Then
            amt = "Four" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "05" Then
            amt = "Five" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "06" Then
            amt = "Six" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "07" Then
            amt = "Seven" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "08" Then
            amt = "Eight" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "09" Then
            amt = "Nine" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "10" Then
            amt = "Ten" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "11" Then
            amt = "Eleven" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "12" Then
            amt = "Twelve" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "13" Then
            amt = "Thirteen" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "14" Then
            amt = "Fourteen" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "15" Then
            amt = "Fifteen" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "16" Then
            amt = "Sixteen" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "17" Then
            amt = "Seventeen" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "18" Then
            amt = "Eighteen" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "19" Then
            amt = "Nineteen" & amt
            check = 1
        End If
        If str.Chars(str.Length - 5) & str.Chars(str.Length - 4) = "20" Then
            amt = "Twenty" & amt
            check = 1
        End If
        If check <> 1 Then
            If str.Chars(str.Length - 4) = "1" Then
                amt = "One"
                ' ElseIf 
            End If
        End If
        Return amt
    End Function

    Private Sub MyDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mydg1cal.CellContentClick

    End Sub

    Private Sub TextBox22_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtShipTo.Focus()
        End If
    End Sub

    Private Sub MaskedTextbox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub UserControl12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MaskedTextBox2_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles maskbilldate.MaskInputRejected

    End Sub

    Private Sub UserControl12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub TextBox25_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox25.Enter
        Try
            'If e.KeyCode = Keys.Enter Then
            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime
            dat1 = dateyf.ToString
            dat2 = dateyl.ToString
            dat = maskbilldate.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) > 0 And DateDiff(DateInterval.Day, dat2, dat) < 0 Then
                maindg.Rows.Add()
                maindg.Item(0, 0).Selected = True
                maindg.Item(0, 0).Value = 1
                txtSrNo.Text = 1
                maindg.Item(1, 0).Selected = True
                txtITName.Focus()
            Else
                maskbilldate.Focus()
            End If
            '  ElseIf e.KeyCode = Keys.Up Then
            ' TextBox17.Focus()
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles maskchdt.MaskInputRejected

    End Sub

    Private Sub ComboBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comInvoiceType.KeyDown

    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comSaleType.Leave, comInvoiceType.Leave
        If sender.Items.Contains(sender.Text) = False Then
            MsgBox("Select from list")
            sender.Focus()
            MsgBox("het")
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click

    End Sub

    Private Sub frmSale_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comInvoiceType.SelectedIndexChanged

    End Sub

    Private Sub TextBox10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRegister.GotFocus, txtSrNo.GotFocus, txtRegCode.GotFocus, txtAcDr.GotFocus, txtAccodedr.GotFocus, txtAcCr.GotFocus, txtAccodeCr.GotFocus, txtChno.GotFocus, txtBillNosec.GotFocus, txtGrAmt.GotFocus, txtBillNofirst.GotFocus, txtVrNosec.GotFocus, txtVrnofirst.GotFocus, txtDescription.GotFocus, txtNetAmt.GotFocus, TextBox24.GotFocus, TextBox25.GotFocus, txtBillSr.GotFocus, txtJvVrNo.GotFocus, txtITName.GotFocus, comSaleType.GotFocus, comInvoiceType.GotFocus, maskchdt.GotFocus, maskbilldate.GotFocus, txtWorkNo.GotFocus, TextBox31.GotFocus, txtFind.GotFocus, txtShipTo.GotFocus
        sender.backcolor = Color.Yellow
        txtSrNo.SendToBack()
        txtITName.SendToBack()
        txtItcode.SendToBack()
        txtPcs.SendToBack()
        txtPack.SendToBack()
        txtQty.SendToBack()
        txtRate.SendToBack()
        txtUnit.SendToBack()
        txtAmount.SendToBack()
        sender.bringtofront()

    End Sub
    Private Sub TextBox122_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChno.GotFocus

    End Sub

    Private Sub TextBox112_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcDr.GotFocus
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter(acm(sender.text), cn)
            da.Fill(ds)
            dgacm.Visible = True
            dgacm.DataSource = ds.Tables(0)
            dgacm.BringToFront()
            '    DataGridView4.Top = sender.Top + 22
            '   DataGridView4.Left = sender.Left
            dgacm.AutoResizeColumns()
            close1()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox10_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRegister.LostFocus, txtSrNo.LostFocus, txtRegCode.LostFocus, txtAcDr.LostFocus, txtAccodedr.LostFocus, txtAcCr.LostFocus, txtAccodeCr.LostFocus, txtChno.LostFocus, txtBillNosec.LostFocus, txtGrAmt.LostFocus, txtBillNofirst.LostFocus, txtVrNosec.LostFocus, txtVrnofirst.LostFocus, txtDescription.LostFocus, txtNetAmt.LostFocus, TextBox24.LostFocus, TextBox25.LostFocus, txtBillSr.LostFocus, txtJvVrNo.LostFocus, txtITName.LostFocus, comSaleType.LostFocus, comSaleType.LostFocus, maskchdt.LostFocus, maskbilldate.LostFocus, txtFind.LostFocus, TextBox31.LostFocus, txtShipTo.LostFocus, txtWorkNo.LostFocus
        sender.backcolor = Color.White

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        '   Label17.Text = ""

    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles maindg.RowsAdded
        txtGrAmt.Text = ""
        txtGrAmt.Text = Math.Round(Val(TotalAmount))
        maindg.Item(maindg.ColumnCount - 1, e.RowIndex).Value = 0
    End Sub

    Private Sub TextBox29_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox29.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox28.Text = Val(TextBox29.Text) - Val(txtNetAmt.Text)
            txtDescription.Focus()
        End If
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles maindg.RowsRemoved
        txtGrAmt.Text = Math.Round(Val(TotalAmount))
    End Sub

    Private Sub TextBox23_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNetAmt.KeyDown
        txtDescription.Focus()
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskchdt.Leave
        Try

            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime

            dat1 = dateyf.ToString
            dat2 = dateyl.ToString
            dat = maskchdt.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                '  txtBillNosec.Focus()
            Else
                MsgBox("Please enter date in current year")
                maskchdt.Focus()
            End If


        Catch ex As Exception
            MsgBox("enter proper date")
            maskchdt.Focus()
        End Try
    End Sub

    Private Sub MaskedTextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskbilldate.Leave
        Try

            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime
            dat1 = dateyf
            dat2 = dateyl
            dat = maskbilldate.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                '        Try
                'DataGridView1.Rows.Add()
                '  Catch ex As Exception

                '     End Try

                '            Try
                'DataGridView1.Item(0, 0).Selected = True
                '   DataGridView1.Item(0, 0).Value = 1
                '  TextBox1.Text = 1
                ' Catch ex As Exception

                '   End Try
                Try
                    '              DataGridView1.Item(2, 0).Selected = True
                    '             TextBox2.Focus()

                Catch ex As Exception

                End Try
            Else
                MsgBox("Please enter date in current year")
                maskbilldate.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter proper date")
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        butSave.Enabled = True
        butDelete.Enabled = True
        butAdd.Enabled = True
        butEdit.Enabled = True
    End Sub

    Private Sub DataGridView3_CellEnter1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim dr As SqlDataReader
            Dim gramt As Decimal
            Dim netamt As Decimal
            '    MsgBox("het")
            dr = myconselect("Salesc", dg1.Item(0, e.RowIndex).Value, "VrNo")
            While dr.Read
                txtRegister.Text = dr.Item("BkName")
                txtRegCode.Text = dr.Item("BkCode")
                txtChno.Text = dr.Item("ChNo")
                maskchdt.Text = Format(dr.Item("ChDt"), "dd-MM-yyyy")
                Dim dat As New Date
                dat = maskchdt.Text.ToString
                txtBillNosec.Text = dr.Item("BillNo")
                maskbilldate.Text = Format(dr.Item("BillDt"), "dd-MM-yyyy")
                dat = maskbilldate.Text.ToString
                txtAcDr.Text = dr.Item("Name")
                txtAcCr.Text = dr.Item("NameCr")
                txtVrNosec.Text = dr.Item("VrNo").ToString.Substring(3)
                comSaleType.Text = dr.Item("PurType")
                ' TextBox23.Text = dr.Item("NetAmt")
                txtJvVrNo.Text = dr.Item("JVVRNO")
                gramt = dr.Item("gramt")
                netamt = dr.Item("netamt")
                txtWorkNo.Text = dr.Item("workno")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
            While dr.Read
                txtAccodedr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
            While dr.Read
                txtAccodeCr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            connect()
            cmd = New SqlCommand("Select * from Salec1 where BillNo='" & txtBillNosec.Text & "' and NameCr='" & txtAcCr.Text & "' and bkname='" & txtRegister.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            maindg.Rows.Clear()
            While dr.Read
                maindg.Rows.Add()
                txtSrNo.Text = 1
                maindg.Item(0, i).Value = i + 1
                maindg.Item(1, i).Value = dr.Item("Itcode2")
                maindg.Item(2, i).Value = dr.Item("ITName")
                maindg.Item(3, i).Value = dr.Item("ITCode")
                maindg.Item(4, i).Value = dr.Item("Pcs")
                maindg.Item(5, i).Value = dr.Item("Pack")
                maindg.Item(6, i).Value = dr.Item("Qty")
                maindg.Item(7, i).Value = dr.Item("Rate")
                maindg.Item(8, i).Value = dr.Item("Unit")
                maindg.Item(9, i).Value = dr.Item("Amount")
                maindg.Item(10, i).Value = dr.Item("ch")
                i = i + 1
            End While
            dr.Close()
            close1()
            connect()
            Dim datax As New SqlDataAdapter
            Dim dstax As New DataSet
            datax = New SqlDataAdapter("Select  bktype,tax,taxnara,changable,value,poname,pocode,al,onwhich,optype,amt,taxindex,ispost,serialno,totalamt from salTax where VrNo='" & dg1.Item(0, e.RowIndex).Value & "' order by taxIndex", cn)
            datax.Fill(dstax)
            mydg1cal.DataSource = dstax.Tables(0)
            Dim gramtcount As Integer
            ' TextBox18.Clear()
            '   For gramtcount = 0 To DataGridView1.Rows.Count - 1
            'TextBox18.Text = Val(TextBox18.Text) + DataGridView1.Item(DataGridView1.Columns.Count - 1, gramtcount).Value
            '   Next
            txtGrAmt.Text = gramt
            TextBox24.Text = txtGrAmt.Text
            'gridsetup2()
            Try
                comInvoiceType.Text = mydg1cal.Item(1, 0).Value
            Catch ex As Exception

            End Try
            txtNetAmt.Text = netamt
            Try
                mydg1cal.Rows.RemoveAt(mydg1cal.Rows.Count - 1)
                mydg1cal.Rows.RemoveAt(mydg1cal.Rows.Count - 1)

            Catch ex As Exception

            End Try
            mydg1cal.Columns(0).Visible = False
            mydg1cal.Columns(1).Visible = False
            mydg1cal.Columns(3).Visible = False
            Dim i1 As Integer
            For i1 = 0 To mydg1cal.Rows.Count - 1
                If mydg1cal.Item(3, i1).Value.ToString.ToUpper = "FalSe".ToUpper Then
                    mydg1cal.Item(4, i1).ReadOnly = True
                    mydg1cal.Item(4, i1).Style.ForeColor = Color.Red
                End If
            Next
            ' MyDataGridView1.Item(4+5, 0).Selected = True
            mydg1cal.Columns(5).Visible = False
            mydg1cal.Columns(6).Visible = False
            mydg1cal.Columns(7).ReadOnly = True
            mydg1cal.Columns(8).Visible = False
            mydg1cal.Columns(9).Visible = False
            mydg1cal.Columns(11).Visible = False
            mydg1cal.Columns(12).Visible = False
            mydg1cal.Columns(13).Visible = False
            mydg1cal.Columns(14).Visible = False
            close1()
            'TextBox23.Text = DataGridView3.Item(DataGridView3.ColumnCount - 7, e.RowIndex).Value
            txtNetAmt.Text = netamt
            dgItem.Visible = False
            dgacm.Visible = False
            txtSrNo.Enabled = False
            dg1.Focus()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox18_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGrAmt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim cmd1 As New SqlCommand
                Dim dr1 As SqlDataReader
                Dim STRCHECK As String
                connect()
                cmd1 = New SqlCommand("Select value from tblsetup where BOOK='SALE' AND OPERATION='GRAMTCHANGE'", cn)
                dr1 = cmd1.ExecuteReader
                While dr1.Read
                    STRCHECK = dr1.Item("VALUE")
                End While
                dr1.Close()
                If STRCHECK = "FALSE" Then
                    txtGrAmt.Enabled = False
                Else
                    txtGrAmt.Enabled = True
                End If
                cmd1 = New SqlCommand("Select value from tblsetup where BOOK='SALE' AND OPERATION='GRAMTROUND'", cn)
                dr1 = cmd1.ExecuteReader
                While dr1.Read
                    STRCHECK = dr1.Item("VALUE")
                End While
                dr1.Close()
                '   If STRCHECK = "FALSE" Then
                '       TextBox18.Text = Convert.ToDecimal(TotalAmount)
                '  Else
                '     TextBox18.Text = Convert.ToDecimal(Math.Round(TotalAmount))
                '    End If
                close1()


                If Val(txtGrAmt.Text) = Val(TextBox24.Text) And txtGrAmt.Text.Trim.Length <> 0 Then
                    If MsgBox("You want to change tax", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        gridsetup()
                        cal()
                    End If

                Else
                    gridsetup()
                    cal()
                End If
                netamtcal()
                mydg1cal.Focus()
                Try
                    mydg1cal.Item(3, 0).Selected = True
                Catch ex As Exception

                End Try

                '      TextBox29.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg1.Width = 10
            dg1.Height = 10
            dg1.SendToBack()
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPcs.LostFocus

    End Sub

    Private Sub TextBox18_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGrAmt.KeyUp
        If Val(txtGrAmt.Text) > 99999999999999.984 Then
            MsgBox("Not valid figure")
            txtGrAmt.Focus()
        End If
    End Sub

    Private Sub TextBox23_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNetAmt.KeyUp
        If Val(txtNetAmt.Text) > 999999999999.999 Then
            MsgBox("Not valid figure")
            txtNetAmt.Focus()
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrint.Click
        billno = txtBillNosec.Text
        frmsalebill.Close()
        frmsalebill.Show()

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        txtFind.Focus()
        GroupBox1.BringToFront()
        GroupBox1.Visible = True
    End Sub

    Private Sub TextBox32_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button15.Focus()
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (txtFind.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = txtFind.Text
        For i = temp1 To dg1.Rows.Count - 1
            For j = temp2 To dg1.ColumnCount - 1
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)

                If (dg1.Item(j, i).Value.ToString.ToLower.ToString.Contains(txtFind.Text.ToLower)) Then
                    dg1.Item(j, i).Selected = True
                    temp2 = j + 1
                    '    check = 1
                    GoTo en
                End If
            Next
            temp1 = i + 1
            temp2 = 0
        Next
en:
    End Sub

    Private Sub TextBox30_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWorkNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            '   TextBox16.Focus()
            maskchdt.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            comInvoiceType.Focus()
        End If
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextBox33_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtDescription.Focus()
        End If
    End Sub


    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChno.TextChanged

    End Sub

    Private Sub CheckedListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chlichno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                connect()
                Dim j As Integer
                Dim list1 As New ListBox
                For j = 0 To maindg.Rows.Count - 1
                    Try
                        If maindg.Item(10, j).Value.ToString.Trim.Length = 0 Then
                        Else
                            list1.Items.Add(j)
                        End If
                    Catch ex As Exception

                    End Try
                    ' MsgBox(DataGridView1.Item(10, j).Value)

                Next
                For j = 0 To list1.Items.Count - 1
                    maindg.Rows.RemoveAt(Val(list1.Items(j)) - j)
                Next
                '   DataGridView1.Rows.Clear()
                Dim i As Integer

                For i = 0 To chlichno.CheckedItems.Count - 1
                    Dim vrno As String = ""
                    Dim cmd As New SqlCommand("Select vrno from ch1 where chno='" & chlichno.CheckedItems(i).ToString & "'", cn)
                    Dim dr As SqlDataReader
                    dr = cmd.ExecuteReader
                    While dr.Read
                        vrno = dr.Item(0)
                    End While
                    dr.Close()
                    cmd = New SqlCommand("Select * from ch2 where vrno='" & vrno & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        With maindg
                            .Rows.Add()
                            .Item(1, .RowCount - 1).Value = dr.Item("itcode2")
                            .Item(2, .RowCount - 1).Value = dr.Item("itname")
                            .Item(3, .RowCount - 1).Value = dr.Item("itcode")
                            .Item(4, .RowCount - 1).Value = dr.Item("pcs")
                            .Item(5, .RowCount - 1).Value = dr.Item("pack")
                            .Item(6, .RowCount - 1).Value = dr.Item("qty")
                            .Item(8, .RowCount - 1).Value = dr.Item("unit")
                            .Item(10, .RowCount - 1).Value = chlichno.CheckedItems(i)
                        End With
                    End While
                    dr.Close()
                Next
                For i = 0 To maindg.Rows.Count - 1
                    maindg.Item(0, i).Value = i + 1
                Next
                txtSrNo.Text = "1"
                Try
                    maindg.Item(0, 0).Selected = True
                    chlichno.Visible = False

                Catch ex As Exception

                End Try
                close1()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chlichno.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles maindg.DefaultValuesNeeded
        maindg.Item(10, e.Row.Index).Value = "NO"
    End Sub

    Private Sub butSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSavePrint.Click

    End Sub
End Class
