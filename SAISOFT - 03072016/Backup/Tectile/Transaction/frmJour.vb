Imports System.Data.SqlClient
Public Class frmJour
    Dim i As Integer = 0
    Dim editcheck As Integer
    Dim isdr As Integer = 0
    Dim iscr As Integer = 0
    Public jourac As Integer = 0
    Public timercount As Integer = 0
    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus, TextBox7.GotFocus, TextBox8.GotFocus
        TextBox4.SendToBack()
        TextBox5.SendToBack()
        TextBox6.SendToBack()
        TextBox7.SendToBack()
        TextBox8.SendToBack()
        sender.BringtoFront()
    End Sub
    Private Sub my_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus, TextBox6.GotFocus, TextBox7.GotFocus, TextBox8.GotFocus, DG2.GotFocus, ButSave.GotFocus, butEXIT.GotFocus, butAdd.GotFocus, butEdit.GotFocus, butDelete.GotFocus, maskdate.GotFocus, dg1.GotFocus
        dgacm.Visible = False
    End Sub
    Private Sub my1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles maskdate.GotFocus
        maskdate.SelectionStart = 0
    End Sub
    Private Sub TextBox41_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus

    End Sub
    Private Sub one(ByRef tb As TextBox)
        Dim re As New Rectangle
        re = dg1.GetCellDisplayRectangle(dg1.CurrentCell.ColumnIndex, dg1.CurrentCell.RowIndex, True)
        tb.Top = re.Top + 92
        tb.Left = re.Left + 12
        tb.BringToFront()
        TextBox4.Text = dg1.Item(2, dg1.CurrentCell.RowIndex).Value
        TextBox5.Text = dg1.Item(4, dg1.CurrentCell.RowIndex).Value
        TextBox6.Text = dg1.Item(5, dg1.CurrentCell.RowIndex).Value
        TextBox7.Text = dg1.Item(6, dg1.CurrentCell.RowIndex).Value
        TextBox8.Text = dg1.Item(1, dg1.CurrentCell.RowIndex).Value
        If TextBox5.Text.Trim = "" Then
            TextBox5.Text = 0
        End If
        If TextBox6.Text.Trim = "" Then
            TextBox6.Text = 0
        End If
        tb.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEXIT.Click
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

    Private Sub frmJour_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        End If
    End Sub
    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles maskdate.Leave
        Try
            Dim dat As New Date
            dat = maskdate.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Or DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter Date in Current A/c Year")
                maskdate.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            maskdate.Focus()
        End Try
    End Sub
    Private Sub frmJour_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtvrnofirst.Text = acycode & "/"
            companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
            dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

            ButSave.Enabled = False
            butDelete.Enabled = False
            i = 1
            dg1.Columns(3).ReadOnly = True
            dg1.Rows.Add()
            'myfillCustome(TextBox4, "tblAccount", "ACName")
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            '      da = New SqlDataAdapter("Select VrNo,Sum(dr) as Amount from tblJour group by VrNo order by convert(int,SUBSTR(vrno, 3))", cn)
            Try

                da = New SqlDataAdapter("select VrNo,Sum(dr) as Amount from tbljour group by vrno order by convert(int,substring(vrno,4,len(vrno)-3))", cn)
                da.Fill(ds)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            DG2.DataSource = ds.Tables(0)
            Try
                DG2.Item(0, DG2.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try
            DG2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            close1()
            If frmzoom7.zoom = True Then
                Dim cn As Integer
                For cn = 0 To DG2.Rows.Count - 1
                    If DG2.Item(0, cn).Value = frmzoom7.VrNo Then
                        DG2.Item(0, cn).Selected = True
                        GoTo en
                    End If
                Next
en:
            ElseIf frmnewzoom4.zoom1 = True Then
                Dim cn As Integer
                For cn = 0 To DG2.Rows.Count - 1
                    If DG2.Item(0, cn).Value = frmnewzoom4.VrNo Then
                        DG2.Item(0, cn).Selected = True
                        GoTo en
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        Try
            If e.KeyChar >= "0" And e.KeyChar <= "9" = False Then
                If e.KeyChar = "." = False Then
                    e.Handled = True
                End If
            Else
                dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex).Value = "0.00"
                dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = "DR"
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        Try
            If e.KeyChar >= "0" And e.KeyChar <= "9" = False Then
                If e.KeyChar = "." = False Then
                    e.Handled = True
                End If
            Else
                dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex).Value = "0.00"
                dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = "CR"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            If i <> 0 Then
                If e.ColumnIndex = 1 Then
                    one(TextBox8)
                ElseIf e.ColumnIndex = 2 Then
                    one(TextBox4)
                ElseIf e.ColumnIndex = 4 Then
                    one(TextBox5)
                ElseIf e.ColumnIndex = 5 Then
                    one(TextBox6)
                ElseIf e.ColumnIndex = 6 Then
                    one(TextBox7)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox4_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LocationChanged, TextBox5.LocationChanged, TextBox6.LocationChanged, TextBox7.LocationChanged, TextBox8.LocationChanged
        TextBox4.Top = sender.top
        TextBox5.Top = sender.top
        TextBox6.Top = sender.top
        TextBox7.Top = sender.top
        TextBox8.Top = sender.top

    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles maskdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVrnoSec.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVrnoSec.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg1.Rows.Add()
            dg1.Item(0, 0).Value = 1
            dg1.Item(1, 0).Selected = True
            TextBox8.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox8.Text.ToUpper = "DR" Or TextBox8.Text.ToUpper = "CR" Then
            Else
                MsgBox("Select DR or CR")
                TextBox8.Focus()
                GoTo en

            End If
            dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = TextBox8.Text.ToUpper
            dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Selected = True
            TextBox4.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If TextBox8.Text.ToUpper = "DR" Or TextBox8.Text.ToUpper = "CR" Then
            Else
                MsgBox("Select DR or CR")
                TextBox8.Focus()
                GoTo en

            End If

            dg1.CurrentCell.Value = TextBox8.Text
            dg1.Item(1, dg1.CurrentCell.RowIndex + 1).Selected = True
        ElseIf e.KeyCode = Keys.Up Then
            If 0 <= dg1.SelectedCells.Item(0).RowIndex - 1 Then
                If TextBox8.Text.ToUpper = "DR" Or TextBox8.Text.ToUpper = "CR" Then
                Else
                    MsgBox("Select DR or CR")
                    TextBox8.Focus()
                    GoTo en
                End If
                dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex - 1).Selected = True
            Else
            End If
        ElseIf e.KeyCode = Keys.Right Then
            If TextBox8.SelectionStart = TextBox8.Text.Length Or TextBox8.Text.Length = 0 Then
                If TextBox8.Text.ToUpper = "DR" Or TextBox8.Text.ToUpper = "CR" Then
                Else
                    MsgBox("Select DR or CR")
                    TextBox8.Focus()
                    GoTo en
                End If
                dg1.CurrentCell.Value = TextBox8.Text
                dg1.Item(2, dg1.CurrentCell.RowIndex).Selected = True
                TextBox8.SendToBack()
                dg1.Focus()
                TextBox4.Focus()
            End If
