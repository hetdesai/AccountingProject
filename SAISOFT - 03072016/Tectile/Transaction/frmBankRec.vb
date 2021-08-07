Imports System.Data.SqlClient
Public Class frmBankRec
    Dim dr As SqlDataReader
    Public bankac As Integer = 0
    Public checkedit As Integer = 0
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim selectfield As String
    Dim gridamount As Decimal
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim tv1 As String
    Dim billclear As String = ""
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
    Private Sub clearall()
        txtVrNosec.Clear()
        txtRemark.Clear()
        txtAmount.Text = "0.00"
        txtChqno.Clear()
        txtAcName.Clear()
        txtAccode.Clear()
        txtRefBank.Clear()
    End Sub
    Private Sub dgacm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcName.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
            Dim dr As SqlDataReader
            dr = myconselect("tblAccount", txtAcName.Text, "ACName")
            While dr.Read
                txtAccode.Text = dr.Item("ACCode")
            End While
            txtChqno.Focus()
            dgacm.Visible = False
        End If
    End Sub
    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcName.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChqno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRefBank.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAcName.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox1.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtChqno.Focus()
        End If
    End Sub
    Private Sub TextBox7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcName.Leave
        dr = myconselect("tblAccount", txtAcName.Text, "ACName")
        While dr.Read
            txtAccode.Text = dr.Item("ACCode")
        End While
        dr.Close()
    End Sub
    Private Sub TextBox7_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcName.KeyUp
        ' myAutoComplete(TextBox7, ListBox1, "tblAccount", "ACName")
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            Dim ds1 As New DataSet
            connect()
            da = New SqlDataAdapter(acm(sender.Text), cn)
            da.Fill(ds)
            'da.Fill(ds, "b")
            dgacm.Visible = True
            dgacm.DataSource = ds.Tables(0)
            dgacm.AutoResizeColumns()
            dgacm.BringToFront()
            dgacm.BringToFront()
            '  dgacm.Top = sender.Top + 22
            '     dgacm.Left = sender.Left
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.RowEnter
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblbankrec where vrno='" & DG1.Item(0, e.RowIndex).Value & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                txtVrnofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                txtVrNosec.Text = dr.Item("vrno").ToString.Substring(3)
                txtBKCode.Text = dr.Item("bkcode")
                txtBkName.Text = dr.Item("bkname")
                maskdate.Text = Format(dr.Item("dat"), "dd-MM-yyyy")
                txtAcName.Text = dr.Item("Name")
                txtAccode.Text = dr.Item("accode")
                txtChqno.Text = dr.Item("checkno")
                txtRefBank.Text = dr.Item("refbank")
                txtAmount.Text = dr.Item("amount")
                txtRemark.Text = dr.Item("desce")
                gridamount = dr.Item("amount")
                ComboBox1.Text = dr.Item("billclear")
                billclear = dr.Item("billclear")
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            txtAmount.Focus()
        End If
    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcName.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgacm.Rows.Count <> 0 Then
                txtAcName.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                dgacm.Visible = False
                txtChqno.Focus()
            Else
                If MsgBox("Account not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    bankac = 1
                    frmACMaster.Show()
                    Me.Hide()
                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            dgacm.Focus()
            dgacm.Item(0, 0).Selected = True
        ElseIf e.KeyCode = Keys.Up Then
            dgacm.Visible = False
            maskdate.Focus()
        End If
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkName.GotFocus, txtBKCode.GotFocus, txtVrnofirst.GotFocus, txtVrNosec.GotFocus, txtRemark.GotFocus, txtAmount.GotFocus, txtChqno.GotFocus, txtAcName.GotFocus, txtAccode.GotFocus, txtRefBank.GotFocus, maskdate.GotFocus
        Try
            sender.BackColor = Color.Pink
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBkName.LostFocus, txtBKCode.LostFocus, txtVrnofirst.LostFocus, txtVrNosec.LostFocus, txtRemark.LostFocus, txtAmount.LostFocus, txtChqno.LostFocus, txtAcName.LostFocus, txtAccode.LostFocus, txtRefBank.LostFocus, maskdate.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub frmBankRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
            dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
            connect()
            Dim cmd1 As New SqlCommand
            Dim dr1 As SqlDataReader
            cmd1 = New SqlCommand("select fields from tblselectfield where tablename='tblbank'", cn)
            dr1 = cmd1.ExecuteReader
            While dr1.Read
                selectfield = dr1.Item(0).ToString.Substring(0, dr1.Item(0).ToString.Length - 1)
            End While
            dr1.Close()
            close1()
            Try
                txtBkName.Text = frmMainScreen.bankrnam
                dr = myconselect("tblAccount", txtBkName.Text, "ACName")
                While dr.Read
                    txtBKCode.Text = dr.Item("ACCode")
                End While
                dr.Close()
                Dim ds As New DataSet
                connect()
                Dim da As New SqlDataAdapter
                da = New SqlDataAdapter("Select " & selectfield & " from tblBank Where BkName='" & txtBkName.Text & "' and Namecr='" & txtBkName.Text & "'ORDER BY convert(int,substring(vrno,4,len(Vrno))) ", cn)
                da.Fill(ds)
                DG1.DataSource = ds.Tables(0)
                close1()
                If DG1.RowCount = 0 Then
                Else
                    DG1.Item(0, DG1.Rows.Count - 1).Selected = True
                End If
                txtVrnofirst.Text = acycode & "\"

                'TextBox3.Text = "2"
                
en:
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            txtVrnofirst.Text = acycode & "\"
            myfilldatagrid(DG1, "tblBankRec")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub butAdd_Click(sender As Object, e As EventArgs) Handles butAdd.Click

        GroupBox1.Enabled = True
        Label11.Text = "ADD Mode"
        clearall()
        maxVrNo(txtVrNosec, "tblBankRec")
        maskdate.Focus()
        '  MaskedTextBox1.Text = Format(Date.Today, "dd-MM-yyyy")
        maskdate.SelectionStart = 0
    End Sub

    Private Sub butEdit_Click(sender As Object, e As EventArgs) Handles butEdit.Click
        GroupBox1.Enabled = True
        

        Try
            Try
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("select * from tblbankrec where vrno='" & DG1.Item(0, DG1.CurrentCell.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    txtVrnofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                    txtVrNosec.Text = dr.Item("vrno").ToString.Substring(3)
                    txtBKCode.Text = dr.Item("bkcode")
                    txtBkName.Text = dr.Item("bkname")
                    maskdate.Text = Format(dr.Item("dat"), "dd-MM-yyyy")
                    txtAcName.Text = dr.Item("Name")
                    txtAccode.Text = dr.Item("accode")
                    txtChqno.Text = dr.Item("checkno")
                    txtRefBank.Text = dr.Item("refbank")
                    txtAmount.Text = dr.Item("amount")
                    gridamount = dr.Item("amount")
                    txtRemark.Text = dr.Item("desce")
                End While
                dr.Close()
                close1()
                Label11.Text = "EDIT MODE"
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            maskdate.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub butFind_Click(sender As Object, e As EventArgs) Handles butFind.Click
        Try
           
            GroupBox2.Visible = True
            txtFind.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (txtFind.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = txtFind.Text
        For i = temp1 To DG1.Rows.Count - 1
            For j = temp2 To DG1.ColumnCount - 1
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)
                If (DG1.Item(j, i).Value.ToString.ToLower.ToString.Contains(tv1.ToLower)) Then
                    DG1.Item(j, i).Selected = True
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

    Private Sub butSave_Click(sender As Object, e As EventArgs) Handles butSave.Click
        Try
            checkedit = 0
            Dim dat1 As New Date
            dat1 = maskdate.Text.ToString
            Dim a() As String = {txtVrnofirst.Text & txtVrNosec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, txtBKCode.Text, txtBkName.Text, txtAccode.Text, txtAcName.Text, txtAmount.Text, txtRemark.Text, txtChqno.Text, txtRefBank.Text, "Bank", txtBkName.Text, txtBKCode.Text, 0, " ", 0, "f", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, ComboBox1.Text}
            If Label11.Text = "ADD Mode" Then
                Dim cmdcheck As New SqlCommand
                Dim drcheck As SqlDataReader
                connect()
                cmdcheck = New SqlCommand("Select * from tblBankRec where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                drcheck = cmdcheck.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo last
                Else
                    drcheck.Close()
                End If
                close1()
                myinsert(a, "tblBankRec")


            ElseIf Label11.Text.ToLower = "EDIT Mode".ToLower Then
                Dim cmdcheck As New SqlCommand

                connect()
                cmdcheck = New SqlCommand("delete from tblBankRec where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmdcheck.ExecuteNonQuery()
                close1()
                myinsert(a, "tblBankRec")

              
            Else
                MsgBox("Incorrect Option")
            End If
            connect()
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select " & selectfield & " from tblBankRec Where BkName='" & txtBkName.Text & "' and Namecr='" & txtBkName.Text & "'ORDER BY convert(int,substring(vrno,4,len(Vrno))) ", cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            If DG1.RowCount = 0 Then
            Else
                DG1.Item(0, DG1.Rows.Count - 1).Selected = True
            End If
            close1()
            MsgBox("success")
            'clearall()
            '    Button2.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
last:
    End Sub

    Private Sub butDelete_Click(sender As Object, e As EventArgs) Handles butDelete.Click
        Try
            Dim dat1 As New Date
            dat1 = maskdate.Text.ToString
            Dim paidamt As New ListBox
            Dim oubNo As New ListBox
            Dim bkcode As New ListBox
            Dim RD As Decimal
            Dim TDS As Decimal
            Dim CLAIM As Decimal
            Dim DISCOUNT As Decimal
            connect()
            If MsgBox("You want to delete entry for VrNo=" & txtVrnofirst.Text & txtVrNosec.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim cmd As New SqlCommand
                Dim da1 As New SqlDataAdapter
                cmd = New SqlCommand("Delete from tblBankRec where VrNo='" & txtVrnofirst.Text & txtVrNosec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                connect()
                da = New SqlDataAdapter("Select " & selectfield & " from tblBankRec Where BkName='" & txtBkName.Text & "' and Namecr='" & txtBkName.Text & "'", cn)
                da.Fill(ds)
                DG1.DataSource = ds.Tables(0)
                Try
                    DG1.Item(0, DG1.RowCount - 1).Selected = True
                Catch ex As Exception
                    txtAccode.Clear()
                    txtAcName.Clear()
                    txtAmount.Clear()
                    txtChqno.Clear()
                    txtFind.Clear()
                    txtRefBank.Clear()
                    txtRemark.Clear()
                    txtVrnofirst.Clear()
                    txtVrNosec.Clear()
                End Try
                close1()
            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_Enter(sender As Object, e As EventArgs) Handles ComboBox1.Enter
        ComboBox1.DroppedDown = True
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAmount.Focus()
        ElseIf e.KeyCode = Keys.Up Then

        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemark.Focus()
        End If
    End Sub
End Class