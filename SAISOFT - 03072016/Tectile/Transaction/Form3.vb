Imports System.Data.SqlClient
Public Class Form3
    Dim i As Integer = 0
    Dim tbcheck As Integer
    Dim editcheck As Integer = 0
    Public newac As Integer
    Public newit As Integer
    Dim tr As SqlTransaction
    Dim timercount As Integer
    Dim VATCHECK As String
    Dim selectfield As String
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1main.CellEnter
        Try
            i = 1
            If i <> 0 Then
                If e.ColumnIndex = 0 Then
                    one(txtSrNo)
                ElseIf e.ColumnIndex = 1 Then
                    one(txtITName)
                ElseIf e.ColumnIndex = 2 Then
                    one(txtItcode)
                ElseIf e.ColumnIndex = 3 Then
                    one(txtPcs)
                ElseIf e.ColumnIndex = 4 Then
                    one(txtPack)
                ElseIf e.ColumnIndex = 5 Then
                    one(txtQty)
                ElseIf e.ColumnIndex = 6 Then
                    one(txtRate)
                ElseIf e.ColumnIndex = 7 Then
                    one(txtUnit)
                ElseIf e.ColumnIndex = 8 Then
                    one(txtAmount)

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub one(ByRef tb As TextBox)
        Try
            Dim re As New Rectangle
            re = dg1main.GetCellDisplayRectangle(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex, True)
            tb.Top = re.Top + 192
            tb.Left = re.Left + 425
            tb.BringToFront()
            txtSrNo.Text = dg1main.Item(0, dg1main.CurrentCell.RowIndex).Value
            txtITName.Text = dg1main.Item(1, dg1main.CurrentCell.RowIndex).Value
            txtItcode.Text = dg1main.Item(2, dg1main.CurrentCell.RowIndex).Value
            txtPcs.Text = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value
            txtPack.Text = dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
            txtQty.Text = dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value
            txtRate.Text = dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value
            txtUnit.Text = dg1main.Item(7, dg1main.CurrentCell.RowIndex).Value
            txtAmount.Text = dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub enableall()
        Try

            dg1main.Enabled = True
            dgItem.Enabled = True
            dgAcm.Enabled = True
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
            txtRegcode.Enabled = True
            txtAcDr.Enabled = True
            txtAccodedr.Enabled = True
            txtAcCr.Enabled = True
            txtAccodecr.Enabled = True
            txtChNo.Enabled = True
            txtBillNosec.Enabled = True
            txtGramt.Enabled = True
            txtBillNofirst.Enabled = True
            txtVrNosec.Enabled = True
            txtVrNofirst.Enabled = True
            txtRemark.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub deasableall()
        Try

            dg1main.Enabled = False
            dgItem.Enabled = False
            dgAcm.Enabled = False
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
            txtRegcode.Enabled = False
            txtAcDr.Enabled = False
            txtAccodedr.Enabled = False
            txtAcCr.Enabled = False
            txtAccodecr.Enabled = False
            txtChNo.Enabled = False
            txtBillNosec.Enabled = False
            txtGramt.Enabled = False
            txtBillNofirst.Enabled = False
            txtVrNosec.Enabled = False
            txtVrNofirst.Enabled = False
            txtRemark.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Form3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
           
            dg1.Visible = True
            dg1.Focus()
            dg1.BringToFront()
        End If
    End Sub
    Private Sub enableall(ByVal b As Boolean)
        dgItem.Enabled = b
        dg1main.Enabled = b
        txtSrNo.Enabled = b
        txtITName.Enabled = b
        txtItcode.Enabled = b
        txtPcs.Enabled = b
        txtPack.Enabled = b
        txtQty.Enabled = b
        txtRate.Enabled = b
        txtUnit.Enabled = b
        txtAmount.Enabled = b
        txtRegister.Enabled = b
        txtRegcode.Enabled = b
        txtAcDr.Enabled = b
        txtAccodedr.Enabled = b
        txtAcCr.Enabled = b
        txtAccodecr.Enabled = b
        txtChNo.Enabled = b
        txtBillNosec.Enabled = b
        '  TextBox18.Enabled = b
        txtBillNofirst.Enabled = b
        txtVrNosec.Enabled = b
        txtVrNofirst.Enabled = b
        txtRemark.Enabled = b
        txtNetAmt.Enabled = b
        TextBox24.Enabled = b
        mydg1cal.Enabled = b
        comPurtype.Enabled = b
        comInvoiceType.Enabled = b
        maskChdate.Enabled = b
        maskBilldate.Enabled = b
        butRemove.Enabled = b
        dgAcm.Enabled = b
    End Sub
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            connect()
            Dim CMD1 As New SqlCommand
            Dim DR1 As SqlDataReader
            CMD1 = New SqlCommand("sELECT VALUE FROM TBLSETUP WHERE BOOK='PURCHASE' AND OPERATION='VATROUND'", cn)
            DR1 = CMD1.ExecuteReader
            While DR1.Read
                VATCHECK = DR1.Item(0)
            End While
            DR1.Close()
            CMD1 = New SqlCommand("select fields from tblselectfield where tablename='tblPurchase'", cn)
            DR1 = CMD1.ExecuteReader
            While DR1.Read
                selectfield = DR1.Item(0).ToString.Substring(0, DR1.Item(0).ToString.Length - 1)
            End While
            DR1.Close()
            close1()
            companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
            dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
            butSave.Enabled = False
            '      butDelete.Enabled = False
            enableall(False)
            Dim datmy As New Date
            datmy = "12-03-2011"
            Try
                '*********************************new editing***********************'
                connect()
                Dim cmdtax As New SqlCommand
                Dim drtax As SqlDataReader
                cmdtax = New SqlCommand("select distinct tax from Taxmst where bktype='Purchase'", cn)
                drtax = cmdtax.ExecuteReader
                While drtax.Read
                    comInvoiceType.Items.Add(drtax.Item(0))
                End While
                drtax.Close()
                close1()

                '*********************************new editing ends***********************'
                deasableall()
                myfillCustome(txtUnit, "tblUnit", "Unit")
                txtBillNofirst.ReadOnly = True
                txtBillNofirst.Text = acycode & "/"
                txtVrNofirst.Text = acycode & "/"
                If frmzoom7.zoom = True Then
                    Dim cmd As New SqlCommand
                    Dim drsale As SqlDataReader
                    connect()
                    cmd = New SqlCommand("Select " & selectfield & " from tblPurchase where VrNo='" & frmzoom7.VrNo & "'", cn)
                    drsale = cmd.ExecuteReader
                    While drsale.Read
                        txtRegister.Text = drsale.Item("BkName")
                    End While
                    drsale.Close()
                    close1()
                ElseIf frmnewzoom4.zoom1 = True Then
                    Dim cmd As New SqlCommand
                    Dim drsale As SqlDataReader
                    connect()
                    cmd = New SqlCommand("Select " & selectfield & " from tblPurchase where VrNo='" & frmnewzoom4.VrNo & "'", cn)
                    drsale = cmd.ExecuteReader
                    While drsale.Read
                        txtRegister.Text = drsale.Item("BkName")
                    End While
                    drsale.Close()
                    close1()
                Else
                    txtRegister.Text = (frmMainScreen.bkname)
                End If
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", txtRegister.Text, "ACName")
                While dr.Read
                    txtRegcode.Text = dr.Item("ACCode")
                End While
                dr.Close()
                Dim dat1 As DateTime
                Dim dat2 As DateTime
                dat1 = dateyf.ToString
                'myfilldatagrid(DataGridView3, "tblPurchase")
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                connect()
                da = New SqlDataAdapter("Select " & selectfield & " from tblPurchase Where BkName='" & txtRegister.Text & "' order By convert(int,BookVr)", cn)
                da.Fill(ds)

                dg1.DataSource = ds.Tables(0)
                Try
                    dg1.Item(0, dg1.Rows.Count - 1).Selected = True
                Catch ex As Exception

                End Try
                close1()
                dg1main.Rows.Add()
                txtRegister.Focus()
                i = 1
                txtSrNo.ReadOnly = True
                txtItcode.ReadOnly = True
                '      txtAmount.ReadOnly = False
                txtSrNo.Width = 50
                txtITName.Width = 200
                txtItcode.Width = 70
                txtPcs.Width = 70
                txtPack.Width = 70
                txtQty.Width = 70
                txtRate.Width = 70
                txtUnit.Width = 40
                txtAmount.Width = 100
                txtSrNo.Visible = True
                txtITName.Visible = True
                txtItcode.Visible = True
                txtPcs.Visible = True
                txtPack.Visible = True
                txtQty.Visible = True
                txtRate.Visible = True
                txtUnit.Visible = True
                txtAmount.Visible = True
                txtSrNo.SendToBack()
                txtITName.SendToBack()
                txtItcode.SendToBack()
                txtPcs.SendToBack()
                txtPack.SendToBack()
                txtQty.SendToBack()
                txtRate.SendToBack()
                txtUnit.SendToBack()
                txtAmount.SendToBack()
                If frmzoom7.zoom = True Then
                    Dim cn As Integer
                    For cn = 0 To dg1.Rows.Count - 1
                        If dg1.Item(0, cn).Value = frmzoom7.VrNo Then
                            dg1.Item(0, cn).Selected = True
                            GoTo en
                        End If
                    Next
                End If


                dg1main.Columns(3).DefaultCellStyle.Format = "f0"
                dg1main.Columns(4).DefaultCellStyle.Format = "f3"
                dg1main.Columns(5).DefaultCellStyle.Format = "f2"
                dg1main.Columns(6).DefaultCellStyle.Format = "f2"
                dg1main.Columns(8).DefaultCellStyle.Format = "f2"
en:
                If frmnewzoom4.zoom1 = True Then
                    Dim cn As Integer
                    For cn = 0 To dg1.Rows.Count - 1
                        If dg1.Item(0, cn).Value = frmnewzoom4.VrNo Then
                            dg1.Item(0, cn).Selected = True
                            GoTo en1
                        End If
                    Next
                End If
