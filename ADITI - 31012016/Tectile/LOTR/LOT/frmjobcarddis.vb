Imports System.Data.SqlClient
Public Class frmjobcarddis
    Dim ds As New DataSet2
    Public FROMWHERE As String = ""
    Public LOTNO As String = ""

    Private Sub frmjobcarddis_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If FROMWHERE <> "LOTR" Then
            frmlotr.Visible = True
        End If
    End Sub

    Private Sub frmjobcarddis_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub frmjobcarddis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
       
        Dim group As String = ""
        Dim Name As String = ""
        Dim lotno As String = ""
        Dim item As String = ""
        Dim mst As String = ""
        Dim dat1 As New Date
        Dim dat2 As New Date
        Dim type As String = ""
        Dim dat As String = ""
        dat1 = FRMJOBCARDSELE.MaskedTextBox1.Text
        dat2 = FRMJOBCARDSELE.MaskedTextBox2.Text
        dat = "date>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and date<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
        Dim i As Integer
        '   MessageBox.Show(frmjobcardsele.CustomeChecklistbox1.CheckedItemsCount)
        If FRMJOBCARDSELE.CustomeChecklistbox1.CheckedItemsCount = 0 Then
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox1.ItemsCount - 1
                group = group & "pgroup='" & FRMJOBCARDSELE.CustomeChecklistbox1.getItems(i).ToString & "' or "

            Next
        Else
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox1.CheckedItemsCount - 1
                group = group & "pgroup='" & FRMJOBCARDSELE.CustomeChecklistbox1.getCheckedItems(i).ToString & "' or "
            Next

        End If
        ' MessageBox.Show(group)
        group = group.Substring(0, group.Length - 4)
        '  MessageBox.Show(group)
        If FRMJOBCARDSELE.CustomeChecklistbox2.CheckedItemsCount = 0 Then
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox2.ItemsCount - 1
                Name = Name & "acname='" & FRMJOBCARDSELE.CustomeChecklistbox2.getItems(i).ToString & "' or "
            Next
        Else
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox2.CheckedItemsCount - 1
                Name = Name & "acname='" & FRMJOBCARDSELE.CustomeChecklistbox2.getCheckedItems(i).ToString & "' or "
            Next
        End If
        Name = Name.Substring(0, Name.Length - 4)
        If FRMJOBCARDSELE.CustomeChecklistbox4.CheckedItemsCount = 0 Then
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox4.ItemsCount - 1
                lotno = lotno & "lotno='" & FRMJOBCARDSELE.CustomeChecklistbox4.getItems(i).ToString & "' or "
            Next
        Else
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox4.CheckedItemsCount - 1
                lotno = lotno & "lotno='" & FRMJOBCARDSELE.CustomeChecklistbox4.getCheckedItems(i).ToString & "' or "
            Next
        End If
        Try
            lotno = lotno.Substring(0, lotno.Length - 4)
        Catch ex As Exception

        End Try
        If FRMJOBCARDSELE.CustomeChecklistbox3.CheckedItemsCount = 0 Then
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox3.ItemsCount - 1
                item = item & "item='" & FRMJOBCARDSELE.CustomeChecklistbox3.getItems(i).ToString & "' or "
            Next
        Else
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox3.CheckedItemsCount - 1
                item = item & "item='" & FRMJOBCARDSELE.CustomeChecklistbox3.getCheckedItems(i).ToString & "' or "
            Next
        End If
        item = item.Substring(0, item.Length - 4)
        If FRMJOBCARDSELE.CustomeChecklistbox5.CheckedItemsCount = 0 Then
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox5.ItemsCount - 1
                mst = mst & "mst='" & FRMJOBCARDSELE.CustomeChecklistbox5.getItems(i).ToString & "' or "
            Next
        Else
            For i = 0 To FRMJOBCARDSELE.CustomeChecklistbox5.CheckedItemsCount - 1
                mst = mst & "mst='" & FRMJOBCARDSELE.CustomeChecklistbox5.getCheckedItems(i).ToString & "' or "
            Next
        End If
        If FRMJOBCARDSELE.ComboBox3.Text.ToUpper = "MTR" Then
            type = " type='Mtr' "
        ElseIf FRMJOBCARDSELE.ComboBox3.Text.ToUpper = "WEIGHT" Then
            type = "type='Weg' "
        Else
            type = "type IS NULL or type='Mtr' or type='Weg' "

        End If

        mst = mst.Substring(0, mst.Length - 4)
        Dim da As New SqlDataAdapter
        '  MessageBox.Show("select * from tblAccount where (" & group & ")")
        da = New SqlDataAdapter("select * from tblAccount where (" & group & ")", cn)
        da.Fill(ds, "tblAccount")

        '  MsgBox("select * from tblLotr where (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ")")
        '    MsgBox("select * from tblLotr where (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ") and (" & dat & ")")
        da = New SqlDataAdapter("select * from tblLotr where (" & type & ") and (" & Name & ") and (" & lotno & ") and (" & item & ") and (" & mst & ") and (" & dat & ") and accode in (select accode from tblAccount where (" & group & "))", cn)
        da.Fill(ds, "tblLotr")
        da = New SqlDataAdapter("Select * from tblLotrt", cn)
        da.Fill(ds, "tblLotrt")
        Dim rpt As New rptjobcard
        rpt.SetDataSource(ds)

        Dim rpt2 As New rptjobcard2
        rpt2.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = rpt
        close1()

    End Sub
End Class