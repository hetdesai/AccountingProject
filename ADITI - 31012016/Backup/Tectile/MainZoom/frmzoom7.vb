Imports System.Data.SqlClient
Public Class frmzoom7
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Public ACName As String
    Public month As String
    Public zoom As Boolean
    Public book As String
    Public VrNo As String
    Dim sql As String
    Private Sub frmzoom7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            connect()
            If zoomfrom = "Main" Then
                sql = "Select tblLedg.ACName,tblLedg.ACCode,tblLedg.VrNo,tblLedg.Book,tblLedg.Dr,tblLedg.Cr,tblLedg.Ref  from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblLedg.ACName='" & frmzoom4.ACName & "' and Month(Date)=" & frmzoomMonth.month
            ElseIf zoomfrom = "Ledger" Then
                sql = "Select tblLedg.ACName,tblLedg.ACCode,tblLedg.VrNo,tblLedg.Book,tblLedg.Dr,tblLedg.Cr,tblLedg.Ref  from tblLedg,tblAccount,tblSH,tblMH where tblLedg.ACCode = tblAccount.ACCode and tblAccount.Scode = tblSH.Scode and tblSH.Mcode = tblMH.Mcode and tblLedg.ACName='" & rptledggrid.Acname & "' and Month(Date)=" & frmzoomMonth.month
            End If
            da = New SqlDataAdapter(sql, cn)
            da.Fill(ds)
            DG1.DataSource = ds.Tables(0)
            close1()
            If frmzoomMonth.month = "1" Then
                month = "January"
            ElseIf frmzoomMonth.month = "2" Then
                month = "Febuary"
            ElseIf frmzoomMonth.month = "3" Then
                month = "March"
            ElseIf frmzoomMonth.month = "4" Then
                month = "April"
            ElseIf frmzoomMonth.month = "5" Then
                month = "May"
            ElseIf frmzoomMonth.month = "6" Then
                month = "June"
            ElseIf frmzoomMonth.month = "7" Then
                month = "July"
            ElseIf frmzoomMonth.month = "8" Then
                month = "Augest"
            ElseIf frmzoomMonth.month = "9" Then
                month = "September"
            ElseIf frmzoomMonth.month = "10" Then
                month = "October"
            ElseIf frmzoomMonth.month = "11" Then
                month = "November"
            ElseIf frmzoomMonth.month = "12" Then
                month = "December"
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG1.CellContentClick
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DG1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DG1.Item(3, DG1.SelectedCells.Item(0).RowIndex).Value = "Purchase" Then
                book = "Purchase"
                VrNo = DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value
                zoom = True
                Form3.Show()
                Me.Hide()
            End If
            If DG1.Item(3, DG1.SelectedCells.Item(0).RowIndex).Value = "BANK" Then
                book = "Bank"
                VrNo = DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim Namecr As String
                connect()
                cmd = New SqlCommand("Select * from tblBank where VrNo='" & VrNo & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Namecr = dr.Item("NameCr")
                End While
                dr.Close()
                cmd = New SqlCommand("Select * from tblAccount where ACName='" & Namecr & "' and Book='Bank'", cn)
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    zoom = True
                    frmBank.Show()
                Else
                    zoom = True
                    frmBankRecipt.Show()
                End If
                close1()
                '   frmBank.Show()
                Me.Hide()
            End If
            If DG1.Item(3, DG1.SelectedCells.Item(0).RowIndex).Value = "Sales" Then
                book = "Sales"
                zoom = True
                VrNo = DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value
                frmSale.Show()
                Me.Hide()
            End If
            If DG1.Item(3, DG1.SelectedCells.Item(0).RowIndex).Value = "Jour" Then
                book = "Jour"
                zoom = True
                VrNo = DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value
                frmJour.Show()
                Me.Hide()
            End If
            If DG1.Item(3, DG1.SelectedCells.Item(0).RowIndex).Value = "OPBAL" Then
                book = "OPBAL"
                zoom = True
                VrNo = DG1.Item(2, DG1.SelectedCells.Item(0).RowIndex).Value
                frmOpeningMaster.Show()
                Me.Hide()
            End If

        End If
        If e.KeyCode = Keys.Escape Then
            frmzoomMonth.Close()
            frmzoomMonth.Show()
        End If
    End Sub
End Class