en:
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgacm.Rows.Count = 0 Then
                    If MsgBox("Account not exists you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        jourac = 1
                        frmACMaster.Show()
                        Me.Hide()
                        GoTo en
                    Else
                        GoTo en
                    End If
                End If
                TextBox4.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Value = TextBox4.Text
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", TextBox4.Text, "ACName")
                If dr.HasRows Then
                    While dr.Read
                        dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value = dr.Item("ACCode")
                    End While
                    dr.Close()
                    If dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = "DR" Then
                        dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex).Value = 0.0
                        dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                        TextBox5.Focus()
                    End If
                    If dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = "CR" Then
                        dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex).Value = 0.0
                        dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                        TextBox6.Focus()
                    End If
                    dgacm.Visible = False
                Else
                    dr.Close()
                    MsgBox("Account does not exists")
                    dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                End If


            ElseIf e.KeyCode = Keys.Down Then
                If dgacm.Rows.Count = 0 Then
                Else
                    dgacm.Focus()
                    dgacm.Item(0, 1).Selected = True
                End If

                '    If DataGridView1.Rows.Count - 1 >= DataGridView1.SelectedCells.Item(0).RowIndex + 1 Then
                'DataGridView1.Item(2, DataGridView1.SelectedCells.Item(0).RowIndex + 1).Selected = True
                ' Else
                ' End If

            ElseIf e.KeyCode = Keys.Up Then
                If 0 <= dg1.SelectedCells.Item(0).RowIndex - 1 Then
                    dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex - 1).Selected = True
                Else

                End If
            ElseIf e.KeyCode = Keys.Right Then
                If TextBox4.SelectionStart = TextBox4.Text.Length Or TextBox4.Text.Length = 0 Then
                    dg1.CurrentCell.Value = TextBox4.Text
                    dg1.Item(4, dg1.CurrentCell.RowIndex).Selected = True
                    TextBox4.SendToBack()
                    dg1.Focus()
                    TextBox5.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If TextBox4.SelectionStart = 0 Or TextBox4.Text.Length = 0 Then
                    dg1.CurrentCell.Value = TextBox4.Text
                    dg1.Item(1, dg1.CurrentCell.RowIndex).Selected = True
                    dg1.Focus()
                    TextBox8.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex).Value = TextBox5.Text
                If dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = "CR" Then
                    dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                    TextBox6.Focus()
                Else
                    dg1.Item(6, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                    TextBox7.Focus()
                End If
            ElseIf e.KeyCode = Keys.Down Then
                If dg1.Rows.Count - 1 >= dg1.SelectedCells.Item(0).RowIndex + 1 Then
                    dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex + 1).Selected = True
                Else

                End If
            ElseIf e.KeyCode = Keys.Up Then
                If 0 <= dg1.SelectedCells.Item(0).RowIndex - 1 Then
                    dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex - 1).Selected = True
                Else

                End If
            ElseIf e.KeyCode = Keys.Right Then
                If TextBox5.SelectionStart = TextBox5.Text.Length Or TextBox5.Text.Length = 0 Then
                    dg1.CurrentCell.Value = TextBox5.Text
                    dg1.Item(5, dg1.CurrentCell.RowIndex).Selected = True
                    TextBox5.SendToBack()
                    dg1.Focus()
                    TextBox6.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If TextBox5.SelectionStart = 0 Or TextBox5.Text.Length = 0 Then
                    dg1.CurrentCell.Value = TextBox5.Text
                    dg1.Item(3, dg1.CurrentCell.RowIndex).Selected = True
                    dg1.Focus()
                End If
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex).Value = TextBox6.Text
                dg1.Item(6, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                TextBox7.Focus()
            ElseIf e.KeyCode = Keys.Down Then
                If dg1.Rows.Count - 1 >= dg1.SelectedCells.Item(0).RowIndex + 1 Then
                    dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex + 1).Selected = True
                Else

                End If
            ElseIf e.KeyCode = Keys.Up Then
                If 0 <= dg1.SelectedCells.Item(0).RowIndex - 1 Then
                    dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex - 1).Selected = True
                Else

                End If
            ElseIf e.KeyCode = Keys.Right Then
                If TextBox6.SelectionStart = TextBox6.Text.Length Or TextBox6.Text.Length = 0 Then
                    dg1.CurrentCell.Value = TextBox6.Text
                    dg1.Item(6, dg1.CurrentCell.RowIndex).Selected = True
                    TextBox6.SendToBack()
                    dg1.Focus()
                    'TextBox7.Focus()
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If TextBox6.SelectionStart = 0 Or TextBox6.Text.Length = 0 Then
                    dg1.CurrentCell.Value = TextBox6.Text
                    dg1.Item(4, dg1.CurrentCell.RowIndex).Selected = True
                    dg1.Focus()
                    TextBox5.Focus()
                End If

            End If
        Catch ex As Exception
            '    MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg1.Item(6, dg1.SelectedCells.Item(0).RowIndex).Value = TextBox7.Text
            If dg1.Rows.Count < dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value + 1 Then
                dg1.Rows.Add()
            End If
            TextBox9.Text = countDr()
            TextBox10.Text = countCr()
            If countDr() > countCr() Then
                dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex + 1).Value = "CR"
                dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex + 1).Value = countDr() - countCr()
            ElseIf countDr() < countCr() Then
                dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex + 1).Value = "DR"
                dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex + 1).Value = countCr() - countDr()
            Else
                MsgBox("completed")
                ButSave.Enabled = True
                ButSave.Focus()
                GoTo en
            End If
            dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex + 1).Value = dg1.Item(0, dg1.SelectedCells.Item(0).RowIndex).Value + 1
            dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex + 1).Selected = True
            TextBox8.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If dg1.Rows.Count - 1 >= dg1.SelectedCells.Item(0).RowIndex + 1 Then
                dg1.Item(6, dg1.SelectedCells.Item(0).RowIndex + 1).Selected = True
            Else

            End If
        ElseIf e.KeyCode = Keys.Up Then
            If 0 <= dg1.SelectedCells.Item(0).RowIndex - 1 Then
                dg1.Item(6, dg1.SelectedCells.Item(0).RowIndex - 1).Selected = True
            Else

            End If
        ElseIf e.KeyCode = Keys.Left Then
            If TextBox7.SelectionStart = 0 Or TextBox7.Text.Length = 0 Then
                dg1.CurrentCell.Value = TextBox7.Text
                dg1.Item(5, dg1.CurrentCell.RowIndex).Selected = True
                dg1.Focus()
                TextBox6.Focus()
            End If

        End If
