Imports System.Data.SqlClient
Public Class FRMJOBCARDSELE

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub MaskedTextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.Enter, MaskedTextBox2.Enter
        sender.SelectionLength = 0
        sender.SelectionStart = 0
    End Sub

    Private Sub MaskedTextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaskedTextBox1.GotFocus, MaskedTextBox2.GotFocus
        sender.SelectionLength = 0
        sender.SelectionStart = 0
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmjobcarddis.Show()
    End Sub

    Private Sub FRMJOBCARDSELE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FRMJOBCARDSELE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MaskedTextBox1.Text = Date.Today
        MaskedTextBox1.Focus()
        MaskedTextBox2.Text = Date.Today
        Try
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            If frmMainScreen.inwardrpt.ToUpper = "Lot".ToUpper Then
                '  Label4.Visible = False
                '     ComboBox2.Visible = False
            Else
                ' Label3.Visible = False
                'ComboBox1.Visible = False
            End If
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("select distinct pgroup from tblaccount", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox1.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct acname from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox2.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct item from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox3.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select distinct mst from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox5.AddItem(dr.Item(0))
            End While
            dr.Close()
            cmd = New SqlCommand("select lotno from tblLotr order by convert(int,lotn)", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CustomeChecklistbox4.AddItem(dr.Item(0))
            End While
            dr.Close()

            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmjobcarddis.Show()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class