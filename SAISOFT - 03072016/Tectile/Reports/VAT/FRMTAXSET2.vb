Imports System.Data.SqlClient
Public Class FRMTAXSET2

    Private Sub FRMTAXSET2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FRMTAXSET2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Dim DS As New DataSet
        Dim DA As New SqlDataAdapter
        DA = New SqlDataAdapter("SELECT DISTINCT TAXNARA FROM saltax", cn)
        DA.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
        Dim COL As New DataGridViewTextBoxColumn
        COL.HeaderText = "TYPE"
        COL.Name = "TYPE"
        DataGridView1.Columns.Add(COL)
        Dim COL1 As New DataGridViewTextBoxColumn
        COL1.HeaderText = "Alphabet"
        COL1.Name = "alph"
        DataGridView1.Columns.Add(COL1)
        Dim i As Integer
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        connect()
        For i = 0 To DataGridView1.RowCount - 1
            cmd = New SqlCommand("select type from tax1 where taxnara='" & DataGridView1.Item(0, i).Value & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Item(1, i).Value = dr.Item(0)
            End While
            dr.Close()
        Next
        For i = 0 To DataGridView1.RowCount - 1
            cmd = New SqlCommand("select alpha from tax1 where taxnara='" & DataGridView1.Item(0, i).Value & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Item(2, i).Value = dr.Item(0)
            End While
            dr.Close()
        Next
        close1()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        connect()
        Dim cmd As New SqlCommand
        cmd = New SqlCommand("delete from tax1", cn)
        cmd.ExecuteNonQuery()
        close1()
        Dim i As Integer
        connect()
        For i = 0 To DataGridView1.RowCount - 1
            Dim a() As String = {DataGridView1.Item(0, i).Value, DataGridView1.Item(1, i).Value, DataGridView1.Item(2, i).Value}
            myinsert(a, "tax1")
        Next
        close1()
        MsgBox("saved")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class