en:
    End Sub
    Private Function countDr() As Integer
        Dim amt As Integer = 0
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            amt = amt + dg1.Item(4, i).Value
        Next
        Return amt
    End Function
    Private Function countCr() As Integer
        Dim amt As Integer = 0
        Dim i As Integer
        For i = 0 To dg1.Rows.Count - 1
            amt = amt + dg1.Item(5, i).Value
        Next
        Return amt
    End Function
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        Try
            If txtType.Text = "Main" Then
                '  MsgBox("WRONG ENTRY")
                '  GoTo en
            End If
            If countCr() <> countDr() Then
                MsgBox("Cr & Dr Not equal")
                GoTo en
            End If
            If editcheck = 1 Then
                connect()
                Dim cmdchecka As New SqlCommand
                Dim drcheck As SqlDataReader
                cmdchecka = New SqlCommand("select * from tblJour where VrNo='" & txtvrnofirst.Text & txtVrnoSec.Text & "'", cn)
                drcheck = cmdchecka.ExecuteReader
                If drcheck.HasRows Then
                    drcheck.Close()
                    MsgBox("Duplicate VrNo")
                    GoTo en
                Else
                    drcheck.Close()

                End If
                close1()

                Dim i As Integer
                Dim dat1 As New Date
                dat1 = maskdate.Text.ToString
                For i = 0 To dg1.Rows.Count - 1
                    TextBox12.Text = ""
                    Try
                        If (dg1.Item(1, i).Value).ToString.Length <> 0 Then
                            Dim a() As String = {txtvrnofirst.Text & txtVrnoSec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dg1.Item(0, i).Value, dg1.Item(1, i).Value, dg1.Item(2, i).Value, dg1.Item(3, i).Value, dg1.Item(4, i).Value, dg1.Item(5, i).Value, dg1.Item(6, i).Value, "Main"}
                            myinsert(a, "tblJour")
                        Else
                            GoTo N
                        End If

                    Catch ex As Exception
                        GoTo N
                    End Try
                  



                    If dg1.Item(1, i).Value = "DR" Then
                        Dim k As Integer
                        For k = 0 To dg1.RowCount - 2
                            If dg1.Item(1, k).Value = "CR" Then
                                TextBox12.Text = TextBox12.Text & dg1.Item(2, k).Value & vbNewLine
                            End If
                        Next
                    End If
                    If dg1.Item(1, i).Value = "CR" Then
                        Dim k As Integer
                        For k = 0 To dg1.RowCount - 2
                            If dg1.Item(1, k).Value = "DR" Then
                                TextBox12.Text = TextBox12.Text & dg1.Item(2, k).Value & vbNewLine
                            End If
                        Next
                    End If

                    Dim b() As String = {txtvrnofirst.Text & txtVrnoSec.Text, "Jour", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dg1.Item(3, i).Value, dg1.Item(2, i).Value, dg1.Item(4, i).Value, dg1.Item(5, i).Value, Val(dg1.Item(5, i).Value) - Val(dg1.Item(4, i).Value), dg1.Item(6, i).Value, TextBox12.Text, " ", 0}
                    myinsert(b, "tblLedg")
                Next
