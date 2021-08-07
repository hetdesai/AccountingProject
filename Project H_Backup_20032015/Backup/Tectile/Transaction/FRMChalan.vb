Imports System.Data.SqlClient
Public Class FRMChalan
    Dim editcheck As Integer
    Dim editcheck2 As Integer
    Dim tbcheck As Integer
    Public newac As Integer = 0
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim tv As String = ""
    Public chno As String = ""
    Private Sub FRMChalan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        gridfill()
        Try
            connect()
            Dim dr As SqlDataReader
            dr = myconselect("tblaccount", "Sales", "book")
            While dr.Read
                ComboBox1.Items.Add(dr.Item("acname"))
            End While
            dr.Close()
            close1()

        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If MsgBox("Are you sure you want to delete this entry", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                connect()
                Dim cmd As New SqlCommand("delete from ch1 where vrno='" & TextBox1.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from ch2 where vrno='" & TextBox1.Text & "'", cn)
                cmd.ExecuteNonQuery()
                MsgBox("Deleted")
                gridfill()
                close1()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


        End If
    End Sub

   
    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        Try

            If e.KeyCode = Keys.Down Then
                tbcheck = 1
                dgacm.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                TextBox2.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", TextBox2.Text, "ACName")
                While dr.Read
                    TextBox6.Text = dr.Item("ACCode")
                End While
                dr.Close()
                If TextBox2.Text = "" Then
                    If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        newac = 2
                        frmACMaster.Show()
                    Else
                        TextBox2.Focus()
                    End If
                End If
                TextBox3.Focus()
                dgacm.Visible = False
            ElseIf e.KeyCode = Keys.Up Then
                ' TextBox10.Focus()
            End If
        Catch ex As Exception
            If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                newac = 2
                frmACMaster.Show()
                Me.Hide()
            Else
                TextBox12.Focus()
            End If

        End Try
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp, TextBox3.KeyUp
        Try
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter(acm(sender.text), cn)
            da.Fill(ds)
            dgacm.Visible = True
            dgacm.DataSource = ds.Tables(0)
            dgacm.BringToFront()
            dgacm.AutoResizeColumns()
            '  dgacm.Top = sender.Top + 22
            '  dgacm.Left = sender.Left
            close1()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        Try

            If e.KeyCode = Keys.Down Then
                tbcheck = 2
                dgacm.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                TextBox3.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", TextBox3.Text, "ACName")
                While dr.Read
                    TextBox7.Text = dr.Item("ACCode")
                End While
                dr.Close()
                If TextBox3.Text = "" Then
                    If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        newac = 3
                        frmACMaster.Show()
                    Else
                        TextBox3.Focus()
                    End If
                End If
                TextBox15.Focus()
                '  TextBox5.Focus()
                dgacm.Visible = False
            ElseIf e.KeyCode = Keys.Up Then
                ' TextBox10.Focus()
            End If
        Catch ex As Exception
            If MsgBox("You want to create a new Account", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                newac = 3
                frmACMaster.Show()
                Me.Hide()
            Else
                TextBox3.Focus()
            End If

        End Try
    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp

    End Sub

    Private Sub dgacm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgacm.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tbcheck = 1 Then
                TextBox2.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", TextBox2.Text, "ACName")
                While dr.Read
                    TextBox6.Text = dr.Item("ACCode")
                End While
                TextBox3.Focus()
                dgacm.Visible = False
            End If
            If tbcheck = 2 Then
                TextBox3.Text = dgacm.Item(1, dgacm.SelectedCells.Item(0).RowIndex).Value
                Dim dr As SqlDataReader
                dr = myconselect("tblAccount", TextBox3.Text, "ACName")
                While dr.Read
                    TextBox7.Text = dr.Item("ACCode")
                End While
                dgacm.Visible = False
                TextBox5.Focus()
            End If
        End If
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
    Private Sub TextBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        Dim dr As SqlDataReader
        dr = myconselect("tblAccount", TextBox2.Text, "ACName")
        While dr.Read
            TextBox6.Text = dr.Item("ACCode")
        End While
        dr.Close()
    End Sub

    Private Sub TextBox3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        Dim dr As SqlDataReader
        dr = myconselect("tblAccount", TextBox3.Text, "ACName")
        While dr.Read
            TextBox7.Text = dr.Item("ACCode")
        End While
        dr.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        editcheck = 1
        editcheck2 = 0
        ComboBox1.Focus()
        dg1.Rows.Clear()
        maxVrNo(TextBox1, "ch1")
        connect()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select distinct workorderno from ch1", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            TextBox4.AutoCompleteCustomSource.Add(dr.Item(0))
        End While
        dr.Close()
        close1()
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If editcheck = 1 Then
                    connect()
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader
                    cmd = New SqlCommand("Select chno from ch1 where chno='" & TextBox5.Text & "'", cn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        MsgBox("Duplicate chalan no")
                        TextBox5.Focus()
                        dr.Close()
                    Else
                        TextBox4.Focus()
                        dr.Close()
                    End If
                    close1()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.Leave

    End Sub

    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        Try
            If editcheck = 1 Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select chno from ch1 where chno='" & TextBox5.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    MsgBox("Duplicate chalan no")
                    TextBox5.Focus()
                    dr.Close()
                Else
                    TextBox4.Focus()
                    dr.Close()
                End If
                close1()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox1.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave
        Try
            Dim dat As DateTime
            Dim dat1 As DateTime
            Dim dat2 As DateTime
            dat1 = dateyf.ToString
            dat2 = dateyl.ToString
            dat = MaskedTextBox1.Text.ToString
            If DateDiff(DateInterval.Day, dat1, dat) >= 0 And DateDiff(DateInterval.Day, dat2, dat) <= 0 Then
                Button1.Focus()
            Else
                MsgBox("Please enter date in current year")
                MaskedTextBox1.Focus()
            End If
        Catch ex As Exception
            MsgBox("enter proper date")
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox8.Focus()
        editcheck2 = 0
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try
                    TextBox8.Text = dgitem.Item(1, dgacm.CurrentCell.RowIndex).Value
                    dgitem.Visible = False
                    TextBox9.Focus()
                Catch ex As Exception

                End Try
            ElseIf e.KeyCode = Keys.Down Then
                dgitem.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter
        dgacm.Visible = False
    End Sub

    Private Sub TextBox8_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyUp
        Try
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            connect()
            da = New SqlDataAdapter("Select * from tblItem where itname like '" & TextBox8.Text & "%'", cn)
            da.Fill(ds)
            dgitem.Visible = True
            dgitem.DataSource = ds.Tables(0)
            dgitem.BringToFront()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub dgitem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgitem.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                TextBox8.Text = dgitem.Item(1, dgitem.CurrentCell.RowIndex).Value
                dgitem.Visible = False
                TextBox9.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox9_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox10.Focus()
        End If
    End Sub
    Private Sub TextBox10_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox10.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox11.Focus()
        End If
    End Sub
    Private Sub TextBox11_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox11.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox12.Focus()
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If editcheck2 = 0 Then
            dg1.Rows.Add()
            dg1.Item(0, dg1.RowCount - 1).Value = TextBox8.Text
            dg1.Item(2, dg1.RowCount - 1).Value = TextBox9.Text
            dg1.Item(3, dg1.RowCount - 1).Value = TextBox10.Text
            dg1.Item(4, dg1.RowCount - 1).Value = TextBox11.Text
            dg1.Item(5, dg1.RowCount - 1).Value = TextBox12.Text
            connect()
            Dim dr As SqlDataReader
            dr = myconselect("tblitem", TextBox8.Text, "Itname")
            While dr.Read
                dg1.Item(1, dg1.RowCount - 1).Value = dr.Item("itcode")
                dg1.Item(6, dg1.RowCount - 1).Value = dr.Item("itunit")
            End While
            dr.Close()
            close1()
            TextBox8.Focus()
        ElseIf editcheck2 = 1 Then
            dg1.Item(0, dg1.CurrentCell.RowIndex).Value = TextBox8.Text
            dg1.Item(2, dg1.CurrentCell.RowIndex).Value = TextBox9.Text
            dg1.Item(3, dg1.CurrentCell.RowIndex).Value = TextBox10.Text
            dg1.Item(4, dg1.CurrentCell.RowIndex).Value = TextBox11.Text
            dg1.Item(5, dg1.CurrentCell.RowIndex).Value = TextBox12.Text
            connect()
            Dim dr As SqlDataReader
            dr = myconselect("tblitem", TextBox8.Text, "Itname")
            While dr.Read
                dg1.Item(1, dg1.CurrentCell.RowIndex - 1).Value = dr.Item("itcode")
                dg1.Item(6, dg1.CurrentCell.RowIndex - 1).Value = dr.Item("itunit")
            End While
            dr.Close()
            close1()
            TextBox8.Focus()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        editcheck = 2
        editcheck2 = 1
        Try
            Dim dr As SqlDataReader
            Dim vrno As String
            dr = myconselect("ch1", dg2.Item(0, dg2.CurrentCell.RowIndex).Value, "vrno")
            While dr.Read
                TextBox1.Text = dr.Item(0)
                TextBox2.Text = dr.Item(1)
                TextBox6.Text = dr.Item(2)
                TextBox3.Text = dr.Item(3)
                TextBox7.Text = dr.Item(4)
                TextBox4.Text = dr.Item(5)
                TextBox15.Text = dr.Item(6)
                MaskedTextBox1.Text = Format(dr.Item(7), "dd-MM-yyyy")
                TextBox5.Text = dr.Item(8)
                ComboBox1.Text = dr.Item(9)
                TextBox14.Text = dr.Item(10)
            End While
            dr.Close()
            dr = myconselect("ch2", dg2.Item(0, dg2.CurrentCell.RowIndex).Value, "vrno")
            dg1.Rows.Clear()
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, dg1.RowCount - 1).Value = dr.Item(1)
                dg1.Item(1, dg1.RowCount - 1).Value = dr.Item(2)
                dg1.Item(2, dg1.RowCount - 1).Value = dr.Item(3)
                dg1.Item(3, dg1.RowCount - 1).Value = dr.Item(4)
                dg1.Item(4, dg1.RowCount - 1).Value = dr.Item(5)
                dg1.Item(5, dg1.RowCount - 1).Value = dr.Item(6)
                dg1.Item(6, dg1.RowCount - 1).Value = dr.Item(7)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        editcheck2 = 1
        Try
            TextBox8.Text = dg1.Item(0, dg1.CurrentCell.RowIndex).Value
            TextBox9.Text = dg1.Item(2, dg1.CurrentCell.RowIndex).Value
            TextBox10.Text = dg1.Item(3, dg1.CurrentCell.RowIndex).Value
            TextBox11.Text = dg1.Item(4, dg1.CurrentCell.RowIndex).Value
            TextBox12.Text = dg1.Item(5, dg1.CurrentCell.RowIndex).Value
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TextBox8.Text.Trim.Length <> 0 Then
                dg1.Rows.RemoveAt(dg1.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            MsgBox("Select proper row")
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            connect()
            Dim cmd As New SqlCommand("delete from ch1 where vrno='" & TextBox1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("delete from ch2 where vrno='" & TextBox1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            Dim dat As New Date
            dat = MaskedTextBox1.Text.ToString
            Dim a() As String = {TextBox1.Text, TextBox2.Text, TextBox6.Text, TextBox3.Text, TextBox7.Text, TextBox4.Text, TextBox15.Text, dat.Month & "-" & dat.Day & "-" & dat.Year, TextBox5.Text, ComboBox1.Text, TextBox14.Text}
            myinsert(a, "ch1")
            Dim i As Integer
            For i = 0 To dg1.RowCount - 1
                Dim b() As String = {TextBox1.Text, dg1.Item(0, i).Value, dg1.Item(1, i).Value, dg1.Item(2, i).Value, dg1.Item(3, i).Value, dg1.Item(4, i).Value, dg1.Item(5, i).Value, dg1.Item(6, i).Value}
                myinsert(b, "ch2")
            Next
            MsgBox("Inserted")
            gridfill()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub TextBox10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus
        Format((TextBox10.Text), "0.00")
    End Sub
    Private Sub TextBox11_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        Format(Val(TextBox11.Text), "0.00")
    End Sub
    Private Sub TextBox12_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.LostFocus
        Format(Val(sender.text), "0.000")
    End Sub
    Private Sub TextBox12_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox12.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button10.Focus()
        End If
    End Sub
    Private Sub gridfill()
        Try
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select * from ch1", cn)
            da.Fill(ds)
            dg2.DataSource = ds.Tables(0)
            close1()
            Try
                dg2.Item(0, dg2.RowCount - 1).Selected = True
                dg2.Visible = True
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        gridfill()
        dg2.BringToFront()
        dg2.Width = 950
        dg2.Height = 700
        dg2.Left = 0
        dg2.Top = 10
        GroupBox4.Visible = True
        TextBox13.Focus()
        tv = ""
    End Sub

    Private Sub dg2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellEnter
        Try
            Dim dr As SqlDataReader
            Dim vrno As String
            dr = myconselect("ch1", dg2.Item(0, e.RowIndex).Value, "vrno")
            While dr.Read
                TextBox1.Text = dr.Item(0)
                TextBox2.Text = dr.Item(1)
                TextBox6.Text = dr.Item(2)
                TextBox3.Text = dr.Item(3)
                TextBox7.Text = dr.Item(4)
                TextBox4.Text = dr.Item(5)
                TextBox15.Text = dr.Item(6)
                MaskedTextBox1.Text = Format(dr.Item(7), "dd-MM-yyyy")
                TextBox5.Text = dr.Item(8)
                ComboBox1.Text = dr.Item(9)
                TextBox14.Text = dr.Item(10)
            End While
            dr.Close()
            dr = myconselect("ch2", dg2.Item(0, e.RowIndex).Value, "vrno")
            dg1.Rows.Clear()
            While dr.Read
                dg1.Rows.Add()
                dg1.Item(0, dg1.RowCount - 1).Value = dr.Item(1)
                dg1.Item(1, dg1.RowCount - 1).Value = dr.Item(2)
                dg1.Item(2, dg1.RowCount - 1).Value = dr.Item(3)
                dg1.Item(3, dg1.RowCount - 1).Value = dr.Item(4)
                dg1.Item(4, dg1.RowCount - 1).Value = dr.Item(5)
                dg1.Item(5, dg1.RowCount - 1).Value = dr.Item(6)
                dg1.Item(6, dg1.RowCount - 1).Value = dr.Item(7)
            End While
            dr.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dg1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
      
        
    End Sub

    Private Sub TextBox13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox13.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button12.Focus()
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox13.Text = tv) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv = TextBox13.Text
        For i = temp1 To dg2.Rows.Count - 1
            For j = temp2 To dg2.ColumnCount - 1
                ' MsgBox(frmMHMaster.DG1.Item(j, i).Value.ToString.ToLower.ToString)

                If (dg2.Item(j, i).Value.ToString.ToLower.ToString.Contains(TextBox13.Text.ToLower)) Then
                    dg2.Item(j, i).Selected = True
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

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        GroupBox4.Visible = False
    End Sub

    Private Sub GroupBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox4.LostFocus
        GroupBox4.Visible = False
    End Sub

    Private Sub dg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dg2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg2.Visible = False
        End If
    End Sub

    Private Sub FRMChalan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            gridfill()
            dg2.Height = 900
            dg2.Visible = True
            dg2.BringToFront()
            dg2.Width = 950
            dg2.Height = 700

            dgacm.Visible = False
            dgitem.Visible = False
            dgacm.AutoResizeColumns()
            dg2.Left = 0
            dg2.Top = 10
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        If ComboBox1.Items.Contains(ComboBox1.Text) = False Then
            MsgBox("Select from list")
            ComboBox1.Focus()
        Else

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            connect()
            Dim dr As SqlDataReader
            dr = myconselect("tblAccount", ComboBox1.Text, "acname")
            While dr.Read
                TextBox14.Text = dr.Item("accode")
            End While
            dr.Close()
            close1()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dg2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellContentClick

    End Sub

    Private Sub GroupBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Leave
        dgitem.Visible = False
    End Sub

    Private Sub TextBox15_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox15.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox5.Focus()
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        chno = TextBox5.Text
        frmchalandis.Show()
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub
End Class