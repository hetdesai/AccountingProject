Imports System.Data.SqlClient
Public Class rptledggrid
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Public datfrom As New Date
    Public datto As New Date
    Public Acname As String
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub rptledggrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim dat As New Date
            dat = MaskedTextBox1.Text.ToString
            connect()
            cmd = New SqlCommand("Select ACCode,ACName,Sum(Dr) as Dr,Sum(Cr) As Cr from tblLedg where Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' group By ACCode,ACName", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim a() As String = {"A", "OPE", dat.Month & "-" & dat.Day & "-" & dat.Year, dr.Item("ACCode").ToString, dr.Item("ACName").ToString, dr.Item("Dr").ToString, dr.Item("Cr").ToString, "A", "A", "A", "0"}
                myinsert(a, "templedg")
            End While
            dr.Close()
            da = New SqlDataAdapter("Select ACName,ACCode,Sum(Dr) as DR,Sum(Cr) As Cr,Sum(Cr)-Sum(Dr) as balance from tblLedg where date > '" & dat.Month & "-" & dat.Day & "-" & dat.Year & "'group by ACName,ACCode", cn)
            da.Fill(ds, "tblLedg1")
            '      rpt.SetDataSource(ds)
            '     CrystalReportViewer1.ReportSource = rpt
            DataGridView1.DataSource = ds.Tables(0)
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            zoomfrom = "Ledger"
            datfrom = MaskedTextBox1.Text.ToString
            datto = MaskedTextBox2.Text.ToString
            Acname = DataGridView1.Item(0, DataGridView1.SelectedCells.Item(0).RowIndex).Value
            frmzoomMonth.Show()
        End If
    End Sub
End Class