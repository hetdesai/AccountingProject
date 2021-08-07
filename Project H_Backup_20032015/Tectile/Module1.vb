Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Module Module1
    Dim cmd As New SqlCommand
    Dim ds1 As New DataSet
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Public cn As New SqlConnection
    Public cn1 As New SqlConnection
    Public dateyf As New Date
    Public dateyl As New Date
    Public acyear As String
    Public acycode As String
    Public vcomp As String
    Public zoomfrom As String
    Public comname As String
    Public zoomprint As Integer
    Public Function acm(ByVal a As String) As String
        Return "Select ac.ACCode,ac.ACname,ac.Schedule,ac.Add1,ac.add2,ac.Place,ac.marko,ac.Pin,ac.State,ac.GSTNo,ac.CSTNo,ac.GstDT,ac.CSTDt,ac.PanNo,ac.Emailid,ac.MObNo,ac.Homeno,ac.Book,ac.Scode,ac.Mcode,ac.Pgroup,Sum(tblLedg.bal) as Balance,tblOpen.Amount,tblOpen.type from tblAccount ac Left outer join tblLedg On tblLedg.ACname=ac.Acname left outer join tblOpen on tblLedg.acname=tblOpen.ACNAME where ac.acname like '" & a & "%' group by ac.ACCode,ac.ACname,ac.Schedule,ac.Add1,ac.add2,ac.Place,ac.marko,ac.Pin,ac.State,ac.GSTNo,ac.CSTNo,ac.GstDT,ac.CSTDt,ac.PanNo,ac.Emailid,ac.MObNo,ac.Homeno,ac.Book,ac.Scode,ac.Mcode,ac.Pgroup,tblLedg.ACname,tblOPen.amount,tblopen.type order by ac.acname"
    End Function
    Public Sub connect()
        cn = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Backup from old laptop\Project H_28032013\Tectile\bin\Debug\5NewDb.mdf;Integrated Security=True;Connect Timeout=30")

        'cn = New SqlConnection("Server=tcp:hbwiltr2fb.database.windows.net,1433;Database=school;User ID=hetsql@hbwiltr2fb;Password=Password123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        cn.Open()
    End Sub
    Private Sub connect1()
        cn1 = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\" & frmcomdis.companycode & "NEWdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")
        cn1.Open()
    End Sub
    Public Sub close1()
        cn.Close()
    End Sub
    Public Sub close2()
        cn1.Close()
    End Sub
    Public Sub onlyNumbers(ByRef sender As Object, ByRef e As KeyPressEventArgs)
        If (e.KeyChar >= "0" And e.KeyChar <= "9") = False Then
            If e.KeyChar <> "." Then
                If Asc(e.KeyChar) <> 8 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Public Sub onlyNumbers2(ByRef sender As Object, ByRef e As KeyPressEventArgs)
        If (e.KeyChar >= "0" And e.KeyChar <= "9") = False Then
            If Asc(e.KeyChar) <> 8 Then
                e.Handled = True
            End If
        End If
    End Sub
    Public Sub myinsert(ByVal a As Array, ByVal ds As String)
        Try
            connect()
            Dim i As Integer
            Dim sql As String
            Dim da As New SqlDataAdapter
            Dim ds1 As New DataSet
            da = New SqlDataAdapter("Select * from " & ds, cn)
            da.Fill(ds1)
            '  MsgBox(ds1.Tables(0).Columns(1).DataType.ToString)

            sql = "Insert into " & ds & " values("
            For i = 0 To a.Length - 1
                If ds = "Salec1" Then
                    '   MsgBox(ds1.Tables(0).Columns(i).ColumnName & "     " & ds1.Tables(0).Columns(i).DataType.ToString)
                End If
                If ds1.Tables(0).Columns(i).DataType.ToString.Equals("System.Decimal") Then
                    sql = sql & a(i) & ","
                Else
                    sql = sql & "'" & a(i) & "',"
                End If
            Next
            sql = sql.Substring(0, sql.Length - 1) & ")"
            If ds.ToUpper = "salesc".ToUpper Then
                '   MsgBox(sql)
            End If
            ' MsgBox(sql)
            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            ' MsgBox("Inserted")
            close1()
        Catch ex As Exception
            MsgBox(ds & ex.ToString)
        End Try

    End Sub
    Private Sub My_Keydown(sender As Object, e As KeyEventArgs, ByRef control As Object)
        If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down) Then
            control.focus()
        End If

    End Sub
    Public Sub myinsert1(ByVal a As Array, ByVal ds As String, ByRef tr As SqlTransaction)
        Try
            connect1()
            MsgBox(ds)
            Dim i As Integer
            Dim sql As String
            Dim da As New SqlDataAdapter
            Dim ds1 As New DataSet
            da = New SqlDataAdapter("Select * from " & ds, cn1)
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
            cmd.Transaction = tr
            cmd = New SqlCommand(sql, cn, tr)
            cmd.ExecuteNonQuery()
            MsgBox("Asc")
            ' MsgBox("Inserted")
            close2()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub mydelete(ByVal ds As String, ByVal key As String, ByVal condition As String)
        connect()
        If condition.StartsWith("c") = False Then
            cmd = New SqlCommand("Delete from " & ds & " where " & key & "=" & condition, cn)
        Else
            cmd = New SqlCommand("Delete from " & ds & " where " & key & "='" & condition & "'", cn)
        End If

        cmd.ExecuteNonQuery()
        close1()
    End Sub
    Public Sub myupdate(ByVal ds As String, ByVal a As Array, ByVal key As String, ByVal con As String)
        Try
            connect()
            Dim i As Integer
            Dim sql As String
            Dim da As New SqlDataAdapter
            Dim ds1 As New DataSet

            da = New SqlDataAdapter("Select * from " & ds, cn)
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
            da = New SqlDataAdapter("Select * from " & ds, cn)
            da.Fill(ds1)
            '      MsgBox(sql)
            If ds1.Tables(0).Columns(key).DataType.ToString.Equals("System.Decimal") = True Then

                sql = sql.Substring(0, sql.Length - 2) & " where " & key & "=" & con
            Else
                sql = sql.Substring(0, sql.Length - 2) & " where " & key & "='" & con & "'"
            End If

            cmd = New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
            ' MsgBox("het")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub myfillCombo(ByRef combo As ComboBox, ByVal ds As String, ByVal column As String)
        connect()
        cmd = New SqlCommand("Select " & column & " from " & ds, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            combo.Items.Add(dr.Item(0))
        End While
        dr.Close()
        close1()
    End Sub
    Public Sub myfilldatagrid(ByRef a As DataGridView, ByVal ds As String)
        connect()
        Dim da As New SqlDataAdapter
        Dim ds1 As New DataSet
        da = New SqlDataAdapter("Select * from " & ds, cn)
        da.Fill(ds1)
        a.DataSource = ds1.Tables(0)
        Try
            a.Item(0, a.RowCount - 1).Selected = True
        Catch ex As Exception

        End Try
        close1()
    End Sub
    Public Sub myAutoComplete(ByRef tb As TextBox, ByRef li As ListBox, ByVal ds As String, ByVal col As String)
        connect()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd = New SqlCommand("Select * from " & ds & " where " & col & " like '" & tb.Text & "%'", cn)
        dr = cmd.ExecuteReader
        li.Items.Clear()
        While dr.Read
            li.Items.Add(dr.Item(col))
        End While
        dr.Close()
        close1()
        li.Left = tb.Left
        li.Top = tb.Top + 25
        li.Width = tb.Width
        li.Visible = True
        li.BringToFront()
    End Sub
    Public Sub myfillCustome(ByRef a As TextBox, ByVal ds As String, ByVal column As String)
        connect()
        cmd = New SqlCommand("Select " & column & " from " & ds, cn)
        dr = cmd.ExecuteReader
        While dr.Read
            a.AutoCompleteCustomSource.Add(dr.Item(0))
        End While
        dr.Close()
        a.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        a.AutoCompleteSource = AutoCompleteSource.CustomSource
        close1()

    End Sub
    Public Sub myserialno(ByVal ds As String, ByRef tb As TextBox, ByVal col As String)
        connect()
        Dim i As Integer = 0
        Dim da As New SqlDataAdapter
        Dim ds1 As New DataSet
        cmd = New SqlCommand("Select Count(" & col & ") from " & ds, cn)
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
            cmd = New SqlCommand("Select Max(" & col & ") from " & ds, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                tb.Text = dr.Item(0) + 1
            End While
            dr.Close()
        End If
en:
        close1()
    End Sub
    Public Function myconselect(ByVal ds As String, ByVal con As String, ByVal col As String) As SqlDataReader
        Try
            connect()
            '      MsgBox(cn.ToString)
            Dim da As New SqlDataAdapter
            Dim ds1 As New DataSet
            Dim dr As SqlDataReader
            da = New SqlDataAdapter("Select * from " & ds, cn)
            da.Fill(ds1)
            If ds1.Tables(0).Columns(col).DataType.ToString.Equals("System.Decimal") = True Then
                cmd = New SqlCommand("Select * from " & ds & " where " & col & "=" & con, cn)
                'MsgBox("Select * from " & ds & " where " & col & "=" & con)
            Else
                cmd = New SqlCommand("Select * from " & ds & " where " & col & "='" & con & "'", cn)
                'MsgBox("Select * from " & ds & " where " & col & "='" & con & "'")
            End If
            dr = cmd.ExecuteReader
            Return dr
            close1()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function duplicate(ByVal ds As String, ByVal col As String, ByRef tb As TextBox) As Boolean
        connect()
        da = New SqlDataAdapter("Select * from " & ds, cn)
        da.Fill(ds1)
        If ds1.Tables(0).Columns(col).DataType.ToString.Equals("System.Decimal") = True Then
            cmd = New SqlCommand("Select * from " & ds & " where " & col & "=" & tb.Text, cn)
        Else
            cmd = New SqlCommand("Select * from " & ds & " where " & col & "='" & tb.Text & "'", cn)
        End If
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Sub numericform(ByRef tb As TextBox)
        Try
            tb.Text = Format(Val(tb.Text), "0.00")
        Catch ex As Exception
        End Try
    End Sub
    Public Sub numericformweight(ByRef tb As TextBox)
        Try
            tb.Text = Format(Val(tb.Text), "0.000")
        Catch ex As Exception
        End Try
    End Sub
    Public Function passparam(ByVal fromdat As String, ByVal todate As String, ByVal Title As String) As ParameterFields
        Try

            Dim p1 As New ParameterFields
            Dim field1 As New ParameterField ' ParameterField for 1st param
            Dim value1 As New ParameterDiscreteValue  ' ParameterField for 2nd param
            Dim field2 As New ParameterField  'ParameterDiscreteValue for 1st param
            Dim value2 As New ParameterDiscreteValue 'ParameterDiscreteValue for 2nd param
            Dim field3 As New ParameterField
            Dim value3 As New ParameterDiscreteValue
            Dim field4 As New ParameterField
            Dim value4 As New ParameterDiscreteValue
            Dim field5 As New ParameterField
            Dim value5 As New ParameterDiscreteValue
            'Now set first param
            field1.ParameterFieldName = "fromdate"
            value1.Value = fromdat
            field1.CurrentValues.Add(value1)
            p1.Add(field1)
            field2.ParameterFieldName = "Todate"
            value2.Value = todate
            field2.CurrentValues.Add(value2)
            p1.Add(field2)
            field3.ParameterFieldName = "title"
            value3.Value = Title
            field3.CurrentValues.Add(value3)
            p1.Add(field3)
            field4.ParameterFieldName = "Comapnyname"
            value4.Value = comname
            field4.CurrentValues.Add(value4)
            p1.Add(field4)
            field5.ParameterFieldName = "Address"
            value5.Value = ""
            field5.CurrentValues.Add(value5)
            p1.Add(field5)
            Return p1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String
        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        Dim i As Integer
        strReplicate = ""
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate
    End Function
    Function AmtInWord(ByVal Num As Decimal) As String
        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = NumToWord(CDbl(strNum)) + IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + IIf(CDbl(strNumDec) > 0, " and " + cWord3(CDbl(strNumDec)) + " Paise", "")
        Else
            StrWord = NumToWord(CDbl(strNum)) + IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ")
        End If
        AmtInWord = StrWord & " Only"
        Return AmtInWord
    End Function
    Function NumToWord(ByVal Num As Decimal) As String
        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord
    End Function
    Function cWordG3(ByVal Num As Decimal) As String
        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3
    End Function
    Function cWord3(ByVal Num As Decimal) As String
        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3
    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, _
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, _
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, _
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, _
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, _
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"}, _
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord
    End Function
    Public Function fdat(ByVal s As String) As String
        Try

            Dim date1 As String
            Dim dat As New Date
            dat = s
            If dat.Month < 10 Then
                If dat.Day < 10 Then
                    Return "0" & dat.Day & "0" & dat.Month & dat.Year
                Else
                    Return dat.Day & "0" & dat.Month & dat.Year
                End If
            Else
                Return dat.Day & dat.Month & dat.Year
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Sub numbersonly(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If e.KeyChar >= "0" And e.KeyChar <= "9" = False Then
                If e.KeyChar <> "." Then
                    e.Handled = True
                Else
                    MsgBox(sender.text.Contains("."))
                    If sender.Text.Contains(".") Then
                        e.Handled = True
                    End If
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub tital(ByVal frm As Form)

    End Sub
    Public Sub datagridcolor(ByRef dg As DataGridView)
        dg.DefaultCellStyle.BackColor = My.Settings.gridbackcolor
        dg.DefaultCellStyle.ForeColor = My.Settings.gridforecolor
    End Sub
    Public Function lotn(ByVal a As String) As String
        a = a.ToUpper().Trim
        If a.Chars(0) <= "Z" And a.Chars(0) >= "A" Then
            MsgBox("LotNo cannot start with Alphabet")
            GoTo en
        End If
        Dim i As Integer
        For i = 0 To a.Length - 1
            If a.Chars(i) <= "Z" And a.Chars(i) >= "A" Then
                If i <> 1 Then
                    Return a.Substring(0, i)
                    '  TextBox3.Text = TextBox1.Text.Substring(i)
                    GoTo en
                Else
                    Return a.Substring(0, 1)
                    '  TextBox3.Text = TextBox1.Text.Substring(1)
                    GoTo en
                End If
            End If
        Next
        Return a
en:
    End Function
    Public Function lotc(ByVal a As String) As String
        Dim b As String = ""
        a = a.ToUpper().Trim
        If a.Chars(0) <= "Z" And a.Chars(0) >= "A" Then
            MsgBox("LotNo cannot start with Alphabet")
            GoTo en
        End If
        Dim i As Integer
        For i = 0 To a.Length - 1
            If a.Chars(i) <= "Z" And a.Chars(i) >= "A" Then
                If i <> 1 Then
                    '    Return a.Substring(0, i)
                    Return a.Substring(i)
                    GoTo en
                Else
                    '  Return a.Substring(0, 1)
                    Return a.Substring(1)
                    GoTo en
                End If
            End If
        Next
        Return b
en:
    End Function
    Public Sub update1(ByRef p As ProgressBar, ByRef dat1 As String)
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim li As New ListBox
            cmd = New SqlCommand("select distinct lotno from tbllotr", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                li.Items.Add(dr.Item(0))
            End While
            dr.Close()
            p.Maximum = 3000
            p.Step = 1

            Dim i As Integer
            Dim gbalmtr As Decimal = 0
            Dim gbalpcs As Decimal = 0
            Dim lotsr As New ListBox
            Dim gbalmtr2 As Decimal = 0
            Dim dat As New Date
            dat = dat1
            Dim j As Integer
            connect()

            cmd = New SqlCommand("Update tblLotrt set gbalmtr=gmtr", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Update tblLotr set gbalpcs=gpcs", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Update tblLotr set gbalmtr=gmtr", cn)
            cmd.ExecuteNonQuery()

            '            close1()

            For i = 0 To li.Items.Count - 1
                gbalmtr = 0
                gbalmtr2 = 0
                gbalpcs = 0
                lotsr.Items.Clear()
                cmd = New SqlCommand("select distinct sr from tblLotrt where lotno='" & li.Items(i).ToString & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    lotsr.Items.Add(dr.Item(0))
                End While
                dr.Close()
                For j = 0 To lotsr.Items.Count - 1
                    gbalmtr2 = 0
                    cmd = New SqlCommand("select sum(grmtr) from salet where lotno='" & li.Items(i).ToString & "' and srno=" & lotsr.Items(j).ToString & " and billdt<='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' group by srno,lotno", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        gbalmtr2 = dr.Item(0)
                    End While
                    dr.Close()
                    cmd = New SqlCommand("Update tbllotrt set gbalmtr=gmtr-'" & gbalmtr2 & "' where lotno='" & li.Items(i).ToString & "' and sr=" & lotsr.Items(j).ToString, cn)
                    cmd.ExecuteNonQuery()
                Next
                cmd = New SqlCommand("select sum(grmtr) from salet where lotno='" & li.Items(i).ToString & "' and billdt<='" & dat.Month & "-" & dat.Day & "-" & dat.Year & "' group by lotno", cn)
                dr = cmd.ExecuteReader
                gbalmtr = 0
                While dr.Read
                    gbalmtr = dr.Item(0)
                End While
                dr.Close()
                cmd = New SqlCommand("select count(grmtr) from salet where lotno='" & li.Items(i).ToString & "' and grmtr>0 group by lotno", cn)
                dr = cmd.ExecuteReader
                gbalpcs = 0
                While dr.Read
                    gbalpcs = dr.Item(0)
                End While
                dr.Close()
                cmd = New SqlCommand("Update tblLotr set gbalmtr=gmtr - '" & gbalmtr & "' where lotno='" & li.Items(i).ToString & "'", cn)
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("Update tblLotr set gbalpcs=gpcs - '" & gbalpcs & "' where lotno='" & li.Items(i).ToString & "'", cn)
                cmd.ExecuteNonQuery()
                Try
                    p.Increment(p.Step)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                'cmd=New SqlCommand ("select grmtr from salet where lotno='" & 
            Next
            MsgBox("Success")
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Module
