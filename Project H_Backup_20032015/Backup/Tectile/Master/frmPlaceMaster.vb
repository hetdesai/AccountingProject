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
    Private Sub cmdFind_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFind.Click
        frmPlaceFind.Show()
    End Sub
    Private Sub cmdAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
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
    Private Sub cmdEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEdit.Click
        check = 2
        Label5.Text = "Edit Mode"
        Dim i As DataGridViewSelectedCellCollection
        i = DG1.SelectedCells
        txtPcode.Text = DG1.Item(0, i.Item(0).RowIndex).Value
        txtPlace.Text = DG1.Item(1, i.Item(0).RowIndex).Value
        GroupBox1.Enabled = True
        txtPlace.Focus()

    End Sub
    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
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
                myfilldatagrid(DG1, "tblPlace")
                DG1.Item(0, DG1.RowCount - 1).Selected = True
                DG1.Refresh()
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
                myupdate("tblPlace", a, "PLCode", txtPcode.Text)
                Dim rowi As Integer
                Dim coli As Integer
                Dim i As DataGridViewSelectedCellCollection
                i = DG1.SelectedCells
                rowi = i.Item(0).RowIndex
                coli = i.Item(0).ColumnIndex
                myfilldatagrid(DG1, "tblPlace")
                Timer1.Enabled = True
                Label2.Text = "UPDATED"
                DG1.Item(coli, rowi).Selected = True
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
            GroupBox1.Enabled = True

        Catch ex As Exception

        End Try


    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlace.KeyDown
        If e.KeyCode = Keys.Enter Then
            butSave.Focus()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
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
End Class