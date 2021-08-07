Imports System.Data.SqlClient
Public Class frmBrokerMaster
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Public bplcheck As Integer = 0
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        frmBrokerFind.Show()

    End Sub
    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            TextBox1.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            TextBox2.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            TextBox3.Text = dg1.Item(2, i.Item(0).RowIndex).Value
            TextBox4.Text = dg1.Item(3, i.Item(0).RowIndex).Value
        Catch ex As Exception
            ' MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timercount = timercount + 1
        If timercount > 10 Then
            timercount = 0
            Timer1.Enabled = False
            Label2.Text = ""
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TextBox2.Text.Trim.Length = 0 Then
                MsgBox("Broker can not be blank")
                TextBox2.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text}
                If duplicate("tblBroker", "Broker", TextBox2) Then
                    MsgBox("Broker already exists")
                    TextBox2.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblBroker")
                myfilldatagrid(DG1, "tblBroker")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                myserialno("tblBroker", TextBox1, "BRCode")
                TextBox2.Focus()
            ElseIf check = 2 Then
                Dim a() As String = {TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text}
                If (duplicate("tblBroker", "Broker", TextBox2)) = True Then
                    MsgBox("Record already exists")
                    TextBox2.Focus()
                    GoTo en
                End If
                myupdate("tblBroker", a, "BRCode", TextBox1.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblBroker")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
                TextBox2.Focus()
            End If
en:
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmBrokerMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            '     SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub frmBrokerMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            '  If check = 1 Then
            connect()
            '    myfillCustome(TextBox4, "tblPlace", "PLName")
            myfilldatagrid(DG1, "tblBroker")
            DG1.Item(0, DG1.RowCount - 1).Selected = True
            cmdAdd.Focus()
            'ElseIf check = 2 Then
            ' End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            myserialno("tblBroker", TextBox1, "BRCode")
            GroupBox1.Enabled = True
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        frmMHfind.Close()
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        TextBox1.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        TextBox2.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        TextBox3.Text = DG1.Item(2, i.Item(0).RowIndex).Value
        TextBox4.Text = DG1.Item(3, i.Item(0).RowIndex).Value
        GroupBox1.Enabled = True
        TextBox2.Focus()
    End Sub

    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox1.Items.Count <> 0 Then
                TextBox4.Text = ListBox1.Items(0).ToString
                ListBox1.Visible = False
            Else
                If MsgBox("Place not exits you want to create new", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    bplcheck = 1
                    Me.Hide()
                    frmPlaceMaster.Show()
                Else
                    TextBox4.Focus()

                End If
            End If
        ElseIf e.KeyCode = Keys.Down Then
            ListBox1.Focus()
            ListBox1.SelectedIndex = 0
            '    Button3.Focus()
        End If
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        Me.KeyPreview = False
        If e.KeyCode = Keys.Enter Then
            TextBox4.Text = ListBox1.SelectedItem.ToString
            ListBox1.Visible = False
            Me.KeyPreview = True
            Button3.Focus()

        End If
    End Sub
    Private Sub TextBox4_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyUp
        myAutoComplete(TextBox4, ListBox1, "tblPlace", "PLName")
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBox4.Focus()
        End If
    End Sub
End Class