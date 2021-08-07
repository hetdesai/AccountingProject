Imports System.Data.SqlClient
Public Class LotCheck

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            dginward.Rows.Clear()
            dginwarddetail.Rows.Clear()
            dgoutward.Rows.Clear()
            dgoutwarddetail.Rows.Clear()
            getinward()
            getoutward()
            inwarddetails()
            Try
                outworddetails(dgoutward.CurrentCell.RowIndex)
            Catch ex As Exception

            End Try


            If dginward.Rows.Count = 0 And dgoutward.Rows.Count = 0 Then
                MessageBox.Show("Lot no not exists")
            End If
            dgoutward.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub getinward()
        Try

            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select * from tblLotr where lotno='" & txtloty.Text & txtlotno.Text & "'", cn)
            dr = cmd.ExecuteReader
            Dim i As Integer = 0
            While dr.Read
                dginward.Rows.Add()
                dginward.Item("coldate", i).Value = Format(dr.Item("Date"), "dd-MM-yyyy")
                dginward.Item("colvrno", i).Value = dr.Item("vrno")
                dginward.Item("colacname", i).Value = dr.Item("ACNAME")
                dginward.Item("colgpcs", i).Value = dr.Item("gpcs")
                dginward.Item("colgmtr", i).Value = dr.Item("gmtr")
                dginward.Item("colitem", i).Value = dr.Item("item")
                dginward.Item("colgbalpcs", i).Value = dr.Item("gbalpcs")
                dginward.Item("colgbalmtr", i).Value = dr.Item("gbalmtr")
                dginward.Item("colmarka", i).Value = dr.Item("marka")
                dginward.Item("collrno", i).Value = dr.Item("lrno")
                dginward.Item("colweight", i).Value = dr.Item("weight")
                i = i + 1
            End While
            dr.Close()
            close1()
        Catch ex As Exception

        End Try

    End Sub

    
    Private Sub getoutward()
        connect()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select * from sale1 where lotno='" & txtloty.Text & txtlotno.Text & "'", cn)
        dr = cmd.ExecuteReader
        Dim i As Integer = 0
        While dr.Read
            dgoutward.Rows.Add()
            dgoutward.Item("col2date", i).Value = Format(dr.Item("BillDt"), "dd-MM-yyyy")
            dgoutward.Item("col2vrno", i).Value = dr.Item("vrno")
            dgoutward.Item("col2acname", i).Value = dr.Item("Namecr")
            dgoutward.Item("col2gpcs", i).Value = dr.Item("grpcs")
            dgoutward.Item("col2gmtr", i).Value = dr.Item("grmtr")
            dgoutward.Item("col2item", i).Value = dr.Item("itname")
            dgoutward.Item("colfpcs", i).Value = dr.Item("pcs")
            dgoutward.Item("colfmtr", i).Value = dr.Item("qty")
            dgoutward.Item("colrate", i).Value = dr.Item("rate")
            dgoutward.Item("colamount", i).Value = dr.Item("Amount")
            dgoutward.Item("colsr", i).Value = dr.Item("SrNo")
            '  dgoutward.Item("colmarka", i).Value = dr.Item
            i = i + 1
        End While
        dr.Close()
        close1()

    End Sub

    Private Sub LotCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtloty.Text = acycode & "/"
        Try
            ComboBox3.Items.Add(acycode & "/")
            ComboBox3.Items.Add(acycode - 1 & "/")
            ComboBox3.Items.Add(acycode - 2 & "/")
            ComboBox3.Items.Add(acycode - 3 & "/")

        Catch ex As Exception

        End Try
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select distinct acname from tblLotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
            ComboBox2.Items.Clear()
            connect()
            cmd = New SqlCommand("Select rlotno from tbllotr order by date", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        txtlotno.Text = ComboBox2.Text


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ComboBox2.Items.Clear()
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select rlotno from tbllotr where acname ='" & ComboBox1.Text & "' order by acname", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr.Item(0))
            End While
            dr.Close()
            close1()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dginward_KeyDown(sender As Object, e As KeyEventArgs) Handles dginward.KeyDown
        If e.KeyCode = Keys.Enter Then
            inwarddetails()
        End If
    End Sub
    Private Sub inwarddetails()
        Try


            If dginward.CurrentRow.Index > -1 Then
                dginwarddetail.Rows.Clear()
                Dim i As Integer = 0
                connect()
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select Sr,Gmtr,GbalMtr from tblLotrt where VrNo='" & dginward.Item(0, dginward.CurrentCell.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    dginwarddetail.Rows.Add()
                    dginwarddetail.Item(0, i).Value = dr.Item(0)
                    dginwarddetail.Item(1, i).Value = dr.Item(1)
                    dginwarddetail.Item(2, i).Value = dr.Item(2)
                    i = i + 1
                End While
                dr.Close()
                close1()
            End If




        Catch ex As Exception
            '     MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgoutward_KeyDown(sender As Object, e As KeyEventArgs) Handles dgoutward.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                outworddetails(dgoutward.CurrentCell.RowIndex)
            End If

        Catch ex As Exception

        End Try
     End Sub
    Private Sub outworddetails(rowno As Integer)
        Try

            If dginward.CurrentRow.Index > -1 Then
                connect()
                dgoutwarddetail.Rows.Clear()
                Dim cmd As New SqlCommand
                Dim i As Integer = 0
                Dim dr As SqlDataReader
                cmd = New SqlCommand("Select SrNo,Qty,GrMtr from salet where sr=" & dgoutward.Item(1, rowno).Value & " and vrno='" & dgoutward.Item(0, dgoutward.CurrentCell.RowIndex).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    dgoutwarddetail.Rows.Add()
                    dgoutwarddetail.Item(0, i).Value = dr.Item(0)
                    dgoutwarddetail.Item(1, i).Value = dr.Item(2)
                    dgoutwarddetail.Item(2, i).Value = dr.Item(1)
                    i = i + 1
                End While
                dr.Close()
                close1()
            End If



        Catch ex As Exception
            '      MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub dgoutward_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgoutward.RowEnter
        outworddetails(e.RowIndex)
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ComboBox2.Focus()
        End If
    End Sub

    Private Sub ComboBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If

    End Sub
End Class