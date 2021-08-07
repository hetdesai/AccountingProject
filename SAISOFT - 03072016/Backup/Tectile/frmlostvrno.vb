Imports System.Data.SqlClient
Public Class frmlostvrno
    Private Sub frmlostvrno_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            connect()
            If ComboBox1.Text = "Purchase" Then
                cmd = New SqlCommand("delete from tblPurchasedetail where vrno not in (Select vrno from tblPurchase)", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLedg where book='Purchase' and vrno not in (Select vrno from tblPurchase)", cn)
                cmd.ExecuteNonQuery()
            ElseIf ComboBox1.Text = "Sale" Then
                cmd = New SqlCommand("delete from salec1 where vrno not in (Select vrno from salesc)", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("delete from tblLedg where book='Sales' and vrno not in (Select vrno from salesc)", cn)
                cmd.ExecuteNonQuery()
            ElseIf ComboBox1.Text = "Jour" Then

            ElseIf ComboBox1.Text = "Bank" Then

            End If
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class