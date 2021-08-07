Imports System.Data.SqlClient
Public Class frmClearAll

    Private Sub frmClearAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select Table_Name from INFORMATION_SCHEMA.tables order by table_name", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            CheckedListBox1.Items.Remove("tblAccount")
            CheckedListBox1.Items.Remove("tblSetup")
            CheckedListBox1.Items.Remove("tblMH")
            CheckedListBox1.Items.Remove("tblSH")
            CheckedListBox1.Items.Remove("TaxMst")
            CheckedListBox1.Items.Remove("AujvMst")
            CheckedListBox1.Items.Remove("tblUserPass")
            CheckedListBox1.Items.Remove("tblselectfield")
            CheckedListBox1.Items.Remove("sysdiagrams")
            CheckedListBox1.Items.Remove("tblCompany")
            CheckedListBox1.Items.Remove("Table")

            close1()
            Dim i As Integer
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MessageBox.Show("Do you want to delete all selected tables", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If MsgBox("This is the final warning. Are you want to delete all the selected tables", vbYesNo) = Windows.Forms.DialogResult.Yes Then
                    connect()
                    Dim cmd As New SqlCommand
                    Dim i As Integer
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        cmd = New SqlCommand("Delete from " & CheckedListBox1.CheckedItems(i), cn)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show(CheckedListBox1.CheckedItems(i) & "Table Deleted")
                    Next
                    cmd = New SqlCommand("Delete from tblAccount where schedule like '%SUNDRY%'", cn)
                    cmd.ExecuteNonQuery()
                    close1()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class