Imports System.Data.SqlClient
Public Class frmlotdetail
    Dim master_check As String
    Dim style_leave_check As Integer = 0
    Dim shade_leave_check As Integer = 0
    Dim machine_leave_check As Integer = 0
    Dim design_leave_check As Integer = 0
    Dim process_leave_check As Integer = 0
    Private Sub frmlotdetail_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FRMDISPATCH.Show()
    End Sub
    Private Sub dataGridView1_SortCompare(ByVal sender As Object, ByVal e As DataGridViewSortCompareEventArgs) Handles DG1.SortCompare
        If e.Column.Index <> 0 Then
            Return
        End If
        Try
            e.SortResult = If(CInt(e.CellValue1) < CInt(e.CellValue2), -1, 1)
            e.Handled = True
        Catch
        End Try
    End Sub

    Private Sub frmlotdetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.W And e.Control Then
            txtRemark.Focus()
            'savecode()
        ElseIf e.KeyCode = Keys.F7 Then
            TP()
        ElseIf e.KeyCode = Keys.F8 Then
            Half()
        End If
    End Sub
    Private Sub frmlotdetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            DG1.Focus()
            connect()
            '   testgrid.DataSource = FRMDISPATCH.ds.Tables("lotr")
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tbllotr where lotno='" & FRMDISPATCH.lotno & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtLotNo.Text = dr.Item("lotno")
                txtLrNo.Text = dr.Item("lrno")
                txtIchNo.Text = dr.Item("ichno")
                txtGrayItem.Text = dr.Item("item")
                txtMst.Text = dr.Item("mst")
                txtWidth.Text = dr.Item("width")
                txtGbalpcs.Text = dr.Item("gbalpcs")
                txtGbalMtr.Text = dr.Item("gbalmtr")
            End While
            dr.Close()
            cmd = New SqlCommand("select * from tblLotrt where lotno='" & FRMDISPATCH.lotno & "' AND GBALMTR >0", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            While dr.Read
                DG1.Rows.Add()
                DG1.Item(0, i).Value = dr.Item("Sr")
                DG1.Item(1, i).Value = dr.Item("GbalMtr")
                DG1.Item(2, i).Value = dr.Item("GBALmtr")
                DG1.Item(3, i).Value = 0.0
                i = i + 1
            End While
            '  MsgBox(i)
            dr.Close()
            ' If Label14.Text = "EDIT" Then
            Dim k As Integer = DG1.RowCount
            With FRMDISPATCH
                Dim lotno As New ListBox
                '       testgrid.Visible = True
                '      testgrid.DataSource = .ds.Tables("lotr")
                For i = 0 To .ds.Tables("lotr").Rows.Count - 1
                    If .ds.Tables("lotr").Rows(i).Item(5).ToString = txtLotNo.Text And .ds.Tables("lotr").Rows(i).Item(6) = FRMDISPATCH.dg1.Item(0, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value Then
                        lotno.Items.Add(i)
                        DG1.Rows.Add()
                    End If
                Next
                For i = 0 To lotno.Items.Count - 1
                    ' MsgBox(.ds.Tables("lotr").Rows(i).Item(3))
                    DG1.Item(0, k).Value = .ds.Tables("lotr").Rows(lotno.Items(i).ToString).Item(0).ToString
                    DG1.Item(1, k).Value = .ds.Tables("lotr").Rows(lotno.Items(i).ToString).Item(1).ToString
                    DG1.Item(2, k).Value = .ds.Tables("lotr").Rows(lotno.Items(i).ToString).Item(2).ToString
                    DG1.Item(3, k).Value = .ds.Tables("lotr").Rows(lotno.Items(i).ToString).Item(3).ToString
                    DG1.Item(5, k).Value = .ds.Tables("lotr").Rows(lotno.Items(i).ToString).Item(4).ToString
                    k = k + 1
                    '  DG1.Item(5, DG1.RowCount - 2).Value = .ds.Tables("lotr").Rows(i).Item(5).ToString
                Next
            End With
            ' End If
            ' DG1.Columns(0).ValueType = GetType(Decimal)
            Try
                DG1.Sort(DG1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            close1()
            Try
                ' DG1.Item(3, 0).Selected = True
                cmbmst.Focus()
            Catch ex As Exception

            End Try
            ' DG1.Rows(DG1.RowCount - 1).ReadOnly = True
            DG1.Focus()
            Dim k1 As Integer
            For k1 = 0 To DG1.RowCount - 1
                DG1.Item(4, k1).Value = Format(((Val(DG1.Item(2, k1).Value) - Val(DG1.Item(3, k1).Value)) / Val(DG1.Item(2, k1).Value)) * 100, "0.00")
            Next
            If DG1.RowCount = 0 Then
                MsgBox("Lot already dispatched")
                close1()

                Me.Close()
                FRMDISPATCH.Show()
                GoTo en
            End If
            connect()
            cmd = New SqlCommand("Select process from prmst", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmdprocess.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select style from stylemst", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbstyle.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select SHADE from tblShade", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbshade.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select mst from mst", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbmst.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select itname from tblItem", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbitem.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select machineno from tblmachine", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbmachine.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select desgno from tbldesgmst", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbDesign.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Try
                cmdprocess.Text = FRMDISPATCH.dg1.Item(3, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                cmbstyle.Text = FRMDISPATCH.dg1.Item(5, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                cmbshade.Text = FRMDISPATCH.dg1.Item(6, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                cmbitem.Text = FRMDISPATCH.dg1.Item(4, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                cmbmst.Text = FRMDISPATCH.dg1.Item(7, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                txtRemark.Text = FRMDISPATCH.dg1.Item(17, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                cmbDesign.Text = FRMDISPATCH.dg1.Item(18, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                cmbmachine.Text = FRMDISPATCH.dg1.Item(19, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
            Catch ex As Exception

            End Try
            If cmbmst.Text.Length = 0 Then
                cmd = New SqlCommand("Select mst  from tblLotr where lotno='" & txtLotNo.Text & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    cmbmst.Text = dr.Item(0)
                End While
                dr.Close()
            End If
            If cmbitem.Text.Length = 0 Then
                cmd = New SqlCommand("Select item  from tblLotr where lotno='" & txtLotNo.Text & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    cmbitem.Text = dr.Item(0)
                End While
                dr.Close()
            End If
            close1()
en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dg1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellValidated
        Dim i As Integer
        Dim amt As Decimal = 0
        Dim amt2 As Decimal = 0
        Dim count As Integer = 0
        Dim count2 As Integer = 0
        For i = 0 To DG1.Rows.Count - 1
            If Val(DG1.Item(3, i).Value) <> 0 Then
                amt = amt + Val(DG1.Item(3, i).Value)
                amt2 = amt2 + Val(DG1.Item(2, i).Value)
                count2 = count2 + 1
                If Val(DG1.Item(1, i).Value) <> 0 Then
                    count = count + 1
                End If
            End If
        Next
        TextBox10.Text = amt
        TextBox9.Text = amt2
        TextBox23.Text = count
        TextBox24.Text = count2
        If e.ColumnIndex = 3 Then
            DG1.Item(4, e.RowIndex).Value = Format(((Val(DG1.Item(2, e.RowIndex).Value) - Val(DG1.Item(3, e.RowIndex).Value)) / Val(DG1.Item(2, e.RowIndex).Value)) * 100, "0.00")
        End If
    End Sub

    Private Sub TextBox11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox20.KeyDown, TextBox19.KeyDown, TextBox18.KeyDown, TextBox17.KeyDown, TextBox16.KeyDown, TextBox15.KeyDown, TextBox14.KeyDown, TextBox13.KeyDown, TextBox12.KeyDown, TextBox11.KeyDown, TextBox21.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.Up Then
            SendKeys.Send("+{TAB}")
        End If
    End Sub

    Private Sub TextBox11_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox21.Leave, TextBox20.Leave, TextBox19.Leave, TextBox18.Leave, TextBox17.Leave, TextBox16.Leave, TextBox15.Leave, TextBox14.Leave, TextBox13.Leave, TextBox12.Leave, TextBox11.Leave
        sender.text = Format(Val(sender.text), "0.00")
        Dim amt As Decimal
        amt = amt + Val(TextBox11.Text)
        amt = amt + Val(TextBox12.Text)
        amt = amt + Val(TextBox13.Text)
        amt = amt + Val(TextBox14.Text)
        amt = amt + Val(TextBox15.Text)
        amt = amt + Val(TextBox16.Text)
        amt = amt + Val(TextBox17.Text)
        amt = amt + Val(TextBox18.Text)
        amt = amt + Val(TextBox19.Text)
        amt = amt + Val(TextBox20.Text)
        amt = amt + Val(TextBox21.Text)
        TextBox22.Text = amt
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butTP.Click
        TP()
    End Sub
    Public Sub TP()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        TextBox20.Clear()
        TextBox21.Clear()
        GroupBox1.Enabled = True
        GroupBox1.Visible = True
        GroupBox1.Focus()

        Dim count As Integer
        Dim li As New ListBox
        count = DG1.Item(0, DG1.CurrentCell.RowIndex).Value
        Dim i As Integer
        For i = 0 To DG1.RowCount - 1
            If DG1.Item(0, i).Value = count Then
                li.Items.Add(i)
            End If
        Next
        Try

            TextBox11.Text = DG1.Item(3, li.Items(0)).Value
            TextBox11.SelectAll()
            TextBox12.Text = DG1.Item(3, li.Items(1)).Value
            TextBox13.Text = DG1.Item(3, li.Items(2)).Value
            TextBox14.Text = DG1.Item(3, li.Items(3)).Value
            TextBox15.Text = DG1.Item(3, li.Items(4)).Value
            TextBox16.Text = DG1.Item(3, li.Items(5)).Value
            TextBox17.Text = DG1.Item(3, li.Items(6)).Value
            TextBox18.Text = DG1.Item(3, li.Items(7)).Value
            TextBox19.Text = DG1.Item(3, li.Items(8)).Value
            TextBox20.Text = DG1.Item(3, li.Items(9)).Value
            TextBox21.Text = DG1.Item(3, li.Items(10)).Value
        Catch ex As Exception

        End Try
        TextBox11.Focus()
        Try
            Dim l As Integer = li.Items(0)
            Dim k As Integer
            For k = 0 To li.Items.Count - 2
                DG1.Rows.RemoveAt(l + 1)
            Next
        Catch ex As Exception
        End Try
        Label10.Text = DG1.Item(0, DG1.CurrentCell.RowIndex).Value
        Label9.Text = DG1.Item(1, DG1.CurrentCell.RowIndex).Value
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim i As Integer = DG1.CurrentCell.RowIndex
        tp(TextBox11, i)
        tp(TextBox12, i)
        tp(TextBox13, i)
        tp(TextBox14, i)
        tp(TextBox15, i)
        tp(TextBox16, i)
        tp(TextBox17, i)
        tp(TextBox18, i)
        tp(TextBox19, i)
        tp(TextBox20, i)
        tp(TextBox21, i)
        DG1.Focus()
        GroupBox1.Enabled = False
    End Sub
    Private Sub tp(ByVal tb As TextBox, ByRef i As Integer)
        If Val(tb.Text) > 0 Then
            If tb.Name = TextBox11.Name Then
                DG1.Item(3, i).Value = Val(tb.Text)
            Else
                i = i + 1
                DG1.Rows.Insert(i)
                DG1.Item(0, i).Value = Label10.Text
                DG1.Item(1, i).Value = 0
                DG1.Item(2, i).Value = 0
                DG1.Item(3, i).Value = Val(tb.Text)
            End If
        End If
    End Sub
    Private Sub deletecode()
        With FRMDISPATCH.ds.Tables("lotr")
            Dim i As Integer
            Dim lotno As New ListBox
            '  testgrid.DataSource = FRMDISPATCH.ds.Tables("lotr")
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Item(5).ToString = txtLotNo.Text And .Rows(i).Item(6).ToString = FRMDISPATCH.dg1.Item(0, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value Then
                    lotno.Items.Add(i)
                    Dim gbalmtr As Decimal = 0
                    Dim gbalmtr1 As Decimal = 0
                    Dim gbalpcs As Decimal = 0
                    '  Dim isdesp As String = "f"
                    Dim cmd As New SqlCommand
                    With FRMDISPATCH
                        connect()
                        '    isdesp = "f"
                        gbalmtr = 0
                        gbalmtr1 = 0
                        gbalpcs = 0
                        cmd = New SqlCommand("Select gbalmtr from tblLotrt where Sr=" & .ds.Tables("LOTR").Rows(i).Item(0).ToString & " and lotno='" & .ds.Tables("LOTR").Rows(i).Item(5).ToString & "'", cn)
                        Dim dr As SqlDataReader
                        dr = cmd.ExecuteReader
                        While dr.Read
                            gbalmtr = Val(dr.Item(0).ToString) + Val(.ds.Tables("LOTR").Rows(i).Item(2).ToString)
                        End While
                        dr.Close()
                        cmd = New SqlCommand("Select gbalmtr,gbalpcs from tblLotr where lotno='" & .ds.Tables("LOTR").Rows(i).Item(5).ToString & "'", cn)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            '  MsgBox(.ds.Tables("lotr").Rows(i).Item(2).ToString)
                            gbalmtr1 = Val(dr.Item(0).ToString) + Val(.ds.Tables("LOTR").Rows(i).Item(2).ToString)
                            If .ds.Tables("lotr").Rows(i).Item(2).ToString > 0 Then
                                gbalpcs = dr.Item(1) + 1
                                If gbalpcs = 0 Then
                                    '    isdesp = "t"
                                End If
                            End If
                        End While
                        dr.Close()
                        cmd = New SqlCommand("Update tbllotrt set gbalmtr=" & gbalmtr & " where Sr=" & .ds.Tables("LOTR").Rows(i).Item(0).ToString & " and lotno='" & .ds.Tables("LOTR").Rows(i).Item(5).ToString & "'", cn)
                        cmd.ExecuteNonQuery()
                        If .ds.Tables("lotr").Rows(i).Item(2).ToString > 0 And .ds.Tables("lotr").Rows(i).Item(6) = FRMDISPATCH.dg1.Item(0, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value Then
                            cmd = New SqlCommand("Update tbllotr set gbalmtr=" & gbalmtr1 & ",gbalpcs=" & gbalpcs & " where lotno='" & .ds.Tables("LOTR").Rows(i).Item(5).ToString & "'", cn)
                            cmd.ExecuteNonQuery()
                        End If
                    End With
                End If
            Next
            For i = 0 To lotno.Items.Count - 1
                .Rows.RemoveAt(lotno.Items(i).ToString - i)
            Next
            testgrid.DataSource = FRMDISPATCH.ds.Tables("lotr")
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        savecode()
    End Sub
    Private Sub savecode()
        Try
            connect()
            With FRMDISPATCH
                'If Label14.Text = "EDIT" Then
                deletecode()
                ' GoTo en
                ' End If
                Dim amt As Decimal = 0
                Dim i As Integer
                For i = 0 To DG1.RowCount - 1
                    If Val(DG1.Item(3, i).Value) > 0 Then
                        Dim dt As DataRow = .ds.Tables("lotr").NewRow
                        dt.Item(0) = DG1.Item(0, i).Value
                        dt.Item(1) = DG1.Item(1, i).Value
                        dt.Item(2) = DG1.Item(2, i).Value
                        dt.Item(3) = DG1.Item(3, i).Value
                        dt.Item(4) = DG1.Item(5, i).Value
                        dt.Item(5) = txtLotNo.Text
                        dt.Item(6) = FRMDISPATCH.dg1.Item(0, FRMDISPATCH.dg1.CurrentCell.RowIndex).Value
                        Dim cmd As New SqlCommand
                        Dim gbalmtr As Decimal = 0
                        cmd = New SqlCommand("Select gbalmtr from tblLotrt where Sr=" & DG1.Item(0, i).Value & " and lotno='" & txtLotNo.Text & "'", cn)
                        Dim dr As SqlDataReader
                        dr = cmd.ExecuteReader
                        While dr.Read
                            gbalmtr = Val(dr.Item(0).ToString) - Val(DG1.Item(2, i).Value)
                            amt = amt + Val(DG1.Item(2, i).Value)
                        End While
                        dr.Close()
                        cmd = New SqlCommand("Update tbllotrt set gbalmtr=" & gbalmtr & " where Sr=" & DG1.Item(0, i).Value & " and lotno='" & txtLotNo.Text & "'", cn)
                        cmd.ExecuteNonQuery()
                        .ds.Tables("lotr").Rows.Add(dt)
                    End If
                Next
                Dim amt2 As Decimal = 0
                Dim gbalmtr2 As Decimal = 0
                '   Dim isdesp As String = "f"
                Dim cmd2 As New SqlCommand
                Dim dr2 As SqlDataReader
                cmd2 = New SqlCommand("select gbalmtr,gbalpcs from tblLotr where lotno='" & txtLotNo.Text & "'", cn)
                dr2 = cmd2.ExecuteReader
                While dr2.Read
                    gbalmtr2 = dr2.Item(0)
                    amt2 = dr2.Item(1)
                    If amt2 - Val(TextBox23.Text) = 0 Then
                        '     isdesp = "t"
                    Else
                        '  isdesp = "f"
                    End If
                End While
                dr2.Close()
                cmd2 = New SqlCommand("Update tbllotr set gbalmtr=" & gbalmtr2 - amt & ",gbalpcs=" & amt2 - Val(TextBox23.Text) & " where lotno='" & txtLotNo.Text & "'", cn)
                cmd2.ExecuteNonQuery()
                Dim cmd1 As New SqlCommand
                Dim dr1 As SqlDataReader
                cmd1 = New SqlCommand("Select * from tbllotr,tbLitem where lotno='" & txtLotNo.Text & "' and tblLotr.item=tblitem.itname", cn)
                dr1 = cmd1.ExecuteReader
                While dr1.Read
                    Dim currentrow As Integer = .dg1.CurrentCell.RowIndex
                    .dg1.Item(4, currentrow).Value = cmbitem.Text
                    .dg1.Item(7, currentrow).Value = cmbmst.Text
                    .dg1.Item(8, currentrow).Value = dr1.Item("width")
                    .dg1.Item(9, currentrow).Value = Val(TextBox23.Text)
                    .dg1.Item(10, currentrow).Value = Val(TextBox9.Text)
                    .dg1.Item(11, currentrow).Value = 0
                    .dg1.Item(12, currentrow).Value = 0
                    .dg1.Item(13, currentrow).Value = Val(TextBox24.Text)
                    .dg1.Item(14, currentrow).Value = Val(TextBox10.Text)
                    .dg1.Item(3, currentrow).Value = cmdprocess.Text
                    .dg1.Item(5, currentrow).Value = cmbstyle.Text
                    .dg1.Item(6, currentrow).Value = cmbshade.Text
                    .dg1.Item(17, currentrow).Value = txtRemark.Text
                    .dg1.Item(18, currentrow).Value = cmbDesign.Text
                    .dg1.Item(19, currentrow).Value = cmbmachine.Text
                    '  .dg1.Item(14, .dg1.CurrentCell.RowIndex).Value = dr1.Item("rate")
                End While
                dr1.Close()
                .dg1.Item(16, .dg1.CurrentCell.RowIndex).Value = Val(TextBox10.Text) * Val(.dg1.Item(15, .dg1.CurrentCell.RowIndex).Value)
                FRMDISPATCH.caldispatch()
                close1()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        MsgBox("success")
        Me.Close()
        FRMDISPATCH.ListBox1.Focus()
        FRMDISPATCH.dg1.Rows(FRMDISPATCH.dg1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Red
en:
    End Sub

    Private Sub DG1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick

    End Sub

    Private Sub DG1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DG1.RowsAdded

    End Sub

    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub butHalf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butHalf.Click
        half()
    End Sub
    Public Sub half()
        Try
            Label15.Visible = True
            TextBox1.Visible = True
            Dim J As String
            Dim K As Decimal
            '    K = DG1.Item(1, DG1.CurrentCell.RowIndex).Value
            Try
                TextBox1.Focus()
                ' J = (InputBox("ENTER VALUE"))
            Catch ex As Exception
                MsgBox("ENTER PROPER VALUE")
            End Try
            J = CDec(J)
            If J > K Then
                MsgBox("PLEASE ENTER PROPER VALUE")
                GoTo EN
            End If
            Dim I As Integer = DG1.CurrentCell.RowIndex

            'DG1.Rows.Insert(I)
            '    DG1.Item(0, I).Value = Label10.Text
            '   DG1.Item(1, I).Value = J
            ' DG1.Item(2, I).Value = J
            'DG1.Rows.Insert(I + 1)
            ' DG1.Item(0, I + 1).Value = Label10.Text
            'DG1.Item(1, I + 1).Value = K - J
            ' DG1.Item(2, I + 1).Value = K - J
            ' DG1.Item(3, I).Value = Val(tb.Text)
EN:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub butHalf_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butHalf.KeyDown

    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TextBox1.Text) = 0 Then
                GoTo e1
            End If
            If DG1.Item(1, DG1.CurrentCell.RowIndex).Value < Val(TextBox1.Text) Then
                MessageBox.Show("Please enter value less than balance meter")
                TextBox1.Focus()
                GoTo en
            End If


            DG1.Item(2, DG1.CurrentCell.RowIndex).Value = Format(Val(TextBox1.Text), "0.00")
e1:
            DG1.Focus()
            Label15.Visible = False
            TextBox1.Visible = False
            DG1.CurrentCell.Selected = True
en:
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles cmdprocess.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbitem.Focus()
        End If
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles cmdprocess.Leave
        Try
            If process_leave_check = 0 Then


                If cmdprocess.Items.Contains(cmdprocess.Text) = False Then
                    If MsgBox("This process is not in List. Do you want to add new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        process_leave_check = 1
                        Dim style As String
                        Label24.Text = "Process"
                        master_check = "Process"
                        TextBox2.Visible = True
                        TextBox2.Focus()


                    Else
                        cmdprocess.Focus()

                    End If
                Else

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbstyle.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                cmbshade.Focus()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs) Handles cmbstyle.Leave
        Try
            If style_leave_check = 0 Then


                If cmbstyle.Items.Contains(cmbstyle.Text) = False Then
                    If MsgBox("This Item1 is not in List. Do you want to add new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        style_leave_check = 1
                        Dim style As String
                        Label24.Text = "Item1"
                        master_check = "Style"
                        TextBox2.Visible = True
                        TextBox2.Focus()


                    Else
                        cmbstyle.Focus()

                    End If
                Else

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbshade.KeyDown
        If e.KeyCode = Keys.Enter Then


            Try
                ' DG1.Item(3, 0).Selected = True
                ' DG1.Focus()
                cmbDesign.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ComboBox3_Leave(sender As Object, e As EventArgs) Handles cmbshade.Leave
        Try
            If shade_leave_check = 0 Then


                If cmbshade.Items.Contains(cmbshade.Text) = False Then
                    If MsgBox("This Item2 is not in List. Do you want to add new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        shade_leave_check = 1
                        Dim style As String
                        Label24.Visible = True
                        Label24.Text = "Item2"
                        master_check = "Shade"
                        TextBox2.Visible = True
                        TextBox2.Focus()
                    Else
                        cmbshade.Focus()

                    End If
                Else

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbitem.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbstyle.Focus()
        End If
    End Sub

    Private Sub ComboBox4_Leave(sender As Object, e As EventArgs) Handles cmbitem.Leave
        Try
            If cmbitem.Text.Contains(cmbitem.Text) = False Then
                MessageBox.Show("Please select item from list")
                cmbitem.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbmst.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbitem.Focus()
        End If
    End Sub
    Private Sub ComboBox5_Leave(sender As Object, e As EventArgs) Handles cmbmst.Leave
        Try
            If cmbmst.Text.Contains(cmbmst.Text) = False Then
                MessageBox.Show("Please select master from list")
                cmbmst.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRemark_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        End If
    End Sub

    Private Sub cmbDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDesign.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbmachine.Focus()
        End If
    End Sub

    Private Sub cmbmachine_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbmachine.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                DG1.Item(3, 0).Selected = True
                DG1.Focus()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            
            If master_check = "Style" Then
                If TextBox2.Text.Trim.Length = 0 Then
                    MessageBox.Show("Can not enter blank Style")
                    cmbstyle.Focus()
                    style_leave_check = 0
                    GoTo en
                End If
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim txt1 As New TextBox
                If duplicate("stylemst", "style", TextBox2) Then
                    style_leave_check = 0
                    MessageBox.Show("This style is already in List. Please check")
                    cmbstyle.Focus()
                    GoTo en
                End If
                myserialno("stylemst", txt1, "stycode")
                connect()
                cmd = New SqlCommand("Insert into stylemst values(" & txt1.Text & ",'" & TextBox2.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MsgBox("Inserted")
                style_leave_check = 0
                cmbstyle.Items.Add(TextBox2.Text)
                cmbstyle.Text = TextBox2.Text
                cmbstyle.Focus()
                close1()
            ElseIf master_check = "Shade" Then
                If TextBox2.Text.Trim.Length = 0 Then
                    MessageBox.Show("Can not enter blank Shade")
                    cmbshade.Focus()
                    shade_leave_check = 0
                    GoTo en
                End If
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim txt1 As New TextBox
                If duplicate("tblShade", "shade", TextBox2) Then
                    shade_leave_check = 0
                    MessageBox.Show("This shade is already in List. Please check")
                    cmbshade.Focus()
                    GoTo en
                End If
                shade_leave_check = 0
                myserialno("tblShade", txt1, "SHcode")
                connect()
                cmd = New SqlCommand("Insert into tblShade values(" & txt1.Text & ",'" & TextBox2.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MsgBox("Inserted")
                cmbshade.Items.Add(TextBox2.Text)
                cmbshade.Text = TextBox2.Text
                cmbshade.Focus()

                close1()
            ElseIf master_check = "Design" Then
                If TextBox2.Text.Trim.Length = 0 Then
                    MessageBox.Show("Can not enter blank Design")
                    cmbDesign.Focus()
                    design_leave_check = 0
                    GoTo en
                End If
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim txt1 As New TextBox
                If duplicate("tblDesgMst", "desgno", TextBox2) Then
                    design_leave_check = 0
                    MessageBox.Show("This design is already in List. Please check")
                    cmbDesign.Focus()
                    GoTo en
                End If
                myserialno("tbldesgmst", txt1, "desgcode")
                connect()
                design_leave_check = 0
                cmd = New SqlCommand("Insert into tbldesgmst values(" & txt1.Text & ",'" & TextBox2.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MsgBox("Inserted")
                cmbDesign.Items.Add(TextBox2.Text)
                cmbDesign.Text = TextBox2.Text
                cmbDesign.Focus()

                close1()
            ElseIf master_check = "Machine" Then
                If TextBox2.Text.Trim.Length = 0 Then
                    MessageBox.Show("Can not enter blank Machine")
                    cmbmachine.Focus()
                    machine_leave_check = 0
                    GoTo en
                End If
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim txt1 As New TextBox
                If duplicate("tblMachine", "Machineno", TextBox2) Then
                    machine_leave_check = 0
                    MessageBox.Show("This machine is already in List. Please check")
                    cmbDesign.Focus()
                    GoTo en
                End If
                machine_leave_check = 0
                myserialno("tblMachine", txt1, "Machinecode")
                connect()
                cmd = New SqlCommand("Insert into tblmachine values(" & txt1.Text & ",'" & TextBox2.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MsgBox("Inserted")
                cmbmachine.Items.Add(TextBox2.Text)
                cmbmachine.Text = TextBox2.Text
                cmbmachine.Focus()

                close1()
            ElseIf master_check = "Process" Then
                If TextBox2.Text.Trim.Length = 0 Then
                    MessageBox.Show("Can not enter blank Process")
                    cmdprocess.Focus()
                    process_leave_check = 0
                    GoTo en
                End If
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim txt1 As New TextBox
                If duplicate("prmst", "process", TextBox2) Then
                    process_leave_check = 0
                    MessageBox.Show("This Process is already in List. Please check")
                    cmbDesign.Focus()
                    GoTo en
                End If
                process_leave_check = 0
                myserialno("prmst", txt1, "prcode")
                connect()
                cmd = New SqlCommand("Insert into prmst values(" & txt1.Text & ",'" & TextBox2.Text & "')", cn)
                cmd.ExecuteNonQuery()
                MsgBox("Inserted")
                cmdprocess.Items.Add(TextBox2.Text)
                cmdprocess.Text = TextBox2.Text
                cmdprocess.Focus()

                close1()
            End If
en:
            TextBox2.Visible = False
            TextBox2.Clear()
            Label24.Visible = False
        End If

    End Sub

   
    Private Sub cmbDesign_Leave(sender As Object, e As EventArgs) Handles cmbDesign.Leave
        Try
            If design_leave_check = 0 Then


                If cmbDesign.Items.Contains(cmbDesign.Text) = False Then
                    If MsgBox("This design is not in List. Do you want to add new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        design_leave_check = 1
                        Dim style As String
                        Label24.Visible = True
                        Label24.Text = "Design"
                        master_check = "Design"
                        TextBox2.Visible = True
                        TextBox2.Focus()


                    Else
                        cmbDesign.Focus()

                    End If
                Else

                End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmbmachine_Leave(sender As Object, e As EventArgs) Handles cmbmachine.Leave
        Try
            If machine_leave_check = 0 Then


                If cmbmachine.Items.Contains(cmbmachine.Text) = False Then
                    If MsgBox("This machine is not in List. Do you want to add new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        machine_leave_check = 1
                        Dim style As String
                        Label24.Visible = True
                        Label24.Text = "Machine"
                        master_check = "Machine"
                        TextBox2.Visible = True
                        TextBox2.Focus()


                    Else
                        cmbDesign.Focus()

                    End If
                Else

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox11_Enter(sender As Object, e As EventArgs) Handles TextBox11.Enter, TextBox12.Enter, TextBox13.Enter, TextBox14.Enter, TextBox15.Enter, TextBox16.Enter, TextBox17.Enter, TextBox18.Enter, TextBox19.Enter, TextBox20.Enter, TextBox21.Enter
        sender.SelectionStart = 0
        sender.SelectionLength = TextBox1.Text.Length
        sender.SelectAll()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class