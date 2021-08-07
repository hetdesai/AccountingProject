Imports System.Data.SqlClient
Public Class frmlotbillselection

    Private Sub frmlotbillselection_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmlotbillselection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        companyname1.Text = frmcomdis.CompanyName
        dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
        dateyl1.Text = Format(dateyl, "dd-MM-yyyy")
        MaskedTextBox1.Text = dateyf
        MaskedTextBox2.Text = dateyl
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select convert(INT,billno) from sale order by convert(INT,billno)", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ChkBill.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("Select distinct name from sale", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ChkAccount.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct pgroup from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ChkGroup.AddItem(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmlotbill.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

   

    Private Sub MaskedTextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Leave, MaskedTextBox2.Leave
        Try
            Dim dat As New Date
            dat = MaskedTextBox2.Text
            If DateDiff(DateInterval.Day, dat, dateyf) > 0 Or DateDiff(DateInterval.Day, dat, dateyl) < 0 Then
                MsgBox("Enter Date in Current A/c Year")
                MaskedTextBox2.Focus()
            End If
        Catch ex As Exception
            MsgBox("Enter Proper Date")
            MaskedTextBox2.Focus()
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub
End Class