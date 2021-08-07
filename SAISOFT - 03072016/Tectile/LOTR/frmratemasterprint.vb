Imports System.Data.SqlClient
Public Class frmratemasterprint
    Dim ds As New DataSet2
    Dim da As New SqlDataAdapter
    Private Sub frmratemasterprint_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmratemasterprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim rpt As New rptratemst
        rpt.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
        close1()

    End Sub
End Class