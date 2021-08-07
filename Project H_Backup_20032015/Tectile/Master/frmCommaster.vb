Imports System.Data.SqlClient
Public Class frmCommaster
    Dim cmd As New SqlCommand
    Dim ds As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim companycon As New SqlConnection
    Private Sub gotfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhone3.GotFocus, txtComName.GotFocus, txtCity.GotFocus, txtPhone1.GotFocus, txtPhone2.GotFocus, txtPhone3.GotFocus, txtFax.GotFocus, txtWebSite.GotFocus, txtTinNo.GotFocus, txtCstNo.GotFocus, txtPanNo.GotFocus, txtComCode.GotFocus, txtTanNo.GotFocus, txtEccNo.GotFocus, txtSortname.GotFocus, txtState.GotFocus, txtreportHeader1.GotFocus, txtreportheader2.GotFocus, txtAddress1.GotFocus, txtAddress2.GotFocus, txtAdress3.GotFocus, txtServiceTax.GotFocus, txtJuriCity.GotFocus, txtPincode.GotFocus
        Try
            sender.BackColor = Color.LightSteelBlue
            sender.forecolor = Color.White
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub lostfocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhone3.LostFocus, txtComName.LostFocus, txtCity.LostFocus, txtPhone1.LostFocus, txtPhone2.LostFocus, txtPhone3.LostFocus, txtFax.LostFocus, txtWebSite.LostFocus, txtTinNo.LostFocus, txtCstNo.LostFocus, txtPanNo.LostFocus, txtComCode.LostFocus, txtTanNo.LostFocus, txtEccNo.LostFocus, txtSortname.LostFocus, txtState.LostFocus, txtreportHeader1.LostFocus, txtreportheader2.LostFocus, txtAddress1.LostFocus, txtAddress2.LostFocus, txtAdress3.LostFocus, txtServiceTax.LostFocus, txtJuriCity.LostFocus, txtPincode.LostFocus
        Try
            sender.BackColor = Color.White
            sender.forecolor = Color.Black
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmCommaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmCommaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            TextBox25.Text = Application.StartupPath & "\" & "IMAGES\NOIMAGE.BMP"
            PictureBox1.ImageLocation = Application.StartupPath & "\" & "IMAGES\NOIMAGE.BMP"
            PictureBox1.Load()
            companycon = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            companycon.Open()
            cmd = New SqlCommand("Select distinct comname from tblCompany", companycon)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            If frmcomdis.mode = 1 Then
                Label20.Text = "ADD Mode"
                myserialno("tblCompany", txtComCode, "ComCode")
            ElseIf frmcomdis.mode = 2 Then
                cmd = New SqlCommand("Select * from tblCompany where srno=" & frmcomdis.code, companycon)
                dr = cmd.ExecuteReader
                While dr.Read
                    txtComName.Text = dr.Item(0)
                    txtComCode.Text = dr.Item(1)
                    maskfrom.Text = dr.Item(2)
                    maskto.Text = dr.Item(3)
                    txtSortname.Text = dr.Item(4)
                    txtState.Text = dr.Item(5)
                    TextBox25.Text = Application.StartupPath & "\Images\" & dr.Item(1)
                    TextBox26.Text = Application.StartupPath & "\Images\" & dr.Item(1)
                    PictureBox1.ImageLocation = Application.StartupPath & "\Images\" & dr.Item(1)
                    PictureBox1.Load()
                    txtreportHeader1.Text = dr.Item(7)
                    txtreportheader2.Text = dr.Item(8)
                    txtAddress1.Text = dr.Item(9)
                    txtAddress2.Text = dr.Item(10)
                    txtAdress3.Text = dr.Item(11)
                    txtCity.Text = dr.Item(12)
                    txtPincode.Text = dr.Item(13)
                    txtPhone1.Text = dr.Item(14)
                    txtPhone2.Text = dr.Item(15)
                    txtPhone3.Text = dr.Item(16)
                    txtFax.Text = dr.Item(17)
                    txtWebSite.Text = dr.Item(18)
                    txtTinNo.Text = dr.Item(19)
                    txtCstNo.Text = dr.Item(20)
                    txtPanNo.Text = dr.Item(21)
                    txtTanNo.Text = dr.Item(22)
                    txtEccNo.Text = dr.Item(23)
                    txtServiceTax.Text = dr.Item(24)
                    txtJuriCity.Text = dr.Item(25)
                    txttnc.Text = dr.Item(26)
                End While
                dr.Close()
                Label20.Text = "EDIT Mode"
            ElseIf frmcomdis.mode = 1 Then
                Label20.Text = "Delete Mode"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If txtPincode.Text.Trim.Length = 0 Then
                txtPincode.Text = 0
            End If
            If txtPhone1.Text.Trim.Length = 0 Then
                txtPhone1.Text = 0
            End If
            If txtPhone2.Text.Trim.Length = 0 Then
                txtPhone2.Text = 0
            End If
            If txtPhone3.Text.Trim.Length = 0 Then
                txtPhone3.Text = 0
            End If
            If txtFax.Text.Trim.Length = 0 Then
                txtFax.Text = 0
            End If
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = maskfrom.Text.ToString
            dat2 = maskto.Text.ToString
            If frmcomdis.mode = 1 Then
                Dim a() As String = {txtComName.Text, txtComCode.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtSortname.Text, txtState.Text, txtComName.Text, txtreportHeader1.Text, txtreportheader2.Text, txtAddress1.Text, txtAddress2.Text, txtAdress3.Text, txtCity.Text, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtPhone3.Text, txtFax.Text, txtWebSite.Text, txtTinNo.Text, txtCstNo.Text, txtPanNo.Text, txtTanNo.Text, txtEccNo.Text, txtServiceTax.Text, txtJuriCity.Text, txttnc.Text}
                myinsert(a, "tblCompany")
                MsgBox("Inserted")
                System.IO.File.Copy(TextBox25.Text, Application.StartupPath & "\Images\" & txtComCode.Text)
                System.IO.File.Copy(Application.StartupPath & "\NewDb.mdf", Application.StartupPath & "\" & txtComCode.Text & "NewDb.mdf")
            ElseIf frmcomdis.mode = 2 Then
                Dim a() As String = {txtComName.Text, txtComCode.Text, dat1.Month & "-" & dat1.Day & "-" & dat1.Year, dat2.Month & "-" & dat2.Day & "-" & dat2.Year, txtSortname.Text, txtState.Text, txtComName.Text, txtreportHeader1.Text, txtreportheader2.Text, txtAddress1.Text, txtAddress2.Text, txtAdress3.Text, txtCity.Text, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtPhone3.Text, txtFax.Text, txtWebSite.Text, txtTinNo.Text, txtCstNo.Text, txtPanNo.Text, txtTanNo.Text, txtEccNo.Text, txtServiceTax.Text, txtJuriCity.Text, txttnc.Text}
                If TextBox25.Text.Trim.ToString <> TextBox26.Text.Trim.ToString Then
                    If System.IO.File.Exists(Application.StartupPath & "\Images\" & txtComCode.Text) = True Then
                        System.IO.File.Delete(Application.StartupPath & "\Images\" & txtComCode.Text)
                    End If
                    System.IO.File.Copy(TextBox25.Text, Application.StartupPath & "\Images\" & txtComCode.Text)
                End If
                myupdate("tblCompany", a, "srno", frmcomdis.code)
                MsgBox("Updated")
            End If
            da = New SqlDataAdapter("Select * from tblCompany", companycon)
            da.Fill(ds)
            frmcomdis.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub myinsert(ByVal a As Array, ByVal ds As String)
        Try
            dr.Close()
            companycon = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            companycon.Open()
            Dim i As Integer
            Dim sql As String
            Dim da As New SqlDataAdapter
            Dim ds1 As New DataSet

            da = New SqlDataAdapter("Select * from " & ds, companycon)
            da.Fill(ds1)
            '  MsgBox(ds1.Tables(0).Columns(1).DataType.ToString)
            sql = "Insert into " & ds & " values("
            For i = 0 To a.Length - 1
                If ds1.Tables(0).Columns(i).DataType.ToString.Equals("System.Decimal") Then
                    sql = sql & a(i) & ","
                Else
                    sql = sql & "'" & a(i) & "',"
                End If
            Next
            sql = sql.Substring(0, sql.Length - 1) & ")"
            cmd = New SqlCommand(sql, companycon)
            cmd.ExecuteNonQuery()
            ' MsgBox("Inserted")
            companycon.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub myupdate(ByVal ds As String, ByVal a As Array, ByVal key As String, ByVal con As String)
        Try
            companycon = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
            companycon.Open()
            '   connect()
            Dim i As Integer
            Dim sql As String
            Dim da As New SqlDataAdapter
            Dim ds1 As New DataSet

            da = New SqlDataAdapter("Select * from " & ds, companycon)
            da.Fill(ds1)
            '  MsgBox(ds1.Tables(0).Columns(1).DataType.ToString)
            sql = "Update " & ds & " set "
            For i = 0 To a.Length - 1
                sql = sql & ds1.Tables(0).Columns(i).ColumnName & "="
                If ds1.Tables(0).Columns(i).DataType.ToString.Equals("System.Decimal") Then
                    sql = sql & a(i) & ", "
                Else
                    sql = sql & "'" & a(i) & "', "
                End If
            Next
            da = New SqlDataAdapter("Select * from " & ds, companycon)
            da.Fill(ds1)
            '      MsgBox(sql)
            If ds1.Tables(0).Columns(key).DataType.ToString.Equals("System.Decimal") = True Then

                sql = sql.Substring(0, sql.Length - 2) & " where " & key & "=" & con
            Else
                sql = sql.Substring(0, sql.Length - 2) & " where " & key & "='" & con & "'"
            End If

            cmd = New SqlCommand(sql, companycon)
            cmd.ExecuteNonQuery()
            ' MsgBox("het")
            companycon.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub myserialno(ByVal ds As String, ByRef tb As TextBox, ByVal col As String)
        companycon = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Companydatabase.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        companycon.Open()

        '  connect()
        Dim i As Integer = 0
        Dim da As New SqlDataAdapter
        Dim ds1 As New DataSet
        cmd = New SqlCommand("Select Count(" & col & ") from " & ds, companycon)
        dr = cmd.ExecuteReader
        While dr.Read
            If dr.Item(0) = 0 Then
                i = i + 1
                tb.Text = "1"
                GoTo en
            End If
        End While
        dr.Close()
        If i = 0 Then
            cmd = New SqlCommand("Select Max(" & col & ") from " & ds, companycon)
            dr = cmd.ExecuteReader
            While dr.Read
                tb.Text = dr.Item(0) + 1
            End While
            dr.Close()
        End If
        companycon.Close()

en:
        close1()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.ImageLocation = (OpenFileDialog1.FileName.ToString)
            PictureBox1.Load()
            TextBox25.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox25_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox25.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdress3.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cmd As New SqlCommand
        Dim sr As SqlDataReader
        companycon.Open()
        cmd = New SqlCommand("Select * from tblCompany where comname='" & ComboBox1.Text & "'", companycon)
        dr = cmd.ExecuteReader
        While dr.Read
            txtComName.Text = dr.Item(0)
            txtSortname.Text = dr.Item(4)
            txtState.Text = dr.Item(5)
            TextBox25.Text = Application.StartupPath & "\Images\" & dr.Item(1)
            TextBox26.Text = Application.StartupPath & "\Images\" & dr.Item(1)
            PictureBox1.ImageLocation = Application.StartupPath & "\Images\" & dr.Item(1)
            PictureBox1.Load()
            txtreportHeader1.Text = dr.Item(7)
            txtreportheader2.Text = dr.Item(8)
            txtAddress1.Text = dr.Item(9)
            txtAddress2.Text = dr.Item(10)
            txtAdress3.Text = dr.Item(11)
            txtCity.Text = dr.Item(12)
            txtPincode.Text = dr.Item(13)
            txtPhone1.Text = dr.Item(14)
            txtPhone2.Text = dr.Item(15)
            txtPhone3.Text = dr.Item(16)
            txtFax.Text = dr.Item(17)
            txtWebSite.Text = dr.Item(18)
            txtTinNo.Text = dr.Item(19)
            txtCstNo.Text = dr.Item(20)
            txtPanNo.Text = dr.Item(21)
            txtTanNo.Text = dr.Item(22)
            txtEccNo.Text = dr.Item(23)
            txtServiceTax.Text = dr.Item(24)
            txtJuriCity.Text = dr.Item(25)
            txttnc.Text = dr.Item(26)
        End While
        dr.Close()
        companycon.Close()
    End Sub

    Private Sub reportHeader1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtreportHeader1.TextChanged

    End Sub
End Class