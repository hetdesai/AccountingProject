Imports System.Data.SqlClient
Public Class frmPlaceMaster
    Dim check As Integer
    Dim timercount As Integer
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim dr As SqlDataReader
    Dim CLOSECHECK As Integer = 0
    Private Sub cmdExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
    Private Sub cmdFind_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click, Button1.Click
        frmPlaceFind.Show()
    End Sub
    Private Sub cmdAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click, Button4.Click
        Try
            check = 1
            Label5.Text = "ADD Mode"
            txtPcode.Clear()
            txtPlace.Clear()
            GroupBox1.Enabled = True
            myserialno("tblPlace", txtPcode, "PLCode")
            txtPlace.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click, Button2.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = dg1.SelectedCells
        txtPcode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
        txtPlace.Text = dg1.Item(1, i.Item(0).RowIndex).Value
        TextBox1.Text = txtPlace.Text
        GroupBox1.Enabled = True
        txtPlace.Focus()

    End Sub
   

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click, Button3.Click
        Try
            If txtPlace.Text.Trim.Length = 0 Then
                MsgBox("Place can not be blank")
                txtPlace.Focus()
                GoTo en
            End If
            If check = 1 Then
                Dim a() As String = {txtPcode.Text, txtPlace.Text}
                If duplicate("tblPlace", "PLName", txtPlace) Then
                    MsgBox("Mhead already exists")
                    txtPlace.Focus()
                    GoTo en
                Else
                End If
                myinsert(a, "tblPlace")
                myfilldatagrid(dg1, "tblPlace")
                dg1.Item(0, dg1.RowCount - 1).Selected = True
                dg1.Refresh()
                Timer1.Enabled = True
                Label2.Text = "SAVED"
                If frmACMaster.plcheck = 1 Then
                    frmACMaster.txtPlace.Text = txtPlace.Text
                    frmACMaster.listState.Visible = False
                    frmACMaster.Show()
                    frmACMaster.txtPlace.Focus()
                    frmACMaster.txtPin.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                ElseIf frmBrokerMaster.bplcheck = 1 Then
                    frmBrokerMaster.TextBox4.Text = txtPlace.Text
                    frmBrokerMaster.ListBox1.Visible = False
                    frmBrokerMaster.Show()
                    frmBrokerMaster.TextBox4.Focus()
                    frmBrokerMaster.Button3.Focus()
                    CLOSECHECK = 0
                    Me.Close()
                Else
                    txtPcode.Clear()
                    txtPlace.Clear()
                    myserialno("tblPlace", txtPcode, "PLCode")
                    txtPlace.Focus()
                End If

            ElseIf check = 2 Then
                Dim a() As String = {txtPcode.Text, txtPlace.Text}
                If (duplicate("tblPlace", "PLName", txtPlace)) = True Then
                    MsgBox("Record already exists")
                    txtPlace.Focus()
                    GoTo en
                End If
                Try
                    connect()
                    Dim cmd As New SqlCommand
                    cmd = New SqlCommand("Update tblAccount set place='" & txtPlace.Text & "' where place='" & TextBox1.Text & "'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                Catch ex As Exception

                End Try
              
                myupdate("tblPlace", a, "PLCode", txtPcode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = dg1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(dg1, "tblPlace")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                dg1.Item(coli, rowi).Selected = True
                txtPlace.Focus()
            End If
en:
        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub


    Private Sub DG1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DG1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellEnter
        Try
            Dim i As DataGridViewSelectedCellCollection
            i = dg1.SelectedCells
            txtPcode.Text = dg1.Item(0, i.Item(0).RowIndex).Value
            txtPlace.Text = dg1.Item(1, i.Item(0).RowIndex).Value
            TextBox1.Text = txtPlace.Text
            GroupBox1.Enabled = True

        Catch ex As Exception

        End Try


    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlace.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPcode.GotFocus, txtPlace.GotFocus
        Try
            sender.BackColor = Color.Yellow
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPcode.LostFocus, txtPlace.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmPlaceMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If CLOSECHECK = 1 Then
            If frmACMaster.plcheck = 1 Then
                frmACMaster.listState.Visible = False
                frmACMaster.Show()
                frmACMaster.txtPlace.Focus()
            ElseIf frmBrokerMaster.bplcheck = 1 Then
                frmBrokerMaster.ListBox1.Visible = False
                frmBrokerMaster.Show()
                frmBrokerMaster.TextBox4.Focus()
            End If
        End If
    End Sub
    Private Sub frmPlaceMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmPlaceMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagridcolor(dg1)
        Try
            companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = dateyf
            dateyl1.Text = dateyl

            '  If check = 1 Then
            If frmACMaster.plcheck = 1 Or frmBrokerMaster.bplcheck = 1 Then
                butAdd.Enabled = False
                butFind.Enabled = False
                butEdit.Enabled = False
                dg1.Enabled = False
                check = 1
                Label5.Text = "ADD Mode"
                txtPcode.Clear()
                txtPlace.Clear()
                GroupBox1.Enabled = True
                myserialno("tblPlace", txtPcode, "PLCode")
                txtPlace.Focus()
                CLOSECHECK = 1
            Else
                connect()
                myfilldatagrid(dg1, "tblPlace")
                Try
                    dg1.Item(0, dg1.RowCount - 1).Selected = True
                Catch ex As Exception
                    '     MsgBox("File Empty")
                End Try

                butAdd.Focus()

            End If
            'ElseIf check = 2 Then
            ' End If
        Catch ex As Exception
            MsgBox(ex.ToString)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click, Button5.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblaccount where place='" & txtPlace.Text & "'", cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("This place name is assign for account you can not delete it")
                dr.Close()
                GoTo en
            Else
                dr.Close()
                cmd = New SqlCommand("delete from tblplace where plname='" & txtPlace.Text & "'", cn)
                cmd.ExecuteNonQuery()
                MsgBox("successfully deleted")
            End If
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("select * from tblPlace", cn)
            da.Fill(ds)
            dg1.DataSource = ds.Tables(0)
            Try
                dg1.Item(0, dg1.RowCount - 1).Selected = True
            Catch ex As Exception

            End Try
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
en:
        close1()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butPrint.Click
        frmprintplace.Show()
    End Sub

    Private Sub Button4_Enter(sender As Object, e As EventArgs) Handles cmdExit.Enter, Button5.Enter, Button4.Enter, Button3.Enter, Button2.Enter, Button1.Enter
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub Button4_Leave(sender As Object, e As EventArgs) Handles cmdExit.Leave, Button5.Leave, Button4.Leave, Button3.Leave, Button2.Leave, Button1.Leave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub

    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles cmdExit.MouseHover, Button5.MouseHover, Button4.MouseHover, Button3.MouseHover, Button2.MouseHover, Button1.MouseHover
        sender.backcolor = Color.Blue
        sender.forecolor = Color.White
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles cmdExit.MouseLeave, Button5.MouseLeave, Button4.MouseLeave, Button3.MouseLeave, Button2.MouseLeave, Button1.MouseLeave
        sender.backcolor = Color.FromArgb(192, 192, 255)
        sender.forecolor = Color.Black
    End Sub
End Class