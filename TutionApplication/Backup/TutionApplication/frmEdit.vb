Imports System.Data.OleDb
Public Class frmEdit
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
    Dim da As New OleDbDataAdapter
    Dim dr As OleDbDataReader
    Public ID As Integer
    Public mode As Integer '1 for Edit 2 for Delete

    Private Sub frmEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Edit"
        Connect()
        da = New OleDbDataAdapter("Select * from tblStudentInfo,tblParentsInfo where tblStudentInfo.ID = tblParentsInfo.ID", cn)
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Close1()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmSearch.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As DataGridViewSelectedCellCollection
        i = DataGridView1.SelectedCells
        ID = DataGridView1.Item(0, i.Item(0).RowIndex).Value
        mode = 1
        Me.Hide()
        frmEdit2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As DataGridViewSelectedCellCollection
        i = DataGridView1.SelectedCells
        ID = DataGridView1.Item(0, i.Item(0).RowIndex).Value
        mode = 2
        frmEdit2.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim i As DataGridViewSelectedCellCollection
            i = DataGridView1.SelectedCells
            ID = DataGridView1.Item(0, i.Item(0).RowIndex).Value
            mode = 1
            Me.Hide()
            frmEdit2.Show()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class