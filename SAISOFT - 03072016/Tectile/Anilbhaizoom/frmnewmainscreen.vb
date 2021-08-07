Imports System.Data.SqlClient
Public Class frmnewmainscreen
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Private Sub frmnewmainscreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            Dim lia As New ListBox
            Dim liaalph As New ListBox
            Dim asstes As New ListBox
            Dim assetalpha As New ListBox
            cmd = New SqlCommand("Select Mhead,malph from tblMH where asd='Liabilities'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                lia.Items.Add(dr.Item("Mhead"))
                liaalph.Items.Add(dr.Item("malph"))
            End While
            dr.Close()
            cmd = New SqlCommand("Select Mhead,malph from tblMH where asd='Assets'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                asstes.Items.Add(dr.Item("Mhead"))
                assetalpha.Items.Add(dr.Item("malph"))
            End While
            dr.Close()
            Dim blcount As Integer
            If asstes.Items.Count > lia.Items.Count Then
                blcount = asstes.Items.Count - 1
            ElseIf asstes.Items.Count < lia.Items.Count Then
                blcount = lia.Items.Count - 1
            Else
                blcount = asstes.Items.Count - 1
            End If
            Dim i As Integer = 0
            dg1.Rows.Add()
            dg1.Item(0, 0).Value = "Liabilities"
            dg1.Item(1, 0).Value = "Alph"
            dg1.Item(2, 0).Value = "Amount"
            dg1.Item(3, 0).Value = "Assets"
            dg1.Item(4, 0).Value = "Alph"
            dg1.Item(5, 0).Value = "Amount"
            dg1.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            dg1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            dg1.Rows(0).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
            dg1.Rows(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            i = i + 1
            Dim k As Integer
            For k = 0 To blcount
                dg1.Rows.Add()
                Try
                    dg1.Item(0, i).Value = lia.Items(k)
                    dg1.Item(1, i).Value = liaalph.Items(k)
                    dg1.Item(2, i).Value = mysub(dg1.Item(0, i).Value.ToString)
                Catch ex As Exception
                End Try
                Try
                    dg1.Item(3, i).Value = asstes.Items(k)
                    dg1.Item(4, i).Value = assetalpha.Items(k)
                    dg1.Item(5, i).Value = mysub3(dg1.Item(3, i).Value.ToString)
                Catch ex As Exception
                End Try
                i = i + 1
            Next
            Dim exp As New ListBox
            Dim expalph As New ListBox
            Dim income As New ListBox
            Dim incomealph As New ListBox
            Dim dr1 As SqlDataReader
            Dim cmd1 As New SqlCommand
            cmd1 = New SqlCommand("Select Mhead,malph from tblMH where asd='Expenditure'", cn)
            dr1 = cmd1.ExecuteReader
            While dr1.Read
                exp.Items.Add(dr1.Item("Mhead"))
                expalph.Items.Add(dr1.Item("malph"))
            End While
            dr1.Close()
            cmd1 = New SqlCommand("Select Mhead,malph from tblMH where asd='Income'", cn)
            dr1 = cmd1.ExecuteReader
            While dr1.Read
                income.Items.Add(dr1.Item("Mhead"))
                incomealph.Items.Add(dr1.Item("malph"))
            End While
            dr1.Close()
            Dim plcount As Integer
            If exp.Items.Count > income.Items.Count Then
                plcount = exp.Items.Count - 1
            ElseIf exp.Items.Count < income.Items.Count Then
                plcount = income.Items.Count - 1
            Else
                plcount = income.Items.Count - 1
            End If
            dg1.Rows.Add()
            dg1.Item(0, i).Value = "Expenditure"
            dg1.Item(1, i).Value = "Alph"
            dg1.Item(2, i).Value = "Amount"
            dg1.Item(3, i).Value = "Income"
            dg1.Item(4, i).Value = "Alph"
            dg1.Item(5, i).Value = "Amount"
            dg1.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            dg1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
            dg1.Rows(i).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
            dg1.Rows(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            i = i + 1
            For k = 0 To plcount
                dg1.Rows.Add()
                Try
                    dg1.Item(0, i).Value = exp.Items(k)
                    dg1.Item(1, i).Value = expalph.Items(k)
                    dg1.Item(2, i).Value = mysub3(dg1.Item(0, i).Value.ToString)
                Catch ex As Exception
                End Try
                Try
                    dg1.Item(3, i).Value = income.Items(k)
                    dg1.Item(4, i).Value = incomealph.Items(k)
                    dg1.Item(5, i).Value = mysub(dg1.Item(3, i).Value.ToString)
                Catch ex As Exception
                End Try
                i = i + 1
            Next

            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function mysub(ByVal mhead As String) As String
        connect()
        Dim sql As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        sql = "  Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        Dim bal As New Decimal
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                If dr.Item("Bal") > 0 Then
                    bal = dr.Item("Bal")
                    dr.Close()
                    Return Convert.ToDecimal(bal)
                ElseIf dr.Item("Bal") < 0 Then
                    bal = dr.Item("Bal")
                    dr.Close()

                    Return Convert.ToDecimal(bal)
                Else
                    dr.Close()
                    Return "0.00"
                End If
            End While

            dr.Close()
        End If
        close1()

    End Function
    Private Function mysub3(ByVal mhead As String) As String
        connect()
        Dim sql As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        sql = "  Select ASD,tblMh.Mhead,Sum(Dr) As DR, Sum(Cr) as CR,sum(bal) as bal, Sum(Cr)-Sum(Dr) as Balance from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode=tblAccount.ACCode and tblAccount.Scode = tblSH.SCode and tblSH.Mcode = tblMH.Mcode and tblMh.mhead='" & mhead & "' group by tblMh.Mhead,tblMh.ASD order by tblMh.Mhead,ASD"
        cmd = New SqlCommand(sql, cn)
        dr = cmd.ExecuteReader
        Dim bal As Decimal
        If dr.HasRows = False Then
            dr.Close()
            Return "0.00"
        Else
            While dr.Read
                If dr.Item("Bal") < 0 Then
                    bal = dr.Item("Bal")
                    dr.Close()
                    Return Format(bal * -1, "0.00")
                ElseIf dr.Item("Bal") > 0 Then
                    bal = dr.Item("Bal")
                    dr.Close()
                    Return Convert.ToDecimal((bal) * -1)
                Else
                    dr.Close()
                    Return "0.00"
                End If
            End While
            dr.Close()
        End If
        close1()

    End Function
End Class