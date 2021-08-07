Imports System.Data.SqlClient
Public Class FRMDISPATCH
    Dim currentrow As Integer = 0
    Dim prcheck As Integer = 0
    Dim lotcheck As Integer = 0
    Public lotno As String = ""
    Public ds As New DataSet
    Dim procee As New AutoCompleteStringCollection
    Dim style As New AutoCompleteStringCollection
    Public edlotno As String
    Dim edlotno1 As String
    Public ds2 As New DataSet
    Public editcheck As Integer = 0
    Dim bkname As String
    Dim bkcode As Integer
    Dim chno As String
    Dim chdt As DateTime
    Dim billno As String
    Dim oubno As String
    Dim billdt As DateTime
    Dim name As String
    Dim namecr As String
    Dim purtype As String
    Dim srno As Integer
    Dim itname As String
    Dim itcode As Integer
    Dim pcs As Decimal
    Dim pack As Decimal
    Dim qty As Decimal
    Dim rate As Decimal
    Dim unit As String
    Dim amount As Decimal
    Dim vrno As String
    Dim accode As Integer
    Dim accodecr As Integer
    Dim itcode2 As String
    Dim ch As String
    Dim prcode As Integer
    Dim process As String
    Dim style1 As String
    Dim mstcode As Integer
    Dim mst As String
    Dim width As Decimal
    Dim grpcs As Decimal
    Dim grmtr As Decimal
    Dim grrate As Decimal
    Dim grval As Decimal
    Dim desgno As String
    Dim lotno1 As String
    Dim Mbillno As String
    Dim fromwhere As String = "MILL"
    Dim srno1 As New ListBox
    Dim maxentry As Integer
    Dim txtvrno As New TextBox
    Dim billdate As New Date
    Dim spcs As Decimal
    Dim sqty As Decimal
    Dim sgramt As Decimal
    Dim sgrdisper As Decimal = 0
    Dim sgrdis As Decimal = 0
    Dim sexc As Decimal = 0
    Dim svatper As Decimal = 0
    Dim svat As Decimal = 0
    Dim sadvatper As Decimal = 0
    Dim sadvat As Decimal = 0
    Dim sgst As Decimal = 0
    Dim scst As Decimal = 0
    Dim ssertax As Decimal = 0
    Dim saddnara As Decimal = 0
    Dim saddper As Decimal = 0
    Dim slessnara As Decimal = 0
    Dim sprefix As String = "-"
    Dim sjvvrno As String = "-"
    Dim snetamt As Decimal = 0
    Dim sinwords As String = "-"
    Dim sremark As String = "-"
    Dim soutamt As Decimal = 0
    Dim sispaid As String = "f"
    Dim sworkno As String = "-"
    Dim sshipto As String = "-"
    Dim sgrpcs As Decimal = 0
    Dim sgrqty As Decimal = 0
    Dim sgrval As Decimal = 0
    Dim sdelvary As Integer = 1
    Dim spttime As String = "-"
    Dim svehicalno As String = "-"
    Dim saddamt As Decimal = 0
    Dim lvrno As String = ""
    Dim lbook As String = ""
    Dim ldate1 As String
    Dim laccode As Integer = 0
    Dim lacname As String = ""
    Dim ldr As Decimal = 0
    Dim lcr As Decimal = 0
    Dim lbal As Decimal = 0
    Dim lremark As String = ""
    Dim lref As String = ""
    Dim lopname As String = ""
    Dim lopcode As Decimal = 0

    Private Sub closing()
        Try
            ' update1()
            Dim i As Integer
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim grmtr As Decimal = 0
            Dim grpcs As Decimal = 0
            connect()
            '  MsgBox(ds.Tables("lotr").Rows.Count)
            For i = 0 To ds.Tables("lotr").Rows.Count - 1
                cmd = New SqlCommand("update tblLotrt set gbalmtr=gbalmtr+'" & ds.Tables("lotr").Rows(i).Item(2).ToString & "' where lotno='" & ds.Tables("lotr").Rows(i).Item(5).ToString & "' and sr='" & ds.Tables("lotr").Rows(i).Item(0).ToString & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("update tblLotr set gbalmtr=gbalmtr+'" & ds.Tables("lotr").Rows(i).Item(2).ToString & "' where lotno='" & ds.Tables("lotr").Rows(i).Item(5).ToString & "'", cn)
                cmd.ExecuteNonQuery()
                If ds.Tables("lotr").Rows(i).Item(2) > 0 Then
                    cmd = New SqlCommand("update tblLotr set gbalpcs=gbalpcs+'1' where lotno='" & ds.Tables("lotr").Rows(i).Item(5).ToString & "'", cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            '   MsgBox(ds2.Tables("lotr").Rows.Count)
            For i = 0 To ds2.Tables("lotr").Rows.Count - 1
                cmd = New SqlCommand("update tblLotrt set gbalmtr=gbalmtr-'" & ds2.Tables("lotr").Rows(i).Item(2).ToString & "' where lotno='" & ds2.Tables("lotr").Rows(i).Item(5).ToString & "' and sr='" & ds2.Tables("lotr").Rows(i).Item(0).ToString & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("update tblLotr set gbalmtr=gbalmtr-'" & ds2.Tables("lotr").Rows(i).Item(2).ToString & "' where lotno='" & ds2.Tables("lotr").Rows(i).Item(5).ToString & "'", cn)
                cmd.ExecuteNonQuery()
                If ds2.Tables("lotr").Rows(i).Item(2) > 0 Then
                    cmd = New SqlCommand("update tblLotr set gbalpcs=gbalpcs-'1' where lotno='" & ds2.Tables("lotr").Rows(i).Item(5).ToString & "'", cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub FRMDISPATCH_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '   update1()
        closing()
    End Sub
    Private Sub bindGrid()
        ' DataGridView1.DataSource = ds.Tables(0) ' To get Data Table for the Grid View
        setAutoComplete()
    End Sub

    Private Sub setAutoComplete()
        Dim cmd As New SqlCommand
        Dim DR As SqlDataReader
        connect()
        cmd = New SqlCommand("Select * from prmst", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            procee.Add(DR.Item("process").ToString)
        End While
        DR.Close()
        cmd = New SqlCommand("Select * from stylemst", cn)
        DR = cmd.ExecuteReader
        While DR.Read
            style.Add(DR.Item("style").ToString)
        End While
        DR.Close()
        close1()
    End Sub
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dg1.EditingControlShowing

        If dg1.CurrentCell.ColumnIndex = 14 Or dg1.CurrentCell.ColumnIndex = 13 AndAlso TypeOf e.Control Is TextBox Then ' Checking Whether the Editing Control Column Index is 1 or not if 1 Then Enabling Auto Complete Extender
            Dim editingControl As TextBox = TryCast(e.Control, TextBox)
            If editingControl IsNot Nothing Then
                AddHandler editingControl.KeyPress, AddressOf Me.tx_KeyPress
                RemoveHandler Me.dg1.EditingControlShowing, AddressOf Me.DataGridView1_EditingControlShowing
                GoTo LAST
            End If
        End If
        If dg1.CurrentCell.ColumnIndex = 3 AndAlso TypeOf e.Control Is TextBox Then ' Checking Whether the Editing Control Column Index is 1 or not if 1 Then Enabling Auto Complete Extender
            Dim editingControl1 As TextBox = TryCast(e.Control, TextBox)
            With DirectCast(editingControl1, TextBox)
                .AutoCompleteCustomSource = procee
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                GoTo LAST
            End With
            '  Else ' we are not Enabling Auto Complete Extendar
            '     With DirectCast(e.Control, TextBox)
            '.AutoCompleteMode = AutoCompleteMode.None
            '  End With
        End If
        If dg1.CurrentCell.ColumnIndex = 5 AndAlso TypeOf e.Control Is TextBox Then ' Checking Whether the Editing Control Column Index is 1 or not if 1 Then Enabling Auto Complete Extender
            Dim editingControl1 As TextBox = TryCast(e.Control, TextBox)
            With DirectCast(editingControl1, TextBox)
                .AutoCompleteCustomSource = style
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                GoTo LAST
            End With
            '  Else ' we are not Enabling Auto Complete Extendar
            '     With DirectCast(e.Control, TextBox)
            '.AutoCompleteMode = AutoCompleteMode.None
            '  End With
        End If
        
LAST:
    End Sub
    Private Sub tx_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            Try
                If (Me.dg1.CurrentCell.ColumnIndex = 14) Then
                    onlyNumbers(sender, e)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            '     If (Me.dgpurch.CurrentCell.ColumnIndex = 3 Or dgpurch.CurrentCell.ColumnIndex = 4 Or dgpurch.CurrentCell.ColumnIndex = 5 Or dgpurch.CurrentCell.ColumnIndex = 6) Then
            'onlyNumbers(sender, e)
            ' End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub billno123()
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select max(BILLno) from sale", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Try
                    txtBillNosecond.Text = Val(dr.Item(0)) + 1
                    txtInvoiceNo.Text = txtBillNosecond.Text
                Catch ex As Exception
                    txtBillNosecond.Text = 1
                    txtInvoiceNo.Text = txtBillNosecond.Text
                End Try

            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub maxVrNo(ByRef tb As TextBox, ByVal ds As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            cmd = New SqlCommand("Select VrNo from " & ds, cn)
            dr = cmd.ExecuteReader
            Dim maxVrNo As Integer
            maxVrNo = 0
            While dr.Read
                If maxVrNo < dr.Item("VrNo").ToString.Substring(3) Then
                    maxVrNo = dr.Item("VrNo").ToString.Substring(3)
                End If
            End While
            dr.Close()
            tb.Text = maxVrNo + 1
            tb.Text = acycode & "/" & tb.Text
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gridfill1()
        Try
            '   MsgBox(FRMDISPATCH.editcheck)
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("select Vrno,billdt,billno,Name,Pcs,Qty,NetAmt,BKName,mst,delvary from sale", cn)
            da.Fill(ds)
            dg3.DataSource = ds.Tables(0)
            Try
                dg3.Columns(0).Visible = False
                '   dg3.Item(1, dg3.RowCount - 1).Selected = True
                dg3.Focus()
            Catch ex As Exception
                ' MsgBox(ex.ToString)
            End Try
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub FRMDISPATCH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select acname from tblAccount where book='Sales'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtbkname1.AutoCompleteCustomSource.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select acname from tblAccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtNamecr.AutoCompleteCustomSource.Add(dr.Item(0))
            End While
            dr.Close()
            Dim cmdprocess As New SqlCommand
            Dim drprocess As SqlDataReader

            cmdprocess = New SqlCommand("select * from prmst", cn)
            drprocess = cmdprocess.ExecuteReader
            While drprocess.Read
                ListBox1.Items.Add(drprocess.Item(1))
            End While
            drprocess.Close()
            cmdprocess = New SqlCommand("select * from stylemst", cn)
            drprocess = cmdprocess.ExecuteReader
            While drprocess.Read
                ListBox2.Items.Add(drprocess.Item(1))
            End While
            drprocess.Close()
            close1()

            With Me
                .ds2.Tables.Add("lotr")
                .ds2.Tables("lotr").Columns.Add("srno")
                .ds2.Tables("lotr").Columns.Add("Gbalmtr")
                .ds2.Tables("lotr").Columns.Add("GBALMtr")
                .ds2.Tables("lotr").Columns.Add("Fmtr")
                .ds2.Tables("lotr").Columns.Add("Desc")
                .ds2.Tables("lotr").Columns.Add("LotNo")
                .ds2.Tables("lotr").Columns(0).DataType = GetType(Decimal)
                .ds2.Tables("lotr").Columns.Add("Sales1rno")
            End With
            With Me
                .ds.Tables.Add("lotr")
                .ds.Tables("lotr").Columns.Add("srno")
                .ds.Tables("lotr").Columns.Add("Gbalmtr")
                .ds.Tables("lotr").Columns.Add("GBALMtr")
                .ds.Tables("lotr").Columns.Add("Fmtr")
                .ds.Tables("lotr").Columns.Add("Desc")
                .ds.Tables("lotr").Columns.Add("LotNo")
                .ds.Tables("lotr").Columns(0).DataType = GetType(Decimal)
                .ds.Tables("lotr").Columns.Add("Sales1rno")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        dg3.BringToFront()
        dg3.Visible = True
        gridfill1()
        Try
            dg3.Item(1, dg3.RowCount - 1).Selected = True
        Catch ex As Exception

        End Try

        txtBillNofirst.Text = acycode & "/"
        bindGrid()
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        MaskedTextBox1.Text = Format(Date.Today, "dd-MM-yyyy")
        ComboBox1.Items.Add(acycode & "/")
        ComboBox1.Items.Add(acycode - 1 & "/")
        ComboBox1.Items.Add(acycode - 2 & "/")
        ComboBox1.Items.Add(acycode - 3 & "/")
        ComboBox1.Items.Add(acycode - 4 & "/")
        ComboBox1.Items.Add(acycode - 5 & "/")
        ComboBox1.Text = ComboBox1.Items(0).ToString
        connect()
        Dim cmd2 As New SqlCommand
        Dim dr2 As SqlDataReader
        cmd2 = New SqlCommand("select accode from tblaccount where acname='" & txtNamecr.Text & "'", cn)
        dr2 = cmd2.ExecuteReader
        While dr2.Read
            txtAccodecr.Text = dr2.Item(0)
        End While
        dr2.Close()
        cmd2 = New SqlCommand("select billsr from tblAccount where acname='" & txtNamecr.Text & "'", cn)
        dr2 = cmd2.ExecuteReader
        While dr2.Read
            TextBox19.Text = dr2.Item(0)
        End While
        dr2.Close()
        close1()

    End Sub
    Private Sub filldataset()
        Try
            Dim i As Integer
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            Dim li As New ListBox
            cmd = New SqlCommand("select distinct lotno from salet where vrno='" & txtvrno1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                li.Items.Add(dr.Item(0))
            End While
            dr.Close()
            ds2.Tables("Lotr").Rows.Clear()
            ds.Tables("Lotr").Rows.Clear()
            '   MsgBox(li.Items.Count - 1)
            For i = 0 To li.Items.Count - 1
                '  MsgBox(dg1.Item(1, i).Value & dg1.Item(2, i).Value)
                cmd = New SqlCommand("select srno,grmtr,qty,remark,lotno,sr from salet where lotno='" & li.Items(i).ToString & "' AND VRNO='" & txtvrno1.Text & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim dt As DataRow = ds2.Tables("lotr").NewRow
                    dt.Item(0) = dr.Item(0)
                    dt.Item(1) = dr.Item(1)
                    dt.Item(2) = dr.Item(1)
                    dt.Item(3) = dr.Item(2)
                    dt.Item(4) = dr.Item(3)
                    dt.Item(5) = dr.Item(4)
                    dt.Item(6) = dr.Item(5)
                    ds2.Tables("lotr").Rows.Add(dt)
                    Dim dt1 As DataRow = ds.Tables("lotr").NewRow
                    dt1.Item(0) = dr.Item(0)
                    dt1.Item(1) = dr.Item(1)
                    dt1.Item(2) = dr.Item(1)
                    dt1.Item(3) = dr.Item(2)
                    dt1.Item(4) = dr.Item(3)
                    dt1.Item(5) = dr.Item(4)
                    dt1.Item(6) = dr.Item(5)
                    ds.Tables("lotr").Rows.Add(dt1)
                End While
                dr.Close()
                ' MsgBox("ok")
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub fillsale1()
        Try
            dg1.Rows.Clear()
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from sale1 where vrno='" & txtvrno1.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, i).Value = dr.Item("Srno")
                dg1.Item(1, i).Value = dr.Item("lotno").ToString.Substring(0, 3)
                dg1.Item(2, i).Value = dr.Item("lotno").ToString.Substring(3)
                dg1.Item(3, i).Value = dr.Item("process")
                dg1.Item(4, i).Value = dr.Item("itname")
                dg1.Item(5, i).Value = dr.Item("style")
                dg1.Item(6, i).Value = dr.Item("mst")
                dg1.Item(7, i).Value = dr.Item("width")
                dg1.Item(8, i).Value = dr.Item("grpcs")
                dg1.Item(9, i).Value = dr.Item("grmtr")
                dg1.Item(10, i).Value = dr.Item("grrate")
                dg1.Item(11, i).Value = dr.Item("grval")
                dg1.Item(12, i).Value = dr.Item("pcs")
                dg1.Item(13, i).Value = dr.Item("qty")
                dg1.Item(14, i).Value = dr.Item("rate")
                dg1.Item(15, i).Value = dr.Item("amount")
                i = i + 1
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.GotFocus, txtbkname1.GotFocus, txtregcode1.GotFocus, txtBillNosecond.GotFocus, txtBillNofirst.GotFocus, TextBox14.GotFocus, TextBox15.GotFocus, TextBox16.GotFocus, TextBox17.GotFocus, TextBox18.GotFocus, TextBox19.GotFocus, txtNamecr.GotFocus, txtJvvrno.GotFocus, TextBox21.GotFocus, txtAccodecr.GotFocus, txtAccode.GotFocus, TextBox24.GotFocus, txtVehicalno.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, txtvrno1.GotFocus, txtInvoiceNo.GotFocus, txtDelv.GotFocus, txtMarka.GotFocus, txtGroup.GotFocus, MaskedTextBox1.GotFocus, ComboBox1.GotFocus
        sender.backcolor = Color.Pink
    End Sub

    Private Sub txtBillNosecond_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBillNosecond.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub txtBillNosecond_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillNosecond.KeyUp

    End Sub

    Private Sub txtBillNosecond_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBillNosecond.Leave
        Try
            If txtBillNosecond.Text.Trim.Length = 0 Then
                MsgBox("Bill no can not be blank")
                txtBillNosecond.Focus()
                GoTo en
            End If
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select * from sale where billno='" & txtInvoiceNo.Text.Trim & " '", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("Duplicate billno")
                txtBillNosecond.Focus()
            End If
            close1()

en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox1_lostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus, txtbkname1.LostFocus, txtregcode1.LostFocus, txtBillNosecond.LostFocus, txtBillNofirst.LostFocus, TextBox14.LostFocus, TextBox15.LostFocus, TextBox16.LostFocus, TextBox17.LostFocus, TextBox18.LostFocus, TextBox19.LostFocus, txtNamecr.LostFocus, txtJvvrno.LostFocus, TextBox21.LostFocus, txtAccodecr.LostFocus, txtAccode.LostFocus, TextBox24.LostFocus, txtVehicalno.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus, txtvrno1.LostFocus, txtInvoiceNo.LostFocus, txtDelv.LostFocus, txtMarka.LostFocus, txtGroup.LostFocus, MaskedTextBox1.LostFocus, ComboBox1.LostFocus
        sender.backcolor = Color.White
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgacm.RowCount <> 0 Then
                txtName.Text = dgacm.Item(1, dgacm.CurrentCell.RowIndex).Value
            End If
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            cmd = New SqlCommand("select * from tblAccount where acname='" & txtName.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Try
                    txtMarka.Text = dr.Item("marko")
                    txtGroup.Text = dr.Item("pgroup")
                    TextBox3.Text = dr.Item("Add1") & "," & dr.Item("Add2")
                    TextBox4.Text = dr.Item("mstname")
                    txtAccode.Text = dr.Item("accode")
                    TextBox24.Text = dr.Item("mstcode")
                Catch ex As Exception

                End Try
            End While
            dr.Close()
            close1()
            dgacm.Visible = False
            MaskedTextBox1.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            dgacm.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyUp
        Try

            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter(acm(txtName.Text), cn)
            da.Fill(ds)
            dgacm.DataSource = ds.Tables(0)
            dgacm.Visible = True
            dgacm.AutoResizeColumns()
            dgacm.Top = txtName.Top + 22
            dgacm.BringToFront()
            close1()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus
        MaskedTextBox1.SelectionStart = 0
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtInvoiceNo.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtName.Focus()
        End If
    End Sub
    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvoiceNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDelv.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            MaskedTextBox1.Focus()
        End If
    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDelv.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicalno.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtInvoiceNo.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupBox1.Enabled = False
        dg1.Rows.Clear()
        dg1.Rows.Add()
        dg1.Focus()
    End Sub
    Private Sub dg1_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellLeave
        If e.ColumnIndex = 3 Then
            ListBox1.Visible = False

        End If
        If e.ColumnIndex = 5 Then
            ListBox2.Visible = False
        End If
        If e.ColumnIndex = 2 Then
            prcheck = 1
        End If
    End Sub
    Private Sub dg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                If dg1.CurrentCell.ColumnIndex = dg1.ColumnCount - 1 Then
                    dg1.Rows(dg1.CurrentCell.RowIndex).ReadOnly = True
                    dg1.Rows(dg1.CurrentCell.RowIndex).DefaultCellStyle.ForeColor = Color.Red
                    dg1.Rows.Add()
                    dg1.Item(0, dg1.CurrentCell.RowIndex + 1).Selected = True
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dg1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg1.RowsAdded
        dg1.Item(0, e.RowIndex).Value = e.RowIndex + 1
        dg1.Item(1, e.RowIndex).Value = ComboBox1.Text
        dg1.Item(12, e.RowIndex).Value = 0.0
        dg1.Item(13, e.RowIndex).Value = 0.0
        If e.RowIndex <> 0 Then
            dg1.Item(3, e.RowIndex).Value = dg1.Item(3, e.RowIndex - 1).Value
            dg1.Item(5, e.RowIndex).Value = dg1.Item(5, e.RowIndex - 1).Value
            GoTo en
        End If
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim maxbillno As String = ""
            cmd = New SqlCommand("Select max(convert(int,billno)) from sale where bkname='" & txtbkname1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                maxbillno = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select process,style from sale1 where billno='" & maxbillno & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Item(3, 0).Value = dr.Item(0)
                dg1.Item(5, 0).Value = dr.Item(1)
            End While
            dr.Close()
            close1()
        Catch ex As Exception

        End Try

en:
    End Sub

   
    Public Sub caldispatch()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            TextBox14.Text = Val(TextBox14.Text) + dg1.Item(15, i).Value
            TextBox15.Text = Val(TextBox15.Text) + dg1.Item(13, i).Value
            TextBox16.Text = Val(TextBox16.Text) + dg1.Item(12, i).Value
            TextBox17.Text = Val(TextBox17.Text) + dg1.Item(9, i).Value
            TextBox18.Text = Val(TextBox18.Text) + dg1.Item(8, i).Value
        Next

        For i = 0 To dg1.Rows.Count - 1

        Next

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        closing()
        dg3.SendToBack()
        dg3.Visible = False

        txtMaxbill.Text = 0
        editcheck = 1
        GroupBox1.Enabled = True
        closing()
        billno123()
        maxVrNo(txtvrno1, "sale")
        txtName.Focus()
        Label22.Text = "ADD"
        Label23.Text = "ADD"
        dg1.Rows.Clear()
    End Sub
    Private Sub dg1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellValidated
        Dim prcheck As Integer = 0
        Dim stcheck As Integer = 0
        Try
            If e.ColumnIndex = 2 Then
                Try
                    If dg1.CurrentCell.Value.ToString.Length = 0 Then

                    End If
                Catch ex As Exception
                    If MsgBox("You want to exit from entry", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        GoTo en2
                    End If
                End Try
            End If

            If e.ColumnIndex = 3 Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select process from prmst where process='" & dg1.CurrentCell.Value & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Close()
                Else
                    dr.Close()
                    If MsgBox("Want to add new process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Try
                            If dg1.CurrentCell.Value.ToString.Length = 0 Then
                                MsgBox("Process can not be blank")
                                dg1.CurrentCell.Selected = True
                                GoTo en
                            End If

                        Catch ex As Exception
                            MsgBox("Process can not be blank")
                            dg1.CurrentCell.Selected = True
                            prcheck = 1
                            GoTo en

                        End Try
                        Dim txt1 As New TextBox
                        myserialno("prmst", txt1, "prcode")
                        connect()
                        cmd = New SqlCommand("Insert into prmst values(" & txt1.Text & ",'" & dg1.CurrentCell.Value & "')", cn)
                        cmd.ExecuteNonQuery()
                        MsgBox("Inserted")
                        close1()
                    End If


                End If
                close1()

            End If
            If e.ColumnIndex = 5 Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select style from stylemst where style='" & dg1.CurrentCell.Value & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Close()
                Else
                    dr.Close()
                    If MsgBox("Want to add new style", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Try
                            If dg1.CurrentCell.Value.ToString.Length = 0 Then
                                MsgBox("Style can not be blank")
                                dg1.CurrentCell.Selected = True
                                GoTo en
                            End If

                        Catch ex As Exception
                            MsgBox("Style can not be blank")
                            dg1.CurrentCell.Selected = True
                            stcheck = 1
                            GoTo en

                        End Try
                        Dim txt1 As New TextBox
                        myserialno("stylemst", txt1, "stycode")
                        connect()
                        cmd = New SqlCommand("Insert into stylemst values(" & txt1.Text & ",'" & dg1.CurrentCell.Value & "')", cn)
                        cmd.ExecuteNonQuery()
                        MsgBox("Inserted")
                        close1()
                    End If


                End If
                close1()

            End If
            If e.ColumnIndex <> 2 Then
                lotcheck = 0
            End If
            If e.ColumnIndex = 2 Then
                If dg1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red Then
                    Label23.Text = "EDIT"
                End If
            End If
            If lotcheck = 0 Then
                If e.ColumnIndex = 2 Then
                    If Label23.Text = "ADD" Then
                        connect()
                        Dim cmd As New SqlCommand
                        Dim dr As SqlDataReader
                        cmd = New SqlCommand("select * from tbllotr where lotno='" & dg1.Item(1, e.RowIndex).Value.ToString & dg1.Item(2, e.RowIndex).Value.ToString & "'", cn)
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            dr.Close()
                        Else
                            dr.Close()
                            dg1.Item(2, e.RowIndex).Selected = True
                            MsgBox("Lotno not exists")
                            SendKeys.Send("{LEFT}")
                            GoTo label
                        End If
                        cmd = New SqlCommand("select * from tbllotr where lotno='" & dg1.Item(1, e.RowIndex).Value.ToString & dg1.Item(2, e.RowIndex).Value.ToString & "' and isdesp='f'", cn)
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            dr.Close()
                        Else
                            dr.Close()
                            dg1.Item(2, e.RowIndex).Selected = True
                            MsgBox("! lot has been canceled")
                            SendKeys.Send("{LEFT}")
                            GoTo en
                        End If
                        dr.Close()
                        cmd = New SqlCommand("select * from tbllotr where lotno='" & dg1.Item(1, e.RowIndex).Value.ToString & dg1.Item(2, e.RowIndex).Value.ToString & "' and acname='" & txtName.Text & "'", cn)
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            dr.Close()
                        Else
                            dr.Close()
                            dg1.Item(2, e.RowIndex).Selected = True
                            Dim cmd2 As New SqlCommand
                            Dim dr2 As SqlDataReader
                            Dim acname As String = ""
                            cmd2 = New SqlCommand("select acname from tbllotr where lotno='" & dg1.Item(1, e.RowIndex).Value.ToString & dg1.Item(2, e.RowIndex).Value.ToString & "'", cn)
                            dr2 = cmd2.ExecuteReader
                            While dr2.Read
                                acname = dr2.Item(0)
                            End While
                            dr2.Close()
                            If MsgBox("! Wrong Party Name " & " Correct party  " & acname & ". Want to see the Lotlist", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
label:
                                Dim da As New SqlDataAdapter
                                Dim ds As New DataSet
                                da = New SqlDataAdapter("select date,lotno,ichno,lrno,mst,gbalpcs,gbalmtr,isdesp,item,weg from tbllotr where acname='" & txtName.Text & "' and gbalmtr<>0", cn)
                                da.Fill(ds)
                                dg2.DataSource = ds.Tables(0)
                                If dg2.RowCount = 0 Then
                                    MsgBox("No lot for selected party")
                                    dg1.Item(2, e.RowIndex).Selected = True
                                    dg2.Visible = False
                                    GoTo en
                                End If
                                dg2.Visible = True
                                Label24.Visible = True
                                dg2.BringToFront()
                                lotcheck = 1
                                'dg2.Focus()
                                ' dg1.Item(0, e.RowIndex).Selected = True
                                GoTo en
                            Else
                                dg1.Item(2, e.RowIndex).Selected = True
                                SendKeys.Send("{LEFT}")
                            End If
                            GoTo en
                        End If
                        dr.Close()
                        close1()
                        frmlotdetail.Label14.Text = "ADD"
                        lotno = dg1.Item(1, dg1.CurrentCell.RowIndex).Value.ToString & dg1.Item(2, dg1.CurrentCell.RowIndex).Value.ToString
                        Try
                            frmlotdetail.Show()
                            Me.Hide()
                        Catch ex As Exception
                            Me.Show()
                            SendKeys.Send("{LEFT}")
                        End Try


                    Else
                        frmlotdetail.Label14.Text = "EDIT"
                        lotno = dg1.Item(1, dg1.CurrentCell.RowIndex).Value.ToString & dg1.Item(2, dg1.CurrentCell.RowIndex).Value.ToString
                        Try
                            frmlotdetail.Show()
                            Me.Hide()
                        Catch ex As Exception
                            Me.Show()
                            SendKeys.Send("{LEFT}")
                        End Try

                        '   Me.Hide()
                    End If
                End If
            End If
            If e.ColumnIndex = dg1.ColumnCount - 2 Then
                dg1.Item(dg1.ColumnCount - 1, e.RowIndex).Value = Format(Val(Math.Round((dg1.Item(dg1.ColumnCount - 2, e.RowIndex).Value) * Val(dg1.Item(dg1.ColumnCount - 3, e.RowIndex).Value), 0)), "0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
        If prcheck = 1 Then
            prcheck = 0
            SendKeys.Send("{LEFT}")
        End If
        If stcheck = 1 Then
            stcheck = 1
            SendKeys.Send("{LEFT}")
        End If
        If lotcheck = 1 Then
            '   dg1.Item(1, e.RowIndex).Selected = True
            ' MsgBox("q")
            ' dg1.Enabled = False
            dg2.Focus()
        End If
        If e.ColumnIndex = 15 Then
            caldispatch()
        End If
en2:
        '  MsgBox(lotcheck)
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg2.KeyDown
        If e.KeyCode = Keys.Enter Then
            connect()
            Dim cmd As New SqlCommand("Select rlotno from tblLotr where lotno='" & dg2.Item(1, dg2.CurrentCell.RowIndex).Value.ToString & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                dg1.Item(2, dg1.CurrentCell.RowIndex).Value = dr.Item(0)
                dg1.Item(2, dg1.CurrentCell.RowIndex).Selected = True
            End While
            dr.Close()
            close1()
            lotcheck = 0
            dg1.Focus()
            dg2.Visible = False
        ElseIf e.KeyCode = Keys.F10 Then
            dg2.Visible = False
            dg1.Item(1, dg1.CurrentCell.RowIndex).Selected = True
            dg1.Focus()
            Label24.Visible = False
        End If
    End Sub
    Private Function check1() As Boolean
        If txtAccode.Text.Trim.Length = 0 Or txtAccode.Text = "0" Then
            MsgBox("Select proper AcDr")
            Return False
        ElseIf txtAccodecr.Text.Trim.Length = 0 Or txtAccodecr.Text = "0" Then
            MsgBox("Select proper AcCr")
            Return False
        ElseIf txtName.Text.Trim.Length = 0 Then
            MsgBox("AcDr can not be blank")
            Return False
        ElseIf txtNamecr.Text.Trim.Length = 0 Then
            MsgBox("AcCr can not be blank")
            Return False
        ElseIf txtBillNofirst.Text.Trim.Length = 0 Then
            MsgBox("Wrong bill no")
            Return False
        ElseIf txtBillNosecond.Text.Trim.Length = 0 Then
            MsgBox("Wrong bill no")
            Return False
        ElseIf txtInvoiceNo.Text.Trim.Length = 0 Then
            MsgBox("Invoice no can not be blank")
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        caldispatch()
        If check1() Then
        Else
            GoTo en1
        End If
        If Label22.Text = "ADD" Then
            Try
                Dim dat As New Date
                dat = MaskedTextBox1.Text
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                Dim itcode As Integer = 0
                Dim prcode As Integer = 0
                Dim mstcode As Integer = 0
                Dim a() As String = {txtvrno1.Text, txtbkname1.Text, txtregcode1.Text, txtInvoiceNo.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtBillNosecond.Text, txtBillNofirst.Text & txtBillNosecond.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtName.Text, txtNamecr.Text, Val(TextBox16.Text), Val(TextBox15.Text), Val(TextBox14.Text), 0, TextBox19.Text, txtJvvrno.Text, Val(TextBox14.Text), AmtInWord(Val(TextBox14.Text)), TextBox21.Text, txtAccode.Text, txtAccodecr.Text, TextBox24.Text, TextBox4.Text, TextBox18.Text, TextBox17.Text, 0, txtDelv.Text, Today.TimeOfDay.ToString, txtVehicalno.Text}
                myinsert(a, "sale")
                Dim I As Integer
                For I = 0 To dg1.RowCount - 1
                    connect()
                    Try
                        If dg1.Item(12, I).Value = 0 Then
                            GoTo en
                        End If

                    Catch ex As Exception

                    End Try
                    CMD = New SqlCommand("select itcode from tblitem where itname='" & dg1.Item(4, I).Value.ToString & "'", cn)
                    connect()
                    dr = CMD.ExecuteReader
                    While dr.Read
                        itcode = dr.Item(0)
                    End While
                    dr.Close()
                    CMD = New SqlCommand("select prcode from prmst where process='" & dg1.Item(3, I).Value.ToString & "'", cn)
                    dr = CMD.ExecuteReader
                    While dr.Read
                        prcode = dr.Item(0)
                    End While
                    dr.Close()
                    CMD = New SqlCommand("select mstcode from mst where mst='" & dg1.Item(6, I).Value.ToString & "'", cn)
                    dr = CMD.ExecuteReader
                    While dr.Read
                        mstcode = dr.Item(0)
                    End While
                    dr.Close()
                    Dim b() As String = {txtvrno1.Text, txtbkname1.Text, txtregcode1.Text, txtInvoiceNo.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtBillNosecond.Text, txtBillNofirst.Text & txtBillNosecond.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtName.Text, txtNamecr.Text, dg1.Item(0, I).Value, dg1.Item(4, I).Value, itcode, dg1.Item(12, I).Value, "1", dg1.Item(13, I).Value, dg1.Item(14, I).Value, "MTR", dg1.Item(15, I).Value, txtAccode.Text, txtAccodecr.Text, prcode, dg1.Item(3, I).Value, dg1.Item(5, I).Value, mstcode, dg1.Item(6, I).Value, dg1.Item(7, I).Value, dg1.Item(8, I).Value, dg1.Item(9, I).Value, dg1.Item(10, I).Value, dg1.Item(11, I).Value, 0, dg1.Item(1, I).Value & dg1.Item(2, I).Value}
                    myinsert(b, "sale1")
                Next
en:
                For I = 0 To ds.Tables("lotr").Rows.Count - 1
                    Dim c() As String = {txtvrno1.Text, txtbkname1.Text, txtregcode1.Text, txtInvoiceNo.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtBillNosecond.Text, txtBillNofirst.Text & txtBillNosecond.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtName.Text, txtNamecr.Text, txtAccode.Text, txtAccodecr.Text, ds.Tables("lotr").Rows(I).Item(0).ToString, ds.Tables("lotr").Rows(I).Item(3).ToString, ds.Tables("lotr").Rows(I).Item(2).ToString, ds.Tables("lotr").Rows(I).Item(5).ToString, ds.Tables("lotr").Rows(I).Item(6).ToString, ds.Tables("lotr").Rows(I).Item(4).ToString}
                    myinsert(c, "salet")
                Next

                '  dr.Close()
                close1()
                ds.Tables("lotr").Rows.Clear()
                close1()
                MsgBox("Success")

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Try
                connect()
                Dim cmdde As New SqlCommand
                cmdde = New SqlCommand("delete from sale1 where vrno='" & txtvrno1.Text & "'", cn)
                cmdde.ExecuteNonQuery()
                cmdde = New SqlCommand("delete from salet where vrno='" & txtvrno1.Text & "'", cn)
                cmdde.ExecuteNonQuery()
                cmdde = New SqlCommand("delete from sale where vrno='" & txtvrno1.Text & "'", cn)
                cmdde.ExecuteNonQuery()
                Dim vrno As String = ""
                Dim drde As SqlDataReader
                cmdde = New SqlCommand("Select vrno from salesc where billno='" & txtBillNosecond.Text & "' and bkname='" & txtbkname1.Text & "'", cn)
                drde = cmdde.ExecuteReader
                While drde.Read
                    vrno = drde.Item(0)
                End While
                drde.Close()
                cmdde = New SqlCommand("DELETE FROM SALeSC WHERE BILLNO='" & txtBillNosecond.Text & "' and bkname='" & txtbkname1.Text & "'", cn)
                cmdde.ExecuteNonQuery()
                cmdde = New SqlCommand("Delete from salec1 where billno='" & txtBillNosecond.Text & "' and bkname='" & txtbkname1.Text & "'", cn)
                cmdde.ExecuteNonQuery()
                cmdde = New SqlCommand("Delete from tblLedg where book='Sales' and vrno='" & vrno & "'", cn)
                cmdde.ExecuteNonQuery()
                close1()

                Dim dat As New Date
                dat = MaskedTextBox1.Text
                Dim CMD As New SqlCommand
                Dim dr As SqlDataReader
                Dim itcode As Integer = 0
                Dim prcode As Integer = 0
                Dim mstcode As Integer = 0
                Dim a() As String = {txtvrno1.Text, txtbkname1.Text, txtregcode1.Text, txtInvoiceNo.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtBillNosecond.Text, txtBillNofirst.Text & txtBillNosecond.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtName.Text, txtNamecr.Text, Val(TextBox16.Text), Val(TextBox15.Text), Val(TextBox14.Text), 0, TextBox19.Text, txtJvvrno.Text, Val(TextBox14.Text), AmtInWord(Val(TextBox14.Text)), TextBox21.Text, txtAccode.Text, txtAccodecr.Text, TextBox24.Text, TextBox4.Text, TextBox18.Text, TextBox17.Text, 0, txtDelv.Text, Today.TimeOfDay.ToString, txtVehicalno.Text}
                myinsert(a, "sale")
                Dim I As Integer
                For I = 0 To dg1.RowCount - 1
                    connect()
                    CMD = New SqlCommand("select itcode from tblitem where itname='" & dg1.Item(4, I).Value.ToString & "'", cn)
                    connect()
                    dr = CMD.ExecuteReader
                    While dr.Read
                        itcode = dr.Item(0)
                    End While
                    dr.Close()
                    CMD = New SqlCommand("select prcode from prmst where process='" & dg1.Item(3, I).Value.ToString & "'", cn)
                    dr = CMD.ExecuteReader
                    While dr.Read
                        prcode = dr.Item(0)
                    End While
                    dr.Close()
                    CMD = New SqlCommand("select mstcode from mst where mst='" & dg1.Item(6, I).Value.ToString & "'", cn)
                    dr = CMD.ExecuteReader
                    While dr.Read
                        mstcode = dr.Item(0)
                    End While
                    dr.Close()
                    Dim b() As String = {txtvrno1.Text, txtbkname1.Text, txtregcode1.Text, txtInvoiceNo.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtBillNosecond.Text, txtBillNofirst.Text & txtBillNosecond.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtName.Text, txtNamecr.Text, dg1.Item(0, I).Value, dg1.Item(4, I).Value, itcode, dg1.Item(12, I).Value, "1", dg1.Item(13, I).Value, dg1.Item(14, I).Value, "MTR", dg1.Item(15, I).Value, txtAccode.Text, txtAccodecr.Text, prcode, dg1.Item(3, I).Value, dg1.Item(5, I).Value, mstcode, dg1.Item(6, I).Value, dg1.Item(7, I).Value, dg1.Item(8, I).Value, dg1.Item(9, I).Value, dg1.Item(10, I).Value, dg1.Item(11, I).Value, 0, dg1.Item(1, I).Value & dg1.Item(2, I).Value}
                    myinsert(b, "sale1")
                Next
                For I = 0 To ds.Tables("lotr").Rows.Count - 1
                    Dim c() As String = {txtvrno1.Text, txtbkname1.Text, txtregcode1.Text, txtInvoiceNo.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtBillNosecond.Text, txtBillNofirst.Text & txtBillNosecond.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, txtName.Text, txtNamecr.Text, txtAccode.Text, txtAccodecr.Text, ds.Tables("lotr").Rows(I).Item(0).ToString, ds.Tables("lotr").Rows(I).Item(3).ToString, ds.Tables("lotr").Rows(I).Item(2).ToString, ds.Tables("lotr").Rows(I).Item(5).ToString, ds.Tables("lotr").Rows(I).Item(6).ToString, ds.Tables("lotr").Rows(I).Item(4).ToString}
                    myinsert(c, "salet")
                Next
                ds.Tables("lotr").Rows.Clear()
                ds2.Tables("lotr").Rows.Clear()
                close1()
                MsgBox("Success")

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            '  deletecode()
        End If
        dg1.Rows.Clear()
        Try
            Dim txtmaxbill As New TextBox
            txtmaxbill.Text = 0
            If Val(txtMaxBill.Text) > 0 Then
                ' option1()
            Else
                option2()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en1:
    End Sub
    Private Sub option2()
        Dim CMD As New SqlCommand
        Dim DR As SqlDataReader
        Dim VALUE As String = ""
        connect()

        CMD = New SqlCommand("SELECT VALUE FROM TBLSETUP WHERE BOOK='LOTR' AND OPERATION='TRANSFER'", cn)
        DR = CMD.ExecuteReader
        While DR.Read
            VALUE = DR.Item(0)
        End While
        DR.Close()
        close1()
        If VALUE = "TRUE" Then
            bkname = txtbkname1.Text
            bkcode = txtregcode1.Text
            billdate = MaskedTextBox1.Text
            maxentry = Val(txtMaxbill.Text)
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text
            dat2 = MaskedTextBox1.Text
            Dim sql As String
            connect()
            Dim liaccode As New ListBox
            '  Dim cmd As New SqlCommand
            ' Dim dr As SqlDataReader
            CMD = New SqlCommand("Select billsr from tblAccount where accode='" & txtregcode1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                sprefix = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select distinct accode from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and billno='" & txtBillNosecond.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                liaccode.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Dim k As Integer
            Dim liacname As New ListBox
            For k = 0 To liaccode.Items.Count - 1
                cmd = New SqlCommand("Select acname from tblAccount where accode=" & liaccode.Items(k), cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    liacname.Items.Add(dr.Item(0))
                End While
                dr.Close()
            Next
            For k = 0 To liaccode.Items.Count - 1
                srno1.Items.Clear()
                connect()
                sql = "Select serilano from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and accode=" & liaccode.Items(k) & " and billno='" & txtBillNosecond.Text & "' and bkname='" & txtbkname1.Text & "'"
                cmd = New SqlCommand(sql, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    srno1.Items.Add(dr.Item(0))
                End While
                dr.Close()
                '   MsgBox(srno1.Items.Count)
                txtMaxbill.Text = srno1.Items.Count
                maxentry = Val(txtMaxbill.Text)
                '    MsgBox(liacname.Items(k) & TextBox2.Text)
                transfer1(liacname.Items(k), txtNamecr.Text, liaccode.Items(k), txtAccodecr.Text)
                txtMaxbill.Text = 0
                close1()
            Next
            close1()
        End If
    End Sub
    Private Sub option1()
        If MsgBox("Are you sure want to transfer", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            bkname = txtBKNAME1.Text
            bkcode = txtREGCODE1.Text
            billdate = MaskedTextBox1.Text
            maxentry = 0
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text
            dat2 = MaskedTextBox1.Text
            Dim sql As String
            connect()
            Dim liaccode As New ListBox
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select billsr from tblAccount where acname='" & txtbkname1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                sprefix = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select distinct accode from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and billno='" & txtBillNosecond.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                liaccode.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Dim k As Integer
            Dim liacname As New ListBox
            For k = 0 To liaccode.Items.Count - 1
                cmd = New SqlCommand("Select acname from tblAccount where accode=" & liaccode.Items(k), cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    liacname.Items.Add(dr.Item(0))
                End While
                dr.Close()
            Next
            dr.Close()
            For k = 0 To liaccode.Items.Count - 1
                srno1.Items.Clear()
                sql = "Select serilano from sale1 where billdt>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and billdt<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and accode=" & liaccode.Items(k)
                cmd = New SqlCommand(sql, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    srno1.Items.Add(dr.Item(0))
                End While
                dr.Close()
                '   MsgBox(srno1.Items.Count)
                '   MsgBox(liacname.Items(k), TextBox2.Text)
                transfer1(liacname.Items(k), txtNamecr.Text, liaccode.Items(k), txtAccodecr.Text)
            Next
            close1()
        End If
    End Sub
    Private Sub transfer1(ByVal name1 As String, ByVal namecr1 As String, ByVal accode1 As Integer, ByVal accodecr1 As Integer)

        Dim count1 As Integer = 0
        Dim check As Integer = 0

        If (srno1.Items.Count / maxentry) = 0 Then
            check = 1
        Else
            check = 0
        End If
        If check = 0 Then
l:
            If count1 + 1 < (srno1.Items.Count / maxentry) + 1 Then
                maxVrNo(txtvrno, "salesc")
                '   MsgBox(name1 & namecr1)
                insert11(count1, billnocount, accode1, name1, namecr1, accodecr1)
                count1 = count1 + 1
                GoTo l
            Else
                GoTo en
            End If

        Else
m:
            If count1 + 1 <= srno1.Items.Count / maxentry Then
                maxVrNo(txtvrno, "salesc")
                '   MsgBox(name1 & namecr1)
                insert11(count1, billnocount, accode1, name1, namecr1, accodecr1)
                count1 = count1 + 1
                GoTo m
            Else
                GoTo en
            End If

        End If
en:
    End Sub
    Private Sub insert11(ByRef count1 As Integer, ByRef billno2 As String, ByRef accode1 As Integer, ByVal name1 As String, ByVal namecr1 As String, ByVal accodecr1 As Integer)
        Dim i As Integer
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        '   MsgBox(count1)
        spcs = 0
        sqty = 0
        sgramt = 0
        snetamt = 0
        sgrpcs = 0
        sgrqty = 0
        sgrval = 0
        For i = 1 To maxentry
            ' MsgBox((maxentry * count1 + i - 1))
            If (maxentry * count1 + i - 1) > (srno1.Items.Count - 1) Then
                GoTo en
            End If
            connect()
            cmd = New SqlCommand("select * from sale1 where serilano=" & srno1.Items(maxentry * count1 + i - 1), cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ' bkname = TextBox1.Text
                'bkcode = txtRegCode.Text
                chno = dr.Item("chno")
                MaskedTextBox1.Text = dr.Item("chdt")
                chdt = MaskedTextBox1.Text
                billno = billno
                oubno = acycode & "/" & billno
                '   MaskedTextBox3.Text = 
                '    billdt = MaskedTextBox3.Text
                '  name = dr.Item("Name")
                ' namecr = dr.Item("Namecr")
                'purtype = dr.Item("Purtype")
                srno = i
                itname = dr.Item("itname")
                itcode = dr.Item("itcode")
                pcs = dr.Item("pcs")
                spcs = spcs + Val(dr.Item("pcs"))
                pack = dr.Item("pack")

                qty = dr.Item("qty")
                sqty = sqty + Val(dr.Item("qty"))
                rate = dr.Item("rate")
                unit = dr.Item("unit")
                amount = dr.Item("amount")
                sgramt = sgramt + Val(dr.Item("amount"))
                '     MsgBox(sgramt)
                '  accode = dr.Item("accode")
                ' accodecr = dr.Item("accodecr")
                '   itcode2 = 0
                '  ch = 0
                prcode = dr.Item("prcode")
                process = dr.Item("process")
                style1 = dr.Item("style")
                mstcode = dr.Item("mstcode")
                mst = dr.Item("mst")
                width = dr.Item("width")
                grpcs = dr.Item("grpcs")
                sgrpcs = sgrpcs + Val(dr.Item("grpcs"))
                grmtr = dr.Item("grmtr")
                sgrqty = sgrqty + Val(dr.Item("grmtr"))
                grrate = dr.Item("grrate")
                grval = dr.Item("grval")
                sgrval = sgrval + Val(dr.Item("grval"))
                desgno = dr.Item("desgno")
                lotno1 = dr.Item("lotno")
                Mbillno = dr.Item("billno")
            End While
            dr.Close()

            Dim a() As String = {bkname, bkcode, chno, chdt.Month & "-" & chdt.Day & "-" & chdt.Year, billno2, acycode & "/" & billno2, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, name1, namecr1, " ", srno, itname, itcode, pcs, pack, qty, rate, unit, amount, txtvrno.Text, accode1, accodecr1, 0, 0, prcode, process, style1, mstcode, mst, width, grpcs, grmtr, grrate, grval, desgno, lotno1, Mbillno, "MILL"}
            myinsert(a, "salec1")

            close1()
        Next
en:
        snetamt = sgramt
        sinwords = AmtInWord(snetamt)
        soutamt = snetamt
        sispaid = "f"

        Dim b() As String = {txtvrno.Text, bkname, bkcode, "chno", billdate.Month & "-" & billdate.Day & "-" & billdate.Year, billno2, acycode & "/" & billno2, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, name1, namecr1, " ", spcs, sqty, sgramt, sgrdisper, sgrdis, sexc, svatper, svat, sadvatper, sadvat, sgst, scst, ssertax, saddnara, saddper, saddamt, slessnara, sprefix, sjvvrno, snetamt, sinwords, sremark, accode1, accodecr1, soutamt, sispaid, sworkno, sshipto, mstcode, mst, sgrpcs, sgrqty, sgrval, sdelvary, spttime, svehicalno}
        myinsert(b, "salesc")

        lvrno = txtvrno.Text
        lbook = "Sales"
        laccode = accode1
        lacname = name1
        ldr = snetamt
        lcr = 0
        lbal = -snetamt
        lremark = ""
        lref = ""
        lopname = namecr1
        lopcode = accodecr1

        Dim c() As String = {lvrno, lbook, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, laccode, lacname, ldr, lcr, lbal, lremark, lref, lopname, lopcode}
        myinsert(c, "tblLedg")

        lvrno = txtvrno.Text
        lbook = "Sales"
        laccode = accodecr1
        lacname = namecr1
        ldr = 0
        lcr = snetamt
        lbal = snetamt
        lremark = ""
        lref = ""
        lopname = name1
        lopcode = accode1
        '   MsgBox("0")
        Dim d() As String = {lvrno, lbook, billdate.Month & "-" & billdate.Day & "-" & billdate.Year, laccode, lacname, ldr, lcr, lbal, lremark, lref, lopname, lopcode}
        myinsert(d, "tblLedg")
        gridfill1()
        If Label22.Text = "EDIT" Then
            Try
                'MsgBox("Here")
                dg3.Item(1, currentrow + 1).Selected = True
            Catch ex As Exception

            End Try
        Else
            Try
                dg3.Item(1, dg3.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try

        End If
        '  MsgBox("f")

    End Sub
    Private Function billnocount() As String
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim billsr As String
            Dim billno As Integer
            Dim maxbill As Integer = 0
            Dim place As Integer
            Dim yesno As String
            connect()
            cmd = New SqlCommand("Select billsr from tblAccount where ACcode=" & txtREGCODE1.Text, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                billsr = dr.Item(0)
            End While
            dr.Close()
            cmd = New SqlCommand("Select SRYN from tblAccount where ACCode=" & txtREGCODE1.Text, cn)
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
                cmd = New SqlCommand("Select MaxBill from tblAccount where BKCOde=" & txtREGCODE1.Text, cn)
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
                Return billsr & str1
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
                cmd = New SqlCommand("Select MaxBill from tblAccount where ACCOde=" & txtREGCODE1.Text, cn)
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
                '   MsgBox(str1)
                Return str1
            End If
            '    txtBillSr.Text = billsr

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        closing()
        MsgBox("CANCELED")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim I As Integer
        Dim CMD As New SqlCommand
        connect()
        Dim li As New ListBox
        For I = 0 To ds.Tables("LOTR").Rows.Count - 1
            If ds.Tables("LOTR").Rows(I).Item(5).ToString = dg1.Item(1, dg1.CurrentCell.RowIndex).Value & dg1.Item(2, dg1.CurrentCell.RowIndex).Value And ds.Tables("lotr").Rows(I).Item(6).ToString = dg1.Item(0, dg1.CurrentCell.RowIndex).Value Then
                li.Items.Add(I)
                Dim gbalmtr As Decimal = 0
                Dim gbalmtr1 As Decimal = 0
                Dim gbalpcs As Decimal = 0
                '  Dim isdesp As String = "f"
                CMD = New SqlCommand("Select gbalmtr from tblLotrt where Sr=" & ds.Tables("LOTR").Rows(I).Item(0).ToString & " and lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
                Dim dr As SqlDataReader
                dr = CMD.ExecuteReader
                While dr.Read
                    gbalmtr = Val(dr.Item(0).ToString) + Val(ds.Tables("LOTR").Rows(I).Item(2).ToString)
                End While
                dr.Close()
                CMD = New SqlCommand("Select gbalmtr,gbalpcs from tblLotr where lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
                dr = CMD.ExecuteReader
                While dr.Read
                    gbalmtr1 = Val(dr.Item(0).ToString) + Val(ds.Tables("LOTR").Rows(I).Item(2).ToString)
                    If ds.Tables("lotr").Rows(I).Item(2).ToString > 0 Then
                        gbalpcs = Val(dr.Item(1)) + 1
                    End If
                End While
                dr.Close()
                CMD = New SqlCommand("Update tbllotrt set gbalmtr=" & gbalmtr & " where Sr=" & ds.Tables("LOTR").Rows(I).Item(0).ToString & " and lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
                CMD.ExecuteNonQuery()
                CMD = New SqlCommand("Update tbllotr set gbalmtr=" & gbalmtr1 & " where lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
                CMD.ExecuteNonQuery()
                If ds.Tables("lotr").Rows(I).Item(2).ToString > 0 Then
                    CMD = New SqlCommand("Update tbllotr set gbalpcs=" & gbalpcs & " where lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
                    CMD.ExecuteNonQuery()
                End If
            End If
        Next
        For I = 0 To li.Items.Count - 1
            ds.Tables("lotr").Rows.RemoveAt(Val(li.Items(I).ToString) - I)
        Next
        Try
            dg1.Rows.RemoveAt(dg1.CurrentCell.RowIndex)
        Catch ex As Exception


        End Try
        close1()
        '      Else
        '         Dim I As Integer
        '        Dim CMD As New SqlCommand
        '       connect()
        '      For I = 0 To ds.Tables("LOTR").Rows.Count - 1
        '       If ds.Tables("LOTR").Rows(I).Item(5).ToString = dg1.Item(2, dg1.CurrentCell.RowIndex).Value Then
        'Dim gbalmtr As Decimal = 0
        '       Dim gbalmtr1 As Decimal = 0
        '      Dim gbalpcs As Decimal = 0
        '        CMD = New SqlCommand("Select gbalmtr from tblLotrt where Sr=" & ds.Tables("LOTR").Rows(I).Item(0).ToString & " and lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
        '       Dim dr As SqlDataReader
        '      dr = CMD.ExecuteReader
        '     While dr.Read
        'gbalmtr = Val(dr.Item(0).ToString) + Val(ds.Tables("LOTR").Rows(I).Item(2).ToString)
        '    End While
        ''    dr.Close()
        '   CMD = New SqlCommand("Select gbalmtr,gbalpcs from tblLotr where lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
        '     dr = CMD.ExecuteReader
        '    While dr.Read
        'gbalmtr1 = Val(dr.Item(0).ToString) + Val(ds.Tables("LOTR").Rows(I).Item(2).ToString)
        '  If ds.Tables ("lotr").Rows (I).Item (2
        '   End While
        '  dr.Close()

        '       CMD = New SqlCommand("Update tbllotrt set gbalmtr=" & gbalmtr & " where Sr=" & ds.Tables("LOTR").Rows(I).Item(0).ToString & " and lotno='" & ds.Tables("LOTR").Rows(I).Item(5).ToString & "'", cn)
        '      CMD.ExecuteNonQuery()
        ' End If
        '    Next
        '     dg1.Rows.RemoveAt(dg1.CurrentCell.RowIndex)
        '    close1()

        '     End If
    End Sub
    Private Sub dgacm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgacm.RowCount <> 0 Then
                txtName.Text = dgacm.Item(1, dgacm.CurrentCell.RowIndex).Value
            End If
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            cmd = New SqlCommand("select * from tblAccount where acname='" & txtName.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Try
                    txtMarka.Text = dr.Item("marko")
                    txtGroup.Text = dr.Item("pgroup")
                    TextBox3.Text = dr.Item("Add1") & "," & dr.Item("Add2")
                    TextBox4.Text = dr.Item("mstname")
                    txtAccode.Text = dr.Item("accode")
                    TextBox24.Text = dr.Item("mstcode")
                Catch ex As Exception

                End Try
            End While
            dr.Close()
            close1()
            dgacm.Visible = False
            MaskedTextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJvvrno.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub deletecode()
        Try
            connect()
            Dim i As Integer
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim lotno As New ListBox
            Dim grmtr As New ListBox
            Dim grpcs As New ListBox
            Dim srno As New ListBox
            cmd = New SqlCommand("select * from salet where VrNo='" & txtvrno1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                lotno.Items.Add(dr.Item("lotno"))
                grmtr.Items.Add(dr.Item("grmtr"))
                srno.Items.Add(dr.Item("srno"))
            End While
            dr.Close()
            Dim gbalmtr As Decimal = 0
            For i = 0 To lotno.Items.Count - 1
                cmd = New SqlCommand("select gbalmtr from tbllotrt where lotno='" & lotno.Items(i).ToString & "' and sr=" & srno.Items(i).ToString, cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    gbalmtr = dr.Item(0)
                End While
                dr.Close()
                cmd = New SqlCommand("update tbllotrt set gbalmtr=" & gbalmtr + Val(grmtr.Items(i).ToString) & " where lotno='" & lotno.Items(i).ToString & "' and sr=" & srno.Items(i).ToString, cn)
                cmd.ExecuteNonQuery()
            Next
            lotno.Items.Clear()
            grmtr.Items.Clear()
            cmd = New SqlCommand("select lotno,grmtr,grpcs from sale1 where vrno='" & txtvrno1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                lotno.Items.Add(dr.Item("lotno"))
                grmtr.Items.Add(dr.Item("grmtr"))
                grpcs.Items.Add(dr.Item("grpcs"))
            End While
            dr.Close()
            Dim gbalmtr1 As Decimal = 0
            Dim gbalpcs As Decimal = 0
            '  Dim isdesp As String = "f"
            For i = 0 To lotno.Items.Count - 1
                gbalmtr1 = 0
                gbalpcs = 0
                cmd = New SqlCommand("select gbalmtr,gbalpcs from tbllotr where lotno='" & lotno.Items(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    gbalmtr1 = dr.Item(0)
                    gbalpcs = dr.Item(1)
                End While
                dr.Close()
                cmd = New SqlCommand("update tbllotr set gbalmtr=" & gbalmtr1 + Val(grmtr.Items(i).ToString) & " where lotno='" & lotno.Items(i).ToString & "'", cn)
                cmd.ExecuteNonQuery()
                If gbalpcs - Val(Val(grpcs.Items(i).ToString)) > 0 Then
                    ' isdesp = "f"
                    cmd = New SqlCommand("update tbllotr set gbalpcs=" & gbalpcs + Val(grpcs.Items(i).ToString) & " where lotno='" & lotno.Items(i).ToString & "'", cn)
                    cmd.ExecuteNonQuery()
                Else
                    '  isdesp = "t"
                    cmd = New SqlCommand("update tbllotr set gbalpcs=" & gbalpcs + Val(grpcs.Items(i).ToString) & " where lotno='" & lotno.Items(i).ToString & "'", cn)
                    cmd.ExecuteNonQuery()
                End If

            Next

            '*******************************deletecode**********************************
            cmd = New SqlCommand("delete from sale where VrNo='" & txtvrno1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("delete from sale1 where VrNo='" & txtvrno1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("delete from salet where VrNo='" & txtvrno1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            Dim vrno As String = ""
            Dim drde As SqlDataReader
            cmd = New SqlCommand("Select vrno from salesc where billno='" & txtBillNosecond.Text & "' and bkname='" & txtbkname1.Text & "'", cn)
            drde = cmd.ExecuteReader
            While drde.Read
                vrno = drde.Item(0)
            End While
            drde.Close()
            cmd = New SqlCommand("DELETE FROM SALeSC WHERE BILLNO='" & txtBillNosecond.Text & "' and bkname='" & txtbkname1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Delete from salec1 where billno='" & txtBillNosecond.Text & "' and bkname='" & txtbkname1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Delete from tblLedg where book='Sales' and vrno='" & vrno & "'", cn)
            cmd.ExecuteNonQuery()
            ds.Tables("lotr").Rows.Clear()
            ds2.Tables("lotr").Rows.Clear()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub clearall()
        txtName.Clear()
        '  TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        txtvrno1.Clear()
        txtInvoiceNo.Clear()
        txtDelv.Clear()
        'TextBox8.Clear()
        txtGroup.Clear()
        ' TextBox10.Clear()
        'TextBox11.Clear()
        txtBillNosecond.Clear()
        '  TextBox13.Clear()
        '    TextBox19.Clear()
        '  TextBox20.Clear()
        TextBox21.Clear()
        '     TextBox22.Clear()
        txtAccode.Clear()
        TextBox24.Clear()
        txtVehicalno.Clear()
        dg1.Rows.Clear()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        closing()
        If MsgBox("Are you sure want to delete entry", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            currentrow = dg3.CurrentCell.RowIndex
            deletecode()
            clearall()
            MsgBox("Deleted")
            gridfill1()
            Try
                If currentrow <= dg3.RowCount - 1 Then
                    dg3.Item(1, currentrow).Selected = True
                End If

            Catch ex As Exception
                '   MsgBox(ex.ToString)
            End Try


        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Label23.Text = "EDIT"
        Label22.Text = "EDIT"

        dg3.SendToBack()
        dg3.Visible = False
        Try
            currentrow = dg3.CurrentCell.RowIndex
        Catch ex As Exception

        End Try

        txtMaxbill.Text = 0
        filldataset()
        ' closing()
        '     Me.Hide()
        If frmbilldis.editcheck = 1 Then
            GroupBox1.Enabled = False
            ' dg1.Columns(0).ReadOnly = True
            '  dg1.Columns(1).ReadOnly = True
            ' dg1.Columns(2).ReadOnly = True
            'dg1.Columns(3).ReadOnly = True
            '   dg1.Columns(4).ReadOnly = True
            '  dg1.Columns(5).ReadOnly = True
            ' dg1.Columns(6).ReadOnly = True
            '   dg1.Columns(7).ReadOnly = True
            '  dg1.Columns(8).ReadOnly = True
            ' dg1.Columns(9).ReadOnly = True
            '  dg1.Columns(10).ReadOnly = True
            ' dg1.Columns(12).ReadOnly = True
            '  dg1.Columns(13).ReadOnly = True
            ' dg1.Columns(15).ReadOnly = True
            '    dg1.Columns(14).ReadOnly = True
            ' dg1.Item(14, 0).Selected = True
            '        MsgBox("het")
        End If

        ' frmbilldis.Close()
        'frmbilldis.Show()
        dg1.Focus()
    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub TextBox25_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVehicalno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtDelv.Focus()
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Label23.Text = "EDIT"
        dg1.CurrentRow.ReadOnly = False
        dg1.Focus()

    End Sub
    Private Sub dgacm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgacm.CellContentClick
    End Sub
    Private Sub dg1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg1.Leave
    End Sub
    Private Sub dg1_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            If e.ColumnIndex = 14 Then
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                cmd = New SqlCommand("Select * from RateMst where Pgroup='" & txtGroup.Text & "' and Process='" & dg1.Item(3, e.RowIndex).Value & "' and style='" & dg1.Item(5, e.RowIndex).Value & "' and acname='" & txtName.Text & "' and mst='" & TextBox4.Text & "' and item='" & dg1.Item(4, e.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                '    MsgBox(TextBox9.Text & "-" & dg1.Item(3, e.RowIndex).Value & "-" & dg1.Item(5, e.RowIndex).Value & "-" & TextBox1.Text & "-" & TextBox4.Text & "-" & dg1.Item(5, e.RowIndex).Value)
                If dr.HasRows = True Then
                    '  MsgBox("het")
                    While dr.Read
                        dg1.Item(14, e.RowIndex).Value = dr.Item("Rate")
                    End While
                    dr.Close()
                Else
                    If MsgBox("You want to insert rate for this combination", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim value As Decimal
                        value = InputBox("Rate")
                        Dim a() As String = {txtGroup.Text, txtName.Text, TextBox4.Text, dg1.Item(3, e.RowIndex).Value, dg1.Item(5, e.RowIndex).Value, dg1.Item(4, e.RowIndex).Value, value}
                        myinsert(a, "RateMst")
                        MsgBox("Inserted")
                        dg1.Item(14, e.RowIndex).Value = value
                    End If

                End If
                close1()
            End If
            If e.ColumnIndex = 3 Then
                Dim re As New Rectangle
                re = dg1.GetCellDisplayRectangle(dg1.CurrentCell.ColumnIndex, dg1.CurrentCell.RowIndex, True)
                '  ListBox1.Top = re.Top + 360
                ' ListBox1.Left = re.Left + 40
                '      ListBox1.Visible = True
                ListBox1.SelectedIndex = 0
                If dg1.CurrentCell.Value.ToString.Trim.Length <> 0 Then
                    ListBox1.SelectedItem = dg1.CurrentCell.Value
                End If

                '     ListBox1.Focus()
                ' MsgBox("het")
            End If
            If e.ColumnIndex = 5 Then
                Dim re As New Rectangle
                re = dg1.GetCellDisplayRectangle(dg1.CurrentCell.ColumnIndex, dg1.CurrentCell.RowIndex, True)
                ' ListBox2.Top = re.Top + 360
                'ListBox2.Left = re.Left + 40
                '     ListBox2.Visible = True
                If dg1.CurrentCell.Value.ToString.Trim.Length <> 0 Then
                    ListBox2.SelectedItem = dg1.CurrentCell.Value
                End If
                '  ListBox2.SelectedItem = dg1.CurrentCell.Value
                '  MsgBox("j")
                '   ListBox2.Focus()
            End If
        Catch ex As Exception
            '   MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dg1.Item(3, dg1.CurrentCell.RowIndex).Value = ListBox1.SelectedItem.ToString
                dg1.Focus()
                dg1.Item(5, dg1.CurrentCell.RowIndex).Selected = True
                ListBox1.Visible = False
            ElseIf e.KeyCode = Keys.Left Then
                dg1.Item(2, dg1.CurrentCell.RowIndex).Selected = True
                dg1.Focus()
                ListBox1.Visible = False
            ElseIf e.KeyCode = Keys.Right Then
                dg1.Item(5, dg1.CurrentCell.RowIndex).Selected = True
                dg1.Focus()
                ListBox1.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ListBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dg1.Item(5, dg1.CurrentCell.RowIndex).Value = ListBox2.SelectedItem.ToString
                dg1.Item(14, dg1.CurrentCell.RowIndex).Selected = True
                ListBox2.Visible = False
                dg1.Focus()
            ElseIf e.KeyCode = Keys.Left Then
                dg1.Item(3, dg1.CurrentCell.RowIndex).Selected = True
                dg1.Focus()
                ListBox2.Visible = False
            ElseIf e.KeyCode = Keys.Right Then
                dg1.Item(13, dg1.CurrentCell.RowIndex).Selected = True
                dg1.Focus()
                ListBox2.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox1.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Or DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter Date in Current A/c Year")
                MaskedTextBox1.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox1.Focus()
        End Try
    End Sub

    Private Sub Button1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Up Then
            txtVehicalno.Focus()
            '  MsgBox("het")
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            closing()
            Me.Hide()
            frmbilldis.Close()
            editcheck = 1
            '   frmbilldis.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbkname1.Leave
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select accode from tblaccount where acname='" & txtbkname1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtregcode1.Text = dr.Item(0)
            End While
            dr.Close()
            close1()
            If txtregcode1.Text.Trim.Length = 0 Then
                MsgBox("Select proper account")
                txtbkname1.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNamecr.Leave
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select accode from tblaccount where acname='" & txtNamecr.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtAccodecr.Text = dr.Item(0)
            End While
            dr.Close()
            close1()
            If txtAccodecr.Text.Trim.Length = 0 Then
                MsgBox("Select proper account")
                txtName.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceNo.Leave
        Try
            If txtInvoiceNo.Text.Trim.Length = 0 Then
                MsgBox("Invoice no can not be blank")
                txtInvoiceNo.Focus()
                GoTo en
            End If
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select * from sale where billno='" & txtInvoiceNo.Text.Trim & " '", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("Duplicate billno")
                txtInvoiceNo.Focus()
            End If
            close1()

en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dg3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg3.CellEnter
        Try
            '    closing()
            edlotno1 = dg3.Item(0, dg3.CurrentCell.RowIndex).Value
            txtvrno1.Text = edlotno1
            GroupBox1.Enabled = False
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from sale where vrno='" & edlotno1 & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtbkname1.Text = dr.Item("bkname")
                txtregcode1.Text = dr.Item("bkcode")
                txtNamecr.Text = dr.Item("Namecr")
                txtAccode.Text = dr.Item("accode")
                txtName.Text = dr.Item("Name")
                txtAccodecr.Text = dr.Item("accodecr")
                txtJvvrno.Text = dr.Item("jvvrno")
                txtBillNosecond.Text = dr.Item("billno")
                txtInvoiceNo.Text = dr.Item("chno")
                txtDelv.Text = dr.Item("delvary")
                txtVehicalno.Text = dr.Item("vehicalno")
                MaskedTextBox1.Text = Format(dr.Item("billdt"), "dd-MM-yyyy")
                TextBox19.Text = dr.Item("prefix")

            End While
            dr.Close()
            cmd = New SqlCommand("select * from tblaccount where acname='" & txtName.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox4.Text = dr.Item("mstname")
                TextBox24.Text = dr.Item("mstcode")
                txtMarka.Text = dr.Item("marko")
                txtGroup.Text = dr.Item("pgroup")
                TextBox3.Text = dr.Item("add1") & "," & dr.Item("add2") & "," & dr.Item("place")
            End While
            dr.Close()
            fillsale1()
         '   filldataset()
            caldispatch()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub

    Private Sub dg3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg3.CellContentClick

    End Sub

    Private Sub dg3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg3.KeyDown
        '   If e.KeyCode = Keys.Enter Then
        'dg3.SendToBack()
        'End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        closing()
        dg3.BringToFront()
        dg3.Visible = True
    End Sub

    Private Sub txtInvoiceNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceNo.KeyPress
        numbersonly(sender, e)
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub
End Class