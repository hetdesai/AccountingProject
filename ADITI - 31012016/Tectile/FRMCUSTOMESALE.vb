Imports System.Drawing.Text

Public Class FRMCUSTOMESALE
    Public vrno As String = "vrno"
    Public bkname As String = "bkname"
    Public chno As String = "chno"
    Public chdt As String = "chdt"
    Public billno As String = "billno"
    Public billdt As String = "billdt"
    Public oubno As String = "oubno"
    Public name1 As String = "name"
    Public namecr As String = "namecr"
    Public purtype As String = "purtype"
    Public pcs As String = "pcs"
    Public qty As String = "qty"
    Public gramt As String = "gramt"
    Public netamt As String = "netamt"
    Public workno As String = "workno"
    Public shipto As String = "shipto"
    Public grp1 As String = "grp1"
    Public grp2 As String = "grp2"
    Public grp3 As String = "grp3"
    Public grp4 As String = "grp4"
    Public groupheader1 As String = "grouph1"
    Public groupheader2 As String = "grouph2"
    Public summary1 As String = "sum1"
    Public summary2 As String = "sum2"
    Public month1 As String = "month1"
    Public month2 As String = "month2"
    Public dat1 As String = "date1"
    Public dat2 As String = "date2"
    Public final1 As String = "final"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            vrno = "vrno"
            bkname = "bkname"
            chno = "chno"
            chdt = "chdt"
            billno = "billno"
            billdt = "billdt"
            oubno = "oubno"
            name1 = "name"
            namecr = "namecr"
            purtype = "purtype"
            pcs = "pcs"
            qty = "qty"
            gramt = "gramt"
            netamt = "netamt"
            workno = "workno"
            shipto = "shipto"
            grp1 = "grp1"
            grp2 = "grp2"
            grp3 = "grp3"
            grp4 = "grp4"
            groupheader1 = "grouph1"
            groupheader2 = "grouph2"
            summary1 = "sum1"
            summary2 = "sum2"
            month1 = "month1"
            month2 = "month2"
            dat1 = "date1"
            dat2 = "date2"
            final1 = "final"

            Dim i As Integer
            For i = 0 To DG1.RowCount - 1
                If vrno = DG1.Item(0, i).Value.ToString.ToLower Then
                    vrno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value
                End If
                If bkname = DG1.Item(0, i).Value.ToString.ToLower Then
                    bkname = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value
                End If
                If chno = DG1.Item(0, i).Value.ToString.ToLower Then
                    chno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If chdt = DG1.Item(0, i).Value.ToString.ToLower Then
                    chdt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If billno = DG1.Item(0, i).Value.ToString.ToLower Then
                    billno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If billdt = DG1.Item(0, i).Value.ToString.ToLower Then
                    billdt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If oubno = DG1.Item(0, i).Value.ToString.ToLower Then
                    oubno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If name1 = DG1.Item(0, i).Value.ToString.ToLower Then
                    name1 = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If namecr = DG1.Item(0, i).Value.ToString.ToLower Then
                    namecr = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If workno = DG1.Item(0, i).Value.ToString.ToLower Then
                    workno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If shipto = DG1.Item(0, i).Value.ToString.ToLower Then
                    shipto = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If purtype = DG1.Item(0, i).Value.ToString.ToLower Then
                    purtype = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If gramt = DG1.Item(0, i).Value.ToString.ToLower Then
                    gramt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If netamt = DG1.Item(0, i).Value.ToString.ToLower Then
                    netamt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If pcs = DG1.Item(0, i).Value.ToString.ToLower Then
                    pcs = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If qty = DG1.Item(0, i).Value.ToString.ToLower Then
                    qty = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
