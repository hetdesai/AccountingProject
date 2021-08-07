Imports System.Data.SqlClient
Imports OnBarcode.Barcode
Imports System.IO

Public Class frmitEM3
    Dim check As Integer
    Dim tv1 As String
    Dim temp1 As Integer
    Dim temp2 As Integer
    Public ITCHECK As Integer = 0
    Private Sub frmit2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub printbarcode()
        Dim barcode As OnBarcode.Barcode.Linear
        barcode = New OnBarcode.Barcode.Linear()
        barcode.Type = BarcodeType.CODE128
        barcode.Data = TextBox4.Text
        barcode.X = 1
        barcode.Y = 60
        barcode.drawBarcode(Application.StartupPath & "//barcode//" & TextBox2.Text & ".png")
    End Sub
    Private Sub frmit2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        Dim da As New SqlDataAdapter
        Dim ds As New DataSet
        da = New SqlDataAdapter("select * from tblIt2 where code like 'SST%'", cn)
        da.Fill(ds)
        dg1.DataSource = ds.Tables(0)
        Try
            dg1.Item(0, dg1.RowCount - 1).Selected = True
        Catch ex As Exception

        End Try
        close1()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox4.Clear()
        TextBox1.Focus()
        TextBox2.Text = 1.0
        TextBox3.Text = 0.0
        TextBox6.Text = 0.0
        Label6.Text = "ADD"
        TextBox3.Clear()
        ' TextBox4.ReadOnly = False
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        connect()
        cmd = New SqlCommand("select * from tblit2 where code like 'SST%' order by srno", cn)
        dr = cmd.ExecuteReader
        Dim max As Integer = 0
        While dr.Read
            If max < Val(dr.Item(0).ToString.Substring(3)) Then
                max = Val(dr.Item(0).ToString.Substring(3))
            End If
        End While
        TextBox4.Text = "SST" & (max + 1)
        Try
            TextBox4.SelectionStart = 0
            TextBox4.SelectionLength = TextBox4.Text.Length

        Catch ex As Exception
            TextBox4.Text = ""
        End Try
        dr.Close()
        close1()

        ' myserialno("tblIt2", TextBox4, "code")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            TextBox4.ReadOnly = True
            TextBox3.Focus()
            TextBox1.Text = dg1.Item(1, dg1.CurrentCell.RowIndex).Value
            TextBox2.Text = dg1.Item(2, dg1.CurrentCell.RowIndex).Value
            TextBox3.Text = dg1.Item(3, dg1.CurrentCell.RowIndex).Value
            TextBox4.Text = dg1.Item(0, dg1.CurrentCell.RowIndex).Value
            TextBox5.Text = dg1.Item(4, dg1.CurrentCell.RowIndex).Value
            TextBox6.Text = dg1.Item(5, dg1.CurrentCell.RowIndex).Value
            Label6.Text = "EDIT"
            'TextBox1.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dg1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellContentClick

    End Sub

    Private Sub dg1_cellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            TextBox1.Text = dg1.Item(1, dg1.CurrentCell.RowIndex).Value
            TextBox2.Text = dg1.Item(2, dg1.CurrentCell.RowIndex).Value
            TextBox3.Text = dg1.Item(3, dg1.CurrentCell.RowIndex).Value
            TextBox4.Text = dg1.Item(0, dg1.CurrentCell.RowIndex).Value
            TextBox5.Text = dg1.Item(4, dg1.CurrentCell.RowIndex).Value
            TextBox6.Text = dg1.Item(5, dg1.CurrentCell.RowIndex).Value

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If Val(TextBox3.Text) < 1 Or TextBox3.Text.Length = 0 Then
                MsgBox("Rate is not proper")
                TextBox3.Focus()
                GoTo en
            End If
            If Val(TextBox6.Text) < 1 Or TextBox6.Text.Length = 0 Then
                MsgBox("MRP is not proper")
                TextBox6.Focus()
                GoTo en
            End If
            If Val(TextBox2.Text) < 1 Or TextBox2.Text.Length = 0 Then
                MsgBox("PCS is not proper")
                TextBox2.Focus()
                GoTo en
            End If
            If Label6.Text = "ADD" Then
                connect()
                Try
                    If TextBox4.Text.StartsWith("SST") Then
                        printbarcode()
                    Else

                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    GoTo en
                End Try
                connect()
                Dim CMD As New SqlCommand
                Dim DR As SqlDataReader
                CMD = New SqlCommand("SELECT * FROM TBLIT2 WHERE CODE='" & TextBox4.Text & "'", cn)
                DR = CMD.ExecuteReader
                If DR.HasRows = True Then
                    DR.Close()
                    MsgBox("ALREADY INSERTED ITEM")
                    GoTo en
                Else
                    DR.Close()
                End If
                close1()
                Dim a() As String = {TextBox4.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text}
                myinsert(a, "tblit2")
                Dim lFSFileStream As FileStream
                Dim lBRBinaryReader As BinaryReader
                Dim lBImageByte As Byte()
                If TextBox4.Text.StartsWith("SST") Then
                    lFSFileStream = New FileStream(Application.StartupPath & "//barcode//" & TextBox2.Text & ".png", FileMode.Open)
                    '  lFSFileStream = New FileStream(Application.StartupPath & "//barcode//" & "EMPTY" & ".png", FileMode.Open)
                Else
                    lFSFileStream = New FileStream(Application.StartupPath & "//barcode//" & "EMPTY" & ".png", FileMode.Open)
                End If
                lBRBinaryReader = New BinaryReader(lFSFileStream)
                lBImageByte = New Byte(lFSFileStream.Length + 1) {}
                lBImageByte = lBRBinaryReader.ReadBytes(Convert.ToInt32(lFSFileStream.Length))
                connect()
                '  Dim cmd As New SqlCommand
                CMD = New SqlCommand("insert into tblBarcode values(@itcode,@barcode1)", cn)
                CMD.Parameters.AddWithValue("@itcode", TextBox4.Text)
                CMD.Parameters.AddWithValue("@barcode1", lBImageByte)
                CMD.ExecuteNonQuery()
                close1()
                ' dt.Item(0) = lBImageByte
                'ds.Tables("tblLogo").Rows.Add(dt)
                lFSFileStream.Close()
                MsgBox("Inserted")
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("select * from tblIt2 where code like 'SST%' order by srno", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                Try
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try
                TextBox4.Focus()
                TextBox1.Focus()
                TextBox2.Text = 1.0
                TextBox3.Text = 0.0
                TextBox6.Text = 0.0
                Label6.Text = "ADD"
                TextBox3.Clear()
                '    TextBox4.ReadOnly = False
                '    Dim cmd As New SqlCommand
                '   Dim dr As SqlDataReader
                connect()
                CMD = New SqlCommand("select * from tblit2 where code like 'SST%'", cn)
                DR = CMD.ExecuteReader
                Dim max As Integer = 0
                While DR.Read
                    If max < Val(DR.Item(0).ToString.Substring(3)) Then
                        max = Val(DR.Item(0).ToString.Substring(3))
                    End If
                End While
                TextBox4.Text = "SST" & (max + 1)
                Try
                    TextBox4.SelectionStart = 0
                    TextBox4.SelectionLength = TextBox4.Text.Length

                Catch ex As Exception
                    TextBox4.Text = ""
                End Try
                DR.Close()
                close1()
                close1()
            ElseIf Label6.Text = "EDIT" Then
                connect()
                Dim a() As String = {TextBox4.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox5.Text, TextBox6.Text}
                myupdate("tblit2", a, "code", TextBox4.Text)
                Dim da As New SqlDataAdapter
                Dim ds As New DataSet
                da = New SqlDataAdapter("select * from tblIt2 where code like 'SST%'", cn)
                da.Fill(ds)
                dg1.DataSource = ds.Tables(0)
                Try
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                Catch ex As Exception

                End Try
                MsgBox("Inserted")
                close1()
            End If

en:
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        myAutoComplete(TextBox1, ListBox1, "tblitem", "itname")
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave

    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ListBox1.Visible = False
            TextBox1.Text = ListBox1.SelectedItem.ToString
            TextBox5.Focus()
        End If
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub gotfocus2(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus, TextBox6.GotFocus
        Try
            sender.selectionstart = 0
            sender.selectionlength = sender.text.length
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus, TextBox6.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                If ListBox1.Items.Count <> 0 Then
                    TextBox5.Focus()
                    TextBox1.Text = ListBox1.Items(0).ToString
                    ListBox1.Visible = False
                Else

                    If MsgBox("ARE YOU WANT TO ADD NEW ITEM", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ITCHECK = 1
                        frmITMaster.Show()
                    End If
                End If

            ElseIf e.KeyCode = Keys.Down Then
                ListBox1.Focus()
                ListBox1.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.Up Then
                TextBox4.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox6.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            TextBox5.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        onlyNumbers(sender, e)
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        onlyNumbers(sender, e)

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        onlyNumbers(sender, e)
    End Sub
    Private Sub TextBox5_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox2.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            '     TextBox3.Focus()
            Button3.Focus()
        ElseIf e.KeyCode = Keys.Up Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Label6.Text.ToUpper = "ADD" Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("select * from tblit2 where code='" & TextBox4.Text & "'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    MsgBox("Item Already inserted")
                    dr.Close()
                    GoTo last
                Else
                    dr.Close()
                    TextBox1.Focus()
                End If
                close1()


            End If

        End If
last:
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        GroupBox2.Visible = True
        TextBox7.Focus()
        tv1 = ""
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        GroupBox2.Visible = False
        Button1.Focus()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim i, j As Integer
        i = 0
        j = 0
        If (TextBox1.Text = tv1) Then
        Else
            temp1 = 0
            temp2 = 0
        End If
        tv1 = TextBox1.Text
        For i = temp1 To dg1.Rows.Count - 1
            For j = temp2 To dg1.ColumnCount - 1
                If (dg1.Item(j, i).Value.ToString.ToLower.Contains(TextBox7.Text.ToLower.ToString)) Then
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

    Private Sub TextBox7_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button6.Focus()
        End If
    End Sub
End Class