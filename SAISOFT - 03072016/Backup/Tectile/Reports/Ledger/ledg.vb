Imports System.Data.SqlClient
Public Class ledg
    Dim da As New SqlDataAdapter
    '   Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim cmd As New SqlCommand
    Dim x As Integer = 10
    Dim y As Integer = 10
    Dim li As New ListBox
    Public ledgdataset As New DataSet2
    Public ledgtype As String
    Private Sub ledg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub ledg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            Dim maindatagrid As New DataGridView
            Dim mainpt As New Point
            mainpt.X = x
            mainpt.Y = y + 40
            maindatagrid.Columns.Add("Col1", "Date")
            maindatagrid.Columns.Add("col2", "Book")
            maindatagrid.Columns.Add("col3", "Ref")
            maindatagrid.Columns.Add("col4", "Opname")
            maindatagrid.Columns.Add("col5", "Dr")
            maindatagrid.Columns.Add("col6", "Cr")
            'maindatagrid.Columns.Add("col7", "Bal")
            maindatagrid.Columns.Add("col8", "Remark")
            maindatagrid.Columns.Add("col9", "VrNo")
            maindatagrid.Columns(0).Width = 100
            maindatagrid.Columns(1).Width = 50
            maindatagrid.Columns(2).Width = 150
            maindatagrid.Columns(3).Width = 300
            maindatagrid.Columns(4).Width = 100
            maindatagrid.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            maindatagrid.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            maindatagrid.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            maindatagrid.Columns(5).Width = 100
            maindatagrid.Columns(6).Width = 400
            maindatagrid.Columns(7).Width = 100
            maindatagrid.Height = 25
            maindatagrid.Rows.Clear()
            maindatagrid.Width = 1200
            maindatagrid.RowHeadersVisible = False
            maindatagrid.Location = mainpt
            Me.Controls.Add(maindatagrid)
            connect()
            '  dr = cmd.ExecuteReader
            ' While dr.Read
            'li.Items.Add(dr.Item(0))
            ' End While
            ' dr.Close()
            ' cn.Close()
            ' For i = 0 To 2
            'li.Items.Add(li.Items(0).ToString)
            'Next
            Dim i As Integer
            If disledg.CheckedListBox1.CheckedItems.Count = 0 Then
                For i = 0 To disledg.CheckedListBox1.Items.Count - 1
                    connect()
                    Dim trcount As Integer
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    cmd = New SqlCommand("Select count(VRNo) from tblLedg where ACName='" & disledg.CheckedListBox1.Items(i).ToString & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        trcount = dr.Item(0)
                    End While
                    dr.Close()
                    If trcount = 0 Then
                    Else
                        li.Items.Add(disledg.CheckedListBox1.Items(i).ToString)
                    End If
                    close1()
                Next
            Else
                For i = 0 To disledg.CheckedListBox1.CheckedItems.Count - 1
                    connect()
                    Dim trcount As Integer
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    cmd = New SqlCommand("Select count(VRNo) from tblLedg where ACName='" & disledg.CheckedListBox1.CheckedItems(i).ToString & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        trcount = dr.Item(0)
                    End While
                    dr.Close()
                    If trcount = 0 Then
                    Else
                        li.Items.Add(disledg.CheckedListBox1.CheckedItems(i).ToString)
                    End If
                    close1()

                Next
            End If
            For i = 0 To li.Items.Count - 1
                Dim stx As New TextBox
                Dim dg As New DataGridView
                Dim pt As New Point
                Dim ds As New DataSet
                Dim tx As New TextBox
                If i <> 0 Then
                    '       dg.ColumnHeadersVisible = False
                End If
                connect()
                dg.BackgroundColor = Color.White
                dg.RowHeadersVisible = False
                tx.Text = li.Items(i).ToString
                tx.TextAlign = HorizontalAlignment.Left
                tx.ForeColor = Color.Red
                tx.Width = 1200
                tx.Font = New Font("Arial", 12, FontStyle.Bold)
                pt.X = x
                pt.Y = y
                tx.Location = pt
                pt.X = x
                pt.Y = y + 25
                dg.ReadOnly = True
                dg.MultiSelect = False
                dg.Name = "datagrid" & i
                dg.Location = pt
                dg.Width = 1500
                dg.StandardTab = True
                dg.AllowUserToAddRows = False
                Dim dr1 As Integer
                Dim cr1 As Integer
                Dim dat As New Date
                Dim dat2 As New Date
                Dim sql As String
                dat = disledg.MaskedTextBox1.Text.ToString
                dat2 = disledg.MaskedTextBox2.Text.ToString
                Dim dr As SqlDataReader
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select Sum(dr) as dr,Sum(cr) as cr,Sum(bal)as bal from tblLedg where Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and ACName='" & li.Items(i).ToString & "' group by ACName", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = False Then
                    dr1 = 0.0
                    cr1 = 0.0
                    dr.Close()
                    Dim a() As String = {" ", " ", dat.Month & "-" & dat.Day & "-" & dat.Year, 0, li.Items(i).ToString, dr1, cr1, cr1 - dr1, " ", " ", "Opening Balance ", 0}
                    myinsert(a, "tempLedg")
                Else
                    While dr.Read
                        dr1 = 0.0
                        cr1 = 0.0
                        If dr.Item("bal") < 0 Then
                            dr1 = dr.Item("bal") * -1
                            cr1 = 0.0
                        ElseIf dr.Item("bal") > 0 Then
                            cr1 = dr.Item("Bal")
                            dr1 = 0.0
                        Else
                            cr1 = 0.0
                            dr1 = 0.0
                        End If
                    End While
                    dr.Close()
                    Dim a() As String = {" ", " ", dat.Month & "-" & dat.Day & "-" & dat.Year, 0, li.Items(i).ToString, dr1, cr1, cr1 - dr1, " ", " ", "Opening Balance ", 0}
                    myinsert(a, "tempLedg")

                End If
                myfilldatagrid(DataGridView1, "templedg")
                connect()
                If dat = dateyf Then
                    sql = "Select Date,Book,Ref,Opname,Dr,Cr,Remark,VrNo from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ACName='" & li.Items(i).ToString & "' order by date"
                Else
                    sql = "Select Date,Book,Ref,Opname,Dr,Cr,Remark,VrNo from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ACName='" & li.Items(i).ToString & "' UNION Select Date,Book,Ref,Opname,Dr,Cr,Remark,VrNo from tempLedg where ACName='" & li.Items(i).ToString & "' order by date"
                End If
                '     dg.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
                da = New SqlDataAdapter(sql, cn)
                da.Fill(ds)
                ' cmd = New SqlCommand("Delete from tempLedg", cn)
                'cmd.ExecuteNonQuery()
                dg.GridColor = Color.Black
                dg.DataSource = ds.Tables(0)
                dg.RowsDefaultCellStyle.SelectionBackColor = Color.White
                dg.RowsDefaultCellStyle.SelectionForeColor = Color.Black
                Panel1.Controls.Add(tx)
                Panel1.Controls.Add(dg)
                'new editing
                dg.Columns(0).Width = 100
                dg.Columns(1).Width = 50
                dg.Columns(2).Width = 150
                dg.Columns(3).Width = 300
                dg.Columns(4).Width = 100
                dg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dg.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dg.Columns(5).Width = 100
                dg.Columns(6).Width = 400
                dg.Columns(7).Width = 100
                dg.Columns(dg.Columns.Count - 1).Visible = False
                dg.Width = 1200
                dg.ScrollBars = ScrollBars.None
                dg.ColumnHeadersVisible = False
                '*****
                AddHandler tx.KeyDown, AddressOf tkd
                AddHandler dg.KeyDown, AddressOf kd
                AddHandler dg.GotFocus, AddressOf gf
                AddHandler dg.LostFocus, AddressOf lf
                '  If i <> 0 Then
                'dg.Height = (dg.Rows.Count + 2) * 22
                ' y = y + (dg.Rows.Count + 3) * 23
                ' Dim lbldr As New Label
                ' lbldr.Text = getDr(dg)
                ' lbldr.Location = New Point(610, y - 42)
                ' Panel1.Controls.Add(lbldr)
                'lbldr.BringToFront()
                ' lbldr.TextAlign = ContentAlignment.MiddleRight
                '  lbldr.BackColor = Color.White
                ' lbldr.ForeColor = Color.Blue
                '  dg.SendToBack()
                ' Dim lblcr As New Label
                'lblcr.Text = getCr(dg)
                ' l'blcr.Location = New Point(710, y - 43)
                ' Panel1.Controls.Add(lblcr)
                ' lblcr.BringToFront()
                ''lblcr.TextAlign = ContentAlignment.MiddleRight
                'lblcr.BackColor = Color.White
                'lblcr.ForeColor = Color.Blue
                'dg.SendToBack()

                'Else
                dg.Height = (dg.Rows.Count + 1) * 22 + 22
                y = y + (dg.Rows.Count + 3) * 23
                Dim lbldr As New Label
                lbldr.Text = getDr(dg)
                lbldr.Location = New Point(610, y - 43)
                Panel1.Controls.Add(lbldr)
                lbldr.BringToFront()
                lbldr.TextAlign = ContentAlignment.MiddleRight
                lbldr.BackColor = Color.White
                lbldr.ForeColor = Color.Blue
                dg.SendToBack()
                Dim lblcr As New Label
                lblcr.Text = getCr(dg)
                lblcr.Location = New Point(710, y - 43)
                Panel1.Controls.Add(lblcr)
                lblcr.BringToFront()
                lblcr.TextAlign = ContentAlignment.MiddleRight
                lblcr.BackColor = Color.White
                lblcr.ForeColor = Color.Blue
                dg.SendToBack()
                lbldr.Font = New Font("Arial", 9, FontStyle.Bold)
                lblcr.Font = New Font("Arial", 9, FontStyle.Bold)
                Dim lblbal As New Label
                lblbal.Font = New Font("Arial", 9, FontStyle.Bold)
                lblbal.TextAlign = ContentAlignment.MiddleRight
                Dim ball As New Decimal
                ball = Convert.ToDecimal(Val(lblcr.Text) - Val(lbldr.Text))
                lblbal.Text = ball
                lblbal.Text = Format(ball, "0.00")
                lblbal.Location = New Point(810, y - 43)
                Panel1.Controls.Add(lblbal)
                lblbal.BringToFront()
                lblbal.BackColor = Color.White
                lblbal.ForeColor = Color.Blue
                lblbal.TextAlign = ContentAlignment.MiddleRight
            Next
            For i = 0 To 5
                Dim point As New Point
                point.X = 10
                point.Y = y + 10
                Dim lbl As New Label
                lbl.Text = ""
                lbl.Location = point
                y = y + 10
                Panel1.Controls.Add(lbl)
            Next
            connect()
            cmd = New SqlCommand("Delete from Templedg", cn)
            cmd.ExecuteNonQuery()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub kd(ByVal Sender As Object, ByVal e As KeyEventArgs)
        Try

            If e.KeyCode = Keys.Enter Then
                MsgBox(Sender.name)
            ElseIf e.KeyCode = Keys.Down Then
                If Sender.SelectedCells.Item(0).rowindex = Sender.rows.count - 1 Then
                    SendKeys.Send("{TAB}")
                End If
            ElseIf e.KeyCode = Keys.Up Then

                If Sender.SelectedCells.Item(0).rowindex = 0 Then
                    SendKeys.Send("+{TAB}")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'MsgBox(Sender.name)
    End Sub
    Private Sub tkd(ByVal Sender As Object, ByVal e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                MsgBox(Sender.name)
            ElseIf e.KeyCode = Keys.Down Then
                '     If Sender.SelectedCells.Item(0).rowindex = Sender.rows.count - 1 Then
                SendKeys.Send("{TAB}")
                ' End If
            ElseIf e.KeyCode = Keys.Up Then
                '    If Sender.SelectedCells.Item(0).rowindex = 0 Then
                SendKeys.Send("+{TAB}")
                ' End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'MsgBox(Sender.name)
    End Sub

    Private Sub gf(ByVal Sender As Object, ByVal e As EventArgs)
        Try
            Sender.RowsDefaultCellStyle.SelectionBackColor = Color.Blue
            Sender.RowsDefaultCellStyle.SelectionForeColor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lf(ByVal Sender As Object, ByVal e As EventArgs)
        Try
            Sender.RowsDefaultCellStyle.SelectionBackColor = Color.White
            Sender.RowsDefaultCellStyle.SelectionForeColor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If RadioButton1.Checked = True Then
                ledgtype = "Normal"
            ElseIf RadioButton2.Checked = True Then
                ledgtype = "Detail"
            ElseIf RadioButton3.Checked = True Then
                ledgtype = "Monthly"
            ElseIf RadioButton4.Checked = True Then
                ledgtype = "Confirmation"
            ElseIf RadioButton5.Checked = True Then
                ledgtype = "Monthly Summary"
            ElseIf RadioButton6.Checked = True Then
                ledgtype = "Next Page"
            ElseIf RadioButton7.Checked = True Then
                ledgtype = "Schedule"
            ElseIf RadioButton8.Checked = True Then
                ledgtype = "Schedule Summary"
            ElseIf RadioButton9.Checked = True Then
                ledgtype = "Ledger Summary"

            End If
            Dim cno As Integer
            Dim ac1 As String = "and ("
            If disledg.CheckedListBox1.CheckedItems.Count = 0 Then
                For cno = 0 To disledg.CheckedListBox1.Items.Count - 1
                    ac1 = ac1 & "ACName='" & disledg.CheckedListBox1.Items(cno).ToString & "' Or "
                Next
            Else
                For cno = 0 To disledg.CheckedListBox1.CheckedItems.Count - 1
                    ac1 = ac1 & "ACName='" & disledg.CheckedListBox1.CheckedItems(cno).ToString & "' Or "
                Next
            End If
            ac1 = ac1.Substring(0, ac1.Length - 4).ToString & ")"
            connect()
            Dim dat As New Date
            Dim dat2 As New Date
            Dim sql As String
            dat = disledg.MaskedTextBox1.Text.ToString
            dat2 = disledg.MaskedTextBox2.Text.ToString
            ledgdataset.Tables("tblLedg").Rows.Clear()
            Dim cmd As New SqlCommand
            If disledg.MaskedTextBox1.Text <> dateyf Then
                Dim sql1 As String
                sql1 = "Select Accode,ACName,Sum(dr) as dr,Sum(cr) as cr,SUm(bal) as bal from tblLedg where (Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "')" & ac1 & " group by accode,ACName"
                '   MsgBox(sql1)
                cmd = New SqlCommand(sql1, cn)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim dt As DataRow = ledgdataset.Tables("tblLedg").NewRow
                    dt.Item("VrNo") = " "
                    dt.Item("Book") = " "
                    dt.Item("Date") = disledg.MaskedTextBox1.Text
                    dt.Item("ACCode") = dr.Item("accode")
                    dt.Item("ACname") = dr.Item("ACname")
                    dt.Item("Dr") = dr.Item("Dr")
                    dt.Item("Cr") = dr.Item("Cr")
                    dt.Item("Bal") = dr.Item("Bal")
                    dt.Item("Remark") = " "
                    dt.Item("OPName") = "Opening Balance"
                    dt.Item("OPCode") = 0
                    '  dt.Item("SrNo") = "0"
                    ledgdataset.Tables("tblLedg").Rows.Add(dt)
                    '   MsgBox("het")
                End While
                dr.Close()
                sql = "Select * from tblLedg where (date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "')" & ac1 & " order by date"
                da = New SqlDataAdapter(sql, cn)
                da.Fill(ledgdataset, "tblLedg")

            Else
                sql = "Select * from tblLedg where (date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "')" & ac1 & " order by date"
                '    MsgBox(sql)
                da = New SqlDataAdapter(sql, cn)
                da.Fill(ledgdataset, "tblLedg")
            End If
            da = New SqlDataAdapter("select * from tblAccount", cn)
            da.Fill(ledgdataset, "tblAccount")
            close1()
            ledgprint.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function getDr(ByRef dg As DataGridView) As Decimal
        Dim dr As Decimal
        Dim i As Integer
        For i = 0 To dg.Rows.Count - 1
            dr = dr + dg.Item(4, i).Value
        Next
        Return dr
    End Function
    Private Function getCr(ByRef dg As DataGridView) As Decimal
        Dim cr As Decimal
        Dim i As Integer
        For i = 0 To dg.Rows.Count - 1
            cr = cr + dg.Item(5, i).Value
        Next
        Return cr
    End Function

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class