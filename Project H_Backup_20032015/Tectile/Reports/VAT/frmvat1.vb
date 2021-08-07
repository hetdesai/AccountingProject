Imports System.Data.SqlClient
Public Class frmvat1
    Dim ds As New DataSet2
    Dim da As New SqlDataAdapter
    Private Sub frmvat1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With frmVatSelection
            Dim type As String = ""
            Dim i As Integer
            Dim tax As String = ""
            If .CheckedListBox2.CheckedItems.Count = 0 Then
                For i = 0 To .CheckedListBox2.Items.Count - 1
                    type = type & "type='" & .CheckedListBox2.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To .CheckedListBox2.CheckedItems.Count - 1
                    type = type & "type='" & .CheckedListBox2.CheckedItems(i).ToString & "' or "
                Next
            End If
            type = type.Substring(0, type.Length - 4)
            If .CheckedListBox1.CheckedItems.Count = 0 Then
                For i = 0 To .CheckedListBox1.Items.Count - 1
                    tax = tax & "tax='" & .CheckedListBox1.Items(i).ToString & "' or "
                Next
            Else
                For i = 0 To .CheckedListBox1.CheckedItems.Count - 1
                    tax = tax & "tax='" & .CheckedListBox1.CheckedItems(i).ToString & "' or "
                Next
            End If
            tax = tax.Substring(0, tax.Length - 4)
            da = New SqlDataAdapter("select * from saltax where (" & tax & ")", cn)
            da.Fill(ds, "saltax")
            'where billdt<='" & .dat1.Month & "-" & .dat1.Day & "-" & .dat1.Year & "' and billdt>='" & .dat2.Month & "-" & .dat2.Day & "-" & .dat2.Year & "'"
            da = New SqlDataAdapter("select * from salesc where billdt>='" & .dat1.Month & "-" & .dat1.Day & "-" & .dat1.Year & "' and billdt<='" & .dat2.Month & "-" & .dat2.Day & "-" & .dat2.Year & "'", cn)
            da.Fill(ds, "salesc")
            da = New SqlDataAdapter("select * from tax1 where (" & type & ")", cn)
            da.Fill(ds, "tax1")
            Dim rpt As New rptvat1
            rpt.SetDataSource(ds)
            CrystalReportViewer1.ReportSource = rpt
        End With
    End Sub
End Class