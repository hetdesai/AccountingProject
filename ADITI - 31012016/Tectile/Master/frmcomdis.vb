Imports System.Data.SqlClient
Public Class frmcomdis
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim companycon As New SqlConnection
    Public mode As Integer
    Public code As Integer
    Public CompanyName As String
    Public companycode As Integer
    Public ShortName As String
    Public state As String
    Public logo As String
    Public reportheader1 As String
    Public reportheader2 As String
    Public add1 As String
    Public add2 As String
    Public add3 As String
    Public City As String
    Public pincode As String
    Public phone1 As String
    Public phone2 As String
    Public phone3 As String
    Public fax As String
    Public website As String
    Public tin As String
    Public cst As String
    Public pan As String
    Public tan As String
    Public ecc As String
    Public Servicetax As String
    Public juricity As String
    Public termscondition As String
    Public addtp As Integer

    Private Sub frmcomdis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmcomdis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "Company Select"
            companycon = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30")
            '  companycon = New SqlConnection("Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=D:\WORK\ADITI\TECTILE\BIN\DEBUG\Companydatabase.MDF;User ID=sa;Password=Password123")
            companycon.Open()
            da = New SqlDataAdapter("Select * from tblCompany", companycon)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            '  DataGridView1.AutoResizeColumn(0)
            DataGridView1.Columns(0).Width = 300
            DataGridView1.Columns(0).HeaderText = "Company"
            DataGridView1.Columns(1).HeaderText = ""
            DataGridView1.Columns(2).Width = 300
            DataGridView1.Columns(2).Width = 300
            DataGridView1.Columns(3).Width = 300
            DataGridView1.Columns(4).Width = 300
            companycon.Close()
            Try
                DataGridView1.Item(0, DataGridView1.Rows.Count - 1).Selected = True
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        mode = 1
        Panel1.Visible = True
        Panel1.Focus()
        '   frmCommaster.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        mode = 2
        code = DataGridView1.Item(DataGridView1.ColumnCount - 1, DataGridView1.SelectedCells.Item(0).RowIndex).Value
        frmCommaster.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        mode = 3
        If MsgBox("Are you sure want to delete company", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As New SqlCommand
            companycon = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30")
            '  companycon = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            '   companycon = New SqlConnection("Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=D:\WORK\ADITI\TECTILE\BIN\DEBUG\Companydatabase.MDF;User ID=sa;Password=Password123")
            companycon.Open()
            cmd = New SqlCommand("Delete from tblCompany where ComCode=" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value, companycon)
            cmd.ExecuteNonQuery()
            If System.IO.File.Exists(Application.StartupPath & "\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "NewDB.mdf") = True Then
                System.IO.File.Delete(Application.StartupPath & "\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "NewDB.mdf")
            End If
            If System.IO.File.Exists(Application.StartupPath & "\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "NewDB_log.mdf") = True Then
                System.IO.File.Delete(Application.StartupPath & "\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "NewDB_log.mdf")
            End If

            If System.IO.File.Exists(Application.StartupPath & "\Images\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value) = True Then
                System.IO.File.Delete(Application.StartupPath & "\Images\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value)
            End If
        End If
        'frmCommaster.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                companycon = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30")
                '  companycon = New SqlConnection("Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=D:\WORK\ADITI\TECTILE\BIN\DEBUG\Companydatabase.MDF;User ID=sa;Password=Password123")
                companycon.Open()
                code = DataGridView1.Item(1, DataGridView1.SelectedCells.Item(0).RowIndex).Value
                comname = DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex).Value
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select * from tblCompany where ComCode=" & Me.code, companycon)
                dr = cmd.ExecuteReader
                While dr.Read
                    CompanyName = dr.Item(0)
                    companycode = dr.Item(1)
                    ShortName = dr.Item(4)
                    state = dr.Item(5)
                    logo = Application.StartupPath & "\Images\" & dr.Item(6)
                    reportheader1 = dr.Item(7)
                    reportheader2 = dr.Item(8)
                    add1 = dr.Item(9)
                    add2 = dr.Item(10)
                    add3 = dr.Item(11)
                    City = dr.Item(12)
                    pincode = dr.Item(13)
                    phone1 = dr.Item(14)
                    phone2 = dr.Item(15)
                    phone3 = dr.Item(16)
                    fax = dr.Item(17)
                    website = dr.Item(18)
                    tin = dr.Item(19)
                    cst = dr.Item(20)
                    pan = dr.Item(21)
                    tan = dr.Item(22)
                    ecc = dr.Item(23)
                    Servicetax = dr.Item(24)
                    juricity = dr.Item(25)
                    termscondition = dr.Item(26)

                    MaskedTextBox1.Text = dr.Item(2)
                    MaskedTextBox2.Text = dr.Item(3)
                    dateyf = MaskedTextBox1.Text
                    dateyl = MaskedTextBox2.Text
                End While
                dr.Close()
                'Me.Hide()
                frmMainScreen.Close()
                frmlogin.Show()
                ' frmMainScreen.Show()
                companycon.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Try
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            If System.IO.File.Exists(Application.StartupPath & "\backup\" & Date.Today & "&" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & ".mdf") Then
                System.IO.File.Delete(Application.StartupPath & "\backup\" & Date.Today & "&" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & ".mdf")
            End If
            If System.IO.File.Exists(Application.StartupPath & "\backup\" & Date.Today & "&" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "_log.ldf") Then
                System.IO.File.Delete(Application.StartupPath & "\backup\" & Date.Today & "&" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "_log.ldf")
            End If
            System.IO.File.Copy(Application.StartupPath & "\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "NewDb.mdf", Application.StartupPath & "\backup\" & Date.Today & "&" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & ".mdf")
            System.IO.File.Copy(Application.StartupPath & "\" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "NewDb_log.ldf", Application.StartupPath & "\backup\" & Date.Today & "&" & DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex).Value & "_log.ldf")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

   

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If RadioButton1.Checked = True Then
            addtp = 1
        Else
            addtp = 2
            frmCommaster.ComboBox1.Visible = True
        End If
        frmCommaster.WindowState = FormWindowState.Normal
        frmCommaster.Show()
    End Sub
End Class