en:
            Next
            Dim j As Integer
            j = 0
            groupheader1 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 1
            groupheader2 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 2
            summary1 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 3
            summary2 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 4
            month1 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 5
            month2 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 6
            dat1 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 7
            dat2 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value
            j = 8
            final1 = dg2.Item(1, j).Value & " " & dg2.Item(2, j).Value & " " & dg2.Item(3, j).Value & " " & dg2.Item(4, j).Value & " " & dg2.Item(5, j).Value & " " & dg2.Item(6, j).Value & " " & dg2.Item(7, j).Value & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value.ToString & " " & dg2.Item(10, j).Value.ToString & " $" & dg2.Item(11, j).Value

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        MessageBox.Show(bkname)
        FRMVIEWCUSTOM.Show()
    End Sub
    Private Sub AddFonts()

        Dim dgvc As DataGridViewComboBoxColumn
        Dim dgvc1 As DataGridViewComboBoxColumn
        dgvc = DG1.Columns(8)
        dgvc1 = dg2.Columns(11)
        Dim installed_fonts As New InstalledFontCollection
        '   ComboBox2.Items.Clear()
        For Each font_family As FontFamily In _
            installed_fonts.Families
            dgvc.Items.Add(font_family.Name)
            dgvc1.Items.Add(font_family.Name)
                '      ComboBox2.Items.Add(font_family.Name)
        Next font_family
        ' ComboBox2.SelectedIndex = 0

    End Sub

    Private Sub FRMCUSTOMESALE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AddFonts()
            Dim i As Integer
            For i = 0 To 10
                dg2.Rows.Add()
                dg2.Item(1, i).Value = i + 1
                dg2.Item(2, i).Value = 250
                dg2.Item(3, i).Value = 1500
                dg2.Item(4, i).Value = "CRBLACK"
                dg2.Item(5, i).Value = "9"
                dg2.Item(7, i).Value = "0"
                dg2.Item(8, i).Value = True
                dg2.Item(8, i).Value = False
                dg2.Item(9, i).Value = True
                dg2.Item(9, i).Value = False
                dg2.Item(10, i).Value = True
                dg2.Item(10, i).Value = False

                dg2.Item(11, i).Value = "Arial"

            Next
            dg2.Item(0, 0).Value = "GroupHeader1"
            dg2.Item(0, 1).Value = "GroupHeader2"
            dg2.Item(0, 2).Value = "Summary1"
            dg2.Item(0, 3).Value = "Summary2"
            dg2.Item(0, 4).Value = "Month"
            dg2.Item(0, 5).Value = "MonthSummary"
            dg2.Item(0, 6).Value = "Date"
            dg2.Item(0, 7).Value = "DateSummary"
            dg2.Item(0, 8).Value = "Final"
            dg2.Item(0, 9).Value = "Detail"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            DG1.Rows.Clear()
            Dim i As Integer
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                DG1.Rows.Add()
                DG1.Item(1, i).Value = i + 1
                DG1.Item(0, DG1.RowCount - 1).Value = CheckedListBox1.CheckedItems(i).ToString
                DG1.Item(4, i).Value = "CRBLACK"
                DG1.Item(5, i).Value = "9"
                DG1.Item(8, i).Value = "Arial"
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DG1_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DG1.RowsAdded
        Try
            DG1.Item(2, e.RowIndex).Value = 221
            DG1.Item(3, e.RowIndex).Value = 1000
            '         DG1.Item(4, e.RowIndex).Value = "CRBLACK"
            '        DG1.Item(5, e.RowIndex).Value = 9
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            vrno = "vrno"
            bkname = "bkname"
            chno = "chno"
            chdt = "chdt"
            billno = "billno"
            billdt = "billdt"
            oubno = "oubno"
            name1 = "name"
            namecr = "namecr"
            purtype = "purtype"
            pcs = "pcs"
            qty = "qty"
            gramt = "gramt"
            netamt = "netamt"
            workno = "workno"
            shipto = "shipto"
            grp1 = "grp1"
            grp2 = "grp2"
            grp3 = "grp3"
            grp4 = "grp4"
            groupheader1 = "grouph1"
            groupheader2 = "grouph2"
            summary1 = "sum1"
            summary2 = "sum2"
            month1 = "month1"
            month2 = "month2"
            dat1 = "date1"
            dat2 = "date2"
            final1 = "final"

            Dim i As Integer
            For i = 0 To DG1.RowCount - 1
                If vrno = DG1.Item(0, i).Value.ToString.ToLower Then
                    vrno = vrno & " " & DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value
                End If
                If bkname = DG1.Item(0, i).Value.ToString.ToLower Then
                    bkname = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value
                End If
                If chno = DG1.Item(0, i).Value.ToString.ToLower Then
                    chno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If chdt = DG1.Item(0, i).Value.ToString.ToLower Then
                    chdt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If billno = DG1.Item(0, i).Value.ToString.ToLower Then
                    billno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If billdt = DG1.Item(0, i).Value.ToString.ToLower Then
                    billdt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If oubno = DG1.Item(0, i).Value.ToString.ToLower Then
                    oubno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If name1 = DG1.Item(0, i).Value.ToString.ToLower Then
                    name1 = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If namecr = DG1.Item(0, i).Value.ToString.ToLower Then
                    namecr = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If workno = DG1.Item(0, i).Value.ToString.ToLower Then
                    workno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If shipto = DG1.Item(0, i).Value.ToString.ToLower Then
                    shipto = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If purtype = DG1.Item(0, i).Value.ToString.ToLower Then
                    purtype = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If gramt = DG1.Item(0, i).Value.ToString.ToLower Then
                    gramt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
                If netamt = DG1.Item(0, i).Value.ToString.ToLower Then
                    netamt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " " & DG1.Item(7, i).Value
                End If
en:
            Next
            Dim j As Integer
            j = 0
            groupheader1 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 1
            groupheader2 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 2
            summary1 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 3
            summary2 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 4
            month1 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 5
            month2 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 6
            dat1 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 7
            dat2 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
            j = 8
            final1 = dg2.Item(1, j).Value.ToString & " " & dg2.Item(2, j).Value.ToString & " " & dg2.Item(3, j).Value.ToString & " " & dg2.Item(4, j).Value.ToString & " " & dg2.Item(5, j).Value.ToString & " " & dg2.Item(6, j).Value.ToString & " " & dg2.Item(7, j).Value.ToString & " " & dg2.Item(8, j).Value.ToString & " " & dg2.Item(9, j).Value & " " & dg2.Item(10, j).Value & "$" & dg2.Item(11, j).Value
           
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub
End Class