N:
                connect()
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("select VrNo,Sum(dr) as Amount from tbljour group by vrno order by convert(int,substring(vrno,4,len(vrno)-3))", cn)
                da.Fill(ds)
                DG2.DataSource = ds.Tables(0)
                DG2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                close1()
                '    MsgBox("inserted")
                Label6.Text = "SAVED"
                Timer1.Enabled = True
                dg1.Rows.Clear()
                Try
                    DG2.Item(0, DG2.RowCount - 1).Selected = True
                    DG2.Rows(DG2.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try

                DG2.Focus()
                maskdate.Focus()
            ElseIf editcheck = 2 Then
                Dim cmd As New SqlCommand
                connect()
                cmd = New SqlCommand("Delete from tblJour where VrNo='" & txtvrnofirst.Text & txtVrnoSec.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtvrnofirst.Text & txtVrnoSec.Text & "' and Book='Jour'", cn)
                cmd.ExecuteNonQuery()
                Dim i As Integer
                Dim dat1 As New Date
                dat1 = maskdate.Text.ToString
                For i = 0 To dg1.Rows.Count - 2
                    Dim a() As String = {txtvrnofirst.Text & txtVrnoSec.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dg1.Item(0, i).Value, dg1.Item(1, i).Value, dg1.Item(2, i).Value, dg1.Item(3, i).Value, dg1.Item(4, i).Value, dg1.Item(5, i).Value, dg1.Item(6, i).Value, "Main"}
                    myinsert(a, "tblJour")
                    Dim b() As String = {txtvrnofirst.Text & txtVrnoSec.Text, "Jour", dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dg1.Item(3, i).Value, dg1.Item(2, i).Value, dg1.Item(4, i).Value, dg1.Item(5, i).Value, Val(dg1.Item(5, i).Value) - Val(dg1.Item(4, i).Value), dg1.Item(6, i).Value, " ", " ", 0}
                    myinsert(b, "tblLedg")
                Next
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("select VrNo,Sum(dr) as Amount from tbljour group by vrno order by convert(int,substring(vrno,4,len(vrno)-3))", cn)
                da.Fill(ds)
                DG2.DataSource = ds.Tables(0)
                Try
                    DG2.Item(0, DG2.Rows.Count - 1).Selected = True
                Catch ex As Exception

                End Try

                DG2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                close1()
                '  MsgBox("edited")
                Label6.Text = "EDITED"
                Timer1.Enabled = True
            End If
            Label6.Visible = True
            TextBox4.SendToBack()
            TextBox5.SendToBack()
            TextBox6.SendToBack()
            TextBox7.SendToBack()
            TextBox8.SendToBack()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        maxVrNo(txtVrnoSec, "tblJour")
        maskdate.Focus()
        editcheck = 1
        dg1.Rows.Clear()
        TextBox4.SendToBack()
        TextBox5.SendToBack()
        TextBox6.SendToBack()
        TextBox7.SendToBack()
        TextBox8.SendToBack()
        txtType.Clear()
        ButSave.Enabled = True
        maskdate.Text = Format(Date.Today, "dd-MM-yyyy")
        maskdate.SelectionStart = 0
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG2.RowEnter
        Try

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ds As New DataSet
            connect()
            cmd = New SqlCommand("Select * from tblJour where VrNo='" & DG2.Item(0, e.RowIndex).Value & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            dg1.Rows.Clear()
            TextBox4.SendToBack()
            TextBox5.SendToBack()
            TextBox6.SendToBack()
            TextBox7.SendToBack()
            TextBox8.SendToBack()
            While dr.Read
                txtvrnofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                txtVrnoSec.Text = dr.Item("VrNo").ToString.Substring(3)
                dg1.Rows.Add()
                dg1.Item(0, i).Value = i + 1
                dg1.Item(1, i).Value = dr.Item("AmtType")
                dg1.Item(2, i).Value = dr.Item("ACName")
                dg1.Item(3, i).Value = dr.Item("ACCode")
                dg1.Item(4, i).Value = dr.Item("Dr")
                dg1.Item(5, i).Value = dr.Item("Cr")
                dg1.Item(6, i).Value = dr.Item("Remark")
                maskdate.Text = Format((dr.Item("Date")), "dd-MM-yyyy")
                txtType.Text = dr.Item("Type")
                i = i + 1
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        If txtType.Text <> "Main" Then
            MsgBox("THIS IS AUTOMATIC GENERATED ENTRY CAN NOT EDIT FROM HERE")
            GoTo LAST
        End If
        ButSave.Enabled = True
        butDelete.Enabled = True
        Try
            editcheck = 2
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ds As New DataSet
            connect()
            cmd = New SqlCommand("Select * from tblJour where VrNo='" & DG2.Item(0, DG2.SelectedCells.Item(0).RowIndex).Value & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            dg1.Rows.Clear()
            TextBox4.SendToBack()
            TextBox5.SendToBack()
            TextBox6.SendToBack()
            TextBox7.SendToBack()
            TextBox8.SendToBack()
            While dr.Read
                txtvrnofirst.Text = dr.Item("vrno").ToString.Substring(0, 3)
                txtVrnoSec.Text = dr.Item("VrNo").ToString.Substring(3)
                dg1.Rows.Add()
                dg1.Item(0, i).Value = i + 1
                dg1.Item(1, i).Value = dr.Item("AmtType")
                dg1.Item(2, i).Value = dr.Item("ACName")
                dg1.Item(3, i).Value = dr.Item("ACCode")
                dg1.Item(4, i).Value = dr.Item("Dr")
                dg1.Item(5, i).Value = dr.Item("Cr")
                dg1.Item(6, i).Value = dr.Item("Remark")
                maskdate.Text = Format(dr.Item("Date"), "dd-MM-yyyy")
                i = i + 1
            End While
            dr.Close()
            close1()
            maskdate.Focus()
            maskdate.SelectionStart = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
LAST:

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Dim cmd As New SqlCommand
        connect()
        If MsgBox("You want to delete the entry of VrNo " & txtvrnofirst.Text & txtVrnoSec.Text & " ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cmd = New SqlCommand("Delete from tblJour where VrNo='" & txtvrnofirst.Text & txtVrnoSec.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Delete from tblLedg where VrNo='" & txtvrnofirst.Text & txtVrnoSec.Text & "' and Book='Jour'", cn)
            cmd.ExecuteNonQuery()
            close1()
            dg1.Rows.Clear()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select VrNo,Sum(dr) as Amount from tblJour group by VrNo", cn)
            da.Fill(ds)
            DG2.DataSource = ds.Tables(0)
            Try
                DG2.Item(0, DG2.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try
            close1()
        Else
        End If
    End Sub
    Public Sub CLEARALL()

    End Sub

    Private Sub DataGridView1_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellLeave
        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
            dg1.Item(e.ColumnIndex, e.RowIndex).Value = Convert.ToDecimal(dg1.Item(e.ColumnIndex, e.RowIndex).Value)
        End If
    End Sub
    Private Sub dgacm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox4.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
            dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Value = TextBox4.Text
            Dim dr As SqlDataReader
            dr = myconselect("tblAccount", TextBox4.Text, "ACName")
            If dr.HasRows Then
                While dr.Read
                    dg1.Item(3, dg1.SelectedCells.Item(0).RowIndex).Value = dr.Item("ACCode")
                End While
                dr.Close()
                If dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = "DR" Then
                    dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex).Value = 0.0
                    dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                    TextBox5.Focus()
                End If
                If dg1.Item(1, dg1.SelectedCells.Item(0).RowIndex).Value = "CR" Then
                    dg1.Item(4, dg1.SelectedCells.Item(0).RowIndex).Value = 0.0
                    dg1.Item(5, dg1.SelectedCells.Item(0).RowIndex).Selected = True
                    TextBox6.Focus()
                End If
                dgacm.Visible = False
            Else
                dr.Close()
                MsgBox("Account does not exists")
                dg1.Item(2, dg1.SelectedCells.Item(0).RowIndex).Selected = True
            End If

            dgacm.Visible = False
        End If
    End Sub
    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyUp
        Try
            '   myAutoComplete(TextBox4, ListBox1, "tblAccount", "ACName")
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
                dgacm.BringToFront()
                dgacm.Top = sender.Top + 22
                ' dgacm.Left = sender.Left
                dgacm.AutoResizeColumns()
                close1()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        '  ListBox1.Visible = False
    End Sub

    Private Sub ListBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        dgacm.BringToFront()
        dgacm.Visible = True
    End Sub

   
    Private Sub ListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '   ListBox1.SendToBack()
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick
    End Sub
    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.RowEnter
    End Sub
    Private Sub TextBox8_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.Leave
    
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 20
        If timercount > 1000 Then
            timercount = 0
            Timer1.Enabled = False
            Label6.Visible = False
        End If
    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyUp, TextBox6.KeyUp
        If Val(sender.Text) > 999999999999.999 Then
            MsgBox("Not valid figure")
            sender.Focus()
        End If
    End Sub
End Class