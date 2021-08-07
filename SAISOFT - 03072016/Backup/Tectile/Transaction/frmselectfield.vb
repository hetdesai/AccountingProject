Imports System.Data.SqlClient
Public Class frmselectfield
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            connect()
            da = New SqlDataAdapter("select * from " & ComboBox1.Text, cn)
            da.Fill(ds)
            Dim i As Integer
            CheckedListBox1.Items.Clear()
            For i = 0 To ds.Tables(0).Columns.Count - 1
                CheckedListBox1.Items.Add(ds.Tables(0).Columns(i).ColumnName)
            Next
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim sql As String = ""
            cmd = New SqlCommand("select fields from tblselectfield where tablename='" & ComboBox1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                sql = dr.Item(0)
            End While
            dr.Close()
            Dim a() As String
            a = sql.Split(",")
            Dim k As Integer
            For k = 0 To a.Length - 1
                For i = 0 To CheckedListBox1.Items.Count - 1
                    If CheckedListBox1.Items(i).ToString = a(k).ToString Then
                        CheckedListBox1.SetItemChecked(i, True)
                    End If
                Next
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim sql As String = ""
            Dim i As Integer
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                sql = sql & CheckedListBox1.CheckedItems(i).ToString & ","
            Next
            cmd = New SqlCommand("delete from tblselectfield where tablename='" & ComboBox1.Text & "'", cn)
            cmd.ExecuteNonQuery()
            Dim a() As String = {ComboBox1.Text, sql}
            myinsert(a, "tblselectfield")
            MsgBox("SAVED")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmselectfield_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
    End Sub
End Class