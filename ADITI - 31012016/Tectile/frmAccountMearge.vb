Imports System.Data.SqlClient
Public Class frmAccountMearge

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Are you sure you want to mearge the accounts", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            GroupBox1.Visible = True
            Dim i As Integer
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                CheckedListBox2.Items.Add(CheckedListBox1.CheckedItems(i).ToString)
            Next
        End If
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        Try
            If ComboBox1.Items.Contains(ComboBox1.Text) = False Then
                MsgBox("Select from List")
                ComboBox1.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

        If MsgBox("This is the final warning.Are you sure you want to mearge the accounts ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim i As Integer
                Dim accode As Integer
                Dim acname As String
                For i = 0 To CheckedListBox2.Items.Count - 1
                    accode = CheckedListBox2.Items(i).ToString.Substring(0, CheckedListBox2.Items(i).ToString.Split("&").Length - 1)
                    acname = CheckedListBox2.Items(i).ToString.Substring(CheckedListBox2.Items(i).ToString.Split("&").Length)
                    cmd = New SqlCommand("Update adv set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update advpmt set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update Aujvmst set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update adv set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update adv set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update sale set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update sale set name='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where name='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update sale set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update sale1 set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update sale1 set name='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where name='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update sale1 set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salec1 set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salec1 set name='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where name='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salec1 set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salesc set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salesc set name='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where name='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salesc set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salet set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salet set name='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where name='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update salet set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update saltax set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update saltax set poname='" & ComboBox1.Text & "',pocode=" & TextBox1.Text & " where poname='" & acname & "' and pocode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update taxmst set poname='" & ComboBox1.Text & "',pocode=" & TextBox1.Text & " where poname='" & acname & "' and pocode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblBank set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblBank set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblcheckacname set acname='" & ComboBox1.Text & "' where acname='" & acname & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tbljour set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblLedg set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tbljour set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblLotr set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblLotrt set accode=" & TextBox1.Text & " where accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblOPEN set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tbloub set acname='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where acname='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tbloub set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurchase set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurchase set name='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where name='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurchase set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurchaseDetail set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurchaseDetail set name='" & ComboBox1.Text & "',accode=" & TextBox1.Text & " where name='" & acname & "' and accode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurchaseDetail set namecr='" & ComboBox1.Text & "',accodecr=" & TextBox1.Text & " where namecr='" & acname & "' and accodecr=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurtax set bkname='" & ComboBox1.Text & "',bkcode=" & TextBox1.Text & " where bkname='" & acname & "' and bkcode=" & accode, cn)
                    cmd.ExecuteNonQuery()
                    cmd = New SqlCommand("Update tblPurtax set poname='" & ComboBox1.Text & "',pocode=" & TextBox1.Text & " where poname='" & acname & "' and pocode=" & accode, cn)
                    cmd.ExecuteNonQuery()

                Next
                close1()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub frmAccountMearge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select * from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item("ACCode") & "&" & dr.Item("ACNAME"))
                ComboBox1.Items.Add(dr.Item("ACNAME"))
            End While
            dr.Close()

            close1()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            connect()
            Dim da As New SqlDataAdapter
            Dim ds As New DataSet
            da = New SqlDataAdapter("Select * from tblAccount where acname='" & ComboBox1.Text & "'", cn)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select accode from tblaccount where acname='" & ComboBox1.Text & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox1.Text = dr.Item(0)
            End While
            dr.Close()
            close1()
        Catch ex As Exception

        End Try
    End Sub
End Class