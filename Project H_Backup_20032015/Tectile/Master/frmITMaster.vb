Imports System.Data.SqlClient
Imports OnBarcode.Barcode
Imports System.IO

Public Class frmITMaster
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim check As Integer
    Dim timercount As Integer
    Dim tb As Integer
    Public ittypecheck As Integer = 0
    Public unitcheck As Integer = 0
    Dim CLOSECHEK As Integer = 0
    Dim TV1 As String
    Dim TEMP1 As Integer
    Dim TEMP2 As Integer

    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItcode.GotFocus, txtItname.GotFocus, txttype.GotFocus, txtUnit.GotFocus, txtRate.GotFocus, txtcopyItname.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItcode.LostFocus, txtItname.LostFocus, txttype.LostFocus, txtUnit.LostFocus, txtRate.LostFocus, txtcopyItname.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmITMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOSECHEK = 1 Then
            If frmITBalance.itbalance = 1 Then
                frmITBalance.Show()
                frmITBalance.ListBox1.Visible = False
            ElseIf Form3.newit = 1 Then
                Form3.Show()
                Form3.dg1main.Item(1, Form3.dg1main.SelectedCells.Item(0).RowIndex).Selected = True
            ElseIf frmSale.newit = 1 Then
                frmSale.Show()
                frmSale.maindg.Item(1, frmSale.maindg.SelectedCells.Item(0).RowIndex).Selected = True
            ElseIf frmlotr.itcheck = 1 Then
                frmlotr.Show()
                frmlotr.txtITName.Focus()
            ElseIf frmit2.ITCHECK = 1 Then
                frmit2.Show()
                frmit2.TextBox1.Focus()
            ElseIf frmitEM3.ITCHECK = 1 Then
                frmitEM3.Show()
                frmitEM3.TextBox1.Focus()
            ElseIf frmLotNew.itcheck = 1 Then
                frmLotNew.Show()
                frmLotNew.txtITNAME.Focus()
                Me.Close()

            End If

        End If
    End Sub
    Private Sub frmITMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmITMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            If frmITBalance.itbalance = 1 Or Form3.newit = 1 Or frmSale.newit = 1 Or frmlotr.itcheck = 1 Or frmit2.ITCHECK = 1 Or frmitEM3.ITCHECK = 1 Or frmLotNew.itcheck = 1 Then
                check = 1
                Label5.Text = "ADD MODE"
                myfilldatagrid(dg1, "tblItem")
                Try
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                Catch ex As Exception
                End Try
                GroupBox1.Enabled = True
                myserialno("tblItem", txtItcode, "ITCode")
                txtItname.Clear()
                '    TextBox3.Clear()
                '   TextBox4.Clear()
                txtRate.Clear()
                txtItname.Focus()
                CLOSECHEK = 1
            Else
                connect()
                myfilldatagrid(dg1, "tblItem")
                'myhide()
                dg1.Columns(0).Width = 80
                dg1.Columns(1).Width = 180
                dg1.Columns(2).Width = 150
                dg1.Item(0, dg1.RowCount - 1).Selected = True

            End If
            '  If check = 1 Then
            'ElseIf check = 2 Then
            ' End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            check = 1
            Label5.Text = "ADD MODE"
            GroupBox1.Enabled = True
            myserialno("tblItem", txtItcode, "ITCode")
            txtItname.Clear()
            '      TextBox3.Clear()
            '     TextBox4.Clear()
            txtRate.Clear()
            txtItname.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub printbarcode()
        Dim barcode As OnBarcode.Barcode.Linear
        barcode = New OnBarcode.Barcode.Linear()
        barcode.Type = BarcodeType.CODE128
        barcode.Data = "zwe" & txtItcode.Text
        barcode.X = 1
        barcode.Y = 60
        barcode.drawBarcode(Application.StartupPath & "//barcode//" & "temp" & txtItcode.Text & ".png")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try

            If txtRate.Text.Trim.Length = 0 Then
                txtRate.Text = "0.00"
            End If
            If txtItname.Text.Trim.Length = 0 Then
                MsgBox("Item Name can not be blank")
                txtItname.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {txtItcode.Text, txtItname.Text, txttype.Text, txtUnit.Text, txtRate.Text}
                If duplicate("tblITEM", "ITNAME", txtItname) Then
                    MsgBox(" Name already exists")
                    txtItname.Focus()
                    GoTo en
                Else
                End If
                'myinsert(a, "tblItem")
                Try
                    connect()
                Catch ex As Exception

                End Try
                Try
                    printbarcode()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Try
                    Dim lFSFileStream As FileStream
                    Dim lBRBinaryReader As BinaryReader
                    Dim lBImageByte As Byte()
                    lFSFileStream = New FileStream(Application.StartupPath & "//barcode//" & "temp" & txtItcode.Text & ".png", FileMode.Open)
                    lBRBinaryReader = New BinaryReader(lFSFileStream)
                    lBImageByte = New Byte(lFSFileStream.Length + 1) {}
                    lBImageByte = lBRBinaryReader.ReadBytes(Convert.ToInt32(lFSFileStream.Length))
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("insert into tblItem values(@itcode,@itname,@ittype,@itunit,@rate,@barcode1)", cn)
                    cmd.Parameters.AddWithValue("@itcode", txtItcode.Text)
                    cmd.Parameters.AddWithValue("@itname", txtItname.Text)
                    cmd.Parameters.AddWithValue("@ittype", txttype.Text)
                    cmd.Parameters.AddWithValue("@itunit", txtUnit.Text)
                    cmd.Parameters.AddWithValue("@rate", txtRate.Text)
                    cmd.Parameters.AddWithValue("@barcode1", lBImageByte)
                    cmd.ExecuteNonQuery()
                    ' dt.Item(0) = lBImageByte
                    'ds.Tables("tblLogo").Rows.Add(dt)
                    lFSFileStream.Close()
                    'rptlogo.SetDataSource(ds)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                close1()
                Label12.Visible = True
                Timer1.Enabled = True
                If frmITBalance.itbalance = 1 Then
                    frmITBalance.Show()
                    frmITBalance.txtItName.Text = txtItname.Text
                    frmITBalance.ListBox1.Visible = False
                    frmITBalance.txtQty.Focus()
                    CLOSECHEK = 0
                    Me.Close()
                ElseIf Form3.newit = 1 Then
                    Form3.Show()
                    Form3.dg1main.Item(1, Form3.dg1main.SelectedCells.Item(0).RowIndex).Selected = True
                    Form3.txtITName.Text = txtItname.Text
                    CLOSECHEK = 0
                    Me.Close()
                ElseIf frmSale.newit = 1 Then
                    frmSale.Show()
                    frmSale.maindg.Item(2, frmSale.maindg.SelectedCells.Item(0).RowIndex).Selected = True

                    frmSale.txtITName.Text = txtItname.Text
                    CLOSECHEK = 0
                    Me.Close()
                ElseIf frmlotr.itcheck = 1 Then
                    frmlotr.Show()
                    frmlotr.txtITName.Text = txtItname.Text
                    frmlotr.txtITName.Focus()
                    frmlotr.txtWidth.Focus()
                    frmlotr.ListBox1.Visible = False
                    CLOSECHEK = 0
                    Me.Close()
                ElseIf frmit2.ITCHECK = 1 Then
                    frmit2.Show()
                    frmit2.TextBox1.Text = txtItname.Text
                    frmit2.TextBox5.Text = txtItname.Text
                    frmit2.TextBox1.Focus()
                    frmit2.TextBox6.Focus()
                    frmit2.TextBox2.Text = 1
                    frmit2.TextBox3.Text = txtRate.Text
                    frmit2.ListBox1.Visible = False
                    CLOSECHEK = 0
                    Me.Close()
                ElseIf frmitEM3.ITCHECK = 1 Then
                    frmitEM3.Show()
                    frmitEM3.TextBox1.Text = txtItname.Text
                    frmitEM3.TextBox5.Text = txtItname.Text
                    frmitEM3.TextBox1.Focus()
                    frmitEM3.TextBox6.Focus()
                    frmitEM3.TextBox2.Text = 1
                    frmitEM3.TextBox3.Text = txtRate.Text
                    frmitEM3.ListBox1.Visible = False
                    CLOSECHEK = 0
                    Me.Close()
                ElseIf frmLotNew.itcheck = 1 Then
                    frmLotNew.Show()
                    frmLotNew.txtITNAME.Text = txtItname.Text
                    frmLotNew.txtITCODE.Text = txtItcode.Text
                    frmLotNew.txtWidth.Focus()
                    frmLotNew.ListBox1.Visible = False
                    CLOSECHEK = 0
                    Me.Close()

                Else
                    myfilldatagrid(dg1, "tblItem")
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                    dg1.Refresh()
                    txtItcode.Clear()
                    txtItname.Clear()
                    '     TextBox3.Clear()
                    '    TextBox4.Clear()
                    txtRate.Clear()
                    txtItname.Focus()
                    myserialno("tblItem", txtItcode, "ITCode")
                End If
            ElseIf check = 2 Then
                'MsgBox("het")

                ' MsgBox("desai")
                Dim a() As String = {txtItcode.Text, txtItname.Text, txttype.Text, txtUnit.Text, txtRate.Text}
                If txtItname.Text.Trim <> txtcopyItname.Text.Trim Then
                    If (duplicate("tblItem", "ITName", txtItname)) = True Then
                        MsgBox("Record already exists")
                        txtItname.Focus()
                        GoTo en
                    End If
                End If
                printbarcode()
                If txtItname.Text <> txtcopyItname.Text Then
                    updateitem()
                End If
                connect()
                Dim CMD As New SqlCommand
                CMD = New SqlCommand("UPDATE TBLSTOCK SET ITNAME='" & txtItname.Text & "' WHERE ITNAME='" & txtcopyItname.Text & "'", cn)
                CMD.ExecuteNonQuery()
                CMD = New SqlCommand("UPDATE TBLSTOCK SET ITTYPE='" & txttype.Text & "' WHERE ITNAME='" & txtItname.Text & "'", cn)
                CMD.ExecuteNonQuery()
                CMD = New SqlCommand("UPDATE TBLPURCHASEDETAIL SET ITNAME='" & txtItname.Text & "' WHERE ITNAME='" & txtcopyItname.Text & "'", cn)
                CMD.ExecuteNonQuery()
                CMD = New SqlCommand("UPDATE SALE1 SET ITNAME='" & txtItname.Text & "' WHERE ITNAME='" & txtcopyItname.Text & "'", cn)
                CMD.ExecuteNonQuery()
                CMD = New SqlCommand("UPDATE SALEC1 SET ITNAME='" & txtItname.Text & "' WHERE ITNAME='" & txtcopyItname.Text & "'", cn)
                CMD.ExecuteNonQuery()
                close1()
                myupdate("tblItem", a, "ITCode", txtItcode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = dg1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(dg1, "tblItem")
                Label17.Visible = True
                Timer1.Enabled = True
                dg1.Item(coli, rowi).Selected = True
                txtItcode.Focus()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
    End Sub
    Private Sub updateitem()
        Try
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("update salec1 set itname='" & txtItname.Text & "' where itname='" & txtcopyItname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblitopen set item='" & txtItname.Text & "' where item='" & txtcopyItname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblPurchaseDetail set itname='" & txtItname.Text & "' where itname='" & txtcopyItname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("update tblStock set itname='" & txtItname.Text & "' where itname='" & txtcopyItname.Text & "'", cn)
            cmd.ExecuteNonQuery()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        'DG1.Width = 300
        DG1.SendToBack()
        frmItemSearch.Close()
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        Dim dr As SqlDataReader
        '    MsgBox(i.Item(0).RowIndex)
        txtItcode.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        txtcopyItname.Text = txtItcode.Text
        dr = myconselect("tblItem", txtItcode.Text, "ITCode")
        While dr.Read
            txtItname.Text = dr.Item(1)
            txtcopyItname.Text = dr.Item(1)
            txttype.Text = dr.Item(2)
            txtUnit.Text = dr.Item(3)
            txtRate.Text = dr.Item(4)
        End While
        dr.Close()
        GroupBox1.Enabled = True
        txtItname.Focus()
    End Sub


    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            Dim dr As SqlDataReader
            '    MsgBox(i.Item(0).RowIndex)
            txtItcode.Text = dg1.Item(0, i.Item(0).RowIndex).Value

            dr = myconselect("tblItem", txtItcode.Text, "ITCode")
            While dr.Read
                txtItname.Text = dr.Item(1)
                txtcopyItname.Text = dr.Item(1)
                txttype.Text = dr.Item(2)
                txtUnit.Text = dr.Item(3)
                txtRate.Text = dr.Item(4)
            End While
            dr.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        GroupBox2.Visible = False
        GroupBox1.Enabled = True
        txtFind.Focus()
        TV1 = ""
        ' frmItemSearch.Show()
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub


    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttype.KeyDown
        If e.KeyCode = Keys.Enter Then
            If listType.Items.Count <> 0 Then
                sender.Text = listType.Items(0).ToString
                txtUnit.Focus()
                listType.Visible = False
            Else
                If MsgBox("Item Type not exits you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ittypecheck = 1
                    frmItemTypeMaster.Show()
                    Me.Hide()
                Else
                    txttype.Focus()

                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            listType.SelectedIndex = 0
            listType.Focus()
            tb = 3
        ElseIf e.KeyCode = Keys.Up Then
            txtItname.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttype.KeyUp
        myAutoComplete(txttype, listType, "tblITType", "TPName")
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            If listType.Items.Count <> 0 Then
                sender.Text = listType.Items(0).ToString
                txtRate.Focus()
                listType.Visible = False
            Else
                If MsgBox("Unit does not exits you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    unitcheck = 1
                    frmUnitMaster.Show()
                    Me.Hide()
                Else
                    txtUnit.Focus()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            listType.Focus()
            listType.SelectedIndex = 0
            tb = 4
        ElseIf e.KeyCode = Keys.Up Then
            txttype.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnit.KeyUp
        myAutoComplete(txtUnit, listType, "tblUnit", "Unit")
    End Sub
    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles listType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb = 3 Then
                txttype.Text = listType.SelectedItem.ToString
                listType.Visible = False
                '  MsgBox("HET")
                txtUnit.Focus()
            ElseIf tb = 4 Then
                txtUnit.Text = listType.SelectedItem.ToString
                listType.Visible = False
                txtRate.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox5_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.Enter
        Me.KeyPreview = True
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItname.KeyDown
        If e.KeyCode = Keys.Enter Then
            txttype.Focus()
            ' TextBox5.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtItcode.Focus()
        End If
    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtUnit.Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub TextBox5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.Leave
        If Val(txtRate.Text) > 999999999999 Then
            MsgBox("Can not save this Rate it is to big to store.")
            txtRate.Focus()
            GoTo en
        End If
        numericform(txtRate)
en:
    End Sub

    Private Sub DG1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F10 Then
            dg1.Width = 1000
            dg1.BringToFront()
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub dg1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPrint.Click
        FRMPRINTITEMForm2.Show()
    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            butOk.Focus()
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (txtFind.Text = tv1) Then
        Else
            TEMP1 = 0
            TEMP2 = 0
        End If
        tv1 = txtFind.Text
        For i = TEMP1 To dg1.Rows.Count - 2
            For j = TEMP2 To dg1.ColumnCount - 1
                If (dg1.Item(j, i).Value.ToString.Contains(txtFind.Text)) Then
                    dg1.Item(j, i).Selected = True
                    TEMP2 = j + 1
                    '    check = 1
                    GoTo en
                End If
            Next
            TEMP1 = i + 1
            TEMP2 = 0
        Next
en:
    End Sub

    Private Sub GroupBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.Leave
        GroupBox2.Visible = False
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        GroupBox2.Visible = False
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            CMD = New SqlCommand("SELECT * FROM TBLSTOCK WHERE ITNAME='" & txtItname.Text & "'", cn)
            DR = CMD.ExecuteReader
            If DR.HasRows Then
                MsgBox("THERE ARE ENTRIES AVAILABLE IN TRANSTCTION DELETE THAT ENTRY FIRST")
                DR.Close()
                GoTo EN
            Else
                DR.Close()
            End If
            If MsgBox("You want to delete this item", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                CMD = New SqlCommand("DELETE FROM TBLITEM WHERE ITNAME='" & txtItname.Text & "'", cn)
                CMD.ExecuteNonQuery()
            End If
            myfilldatagrid(dg1, "TBLITEM")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
EN:
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItname.TextChanged

    End Sub
End Class