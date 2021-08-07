Imports System.Data.SqlClient
Public Class frmRateMaserEdit
    Dim da As New SqlDataAdapter
    Dim temp1 As Integer
    Dim temp2 As Integer
    Dim tv1 As String

    Dim ds As New DataSet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            connect()
            Dim cmb As New SqlCommandBuilder(da)
            da.Update(ds, "ratemst")
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
         End Sub

    Private Sub frmRateMaserEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim group As String = ""
        Dim Name As String = ""
        Dim mst As String = ""

        With frmratemasterselection
            Dim i As Integer
            '   MessageBox.Show(frmlotselection.CustomeChecklistbox1.CheckedItemsCount)
            If .CustomeChecklistbox1.CheckedItemsCount = 0 Then
                For i = 0 To .CustomeChecklistbox1.ItemsCount - 1
                    group = group & "pgroup='" & .CustomeChecklistbox1.getItems(i).ToString & "' or "

                Next
            Else
                For i = 0 To .CustomeChecklistbox1.CheckedItemsCount - 1
                    group = group & "pgroup='" & .CustomeChecklistbox1.getCheckedItems(i).ToString & "' or "
                Next

            End If
            ' MessageBox.Show(group)
            group = group.Substring(0, group.Length - 4)
            '  MessageBox.Show(group)
            If .CustomeChecklistbox2.CheckedItemsCount = 0 Then
                For i = 0 To .CustomeChecklistbox2.ItemsCount - 1
                    Name = Name & "acname='" & .CustomeChecklistbox2.getItems(i).ToString & "' or "
                Next
            Else
                For i = 0 To .CustomeChecklistbox2.CheckedItemsCount - 1
                    Name = Name & "acname='" & .CustomeChecklistbox2.getCheckedItems(i).ToString & "' or "
                Next
            End If
            Name = Name.Substring(0, Name.Length - 4)
            If .CustomeChecklistbox5.CheckedItemsCount = 0 Then
                For i = 0 To .CustomeChecklistbox5.ItemsCount - 1
                    mst = mst & "mst='" & .CustomeChecklistbox5.getItems(i).ToString & "' or "
                Next
            Else
                For i = 0 To .CustomeChecklistbox5.CheckedItemsCount - 1
                    mst = mst & "mst='" & .CustomeChecklistbox5.getCheckedItems(i).ToString & "' or "
                Next
            End If
            mst = mst.Substring(0, mst.Length - 4)
        End With
        connect()
        da = New SqlDataAdapter("Select * from ratemst where (" & group & ") and (" & Name & ") and (" & mst & ")", cn)
        da.Fill(ds, "ratemst")
        DG1.DataSource = ds.Tables(0)
        close1()
        DG1.AutoResizeColumns()
        DG1.Columns("pgroup").ReadOnly = True
        DG1.Columns("acname").ReadOnly = True
        DG1.Columns("mst").ReadOnly = True
        DG1.Columns("process").ReadOnly = True
        DG1.Columns("style").ReadOnly = True
        DG1.Columns("shade").ReadOnly = True
        DG1.Columns("item").ReadOnly = True
        DG1.Columns("serilano").ReadOnly = True
    End Sub

    Private Sub frmRateMaserEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button4.Focus()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim i, j As Integer
            i = 0
            j = 0
            If (TextBox1.Text = tv1) Then
            Else
                temp1 = 0
                temp2 = 1
            End If
            Dim columncount As Integer
            columncount = DG1.ColumnCount - 1


            tv1 = TextBox1.Text

            For i = temp1 To DG1.Rows.Count - 1
                For j = temp2 To columncount
                    If 1 <> 1 Then
                        GoTo a
                    Else
                        If (DG1.Item(j, i).Value.ToString.ToUpper.Contains(TextBox1.Text.ToUpper)) Then
                            Try
                                DG1.Item(j, i).Selected = True

                            Catch ex As Exception

                            End Try
                            temp2 = j + 1
                            '    check = 1
                            GoTo en
                        End If
                    End If

a:

                Next
                temp1 = i + 1
                temp2 = 0
            Next
           
en:



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmratemasterselection.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmratemasterprint.Show()
    End Sub
End Class