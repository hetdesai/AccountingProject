Imports System.Data.SqlClient
Public Class frmbankreport
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet2

    Private Sub frmbankreport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmbankreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If frmMainScreen.bankreport = "Entry to Entry" Then
                Dim rpt As New EntrytoEntry
                connect()
                Dim dr1 As Integer
                Dim cr1 As Integer
                Dim dat As New Date
                Dim dat2 As New Date
                Dim sql As String
                dat = frmbankselection.MaskedTextBox1.Text.ToString
                dat2 = frmbankselection.MaskedTextBox2.Text.ToString
                Dim ACNAME As String
                If frmbankselection.CheckedListBox1.CheckedItems.Count = 0 Then
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.Items.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.Items(CNO).ToString & "' OR"
                    Next
                Else
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.CheckedItems.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.CheckedItems(CNO).ToString & "' OR"
                    Next
                End If
                ACNAME = ACNAME.Substring(0, ACNAME.Length - 3)
                 Dim dr As SqlDataReader
                Dim cmd As New SqlCommand
                Dim acname2 As String
                '  cmd = New SqlCommand("Select Sum(dr),Sum(cr) from tblLedg where Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and ACName='" & frmbankselection.CheckedListBox1.CheckedItems(0).ToString & "' group by ACName", cn)
                cmd = New SqlCommand("Select Sum(dr),Sum(cr),ACName from tblLedg where Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' AND (" & ACNAME & ") group by ACName", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    dr1 = dr.Item(0)
                    cr1 = dr.Item(1)
                    acname2 = dr.Item(2)
                End While
                dr.Close()
                cmd = New SqlCommand("Delete from templedg", cn)
                cmd.ExecuteNonQuery()
                Dim a() As String = {" ", "BANK", dat.Month & "-" & dat.Day & "-" & dat.Year, 0, acname2, dr1, cr1, cr1 - dr1, " ", " ", "Opening Balance ", 0}
                myinsert(a, "tempLedg")

                connect()
                If dat = dateyf Then
                    'sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ACName='" & frmbankselection.CheckedListBox1.CheckedItems(0).ToString & "'"
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and (Book='Bank' OR BOOK='OPBAL') AND (" & ACNAME & ") order by date"
                Else
                    'sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and ACName='" & frmbankselection.CheckedListBox1.CheckedItems(0).ToString & "' UNION Select * from tempLedg where ACName='" & frmbankselection.CheckedListBox1.CheckedItems(0).ToString & "'"
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and Book='Bank' AND (" & ACNAME & ")  UNION Select * from tempLedg where Book='Bank'"
                End If
                ' MsgBox(sql)
                da = New SqlDataAdapter(sql, cn)
                da.Fill(ds, "tblLedg")
                '                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Delete from tempLedg", cn)
                cmd.ExecuteNonQuery()

                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmbankselection.MaskedTextBox1.Text, frmbankselection.MaskedTextBox2.Text, "Entry to Entry")
                CrystalReportViewer1.ReportSource = rpt
                close1()
            ElseIf frmMainScreen.bankreport = "Daily" Then
                Dim rpt As New Daily
                connect()
                connect()
                Dim dr1 As Integer
                Dim cr1 As Integer
                Dim dat As New Date
                Dim dat2 As New Date
                Dim sql As String
                dat = frmbankselection.MaskedTextBox1.Text.ToString
                dat2 = frmbankselection.MaskedTextBox2.Text.ToString
                Dim ACNAME As String
                If frmbankselection.CheckedListBox1.CheckedItems.Count = 0 Then
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.Items.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.Items(CNO).ToString & "' OR"
                    Next
                Else
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.CheckedItems.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.CheckedItems(CNO).ToString & "' OR"
                    Next
                End If
                ACNAME = ACNAME.Substring(0, ACNAME.Length - 3)
                Dim acname2 As String = ""
                Dim dr As SqlDataReader
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select ACNAME,Sum(dr),Sum(cr) from tblLedg where Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and (" & ACNAME & ")group by ACName", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    dr1 = dr.Item(1)
                    cr1 = dr.Item(2)
                    acname2 = dr.Item(0)
                End While
                dr.Close()
                '     MsgBox(dr1 & "   " & cr1 & " " & acname2)
                Dim cmddelete As New SqlCommand
                cmddelete = New SqlCommand("Delete from templedg", cn)
                cmddelete.ExecuteNonQuery()
                Dim a() As String = {" ", "BANK", dat.Month & "-" & dat.Day & "-" & dat.Year, 0, acname2, dr1, cr1, cr1 - dr1, " ", " ", "Opening Balance ", 0}
                myinsert(a, "tempLedg")
                connect()
                If dat = dateyf Then
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and (" & ACNAME & ")"
                Else
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and (" & ACNAME & ")" & " UNION Select * from tempLedg where (" & ACNAME & ")"
                End If
                ' MsgBox(sql)

                da = New SqlDataAdapter(sql, cn)
                da.Fill(ds, "tblLedg")
                '                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Delete from tempLedg", cn)
                cmd.ExecuteNonQuery()
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmbankselection.MaskedTextBox1.Text, frmbankselection.MaskedTextBox2.Text, "Daily")
                CrystalReportViewer1.ReportSource = rpt
                close1()
            ElseIf frmMainScreen.bankreport = "Monthly" Then
                Dim rpt As New Monthly
                connect()
                connect()
                Dim dr1 As Integer
                Dim cr1 As Integer
                Dim dat As New Date
                Dim dat2 As New Date
                Dim sql As String
                dat = frmbankselection.MaskedTextBox1.Text.ToString
                dat2 = frmbankselection.MaskedTextBox2.Text.ToString
                Dim ACNAME As String
                If frmbankselection.CheckedListBox1.CheckedItems.Count = 0 Then
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.Items.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.Items(CNO).ToString & "' OR"
                    Next
                Else
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.CheckedItems.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.CheckedItems(CNO).ToString & "' OR"
                    Next
                End If
                ACNAME = ACNAME.Substring(0, ACNAME.Length - 3)
                Dim acname2 As String
                Dim dr As SqlDataReader
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select acname,Sum(dr),Sum(cr) from tblLedg where Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and (" & ACNAME & ") group by ACName", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    dr1 = dr.Item(1)
                    cr1 = dr.Item(2)
                    acname2 = dr.Item(0)
                End While
                dr.Close()
                Dim cmddelete As New SqlCommand
                cmddelete = New SqlCommand("Delete from templedg", cn)
                cmddelete.ExecuteNonQuery()
                Dim b() As String = {" ", "BANK", dat.Month & "-" & dat.Day & "-" & dat.Year, 0, acname2, dr1, cr1, cr1 - dr1, " ", " ", "Opening Balance ", 0}
                myinsert(b, "tempLedg")

                Dim a() As String = {" ", "BANK", dat.Month & "-" & dat.Day & "-" & dat.Year, 0, acname2, dr1, cr1, cr1 - dr1, " ", " ", "Opening Balance ", 0}
                myinsert(a, "tempLedg")
                connect()
                If dat = dateyf Then
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and (" & ACNAME & ")"
                Else
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and (" & ACNAME & ")" & " UNION Select * from tempLedg where (" & ACNAME & ")"
                End If
                da = New SqlDataAdapter(sql, cn)
                da.Fill(ds, "tblLedg")
                cmd = New SqlCommand("Delete from tempLedg", cn)
                cmd.ExecuteNonQuery()
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmbankselection.MaskedTextBox1.Text, frmbankselection.MaskedTextBox2.Text, "Monthly")
                CrystalReportViewer1.ReportSource = rpt
                close1()
            ElseIf frmMainScreen.bankreport = "Summary" Then
                Dim rpt As New BankSummary
                connect()
                connect()
                Dim dr1 As Integer
                Dim cr1 As Integer
                Dim dat As New Date
                Dim dat2 As New Date
                Dim sql As String
                dat = frmbankselection.MaskedTextBox1.Text.ToString
                dat2 = frmbankselection.MaskedTextBox2.Text.ToString
                Dim ACNAME As String
                If frmbankselection.CheckedListBox1.CheckedItems.Count = 0 Then
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.Items.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.Items(CNO).ToString & "' OR"
                    Next
                Else
                    Dim CNO As Integer
                    For CNO = 0 To frmbankselection.CheckedListBox1.CheckedItems.Count - 1
                        ACNAME = ACNAME & " ACNAME='" & frmbankselection.CheckedListBox1.CheckedItems(CNO).ToString & "' OR"
                    Next
                End If
                ACNAME = ACNAME.Substring(0, ACNAME.Length - 3)
                Dim acname2 As String = ""
                Dim dr As SqlDataReader
                Dim cmd As New SqlCommand
                cmd = New SqlCommand("Select acname,Sum(dr),Sum(cr) from tblLedg where Date <'" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and (" & ACNAME & ") group by ACName", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    dr1 = dr.Item(1)
                    cr1 = dr.Item(2)
                    acname2 = dr.Item(0)
                End While
                dr.Close()
                Dim a() As String = {" ", "BANK", dat.Month & "-" & dat.Day & "-" & dat.Year, 0, acname2, dr1, cr1, cr1 - dr1, " ", " ", "Opening Balance ", 0}
                myinsert(a, "tempLedg")
                connect()
                If dat = dateyf Then
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and (" & ACNAME & ")"
                Else
                    sql = "Select * from tblLedg where date >='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' and date <='" & dat2.Month & "-" & dat2.Day & "-" & dat2.Year & "' and (" & ACNAME & ") UNION Select * from tempLedg where (" & ACNAME & ")"
                End If
                da = New SqlDataAdapter(sql, cn)
                da.Fill(ds, "tblLedg")
                cmd = New SqlCommand("Delete from tempLedg", cn)
                cmd.ExecuteNonQuery()
                rpt.SetDataSource(ds)
                CrystalReportViewer1.ParameterFieldInfo = passparam(frmbankselection.MaskedTextBox1.Text, frmbankselection.MaskedTextBox2.Text, "Summary")
                CrystalReportViewer1.ReportSource = rpt
                close1()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class