en1:
                dg1main.Columns(3).DefaultCellStyle.Format = "f0"
                dg1main.Columns(4).DefaultCellStyle.Format = "f3"
                dg1main.Columns(5).DefaultCellStyle.Format = "f2"
                dg1main.Columns(6).DefaultCellStyle.Format = "f2"
                dg1main.Columns(8).DefaultCellStyle.Format = "f2"
                dg1.BringToFront()

            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try

    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrNo.GotFocus, txtItcode.GotFocus, txtPcs.GotFocus, txtPack.GotFocus, txtQty.GotFocus, txtRate.GotFocus, txtUnit.GotFocus, txtAmount.GotFocus
        Try

            txtSrNo.SendToBack()
            txtITName.SendToBack()
            txtItcode.SendToBack()
            txtPcs.SendToBack()
            txtPack.SendToBack()
            txtQty.SendToBack()
            txtRate.SendToBack()
            txtUnit.SendToBack()
            txtAmount.SendToBack()
            sender.BringtoFront()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSrNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dg1main.CurrentCell.Value = txtSrNo.Text
                dg1main.Item(1, dg1main.CurrentCell.RowIndex).Selected = True
            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtSrNo.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtSrNo.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True
            ElseIf e.KeyCode = Keys.Tab Then
                'Button9.Focus()
                Try
                    '   If editcheck = 0 Then
                    'gridsetup()
                    'cal()
                    'ElseIf editcheck = 1 Then
                    'cal()
                    'End If
                    connect()
                    Dim STRCHECK As String
                    Dim CMD1 As New SqlCommand
                    CMD1 = New SqlCommand("sELECT * FROM TBLSETUP WHERE BOOK='PURCHASE' AND OPERATION='GRAMTCHANGE'", cn)
                    Dim DR1 As SqlDataReader
                    DR1 = CMD1.ExecuteReader
                    While DR1.Read
                        STRCHECK = DR1.Item("vALUE")
                    End While
                    DR1.Close()
                    If STRCHECK = "FALSE" Then
                        txtGramt.Enabled = False
                    Else
                        txtGramt.Enabled = True
                    End If
                    CMD1 = New SqlCommand("sELECT * FROM TBLSETUP WHERE BOOK='PURCHASE' AND OPERATION='GRAMTROUND'", cn)
                    DR1 = CMD1.ExecuteReader
                    While DR1.Read
                        STRCHECK = DR1.Item("VALUE")
                    End While
                    DR1.Close()
                    close1()
                    If STRCHECK = "FALSE" Then
                        txtGramt.Text = Convert.ToDecimal(TotalAmount)
                    Else
                        txtGramt.Text = Convert.ToDecimal(Math.Round(TotalAmount))

                    End If


                    If Val(txtGramt.Text) = Val(TextBox24.Text) And txtGramt.Text.Trim.Length <> 0 And Val(txtGramt.Text) <> 0 Then
                        If MsgBox("You want to change tax", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            gridsetup()
                            cal()
                        End If
                    Else
                        gridsetup()
                        cal()
                    End If
                    netcal()
                    txtGramt.Focus()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtITName.GotFocus
        Try
            sender.BringToFront()
            '   DataGridView2.Left = TextBox2.Left
            dgItem.Top = txtITName.Top + 22

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            ' cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\" & frmcomdis.companycode & "NEWdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            'cn.Open()
            connect()

            da = New SqlDataAdapter("Select itcode,itname,ittype,itunit,rate from tblItem where ITName like '" & txtITName.Text & "%'", cn)
            da.Fill(ds)
            dgItem.DataSource = ds.Tables(0)
            '  dgItem.AutoResizeColumns()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPcs.KeyDown
        Try

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dg1main.CurrentCell.Value = txtPcs.Text
                dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                '   dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value), "0.00")
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(4, dg1main.CurrentCell.RowIndex).Selected = True
                txtPcs.SendToBack()
                dg1main.Focus()
                numericform(txtPcs)
                txtPack.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtPcs.Text
                dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True
            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtPcs.Text
                dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtPcs.SelectionStart = txtPcs.Text.Length Or txtPcs.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtPcs.Text
                    dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(4, dg1main.CurrentCell.RowIndex).Selected = True
                    txtPcs.SendToBack()
                    dg1main.Focus()
                    txtPack.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtPcs.SelectionStart = 0 Or txtPcs.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtPcs.Text
                    dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(1, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Focus()
                    txtITName.Focus()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPack.KeyDown
        Try

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dg1main.CurrentCell.Value = txtPack.Text
                dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(5, dg1main.CurrentCell.RowIndex).Selected = True
                txtPcs.SendToBack()
                dg1main.Focus()
                txtQty.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtPcs.Text
                dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                '   dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value), "0.00")
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True
            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtPcs.Text
                dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtPack.SelectionStart = txtPack.Text.Length Or txtPack.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtPack.Text
                    dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(5, dg1main.CurrentCell.RowIndex).Selected = True
                    txtPcs.SendToBack()
                    dg1main.Focus()
                    txtQty.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                ' MsgBox(TextBox5.SelectionStart)
                If txtPack.SelectionStart = 0 Or txtPack.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtPack.Text
                    dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value = dg1main.Item(3, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(4, dg1main.CurrentCell.RowIndex).Value
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(3, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Focus()
                    txtPcs.Focus()
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        Try

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dg1main.CurrentCell.Value = txtQty.Text
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(6, dg1main.CurrentCell.RowIndex).Selected = True
                dg1main.Focus()
                txtRate.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtQty.Text
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtQty.Text
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtQty.SelectionStart = txtQty.Text.Length Or txtQty.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtQty.Text
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(6, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Focus()
                    txtRate.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Or txtQty.Text.Length = 0 Then
                If txtQty.SelectionStart = 0 Then
                    dg1main.CurrentCell.Value = txtQty.Text
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(4, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Focus()
                    txtPack.Focus()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                dg1main.CurrentCell.Value = txtRate.Text
                dg1main.Item(7, dg1main.CurrentCell.RowIndex).Selected = True
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Focus()
                txtUnit.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtRate.Text
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtRate.Text
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Or txtRate.Text.Length = 0 Then
                If txtRate.SelectionStart = txtRate.Text.Length Then
                    dg1main.CurrentCell.Value = txtRate.Text
                    dg1main.Item(7, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Focus()
                    txtUnit.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtRate.SelectionStart = 0 Or txtRate.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtRate.Text
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = Format(Val(Math.Round(dg1main.Item(5, dg1main.CurrentCell.RowIndex).Value * dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value, 0, MidpointRounding.AwayFromZero)), "0.00")
                    dg1main.Item(5, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Focus()
                    txtQty.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUnit.KeyDown
        Try
            txtAmount.TabStop = False
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                '*********************in comment is old*************
                'DataGridView1.CurrentCell.Value = TextBox8.Text
                'DataGridView1.Item(8, DataGridView1.CurrentCell.RowIndex).Selected = True
                'DataGridView1.Focus()
                If dg1main.Rows.Count < dg1main.Item(0, dg1main.SelectedCells.Item(0).RowIndex).Value + 1 Then
                    dg1main.Rows.Add()
                End If
                txtAmount.Text = Format(Val(txtAmount.Text), "0.00")
                dg1main.Item(7, dg1main.CurrentCell.RowIndex).Value = txtUnit.Text
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = txtAmount.Text
                dg1main.Item(1, dg1main.CurrentCell.RowIndex + 1).Selected = True
                txtSrNo.Text = 1 + dg1main.Item(0, dg1main.CurrentCell.RowIndex - 1).Value
                dg1main.Item(0, dg1main.CurrentCell.RowIndex).Value = txtSrNo.Text
                txtSrNo.Focus()
                dg1main.Item(0, dg1main.CurrentCell.RowIndex).Selected = True

                ' TextBox2.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtUnit.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtUnit.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtUnit.SelectionStart = txtUnit.Text.Length Or txtUnit.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtUnit.Text
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Focus()
                    txtAmount.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtUnit.SelectionStart = 0 Or txtUnit.Text.Length = 0 Then
                    dg1main.CurrentCell.Value = txtUnit.Text
                    dg1main.Item(6, dg1main.CurrentCell.RowIndex).Selected = True
                    dg1main.Focus()
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
                Else
                    If txtPcs.Text.Contains(".") Then
                        e.Handled = True
                    End If
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrNo.LocationChanged, txtITName.LocationChanged, txtItcode.LocationChanged, txtPcs.LocationChanged, txtPack.LocationChanged, txtQty.LocationChanged, txtRate.LocationChanged, txtUnit.LocationChanged, txtAmount.LocationChanged
        Try

            txtSrNo.Top = sender.top
            txtITName.Top = sender.top
            txtItcode.Top = sender.top
            txtPcs.Top = sender.top
            txtPack.Top = sender.top
            txtQty.Top = sender.top
            txtRate.Top = sender.top
            txtUnit.Top = sender.top
            txtAmount.Top = sender.top
            '  DataGridView2.Left = TextBox2.Left
            dgItem.Top = sender.Top + 22
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtITName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                Try
                    If txtITName.Text = "0000" Then
                        butSave.Focus()
                        GoTo en
                    End If
                    'DataGridView1.Rows.Add()
                    txtITName.Text = dgItem.Item(1, 0).Value
                    If txtITName.Text.Length = 0 Then
                        If MsgBox("You want to insert a new Item", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            newit = 1
                            frmITMaster.Show()
                            Me.Hide()
                        Else
                            GoTo en
                        End If
                    End If
                    dg1main.Item(1, dg1main.CurrentCell.RowIndex).Value = txtITName.Text
                    Dim dr As SqlDataReader
                    dr = myconselect("tblItem", txtITName.Text, "ITName")
                    While dr.Read
                        txtItcode.Text = dr.Item("ITCode")
                        dg1main.Item(2, dg1main.CurrentCell.RowIndex).Value = txtItcode.Text
                        If Label10.Text = "EDIT MODE" Then
                        Else
                            txtRate.Text = dr.Item("Rate")
                            dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value = txtRate.Text
                            txtUnit.Text = dr.Item("ITUnit")
                            dg1main.Item(7, dg1main.CurrentCell.RowIndex).Value = txtUnit.Text
                        End If
                     
                    End While

                    dr.Close()
                Catch ex As Exception
                    If MsgBox("You want to insert a new Item", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        newit = 1
                        frmITMaster.Show()
                        Me.Hide()
                    Else
                        GoTo en
                    End If
                End Try
                dg1main.Item(3, dg1main.CurrentCell.RowIndex).Selected = True
                dg1main.Focus()
                dgItem.Visible = False
                txtPcs.Focus()



            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtITName.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                dgItem.Focus()
                dg1main.Enabled = False
                dgItem.Item(0, 0).Selected = True
                dgItem.Visible = True
                dgItem.Focus()
            ElseIf e.KeyCode = Keys.Left Then
                txtSrNo.Focus()
                dg1main.Item(0, dg1main.SelectedCells.Item(0).RowIndex).Selected = True
            End If
en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

                dg1main.CurrentCell.Value = txtItcode.Text
                dg1main.Item(3, dg1main.CurrentCell.RowIndex).Selected = True
                txtPcs.Focus()
                dg1main.Focus()

            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtSrNo.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtSrNo.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dg1main.Rows.Add()
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtITName.KeyUp
        Try

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            dgItem.Visible = True
            '  cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\" & frmcomdis.companycode & "NEWdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            '  cn.Open()
            connect()
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
                dg1main.Enabled = True
                txtITName.Text = dgItem.Item(1, dgItem.SelectedCells(0).RowIndex).Value
                dg1main.CurrentCell.Value = txtITName.Text
                Dim dr As SqlDataReader
                dr = myconselect("tblItem", txtITName.Text, "ITName")
                While dr.Read
                    txtItcode.Text = dr.Item("ITCode")
                    dg1main.Item(2, dg1main.CurrentCell.RowIndex).Value = txtItcode.Text

                    txtRate.Text = dr.Item("Rate")
                    dg1main.Item(6, dg1main.CurrentCell.RowIndex).Value = txtRate.Text
                    txtUnit.Text = dr.Item("ITUnit")
                    dg1main.Item(7, dg1main.CurrentCell.RowIndex).Value = txtUnit.Text
                End While
                dr.Close()
                dg1main.Item(3, dg1main.CurrentCell.RowIndex).Selected = True
                dg1main.Focus()
                dgItem.Visible = False
                txtPcs.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If dg1main.Rows.Count < dg1main.Item(0, dg1main.SelectedCells.Item(0).RowIndex).Value + 1 Then
                    dg1main.Rows.Add()
                End If
                dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = txtAmount.Text
                dg1main.Item(1, dg1main.CurrentCell.RowIndex + 1).Selected = True
                txtSrNo.Text = 1 + dg1main.Item(0, dg1main.CurrentCell.RowIndex - 1).Value
                dg1main.Item(0, dg1main.CurrentCell.RowIndex).Value = txtSrNo.Text
                txtITName.Focus()
                dg1main.Item(1, dg1main.CurrentCell.RowIndex).Selected = True
            ElseIf e.KeyCode = Keys.Down Then
                dg1main.CurrentCell.Value = txtAmount.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex + 1).Selected = True

            ElseIf e.KeyCode = Keys.Up Then
                dg1main.CurrentCell.Value = txtAmount.Text
                dg1main.Item(dg1main.CurrentCell.ColumnIndex, dg1main.CurrentCell.RowIndex - 1).Selected = True
            ElseIf e.KeyCode = Keys.Right Then
                If txtAmount.SelectionStart = txtAmount.Text.Length Then
                    dg1main.Rows.Add()
                    dg1main.Item(8, dg1main.CurrentCell.RowIndex).Value = txtAmount.Text
                    dg1main.Item(1, dg1main.CurrentCell.RowIndex + 1).Selected = True
                    txtSrNo.Text = 1 + dg1main.Item(0, dg1main.CurrentCell.RowIndex - 1).Value
                    dg1main.Item(0, dg1main.CurrentCell.RowIndex).Value = txtSrNo.Text
                    txtITName.Focus()
                    dg1main.Item(1, dg1main.CurrentCell.RowIndex).Selected = True
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If txtAmount.SelectionStart = 0 Then
                    dg1main.CurrentCell.Value = txtSrNo.Text
                    dg1main.Item(dg1main.CurrentCell.ColumnIndex - 1, dg1main.CurrentCell.RowIndex).Selected = True
                    txtUnit.Focus()
                End If
                'ElseIf e.KeyCode = Keys.Tab Then
                '     e.Handled = True
                '    Button9.Focus()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
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
    Private Function rowcount() As Integer
        Dim i, j As Integer
        Try
            For i = 0 To dg1main.Rows.Count - 1
                If dg1main.Item(0, i).Value = "" Then
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
        Try

            Dim i As Integer
            Dim max As Integer
            Try

                For i = 0 To dg1main.Rows.Count - 1
                    If dg1main.Item(1, i).Value.ToString = "" Then

                    End If

                    '            If max < DataGridView1.Item(0, i).Value Then
                    'max = DataGridView1.Item(0, i).Value
                    'End If
                    max = i + 1
                Next
            Catch ex As Exception
                max = i
            End Try

            Dim amount As Integer
            For i = 0 To max - 1
                amount = amount + dg1main.Item(3, i).Value
            Next
            Return amount
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Private Function TotalAmount() As Decimal
        Try
            Dim i As Integer
            Dim max As Integer = 0.0
            Try
                For i = 0 To dg1main.Rows.Count - 1
                    If dg1main.Item(1, i).Value.ToString = "" Then
                    End If
                    max = i + 1
                Next
            Catch ex As Exception
                max = i
            End Try
            '  If max < DataGridView1.Item(0, i).Value Then
            'max = DataGridView1.Item(0, i).Value
            'End If

            Dim amount As Decimal = 0.0
            For i = 0 To max - 1
                amount = amount + dg1main.Item(8, i).Value
            Next
            Return amount

        Catch ex As Exception

        End Try

    End Function
    Private Function totalqty() As Decimal
        Try

            Dim i As Integer
            Dim max As Integer = 0.0
            Try
                For i = 0 To dg1main.Rows.Count - 1
                    If dg1main.Item(1, i).Value.ToString = "" Then
                    End If
                    max = i + 1
                Next
            Catch ex As Exception
                max = i
            End Try
            '  If max < DataGridView1.Item(0, i).Value Then
            'max = DataGridView1.Item(0, i).Value
            'End If

            Dim amount As Decimal = 0.0
            For i = 0 To max - 1
                amount = amount + dg1main.Item(5, i).Value
            Next
            Return amount

        Catch ex As Exception

        End Try
    End Function
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
    Private Sub posting()
        Try
            Dim amt As Decimal = 0.0
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat2 = maskChdate.Text.ToString
            dat1 = maskBilldate.Text.ToString
            connect()
            Dim i As Integer
            Dim k As Integer = 0
            Dim tb As New TextBox
            maxVrNo(txtJvVrno, "tblJour")
            For i = 0 To mydg1cal.Rows.Count - 1

                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select * from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn, tr)
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
                    Dim b() As String = {acycode & "/" & txtJvVrno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, k + 1, "DR", poaccount, poaccode, mydg1cal.Item(10, i).Value, 0.0, txtBillNofirst.Text & txtBillNosec.Text, "JVPU"}
                    myinsert(b, "tblJour")
                    Dim a() As String = {acycode & "/" & txtJvVrno.Text, "JVPU", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, poaccode, poaccount, mydg1cal.Item(10, i).Value, 0.0, -(mydg1cal.Item(10, i).Value), txtRemark.Text, txtVrNofirst.Text & txtVrNosec.Text, txtAcCr.Text, txtAccodecr.Text}
                    myinsert(a, "tblLedg")
                    k = k + 1
                End If
                close1()
            Next
            If amt <> 0 Then
                Dim v() As String = {acycode & "/" & txtJvVrno.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, k + 1, "CR", txtAcCr.Text, txtAccodecr.Text, 0.0, amt, txtBillNofirst.Text & txtBillNosec.Text, "JVPU"}
                myinsert(v, "tblJour")
            Else
                txtJvVrno.Text = 0
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub taxinsert()
        Try
            Dim i As Integer
            Dim dat1 As New Date
            dat1 = maskBilldate.Text.ToString
            For i = 0 To mydg1cal.Rows.Count - 1
                Dim a() As String = {txtVrNofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegcode.Text, txtBillNofirst.Text & txtBillNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, mydg1cal.Item(0, i).Value, mydg1cal.Item(1, i).Value, mydg1cal.Item(2, i).Value, mydg1cal.Item(3, i).Value, mydg1cal.Item(4, i).Value, mydg1cal.Item(5, i).Value, mydg1cal.Item(6, i).Value, mydg1cal.Item(7, i).Value, mydg1cal.Item(8, i).Value, mydg1cal.Item(9, i).Value, mydg1cal.Item(10, i).Value, mydg1cal.Item(11, i).Value, mydg1cal.Item(12, i).Value, mydg1cal.Item(13, i).Value, mydg1cal.Item(14, i).Value}
                myinsert(a, "tblPurtax")
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function checkconstrain() As Boolean
        If txtAcDr.Text.Trim.Length = 0 Then
            MsgBox("AC Dr can not be blank")
            txtAcDr.Focus()
            Return False
        ElseIf txtAccodedr.Text = 0 Then
            MsgBox("check ac dr ")
            txtAcDr.Focus()
        ElseIf txtAcCr.Text.Trim.Length = 0 Then
            MsgBox("AC Cr can not be blank")
            txtAcCr.Focus()
            Return False
        ElseIf txtAccodecr.Text = 0 Then
            MsgBox("check ac cr ")
            txtAcCr.Focus()
            Return False
        ElseIf comPurtype.Items.Contains(comPurtype.Text) = False Then
            MsgBox("select purchase type from list")
            comPurtype.Focus()
            Return False
        ElseIf comInvoiceType.Items.Contains(comInvoiceType.Text) = False Then
            MsgBox("select invoice type from list")
            comInvoiceType.Focus()
            Return False
        ElseIf txtBillNosec.Text.Trim.Length = 0 Then
            MsgBox("Enter bill no")
            comInvoiceType.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            Try
                If checkconstrain() Then
                Else
                    GoTo last
                End If
                If dg1main.Item(8, 0).Value > 0 Then
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
            Dim timepass As Integer
            ' MsgBox(totalqty)
            If editcheck = 0 Then
                connect()
                Dim cmdcheck As SqlCommand
                Dim drcheck As SqlDataReader
                cmdcheck = New SqlCommand("Select * from tblPurchase where vrno='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows = True Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo last
                Else
                    drcheck.Close()
                End If
                close1()
                Dim i As Integer
                Dim max As Integer = 0
                Try
                    For i = 0 To dg1main.Rows.Count - 1
                        If dg1main.Item(1, i).Value.ToString = "" Then
                        End If
                        max = i + 1
                    Next

                Catch ex As Exception
                    max = i
                End Try
                Dim dat1 As New Date
                Dim dat2 As New Date
                dat1 = maskChdate.Text.ToString
                dat2 = maskBilldate.Text.ToString
                Dim r As Integer
                connect()
                Dim cmdit As New SqlCommand
                Dim drit As SqlDataReader
                For i = 0 To max - 1
                    If dg1main.Item(8, i).Value <> 0.0 Then
                        Dim a() As String = {txtRegister.Text, txtRegcode.Text, txtChNo.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comPurtype.Text, dg1main.Item(0, i).Value, dg1main.Item(1, i).Value, dg1main.Item(2, i).Value, dg1main.Item(3, i).Value, dg1main.Item(4, i).Value, dg1main.Item(5, i).Value, dg1main.Item(6, i).Value, dg1main.Item(7, i).Value, dg1main.Item(8, i).Value, txtVrNofirst.Text & txtVrNosec.Text, txtAccodedr.Text, txtAccodecr.Text}
                        myinsert(a, "tblPurchaseDetail")
                    End If
                    connect()
                    cmdit = New SqlCommand("Select ittype from tblItem where itcode=" & dg1main.Item(2, i).Value.ToString, cn)
                    drit = cmdit.ExecuteReader
                    Dim ittype As String
                    While drit.Read
                        ittype = drit.Item(0)
                    End While
                    drit.Close()
                    close1()
                    Dim b1() As String = {dat2.Month & "-" & dat2.Day & "-" & dat2.Year, "Purchase", txtVrNofirst.Text & txtVrNosec.Text, dg1main.Item(1, i).Value, ittype, dg1main.Item(5, i).Value, dg1main.Item(6, i).Value, dg1main.Item(8, i).Value, 0.0, 0.0, 0.0}
                    myinsert(b1, "tblStock")
                Next
                posting()
                '     Dim b() As String = {TextBox21.Text & TextBox20.Text, TextBox10.Text, TextBox11.Text, TextBox16.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, TextBox17.Text, TextBox19.Text & TextBox17.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, TextBox12.Text, TextBox14.Text, ComboBox1.Text, totalpcs(), totalqty(), TotalAmount(), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", acycode & "/" & TextBox27.Text, TextBox23.Text, AmtInWord(TextBox23.Text), TextBox22.Text, TextBox13.Text, TextBox15.Text, TextBox25.Text, Val(TextBox23.Text), "f"}
                '    myinsert(b, "tblPurchase")
                Dim b() As String = {txtVrNofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegcode.Text, txtChNo.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comPurtype.Text, totalpcs(), totalqty(), Val(txtGramt.Text), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", acycode & "/" & txtJvVrno.Text, txtNetAmt.Text, AmtInWord(txtNetAmt.Text), txtRemark.Text, txtAccodedr.Text, txtAccodecr.Text, txtBookvr.Text, Val(txtNetAmt.Text), "f"}
                myinsert(b, "tblPurchase")

                Dim c() As String = {txtVrNofirst.Text & txtVrNosec.Text, "Purchase", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodecr.Text, txtAcCr.Text, 0, txtNetAmt.Text, txtNetAmt.Text, txtRemark.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcDr.Text, txtAccodedr.Text}
                myinsert(c, "tblLedg")
                Dim d() As String = {txtVrNofirst.Text & txtVrNosec.Text, "Purchase", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodedr.Text, txtAcDr.Text, totalnetamt(), 0, ((totalnetamt()) * -1), txtRemark.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcCr.Text, txtAccodecr.Text}
                myinsert(d, "tblLedg")
                taxinsert()
                ' tr.Commit()
                ' Timer1.Stop()
                maxVrNo(txtVrNosec, "tblPurchase")
                '  MsgBox("Success")
                lblSave.Text = "SAVED"
            ElseIf editcheck = 1 Then
                Dim dat1 As New Date
                Dim dat2 As New Date
                dat1 = maskChdate.Text.ToString
                dat2 = maskBilldate.Text.ToString

                Dim i As Integer
                Dim max As Integer = 0
                Try
                    For i = 0 To dg1main.Rows.Count - 1
                        If dg1main.Item(1, i).Value.ToString = "" Then

                        End If

                        '    If max < DataGridView1.Item(0, i).Value Then
                        'max = DataGridView1.Item(0, i).Value
                        ' End If
                        max = i + 1
                    Next
                Catch ex As Exception
                    max = i
                End Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                MsgBox("Delete from tblLedg where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='Purchase'")
                Try
                    cn.Open()
                Catch ex As Exception

                End Try

                cmd = New SqlCommand("Delete from tblPurchaseDetail where NameCr='" & txtAcCr.Text & "' and OubNo='" & txtBillNofirst.Text & txtBillNosec.Text & "' AND VRNO='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='Purchase'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblStock where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='Purchase'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where VrNo='" & txtJvVrno.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblPurTax where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and BkName='" & txtRegister.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLedg where VrNo='" & txtJvVrno.Text & "' and book='JVPU'", cn)
                cmd.ExecuteNonQuery()
                taxinsert()
                posting()
                close1()
                ' Dim r As Integer
                ' r = rowcount()
                '   MsgBox(r)
                '  Dim i As Integer
                Dim cmdit As New SqlCommand
                Dim drit As SqlDataReader
                For i = 0 To max - 1
                    Dim a() As String = {txtRegister.Text, txtRegcode.Text, txtChNo.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comPurtype.Text, dg1main.Item(0, i).Value, dg1main.Item(1, i).Value, dg1main.Item(2, i).Value, dg1main.Item(3, i).Value, dg1main.Item(4, i).Value, dg1main.Item(5, i).Value, dg1main.Item(6, i).Value, dg1main.Item(7, i).Value, dg1main.Item(8, i).Value, txtVrNofirst.Text & txtVrNosec.Text, txtAccodedr.Text, txtAccodecr.Text}
                    myinsert(a, "tblPurchaseDetail")
                    connect()
                    cmdit = New SqlCommand("Select ittype from tblItem where itcode=" & dg1main.Item(2, i).Value.ToString, cn)
                    drit = cmdit.ExecuteReader
                    Dim ittype As String
                    While drit.Read
                        ittype = drit.Item(0)
                    End While
                    drit.Close()
                    close1()
                    Dim b1() As String = {dat2.Month & "-" & dat2.Day & "-" & dat2.Year, "Purchase", txtVrNofirst.Text & txtVrNosec.Text, dg1main.Item(1, i).Value, ittype, dg1main.Item(5, i).Value, dg1main.Item(6, i).Value, dg1main.Item(8, i).Value, 0.0, 0.0, 0.0}
                    myinsert(b1, "tblStock")
                    ' MsgBox("Successful")
                Next
                Dim c() As String = {txtVrNofirst.Text & txtVrNosec.Text, "Purchase", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodecr.Text, txtAcCr.Text, 0, txtNetAmt.Text, txtNetAmt.Text, txtRemark.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcDr.Text, txtAccodedr.Text}
                myinsert(c, "tblLedg")
                Dim d() As String = {txtVrNofirst.Text & txtVrNosec.Text, "Purchase", dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAccodedr.Text, txtAcDr.Text, totalnetamt(), 0, ((totalnetamt()) * -1), txtRemark.Text, txtBillNofirst.Text & txtBillNosec.Text, txtAcCr.Text, txtAccodecr.Text}
                myinsert(d, "tblLedg")
                Dim b() As String = {txtVrNofirst.Text & txtVrNosec.Text, txtRegister.Text, txtRegcode.Text, txtChNo.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBillNosec.Text, txtBillNofirst.Text & txtBillNosec.Text, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtAcDr.Text, txtAcCr.Text, comPurtype.Text, totalpcs(), totalqty(), TotalAmount(), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", acycode & "/" & txtJvVrno.Text, txtNetAmt.Text, AmtInWord(txtNetAmt.Text), txtRemark.Text, txtAccodedr.Text, txtAccodecr.Text, txtBookvr.Text, Val(txtNetAmt.Text), "f"}
                myupdate("tblPurchase", b, "VrNo", txtVrNofirst.Text & txtVrNosec.Text)
                '   MsgBox("Successful")
                lblSave.Text = "EDITED"
            End If
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter("Select " & selectfield & " from tblPurchase Where BkName='" & txtRegister.Text & "' order by convert(int,BookVr)", cn)
            da.Fill(ds)
            dg1.DataSource = ds.Tables(0)
            Try
                dg1.Item(0, dg1.Rows.Count - 1).Selected = True
            Catch ex As Exception

            End Try
            txtSrNo.SendToBack()
            txtITName.SendToBack()
            txtItcode.SendToBack()
            txtPcs.SendToBack()
            txtPack.SendToBack()
            txtQty.SendToBack()
            txtRate.SendToBack()
            txtUnit.SendToBack()
            txtAmount.SendToBack()
            enableall(False)
            butAdd.Enabled = True
            butEdit.Enabled = True
            butDelete.Enabled = False
            butAdd.Focus()
last:
        Catch ex As Exception

            MsgBox(ex.ToString())

        End Try
    End Sub

    Private Sub TextBox12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcCr.GotFocus, txtSrNo.GotFocus, txtRegister.GotFocus, txtAcDr.GotFocus, txtAccodedr.GotFocus, txtAcCr.GotFocus, txtAccodecr.GotFocus, txtChNo.GotFocus, txtBillNosec.GotFocus, txtGramt.GotFocus, txtBillNofirst.GotFocus, txtITName.GotFocus, txtVrNosec.GotFocus, txtVrNofirst.GotFocus, txtRemark.GotFocus, txtNetAmt.GotFocus, txtItcode.GotFocus, txtPcs.GotFocus, txtPack.GotFocus, txtQty.GotFocus, txtRate.GotFocus, txtUnit.GotFocus, txtAmount.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
            txtSrNo.SendToBack()
            txtITName.SendToBack()
            txtItcode.SendToBack()
            txtPcs.SendToBack()
            txtPack.SendToBack()
            txtQty.SendToBack()
            txtRate.SendToBack()
            txtUnit.SendToBack()
            txtAmount.SendToBack()
            'new edit
            '    txtSrNo.Visible = False
            '   txtITName.Visible = False
            '  txtItcode.Visible = False
            ' txtPcs.Visible = False
            'txtPack.Visible = False
            ' txtQty.Visible = False
            'txtRate.Visible = False
            ' txtUnit.Visible = False
            ' txtAmount.Visible = False
            sender.bringtofront()
            'sender.visible = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gotfocus12(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcDr.GotFocus
        Try

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter(acm(sender.text), cn)
            da.Fill(ds)
            dgAcm.Visible = True
            dgAcm.DataSource = ds.Tables(0)
            dgAcm.BringToFront()
            dgAcm.AutoResizeColumns()
            ' DataGridView4.Top = sender.Top + 22
            ' DataGridView4.Left = sender.Left
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox23_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles txtNetAmt.Invalidated
        Try

        Catch ex As Exception

        End Try

    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcCr.LostFocus, txtSrNo.LostFocus, txtRegister.LostFocus, butExit.LostFocus, txtAcDr.LostFocus, txtAccodedr.LostFocus, txtAcCr.LostFocus, txtAccodecr.LostFocus, txtChNo.LostFocus, txtBillNosec.LostFocus, txtGramt.LostFocus, txtBillNofirst.LostFocus, txtITName.LostFocus, txtVrNosec.LostFocus, txtVrNofirst.LostFocus, txtRemark.LostFocus, txtNetAmt.LostFocus, txtItcode.LostFocus, txtPcs.LostFocus, txtPack.LostFocus, txtQty.LostFocus, txtRate.LostFocus, txtUnit.LostFocus, txtAmount.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtITName.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
            dgItem.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox14_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcCr.GotFocus, txtAcDr.GotFocus

        Try

            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter(acm(sender.text), cn)
            ' da.Fill(ds)
            dgAcm.Visible = True
            ' DataGridView4.DataSource = ds.Tables(0)
            dgAcm.BringToFront()
            ' DataGridView4.Top = sender.Top + 22
            'DataGridView4.Left = sender.Left
            dgAcm.AutoResizeColumns()
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcDr.KeyDown
        Try

            If e.KeyCode = Keys.Down Then
                tbcheck = 1
                dgAcm.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                txtAcDr.Text = dgAcm.Item(1, dgAcm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
                While dr.Read
                    txtAccodedr.Text = dr.Item("ACCode")
                End While
                dr.Close()
                ' If TextBox12.Text = "" Then
                '   If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'newac = 2
                '  frmACMaster.Show()
                '  Me.Hide()
                '    Else
                txtAcDr.Focus()
                '   End If
                '        End If
                txtAcCr.Focus()
                dgAcm.Visible = False

            End If
        Catch ex As Exception
            If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                newac = 1
                frmACMaster.Show()
                frmACMaster.txtAcname.Text = sender.text
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
                dgAcm.Focus()
            ElseIf e.KeyCode = Keys.Up Then
                txtAcDr.Focus()

            ElseIf e.KeyCode = Keys.Enter Then
                txtAcCr.Text = dgAcm.Item(1, dgAcm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
                While dr.Read
                    txtAccodecr.Text = dr.Item("ACCode")
                End While
                dr.Close()
                comPurtype.Focus()
                dgAcm.Visible = False
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
            Dim ds1 As New DataSet
            connect()
          
                da = New SqlDataAdapter(acm(sender.Text), cn)
                da.Fill(ds)
                'da.Fill(ds, "b")
                dgAcm.Visible = True
                dgAcm.DataSource = ds.Tables(0)
                dgAcm.BringToFront()
                '  DataGridView4.Top = sender.Top + 22
                ' DataGridView4.Left = sender.Left
                dgAcm.AutoResizeColumns()

            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub DataGridView4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgAcm.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                If tbcheck = 1 Then
                    txtAcDr.Text = dgAcm.Item(1, dgAcm.SelectedCells.Item(0).RowIndex).Value
                    Dim dr As SqlDataReader
                    dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
                    While dr.Read
                        txtAccodedr.Text = dr.Item("ACCode")
                    End While
                    txtAcCr.Focus()
                    dgAcm.Visible = False
                End If
                If tbcheck = 2 Then
                    txtAcCr.Text = dgAcm.Item(1, dgAcm.SelectedCells.Item(0).RowIndex).Value
                    Dim dr As SqlDataReader
                    dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
                    While dr.Read
                        txtAccodecr.Text = dr.Item("ACCode")
                    End While

                    comPurtype.Focus()
                    dgAcm.Visible = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs)
        If sender.ToString = txtAcDr.ToString Then

        End If
    End Sub

    Private Sub comPurtype_Enter(sender As Object, e As EventArgs) Handles comPurtype.Enter
        comPurtype.DroppedDown = True
    End Sub

    Private Sub comPurtype_GotFocus(sender As Object, e As EventArgs) Handles comPurtype.GotFocus
        ' comboBox1.DroppedDown = true;
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comPurtype.KeyDown
        If e.KeyCode = Keys.Enter Then
            '    TextBox16.Focus()
            comInvoiceType.Focus()
        ElseIf ((Control.ModifierKeys And Keys.Shift) = Keys.Shift And e.KeyCode = Keys.Tab) Then

            txtAcCr.Focus()


        End If
    End Sub

    Private Sub TextBox16_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            maskChdate.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            comInvoiceType.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskChdate.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim dat As DateTime
                Dim dat1 As DateTime
                Dim dat2 As DateTime
                dat1 = dateyf.ToString
                dat2 = dateyl.ToString
                dat = maskChdate.Text.ToString
                If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                    txtBillNosec.Focus()
                Else
                    MsgBox("Please enter date in current year")
                    maskChdate.Focus()
                    '  End If

                End If
            ElseIf e.KeyCode = Keys.Up Then
                txtChNo.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox17_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillNosec.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                connect()
                If editcheck = 0 Then
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    cmd = New SqlCommand("Select * from tblPurchase where NameCr='" & txtAcCr.Text & "' and BillNo='" & txtBillNosec.Text & "'", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows Then
                        MsgBox("Bill Already exits for This Ac Cr")
                        txtBillNosec.Focus()
                    Else
                        maskBilldate.Focus()
                    End If
                    dr.Close()
                    close1()
                Else
                    maskBilldate.Focus()

                End If
            ElseIf e.KeyCode = Keys.Up Then
                maskChdate.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub maskBilldate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskBilldate.GotFocus, maskChdate.GotFocus
        sender.BackColor = Color.Pink
    End Sub
    Private Sub maskBilldate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskBilldate.LostFocus, maskChdate.LostFocus
        sender.BackColor = Color.White
    End Sub
    Private Sub MaskedTextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskBilldate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim dat As DateTime
                Dim dat1 As DateTime
                Dim dat2 As DateTime
                dat1 = dateyf
                dat2 = dateyl
                dat = maskBilldate.Text.ToString
                If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                    dg1main.Rows.Add()
                    dg1main.Item(0, 0).Selected = True
                    dg1main.Item(0, 0).Value = 1
                    txtSrNo.Text = 1
                    dg1main.Item(1, 0).Selected = True
                    txtITName.Focus()
                Else
                    MsgBox("Please enter date in current year")
                    maskBilldate.Focus()
                End If
            ElseIf e.KeyCode = Keys.Up Then
                txtBillNosec.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter

        Try
            Dim gramt As Decimal
            Dim dr As SqlDataReader
            Dim netamt As Decimal
            '    MsgBox("het")
            dr = myconselect("tblPurchase", dg1.Item(0, e.RowIndex).Value, "VrNo")
            While dr.Read
                txtNetAmt.Text = dg1.Item(dg1.ColumnCount - 6, e.RowIndex).Value
                ' MsgBox(TextBox23.Text)
                txtRegister.Text = dr.Item("BkName")
                txtRegcode.Text = dr.Item("BkCode")
                txtChNo.Text = dr.Item("ChNo")
                maskChdate.Text = Format(dr.Item("Chdt"), "dd-MM-yyyy")
                txtBillNosec.Text = dr.Item("BillNo")
                maskBilldate.Text = Format(dr.Item("BillDt"), "dd-MM-yyyy")
                txtAcDr.Text = dr.Item("Name")
                txtAcCr.Text = dr.Item("NameCr")
                txtVrNosec.Text = dr.Item("VrNo").ToString.Substring(3)
                comPurtype.Text = dr.Item("PurType")
                txtBookvr.Text = dr.Item("BookVr")
                txtJvVrno.Text = dr.Item("JVVrNo")
                gramt = dr.Item("gramt")
                netamt = dr.Item("netamt")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
            While dr.Read
                txtAccodedr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
            While dr.Read
                txtAccodecr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            connect()
            cmd = New SqlCommand("Select * from tblPurchaseDetail where BillNo='" & txtBillNosec.Text & "' and NameCr='" & txtAcCr.Text & "' and bkname='" & txtRegister.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            dg1main.Rows.Clear()
            While dr.Read
                dg1main.Rows.Add()
                txtSrNo.Text = 1
                dg1main.Item(0, i).Value = i + 1
                dg1main.Item(1, i).Value = dr.Item("ITName")
                dg1main.Item(2, i).Value = dr.Item("ITCode")
                dg1main.Item(3, i).Value = dr.Item("Pcs")
                dg1main.Item(4, i).Value = dr.Item("Pack")
                dg1main.Item(5, i).Value = dr.Item("Qty")
                dg1main.Item(6, i).Value = dr.Item("Rate")
                dg1main.Item(7, i).Value = dr.Item("Unit")
                dg1main.Item(8, i).Value = dr.Item("Amount")
                i = i + 1
            End While
            dr.Close()
            close1()
            connect()
            Dim datax As New SqlDataAdapter
            Dim dstax As New DataSet
            datax = New SqlDataAdapter("Select  bktype,tax,taxnara,changable,value,poname,pocode,al,onwhich,optype,amt,taxindex,ispost,serialno,totalamt from tblPurTax where VrNo='" & dg1.Item(0, e.RowIndex).Value & "'", cn)
            datax.Fill(dstax)
            mydg1cal.DataSource = dstax.Tables(0)
            Dim gramtcount As Integer
            txtGramt.Text = gramt
            TextBox24.Text = txtGramt.Text
            Try
                comInvoiceType.Text = mydg1cal.Item(1, 0).Value
            Catch ex As Exception

            End Try
            'gridsetup2()
            mydg1cal.Columns(0).Visible = False
            mydg1cal.Columns(1).Visible = False
            mydg1cal.Columns(3).Visible = False
            Dim i1 As Integer
            For i1 = 0 To mydg1cal.Rows.Count - 1
                If mydg1cal.Item(3, i1).Value.ToString.ToUpper = "FalSe".ToUpper Then
                    mydg1cal.Item(4, i1).ReadOnly = True
                    mydg1cal.Item(4, i1).Style.ForeColor = Color.Red
                    mydg1cal.Item(10, i1).ReadOnly = True
                    mydg1cal.Item(10, i1).Style.ForeColor = Color.Red
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
            mydg1cal.Columns(14).Visible = True
            mydg1cal.Columns(14).DefaultCellStyle.Format = "f2"
            mydg1cal.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            mydg1cal.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            mydg1cal.Columns(14).ReadOnly = True
            close1()
            dgItem.Visible = False
            dgAcm.Visible = False
            txtSrNo.Enabled = False
            'TextBox23.Text = DataGridView3.Item(DataGridView3.ColumnCount - 8, e.RowIndex).Value
            txtNetAmt.Text = netamt
            'MsgBox(TextBox23.Text)
            '    netcal()
            dg1.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        dg1.Hide()
        lblSave.Text = ""
        butSave.Enabled = True
        butAdd.Enabled = False
        butDelete.Enabled = True
        txtSrNo.Enabled = True
        editcheck = 1
        txtAmount.ReadOnly = False
        Label10.Text = "EDIT MODE"
        enableall(True)
        txtAcDr.Focus()
        Try
            Dim dr As SqlDataReader
            Dim gramt As Decimal
            Dim netamt As Decimal
            '    MsgBox("het")
            dr = myconselect("tblPurchase", dg1.Item(0, dg1.CurrentCell.RowIndex).Value, "VrNo")
            While dr.Read
                txtNetAmt.Text = dr.Item("NetAmt")
                txtRegister.Text = dr.Item("BkName")
                txtRegcode.Text = dr.Item("BkCode")
                txtChNo.Text = dr.Item("ChNo")
                maskChdate.Text = Format(dr.Item("Chdt"), "dd-MM-yyyy")
                txtBillNosec.Text = dr.Item("BillNo")
                maskBilldate.Text = Format(dr.Item("BillDt"), "dd-MM-yyyy")
                txtAcDr.Text = dr.Item("Name")
                txtAcCr.Text = dr.Item("NameCr")
                txtVrNosec.Text = dr.Item("VrNo").ToString.Substring(3)
                comPurtype.Text = dr.Item("PurType")
                txtBookvr.Text = dr.Item("BookVr")
                gramt = dr.Item("gramt")
                netamt = dr.Item("netamt")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcDr.Text, "ACName")
            While dr.Read
                txtAccodedr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            dr = myconselect("tblAccount", txtAcCr.Text, "ACName")
            While dr.Read
                txtAccodecr.Text = dr.Item("ACCode")
            End While
            dr.Close()
            Dim cmd As New SqlCommand
            Dim ds As New DataSet
            connect()
            cmd = New SqlCommand("Select * from tblPurchaseDetail where BillNo='" & txtBillNosec.Text & "' and NameCr='" & txtAcCr.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            dg1main.Rows.Clear()
            While dr.Read
                dg1main.Rows.Add()
                txtSrNo.Text = 1
                dg1main.Item(0, i).Value = i + 1
                dg1main.Item(1, i).Value = dr.Item("ITName")
                dg1main.Item(2, i).Value = dr.Item("ITCode")
                dg1main.Item(3, i).Value = dr.Item("Pcs")
                dg1main.Item(4, i).Value = dr.Item("Pack")
                dg1main.Item(5, i).Value = dr.Item("Qty")
                dg1main.Item(6, i).Value = dr.Item("Rate")
                dg1main.Item(7, i).Value = dr.Item("Unit")
                dg1main.Item(8, i).Value = dr.Item("Amount")
                i = i + 1
            End While
            dr.Close()
            close1()
            connect()
            Dim datax As New SqlDataAdapter
            Dim dstax As New DataSet
            Dim sql As String
            sql = "Select  bktype,tax,taxnara,changable,value,poname,pocode,al,onwhich,optype,amt,taxindex,ispost,serialno,totalamt from tblPurTax where VrNo='" & dg1.Item(0, dg1main.SelectedCells.Item(0).RowIndex).Value & "'"
            datax = New SqlDataAdapter("Select  bktype,tax,taxnara,changable,value,poname,pocode,al,onwhich,optype,amt,taxindex,ispost,serialno,totalamt from tblPurTax where VrNo='" & dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value & "'", cn)
            datax.Fill(dstax)
            mydg1cal.DataSource = dstax.Tables(0)
            Dim gramtcount As Integer
            txtGramt.Clear()
            txtGramt.Text = gramt
            TextBox24.Text = txtGramt.Text
            Try
                comInvoiceType.Text = mydg1cal.Item(1, 0).Value
            Catch ex As Exception

            End Try
            'gridsetup2()
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
            txtNetAmt.Text = netamt
            ' MyDataGridView1.Item(4+5, 0).Selected = True
            mydg1cal.Columns(5).Visible = False
            mydg1cal.Columns(6).Visible = False
            mydg1cal.Columns(7).ReadOnly = True
            mydg1cal.Columns(8).Visible = False
            mydg1cal.Columns(9).Visible = False
            mydg1cal.Columns(11).Visible = False
            mydg1cal.Columns(12).Visible = False
            mydg1cal.Columns(13).Visible = False
            mydg1cal.Columns(14).Visible = True
            mydg1cal.Columns(14).DefaultCellStyle.Format = "f2"
            mydg1cal.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            mydg1cal.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            mydg1cal.Columns(14).ReadOnly = True

            '   netcal()
            close1()
            dgItem.Visible = False
            dgAcm.Visible = False
            txtAcDr.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub maxbookvr()
        Dim q1 As Integer = 0
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        connect()
        cmd = New SqlCommand("Select (VrNo) from tblPurchase Where BkName='" & txtRegister.Text & "'", cn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            q1 = 1
        Else
            q1 = 0
            dr.Close()
        End If
        dr.Close()
        If q1 = 0 Then
            txtBookvr.Text = 1
        Else
            Dim max As Integer = 0
            cmd = New SqlCommand("Select (bookvr) from tblPurchase Where BkName='" & txtRegister.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                If max < Val(dr.Item(0)) Then
                    max = Val(dr.Item(0))
                End If
            End While
            txtBookvr.Text = max + 1
            dr.Close()
        End If
        close1()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        Try
            txtAmount.ReadOnly = True
            dg1.Hide()
            lblSave.Text = ""
            maxbookvr()
            butSave.Enabled = True
            'Button4.Enabled = False
            enableall(True)
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
            '    txtAcDr.Clear()
            '   txtAccodedr.Clear()
            '  txtAcCr.Clear()
            ' txtAccodecr.Clear()
            txtChNo.Clear()
            txtBillNosec.Clear()
            txtGramt.Clear()
            TextBox24.Clear()
            txtRemark.Clear()
            '  MaskedTextBox1.Clear()
            ' MaskedTextBox2.Clear()
            dg1main.Rows.Clear()
            maxVrNo(txtVrNosec, "tblPurchase")
            If txtVrNosec.Text.Length = 0 Then
                txtVrNosec.Text = 1
            End If
            txtAcDr.Focus()
            txtSrNo.Enabled = True
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
            '  maskChdate.Text = Format(Date.Today, "dd/MM/yyyy")
            ' maskBilldate.Text = Format(Date.Today, "dd/MM/yyyy")
            If comPurtype.Text = "" Then
                comPurtype.Text = comPurtype.Items(0)
            End If
            If comInvoiceType.Text = "" Then
                comInvoiceType.Text = comInvoiceType.Items(0)
            End If
            Try
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemove.Click
        Try
            Dim k As Integer = 1
            Dim i As Integer
            If dg1main.Item(0, dg1main.SelectedCells.Item(0).RowIndex).Selected = True Then
                Try
                    dg1main.Item(1, dg1main.SelectedCells.Item(0).RowIndex).Selected = True
                Catch ex As Exception

                End Try
                k = 0
            End If
            i = dg1main.SelectedCells.Item(0).RowIndex
            dg1main.Rows.RemoveAt(i)
            For i = 0 To dg1main.Rows.Count - 1
                dg1main.Item(0, i).Value = i + 1
            Next
            Try
                If k = 0 Then
                    dg1main.Item(0, dg1main.CurrentCell.RowIndex).Selected = True
                End If
            Catch ex As Exception

            End Try

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
        viewDatabse.TextBox1.Text = "tblPurchase"

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        viewDatabse.Show()
        viewDatabse.TextBox1.Text = "tblPurchaseDetail"
    End Sub

    Private Sub DataGridView1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1main.CellValidated
        Try
            If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 8 Then
                dg1main.CurrentCell.Value = Convert.ToDecimal(dg1main.CurrentCell.Value)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_DefaultValuesNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dg1main.DefaultValuesNeeded
        dg1main.Item(5, e.Row.Index).Value = 0.0
        dg1main.Item(4, e.Row.Index).Value = 0.0
        dg1main.Item(3, e.Row.Index).Value = 0.0
        dg1main.Item(2, e.Row.Index).Value = 0.0
        MsgBox("ok")
    End Sub

    Private Sub DataGridView1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dg1main.Scroll
        txtSrNo.SendToBack()
        txtITName.SendToBack()
        txtItcode.SendToBack()
        txtPcs.SendToBack()
        txtPack.SendToBack()
        txtQty.SendToBack()
        txtRate.SendToBack()
        txtUnit.SendToBack()
        txtAmount.SendToBack()
        'DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex).Value = TextBox1.Text
        'DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value = TextBox2.Text
        'DataGridView1.Item(2, DataGridView1.CurrentCell.RowIndex).Value = TextBox3.Text
        'DataGridView1.Item(3, DataGridView1.CurrentCell.RowIndex).Value = TextBox4.Text
        'DataGridView1.Item(4, DataGridView1.CurrentCell.RowIndex).Value = TextBox5.Text
        'DataGridView1.Item(5, DataGridView1.CurrentCell.RowIndex).Value = TextBox6.Text
        'DataGridView1.Item(6, DataGridView1.CurrentCell.RowIndex).Value = TextBox7.Text
        'DataGridView1.Item(7, DataGridView1.CurrentCell.RowIndex).Value = TextBox8.Text
        'DataGridView1.Item(8, DataGridView1.CurrentCell.RowIndex).Value = TextBox9.Text
    End Sub

    Private Sub DataGridView3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dg1.Enter
        Try
            dgItem.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Enter
        Try
            dgItem.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Enter
        Try
            dgItem.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try

            If MsgBox("You want to delete purchase entry for VrNo=" & txtVrNofirst.Text & txtVrNosec.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Delete from tblPurchase where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblPurchaseDetail where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='Purchase'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblPurTax where Vrno='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Bkname='" & txtRegister.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblStock where VrNo='" & txtVrNofirst.Text & txtVrNosec.Text & "' and Book='Purchase'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblJour where VrNo='" & txtJvVrno.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLedg where VrNo='" & txtJvVrno.Text & "' and book='JVPU'", cn)
                cmd.ExecuteNonQuery()
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                connect()
                da = New SqlDataAdapter("Select " & selectfield & " from tblPurchase Where BkName='" & txtRegister.Text & "' order by convert(int,bookvr)", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                Try
                    dg1.Item(0, dg1.Rows.Count - 1).Selected = True
                Catch ex As Exception
                    CLEARALL()
                End Try
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub CLEARALL()
        txtAccodecr.Clear()
        txtAccodedr.Clear()
        txtAcCr.Clear()
        txtAcDr.Clear()
        txtAmount.Clear()
        txtBillNofirst.Clear()
        txtBillNosec.Clear()
        txtBookvr.Clear()
        txtChNo.Clear()
        txtGramt.Clear()
        txtItcode.Clear()
        txtITName.Clear()
        txtJvVrno.Clear()
        txtNetAmt.Clear()
        txtPack.Clear()
        txtPcs.Clear()
        txtQty.Clear()
        txtRate.Clear()
        txtRemark.Clear()
        txtSrNo.Clear()
        txtUnit.Clear()
        txtVrNofirst.Clear()
        txtVrNosec.Clear()
        comPurtype.Text = ""
        comInvoiceType.Text = ""
        dg1main.Rows.Clear()
        '    mydg1cal.Rows.Clear()
    End Sub


    Private Sub ComboBox2_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles comInvoiceType.KeyDown
        'MsgBox("l")
        If e.KeyCode = Keys.Enter Then
            If editcheck = 0 Then
                Try
                    Dim da As New SqlDataAdapter
                    Dim ds As New DataSet
                    connect()
                    da = New SqlDataAdapter("Select * from taxmst where tax='" & comInvoiceType.Text & "' and BkType='Purchase'", cn)
                    da.Fill(ds, "tax")
                    mydg1cal.DataSource = ds.Tables(0)
                    mydg1cal.Columns(10).DefaultCellStyle.Format = "N2"
                    mydg1cal.Columns(14).DefaultCellStyle.Format = "N2"
                    mydg1cal.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    mydg1cal.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    close1()
                    mydg1cal.Columns(14).ReadOnly = True
                Catch ex As Exception
                    '    MsgBox(ex.ToString)
                End Try
            ElseIf editcheck = 1 Then
                If MessageBox.Show("If you want to change tax?", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim da As New SqlDataAdapter
                        Dim ds As New DataSet
                        connect()
                        da = New SqlDataAdapter("Select * from taxmst where tax='" & comInvoiceType.Text & "' and BkType='Purchase'", cn)
                        da.Fill(ds, "tax")
                        mydg1cal.DataSource = ds.Tables(0)
                        mydg1cal.Columns(10).DefaultCellStyle.Format = "N2"
                        mydg1cal.Columns(14).DefaultCellStyle.Format = "N2"
                        mydg1cal.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        mydg1cal.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        mydg1cal.Columns(14).ReadOnly = True
                        close1()

                    Catch ex As Exception
                        '    MsgBox(ex.ToString)
                    End Try

                End If

            End If
            txtChNo.Focus()
        ElseIf ((Control.ModifierKeys And Keys.Shift) = Keys.Shift And e.KeyCode = Keys.Tab) Then

            comPurtype.Focus()

        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comInvoiceType.SelectedIndexChanged

    End Sub
    Private Sub gridsetup()
        Try
            ' MsgBox(TotalAmount)
            txtNetAmt.Text = txtGramt.Text
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
            mydg1cal.Columns(14).Visible = True
            mydg1cal.Columns(14).ReadOnly = True
            ' MyDataGridView1.Columns(15).Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub gridsetup2()
        Try
            ' MsgBox(TotalAmount)
            txtGramt.Text = Convert.ToDecimal(TotalAmount)
            txtNetAmt.Text = txtGramt.Text
            mydg1cal.Focus()
            mydg1cal.Columns(0).Visible = False
            mydg1cal.Columns(1).Visible = False
            mydg1cal.Columns(2).Visible = False
            mydg1cal.Columns(3).Visible = False
            mydg1cal.Columns(4).Visible = False
            mydg1cal.Columns(0 + 5).Visible = False
            mydg1cal.Columns(1 + 5).Visible = False
            mydg1cal.Columns(3 + 5).Visible = False
            Dim i As Integer
            For i = 0 To mydg1cal.Rows.Count - 1
                If mydg1cal.Item(3 + 5, i).Value.ToString.ToUpper = "FalSe".ToUpper Then
                    mydg1cal.Item(4 + 5, i).ReadOnly = True
                    mydg1cal.Item(4 + 5, i).Style.ForeColor = Color.Red
                End If
            Next
            mydg1cal.Item(4 + 5, 0).Selected = True
            mydg1cal.Columns(5 + 5).Visible = False
            mydg1cal.Columns(6 + 5).Visible = False
            mydg1cal.Columns(7 + 5).ReadOnly = True
            mydg1cal.Columns(8 + 5).Visible = False
            mydg1cal.Columns(9 + 5).Visible = False
            mydg1cal.Columns(11 + 5).Visible = False
            mydg1cal.Columns(12 + 5).Visible = False
            mydg1cal.Columns(13 + 5).Visible = False
            mydg1cal.Columns(14 + 5).Visible = False
            ' DataGridView3.Item(0, 1).Selected = True
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
                            If VATCHECK = "TRUE" Then
                                amt = Format(Math.Round((mydg1cal.Item(4, i).Value * txtGramt.Text) / 100), "0.00")
                            Else
                                amt = Format(((mydg1cal.Item(4, i).Value * txtGramt.Text) / 100), "0.00")
                            End If

                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(amt + Val(txtGramt.Text), "0.00")
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(Val(txtGramt.Text) - amt, "0.00")
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = Format(mydg1cal.Item(14, c).Value, "0.00")
                                End If
                            Next
                            If VATCHECK = "TRUE" Then
                                amt = Format(Math.Round((mydg1cal.Item(4, i).Value * value) / 100), "0.00")
                            Else
                                amt = Format(((mydg1cal.Item(4, i).Value * value) / 100), "0.00")
                            End If

                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(amt + value, "0.00")
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(value - amt, "0.00")
                                End If

                            End If

                        End If
                    ElseIf dr.Item("optype").ToString.ToUpper.Trim = "fixed".ToUpper.Trim Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            amt = Format(Math.Round((mydg1cal.Item(4, i).Value)), "0.00")
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(amt + Val(txtGramt.Text), "0.00")
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(Val(txtGramt.Text) - amt, "0.00")
                                End If

                            End If
                        Else
                            Dim onwhich As String
                            onwhich = dr.Item("Onwhich").ToString
                            Dim c As Integer
                            Dim value As Decimal
                            For c = 0 To mydg1cal.Rows.Count - 1
                                If mydg1cal.Item(11, c).Value.ToString.ToUpper.Trim = onwhich.ToUpper.Trim Then
                                    value = Format(mydg1cal.Item(14, c).Value, "0.00")
                                End If
                            Next
                            amt = Math.Round((mydg1cal.Item(4, i).Value))
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(amt + value, "0.00")
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                                Else
                                    mydg1cal.Item(14, i).Value = Format(value - amt, "0.00")
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
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            txtGramt.Text = Convert.ToDecimal(TotalAmount)
            '  If editcheck = 0 Then
            'gridsetup()
            '  cal()
            ' ElseIf editcheck = 1 and Then
            ' cal()
            ' End If
            If txtGramt.Text = TextBox24.Text And txtGramt.Text.Trim.Length <> 0 Then
            Else
                gridsetup()
                cal()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub MyDataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mydg1cal.CellEnter
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
                        If VATCHECK = "TRUE" Then
                            amt = Format(Math.Round((mydg1cal.Item(4, i).Value * txtGramt.Text) / 100), "0.00")
                        Else
                            amt = Format(((mydg1cal.Item(4, i).Value * txtGramt.Text) / 100), "0.00")
                        End If

                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(amt + Val(txtGramt.Text), "0.00")
                            End If

                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(Val(txtGramt.Text) - amt, "0.00")
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
                        If VATCHECK = "TRUE" Then
                            amt = Format(Math.Round((mydg1cal.Item(4, i).Value * value) / 100), "0.00")
                        Else
                            amt = Format(((mydg1cal.Item(4, i).Value * value) / 100), "0.00")
                        End If

                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(amt + value, "0.00")
                            End If
                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(value - amt, "0.00")
                            End If

                        End If

                    End If
                ElseIf dr.Item("optype").ToString.ToUpper.Trim = "fixed".ToUpper.Trim Then
                    If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                        amt = Math.Round((mydg1cal.Item(4, i).Value))
                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(amt + Val(txtGramt.Text), "0.00")
                            End If

                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(Val(txtGramt.Text) - amt, "0.00")
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
                        amt = Format(Math.Round((mydg1cal.Item(4, i).Value)), "0.00")
                        mydg1cal.Item(10, i).Value = amt
                        If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(amt + mydg1cal.Item(14, i - 1).Value, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(amt + value, "0.00")
                            End If
                        ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                            If i <> 0 Then
                                mydg1cal.Item(14, i).Value = Format(mydg1cal.Item(14, i - 1).Value - amt, "0.00")
                            Else
                                mydg1cal.Item(14, i).Value = Format(value - amt, "0.00")
                            End If

                        End If

                    End If


                End If
            End While
            dr.Close()
            close1()
        Next
        netcal()
    End Sub
    Private Sub netcal()

        Try
            Dim i As Integer
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim STRCHECK As String
            CMD = New SqlCommand("sELECT VALUE FROM TBLSETUP WHERE BOOK='PURCHASE' AND OPERATION='NETAMTROUND'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                STRCHECK = DR.Item(0)
            End While
            DR.Close()
            If STRCHECK = "FALSE" Then
                txtNetAmt.Text = (mydg1cal.Item(14, mydg1cal.Rows.Count - 1).Value)
            Else
                txtNetAmt.Text = Math.Round(mydg1cal.Item(14, mydg1cal.Rows.Count - 1).Value)
            End If
            CMD = New SqlCommand("sELECT VALUE FROM TBLSETUP WHERE BOOK='PURCHASE' AND OPERATION='NETAMTCHANGE'", cn)
            DR = CMD.ExecuteReader
            While DR.Read
                STRCHECK = DR.Item(0)
            End While
            DR.Close()
            If STRCHECK = "FALSE" Then
                txtNetAmt.Enabled = False
            Else
                txtNetAmt.Enabled = True
            End If
            close1()
            '  TextBox23.Text = Math.Round(MyDataGridView1.Item(14, MyDataGridView1.Rows.Count - 1).Value)
            txtNetAmt.Text = Convert.ToDecimal(Val(txtNetAmt.Text))
            numericform(txtNetAmt)
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
                            If VATCHECK = "TRUE" Then
                                amt = Math.Round((mydg1cal.Item(4, i).Value * txtGramt.Text) / 100)
                            Else
                                amt = ((mydg1cal.Item(4, i).Value * txtGramt.Text) / 100)
                            End If
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGramt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGramt.Text) - amt
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
                            If VATCHECK = "TRUE" Then
                                amt = Math.Round((mydg1cal.Item(4, i).Value * value) / 100)
                            Else
                                amt = ((mydg1cal.Item(4, i).Value * value) / 100)
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
                            amt = Math.Round((mydg1cal.Item(4, i).Value))
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGramt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGramt.Text) - amt
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
                            amt = Math.Round((mydg1cal.Item(4, i).Value))
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
                i = e.RowIndex
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                connect()
                'new editing
                '  i = e.RowIndex previosly not commented
                cmd = New SqlCommand("Select Al,onwhich,optype from taxmst where taxnara='" & mydg1cal.Item(2, i).Value.ToString.Trim & "'", cn)
                dr = cmd.ExecuteReader
                Dim amt As New Decimal
                While dr.Read
                    If dr.Item("optype").ToString.ToUpper = "per".ToUpper Then
                        If dr.Item("onwhich").ToString.ToUpper = "Gr".ToUpper Then
                            If VATCHECK = "TRUE" Then
                                amt = Math.Round(mydg1cal.Item(10, i).Value)
                            Else
                                amt = (mydg1cal.Item(10, i).Value)
                            End If

                            '    MyDataGridView1.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                    MsgBox(mydg1cal.Item(14, i).Value)
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGramt.Text)
                                End If
                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGramt.Text) - amt
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
                                    MsgBox(value)
                                End If
                            Next
                            If VATCHECK = "TRUE" Then
                                amt = Math.Round(mydg1cal.Item(10, i).Value)
                            Else
                                amt = (mydg1cal.Item(10, i).Value)
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
                            amt = Math.Round(mydg1cal.Item(10, i).Value)
                            mydg1cal.Item(10, i).Value = amt
                            If mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "Add".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = amt + mydg1cal.Item(14, i - 1).Value
                                Else
                                    mydg1cal.Item(14, i).Value = amt + Val(txtGramt.Text)
                                End If

                            ElseIf mydg1cal.Item(7, i).Value.ToString.ToUpper.Trim = "less".ToUpper.Trim Then
                                If i <> 0 Then
                                    mydg1cal.Item(14, i).Value = mydg1cal.Item(14, i - 1).Value - amt
                                Else
                                    mydg1cal.Item(14, i).Value = Val(txtGramt.Text) - amt
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
                            amt = Math.Round(mydg1cal.Item(10, i).Value)
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
                'arrange(e.RowIndex + 1)
            End If
            If e.RowIndex = mydg1cal.Rows.Count - 1 Then
                netcal()
            Else
                arrange(e.RowIndex + 1)
            End If
            If e.ColumnIndex = 10 Or e.ColumnIndex = 14 Then
                mydg1cal.CurrentCell.Value = Convert.ToDecimal(mydg1cal.CurrentCell.Value)
            End If
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub MyDataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mydg1cal.CellContentClick

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Dim i As Integer
            txtNetAmt.Text = mydg1cal.Item(14, mydg1cal.Rows.Count - 1).Value
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1main.CellContentClick

    End Sub

    Private Sub MyDataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mydg1cal.KeyDown
        If e.KeyCode = Keys.Tab Then
            Try
                Dim i As Integer
                txtNetAmt.Text = mydg1cal.Item(14, mydg1cal.Rows.Count - 1).Value
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            ' Button1.Focus()
            txtRemark.Focus()
            txtNetAmt.Focus()
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged

    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1main.CellValueChanged

    End Sub

    Private Sub TextBox22_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtITName.TextChanged

    End Sub

    Private Sub MaskedTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maskChdate.Enter
        maskChdate.SelectionStart = 0
        maskChdate.SelectionLength = 0
    End Sub
    Private Sub MaskedTextBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maskBilldate.Enter
        maskBilldate.SelectionStart = 0
        maskBilldate.SelectionLength = 0
    End Sub

    Private Sub TextBox18_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGramt.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
               
                If Val(txtGramt.Text) = Val(TextBox24.Text) And txtGramt.Text.Trim.Length <> 0 Then
                Else
                    gridsetup()
                    cal()
                End If
                netcal()
                mydg1cal.Focus()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub
    Private Sub TextBox23_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNetAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            numericform(txtNetAmt)
            txtRemark.Focus()
        End If
    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dg1main.RowsAdded
        Try
            dg1main.Item(0, e.RowIndex).Value = Val(dg1main.Item(0, e.RowIndex - 1).Value) + 1
        Catch ex As Exception

        End Try
        dg1main.Item(3, e.RowIndex).Value = "0.00"
        dg1main.Item(4, e.RowIndex).Value = "0.00"
        dg1main.Item(5, e.RowIndex).Value = "0.00"
        dg1main.Item(6, e.RowIndex).Value = "0.00"
        dg1main.Item(7, e.RowIndex).Value = "0.00"
        dg1main.Item(8, e.RowIndex).Value = "0.00"
    End Sub

    Private Sub TextBox17_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBillNosec.Leave
        If txtBillNosec.Text.Trim.Length = 0 Then
            MsgBox("Bill No CanNot be Blank")
            txtBillNosec.Focus()
        End If
    End Sub

    Private Sub TextBox18_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGramt.Leave
        numericform(txtGramt)
    End Sub

    Private Sub TextBox22_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles txtRemark.Layout

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        timercount = timercount + 1
        MsgBox("kl")
    End Sub

    '   Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus, Button2.GotFocus, Button3.GotFocus, Button4.GotFocus, Button5.GotFocus, Button6.GotFocus, Button7.GotFocus, Button8.GotFocus, Button9.GotFocus, Button10.GotFocus
    '      sender.BackColor = Color.Blue
    '     sender.ForeColor = Color.White
    'End Sub
    ' Private Sub Button11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.LostFocus, Button2.LostFocus, Button3.LostFocus, Button4.LostFocus, Button5.LostFocus, Button6.LostFocus, Button7.LostFocus, Button8.LostFocus, Button9.LostFocus, Button10.LostFocus
    '    sender.BackColor = Me.BackColor
    '   sender.ForeColor = Color.Black
    ' End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
    Private Sub ComboBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comInvoiceType.Leave
        If comInvoiceType.Items.Contains(comInvoiceType.Text) = False Then
            MsgBox("Select from List")
            comInvoiceType.Focus()
        End If
        comInvoiceType.DroppedDown = False
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comPurtype.Leave
        If sender.Items.Contains(sender.Text) = False Then
            MsgBox("Select from list")
            sender.Focus()

        End If
        comPurtype.DroppedDown = True
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskChdate.Leave
        Try

            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime
            dat1 = dateyf.ToString
            dat2 = dateyl.ToString
            dat = maskChdate.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                '      txtBillNosec.Focus()
            Else
                MsgBox("Please enter date in current year")
                maskChdate.Focus()
            End If


        Catch ex As Exception
            MsgBox("enter proper date")
        End Try

    End Sub

    Private Sub MaskedTextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskBilldate.Leave
        Try

            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime
            dat1 = dateyf
            dat2 = dateyl
            dat = maskBilldate.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                Try
                    '   dg1main.Rows.Add()
                Catch ex As Exception

                End Try

                Try
                    '  dg1main.Item(0, 0).Selected = True
                    ' dg1main.Item(0, 0).Value = 1
                    'txtSrNo.Text = 1
                Catch ex As Exception

                End Try
                Try
                    ' dg1main.Item(1, 0).Selected = True
                    '    txtITName.Focus()

                Catch ex As Exception

                End Try
            Else
                MsgBox("Please enter date in current year")
                maskBilldate.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter proper date")
        End Try

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

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles maskChdate.MaskInputRejected

    End Sub

    Private Sub TextBox26_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox26.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button12.Focus()
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox26.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox26.Text
        For i = temp1 To dg1.Rows.Count - 1
            For j = temp2 To dg1.ColumnCount - 1
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)

                If (dg1.Item(j, i).Value.ToString.ToLower.ToString.Contains(TextBox26.Text.ToLower)) Then
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

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        GroupBox1.Visible = False
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        GroupBox1.Visible = True
        tv1 = ""
    End Sub

    Private Sub DataGridView3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg1.Visible = False
            GroupBox1.Visible = False
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegcode.TextChanged

    End Sub

    Private Sub Form3_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter("Select " & selectfield & " from tblPurchase Where BkName='" & txtRegister.Text & "' order By convert(int,BookVr)", cn)
            da.Fill(ds)

            dg1.DataSource = ds.Tables(0)
            dg1.BringToFront()
            dg1.Visible = True
            Try
                dg1.Item(0, dg1.Rows.Count - 1).Selected = True
            Catch ex As Exception

            End Try
            close1()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub comInvoiceType_Enter(sender As Object, e As EventArgs) Handles comInvoiceType.Enter
        comInvoiceType.DroppedDown = True
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        frmUnitMaster.Show()
    End Sub
End Class
