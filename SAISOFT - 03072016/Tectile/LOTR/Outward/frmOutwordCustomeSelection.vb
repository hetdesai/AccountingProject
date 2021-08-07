Imports System.Data.SqlClient
Imports System.Drawing.Text

Public Class frmOutwordCustomeSelection
    Public vrno As String = ""
    Public bkname As String = ""
    Public bkcode As String = ""
    Public chno As String = ""
    Public chdt As String = ""
    Public billno As String = ""
    Public oubno As String = ""
    Public billdt As String = ""
    Public Name As String = ""
    Public NameCr As String = ""
    Public SrNo As String = ""
    Public Itname As String = ""
    Public Itcode As String = ""
    Public Pcs As String = ""
    Public PACK As String = ""
    Public Qty As String = ""
    Public Rate As String = ""
    Public Unit As String = ""
    Public Amount As String = ""
    Public Accode As String = ""
    Public Accodecr As String = ""
    Public prcode As String = ""
    Public Process As String = ""
    Public Style As String = ""
    Public Shade As String = ""
    Public mstcode As String = ""
    Public mst As String = ""
    Public width1 As String = ""
    Public Grpcs As String = ""
    Public GrMtr As String = ""
    Public Grrate As String = ""
    Public GrVAL As String = ""
    Public Desgno As String = ""
    Public lotno As String = ""
    Public shortage As String = ""
    Public remark As String = ""
    Public machineno As String = ""
    Public Groupp1 As String = ""
    Public Groupp2 As String = ""
    Public Groupp3 As String = ""
    Public Groupp4 As String = ""
    Public Groupp5 As String = ""
    Public Groupp6 As String = ""
    Public Groupp7 As String = ""
    Public groupp8 As String = ""
    Public groupp9 As String = ""
    Public group1 As String = ""
    Public group2 As String = ""
    Public group3 As String = ""
    Public group4 As String = ""
    Public group5 As String = ""
    Public group6 As String = ""
    Public group7 As String = ""
    Public group8 As String = ""
    Public group9 As String = ""
    Public detailsrequired As String = ""
    Public Sub initializeVariables()
        vrno = "VrNo"
        bkname = "BkName"
        bkcode = "BkCode"
        chno = "ChNo"
        chdt = "ChDt"
        billno = "BillNo"
        oubno = "OubNo"
        billdt = "BillDt"
        Name = "Name"
        NameCr = "NameCr"
        SrNo = "SrNo"
        Itname = "ITName"
        Itcode = "ITCode"
        Pcs = "Pcs"
        PACK = "Pack"
        Qty = "Qty"
        Rate = "Rate"
        Unit = "Unit"
        Amount = "Amount"
        Accode = "ACCode"
        Accodecr = "ACCodeCr"
        prcode = "prcode"
        Process = "process"
        Style = "Style"
        Shade = "Shade"
        mstcode = "mstcode"
        mst = "mst"
        width1 = "width"
        Grpcs = "Grpcs"
        GrMtr = "GrMtr"
        Grrate = "Grrate"
        GrVAL = "GrVAL"
        Desgno = "Desgno"
        lotno = "lotno"
        shortage = "shortage"
        remark = "remark"
        machineno = "machineno"
        Groupp1 = ""
        Groupp2 = ""
        Groupp3 = ""
        Groupp4 = ""
        Groupp5 = ""
        Groupp6 = ""
        Groupp7 = ""
        groupp8 = ""
        groupp9 = ""
        detailsrequired = ""

    End Sub
    Private Sub frmOutwordCustomeSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddFonts()
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SALE1'", cn)
            dr = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr.Item(0))
            End While
            dr.Close()

            cmd = New SqlCommand("Select Distinct Report_Name from Custome_Report1 where Main_Table='SALE1'", cn)
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

    Private Sub AddFonts()

        Dim dgvc As DataGridViewComboBoxColumn
        Dim dgvc1 As DataGridViewComboBoxColumn
        dgvc = DG1.Columns(8)
        dgvc1 = DG2.Columns(6)
        Dim installed_fonts As New InstalledFontCollection
        '   ComboBox2.Items.Clear()
        For Each font_family As FontFamily In _
            installed_fonts.Families
            dgvc.Items.Add(font_family.Name)
            dgvc1.Items.Add(font_family.Name)
            '      ComboBox2.Items.Add(font_family.Name)
        Next font_family
        ' ComboBox2.SelectedIndex = 0

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            DG1.Rows.Clear()
            Dim i As Integer
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                DG1.Rows.Add()
                DG1.Item(1, i).Value = i + 1
                DG1.Item(0, DG1.RowCount - 1).Value = CheckedListBox1.CheckedItems(i).ToString
                cmd = New SqlCommand("Select width from tblFieldWidth where Field_Name='" & DG1.Item(0, DG1.RowCount - 1).Value & "'", cn)
                dr = cmd.ExecuteReader
                While dr.Read
                    DG1.Item(6, i).Value = dr.Item(0)
                End While

                dr.Close()
                DG1.Item(2, i).Value = 200
                DG1.Item(3, i).Value = 1000
                DG1.Item(4, i).Value = "CRBLACK"
                DG1.Item(5, i).Value = "9"
                DG1.Item(8, i).Value = "Arial"
            Next
            close1()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            DG2.Rows.Clear()
            Dim i As Integer
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                DG2.Rows.Add()
                DG2.Item(1, i).Value = i + 1
                DG2.Item(0, i).Value = CheckedListBox1.CheckedItems(i).ToString
                DG2.Item(2, i).Value = "CRBLACK"
                DG2.Item(3, i).Value = "9"
                DG2.Item(4, i).Value = True
                DG2.Item(5, i).Value = True
                DG2.Item(6, i).Value = "Arial"
                DG2.Item(7, i).Value = True
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
    End Sub
    Public Sub GetFields()
        Dim i As Integer

        For i = 0 To DG1.Rows.Count - 1

            Select Case DG1.Item(0, i).Value.ToString.ToUpper
                Case "VRNO"
                    vrno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "BKNAME"
                    bkname = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "BKCODE"
                    bkcode = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "CHNO"
                    chno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "CHDT"
                    chdt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "BILLNO"
                    billno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "OUBNO"
                    oubno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "BILLDT"
                    billdt = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "NAME"
                    Name = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "NAMECR"
                    NameCr = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "SRNO"
                    SrNo = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "ITNAME"
                    Itname = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "ITCODE"
                    Itcode = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "PCS"
                    Pcs = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "PACK"
                    PACK = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "QTY"
                    Qty = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "RATE"
                    Rate = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "UNIT"
                    Unit = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "AMOUNT"
                    Amount = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "ACCODE"
                    Accode = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "ACCODECR"
                    Accodecr = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "PRCODE"
                    prcode = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "PROCESS"
                    Process = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "STYLE"
                    Style = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "SHADE"
                    Shade = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "MSTCODE"
                    mstcode = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "MST"
                    mst = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "WIDTH"
                    width1 = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "GRPCS"
                    Grpcs = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "GRMTR"
                    GrMtr = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "GRVAL"
                    GrVAL = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "DESGNO"
                    Desgno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "LOTNO"
                    lotno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "SHORTAGE"
                    shortage = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "REMARK"
                    remark = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value
                Case "MACHINENO"
                    machineno = DG1.Item(1, i).Value & " " & DG1.Item(2, i).Value & " " & DG1.Item(3, i).Value & " " & DG1.Item(4, i).Value & " " & DG1.Item(5, i).Value & " " & DG1.Item(6, i).Value & " $" & DG1.Item(8, i).Value

            End Select
        Next
        detailsrequired = CheckBox1.Checked

        Try
            Groupp1 = DG2.Item(2, 0).Value & " " & DG2.Item(3, 0).Value & " " & DG2.Item(4, 0).Value.ToString & " " & DG2.Item(5, 1).Value.ToString & " " & DG2.Item(7, 0).Value & " $" & DG2.Item(6, 0).Value
            Groupp2 = DG2.Item(2, 1).Value & " " & DG2.Item(3, 1).Value & " " & DG2.Item(4, 1).Value.ToString & " " & DG2.Item(5, 1).Value.ToString & " " & DG2.Item(7, 1).Value & " $" & DG2.Item(6, 1).Value
            Groupp3 = DG2.Item(2, 2).Value & " " & DG2.Item(3, 2).Value & " " & DG2.Item(4, 2).Value.ToString & " " & DG2.Item(5, 2).Value.ToString & " " & DG2.Item(7, 2).Value & " $" & DG2.Item(6, 2).Value
            Groupp4 = DG2.Item(2, 3).Value & " " & DG2.Item(3, 3).Value & " " & DG2.Item(4, 3).Value.ToString & " " & DG2.Item(5, 3).Value.ToString & " " & DG2.Item(7, 3).Value & " $" & DG2.Item(6, 3).Value
            Groupp5 = DG2.Item(2, 4).Value & " " & DG2.Item(3, 4).Value & " " & DG2.Item(4, 4).Value.ToString & " " & DG2.Item(5, 4).Value.ToString & " " & DG2.Item(7, 4).Value & " $" & DG2.Item(6, 4).Value
            Groupp6 = DG2.Item(2, 5).Value & " " & DG2.Item(3, 5).Value & " " & DG2.Item(4, 5).Value.ToString & " " & DG2.Item(5, 5).Value.ToString & " " & DG2.Item(7, 5).Value & " $" & DG2.Item(6, 5).Value
            Groupp7 = DG2.Item(2, 6).Value & " " & DG2.Item(3, 6).Value & " " & DG2.Item(4, 6).Value.ToString & " " & DG2.Item(5, 6).Value.ToString & " " & DG2.Item(7, 6).Value & " $" & DG2.Item(6, 6).Value
            groupp8 = DG2.Item(2, 7).Value & " " & DG2.Item(3, 7).Value & " " & DG2.Item(4, 7).Value.ToString & " " & DG2.Item(5, 7).Value.ToString & " " & DG2.Item(7, 7).Value & " $" & DG2.Item(6, 7).Value
            groupp9 = DG2.Item(2, 8).Value & " " & DG2.Item(3, 8).Value & " " & DG2.Item(4, 8).Value.ToString & " " & DG2.Item(5, 8).Value.ToString & " " & DG2.Item(7, 8).Value & " $" & DG2.Item(6, 8).Value
        Catch ex As Exception

        End Try

        


       
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        initializeVariables()
        calleft()
        GetFields()

        Dim i As Integer
        For i = 0 To DG2.Rows.Count - 1
            If DG2.Item(1, i).Value = 1 Then
                group1 = DG2.Item(0, i).Value
            ElseIf DG2.Item(1, i).Value = 2 Then
                group2 = DG2.Item(0, i).Value

            ElseIf DG2.Item(1, i).Value = 3 Then
                group3 = DG2.Item(0, i).Value

            ElseIf DG2.Item(1, i).Value = 4 Then
                group4 = DG2.Item(0, i).Value

            ElseIf DG2.Item(1, i).Value = 5 Then
                group5 = DG2.Item(0, i).Value

            ElseIf DG2.Item(1, i).Value = 6 Then
                group6 = DG2.Item(0, i).Value

            ElseIf DG2.Item(1, i).Value = 7 Then
                group7 = DG2.Item(0, i).Value
            ElseIf DG2.Item(1, i).Value = 8 Then
                group8 = DG2.Item(0, i).Value
            ElseIf DG2.Item(1, i).Value = 9 Then
                group9 = DG2.Item(0, i).Value


            End If

        Next
        frmCustomeOutward.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            connect()
            Dim cmd1 As New SqlCommand
            ' Dim dr As SqlDataReader
            cmd1 = New SqlCommand("delete from custome_report1 where Report_Name='" & ComboBox1.Text & "' or Report_name='" & TextBox1.Text & "'", cn)
            cmd1.ExecuteNonQuery()
            cmd1 = New SqlCommand("delete from custome_report2 where Report_Name='" & ComboBox1.Text & "' or Report_name='" & TextBox1.Text & "'", cn)
            cmd1.ExecuteNonQuery()

            close1()

            initializeVariables()
            GetFields()
            Dim i As Integer
            For i = 0 To DG2.Rows.Count - 1
                If DG2.Item(1, i).Value = 1 Then
                    group1 = DG2.Item(0, i).Value
                ElseIf DG2.Item(1, i).Value = 2 Then
                    group2 = DG2.Item(0, i).Value

                ElseIf DG2.Item(1, i).Value = 3 Then
                    group3 = DG2.Item(0, i).Value

                ElseIf DG2.Item(1, i).Value = 4 Then
                    group4 = DG2.Item(0, i).Value

                ElseIf DG2.Item(1, i).Value = 5 Then
                    group5 = DG2.Item(0, i).Value

                ElseIf DG2.Item(1, i).Value = 6 Then
                    group6 = DG2.Item(0, i).Value

                ElseIf DG2.Item(1, i).Value = 7 Then
                    group7 = DG2.Item(0, i).Value

                ElseIf DG2.Item(1, i).Value = 8 Then
                    group8 = DG2.Item(0, i).Value
                ElseIf DG2.Item(1, i).Value = 9 Then
                    group9 = DG2.Item(0, i).Value

                End If

            Next
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim dat As New DateTime
            dat = Date.Now

            cmd = New SqlCommand("insert into Custome_Report1 values('SALE1','" & frmlogin.TextBox1.Text & "','" & dat.Month & "-" & dat.Day & "-" & dat.Year & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('vrno','" & vrno & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('bkname','" & bkname & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('bkcode','" & bkcode & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('chno','" & chno & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('chdt','" & chdt & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('billno','" & billno & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('oubno','" & oubno & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('billdt','" & billdt & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Name','" & Name & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('NameCr','" & NameCr & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('SrNo','" & SrNo & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Itname','" & Itname & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Itcode','" & Itcode & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Pcs','" & Pcs & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('PACK','" & PACK & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Qty','" & Qty & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Rate','" & Rate & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Unit','" & Unit & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Amount','" & Amount & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Accode','" & Accode & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Accodecr','" & Accodecr & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('prcode','" & prcode & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Process','" & Process & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Style','" & Style & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Shade','" & Shade & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('mstcode','" & mstcode & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('mst','" & mst & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('width1','" & width1 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Grpcs','" & Grpcs & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('GrMtr','" & GrMtr & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Grrate','" & Grrate & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('GrVAL','" & GrVAL & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Desgno','" & Desgno & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('lotno','" & lotno & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('shortage','" & shortage & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('remark','" & remark & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('machineno','" & machineno & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group1','" & group1 & " " & Groupp1 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group2','" & group2 & " " & Groupp2 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group3','" & group3 & " " & Groupp3 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group4','" & group4 & " " & Groupp4 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group5','" & group5 & " " & Groupp5 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group6','" & group6 & " " & Groupp6 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group7','" & group7 & " " & Groupp7 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group8','" & group8 & " " & groupp8 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Group9','" & group9 & " " & groupp9 & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("insert into Custome_Report2 values ('Detailsrequired','" & detailsrequired & "','" & TextBox1.Text & "')", cn)
            cmd.ExecuteNonQuery()

            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)



        End Try
    End Sub
    Private Sub loadVariables(reportname As String)
        Try
            connect()
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand("Select * from Custome_Report2 where Report_Name='" & reportname & "'", cn)
            dr = cmd.ExecuteReader
            While dr.Read

                Select Case dr.Item(0).ToString.ToUpper

                    Case "VRNO"

                        vrno = dr.Item(1)
                        If vrno.Length > 10 Then
                            Dim a() As String = vrno.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "VrNo"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = vrno.Split("$")(1)
                        End If
                    Case "BKNAME"
                        bkname = dr.Item(1)
                        If bkname.Length > 10 Then
                            Dim a() As String = bkname.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "BkName"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = bkname.Split("$")(1)
                        End If
                    Case "BKCODE"
                        bkcode = dr.Item(1)

                        If bkcode.Length > 10 Then
                            Dim a() As String = bkcode.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "BkCode"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = bkcode.Split("$")(1)
                        End If
                    Case "CHNO"
                        chno = dr.Item(1)
                        If chno.Length > 10 Then
                            Dim a() As String = chno.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "ChNo"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = chno.Split("$")(1)
                        End If
                    Case "CHDT"
                        chdt = dr.Item(1)
                        If chdt.Length > 10 Then
                            Dim a() As String = chdt.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "ChNo"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = chdt.Split("$")(1)
                        End If
                    Case "BILLNO"
                        billno = dr.Item(1)
                        If billno.Length > 10 Then
                            Dim a() As String = billno.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "BillNo"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = billno.Split("$")(1)
                        End If
                    Case "OUBNO"
                        oubno = dr.Item(1)
                        If oubno.Length > 10 Then
                            Dim a() As String = oubno.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "OubNo"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = oubno.Split("$")(1)
                        End If
                    Case "BILLDT"
                        billdt = dr.Item(1)
                        If billdt.Length > 10 Then
                            Dim a() As String = billdt.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "BillDt"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = billdt.Split("$")(1)
                        End If
                    Case "NAME"
                        Name = dr.Item(1)
                        If Name.Length > 10 Then
                            Dim a() As String = Name.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Name"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Name.Split("$")(1)
                        End If
                    Case "NAMECR"
                        NameCr = dr.Item(1)
                        If NameCr.Length > 10 Then
                            Dim a() As String = NameCr.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "NameCr"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = NameCr.Split("$")(1)
                        End If
                    Case "SRNO"
                        SrNo = dr.Item(1)
                        If SrNo.Length > 10 Then
                            Dim a() As String = SrNo.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "SrNo"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = SrNo.Split("$")(1)
                        End If
                    Case "ITNAME"
                        Itname = dr.Item(1)
                        If Itname.Length > 10 Then
                            Dim a() As String = Itname.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "ITName"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Itname.Split("$")(1)
                        End If
                    Case "ITCODE"
                        Itcode = dr.Item(1)
                        If Itcode.Length > 10 Then
                            Dim a() As String = Itcode.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "ITCode"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Itcode.Split("$")(1)
                        End If
                    Case "PCS"
                        Pcs = dr.Item(1)
                        If Pcs.Length > 10 Then
                            Dim a() As String = Pcs.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Pcs"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Pcs.Split("$")(1)
                        End If
                    Case "PACK"
                        PACK = dr.Item(1)
                        If PACK.Length > 10 Then
                            Dim a() As String = PACK.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Pack"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = PACK.Split("$")(1)
                        End If
                    Case "QTY"
                        Qty = dr.Item(1)
                        If Qty.Length > 10 Then
                            Dim a() As String = Qty.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Qty"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Qty.Split("$")(1)
                        End If
                    Case "RATE"
                        Rate = dr.Item(1)
                        If Rate.Length > 10 Then
                            Dim a() As String = Rate.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Rate"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Rate.Split("$")(1)
                        End If
                    Case "UNIT"
                        Unit = dr.Item(1)
                        If Unit.Length > 10 Then
                            Dim a() As String = Unit.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Unit"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Unit.Split("$")(1)
                        End If
                    Case "AMOUNT"
                        Amount = dr.Item(1)

                        If Amount.Length > 10 Then
                            Dim a() As String = Amount.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Amount"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Amount.Split("$")(1)
                        End If
                    Case "ACCODE"
                        Accode = dr.Item(1)
                        If Accode.Length > 10 Then
                            Dim a() As String = Accode.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "ACCode"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Accode.Split("$")(1)
                        End If
                    Case "ACCODECR"
                        Accodecr = dr.Item(1)
                        If Accodecr.Length > 10 Then
                            Dim a() As String = Accodecr.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "ACCodeCr"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Accodecr.Split("$")(1)
                        End If
                    Case "PRCODE"
                        prcode = dr.Item(1)
                        If prcode.Length > 10 Then
                            Dim a() As String = prcode.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Prcode"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = prcode.Split("$")(1)
                        End If
                    Case "PROCESS"
                        Process = dr.Item(1)
                        If Process.Length > 10 Then
                            Dim a() As String = Process.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Process"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Process.Split("$")(1)
                        End If
                    Case "STYLE"
                        Style = dr.Item(1)
                        If Style.Length > 10 Then
                            Dim a() As String = Style.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Style"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Style.Split("$")(1)
                        End If
                    Case "SHADE"
                        Shade = dr.Item(1)
                        If Shade.Length > 10 Then
                            Dim a() As String = Shade.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Shade"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Shade.Split("$")(1)
                        End If
                    Case "MSTCODE"
                        mstcode = dr.Item(1)
                        If mstcode.Length > 10 Then
                            Dim a() As String = mstcode.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "mstcode"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = mstcode.Split("$")(1)
                        End If
                    Case "MST"
                        mst = dr.Item(1)
                        If mst.Length > 10 Then
                            Dim a() As String = mst.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "mst"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = mst.Split("$")(1)
                        End If
                    Case "WIDTH"
                        width1 = dr.Item(1)
                        If width1.Length > 10 Then
                            Dim a() As String = width1.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Width"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = width1.Split("$")(1)
                        End If
                    Case "GRPCS"
                        Grpcs = dr.Item(1)
                        If Grpcs.Length > 10 Then
                            Dim a() As String = Grpcs.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Grpcs"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Grpcs.Split("$")(1)
                        End If
                    Case "GRMTR"
                        GrMtr = dr.Item(1)
                        If GrMtr.Length > 10 Then
                            Dim a() As String = GrMtr.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "GrMtr"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = GrMtr.Split("$")(1)
                        End If
                    Case "GRRATE"
                        Grrate = dr.Item(1)
                        If Grrate.Length > 10 Then
                            Dim a() As String = Grrate.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "GrRate"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Grrate.Split("$")(1)
                        End If
                    Case "GRVAL"
                        GrVAL = dr.Item(1)
                        If GrVAL.Length > 10 Then
                            Dim a() As String = GrVAL.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "GrVal"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = GrVAL.Split("$")(1)
                        End If
                    Case "DESGNO"
                        Desgno = dr.Item(1)
                        If Desgno.Length > 10 Then
                            Dim a() As String = Desgno.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Desgno"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = Desgno.Split("$")(1)
                        End If
                    Case "LOTNO"
                        lotno = dr.Item(1)
                        If lotno.Length > 10 Then
                            Dim a() As String = lotno.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "lotno"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = lotno.Split("$")(1)
                        End If
                    Case "SHORTAGE"
                        shortage = dr.Item(1)
                        If shortage.Length > 10 Then
                            Dim a() As String = shortage.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "shortage"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = shortage.Split("$")(1)
                        End If
                    Case "REMARK"
                        remark = dr.Item(1)
                        If remark.Length > 10 Then
                            Dim a() As String = remark.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "Remark"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = remark.Split("$")(1)
                        End If
                    Case "MACHINENO"
                        machineno = dr.Item(1)
                        If machineno.Length > 10 Then
                            Dim a() As String = machineno.Split()
                            DG1.Rows.Add()
                            DG1.Item(0, DG1.Rows.Count - 1).Value = "MachineNo"
                            DG1.Item(1, DG1.Rows.Count - 1).Value = a(0)
                            DG1.Item(2, DG1.Rows.Count - 1).Value = a(1)
                            DG1.Item(3, DG1.Rows.Count - 1).Value = a(2)
                            DG1.Item(4, DG1.Rows.Count - 1).Value = a(3)
                            DG1.Item(5, DG1.Rows.Count - 1).Value = a(4)
                            DG1.Item(6, DG1.Rows.Count - 1).Value = a(5)
                            DG1.Item(8, DG1.Rows.Count - 1).Value = machineno.Split("$")(1)
                        End If
                    Case "GROUP1"

                        If dr.Item(1).ToString.Length > 10 Then
                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "1"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If

                    Case "GROUP2"
                        If dr.Item(1).ToString.Length > 10 Then

                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "2"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If

                    Case "GROUP3"
                        If dr.Item(1).ToString.Length > 10 Then

                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "3"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If

                    Case "GROUP4"

                        If dr.Item(1).ToString.Length > 10 Then
                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "4"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If

                    Case "GROUP5"

                        If dr.Item(1).ToString.Length > 10 Then
                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "5"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If

                    Case "GROUP6"
                        MessageBox.Show(dr.Item(1).ToString.Length)
                        If dr.Item(1).ToString.Length > 10 Then
                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "6"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If

                    Case "GROUP7"

                        If dr.Item(1).ToString.Length > 10 Then
                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "7"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If
                    Case "GROUP8"

                        If dr.Item(1).ToString.Length > 10 Then
                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "8"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If
                    Case "GROUP9"

                        If dr.Item(1).ToString.Length > 10 Then
                            DG2.Rows.Add()
                            DG2.Item(0, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(0)
                            DG2.Item(1, DG2.Rows.Count - 1).Value = "9"
                            DG2.Item(2, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(1)
                            DG2.Item(3, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(2)
                            DG2.Item(4, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(3)
                            DG2.Item(5, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(4)
                            DG2.Item(7, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split()(5)
                            DG2.Item(6, DG2.Rows.Count - 1).Value = dr.Item(1).ToString.Split("$")(1)
                        End If
                    Case "DetailsRequired"
                        CheckBox1.Checked = dr.Item(1)
                End Select
            End While
            dr.Close()
            close1()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DG1.Rows.Clear()
        DG2.Rows.Clear()
        loadVariables(ComboBox1.Text)
        TextBox1.Visible = False
        TextBox1.Text = ComboBox1.Text
    End Sub

    
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ComboBox1.Visible = False
        ComboBox1.Text = ""
        TextBox1.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            TextBox2.Text = DG1.Item(0, DG1.CurrentCell.RowIndex).Value
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            connect()
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("delete from tblFieldWidth where Field_Name='" & TextBox2.Text & "'", cn)
            cmd.ExecuteNonQuery()
            ' MessageBox.Show("insert into tblFieldWidth values('" & TextBox2.Text & "'," & Val(TextBox3.Text) & ")")
            cmd = New SqlCommand("insert into tblFieldWidth values('" & TextBox2.Text & "'," & Val(TextBox3.Text) & ")", cn)
            cmd.ExecuteNonQuery()
            close1()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        calleft()
    End Sub
    Public Sub calleft()
        Try

       
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        connect()
        Dim i As Integer
        Dim j As Integer
        Dim left As Integer = 100
        Dim width As Integer = 0
        For i = 1 To 20
            For j = 0 To DG1.Rows.Count - 1
                If DG1.Item(1, j).Value = i Then
                    cmd = New SqlCommand("Select width from tblFieldWidth where Field_Name='" & DG1.Item(0, j).Value & "'", cn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        DG1.Item(6, j).Value = left + width + 10
                        width = width + Val(dr.Item(0))
                    End While
                    dr.Close()
                End If
            Next
        Next
            close1()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class