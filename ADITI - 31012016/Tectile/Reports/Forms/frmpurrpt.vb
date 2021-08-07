Imports System.Data.SqlClient
Public Class frmpurrpt
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Public sql As String
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub frmpurrpt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.backcolor = Color.Yellow
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox1.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox1.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox1.Focus()
        End Try
    End Sub

    Private Sub MaskedTextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox2.Leave
        Try

            Dim dat As New Date
            dat = MaskedTextBox2.Text
            If DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter date in current A/c Year")
                MaskedTextBox2.Focus()
            End If
            sender.backcolor = Color.White
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox2.Focus()
        End Try
    End Sub
    Private Sub frmpurrpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        Try
            If frmMainScreen.report = "Group Detail" Or frmMainScreen.report = "Group Monthly" Or frmMainScreen.report = "Group Summary" Or frmMainScreen.report = "Group Bill Wise" Or frmMainScreen.report = "Group Party Bill Wise" Or frmMainScreen.report = "Group Party Monthly" Or frmMainScreen.report = "Group Party Summary" Or frmMainScreen.report = "Group Party Detail" Or frmMainScreen.report = "SGroup Detail" Or frmMainScreen.report = "SGroup Monthly" Or frmMainScreen.report = "SGroup Summary" Or frmMainScreen.report = "SGroup Bill Wise" Or frmMainScreen.report = "SGroup Party Bill Wise" Or frmMainScreen.report = "SGroup Party Monthly" Or frmMainScreen.report = "SGroup Party Summary" Or frmMainScreen.report = "SGroup Party Detail" Then
                CheckedListBox1.Enabled = True
                CheckedListBox2.Enabled = True
            ElseIf frmMainScreen.report = "Party Detail" Or frmMainScreen.report = "Party Bill Wise" Or frmMainScreen.report = "Party Monthly" Or frmMainScreen.report = "Party Summary" Or frmMainScreen.report = "SParty Detail" Or frmMainScreen.report = "SParty Bill Wise" Or frmMainScreen.report = "SParty Monthly" Or frmMainScreen.report = "SParty Summary" Then
                CheckedListBox2.Enabled = True
            ElseIf frmMainScreen.report = "Item Detail" Or frmMainScreen.report = "Item Monthly" Or frmMainScreen.report = "Item Summary" Then
                CheckedListBox3.Enabled = True
            ElseIf frmMainScreen.report = "Party Item Detail" Or frmMainScreen.report = "Party Item Monthly" Or frmMainScreen.report = "Party Item Summary" Or frmMainScreen.report = "SItem Detail" Or frmMainScreen.report = "SItem Monthly" Or frmMainScreen.report = "SItem Summary" Or frmMainScreen.report = "SParty Item Detail" Or frmMainScreen.report = "SParty Item Monthly" Or frmMainScreen.report = "SParty Item Summary" Then
                CheckedListBox2.Enabled = True
                CheckedListBox3.Enabled = True
            ElseIf frmMainScreen.report = "Party Detail" Or frmMainScreen.report = "Party Bill Wise" Or frmMainScreen.report = "Party Monthly" Or frmMainScreen.report = "Party Summary" Or frmMainScreen.report = "SParty Detail" Or frmMainScreen.report = "SParty Bill Wise" Or frmMainScreen.report = "SParty Monthly" Or frmMainScreen.report = "SParty Summary" Then
                CheckedListBox2.Enabled = True
            End If
            If frmMainScreen.report = "Group Detail" Or frmMainScreen.report = "Group Monthly" Or frmMainScreen.report = "Group Summary" Or frmMainScreen.report = "Group Bill Wise" Or frmMainScreen.report = "Group Party Bill Wise" Or frmMainScreen.report = "Group Party Monthly" Or frmMainScreen.report = "Group Party Summary" Or frmMainScreen.report = "Group Party Detail" Or frmMainScreen.report = "Party Detail" Or frmMainScreen.report = "Party Bill Wise" Or frmMainScreen.report = "Party Monthly" Or frmMainScreen.report = "Party Summary" Or frmMainScreen.report = "Party Item Detail" Or frmMainScreen.report = "Party Item Monthly" Or frmMainScreen.report = "Party Item Summary" Or frmMainScreen.report = "Item Detail" Or frmMainScreen.report = "Item Monthly" Or frmMainScreen.report = "Item Summary" Or frmMainScreen.report = "Register Detail" Or frmMainScreen.report = "Register Monthly" Or frmMainScreen.report = "Register Summary" Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select * from tblAccount where book='Purchase'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    CheckedListBox4.Items.Add(dr.Item("ACName"))
                End While
                dr.Close()
                close1()
            ElseIf frmMainScreen.report = "SGroup Detail" Or frmMainScreen.report = "SGroup Monthly" Or frmMainScreen.report = "SGroup Summary" Or frmMainScreen.report = "SGroup Bill Wise" Or frmMainScreen.report = "SGroup Party Bill Wise" Or frmMainScreen.report = "SGroup Party Monthly" Or frmMainScreen.report = "SGroup Party Summary" Or frmMainScreen.report = "SGroup Party Detail" Or frmMainScreen.report = "SParty Detail" Or frmMainScreen.report = "SParty Bill Wise" Or frmMainScreen.report = "SParty Monthly" Or frmMainScreen.report = "SParty Summary" Or frmMainScreen.report = "SParty Item Detail" Or frmMainScreen.report = "SParty Item Monthly" Or frmMainScreen.report = "SParty Item Summary" Or frmMainScreen.report = "SItem Detail" Or frmMainScreen.report = "SItem Monthly" Or frmMainScreen.report = "SItem Summary" Or frmMainScreen.report = "SRegister Detail" Or frmMainScreen.report = "SRegister Monthly" Or frmMainScreen.report = "SRegister Summary" Then
                connect()
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select * from tblAccount where book='Sales'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    CheckedListBox4.Items.Add(dr.Item("ACName"))
                End While
                dr.Close()
                close1()

            End If
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            connect()
            cmd = New SqlCommand("Select pgroup from tblAccount group by Pgroup", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select ACName from tblAccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox2.Items.Add(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select ITName from tblItem", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox3.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim dat1 As New Date
            Dim dat2 As New Date
            Dim i As Integer
            '*********************************fro book filter**************************
            Dim bk As String = "and ("
            If CheckedListBox4.CheckedItems.Count = 0 Then
                For i = 0 To CheckedListBox4.Items.Count - 1
                    bk = bk & "Bkname='" & CheckedListBox4.Items(i).ToString & "' Or "
                Next
            End If
            For i = 0 To CheckedListBox4.CheckedItems.Count - 1
                bk = bk & "Bkname='" & CheckedListBox4.CheckedItems(i).ToString & "' Or "
            Next
            bk = bk.Substring(0, bk.Length - 4).ToString & ")"
            ' MsgBox(bk)
            '****************************************************************************
            '*****************************for Item Filter********************************
            Dim it As String = "and ("
            If CheckedListBox3.CheckedItems.Count = 0 Then
                For i = 0 To CheckedListBox3.Items.Count - 1
                    it = it & "ITName='" & CheckedListBox3.Items(i).ToString & "' Or "
                Next
            End If
            For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                it = it & "ITName='" & CheckedListBox3.CheckedItems(i).ToString & "' Or "
            Next
            it = it.Substring(0, it.Length - 4).ToString & ")"
            '************************************************************************
            '********************************fro ACName filter**********************
            Dim ac As String = "and ("
            If CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To CheckedListBox2.Items.Count - 1
                    ac = ac & "ACName='" & CheckedListBox2.Items(i).ToString & "' Or "
                Next
            End If
            For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                ac = ac & "ACName='" & CheckedListBox2.CheckedItems(i).ToString & "' Or "
            Next
            ac = ac.Substring(0, ac.Length - 4).ToString & ")"
            Dim ac1 As String = "and ("
            If CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To CheckedListBox2.Items.Count - 1
                    ac1 = ac1 & "Name='" & CheckedListBox2.Items(i).ToString & "' Or "
                Next
            End If
            For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                ac1 = ac1 & "Name='" & CheckedListBox2.CheckedItems(i).ToString & "' Or "
            Next

            ac1 = ac1.Substring(0, ac1.Length - 4).ToString & ")"
            '***********************************************************************
            dat1 = MaskedTextBox1.Text.ToString
            dat2 = MaskedTextBox2.Text.ToString
            If frmMainScreen.report = "Register Detail" Then
                sql = "Select * from tblPurchase where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk
            ElseIf frmMainScreen.report = "Register Monthly" Then
                sql = "Select * from tblPurchase where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk
            ElseIf frmMainScreen.report = "Register Summary" Then
                sql = "Select * from tblPurchase where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk
            ElseIf frmMainScreen.report = "Group Detail" Or frmMainScreen.report = "Group Monthly" Or frmMainScreen.report = "Group Summary" Or frmMainScreen.report = "Party Detail" Or frmMainScreen.report = "Party Monthly" Or frmMainScreen.report = "Party Summary" Or frmMainScreen.report = "Group Party Summary" Or frmMainScreen.report = "Group Party Monthly" Or frmMainScreen.report = "Group Party Detail" Then
                sql = "Select * from tblPurchase,tblAccount where tblAccount.ACCode=tblPurchase.ACCodeCr and (tblPurchase.BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and tblPurchase.BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk & ac
            ElseIf frmMainScreen.report = "Group Bill Wise" Or frmMainScreen.report = "Party Bill Wise" Or frmMainScreen.report = "Group Party Bill Wise" Or frmMainScreen.report = "Party Item Detail" Or frmMainScreen.report = "Party Item Monthly" Or frmMainScreen.report = "Party Item Summary" Or frmMainScreen.report = "Item Detail" Or frmMainScreen.report = "Item Monthly" Or frmMainScreen.report = "Item Summary" Then
                sql = "Select * from tblPurchasedetail,tblAccount where tblAccount.ACCode=tblPurchaseDetail.ACCodeCr and (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk & it & ac & "order by TBLPURCHASEDETAIL.BILLDT"
            ElseIf frmMainScreen.report = "a" Then
                sql = "Select * from tblPurchaseDetail  where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk & it & "order by TBLPURCHASE.BILLDT"
                '**********************************************************************************************************************
                'this is for Sale
            ElseIf frmMainScreen.report = "SRegister Detail" Then
                sql = "Select * from salesc where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk
            ElseIf frmMainScreen.report = "SRegister Monthly" Then
                sql = "Select * from salesc where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk
            ElseIf frmMainScreen.report = "SRegister Summary" Then
                sql = "Select * from salesc where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk
            ElseIf frmMainScreen.report = "SGroup Detail" Or frmMainScreen.report = "SGroup Monthly" Or frmMainScreen.report = "SGroup Summary" Or frmMainScreen.report = "SParty Detail" Or frmMainScreen.report = "SParty Monthly" Or frmMainScreen.report = "SParty Summary" Or frmMainScreen.report = "SGroup Party Summary" Or frmMainScreen.report = "SGroup Party Monthly" Or frmMainScreen.report = "SGroup Party Detail" Then
                sql = "Select * from salesc,tblAccount where tblAccount.ACCode=salesc.ACCode and (salesc.BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and salesc.BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk & ac & " order by CONVERT(INT,BillNo)"
            ElseIf frmMainScreen.report = "SGroup Bill Wise" Or frmMainScreen.report = "SGroup Party Bill Wise" Then
                sql = "Select * from salec1,tblAccount where tblAccount.ACCode=salec1.ACCode and (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk & ac & " order by CONVERT(INT,salec1.BillNo)"
            ElseIf frmMainScreen.report = "SItem Detail" Or frmMainScreen.report = "SItem Monthly" Or frmMainScreen.report = "SItem Summary" Or frmMainScreen.report = "SParty Item Detail" Or frmMainScreen.report = "SParty Item Monthly" Or frmMainScreen.report = "SParty Item Summary" Or frmMainScreen.report = "SParty Bill Wise" Then
                sql = "Select * from salec1 where (BillDt >= '" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and BillDt <= '" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "') " & bk & ac1 & it & " order by CONVERT(INT,salec1.BillNo)"
            End If
            Dim i1 As New frmpur1
            i1.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UserControl11_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserControl11.Leave
        MaskedTextBox1.Text = UserControl11.mydat
    End Sub

    Private Sub UserControl12_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserControl12.Leave
        MaskedTextBox2.Text = UserControl12.mydat
    End Sub
    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub CheckedListBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.GotFocus, CheckedListBox2.GotFocus, CheckedListBox3.GotFocus, CheckedListBox4.GotFocus
        sender.SelectedIndex = 0
        sender.backcolor = Color.LightYellow
    End Sub

    Private Sub CheckedListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckedListBox1.LostFocus, CheckedListBox2.LostFocus, CheckedListBox3.LostFocus, CheckedListBox4.LostFocus
        sender.selectedindex = -1
        sender.backcolor = Color.White
    End Sub

  
    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        Try
            connect()
            Dim CMD As New SqlCommand
            Dim DR As SqlDataReader
            Dim I As Integer
            If CheckedListBox1.CheckedItems.Count = 0 Then
                GoTo EN
            End If
            CheckedListBox2.Items.Clear()
            For I = 0 To CheckedListBox1.CheckedItems.Count - 1
                CMD = New SqlCommand("sELECT * FROM TBLACCOUNT WHERE PGROUP='" & CheckedListBox1.CheckedItems(I).ToString & "'", cn)
                DR = CMD.ExecuteReader
                While DR.Read
                    CheckedListBox2.Items.Add(DR.Item("ACNAME"))
                End While
                DR.Close()
            Next
            close1()
EN:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub MaskedTextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Enter, MaskedTextBox2.Enter, MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionStart = 0
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
       
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Dim i As Integer = CheckedListBox4.FindString(TextBox1.Text)
        CheckedListBox4.SelectedIndex = i
        If CheckedListBox4.Text = "" Then
            CheckedListBox4.SelectedIndex = -1
        End If
    End Sub
End Class