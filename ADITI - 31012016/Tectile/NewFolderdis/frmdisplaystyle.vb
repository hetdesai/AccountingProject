Imports System.Data.SqlClient
Public Class frmdisplaystyle
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.Masterbkcolor = Me.BackColor
        My.Settings.labelcolor = Label2.ForeColor
        My.Settings.labelfont = Label2.Font
        My.Settings.contbackColor = Me.GroupBox1.BackColor
        My.Settings.Comcolor = Panel1.BackColor
        My.Settings.Titlecolor = Label1.ForeColor
        My.Settings.titlefont = Label1.Font
        My.Settings.Save()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
            My.Settings.Masterbkcolor = Me.BackColor
        End If
    End Sub

    Private Sub frmdisplaystyle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmdisplaystyle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        da = New SqlDataAdapter("Select * from tblMH", cn)
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        close1()
        If frmMainScreen.discolor = "System" Then
            '      Me.BackColor = Color.FromKnownColor(KnownColor.Control)
            '     Label2.ForeColor = Color.Black
            '    Label3.ForeColor = Color.Black
            '   Label4.ForeColor = Color.Black
            '  Label2.Font = New Font("Microsoft sans scrif", 10, FontStyle.Regular)
            '       Label3.Font = New Font("Microsoft sans scrif", 10, FontStyle.Regular)
            '      Label4.Font = New Font("Microsoft sans scrif", 10, FontStyle.Regular)
            '     Panel1.BackColor = Color.DarkBlue
            '    dateyf1.Font = (New Font("Microsoft sans scrif", 10, FontStyle.Regular))
            '   dateyl1.Font = New Font("Microsoft sans scrif", 10, FontStyle.Regular)
            '  companyname1.Font = New Font("Microsoft sans scrif", 10, FontStyle.Regular)
            '       dateyf1.ForeColor = Color.White
            '      dateyl1.ForeColor = Color.White
            '     companyname1.ForeColor = Color.White
            '    GroupBox1.BackColor = Color.FromKnownColor(KnownColor.Control)
            '   DataGridView1.DefaultCellStyle.BackColor = Color.White
            '  DataGridView1.DefaultCellStyle.ForeColor = Color.Black
            ' Label1.ForeColor = Color.Red
            '     Label1.Font = New Font("Microsoft sans scrif", 12, FontStyle.Bold)
            '    Panel1.BackColor = Color.DarkBlue
        End If
        DataGridView1.DefaultCellStyle.ForeColor = My.Settings.gridforecolor
        DataGridView1.DefaultCellStyle.BackColor = My.Settings.gridbackcolor
        Me.Panel1.BackColor = My.Settings.Comcolor
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Panel1.BackColor = ColorDialog1.Color
            My.Settings.Comcolor = Me.Panel1.BackColor
        End If
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Label1.ForeColor = ColorDialog1.Color
            My.Settings.Titlecolor = (Me.Label1.ForeColor)
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label1.Font = (FontDialog1.Font)
            My.Settings.titlefont = Label1.Font
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.GroupBox1.BackColor = ColorDialog1.Color
            My.Settings.contbackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label2.ForeColor = ColorDialog1.Color
            Label3.ForeColor = ColorDialog1.Color
            Label4.ForeColor = ColorDialog1.Color
            My.Settings.labelcolor = ColorDialog1.Color
        End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Label2.Font = FontDialog1.Font
            Label3.Font = FontDialog1.Font
            Label4.Font = FontDialog1.Font
            My.Settings.labelfont = Label2.Font
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DataGridView1.DefaultCellStyle.BackColor = ColorDialog1.Color
            My.Settings.gridbackcolor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            DataGridView1.DefaultCellStyle.ForeColor = ColorDialog1.Color
            My.Settings.gridforecolor = ColorDialog1.Color
        End If
    End Sub
End Class