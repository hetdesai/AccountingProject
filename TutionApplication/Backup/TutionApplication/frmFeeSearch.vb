Imports System.Data.OleDb
Public Class frmFeeSearch
    Dim cmd As New OleDbCommand
    Dim ds As New DataSet
    Dim da As New OleDbDataAdapter
    Dim dr As OleDbDataReader
    Public ID1 As Integer

    Private Sub frmFeeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Student Search"
        Connect()
        da = New OleDbDataAdapter("Select * from tblStudentInfo,tblParentsInfo where tblStudentInfo.ID = tblParentsInfo.ID", cn)
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Close1()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As DataGridViewSelectedCellCollection
        i = DataGridView1.SelectedCells
        ID1 = DataGridView1.Item(0, i.Item(0).RowIndex).Value
        Me.Hide()
        frmFee.Close()
        frmFee.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim i As DataGridViewSelectedCellCollection
            i = DataGridView1.SelectedCells
            ID1 = DataGridView1.Item(0, i.Item(0).RowIndex).Value
            Me.Hide()
            frmFee.Close()
            frmFee.Show()
        End If
    End Sub
End Class