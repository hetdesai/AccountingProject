Imports System.Data.OleDb
Public Class frmbShow
    Dim cmd As New OleDbCommand
    Dim da As New OleDbDataAdapter
    Dim dr As OleDbDataReader
    Dim ds As New DataSet
    Dim x As Integer = 100
    Dim y As Integer = 100
    Dim count As Integer = 0
    Private Sub frmbShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "BirthDay Notification"
        DataGridView1.SendToBack()
        Connect()
        cmd = New OleDbCommand("Select * from tblStudentInfo", cn)
        dr = cmd.ExecuteReader
        While dr.Read
            Dim dat As Date = dr.Item("DateOfBirthday")
            Dim dat2 As Date
            dat2 = dat.Day & "-" & dat.Month & "-" & Today.Year
            Dim dat1 As Date = "20-10-2011"
            Dim dat3 As Date = "27-10-2011"
            dat = dr.Item("DateOfBirthday")
            If frmBirthDayNotification.bcheck = 1 Then
                If DateDiff(DateInterval.Day, dat2, DateAdd(DateInterval.Day, 7, Date.Today)) < 7 And DateDiff(DateInterval.Day, dat2, DateAdd(DateInterval.Day, 7, Date.Today)) > -1 Then
                    DataGridView1.Rows.Add()
                    DataGridView1.Item(0, count).Value = (DateDiff(DateInterval.Day, dat2, DateAdd(DateInterval.Day, 7, Date.Today)))
                    DataGridView1.Item(1, count).Value = dr.Item("ID")
                    count = count + 1
                End If
             End If

            If frmBirthDayNotification.bcheck = 2 Then
                If dat.Month = Today.Month Then
                    DataGridView1.Rows.Add()
                    DataGridView1.Item(0, count).Value = (DateDiff(DateInterval.Day, dat2, DateAdd(DateInterval.Day, 7, Date.Today)))
                    DataGridView1.Item(1, count).Value = dr.Item("ID")
                    count = count + 1

                End If
            End If

            If frmBirthDayNotification.bcheck = 3 Then
                '       MsgBox(dat.Month)
                '      MsgBox(Today.Month + 1)

                If dat.Month = Today.Month + 1 Then

                    DataGridView1.Rows.Add()
                    DataGridView1.Item(0, count).Value = (DateDiff(DateInterval.Day, dat2, DateAdd(DateInterval.Day, 7, Date.Today)))
                    DataGridView1.Item(1, count).Value = dr.Item("ID")
                    count = count + 1

                End If
            End If
            If frmBirthDayNotification.bcheck = 4 Then
                '       MsgBox(dat.Month)
                '      MsgBox(Today.Month + 1)
                '     MsgBox(DateDiff(DateInterval.Day, dat2, CDate(frmBirthDayNotification.MaskedTextBox1.Text)))

                If DateDiff(DateInterval.Day, dat2, CDate(frmBirthDayNotification.MaskedTextBox1.Text)) <= 0 And DateDiff(DateInterval.Day, dat2, CDate(frmBirthDayNotification.MaskedTextBox2.Text)) >= 0 Then
                    DataGridView1.Rows.Add()
                    DataGridView1.Item(0, count).Value = (DateDiff(DateInterval.Day, dat2, DateAdd(DateInterval.Day, 7, Date.Today)))
                    DataGridView1.Item(1, count).Value = dr.Item("ID")
                    count = count + 1

                End If


            End If


        End While
        dr.Close()

        Dim i As Integer
        DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        For i = 0 To count - 1
            Connect()

            cmd = New OleDbCommand("Select * from tblStudentInfo Where ID=" & DataGridView1.Item(1, i).Value, cn)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim picture As New PictureBox
                Dim point As New Point
                point.X = x
                point.Y = y
                picture.Location = point
                picture.Height = 100
                picture.Load("C:\ITSoftware\Images\" & dr.Item("ID"))
                '  picture.Load("E:\My VB WORK\" & "A2")
                picture.SizeMode = PictureBoxSizeMode.StretchImage
                Me.Controls.Add(picture)

                Dim lblstname As New Label
                Dim pointname As New Point
                pointname.X = 100 + 100
                pointname.Y = y
                lblstname.Width = 200
                lblstname.Text = dr.Item("St_SName") & " " & dr.Item("St_FName") & " " & dr.Item("St_MName")
                lblstname.Location = pointname
                lblstname.Font = New Font("Arial", 11, FontStyle.Bold)
                Me.Controls.Add(lblstname)
                x = x + 300
                Dim lblschool As New Label
                Dim pointschool As New Point
                pointschool.X = x
                pointschool.Y = y
                lblschool.Width = 100
                lblschool.Text = dr.Item("SchoolName")
                lblschool.Location = pointschool
                lblschool.Font = New Font("Arial", 11, FontStyle.Bold)
                Me.Controls.Add(lblschool)
                x = x + 150
                Dim lblstd As New Label
                Dim pointstd As New Point
                pointstd.X = x
                pointstd.Y = y
                lblstd.Width = 30
                lblstd.Text = dr.Item("Standard")
                lblstd.Location = pointstd
                lblstd.Font = New Font("Arial", 11, FontStyle.Bold)
                Me.Controls.Add(lblstd)
                x = x + 50
                Dim lbldiv As New Label
                Dim pointdiv As New Point
                pointdiv.X = x
                pointdiv.Y = y
                lbldiv.Width = 20
                lbldiv.Text = dr.Item("Div")
                lbldiv.Location = pointdiv
                lbldiv.Font = New Font("Arial", 11, FontStyle.Bold)
                Me.Controls.Add(lbldiv)
                x = x + 50
                Dim lbldate As New Label
                Dim pointdate As New Point
                pointdate.X = x
                pointdate.Y = y
                lbldate.Width = 100
                lbldate.Text = Format(dr.Item("DateOfBirthday"), "dd-MM-yyyy")
                lbldate.Location = pointdate
                lbldate.Font = New Font("Arial", 11, FontStyle.Bold)
                Me.Controls.Add(lbldate)
                x = x + 100
                Dim lblday As New Label
                Dim pointday As New Point
                pointday.X = x
                pointday.Y = y
                lblday.Width = 50
                lblday.Font = New Font("Arial", 11, FontStyle.Bold)
                Dim tempdate As New Date
                tempdate = CDate(dr.Item("DateOfBirthday").ToString).Day & "-" & CDate(dr.Item("DateOfBirthday").ToString).Month & "-" & Date.Today.Year
                If (tempdate.DayOfWeek = DayOfWeek.Friday) Then
                    lblday.Text = "Friday"
                End If
                If (tempdate.DayOfWeek = DayOfWeek.Monday) Then
                    lblday.Text = "Monday"
                End If
                If (tempdate.DayOfWeek = DayOfWeek.Saturday) Then
                    lblday.Text = "Saturday"
                End If
                If (tempdate.DayOfWeek = DayOfWeek.Sunday) Then
                    lblday.Text = "Sunday"
                End If
                If (tempdate.DayOfWeek = DayOfWeek.Thursday) Then
                    lblday.Text = "Thursday"
                End If
                If (tempdate.DayOfWeek = DayOfWeek.Tuesday) Then
                    lblday.Text = "Tuesday"
                End If
                If (tempdate.DayOfWeek = DayOfWeek.Wednesday) Then
                    lblday.Text = "Wednesday"
                End If
                lblday.Font = New Font("Arial", 11, FontStyle.Bold)
                lblday.Location = pointday
                Me.Controls.Add(lblday)
                x = x + 200
                Dim lblcon As New Label
                lblcon.Text = dr.Item("MobileNo")
                Dim pointcon As New Point
                pointcon.X = x
                pointcon.Y = y
                lblday.Width = 200
                lblcon.Font = New Font("Arial", 11, FontStyle.Bold)
                lblcon.Location = pointcon
                Me.Controls.Add(lblcon)
                x = 100
                y = y + 110
            End While
            dr.Close()
            Close1()

        Next

        Close1()

    End Sub
End Class