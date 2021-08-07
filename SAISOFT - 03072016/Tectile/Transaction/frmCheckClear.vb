Imports System.Data.SqlClient
Public Class frmCheckClear

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dat1 As New Date
            Dim dat2 As New Date
            dat1 = MaskedTextBox1.Text.ToString
            dat2 = MaskedTextBox2.Text.ToString
            Dim dr As SqlDataReader
            Dim sql As String = ""
            If ComboBox2.Text = "Pending" Then
                If ComboBox3.Text = "Receipt" Then
                    sql = "Select Vrno,dat,name,namecr,amount,desce,checkno,refbank,slipno from tblBank where bkname=name and dat>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and dat<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ispassed='f'"
                ElseIf ComboBox3.Text = "Payment" Then
                    sql = "Select Vrno,dat,name,namecr,amount,desce,checkno,refbank,slipno from tblBank where bkname=namecr and dat>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and dat<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ispassed='f'"
                ElseIf ComboBox3.Text = "Both" Then
                    sql = "Select Vrno,dat,name,namecr,amount,desce,checkno,refbank,slipno from tblBank where dat>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and dat<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ispassed='f'"
                End If
            Else
                If ComboBox3.Text = "Receipt" Then
                    sql = "Select Vrno,dat,name,namecr,amount,desce,checkno,refbank,slipno from tblBank where bkname=name and dat>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and dat<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
                ElseIf ComboBox3.Text = "Payment" Then
                    sql = "Select Vrno,dat,name,namecr,amount,desce,checkno,refbank,slipno from tblBank where bkname=namecr and dat>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and dat<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
                ElseIf ComboBox3.Text = "Both" Then
                    sql = "Select Vrno,dat,name,namecr,amount,desce,checkno,refbank,slipno from tblBank where dat>='" & dat1.Month & "-" & dat1.Day & "-" & dat1.Year & "' and dat<='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "'"
                End If
            End If

            Dim sqldata As New SqlDataAdapter
            Dim ds As New DataSet
            sqldata = New SqlDataAdapter(sql, cn)
            sqldata.Fill(ds, "tblBank")
            DG1.DataSource = ds.Tables("tblBank")
            DG1.Columns(0).Width = 70
            DG1.Columns(0).Visible = False
            DG1.Columns(1).Width = 80
            DG1.Columns(1).HeaderText = "Date"
            DG1.Columns(2).Width = 150
            DG1.Columns(2).HeaderText = "Name"
            DG1.Columns(3).Width = 150
            DG1.Columns(3).HeaderText = "NameCr"
            DG1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DG1.Columns(4).HeaderText = "Amount"
            DG1.Columns(5).HeaderText = "Description"
            DG1.Columns(6).HeaderText = "Check No"
            DG1.Columns(7).HeaderText = "Ref Bank"
            DG1.Columns(8).HeaderText = "Slip No"
            Dim chk As New DataGridViewCheckBoxColumn()
            DG1.Columns.Add(chk)
            chk.HeaderText = "Check Data"
            chk.Name = "chk"
            Dim i As Integer
            For i = 0 To DG1.Columns.Count - 2
                DG1.Columns(i).ReadOnly = True
            Next

            close1()
            DG1.Focus()
            Try
                DG1.Item(9, 0).Selected = True
            Catch ex As Exception

            End Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub frmCheckClear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MaskedTextBox1.Text = Format(dateyf, "dd-MM-yyyy")
            MaskedTextBox2.Text = Format(dateyl, "dd-MM-yyyy")
            companyname1.Text = frmcomdis.CompanyName
            dateyf1.Text = Format(dateyf, "dd-MM-yyyy")
            dateyl1.Text = Format(dateyl, "dd-MM-yyyy")

            Panel1.Focus()
            ComboBox1.Focus()
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select acname from tblAccount where book='Bank'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dat As New Date
            dat = maskdate.Text.ToString
            Dim i As Integer = 0
            For i = 0 To DG1.RowCount - 1
                If DG1.Item(9, i).Value = True Then
                    cmd = New SqlCommand("update tblbank set ispassed='t', passdt='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' where vrno='" & DG1.Item(0, i).Value & "'", cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub MaskedTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox2.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub ComboBox1_Enter(sender As Object, e As EventArgs) Handles ComboBox1.Enter, ComboBox2.Enter, ComboBox3.Enter
        sender.DroppedDown = True

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox3.Focus()
        End If
    End Sub

    Private Sub ComboBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            MaskedTextBox1.Focus()
        End If
    End Sub
    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave, ComboBox2.Leave, ComboBox3.Leave
        sender.DroppedDown = False

    End Sub

    Private Sub MaskedTextBox2_KeyDown1(sender As Object, e As KeyEventArgs) Handles MaskedTextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub maskdate_KeyDown(sender As Object, e As KeyEventArgs) Handles maskdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.Focus()
        End If
    End Sub

    Private Sub DG1_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.RowLeave

       
    End Sub

    Private Sub DG1_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DG1.RowValidated
        Try

            If DG1.Item(9, e.RowIndex).Value = True Then

                DG1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Else
                DG1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

        Catch ex As Exception
            Try
                DG1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Catch ex1 As Exception

            End Try

        End Try
    End Sub
End Class